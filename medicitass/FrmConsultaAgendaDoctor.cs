using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmConsultaAgendaDoctor : Form
    {
        private Conexion conexion = new Conexion();

        public FrmConsultaAgendaDoctor()
        {
            InitializeComponent();
        }

        private void FrmConsultaAgendaDoctor_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Today;
            cboEstado.SelectedIndex = 0; // "Todos"
            CargarComboDoctores();
        }

        #region Carga de Combos y Datos de Doctor

        private void CargarComboDoctores()
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = @"SELECT id_doctor, 
                                            ('Dr. ' + nombres + ' ' + apellidos) AS nombre_completo 
                                     FROM Doctores 
                                     WHERE estado = 'Activo' 
                                     ORDER BY nombres ASC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboDoctor.DataSource = dt;
                    cboDoctor.DisplayMember = "nombre_completo";
                    cboDoctor.ValueMember = "id_doctor";

                    if (dt.Rows.Count > 0)
                    {
                        cboDoctor.SelectedIndex = 0;
                        ActualizarFichaDoctor();
                        CargarAgendaDoctor();
                    }
                    else
                    {
                        lblEspecialidadInfo.Text = "Especialidad: Sin Médicos Activos";
                        lblJuntaInfo.Text = "N° Junta Vigilancia: -";
                        lblContactoInfo.Text = "Contacto: -";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de doctores: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarFichaDoctor()
        {
            if (cboDoctor.SelectedValue == null || cboDoctor.SelectedIndex == -1) return;

            int idDoctor;
            if (!int.TryParse(cboDoctor.SelectedValue.ToString(), out idDoctor)) return;

            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"SELECT e.nombre AS Especialidad, 
                                            d.numero_junta_vigilancia, 
                                            ISNULL(d.telefono, 'S/T') AS telefono, 
                                            ISNULL(d.correo, 'S/C') AS correo 
                                     FROM Doctores d
                                     INNER JOIN Especialidades e ON d.id_especialidad = e.id_especialidad
                                     WHERE d.id_doctor = @id_doctor";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_doctor", idDoctor);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblEspecialidadInfo.Text = $"Especialidad: {reader["Especialidad"]}";
                                lblJuntaInfo.Text = $"N° Junta Vigilancia: {reader["numero_junta_vigilancia"]}";
                                lblContactoInfo.Text = $"Contacto: Tel. {reader["telefono"]} | {reader["correo"]}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la ficha del doctor: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Carga de Agenda de Citas del Día

        private void CargarAgendaDoctor()
        {
            if (cboDoctor.SelectedValue == null || cboDoctor.SelectedIndex == -1) return;

            int idDoctor;
            if (!int.TryParse(cboDoctor.SelectedValue.ToString(), out idDoctor)) return;

            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = @"SELECT c.id_cita AS [Código Cita],
                                            CONVERT(VARCHAR(5), c.hora_inicio, 108) + ' - ' + CONVERT(VARCHAR(5), c.hora_fin, 108) AS [Bloque Horario],
                                            (p.nombres + ' ' + p.apellidos) AS [Paciente],
                                            p.dui AS [DUI Paciente],
                                            ISNULL(p.telefono, 'Sin Teléfono') AS [Teléfono Paciente],
                                            c.motivo_consulta AS [Motivo Consulta],
                                            c.estado AS [Estado Cita],
                                            ISNULL(c.motivo_cancelacion, '-') AS [Motivo Cancelación],
                                            u.nombre_usuario AS [Agendado Por]
                                     FROM Citas c
                                     INNER JOIN Pacientes p ON c.id_paciente = p.id_paciente
                                     INNER JOIN Usuarios u ON c.id_usuario = u.id_usuario
                                     WHERE c.id_doctor = @id_doctor 
                                       AND c.fecha = @fecha";

                    string estadoSeleccionado = cboEstado.SelectedItem != null ? cboEstado.SelectedItem.ToString() : "Todos";
                    if (estadoSeleccionado != "Todos")
                    {
                        query += " AND c.estado = @estado";
                    }

                    query += " ORDER BY c.hora_inicio ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_doctor", idDoctor);
                        cmd.Parameters.AddWithValue("@fecha", dtpFecha.Value.Date);

                        if (estadoSeleccionado != "Todos")
                        {
                            cmd.Parameters.AddWithValue("@estado", estadoSeleccionado);
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvAgendaDoctor.DataSource = dt;

                        CalcularMetricasResumen(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la agenda del doctor: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularMetricasResumen(DataTable dt)
        {
            int total = dt.Rows.Count;
            int programadas = 0;
            int atendidas = 0;
            int canceladas = 0;

            foreach (DataRow row in dt.Rows)
            {
                string estado = row["Estado Cita"].ToString();
                if (estado == "Programada") programadas++;
                else if (estado == "Atendida") atendidas++;
                else if (estado == "Cancelada") canceladas++;
            }

            lblTotalCitas.Text = $"Total Citas del Día: {total}";
            lblTotalProgramadas.Text = $"Citas Programadas: {programadas}";
            lblTotalAtendidas.Text = $"Citas Atendidas: {atendidas}";
            lblTotalCanceladas.Text = $"Citas Canceladas: {canceladas}";
        }

        #endregion

        #region Eventos de Controles y Selección

        private void cboDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarFichaDoctor();
            CargarAgendaDoctor();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            CargarAgendaDoctor();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarAgendaDoctor();
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Today;
            CargarAgendaDoctor();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Today;
            cboEstado.SelectedIndex = 0;
            CargarComboDoctores();
        }

        #endregion
    }
}
