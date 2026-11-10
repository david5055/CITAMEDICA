using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmAgendarCita : Form
    {
        private Conexion conexion = new Conexion();

        public FrmAgendarCita()
        {
            InitializeComponent();
        }

        private void FrmAgendarCita_Load(object sender, EventArgs e)
        {
            dtpFecha.MinDate = DateTime.Today;
            dtpFecha.Value = DateTime.Today;

            CargarComboPacientes();
            CargarComboEspecialidades();
            CargarComboUsuarios();
            LimpiarCampos();
            CargarCitasTabla();
        }

        #region Carga de Controles Desplegables

        private void CargarComboPacientes()
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = @"SELECT id_paciente, (nombres + ' ' + apellidos + ' - DUI: ' + dui) AS nombre_completo 
                                     FROM Pacientes 
                                     WHERE estado = 'Activo' 
                                     ORDER BY nombres ASC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboPaciente.DataSource = dt;
                    cboPaciente.DisplayMember = "nombre_completo";
                    cboPaciente.ValueMember = "id_paciente";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lista de pacientes: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboEspecialidades()
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = "SELECT id_especialidad, nombre FROM Especialidades WHERE estado = 'Activo' ORDER BY nombre ASC";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboEspecialidad.DataSource = dt;
                    cboEspecialidad.DisplayMember = "nombre";
                    cboEspecialidad.ValueMember = "id_especialidad";

                    if (dt.Rows.Count > 0)
                    {
                        cboEspecialidad.SelectedIndex = 0;
                        CargarComboDoctores(Convert.ToInt32(cboEspecialidad.SelectedValue));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar especialidades: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboDoctores(int idEspecialidad)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = @"SELECT id_doctor, ('Dr. ' + nombres + ' ' + apellidos) AS nombre_doctor 
                                     FROM Doctores 
                                     WHERE estado = 'Activo' AND id_especialidad = @id_especialidad 
                                     ORDER BY nombres ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_especialidad", idEspecialidad);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cboDoctor.DataSource = dt;
                        cboDoctor.DisplayMember = "nombre_doctor";
                        cboDoctor.ValueMember = "id_doctor";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar médicos por especialidad: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarBloquesHorarioDisponibles()
        {
            cboHora.Items.Clear();

            if (cboDoctor.SelectedValue == null || cboDoctor.SelectedIndex == -1)
            {
                return;
            }

            int idDoctor = Convert.ToInt32(cboDoctor.SelectedValue);
            DateTime fechaSeleccionada = dtpFecha.Value.Date;

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
                            cmd.Parameters.AddWithValue("@id_doctor", idDoctor);
                            cmd.Parameters.AddWithValue("@fecha", fechaSeleccionada);
                            cmd.Parameters.AddWithValue("@hora", hora);

                            object res = cmd.ExecuteScalar();
                            bool disponible = (res != null && res != DBNull.Value) ? Convert.ToBoolean(res) : false;

                            if (disponible)
                            {
                                cboHora.Items.Add(hora.ToString(@"hh\:mm"));
                            }
                        }
                    }
                }

                if (cboHora.Items.Count > 0)
                {
                    cboHora.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("El médico no posee bloques de horario disponibles para la fecha seleccionada.", "Sin Disponibilidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar bloques de horario libres: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCitasTabla()
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = @"SELECT c.id_cita AS [Cita N°],
                                            CONVERT(VARCHAR(5), c.hora_inicio, 108) + ' - ' + CONVERT(VARCHAR(5), c.hora_fin, 108) AS [Horario],
                                            (p.nombres + ' ' + p.apellidos) AS [Paciente],
                                            ('Dr. ' + d.nombres + ' ' + d.apellidos) AS [Doctor],
                                            c.motivo_consulta AS [Motivo]
                                     FROM Citas c
                                     INNER JOIN Pacientes p ON c.id_paciente = p.id_paciente
                                     INNER JOIN Doctores d ON c.id_doctor = d.id_doctor
                                     WHERE c.fecha = @fecha AND c.estado = 'Programada'
                                     ORDER BY c.hora_inicio ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fecha", dtpFecha.Value.Date);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvCitasProgramadas.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla de citas programadas: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            if (cboPaciente.Items.Count > 0) cboPaciente.SelectedIndex = 0;
            if (cboEspecialidad.Items.Count > 0) cboEspecialidad.SelectedIndex = 0;
            txtMotivoConsulta.Clear();
            if (cboUsuario.Items.Count > 0) cboUsuario.SelectedIndex = 0;
            cboHora.Items.Clear();
        }

        #endregion

        #region Eventos y Proceso Transaccional

        private void cboEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEspecialidad.SelectedValue != null && int.TryParse(cboEspecialidad.SelectedValue.ToString(), out int idEspec))
            {
                CargarComboDoctores(idEspec);
                cboHora.Items.Clear();
            }
        }

        private void cboDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboHora.Items.Clear();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            cboHora.Items.Clear();
            CargarCitasTabla();
        }

        private void btnVerificarHorarios_Click(object sender, EventArgs e)
        {
            CargarBloquesHorarioDisponibles();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboPaciente.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un paciente de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPaciente.Focus();
                return;
            }

            if (cboDoctor.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un doctor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDoctor.Focus();
                return;
            }

            if (cboHora.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un bloque de horario libre para la cita.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboHora.Focus();
                return;
            }

            if (cboUsuario.SelectedValue == null)
            {
                MessageBox.Show("Seleccione el usuario que registra la cita.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboUsuario.Focus();
                return;
            }

            int idPaciente = Convert.ToInt32(cboPaciente.SelectedValue);
            int idDoctor = Convert.ToInt32(cboDoctor.SelectedValue);
            int idUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
            DateTime fechaCita = dtpFecha.Value.Date;
            TimeSpan horaInicio = TimeSpan.Parse(cboHora.SelectedItem.ToString());
            TimeSpan horaFin = horaInicio.Add(TimeSpan.FromMinutes(30));
            string motivo = txtMotivoConsulta.Text.Trim();

            using (SqlConnection conn = conexion.Conectar())
            {
                conn.Open();

                string queryDoctorLibre = @"SELECT COUNT(*) FROM Citas 
                                           WHERE id_doctor = @id_doctor 
                                             AND fecha = @fecha 
                                             AND hora_inicio = @hora_inicio 
                                             AND estado = 'Programada'";

                using (SqlCommand cmdCheckDoc = new SqlCommand(queryDoctorLibre, conn))
                {
                    cmdCheckDoc.Parameters.AddWithValue("@id_doctor", idDoctor);
                    cmdCheckDoc.Parameters.AddWithValue("@fecha", fechaCita);
                    cmdCheckDoc.Parameters.AddWithValue("@hora_inicio", horaInicio);

                    int countDoc = Convert.ToInt32(cmdCheckDoc.ExecuteScalar());
                    if (countDoc > 0)
                    {
                        MessageBox.Show("El doctor ya cuenta con una cita 'Programada' registrada en ese mismo horario.", "Conflicto de Horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string queryPacienteLibre = @"SELECT COUNT(*) FROM Citas 
                                             WHERE id_paciente = @id_paciente 
                                               AND fecha = @fecha 
                                               AND hora_inicio = @hora_inicio 
                                               AND estado = 'Programada'";

                using (SqlCommand cmdCheckPac = new SqlCommand(queryPacienteLibre, conn))
                {
                    cmdCheckPac.Parameters.AddWithValue("@id_paciente", idPaciente);
                    cmdCheckPac.Parameters.AddWithValue("@fecha", fechaCita);
                    cmdCheckPac.Parameters.AddWithValue("@hora_inicio", horaInicio);

                    int countPac = Convert.ToInt32(cmdCheckPac.ExecuteScalar());
                    if (countPac > 0)
                    {
                        MessageBox.Show("El paciente seleccionado ya posee otra cita programada en la misma fecha y bloque de hora.", "Sobreposición Horaria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string queryInsertCita = @"INSERT INTO Citas 
                                              (id_paciente, id_doctor, fecha, hora_inicio, hora_fin, motivo_consulta, estado, id_usuario, fecha_registro) 
                                              VALUES 
                                              (@id_paciente, @id_doctor, @fecha, @hora_inicio, @hora_fin, @motivo, 'Programada', @id_usuario, GETDATE());
                                              SELECT SCOPE_IDENTITY();";

                    int newCitaId;
                    using (SqlCommand cmdInsertCita = new SqlCommand(queryInsertCita, conn, transaction))
                    {
                        cmdInsertCita.Parameters.AddWithValue("@id_paciente", idPaciente);
                        cmdInsertCita.Parameters.AddWithValue("@id_doctor", idDoctor);
                        cmdInsertCita.Parameters.AddWithValue("@fecha", fechaCita);
                        cmdInsertCita.Parameters.AddWithValue("@hora_inicio", horaInicio);
                        cmdInsertCita.Parameters.AddWithValue("@hora_fin", horaFin);
                        cmdInsertCita.Parameters.AddWithValue("@motivo", string.IsNullOrWhiteSpace(motivo) ? (object)DBNull.Value : motivo);
                        cmdInsertCita.Parameters.AddWithValue("@id_usuario", idUsuario);

                        newCitaId = Convert.ToInt32(cmdInsertCita.ExecuteScalar());
                    }

                    string queryInsertHistorial = @"INSERT INTO Historial_Citas 
                                                    (id_cita, accion, fecha_nueva, hora_nueva, id_usuario, fecha_movimiento) 
                                                    VALUES 
                                                    (@id_cita, 'Creada', @fecha_nueva, @hora_nueva, @id_usuario, GETDATE())";

                    using (SqlCommand cmdHist = new SqlCommand(queryInsertHistorial, conn, transaction))
                    {
                        cmdHist.Parameters.AddWithValue("@id_cita", newCitaId);
                        cmdHist.Parameters.AddWithValue("@fecha_nueva", fechaCita);
                        cmdHist.Parameters.AddWithValue("@hora_nueva", horaInicio);
                        cmdHist.Parameters.AddWithValue("@id_usuario", idUsuario);

                        cmdHist.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("La cita médica ha sido agendada con éxito y registrada en el historial transaccional.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarCampos();
                    CargarCitasTabla();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al agendar la cita: " + ex.Message, "Error Transaccional SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}