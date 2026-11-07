using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmConsultaCitasCanceladas : Form
    {
        public FrmConsultaCitasCanceladas()
        {
            InitializeComponent();
        }

        private void FrmConsultaCitasCanceladas_Load(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            dtpFechaInicio.Value = new DateTime(hoy.Year, hoy.Month, 1);
            dtpFechaFin.Value = hoy;

            CargarCitasCanceladas();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarCitasCanceladas();
        }

        private void CargarCitasCanceladas()
        {
            string filtroTexto = txtFiltroText.Text.Trim();
            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date;

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conexion = new Conexion().Conectar())
                {
                    string query = @"
                        SELECT 
                            c.id_cita AS [ID Cita],
                            (p.nombres + ' ' + p.apellidos) AS Paciente,
                            p.dui AS [DUI Paciente],
                            (d.nombres + ' ' + d.apellidos) AS Doctor,
                            c.fecha AS [Fecha Cita],
                            c.hora_inicio AS [Hora Inicio],
                            c.motivo_cancelacion AS [Motivo de Cancelación],
                            u.nombre_usuario AS [Registrado Por],
                            c.fecha_registro AS [Fecha Registro]
                        FROM Citas c
                        INNER JOIN Pacientes p ON c.id_paciente = p.id_paciente
                        INNER JOIN Doctores d ON c.id_doctor = d.id_doctor
                        INNER JOIN Usuarios u ON c.id_usuario = u.id_usuario
                        WHERE c.estado = 'Cancelada'
                          AND c.fecha BETWEEN @fechaInicio AND @fechaFin
                          AND (
                              p.nombres LIKE @filtro OR
                              p.apellidos LIKE @filtro OR
                              d.nombres LIKE @filtro OR
                              d.apellidos LIKE @filtro OR
                              c.motivo_cancelacion LIKE @filtro
                          )
                        ORDER BY c.fecha DESC, c.hora_inicio DESC";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtroTexto + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvCitasCanceladas.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte de citas canceladas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}