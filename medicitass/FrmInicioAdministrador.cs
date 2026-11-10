
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmInicioAdministrador : Form
    {
        private readonly Conexion conexion = new Conexion();

        public FrmInicioAdministrador()
        {
            InitializeComponent();
        }

        private void FrmInicioAdministrador_Load(
            object sender, EventArgs e)
        {
            CargarDashboard();
        }

        // =========================================
        // ACTUALIZAR TODO EL DASHBOARD
        // =========================================
        private void CargarDashboard()
        {
            btnActualizar.Enabled = false;

            try
            {
                using (SqlConnection cn = conexion.Conectar())
                {
                    cn.Open();

                    CargarEstadisticas(cn);
                    CargarProximasCitas(cn);

                    lblActualizacion.Text =
                        "Última actualización: " +
                        DateTime.Now.ToString(
                            "dd/MM/yyyy HH:mm:ss");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar el resumen de la clínica.\n" +
                    ex.Message,
                    "Error MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnActualizar.Enabled = true;
            }
        }

        // =========================================
        // CONSULTAR LAS ESTADÍSTICAS
        // =========================================
        private void CargarEstadisticas(SqlConnection cn)
        {
            string sql = @"
                SELECT
                    (
                        SELECT COUNT(*)
                        FROM Doctores
                        WHERE estado = 'Activo'
                    ) AS DoctoresActivos,

                    (
                        SELECT COUNT(*)
                        FROM Pacientes
                        WHERE estado = 'Activo'
                    ) AS PacientesActivos,

                    (
                        SELECT COUNT(*)
                        FROM Citas
                        WHERE fecha = CAST(GETDATE() AS DATE)
                    ) AS CitasHoy,

                    (
                        SELECT COUNT(*)
                        FROM Citas
                        WHERE estado = 'Programada'
                        AND
                        (
                            fecha > CAST(GETDATE() AS DATE)
                            OR
                            (
                                fecha = CAST(GETDATE() AS DATE)
                                AND hora_inicio >=
                                    CAST(GETDATE() AS TIME)
                            )
                        )
                    ) AS CitasPendientes,

                    (
                        SELECT COUNT(*)
                        FROM Citas
                        WHERE estado = 'Atendida'
                    ) AS CitasAtendidas,

                    (
                        SELECT COUNT(*)
                        FROM Citas
                        WHERE estado = 'Cancelada'
                    ) AS CitasCanceladas";

            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    lblNumeroDoctores.Text =
                        dr["DoctoresActivos"].ToString();

                    lblNumeroPacientes.Text =
                        dr["PacientesActivos"].ToString();

                    lblNumeroCitasHoy.Text =
                        dr["CitasHoy"].ToString();

                    lblNumeroPendientes.Text =
                        dr["CitasPendientes"].ToString();

                    lblNumeroAtendidas.Text =
                        dr["CitasAtendidas"].ToString();

                    lblNumeroCanceladas.Text =
                        dr["CitasCanceladas"].ToString();
                }
            }
        }

        // =========================================
        // CONSULTAR PRÓXIMAS CITAS
        // =========================================
        private void CargarProximasCitas(SqlConnection cn)
        {
            string sql = @"
                SELECT TOP (15)
                    c.id_cita AS [N° Cita],
                    CONVERT(VARCHAR(10), c.fecha, 103)
                        AS [Fecha],
                    CONVERT(VARCHAR(5), c.hora_inicio, 108)
                        AS [Hora],
                    p.nombres + ' ' + p.apellidos
                        AS [Paciente],
                    d.nombres + ' ' + d.apellidos
                        AS [Doctor],
                    e.nombre AS [Especialidad],
                    c.estado AS [Estado]
                FROM Citas c
                INNER JOIN Pacientes p
                    ON c.id_paciente = p.id_paciente
                INNER JOIN Doctores d
                    ON c.id_doctor = d.id_doctor
                INNER JOIN Especialidades e
                    ON d.id_especialidad = e.id_especialidad
                WHERE c.estado = 'Programada'
                  AND
                  (
                      c.fecha > CAST(GETDATE() AS DATE)
                      OR
                      (
                          c.fecha = CAST(GETDATE() AS DATE)
                          AND c.hora_inicio >=
                              CAST(GETDATE() AS TIME)
                      )
                  )
                ORDER BY
                    c.fecha ASC,
                    c.hora_inicio ASC";

            using (SqlDataAdapter da =
                new SqlDataAdapter(sql, cn))
            {
                DataTable tabla = new DataTable();
                da.Fill(tabla);

                dgvProximasCitas.DataSource = tabla;

                lblTotalProximas.Text =
                    "Próximas citas mostradas: " +
                    tabla.Rows.Count;

                if (dgvProximasCitas.Columns.Contains(
                    "N° Cita"))
                {
                    dgvProximasCitas.Columns[
                        "N° Cita"].FillWeight = 55;
                }

                if (dgvProximasCitas.Columns.Contains(
                    "Paciente"))
                {
                    dgvProximasCitas.Columns[
                        "Paciente"].FillWeight = 145;
                }

                if (dgvProximasCitas.Columns.Contains(
                    "Doctor"))
                {
                    dgvProximasCitas.Columns[
                        "Doctor"].FillWeight = 145;
                }

                dgvProximasCitas.ClearSelection();
            }
        }

        // =========================================
        // BOTÓN ACTUALIZAR
        // =========================================
        private void btnActualizar_Click(
            object sender, EventArgs e)
        {
            CargarDashboard();
        }
    }
}
