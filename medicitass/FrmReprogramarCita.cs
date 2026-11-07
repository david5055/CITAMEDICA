using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmReprogramarCita : Form
    {
        private Conexion conexion = new Conexion();
        private int idDoctorSeleccionado = 0;
        private int idPacienteSeleccionado = 0;
        private DateTime fechaAnteriorCita;
        private TimeSpan horaAnteriorCita;

        public FrmReprogramarCita()
        {
            InitializeComponent();
        }

        private void FrmReprogramarCita_Load(object sender, EventArgs e)
        {
            dtpNuevaFecha.MinDate = DateTime.Today;
            dtpNuevaFecha.Value = DateTime.Today;

            CargarComboUsuarios();
            LimpiarFormulario();
            CargarCitasProgramadasVigentes();
        }

        #region Carga de Datos y Citas Vigentes

        private void CargarComboUsuarios()
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = "SELECT id_usuario, nombre_usuario FROM Usuarios WHERE estado = 'Activo' ORDER BY nombre_usuario ASC";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboUsuario.DataSource = dt;
                    cboUsuario.DisplayMember = "nombre_usuario";
                    cboUsuario.ValueMember = "id_usuario";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lista de usuarios: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCitasProgramadasVigentes()
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    // Exclusivo para citas vigentes en estado 'Programada'
                    string query = @"SELECT c.id_cita AS [Código Cita],
                                            c.fecha AS [Fecha],
                                            CONVERT(VARCHAR(5), c.hora_inicio, 108) + ' - ' + CONVERT(VARCHAR(5), c.hora_fin, 108) AS [Horario],
                                            (p.nombres + ' ' + p.apellidos) AS [Paciente],
                                            ('Dr. ' + d.nombres + ' ' + d.apellidos) AS [Doctor],
                                            c.id_doctor AS [IdDoctor],
                                            c.id_paciente AS [IdPaciente],
                                            c.hora_inicio AS [HoraInicioRaw]
                                     FROM Citas c
                                     INNER JOIN Pacientes p ON c.id_paciente = p.id_paciente
                                     INNER JOIN Doctores d ON c.id_doctor = d.id_doctor
                                     WHERE c.estado = 'Programada' 
                                       AND (c.fecha > CAST(GETDATE() AS DATE) 
                                            OR (c.fecha = CAST(GETDATE() AS DATE) AND c.hora_inicio >= CAST(GETDATE() AS TIME)))
                                     ORDER BY c.fecha ASC, c.hora_inicio ASC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvCitasVigentes.DataSource = dt;

                    if (dgvCitasVigentes.Columns.Contains("IdDoctor")) dgvCitasVigentes.Columns["IdDoctor"].Visible = false;
                    if (dgvCitasVigentes.Columns.Contains("IdPaciente")) dgvCitasVigentes.Columns["IdPaciente"].Visible = false;
                    if (dgvCitasVigentes.Columns.Contains("HoraInicioRaw")) dgvCitasVigentes.Columns["HoraInicioRaw"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la lista de citas programadas: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarBloquesHorarioDisponibles()
        {
            cboNuevaHora.Items.Clear();

            if (idDoctorSeleccionado <= 0) return;

            DateTime nuevaFecha = dtpNuevaFecha.Value.Date;
            TimeSpan horaInicioJornada = new TimeSpan(8, 0, 0);
            TimeSpan horaFinJornada = new TimeSpan(17, 0, 0);
            TimeSpan incremento = TimeSpan.FromMinutes(30);

            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();

                    for (TimeSpan hora = horaInicioJornada; hora < horaFinJornada; hora = hora.Add(incremento))
                    {
                        string query = "SELECT dbo.fn_HorarioDisponible(@id_doctor, @fecha, @hora)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id_doctor", idDoctorSeleccionado);
                            cmd.Parameters.AddWithValue("@fecha", nuevaFecha);
                            cmd.Parameters.AddWithValue("@hora", hora);

                            object res = cmd.ExecuteScalar();
                            bool disponible = (res != null && res != DBNull.Value) ? Convert.ToBoolean(res) : false;

                            if (disponible)
                            {
                                cboNuevaHora.Items.Add(hora.ToString(@"hh\:mm"));
                            }
                        }
                    }
                }

                if (cboNuevaHora.Items.Count > 0)
                {
                    cboNuevaHora.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("El doctor no posee horarios disponibles para la nueva fecha elegida.", "Sin Disponibilidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener bloques de horario: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtIdCita.Clear();
            txtHorarioActual.Clear();
            txtPaciente.Clear();
            txtDoctor.Clear();
            cboNuevaHora.Items.Clear();
            idDoctorSeleccionado = 0;
            idPacienteSeleccionado = 0;

            btnReprogramar.Enabled = false;
        }

        #endregion

        #region Operación Transaccional: Reprogramar Cita

        private void btnReprogramar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones de interfaz
            if (string.IsNullOrEmpty(txtIdCita.Text))
            {
                MessageBox.Show("Seleccione una cita de la tabla para reprogramar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboNuevaHora.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar el nuevo bloque de hora libre.", "Horario requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNuevaHora.Focus();
                return;
            }

            if (cboUsuario.SelectedValue == null)
            {
                MessageBox.Show("Seleccione el usuario que autoriza y registra el cambio.", "Usuario requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboUsuario.Focus();
                return;
            }

            int idCita = Convert.ToInt32(txtIdCita.Text);
            int idUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
            DateTime fechaNueva = dtpNuevaFecha.Value.Date;
            TimeSpan horaNuevaInicio = TimeSpan.Parse(cboNuevaHora.SelectedItem.ToString());
            TimeSpan horaNuevaFin = horaNuevaInicio.Add(TimeSpan.FromMinutes(30));

            // Si intenta reprogramar para la misma fecha y misma hora exactamente
            if (fechaNueva == fechaAnteriorCita && horaNuevaInicio == horaAnteriorCita)
            {
                MessageBox.Show("La fecha y hora seleccionadas son idénticas al horario actual de la cita.", "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación detallada de comparación (Fecha/Hora Previa vs Fecha/Hora Nueva)
            string mensajeConfirmacion = $"¿Está seguro de reprogramar la Cita N° {idCita}?\n\n" +
                                         $"• Paciente: {txtPaciente.Text}\n" +
                                         $"• Doctor: {txtDoctor.Text}\n\n" +
                                         $"[HORARIO ANTERIOR]: {fechaAnteriorCita:dd/MM/yyyy} a las {horaAnteriorCita:hh\\:mm}\n" +
                                         $"[NUEVO HORARIO]: {fechaNueva:dd/MM/yyyy} a las {horaNuevaInicio:hh\\:mm}";

            DialogResult confirmacion = MessageBox.Show(mensajeConfirmacion, "Confirmar Cambio de Horario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion != DialogResult.Yes) return;

            using (SqlConnection conn = conexion.Conectar())
            {
                conn.Open();

                // 2. Verificación de disponibilidad del doctor (excluyendo la cita actual)
                string queryCheckDoctor = @"SELECT COUNT(*) FROM Citas 
                                           WHERE id_doctor = @id_doctor 
                                             AND fecha = @fecha 
                                             AND hora_inicio = @hora_inicio 
                                             AND estado = 'Programada'
                                             AND id_cita <> @id_cita";

                using (SqlCommand cmdDoc = new SqlCommand(queryCheckDoctor, conn))
                {
                    cmdDoc.Parameters.AddWithValue("@id_doctor", idDoctorSeleccionado);
                    cmdDoc.Parameters.AddWithValue("@fecha", fechaNueva);
                    cmdDoc.Parameters.AddWithValue("@hora_inicio", horaNuevaInicio);
                    cmdDoc.Parameters.AddWithValue("@id_cita", idCita);

                    int countDoc = Convert.ToInt32(cmdDoc.ExecuteScalar());
                    if (countDoc > 0)
                    {
                        MessageBox.Show("El doctor ya cuenta con otra cita programada en esa nueva fecha y hora.", "Horario Ocupado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // 3. Verificación de sobreposición para el paciente (excluyendo la cita actual)
                string queryCheckPaciente = @"SELECT COUNT(*) FROM Citas 
                                             WHERE id_paciente = @id_paciente 
                                               AND fecha = @fecha 
                                               AND hora_inicio = @hora_inicio 
                                               AND estado = 'Programada'
                                               AND id_cita <> @id_cita";

                using (SqlCommand cmdPac = new SqlCommand(queryCheckPaciente, conn))
                {
                    cmdPac.Parameters.AddWithValue("@id_paciente", idPacienteSeleccionado);
                    cmdPac.Parameters.AddWithValue("@fecha", fechaNueva);
                    cmdPac.Parameters.AddWithValue("@hora_inicio", horaNuevaInicio);
                    cmdPac.Parameters.AddWithValue("@id_cita", idCita);

                    int countPac = Convert.ToInt32(cmdPac.ExecuteScalar());
                    if (countPac > 0)
                    {
                        MessageBox.Show("El paciente ya posee otra cita en ese nuevo horario.", "Sobreposición Horaria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // 4. Ejecución de la transacción SQL atómica (UPDATE en Citas e INSERT en Historial_Citas)
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // A. Actualizar fecha y hora en Citas
                    string queryUpdateCita = @"UPDATE Citas 
                                               SET fecha = @fecha_nueva, 
                                                   hora_inicio = @hora_inicio_nueva, 
                                                   hora_fin = @hora_fin_nueva 
                                               WHERE id_cita = @id_cita AND estado = 'Programada'";

                    using (SqlCommand cmdUpdate = new SqlCommand(queryUpdateCita, conn, transaction))
                    {
                        cmdUpdate.Parameters.AddWithValue("@id_cita", idCita);
                        cmdUpdate.Parameters.AddWithValue("@fecha_nueva", fechaNueva);
                        cmdUpdate.Parameters.AddWithValue("@hora_inicio_nueva", horaNuevaInicio);
                        cmdUpdate.Parameters.AddWithValue("@hora_fin_nueva", horaNuevaFin);

                        cmdUpdate.ExecuteNonQuery();
                    }

                    // B. Registrar auditoría con valores anteriores y nuevos en Historial_Citas
                    string queryInsertHistorial = @"INSERT INTO Historial_Citas 
                                                   (id_cita, accion, fecha_anterior, hora_anterior, fecha_nueva, hora_nueva, id_usuario, fecha_movimiento)
                                                   VALUES 
                                                   (@id_cita, 'Reprogramada', @fecha_anterior, @hora_anterior, @fecha_nueva, @hora_nueva, @id_usuario, GETDATE())";

                    using (SqlCommand cmdHist = new SqlCommand(queryInsertHistorial, conn, transaction))
                    {
                        cmdHist.Parameters.AddWithValue("@id_cita", idCita);
                        cmdHist.Parameters.AddWithValue("@fecha_anterior", fechaAnteriorCita);
                        cmdHist.Parameters.AddWithValue("@hora_anterior", horaAnteriorCita);
                        cmdHist.Parameters.AddWithValue("@fecha_nueva", fechaNueva);
                        cmdHist.Parameters.AddWithValue("@hora_nueva", horaNuevaInicio);
                        cmdHist.Parameters.AddWithValue("@id_usuario", idUsuario);

                        cmdHist.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("La cita ha sido reprogramada exitosamente dejando trazabilidad en el historial de auditoría.", "Cita Reprogramada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();
                    CargarCitasProgramadasVigentes();
                }
                catch (SqlException sqlex)
                {
                    transaction.Rollback();
                    MessageBox.Show(sqlex.Message, "Restricción de Negocio (Trigger SQL)", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error transaccional al reprogramar la cita: " + ex.Message, "Error General SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Eventos de Selección de Fila y Controles

        private void dgvCitasVigentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvCitasVigentes.Rows[e.RowIndex];

                txtIdCita.Text = fila.Cells["Código Cita"].Value.ToString();
                fechaAnteriorCita = Convert.ToDateTime(fila.Cells["Fecha"].Value);
                txtHorarioActual.Text = $"{fechaAnteriorCita:dd/MM/yyyy} ({fila.Cells["Horario"].Value})";
                txtPaciente.Text = fila.Cells["Paciente"].Value.ToString();
                txtDoctor.Text = fila.Cells["Doctor"].Value.ToString();

                idDoctorSeleccionado = Convert.ToInt32(fila.Cells["IdDoctor"].Value);
                idPacienteSeleccionado = Convert.ToInt32(fila.Cells["IdPaciente"].Value);
                horaAnteriorCita = (TimeSpan)fila.Cells["HoraInicioRaw"].Value;

                cboNuevaHora.Items.Clear();
                btnReprogramar.Enabled = true;
            }
        }

        private void dtpNuevaFecha_ValueChanged(object sender, EventArgs e)
        {
            cboNuevaHora.Items.Clear();
        }

        private void btnBuscarHorarios_Click(object sender, EventArgs e)
        {
            CargarBloquesHorarioDisponibles();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        #endregion
    }
}
