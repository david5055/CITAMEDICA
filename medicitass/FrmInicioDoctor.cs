
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmInicioDoctor : Form
    {
        private readonly Conexion conexion = new Conexion();
        private readonly string usuarioActual;

        private int idDoctorActual = 0;
        private int idUsuarioActual = 0;

        public FrmInicioDoctor() : this("")
        {
        }

        public FrmInicioDoctor(string usuario)
        {
            InitializeComponent();

            usuarioActual = usuario ?? "";

            lblBienvenida.Text =
                string.IsNullOrWhiteSpace(usuarioActual)
                ? "Bienvenido, Doctor"
                : "Bienvenido, " + usuarioActual;

            lblFecha.Text =
                "Fecha: " +
                DateTime.Today.ToString("dd/MM/yyyy");
        }

        private void FrmInicioDoctor_Load(
            object sender, EventArgs e)
        {
            CargarDashboard();
        }

        // ========================================
        // IDENTIFICAR AL DOCTOR AUTENTICADO
        // ========================================
        private bool ObtenerIdentidad(SqlConnection cn)
        {
            idDoctorActual = 0;
            idUsuarioActual = 0;

            // Verificar si la nueva columna existe
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT COL_LENGTH(
                    'dbo.Usuarios', 'id_doctor')", cn))
            {
                if (cmd.ExecuteScalar() == DBNull.Value)
                {
                    lblEstado.Text =
                        "Pendiente: relacionar la cuenta " +
                        "con el doctor en SQL Server.";

                    return false;
                }
            }

            string sql = @"
                SELECT
                    u.id_usuario,
                    u.id_doctor
                FROM dbo.Usuarios u
                INNER JOIN dbo.Roles r
                    ON u.id_rol = r.id_rol
                INNER JOIN dbo.Doctores d
                    ON u.id_doctor = d.id_doctor
                WHERE u.nombre_usuario = @Usuario
                  AND r.nombre_rol = 'Doctor'
                  AND u.estado = 'Activo'
                  AND d.estado = 'Activo'";

            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add(
                    "@Usuario", SqlDbType.VarChar, 50
                ).Value = usuarioActual;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read())
                    {
                        lblEstado.Text =
                            "La cuenta no tiene un doctor " +
                            "activo correctamente asignado.";

                        return false;
                    }

                    int idUsuario =
                        Convert.ToInt32(dr["id_usuario"]);

                    int idDoctor =
                        Convert.ToInt32(dr["id_doctor"]);

                    // No aceptar nombres de usuario duplicados
                    // que puedan corresponder a otra persona.
                    if (dr.Read())
                    {
                        lblEstado.Text =
                            "Hay cuentas duplicadas. " +
                            "Revise los usuarios.";

                        return false;
                    }

                    idUsuarioActual = idUsuario;
                    idDoctorActual = idDoctor;
                }
            }

            return true;
        }

        // ========================================
        // CARGAR DASHBOARD
        // ========================================
        private void CargarDashboard()
        {
            lblTotalHoy.Text = "—";
            lblPendientes.Text = "—";
            lblAtendidas.Text = "—";

            dgvAgenda.Rows.Clear();
            btnMarcarAtendida.Enabled = false;

            lblEstado.Text = "Cargando agenda...";

            try
            {
                using (SqlConnection cn = conexion.Conectar())
                {
                    cn.Open();

                    if (!ObtenerIdentidad(cn))
                        return;

                    CargarIndicadores(cn);
                    CargarAgenda(cn);
                }

                lblEstado.Text =
                    "Agenda actualizada: " +
                    DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            }
            catch (Exception ex)
            {
                lblEstado.Text =
                    "No se pudo cargar la agenda.";

                MessageBox.Show(
                    "Error al consultar las citas:\n\n" +
                    ex.Message,
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ========================================
        // CONTADORES DEL DOCTOR
        // ========================================
        private void CargarIndicadores(SqlConnection cn)
        {
            string sql = @"
                SELECT
                    COUNT(*) AS CitasHoy,

                    COUNT(
                        CASE WHEN estado = 'Programada'
                        THEN 1 END
                    ) AS Pendientes,

                    COUNT(
                        CASE WHEN estado = 'Atendida'
                        THEN 1 END
                    ) AS Atendidas

                FROM dbo.Citas
                WHERE id_doctor = @IdDoctor
                  AND fecha = CAST(GETDATE() AS DATE)";

            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add(
                    "@IdDoctor", SqlDbType.Int
                ).Value = idDoctorActual;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        lblTotalHoy.Text =
                            dr["CitasHoy"].ToString();

                        lblPendientes.Text =
                            dr["Pendientes"].ToString();

                        lblAtendidas.Text =
                            dr["Atendidas"].ToString();
                    }
                }
            }
        }

        // ========================================
        // MOSTRAR MI AGENDA DEL DÍA
        // ========================================
        private void CargarAgenda(SqlConnection cn)
        {
            string sql = @"
                SELECT
                    c.id_cita,
                    c.hora_inicio,
                    p.nombres + ' ' + p.apellidos
                        AS Paciente,
                    ISNULL(c.motivo_consulta, '')
                        AS Motivo,
                    ISNULL(c.estado, '')
                        AS Estado
                FROM dbo.Citas c
                INNER JOIN dbo.Pacientes p
                    ON c.id_paciente = p.id_paciente
                WHERE c.id_doctor = @IdDoctor
                  AND c.fecha = CAST(GETDATE() AS DATE)
                ORDER BY c.hora_inicio";

            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add(
                    "@IdDoctor", SqlDbType.Int
                ).Value = idDoctorActual;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TimeSpan hora =
                            (TimeSpan)dr["hora_inicio"];

                        string horaFormateada =
                            DateTime.Today.Add(hora)
                            .ToString("hh:mm tt");

                        dgvAgenda.Rows.Add(
                            dr["id_cita"],
                            horaFormateada,
                            dr["Paciente"].ToString(),
                            dr["Motivo"].ToString(),
                            dr["Estado"].ToString()
                        );
                    }
                }
            }

            dgvAgenda.ClearSelection();
        }

        // ========================================
        // SELECCIONAR CITA
        // ========================================
        private void dgvAgenda_SelectionChanged(
            object sender, EventArgs e)
        {
            bool puedeAtender =
                idDoctorActual > 0 &&
                idUsuarioActual > 0 &&
                dgvAgenda.SelectedRows.Count == 1;

            if (puedeAtender)
            {
                DataGridViewRow fila =
                    dgvAgenda.SelectedRows[0];

                puedeAtender =
                    string.Equals(
                        Convert.ToString(
                            fila.Cells["colEstado"].Value),
                        "Programada",
                        StringComparison.OrdinalIgnoreCase);
            }

            btnMarcarAtendida.Enabled = puedeAtender;
        }

        // ========================================
        // MARCAR CITA COMO ATENDIDA
        // ========================================
        private void btnMarcarAtendida_Click(
            object sender, EventArgs e)
        {
            if (idDoctorActual <= 0 ||
                idUsuarioActual <= 0 ||
                dgvAgenda.SelectedRows.Count != 1)
            {
                return;
            }

            DataGridViewRow fila =
                dgvAgenda.SelectedRows[0];

            if (!int.TryParse(
                Convert.ToString(
                    fila.Cells["colIdCita"].Value),
                out int idCita))
            {
                return;
            }

            if (!string.Equals(
                Convert.ToString(
                    fila.Cells["colEstado"].Value),
                "Programada",
                StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            DialogResult confirmar = MessageBox.Show(
                "¿Confirmas que terminaste de atender " +
                "esta cita?\n\nCita N° " + idCita,
                "Confirmar atención",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection cn = conexion.Conectar())
                {
                    cn.Open();

                    // Una transacción permite actualizar
                    // la cita y guardar su historial juntos.
                    using (SqlTransaction tx =
                        cn.BeginTransaction())
                    {
                        try
                        {
                            // Volver a verificar que la cuenta
                            // sigue activa y corresponde al doctor.
                            string sql = @"
                                UPDATE c
                                SET c.estado = 'Atendida'
                                OUTPUT
                                    inserted.fecha,
                                    inserted.hora_inicio
                                FROM dbo.Citas c
                                INNER JOIN dbo.Usuarios u
                                    ON u.id_doctor = c.id_doctor
                                INNER JOIN dbo.Roles r
                                    ON u.id_rol = r.id_rol
                                INNER JOIN dbo.Doctores d
                                    ON c.id_doctor = d.id_doctor
                                WHERE c.id_cita = @IdCita
                                  AND c.id_doctor = @IdDoctor
                                  AND u.id_usuario = @IdUsuario
                                  AND u.nombre_usuario = @Usuario
                                  AND u.estado = 'Activo'
                                  AND d.estado = 'Activo'
                                  AND r.nombre_rol = 'Doctor'
                                  AND c.estado = 'Programada'
                                  AND c.fecha <=
                                      CAST(GETDATE() AS DATE)";

                            DateTime fechaCita;
                            TimeSpan horaCita;

                            using (SqlCommand cmd =
                                new SqlCommand(sql, cn, tx))
                            {
                                cmd.Parameters.Add(
                                    "@IdCita", SqlDbType.Int
                                ).Value = idCita;

                                cmd.Parameters.Add(
                                    "@IdDoctor", SqlDbType.Int
                                ).Value = idDoctorActual;

                                cmd.Parameters.Add(
                                    "@IdUsuario", SqlDbType.Int
                                ).Value = idUsuarioActual;

                                cmd.Parameters.Add(
                                    "@Usuario",
                                    SqlDbType.VarChar, 50
                                ).Value = usuarioActual;

                                using (SqlDataReader dr =
                                    cmd.ExecuteReader())
                                {
                                    if (!dr.Read())
                                    {
                                        throw new
                                            InvalidOperationException(
                                            "La cita ya fue modificada, " +
                                            "no está programada o no " +
                                            "pertenece a este doctor.");
                                    }

                                    fechaCita =
                                        Convert.ToDateTime(
                                            dr["fecha"]);

                                    horaCita =
                                        (TimeSpan)dr["hora_inicio"];
                                }
                            }

                            string historial = @"
                                INSERT INTO dbo.Historial_Citas
                                (
                                    id_cita,
                                    accion,
                                    fecha_anterior,
                                    hora_anterior,
                                    fecha_nueva,
                                    hora_nueva,
                                    id_usuario,
                                    fecha_movimiento
                                )
                                VALUES
                                (
                                    @IdCita,
                                    'Atendida',
                                    @Fecha,
                                    @Hora,
                                    @Fecha,
                                    @Hora,
                                    @IdUsuario,
                                    SYSDATETIME()
                                )";

                            using (SqlCommand cmd =
                                new SqlCommand(historial, cn, tx))
                            {
                                cmd.Parameters.Add(
                                    "@IdCita", SqlDbType.Int
                                ).Value = idCita;

                                cmd.Parameters.Add(
                                    "@Fecha", SqlDbType.Date
                                ).Value = fechaCita;

                                cmd.Parameters.Add(
                                    "@Hora", SqlDbType.Time
                                ).Value = horaCita;

                                cmd.Parameters.Add(
                                    "@IdUsuario", SqlDbType.Int
                                ).Value = idUsuarioActual;

                                cmd.ExecuteNonQuery();
                            }

                            tx.Commit();
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show(
                    "La cita fue marcada como atendida.",
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo completar la atención:\n\n" +
                    ex.GetBaseException().Message,
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                CargarDashboard();
            }
        }

        // ========================================
        // ACTUALIZAR
        // ========================================
        private void btnActualizar_Click(
            object sender, EventArgs e)
        {
            CargarDashboard();
        }
    }
}
