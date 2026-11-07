using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmMarcarAtendida : Form
    {
        private Conexion conexion = new Conexion();
        private TimeSpan horaInicioCita;
        private TimeSpan horaFinCita;

        public FrmMarcarAtendida()
        {
            InitializeComponent();
        }

        private void FrmMarcarAtendida_Load(object sender, EventArgs e)
        {
            dtpFechaHoy.Value = DateTime.Today;
            CargarComboDoctores();
            CargarComboUsuarios();
            LimpiarFormulario();
            CargarCitasHoy();
        }

        #region Carga de Combos y Datos de Citas

        private void CargarComboDoctores()
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = @"SELECT 0 AS id_doctor, '-- Todos los Médicos --' AS nombre_completo
                                     UNION ALL
                                     SELECT id_doctor, ('Dr. ' + nombres + ' ' + apellidos) AS nombre_completo 
                                     FROM Doctores 
                                     WHERE estado = 'Activo'";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboDoctorFiltro.DataSource = dt;
                    cboDoctorFiltro.DisplayMember = "nombre_completo";
                    cboDoctorFiltro.ValueMember = "id_doctor";
                    cboDoctorFiltro.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lista de doctores: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

                    if (dt.Rows.Count > 0)
                    {
                        cboUsuario.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lista de usuarios: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCitasHoy()
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    // Restringido estrictamente a citas en estado 'Programada' de la fecha actual
                    string query = @"SELECT c.id_cita AS [Código Cita],
                                            CONVERT(VARCHAR(5), c.hora_inicio, 108) + ' - ' + CONVERT(VARCHAR(5), c.hora_fin, 108) AS [Horario],
                                            (p.nombres + ' ' + p.apellidos) AS [Paciente],
                                            p.dui AS [DUI Paciente],
                                            ('Dr. ' + d.nombres + ' ' + d.apellidos) AS [Doctor],
                                            e.nombre AS [Especialidad],
                                            c.motivo_consulta AS [Motivo Consulta],
                                            c.hora_inicio AS [HoraInicio],
                                            c.hora_fin AS [HoraFin]
                                     FROM Citas c
                                     INNER JOIN Pacientes p ON c.id_paciente = p.id_paciente
                                     INNER JOIN Doctores d ON c.id_doctor = d.id_doctor
                                     INNER JOIN Especialidades e ON d.id_especialidad = e.id_especialidad
                                     WHERE c.fecha = CAST(GETDATE() AS DATE)
                                       AND c.estado = 'Programada'";

                    if (cboDoctorFiltro.SelectedValue != null && Convert.ToInt32(cboDoctorFiltro.SelectedValue) > 0)
                    {
                        query += " AND c.id_doctor = @id_doctor";
                    }

                    query += " ORDER BY c.hora_inicio ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (cboDoctorFiltro.SelectedValue != null && Convert.ToInt32(cboDoctorFiltro.SelectedValue) > 0)
                        {
                            cmd.Parameters.AddWithValue("@id_doctor", Convert.ToInt32(cboDoctorFiltro.SelectedValue));
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvCitasHoy.DataSource = dt;

                        if (dgvCitasHoy.Columns.Contains("HoraInicio")) dgvCitasHoy.Columns["HoraInicio"].Visible = false;
                        if (dgvCitasHoy.Columns.Contains("HoraFin")) dgvCitasHoy.Columns["HoraFin"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar las citas programadas de hoy: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtIdCita.Clear();
            txtPaciente.Clear();
            txtDoctor.Clear();
            txtObservaciones.Clear();
            horaInicioCita = TimeSpan.Zero;
            horaFinCita = TimeSpan.Zero;

            btnMarcarAtendida.Enabled = false;
        }

        #endregion

        #region Operación Transaccional: Marcar Cita Atendida

        private void btnMarcarAtendida_Click(object sender, EventArgs e)
        {
            // 1. Validar Selección de Cita
            if (string.IsNullOrEmpty(txtIdCita.Text))
            {
                MessageBox.Show("Debe seleccionar una cita programada del listado para registrar la atención.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar Captura Obligatoria de Observaciones Clínicas
            if (string.IsNullOrWhiteSpace(txtObservaciones.Text))
            {
                MessageBox.Show("Debe ingresar obligatoriamente las observaciones clínicas o el diagnóstico del paciente.", "Validación Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtObservaciones.Focus();
                return;
            }

            // 3. Validar Usuario Auditador
            if (cboUsuario.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar el usuario que realiza la operación.", "Validación Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboUsuario.Focus();
                return;
            }

            int idCita = Convert.ToInt32(txtIdCita.Text);
            int idUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
            string observacionesClinicas = txtObservaciones.Text.Trim();

            DialogResult confirmacion = MessageBox.Show(
                $"¿Desea confirmar el registro de atención para la cita N° {idCita} del paciente '{txtPaciente.Text}'?\n\nUna vez marcada como 'Atendida', su estado quedará finalizado y no podrá ser alterado.",
                "Confirmar Cierre de Cita",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes) return;

            // 4. Ejecución de la transacción SQL en Citas e Historial_Citas
            using (SqlConnection conn = conexion.Conectar())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // A. Actualizar estado a 'Atendida' (estado final) y guardar las observaciones clínicas en Citas
                    string queryUpdateCita = @"UPDATE Citas 
                                               SET estado = 'Atendida',
                                                   motivo_consulta = @observaciones
                                               WHERE id_cita = @id_cita 
                                                 AND estado = 'Programada'
                                                 AND fecha = CAST(GETDATE() AS DATE)";

                    int filasAfectadas;
                    using (SqlCommand cmdUpdate = new SqlCommand(queryUpdateCita, conn, transaction))
                    {
                        cmdUpdate.Parameters.AddWithValue("@id_cita", idCita);
                        cmdUpdate.Parameters.AddWithValue("@observaciones", observacionesClinicas);

                        filasAfectadas = cmdUpdate.ExecuteNonQuery();
                    }

                    if (filasAfectadas == 0)
                    {
                        transaction.Rollback();
                        MessageBox.Show("La cita seleccionada no pudo ser actualizada. Verifique que la cita siga en estado 'Programada' y corresponda a la fecha actual.", "Transacción Abortada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LimpiarFormulario();
                        CargarCitasHoy();
                        return;
                    }

                    // B. Insertar movimiento de auditoría en Historial_Citas
                    string queryHistorial = @"INSERT INTO Historial_Citas 
                                             (id_cita, accion, fecha_anterior, hora_anterior, fecha_nueva, hora_nueva, id_usuario, fecha_movimiento)
                                             VALUES 
                                             (@id_cita, 'Atendida', CAST(GETDATE() AS DATE), @hora_anterior, CAST(GETDATE() AS DATE), @hora_nueva, @id_usuario, GETDATE())";

                    using (SqlCommand cmdHist = new SqlCommand(queryHistorial, conn, transaction))
                    {
                        cmdHist.Parameters.AddWithValue("@id_cita", idCita);
                        cmdHist.Parameters.AddWithValue("@hora_anterior", horaInicioCita);
                        cmdHist.Parameters.AddWithValue("@hora_nueva", horaInicioCita);
                        cmdHist.Parameters.AddWithValue("@id_usuario", idUsuario);

                        cmdHist.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    MessageBox.Show("La cita médica ha sido marcada como 'Atendida' exitosamente y se registró en el historial clínico de auditoría.", "Cita Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();
                    CargarCitasHoy();
                }
                catch (SqlException sqlex)
                {
                    transaction.Rollback();
                    // Captura del TRIGGER 1 (trg_Citas_EstadoFinal - Error 50001)
                    MessageBox.Show(sqlex.Message, "Restricción de Negocio (Trigger SQL)", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al procesar la atención de la cita: " + ex.Message, "Error General SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Eventos de Selección e Interacción

        private void dgvCitasHoy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvCitasHoy.Rows[e.RowIndex];

                txtIdCita.Text = fila.Cells["Código Cita"].Value.ToString();
                txtPaciente.Text = fila.Cells["Paciente"].Value.ToString();
                txtDoctor.Text = fila.Cells["Doctor"].Value.ToString();
                txtObservaciones.Text = fila.Cells["Motivo Consulta"].Value != DBNull.Value ? fila.Cells["Motivo Consulta"].Value.ToString() : "";

                if (fila.Cells["HoraInicio"].Value != DBNull.Value)
                {
                    horaInicioCita = (TimeSpan)fila.Cells["HoraInicio"].Value;
                }
                if (fila.Cells["HoraFin"].Value != DBNull.Value)
                {
                    horaFinCita = (TimeSpan)fila.Cells["HoraFin"].Value;
                }

                btnMarcarAtendida.Enabled = true;
                txtObservaciones.Focus();
            }
        }

        private void cboDoctorFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarFormulario();
            CargarCitasHoy();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            cboDoctorFiltro.SelectedIndex = 0;
            LimpiarFormulario();
            CargarCitasHoy();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        #endregion
    }
}
