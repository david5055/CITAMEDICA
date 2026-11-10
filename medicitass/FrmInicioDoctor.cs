
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

        // Constructor para el diseñador
        public FrmInicioDoctor() : this("")
        {
        }

        // Constructor que recibe el usuario del Login
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

        // ==========================================
        // CARGAR LA VENTANA
        // ==========================================
        private void FrmInicioDoctor_Load(
            object sender, EventArgs e)
        {
            CargarDashboard();
        }

        // ==========================================
        // IDENTIFICAR AL DOCTOR
        // ==========================================
        private bool ObtenerIdentidad(SqlConnection cn)
        {
            idDoctorActual = 0;
            idUsuarioActual = 0;

            using (SqlCommand cmd = new SqlCommand(
                "SELECT COL_LENGTH('dbo.Usuarios', 'id_doctor')",
                cn))
            {
                object resultado = cmd.ExecuteScalar();

                if (resultado == null ||
                    resultado == DBNull.Value)
                {
                    lblEstado.Text =
                        "Pendiente: relacionar la cuenta " +
                        "con un doctor en SQL Server.";

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

                    int usuarioId =
                        Convert.ToInt32(dr["id_usuario"]);

                    int doctorId =
                        Convert.ToInt32(dr["id_doctor"]);

                    if (dr.Read())
                    {
                        lblEstado.Text =
                            "Existen cuentas duplicadas. " +
                            "Revise los usuarios registrados.";

                        return false;
                    }

                    idUsuarioActual = usuarioId;
                    idDoctorActual = doctorId;
                }
            }

            return true;
        }

        // ==========================================
        // CARGAR ESTADÍSTICAS Y AGENDA
        // ==========================================
        private void CargarDashboard()
        {
            idDoctorActual = 0;
            idUsuarioActual = 0;

            lblTotalHoy.Text = "—";
            lblPendientes.Text = "—";
            lblAtendidas.Text = "—";

            dgvAgenda.Rows.Clear();

            btnMarcarAtendida.Enabled = false;
            btnActualizar.Enabled = false;

            lblEstado.Text = "Cargando información...";

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
                    "Error al cargar las citas del doctor:\n\n" +
                    ex.GetBaseException().Message,
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnActualizar.Enabled = true;
            }
        }

        // ==========================================
        // CONTADORES DEL DOCTOR
        // ==========================================
        private void CargarIndicadores(SqlConnection cn)
        {
            string sql = @"
                SELECT
                    COUNT(*) AS CitasHoy,
                    COUNT(
                        CASE
                            WHEN estado = 'Programada'
                            THEN 1
                        END
                    ) AS Pendientes,
                    COUNT(
                        CASE
                            WHEN estado = 'Atendida'
                            THEN 1
                        END
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

        // ==========================================
        // AGENDA DEL MÉDICO AUTENTICADO
        // ==========================================
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

                        string horaTexto =
                            DateTime.Today.Add(hora)
                            .ToString("hh:mm tt");

                        dgvAgenda.Rows.Add(
                            dr["id_cita"],
                            horaTexto,
                            dr["Paciente"].ToString(),
                            dr["Motivo"].ToString(),
                            dr["Estado"].ToString()
                        );
                    }
                }
            }

            dgvAgenda.ClearSelection();
            btnMarcarAtendida.Enabled = false;
        }

        // ==========================================
        // HABILITAR BOTÓN SEGÚN LA CITA
        // ==========================================
        private void dgvAgenda_SelectionChanged(
            object sender, EventArgs e)
        {
            if (btnMarcarAtendida == null ||
                dgvAgenda == null)
            {
                return;
            }

            bool permitido =
                idDoctorActual > 0 &&
                idUsuarioActual > 0 &&
                dgvAgenda.SelectedRows.Count == 1;

            if (permitido)
            {
                DataGridViewRow fila =
                    dgvAgenda.SelectedRows[0];

                string estado =
                    Convert.ToString(
                        fila.Cells["colEstado"].Value);

                permitido = string.Equals(
                    estado,
                    "Programada",
                    StringComparison.OrdinalIgnoreCase);
            }

            btnMarcarAtendida.Enabled = permitido;
        }

        // ==========================================
        // BOTÓN ACTUALIZAR
        // ==========================================
        private void btnActualizar_Click(
            object sender, EventArgs e)
        {
            CargarDashboard();
        }

        // ==========================================
        // BOTÓN MARCAR CITA ATENDIDA
        // ==========================================
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

            int idCita;

            if (!int.TryParse(
                Convert.ToString(
                    fila.Cells["colIdCita"].Value),
                out idCita))
            {
                MessageBox.Show(
                    "No se pudo identificar la cita.",
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string estado =
                Convert.ToString(
                    fila.Cells["colEstado"].Value);

            if (!string.Equals(
                estado,
                "Programada",
                StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Seleccione una cita programada.",
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Confirmas que terminaste de atender " +
                "la cita N° " + idCita + "?",
                "Confirmar atención",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
                return;

            btnMarcarAtendida.Enabled = false;

            try
            {
                using (SqlConnection cn = conexion.Conectar())
                {
                    cn.Open();

                    using (SqlTransaction tx =
                        cn.BeginTransaction(
                            IsolationLevel.Serializable))
                    {
                        try
                        {
                            // Verificar la cita y la cuenta
                            // antes de modificarla.
                            string verificar = @"
                                SELECT
                                    c.fecha,
                                    c.hora_inicio
                                FROM dbo.Citas c
                                    WITH (UPDLOCK, HOLDLOCK)
                                INNER JOIN dbo.Usuarios u
                                    ON u.id_doctor = c.id_doctor
                                INNER JOIN dbo.Roles r
                                    ON u.id_rol = r.id_rol
                                INNER JOIN dbo.Doctores d
                                    ON d.id_doctor = c.id_doctor
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
                                new SqlCommand(verificar, cn, tx))
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
                                            "La cita no está disponible " +
                                            "o no pertenece a este doctor.");
                                    }

                                    fechaCita =
                                        Convert.ToDateTime(
                                            dr["fecha"]);

                                    horaCita =
                                        (TimeSpan)dr["hora_inicio"];
                                }
                            }

                            // Cambiar el estado de la cita.
                            string actualizar = @"
                                UPDATE dbo.Citas
                                SET estado = 'Atendida'
                                WHERE id_cita = @IdCita
                                  AND id_doctor = @IdDoctor
                                  AND estado = 'Programada'";

                            using (SqlCommand cmd =
                                new SqlCommand(actualizar, cn, tx))
                            {
                                cmd.Parameters.Add(
                                    "@IdCita", SqlDbType.Int
                                ).Value = idCita;

                                cmd.Parameters.Add(
                                    "@IdDoctor", SqlDbType.Int
                                ).Value = idDoctorActual;

                                if (cmd.ExecuteNonQuery() != 1)
                                {
                                    throw new
                                        InvalidOperationException(
                                            "La cita cambió de estado " +
                                            "antes de actualizarse.");
                                }
                            }

                            // Registrar el movimiento.
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
                            if (tx.Connection != null)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo completar la atención:\n\n" +
                    ex.GetBaseException().Message,
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                CargarDashboard();
            }
        }
    }
}
