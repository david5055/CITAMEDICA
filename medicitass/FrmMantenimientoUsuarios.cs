
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmMantenimientoUsuarios : Form
    {
        private readonly Conexion conexion = new Conexion();

        private int idSeleccionado = 0;

        public FrmMantenimientoUsuarios()
        {
            InitializeComponent();
        }

        private void FrmMantenimientoUsuarios_Load(
            object sender, EventArgs e)
        {
            try
            {
                CargarRoles();
                CargarEstados();
                CargarDoctores();
                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // ==========================================
        // CARGAR LOS TRES ROLES
        // ==========================================
        private void CargarRoles()
        {
            string sql = @"
                SELECT id_rol, nombre_rol
                FROM dbo.Roles
                WHERE nombre_rol IN
                    ('Administrador', 'Recepcionista', 'Doctor')
                ORDER BY nombre_rol";

            using (SqlConnection cn = conexion.Conectar())
            using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
            {
                DataTable tabla = new DataTable();
                da.Fill(tabla);

                cboRol.DisplayMember = "nombre_rol";
                cboRol.ValueMember = "id_rol";
                cboRol.DataSource = tabla;
                cboRol.SelectedIndex = -1;
            }
        }

        // ==========================================
        // CARGAR ESTADOS
        // ==========================================
        private void CargarEstados()
        {
            cboEstado.Items.Clear();
            cboEstado.Items.Add("Activo");
            cboEstado.Items.Add("Inactivo");
            cboEstado.SelectedIndex = 0;
        }

        // ==========================================
        // CARGAR DOCTORES
        // ==========================================
        private void CargarDoctores()
        {
            string sql = @"
                SELECT
                    d.id_doctor,
                    CONCAT(
                        d.nombres, ' ',
                        d.apellidos, ' - ',
                        e.nombre,
                        CASE
                            WHEN d.estado = 'Inactivo'
                            THEN ' (Inactivo)'
                            ELSE ''
                        END
                    ) AS nombre_completo
                FROM dbo.Doctores d
                INNER JOIN dbo.Especialidades e
                    ON d.id_especialidad = e.id_especialidad
                ORDER BY d.nombres, d.apellidos";

            using (SqlConnection cn = conexion.Conectar())
            using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
            {
                DataTable tabla = new DataTable();
                da.Fill(tabla);

                cboDoctor.DisplayMember = "nombre_completo";
                cboDoctor.ValueMember = "id_doctor";
                cboDoctor.DataSource = tabla;
                cboDoctor.SelectedIndex = -1;
            }
        }

        // ==========================================
        // CAMBIO DE ROL
        // ==========================================
        private void cboRol_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            bool esDoctor = EsRolDoctor();

            cboDoctor.Enabled = esDoctor;
            lblDoctor.Enabled = esDoctor;

            if (!esDoctor)
                cboDoctor.SelectedIndex = -1;
        }

        private bool EsRolDoctor()
        {
            if (cboRol.SelectedIndex < 0)
                return false;

            DataRowView fila =
                cboRol.SelectedItem as DataRowView;

            if (fila == null)
                return false;

            return string.Equals(
                Convert.ToString(fila["nombre_rol"]),
                "Doctor",
                StringComparison.OrdinalIgnoreCase);
        }

        // ==========================================
        // CARGAR TABLA DE USUARIOS
        // ==========================================
        private void CargarUsuarios(string busqueda = "")
        {
            string sql = @"
                SELECT
                    u.id_usuario AS [Código],
                    u.nombre_usuario AS [Nombre de Usuario],
                    r.nombre_rol AS [Rol],
                    u.id_rol AS [IdRol],
                    u.id_doctor AS [IdDoctor],
                    ISNULL(
                        d.nombres + ' ' + d.apellidos,
                        'No aplica'
                    ) AS [Doctor asignado],
                    ISNULL(u.estado, '') AS [Estado],
                    ISNULL(u.intentos_fallidos, 0)
                        AS [Intentos fallidos],
                    CASE
                        WHEN u.contrasena_hash
                             LIKE 'PBKDF2-SHA256$%'
                        THEN 'Configurada'
                        ELSE 'Revisar formato'
                    END AS [Contraseña]
                FROM dbo.Usuarios u
                INNER JOIN dbo.Roles r
                    ON u.id_rol = r.id_rol
                LEFT JOIN dbo.Doctores d
                    ON u.id_doctor = d.id_doctor
                WHERE
                    (@Buscar = ''
                     OR u.nombre_usuario LIKE
                        '%' + @Buscar + '%')
                ORDER BY u.id_usuario DESC";

            using (SqlConnection cn = conexion.Conectar())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add(
                    "@Buscar", SqlDbType.VarChar, 50
                ).Value = busqueda;

                using (SqlDataAdapter da =
                    new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);

                    dgvUsuarios.DataSource = tabla;
                }
            }

            if (dgvUsuarios.Columns.Contains("IdRol"))
                dgvUsuarios.Columns["IdRol"].Visible = false;

            if (dgvUsuarios.Columns.Contains("IdDoctor"))
                dgvUsuarios.Columns["IdDoctor"].Visible = false;

            if (dgvUsuarios.Columns.Contains("Código"))
                dgvUsuarios.Columns["Código"].FillWeight = 45;

            if (dgvUsuarios.Columns.Contains("Nombre de Usuario"))
                dgvUsuarios.Columns["Nombre de Usuario"]
                    .FillWeight = 110;

            if (dgvUsuarios.Columns.Contains("Doctor asignado"))
                dgvUsuarios.Columns["Doctor asignado"]
                    .FillWeight = 155;

            dgvUsuarios.ClearSelection();
        }

        // ==========================================
        // VALIDAR CAMPOS
        // ==========================================
        private bool ValidarCampos(bool nuevo)
        {
            if (string.IsNullOrWhiteSpace(
                txtNombreUsuario.Text))
            {
                MessageBox.Show(
                    "Ingrese el nombre de usuario.");
                txtNombreUsuario.Focus();
                return false;
            }

            if (txtNombreUsuario.Text.Trim().Length > 50)
            {
                MessageBox.Show(
                    "El usuario no puede superar 50 caracteres.");
                return false;
            }

            if (cboRol.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Seleccione un rol.");
                return false;
            }

            if (cboEstado.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Seleccione un estado.");
                return false;
            }

            if (EsRolDoctor() &&
                cboDoctor.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Debe asignar un médico a la cuenta Doctor.",
                    "Doctor requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            string clave = txtContrasena.Text;

            if (nuevo && string.IsNullOrEmpty(clave))
            {
                MessageBox.Show(
                    "Ingrese una contraseña.");
                return false;
            }

            if (!string.IsNullOrEmpty(clave) &&
                (clave.Length < 8 || clave.Length > 128))
            {
                MessageBox.Show(
                    "La contraseña debe tener entre " +
                    "8 y 128 caracteres.");
                return false;
            }

            return true;
        }

        // ==========================================
        // VERIFICAR USUARIO DUPLICADO
        // ==========================================
        private bool ExisteUsuario(
            SqlConnection cn, SqlTransaction tx,
            string nombre, int idExcluir)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM dbo.Usuarios
                WHERE nombre_usuario = @Nombre
                  AND id_usuario <> @IdExcluir";

            using (SqlCommand cmd =
                new SqlCommand(sql, cn, tx))
            {
                cmd.Parameters.Add(
                    "@Nombre", SqlDbType.VarChar, 50
                ).Value = nombre;

                cmd.Parameters.Add(
                    "@IdExcluir", SqlDbType.Int
                ).Value = idExcluir;

                return Convert.ToInt32(
                    cmd.ExecuteScalar()) > 0;
            }
        }

        // ==========================================
        // COMPROBAR ASIGNACIÓN DEL DOCTOR
        // ==========================================
        private bool ExisteDoctorAsignado(
            SqlConnection cn, SqlTransaction tx,
            int idDoctor, int idExcluir)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM dbo.Usuarios
                WHERE id_doctor = @IdDoctor
                  AND id_usuario <> @IdExcluir";

            using (SqlCommand cmd =
                new SqlCommand(sql, cn, tx))
            {
                cmd.Parameters.Add(
                    "@IdDoctor", SqlDbType.Int
                ).Value = idDoctor;

                cmd.Parameters.Add(
                    "@IdExcluir", SqlDbType.Int
                ).Value = idExcluir;

                return Convert.ToInt32(
                    cmd.ExecuteScalar()) > 0;
            }
        }

        private bool DoctorEstaActivo(
            SqlConnection cn, SqlTransaction tx,
            int idDoctor)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM dbo.Doctores
                WHERE id_doctor = @IdDoctor
                  AND estado = 'Activo'";

            using (SqlCommand cmd =
                new SqlCommand(sql, cn, tx))
            {
                cmd.Parameters.Add(
                    "@IdDoctor", SqlDbType.Int
                ).Value = idDoctor;

                return Convert.ToInt32(
                    cmd.ExecuteScalar()) == 1;
            }
        }

        // ==========================================
        // GUARDAR NUEVO USUARIO
        // ==========================================
        private void btnGuardar_Click(
            object sender, EventArgs e)
        {
            if (!ValidarCampos(true))
                return;

            string nombre = txtNombreUsuario.Text.Trim();
            int idRol = Convert.ToInt32(
                cboRol.SelectedValue);

            int? idDoctor = EsRolDoctor()
                ? (int?)Convert.ToInt32(cboDoctor.SelectedValue)
                : null;

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
                            if (ExisteUsuario(cn, tx, nombre, 0))
                                throw new Exception(
                                    "El nombre de usuario ya existe.");

                            if (idDoctor.HasValue)
                            {
                                if (!DoctorEstaActivo(
                                    cn, tx, idDoctor.Value))
                                    throw new Exception(
                                        "El médico seleccionado no está activo.");

                                if (ExisteDoctorAsignado(
                                    cn, tx, idDoctor.Value, 0))
                                    throw new Exception(
                                        "Ese médico ya está asignado " +
                                        "a otra cuenta de usuario.");
                            }

                            string hash =
                                SeguridadPassword.CrearHash(
                                    txtContrasena.Text);

                            string sql = @"
                                INSERT INTO dbo.Usuarios
                                (
                                    nombre_usuario,
                                    contrasena_hash,
                                    id_rol,
                                    id_doctor,
                                    estado,
                                    intentos_fallidos,
                                    bloqueo_hasta
                                )
                                VALUES
                                (
                                    @Nombre,
                                    @Hash,
                                    @Rol,
                                    @Doctor,
                                    @Estado,
                                    0,
                                    NULL
                                )";

                            using (SqlCommand cmd =
                                new SqlCommand(sql, cn, tx))
                            {
                                cmd.Parameters.Add(
                                    "@Nombre",
                                    SqlDbType.VarChar, 50
                                ).Value = nombre;

                                cmd.Parameters.Add(
                                    "@Hash",
                                    SqlDbType.VarChar, 255
                                ).Value = hash;

                                cmd.Parameters.Add(
                                    "@Rol", SqlDbType.Int
                                ).Value = idRol;

                                cmd.Parameters.Add(
                                    "@Doctor", SqlDbType.Int
                                ).Value = (object)idDoctor
                                    ?? DBNull.Value;

                                cmd.Parameters.Add(
                                    "@Estado",
                                    SqlDbType.VarChar, 15
                                ).Value = cboEstado.Text;

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
                    "Usuario guardado correctamente.",
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // ==========================================
        // MODIFICAR USUARIO
        // ==========================================
        private void btnModificar_Click(
            object sender, EventArgs e)
        {
            if (idSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Seleccione un usuario de la tabla.");
                return;
            }

            if (!ValidarCampos(false))
                return;

            string nombre = txtNombreUsuario.Text.Trim();
            int idRol = Convert.ToInt32(
                cboRol.SelectedValue);

            int? idDoctor = EsRolDoctor()
                ? (int?)Convert.ToInt32(cboDoctor.SelectedValue)
                : null;

            bool cambiarClave =
                !string.IsNullOrEmpty(txtContrasena.Text);

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
                            if (ExisteUsuario(
                                cn, tx, nombre, idSeleccionado))
                                throw new Exception(
                                    "Ya existe otro usuario con ese nombre.");

                            if (idDoctor.HasValue)
                            {
                                if (!DoctorEstaActivo(
                                    cn, tx, idDoctor.Value))
                                    throw new Exception(
                                        "El médico seleccionado no está activo.");

                                if (ExisteDoctorAsignado(
                                    cn, tx, idDoctor.Value,
                                    idSeleccionado))
                                    throw new Exception(
                                        "Ese médico ya pertenece " +
                                        "a otra cuenta.");
                            }

                            string sql = @"
                                UPDATE dbo.Usuarios
                                SET
                                    nombre_usuario = @Nombre,
                                    id_rol = @Rol,
                                    id_doctor = @Doctor,
                                    estado = @Estado";

                            if (cambiarClave)
                            {
                                sql += @",
                                    contrasena_hash = @Hash,
                                    intentos_fallidos = 0,
                                    bloqueo_hasta = NULL";
                            }

                            sql += @"
                                WHERE id_usuario = @Id";

                            using (SqlCommand cmd =
                                new SqlCommand(sql, cn, tx))
                            {
                                cmd.Parameters.Add(
                                    "@Nombre",
                                    SqlDbType.VarChar, 50
                                ).Value = nombre;

                                cmd.Parameters.Add(
                                    "@Rol", SqlDbType.Int
                                ).Value = idRol;

                                cmd.Parameters.Add(
                                    "@Doctor", SqlDbType.Int
                                ).Value = (object)idDoctor
                                    ?? DBNull.Value;

                                cmd.Parameters.Add(
                                    "@Estado",
                                    SqlDbType.VarChar, 15
                                ).Value = cboEstado.Text;

                                cmd.Parameters.Add(
                                    "@Id", SqlDbType.Int
                                ).Value = idSeleccionado;

                                if (cambiarClave)
                                {
                                    cmd.Parameters.Add(
                                        "@Hash",
                                        SqlDbType.VarChar, 255
                                    ).Value =
                                        SeguridadPassword.CrearHash(
                                            txtContrasena.Text);
                                }

                                if (cmd.ExecuteNonQuery() != 1)
                                    throw new Exception(
                                        "No se encontró el usuario.");
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
                    "Usuario actualizado correctamente.",
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // ==========================================
        // INACTIVAR USUARIO
        // ==========================================
        private void btnInactivar_Click(
            object sender, EventArgs e)
        {
            if (idSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Seleccione el usuario que desea inactivar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea inactivar esta cuenta?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection cn = conexion.Conectar())
                using (SqlCommand cmd = new SqlCommand(
                    @"UPDATE dbo.Usuarios
                      SET estado = 'Inactivo',
                          bloqueo_hasta = NULL
                      WHERE id_usuario = @Id", cn))
                {
                    cmd.Parameters.Add(
                        "@Id", SqlDbType.Int
                    ).Value = idSeleccionado;

                    cn.Open();

                    if (cmd.ExecuteNonQuery() != 1)
                        throw new Exception(
                            "No se encontró la cuenta.");
                }

                MessageBox.Show(
                    "La cuenta fue inactivada.");

                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // ==========================================
        // SELECCIONAR REGISTRO
        // ==========================================
        private void dgvUsuarios_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.RowIndex >= dgvUsuarios.Rows.Count)
                return;

            DataGridViewRow fila =
                dgvUsuarios.Rows[e.RowIndex];

            if (fila.IsNewRow)
                return;

            idSeleccionado = Convert.ToInt32(
                fila.Cells["Código"].Value);

            txtIdUsuario.Text =
                idSeleccionado.ToString();

            txtNombreUsuario.Text =
                Convert.ToString(
                    fila.Cells["Nombre de Usuario"].Value);

            txtContrasena.Clear();

            cboRol.SelectedValue =
                Convert.ToInt32(
                    fila.Cells["IdRol"].Value);

            string estado =
                Convert.ToString(
                    fila.Cells["Estado"].Value);

            if (cboEstado.Items.Contains(estado))
                cboEstado.SelectedItem = estado;
            else
                cboEstado.SelectedIndex = 0;

            object valorDoctor =
                fila.Cells["IdDoctor"].Value;

            if (EsRolDoctor() &&
                valorDoctor != null &&
                valorDoctor != DBNull.Value)
            {
                cboDoctor.SelectedValue =
                    Convert.ToInt32(valorDoctor);
            }
            else
            {
                cboDoctor.SelectedIndex = -1;
            }

            btnGuardar.Enabled = false;
            btnModificar.Enabled = true;
            btnInactivar.Enabled = true;
        }

        // ==========================================
        // BUSCAR Y REFRESCAR
        // ==========================================
        private void btnBuscar_Click(
            object sender, EventArgs e)
        {
            try
            {
                CargarUsuarios(txtBuscar.Text.Trim());
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnRefrescar_Click(
            object sender, EventArgs e)
        {
            try
            {
                txtBuscar.Clear();
                CargarDoctores();
                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnLimpiar_Click(
            object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // ==========================================
        // LIMPIAR CAMPOS
        // ==========================================
        private void LimpiarCampos()
        {
            idSeleccionado = 0;

            txtIdUsuario.Clear();
            txtNombreUsuario.Clear();
            txtContrasena.Clear();

            cboRol.SelectedIndex = -1;
            cboDoctor.SelectedIndex = -1;

            if (cboEstado.Items.Count > 0)
                cboEstado.SelectedIndex = 0;

            cboDoctor.Enabled = false;
            lblDoctor.Enabled = false;

            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnInactivar.Enabled = false;

            dgvUsuarios.ClearSelection();
            txtNombreUsuario.Focus();
        }

        // ==========================================
        // MOSTRAR ERRORES
        // ==========================================
        private void MostrarError(Exception ex)
        {
            MessageBox.Show(
                ex.GetBaseException().Message,
                "MediCitas - Usuarios",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
