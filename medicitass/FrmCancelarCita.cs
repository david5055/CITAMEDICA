using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmCancelarCita : Form
    {
        private int idUsuarioActual = 1;

        public FrmCancelarCita()
        {
            InitializeComponent();
        }

        public FrmCancelarCita(int idUsuario) : this()
        {
            this.idUsuarioActual = idUsuario;
        }

        private void FrmCancelarCita_Load(object sender, EventArgs e)
        {
            CargarCitasProgramadas();
        }

        private void CargarCitasProgramadas()
        {
            string query = @"
                SELECT 
                    c.id_cita AS [ID],
                    (p.nombres + ' ' + p.apellidos) AS [Paciente],
                    (d.nombres + ' ' + d.apellidos) AS [Doctor],
                    e.nombre AS [Especialidad],
                    c.fecha AS [Fecha],
                    c.hora_inicio AS [Hora Inicio],
                    c.motivo_consulta AS [Motivo Consulta],
                    c.estado AS [Estado]
                FROM Citas c
                INNER JOIN Pacientes p ON c.id_paciente = p.id_paciente
                INNER JOIN Doctores d ON c.id_doctor = d.id_doctor
                INNER JOIN Especialidades e ON d.id_especialidad = e.id_especialidad
                WHERE c.estado = 'Programada'
                ORDER BY c.fecha ASC, c.hora_inicio ASC;";

            try
            {
                Conexion conexionDB = new Conexion();
                using (SqlConnection con = conexionDB.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvCitasProgramadas.DataSource = dt;
                    }
                }

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las citas programadas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCitasProgramadas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCitasProgramadas.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvCitasProgramadas.SelectedRows[0];

                txtIdCita.Text = fila.Cells["ID"].Value.ToString();
                txtPaciente.Text = fila.Cells["Paciente"].Value.ToString();
                txtDoctor.Text = fila.Cells["Doctor"].Value.ToString();

                DateTime fecha = Convert.ToDateTime(fila.Cells["Fecha"].Value);
                txtFecha.Text = fecha.ToString("yyyy-MM-dd");

                TimeSpan horaInicio = (TimeSpan)fila.Cells["Hora Inicio"].Value;
                txtHora.Text = horaInicio.ToString(@"hh\:mm");
            }
        }

        private void btnCancelarCita_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdCita.Text))
            {
                MessageBox.Show("Por favor seleccione una cita programada de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotivoCancelacion.Text))
            {
                MessageBox.Show("El motivo de cancelación es obligatorio. Por favor escríbalo antes de continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivoCancelacion.Focus();
                return;
            }

            int idCita = Convert.ToInt32(txtIdCita.Text);
            string motivo = txtMotivoCancelacion.Text.Trim();
            DateTime fechaActualCita = DateTime.Parse(txtFecha.Text);
            TimeSpan horaActualCita = TimeSpan.Parse(txtHora.Text);

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea cancelar la cita #{idCita} del paciente '{txtPaciente.Text}'?\n\nEsta acción no se puede deshacer.",
                "Confirmar Cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            try
            {
                Conexion conexionDB = new Conexion();
                using (SqlConnection con = conexionDB.Conectar())
                {
                    con.Open();

                    string queryVerificar = "SELECT estado FROM Citas WHERE id_cita = @IdCita;";
                    using (SqlCommand cmdVer = new SqlCommand(queryVerificar, con))
                    {
                        cmdVer.Parameters.AddWithValue("@IdCita", idCita);
                        string estadoActual = cmdVer.ExecuteScalar()?.ToString();

                        if (estadoActual == "Atendida" || estadoActual == "Cancelada")
                        {
                            MessageBox.Show($"No se puede cancelar esta cita porque su estado actual es '{estadoActual}'.", "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            CargarCitasProgramadas();
                            return;
                        }
                    }

                    SqlTransaction transaction = con.BeginTransaction();

                    try
                    {
                        string queryUpdate = @"
                            UPDATE Citas 
                            SET estado = 'Cancelada', 
                                motivo_cancelacion = @Motivo,
                                id_usuario = @IdUsuario
                            WHERE id_cita = @IdCita;";

                        using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con, transaction))
                        {
                            cmdUpdate.Parameters.AddWithValue("@Motivo", motivo);
                            cmdUpdate.Parameters.AddWithValue("@IdUsuario", idUsuarioActual);
                            cmdUpdate.Parameters.AddWithValue("@IdCita", idCita);

                            cmdUpdate.ExecuteNonQuery();
                        }

                        string queryHistorial = @"
                            INSERT INTO Historial_Citas 
                            (id_cita, accion, fecha_anterior, hora_anterior, fecha_nueva, hora_nueva, id_usuario, fecha_movimiento)
                            VALUES 
                            (@IdCita, 'Cancelada', @FechaAnterior, @HoraAnterior, NULL, NULL, @IdUsuario, SYSDATETIME());";

                        using (SqlCommand cmdHist = new SqlCommand(queryHistorial, con, transaction))
                        {
                            cmdHist.Parameters.AddWithValue("@IdCita", idCita);
                            cmdHist.Parameters.AddWithValue("@FechaAnterior", fechaActualCita);
                            cmdHist.Parameters.AddWithValue("@HoraAnterior", horaActualCita);
                            cmdHist.Parameters.AddWithValue("@IdUsuario", idUsuarioActual);

                            cmdHist.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("La cita ha sido cancelada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarCitasProgramadas();
                    }
                    catch (SqlException exSql)
                    {
                        transaction.Rollback();

                        if (exSql.Number == 50001)
                        {
                            MessageBox.Show(exSql.Message, "Validación de Trigger", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Error SQL al procesar la cancelación: " + exSql.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar procesar la solicitud: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtIdCita.Clear();
            txtPaciente.Clear();
            txtDoctor.Clear();
            txtFecha.Clear();
            txtHora.Clear();
            txtMotivoCancelacion.Clear();

            if (dgvCitasProgramadas != null && dgvCitasProgramadas.Rows.Count > 0)
            {
                dgvCitasProgramadas.ClearSelection();
            }
        }
    }
}