using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmConsultaAgendaFecha : Form
    {
        private Conexion conexion = new Conexion();

        public FrmConsultaAgendaFecha()
        {
            InitializeComponent();
        }

        private void FrmConsultaAgendaFecha_Load(object sender, EventArgs e)
        {
            dtpFechaDesde.Value = DateTime.Today;
            dtpFechaHasta.Value = DateTime.Today.AddDays(7); // Vista predeterminada a 7 días
            cboEstado.SelectedIndex = 0; // "Todos"
            txtBuscar.Clear();

            CargarAgenda();
        }

        #region Método Principal de Carga de Agenda

        private void CargarAgenda()
        {
            // Validar que Fecha Desde <= Fecha Hasta
            if (dtpFechaDesde.Value.Date > dtpFechaHasta.Value.Date)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", "Rango Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFechaDesde.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = @"SELECT c.id_cita AS [Código Cita],
                                            c.fecha AS [Fecha],
                                            CONVERT(VARCHAR(5), c.hora_inicio, 108) + ' - ' + CONVERT(VARCHAR(5), c.hora_fin, 108) AS [Horario],
                                            (p.nombres + ' ' + p.apellidos) AS [Paciente],
                                            p.dui AS [DUI Paciente],
                                            ('Dr. ' + d.nombres + ' ' + d.apellidos) AS [Doctor],
                                            e.nombre AS [Especialidad],
                                            c.motivo_consulta AS [Motivo Consulta],
                                            c.estado AS [Estado],
                                            ISNULL(c.motivo_cancelacion, '-') AS [Motivo Cancelación],
                                            u.nombre_usuario AS [Usuario Registró]
                                     FROM Citas c
                                     INNER JOIN Pacientes p ON c.id_paciente = p.id_paciente
                                     INNER JOIN Doctores d ON c.id_doctor = d.id_doctor
                                     INNER JOIN Especialidades e ON d.id_especialidad = e.id_especialidad
                                     INNER JOIN Usuarios u ON c.id_usuario = u.id_usuario
                                     WHERE c.fecha BETWEEN @fechaDesde AND @fechaHasta";

                    // Filtro dinámico por estado de la cita
                    string estadoSeleccionado = cboEstado.SelectedItem != null ? cboEstado.SelectedItem.ToString() : "Todos";
                    if (estadoSeleccionado != "Todos")
                    {
                        query += " AND c.estado = @estado";
                    }

                    // Filtro dinámico por texto de búsqueda (Paciente, Doctor o DUI)
                    string textoBusqueda = txtBuscar.Text.Trim();
                    if (!string.IsNullOrWhiteSpace(textoBusqueda))
                    {
                        query += @" AND (p.nombres LIKE @buscar 
                                     OR p.apellidos LIKE @buscar 
                                     OR p.dui LIKE @buscar 
                                     OR d.nombres LIKE @buscar 
                                     OR d.apellidos LIKE @buscar)";
                    }

                    query += " ORDER BY c.fecha ASC, c.hora_inicio ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fechaDesde", dtpFechaDesde.Value.Date);
                        cmd.Parameters.AddWithValue("@fechaHasta", dtpFechaHasta.Value.Date);

                        if (estadoSeleccionado != "Todos")
                        {
                            cmd.Parameters.AddWithValue("@estado", estadoSeleccionado);
                        }

                        if (!string.IsNullOrWhiteSpace(textoBusqueda))
                        {
                            cmd.Parameters.AddWithValue("@buscar", "%" + textoBusqueda + "%");
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvCitas.DataSource = dt;

                        CalcularMetricasResumen(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la agenda de citas: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string estado = row["Estado"].ToString();
                if (estado == "Programada") programadas++;
                else if (estado == "Atendida") atendidas++;
                else if (estado == "Cancelada") canceladas++;
            }

            lblTotalCitas.Text = $"Total de Citas: {total}";
            lblTotalProgramadas.Text = $"Citas Programadas: {programadas}";
            lblTotalAtendidas.Text = $"Citas Atendidas: {atendidas}";
            lblTotalCanceladas.Text = $"Citas Canceladas: {canceladas}";
        }

        #endregion

        #region Eventos de Controles

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarAgenda();
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            dtpFechaDesde.Value = DateTime.Today;
            dtpFechaHasta.Value = DateTime.Today;
            CargarAgenda();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            dtpFechaDesde.Value = DateTime.Today;
            dtpFechaHasta.Value = DateTime.Today.AddDays(7);
            cboEstado.SelectedIndex = 0;
            txtBuscar.Clear();
            CargarAgenda();
        }

        #endregion
    }
}
