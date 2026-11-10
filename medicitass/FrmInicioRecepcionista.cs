
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmInicioRecepcionista : Form
    {
        private readonly Conexion conexion = new Conexion();
        private readonly string usuarioActual;

        // Constructor para el diseñador
        public FrmInicioRecepcionista()
            : this("")
        {
        }

        // Constructor utilizado desde el Menú Principal
        public FrmInicioRecepcionista(string usuario)
        {
            InitializeComponent();

            usuarioActual = usuario ?? "";

            lblBienvenida.Text =
                string.IsNullOrWhiteSpace(usuarioActual)
                ? "Bienvenido a Recepción"
                : "Bienvenido, " + usuarioActual;

            lblFecha.Text =
                "Fecha: " +
                DateTime.Today.ToString("dd/MM/yyyy");
        }

        // ==========================================
        // CARGAR DATOS AL ABRIR LA VENTANA
        // ==========================================
        private void FrmInicioRecepcionista_Load(
            object sender, EventArgs e)
        {
            CargarDashboard();
        }

        // ==========================================
        // ACTUALIZAR TODA LA INFORMACIÓN
        // ==========================================
        private void CargarDashboard()
        {
            lblCitasHoy.Text = "—";
            lblProgramadas.Text = "—";
            lblPacientes.Text = "—";

            dgvAgenda.Rows.Clear();

            lblEstado.Text = "Cargando información...";

            try
            {
                using (SqlConnection cn = conexion.Conectar())
                {
                    cn.Open();

                    CargarEstadisticas(cn);
                    CargarAgenda(cn);
                }

                lblEstado.Text =
                    "Información actualizada: " +
                    DateTime.Now.ToString(
                        "dd/MM/yyyy hh:mm tt");
            }
            catch (Exception ex)
            {
                lblEstado.Text =
                    "Error al cargar información.";

                MessageBox.Show(
                    "No se pudieron cargar los datos " +
                    "de Recepción.\n\n" +
                    ex.Message,
                    "MediCitas - Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // MOSTRAR LOS TRES CONTADORES
        // ==========================================
        private void CargarEstadisticas(SqlConnection cn)
        {
            string sql = @"
                SELECT
                    (
                        SELECT COUNT(*)
                        FROM dbo.Citas
                        WHERE fecha = @Fecha
                    ) AS CitasHoy,

                    (
                        SELECT COUNT(*)
                        FROM dbo.Citas
                        WHERE fecha = @Fecha
                        AND estado = 'Programada'
                    ) AS Programadas,

                    (
                        SELECT COUNT(*)
                        FROM dbo.Pacientes
                        WHERE estado = 'Activo'
                    ) AS PacientesActivos;
            ";

            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add(
                    "@Fecha", SqlDbType.Date
                ).Value = DateTime.Today;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        lblCitasHoy.Text =
                            dr["CitasHoy"].ToString();

                        lblProgramadas.Text =
                            dr["Programadas"].ToString();

                        lblPacientes.Text =
                            dr["PacientesActivos"].ToString();
                    }
                }
            }
        }

        // ==========================================
        // MOSTRAR AGENDA GENERAL DEL DÍA
        // ==========================================
        private void CargarAgenda(SqlConnection cn)
        {
            string sql = @"
                SELECT
                    c.hora_inicio,
                    p.nombres + ' ' + p.apellidos
                        AS Paciente,
                    d.nombres + ' ' + d.apellidos
                        AS Doctor,
                    e.nombre AS Especialidad,
                    ISNULL(c.estado, 'Sin estado')
                        AS Estado
                FROM dbo.Citas c
                INNER JOIN dbo.Pacientes p
                    ON c.id_paciente = p.id_paciente
                INNER JOIN dbo.Doctores d
                    ON c.id_doctor = d.id_doctor
                INNER JOIN dbo.Especialidades e
                    ON d.id_especialidad = e.id_especialidad
                WHERE c.fecha = @Fecha
                ORDER BY c.hora_inicio ASC;
            ";

            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add(
                    "@Fecha", SqlDbType.Date
                ).Value = DateTime.Today;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string hora =
                            Convert.ToDateTime(
                                "1900-01-01 " +
                                dr["hora_inicio"].ToString()
                            ).ToString("hh:mm tt");

                        string paciente =
                            dr["Paciente"].ToString();

                        string doctor =
                            dr["Doctor"].ToString();

                        string especialidad =
                            dr["Especialidad"].ToString();

                        string estado =
                            dr["Estado"].ToString();

                        dgvAgenda.Rows.Add(
                            hora,
                            paciente,
                            doctor,
                            especialidad,
                            estado
                        );
                    }
                }
            }

            dgvAgenda.ClearSelection();
        }
    }
}
