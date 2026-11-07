using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmConsultaHistorialPaciente : Form
    {
        private Conexion conexion = new Conexion();

        public FrmConsultaHistorialPaciente()
        {
            InitializeComponent();
        }

        private void FrmConsultaHistorialPaciente_Load(object sender, EventArgs e)
        {
            cboEstado.SelectedIndex = 0;      // "Todos"
            cboTipoTiempo.SelectedIndex = 0;  // "Todas las Citas"
            CargarComboPacientes();
        }

        #region Carga de Combos y Datos del Paciente

        private void CargarComboPacientes()
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = @"SELECT id_paciente, 
                                            (nombres + ' ' + apellidos + ' - DUI: ' + dui) AS nombre_completo 
                                     FROM Pacientes 
                                     ORDER BY nombres ASC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboPaciente.DataSource = dt;
                    cboPaciente.DisplayMember = "nombre_completo";
                    cboPaciente.ValueMember = "id_paciente";

                    if (dt.Rows.Count > 0)
                    {
                        cboPaciente.SelectedIndex = 0;
                        ActualizarFichaPaciente();
                        CargarHistorialPaciente();
                    }
                    else
                    {
                        lblDuiInfo.Text = "DUI / Documento: Sin Pacientes";
                        lblEdadInfo.Text = "F. Nacimiento: -";
                        lblContactoInfo.Text = "Contacto: -";
                        lblDireccionInfo.Text = "Dirección: -";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de pacientes: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarFichaPaciente()
        {
            if (cboPaciente.SelectedValue == null || cboPaciente.SelectedIndex == -1) return;

            int idPaciente;
            if (!int.TryParse(cboPaciente.SelectedValue.ToString(), out idPaciente)) return;

            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"SELECT dui, fecha_nacimiento, sexo, 
                                            ISNULL(telefono, 'Sin Teléfono') AS telefono, 
                                            ISNULL(correo, 'Sin Correo') AS correo, 
                                            ISNULL(direccion, 'Sin Dirección') AS direccion 
                                     FROM Pacientes 
                                     WHERE id_paciente = @id_paciente";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_paciente", idPaciente);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DateTime fNac = Convert.ToDateTime(reader["fecha_nacimiento"]);
                                string dui = reader["dui"].ToString();
                                string sexo = reader["sexo"].ToString();
                                string tel = reader["telefono"].ToString();
                                string correo = reader["correo"].ToString();
                                string dir = reader["direccion"].ToString();

                                lblDuiInfo.Text = $"DUI: {dui} ({sexo})";
                                lblEdadInfo.Text = $"F. Nac: {fNac:dd/MM/yyyy}";
                                lblContactoInfo.Text = $"Tel. {tel} | {correo}";
                                lblDireccionInfo.Text = $"Dirección: {dir}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la ficha del paciente: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Carga del Historial Clínico de Citas

        private void CargarHistorialPaciente()
        {
            if (cboPaciente.SelectedValue == null || cboPaciente.SelectedIndex == -1) return;

            int idPaciente;
            if (!int.TryParse(cboPaciente.SelectedValue.ToString(), out idPaciente)) return;

            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = @"SELECT c.id_cita AS [Código Cita],
                                            c.fecha AS [Fecha],
                                            CONVERT(VARCHAR(5), c.hora_inicio, 108) + ' - ' + CONVERT(VARCHAR(5), c.hora_fin, 108) AS [Horario],
                                            CASE 
                                                WHEN c.fecha < CAST(GETDATE() AS DATE) THEN 'PASADA'
                                                WHEN c.fecha = CAST(GETDATE() AS DATE) AND c.hora_inicio < CAST(GETDATE() AS TIME) THEN 'PASADA'
                                                ELSE 'FUTURA'
                                            END AS [Tiempo],
                                            ('Dr. ' + d.nombres + ' ' + d.apellidos) AS [Doctor],
                                            e.nombre AS [Especialidad],
                                            c.motivo_consulta AS [Motivo Consulta],
                                            c.estado AS [Estado],
                                            ISNULL(c.motivo_cancelacion, '-') AS [Motivo Cancelación],
                                            u.nombre_usuario AS [Agendado Por]
                                     FROM Citas c
                                     INNER JOIN Doctores d ON c.id_doctor = d.id_doctor
                                     INNER JOIN Especialidades e ON d.id_especialidad = e.id_especialidad
                                     INNER JOIN Usuarios u ON c.id_usuario = u.id_usuario
                                     WHERE c.id_paciente = @id_paciente";

                    // Filtro dinámico por Estado
                    string estadoSeleccionado = cboEstado.SelectedItem != null ? cboEstado.SelectedItem.ToString() : "Todos";
                    if (estadoSeleccionado != "Todos")
                    {
                        query += " AND c.estado = @estado";
                    }

                    // Filtro dinámico por Horizonte Temporal (Pasadas vs Futuras)
                    string tipoTiempo = cboTipoTiempo.SelectedItem != null ? cboTipoTiempo.SelectedItem.ToString() : "Todas las Citas";
                    if (tipoTiempo == "Citas Pasadas")
                    {
                        query += @" AND (c.fecha < CAST(GETDATE() AS DATE) 
                                     OR (c.fecha = CAST(GETDATE() AS DATE) AND c.hora_inicio < CAST(GETDATE() AS TIME)))";
                    }
                    else if (tipoTiempo == "Citas Futuras")
                    {
                        query += @" AND (c.fecha > CAST(GETDATE() AS DATE) 
                                     OR (c.fecha = CAST(GETDATE() AS DATE) AND c.hora_inicio >= CAST(GETDATE() AS TIME)))";
                    }

                    query += " ORDER BY c.fecha DESC, c.hora_inicio DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_paciente", idPaciente);

                        if (estadoSeleccionado != "Todos")
                        {
                            cmd.Parameters.AddWithValue("@estado", estadoSeleccionado);
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvHistorial.DataSource = dt;

                        CalcularMetricasResumen(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial del paciente: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularMetricasResumen(DataTable dt)
        {
            int total = dt.Rows.Count;
            int pasadas = 0;
            int futuras = 0;
            int programadas = 0;
            int atendidas = 0;
            int canceladas = 0;

            foreach (DataRow row in dt.Rows)
            {
                string tiempo = row["Tiempo"].ToString();
                string estado = row["Estado"].ToString();

                if (tiempo == "PASADA") pasadas++;
                else if (tiempo == "FUTURA") futuras++;

                if (estado == "Programada") programadas++;
                else if (estado == "Atendida") atendidas++;
                else if (estado == "Cancelada") canceladas++;
            }

            lblTotalCitas.Text = $"Total de Historial: {total}";
            lblTotalPasadas.Text = $"Citas Pasadas (<): {pasadas}";
            lblTotalFuturas.Text = $"Citas Futuras (≥): {futuras}";
            lblTotalProgramadas.Text = $"Programadas: {programadas}";
            lblTotalAtendidas.Text = $"Atendidas: {atendidas}";
            lblTotalCanceladas.Text = $"Canceladas: {canceladas}";
        }

        #endregion

        #region Eventos de Filtro y Selección

        private void cboPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarFichaPaciente();
            CargarHistorialPaciente();
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHistorialPaciente();
        }

        private void cboTipoTiempo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHistorialPaciente();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarHistorialPaciente();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            cboEstado.SelectedIndex = 0;
            cboTipoTiempo.SelectedIndex = 0;
            CargarComboPacientes();
        }

        #endregion
    }
}
