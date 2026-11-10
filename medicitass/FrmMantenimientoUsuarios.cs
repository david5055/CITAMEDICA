
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmMantenimientoUsuarios : Form
    {
        private readonly Conexion conexion = new Conexion();

        public FrmMantenimientoUsuarios()
        {
            InitializeComponent();
        }

        private void FrmMantenimientoUsuarios_Load(
            object sender, EventArgs e)
        {
            CargarComboRoles();
            CargarEstados();
            CargarUsuarios();
            LimpiarCampos();
        }

        // =========================================
        // CARGAR ROLES
        // =========================================
        private void CargarComboRoles()
        {
            try
            {
                using (SqlConnection cn = conexion.Conectar())
                {
                    string sql = @"
                        SELECT id_rol, nombre_rol
                        FROM Roles
                        ORDER BY id_rol";

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(sql, cn))
                    {
                        DataTable tabla = new DataTable();
                        da.Fill(tabla);

                        cboRol.DataSource = tabla;
                        cboRol.DisplayMember = "nombre_rol";
                        cboRol.ValueMember = "id_rol";
                        cboRol.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar roles: " + ex.Message);
            }
        }

        // =========================================
        // CARGAR ESTADOS
        // =========================================
        private void CargarEstados()
        {
            cboEstado.Items.Clear();
            cboEstado.Items.Add("Activo");
            cboEstado.Items.Add("Inactivo");
            cboEstado.SelectedIndex = 0;
        }

        // =========================================
        // CARGAR USUARIOS
        // =========================================
        private void CargarUsuarios(string filtro = "")
        {
            try
            {
                using (SqlConnection cn = conexion.Conectar())
                {
                    string sql = @"
                        SELECT
                            u.id_usuario AS [Código],
                            u.nombre_usuario AS [Nombre de Usuario],
                            r.nombre_rol AS [Rol],
                            u.id_rol AS [IdRol],
                            u.estado AS [Estado],
                            ISNULL(u.intentos_fallidos, 0)
                                AS [Intentos Fallidos],
                            CASE
                                WHEN u.contrasena_hash
                                    LIKE 'PBKDF2-SHA256$%'
                                    THEN 'Configurada'
                                WHEN u.contrasena_hash =
                                    'PENDIENTE_HASH_CSHARP'
                                    THEN 'Pendiente'
                                ELSE 'Requiere actualizar'
                            END AS [Contraseña]
                        FROM Usuarios u
                        INNER JOIN Roles r
                            ON u.id_rol = r.id_rol
                        WHERE
                            u.nombre_usuario LIKE @filtro
                            OR r.nombre_rol LIKE @filtro
                        ORDER BY u.id_usuario DESC";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.Add(
                            "@filtro", SqlDbType.VarChar, 100
                        ).Value = "%" + filtro.Trim() + "%";

                        using (SqlDataAdapter da =
                            new SqlDataAdapter(cmd))
                        {
                            DataTable tabla = new DataTable();
                            da.Fill(tabla);

                            dgvUsuarios.DataSource = tabla;

                            if (dgvUsuarios.Columns.Contains("IdRol"))
                            {
                                dgvUsuarios.Columns["IdRol"].Visible =
                                    false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar usuarios: " + ex.Message);
            }
        }

        // =========================================
        // LIMPIAR CAMPOS
        // =========================================
        private void LimpiarCampos()
        {
            txtIdUsuario.Clear();
            txtNombreUsuario.Clear();
            txtContrasena.Clear();

            if (cboRol.Items.Count > 0)
                cboRol.SelectedIndex = -1;

            if (cboEstado.Items.Count > 0)
                cboEstado.SelectedIndex = 0;

            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnInactivar.Enabled = false;

            dgvUsuarios.ClearSelection();
            txtNombreUsuario.Focus();
        }

        // =========================================
        // VALIDAR CAMPOS
        // =========================================
        private bool ValidarCampos(bool nuevo)
        {
            if (string.IsNullOrWhiteSpace(
                txtNombreUsuario.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el nombre de usuario.");
                txtNombreUsuario.Focus();
                return false;
            }

            if (txtNombreUsuario.Text.Trim().Length > 50)
            {
                MessageBox.Show(
                    "El nombre no puede superar 50 caracteres.");
                return false;
            }

            if (cboRol.SelectedValue == null ||
                cboRol.SelectedValue is DataRowView)
            {
                MessageBox.Show(
                    "Seleccione un rol válido.");
                return false;
            }

            if (cboEstado.SelectedItem == null)
            {
                MessageBox.Show(
                    "Seleccione un estado.");
                return false;
            }

            bool hayClave =
                !string.IsNullOrEmpty(txtContrasena.Text);

            if (nuevo && !hayClave)
            {
                MessageBox.Show(
                    "Debe ingresar una contraseña.");
                txtContrasena.Focus();
                return false;
            }

            if (hayClave && txtContrasena.Text.Length < 8)
            {
                MessageBox.Show(
                    "La contraseña debe tener al menos 8 caracteres.");
                txtContrasena.Focus();
                return false;
            }

            if (hayClave &&
                txtContrasena.Text.Length > 128)
            {
                MessageBox.Show(
                    "La contraseña no puede superar 128 caracteres.");
                return false;
            }

            return true;
        }

        // =========================================
        // COMPROBAR NOMBRE DUPLICADO
        // =========================================
        private bool ExisteUsername(
            SqlConnection cn,
            string username,
            int excluirId)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM Usuarios
                WHERE nombre_usuario = @nombre
                  AND id_usuario <> @id";

            using (SqlCommand cmd =
                new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add(
                    "@nombre", SqlDbType.VarChar, 50
                ).Value = username;

                cmd.Parameters.Add(
                    "@id", SqlDbType.Int
                ).Value = excluirId;

                return Convert.ToInt32(
                    cmd.ExecuteScalar()) > 0;
            }
        }

        // =========================================
        // GUARDAR USUARIO
        // =========================================
        private void btnGuardar_Click(
            object sender, EventArgs e)
        {
            if (!ValidarCampos(true))
                return;

            try
            {
                string nombre = txtNombreUsuario.Text.Trim();

                // HASH COMPATIBLE CON EL LOGIN
                string hash =
                    SeguridadPassword.CrearHash(
                        txtContrasena.Text);

                using (SqlConnection cn = conexion.Conectar())
                {
                    cn.Open();

                    if (ExisteUsername(cn, nombre, 0))
                    {
                        MessageBox.Show(
                            "El nombre de usuario ya existe.");
                        return;
                    }

                    string sql = @"
                        INSERT INTO Usuarios
                        (
                            nombre_usuario,
                            contrasena_hash,
                            id_rol,
                            estado,
                            intentos_fallidos,
                            bloqueo_hasta
                        )
                        VALUES
                        (
                            @nombre,
                            @hash,
                            @rol,
                            @estado,
                            0,
                            NULL
                        )";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.Add(
                            "@nombre", SqlDbType.VarChar, 50
                        ).Value = nombre;

                        cmd.Parameters.Add(
                            "@hash", SqlDbType.VarChar, 255
                        ).Value = hash;

                        cmd.Parameters.Add(
                            "@rol", SqlDbType.Int
                        ).Value =
                            Convert.ToInt32(cboRol.SelectedValue);

                        cmd.Parameters.Add(
                            "@estado", SqlDbType.VarChar, 15
                        ).Value =
                            cboEstado.SelectedItem.ToString();

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Usuario guardado correctamente.\n" +
                    "La contraseña se almacenó de forma segura.",
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarUsuarios();
                LimpiarCampos();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Error de SQL Server: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar usuario: " + ex.Message);
            }
        }

        // =========================================
        // MODIFICAR USUARIO
        // =========================================
        private void btnModificar_Click(
            object sender, EventArgs e)
        {
            int id;

            if (!int.TryParse(txtIdUsuario.Text, out id))
            {
                MessageBox.Show(
                    "Seleccione un usuario para modificar.");
                return;
            }

            if (!ValidarCampos(false))
                return;

            try
            {
                string nombre = txtNombreUsuario.Text.Trim();

                bool cambiarContrasena =
                    !string.IsNullOrEmpty(txtContrasena.Text);

                using (SqlConnection cn = conexion.Conectar())
                {
                    cn.Open();

                    if (ExisteUsername(cn, nombre, id))
                    {
                        MessageBox.Show(
                            "Ya existe otro usuario con ese nombre.");
                        return;
                    }

                    string sql;

                    if (cambiarContrasena)
                    {
                        sql = @"
                            UPDATE Usuarios
                            SET
                                nombre_usuario = @nombre,
                                contrasena_hash = @hash,
                                id_rol = @rol,
                                estado = @estado,
                                intentos_fallidos = 0,
                                bloqueo_hasta = NULL
                            WHERE id_usuario = @id";
                    }
                    else
                    {
                        sql = @"
                            UPDATE Usuarios
                            SET
                                nombre_usuario = @nombre,
                                id_rol = @rol,
                                estado = @estado
                            WHERE id_usuario = @id";
                    }

                    using (SqlCommand cmd =
                        new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.Add(
                            "@id", SqlDbType.Int
                        ).Value = id;

                        cmd.Parameters.Add(
                            "@nombre", SqlDbType.VarChar, 50
                        ).Value = nombre;

                        cmd.Parameters.Add(
                            "@rol", SqlDbType.Int
                        ).Value =
                            Convert.ToInt32(cboRol.SelectedValue);

                        cmd.Parameters.Add(
                            "@estado", SqlDbType.VarChar, 15
                        ).Value =
                            cboEstado.SelectedItem.ToString();

                        if (cambiarContrasena)
                        {
                            string hash =
                                SeguridadPassword.CrearHash(
                                    txtContrasena.Text);

                            cmd.Parameters.Add(
                                "@hash", SqlDbType.VarChar, 255
                            ).Value = hash;
                        }

                        int filas = cmd.ExecuteNonQuery();

                        if (filas == 0)
                        {
                            MessageBox.Show(
                                "El usuario ya no existe.");
                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Usuario modificado correctamente.",
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al modificar usuario: " + ex.Message);
            }
        }

        // =========================================
        // INACTIVAR USUARIO
        // =========================================
        private void btnInactivar_Click(
            object sender, EventArgs e)
        {
            int id;

            if (!int.TryParse(txtIdUsuario.Text, out id))
            {
                MessageBox.Show(
                    "Seleccione un usuario.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de inactivar esta cuenta?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection cn = conexion.Conectar())
                {
                    cn.Open();

                    string sql = @"
                        UPDATE Usuarios
                        SET estado = 'Inactivo'
                        WHERE id_usuario = @id";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.Add(
                            "@id", SqlDbType.Int
                        ).Value = id;

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Usuario inactivado correctamente.");

                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al inactivar: " + ex.Message);
            }
        }

        // =========================================
        // BUSCAR
        // =========================================
        private void btnBuscar_Click(
            object sender, EventArgs e)
        {
            CargarUsuarios(txtBuscar.Text.Trim());
        }

        // =========================================
        // REFRESCAR
        // =========================================
        private void btnRefrescar_Click(
            object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarUsuarios();
        }

        // =========================================
        // LIMPIAR
        // =========================================
        private void btnLimpiar_Click(
            object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // =========================================
        // SELECCIONAR USUARIO
        // =========================================
        private void dgvUsuarios_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila =
                dgvUsuarios.Rows[e.RowIndex];

            if (fila.IsNewRow)
                return;

            txtIdUsuario.Text =
                Convert.ToString(
                    fila.Cells["Código"].Value);

            txtNombreUsuario.Text =
                Convert.ToString(
                    fila.Cells["Nombre de Usuario"].Value);

            // POR SEGURIDAD NO SE MUESTRA EL HASH
            txtContrasena.Clear();

            if (fila.Cells["IdRol"].Value != DBNull.Value)
            {
                cboRol.SelectedValue =
                    Convert.ToInt32(
                        fila.Cells["IdRol"].Value);
            }

            string estado = Convert.ToString(
                fila.Cells["Estado"].Value);

            if (cboEstado.Items.Contains(estado))
                cboEstado.SelectedItem = estado;
            else
                cboEstado.SelectedIndex = 0;

            btnGuardar.Enabled = false;
            btnModificar.Enabled = true;
            btnInactivar.Enabled = true;
        }

        // Evento que puede existir en el diseñador anterior
        private void dgvUsuarios_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // No requiere acciones adicionales.
        }
    }
}
