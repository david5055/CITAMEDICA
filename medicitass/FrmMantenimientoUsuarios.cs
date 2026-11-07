using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmMantenimientoUsuarios : Form
    {
        private Conexion conexion = new Conexion();

        public FrmMantenimientoUsuarios()
        {
            InitializeComponent();
        }

        private void FrmMantenimientoUsuarios_Load(object sender, EventArgs e)
        {
            CargarComboRoles();
            LimpiarCampos();
            CargarUsuarios();
        }

        #region Carga de Datos y Limpieza

        private void CargarComboRoles()
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = "SELECT id_rol, nombre_rol FROM Roles ORDER BY id_rol ASC";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboRol.DataSource = dt;
                    cboRol.DisplayMember = "nombre_rol";
                    cboRol.ValueMember = "id_rol";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de roles: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUsuarios(string filtro = "")
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = @"SELECT u.id_usuario AS [Código], 
                                            u.nombre_usuario AS [Nombre de Usuario], 
                                            r.nombre_rol AS [Rol], 
                                            u.id_rol AS [IdRol], 
                                            u.estado AS [Estado], 
                                            ISNULL(u.intentos_fallidos, 0) AS [Intentos Fallidos]
                                     FROM Usuarios u
                                     INNER JOIN Roles r ON u.id_rol = r.id_rol";

                    if (!string.IsNullOrWhiteSpace(filtro))
                    {
                        query += " WHERE u.nombre_usuario LIKE @filtro OR r.nombre_rol LIKE @filtro";
                    }

                    query += " ORDER BY u.id_usuario DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(filtro))
                        {
                            cmd.Parameters.AddWithValue("@filtro", "%" + filtro.Trim() + "%");
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvUsuarios.DataSource = dt;

                        if (dgvUsuarios.Columns.Contains("IdRol"))
                        {
                            dgvUsuarios.Columns["IdRol"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de usuarios: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtIdUsuario.Clear();
            txtNombreUsuario.Clear();
            txtContrasena.Clear();
            if (cboRol.Items.Count > 0) cboRol.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0; // "Activo"

            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnInactivar.Enabled = false;

            txtNombreUsuario.Focus();
        }

        #endregion

        #region Utilidades de Seguridad (Hash SHA-256)

        private string HashPassword(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        #endregion

        #region Validaciones de Negocio

        private bool ValidarCampos(bool esNuevo)
        {
            // 1. Nombre de Usuario obligatorio
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("Ingrese el nombre de usuario (username).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return false;
            }

            // 2. Rol obligatorio
            if (cboRol.SelectedIndex == -1 || cboRol.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un rol para el usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRol.Focus();
                return false;
            }

            // 3. Validación de Contraseña (Longitud Mínima 8 Caracteres)
            if (esNuevo)
            {
                if (string.IsNullOrWhiteSpace(txtContrasena.Text))
                {
                    MessageBox.Show("Debe ingresar una contraseña para el nuevo usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContrasena.Focus();
                    return false;
                }

                if (txtContrasena.Text.Length < 8)
                {
                    MessageBox.Show("La contraseña debe tener una longitud mínima de 8 caracteres.", "Seguridad de Clave", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContrasena.Focus();
                    return false;
                }
            }
            else
            {
                // Si se escribe una nueva clave en modificación, debe cumplir la regla de 8 caracteres
                if (!string.IsNullOrWhiteSpace(txtContrasena.Text) && txtContrasena.Text.Length < 8)
                {
                    MessageBox.Show("La nueva contraseña debe tener una longitud mínima de 8 caracteres.", "Seguridad de Clave", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContrasena.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool ExisteUsername(string username, int idExcluir = 0)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE nombre_usuario = @username AND id_usuario <> @idExcluir";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username.Trim());
                        cmd.Parameters.AddWithValue("@idExcluir", idExcluir);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar la unicidad del nombre de usuario: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        #endregion

        #region Operaciones CRUD

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(esNuevo: true)) return;

            string username = txtNombreUsuario.Text.Trim();
            if (ExisteUsername(username))
            {
                MessageBox.Show("El nombre de usuario (username) ya está registrado en la plataforma.", "Username Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return;
            }

            try
            {
                string contrasenaHash = HashPassword(txtContrasena.Text);

                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"INSERT INTO Usuarios 
                                    (nombre_usuario, contrasena_hash, id_rol, estado, intentos_fallidos) 
                                    VALUES 
                                    (@nombre_usuario, @contrasena_hash, @id_rol, @estado, 0)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre_usuario", username);
                        cmd.Parameters.AddWithValue("@contrasena_hash", contrasenaHash);
                        cmd.Parameters.AddWithValue("@id_rol", Convert.ToInt32(cboRol.SelectedValue));
                        cmd.Parameters.AddWithValue("@estado", cboEstado.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdUsuario.Text))
            {
                MessageBox.Show("Seleccione un usuario de la lista para modificar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos(esNuevo: false)) return;

            int idUsuario = Convert.ToInt32(txtIdUsuario.Text);
            string username = txtNombreUsuario.Text.Trim();

            if (ExisteUsername(username, idUsuario))
            {
                MessageBox.Show("El nombre de usuario (username) ya pertenece a otro registro.", "Username Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();

                    string query;
                    if (!string.IsNullOrWhiteSpace(txtContrasena.Text))
                    {
                        // Si ingresó una nueva contraseña, actualizamos el hash y reseteamos el bloqueo por intentos fallidos
                        query = @"UPDATE Usuarios 
                                  SET nombre_usuario = @nombre_usuario, 
                                      contrasena_hash = @contrasena_hash, 
                                      id_rol = @id_rol, 
                                      estado = @estado, 
                                      intentos_fallidos = 0, 
                                      bloqueo_hasta = NULL 
                                  WHERE id_usuario = @id_usuario";
                    }
                    else
                    {
                        // Si se dejó en blanco, se conserva la contraseña anterior
                        query = @"UPDATE Usuarios 
                                  SET nombre_usuario = @nombre_usuario, 
                                      id_rol = @id_rol, 
                                      estado = @estado 
                                  WHERE id_usuario = @id_usuario";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                        cmd.Parameters.AddWithValue("@nombre_usuario", username);
                        cmd.Parameters.AddWithValue("@id_rol", Convert.ToInt32(cboRol.SelectedValue));
                        cmd.Parameters.AddWithValue("@estado", cboEstado.SelectedItem.ToString());

                        if (!string.IsNullOrWhiteSpace(txtContrasena.Text))
                        {
                            cmd.Parameters.AddWithValue("@contrasena_hash", HashPassword(txtContrasena.Text));
                        }

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cuenta de usuario actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la cuenta de usuario: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdUsuario.Text))
            {
                MessageBox.Show("Seleccione un usuario de la lista para inactivar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUsuario = Convert.ToInt32(txtIdUsuario.Text);
            string username = txtNombreUsuario.Text;

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de inactivar la cuenta de usuario '{username}'?",
                "Confirmar Inactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = conexion.Conectar())
                    {
                        conn.Open();
                        string query = "UPDATE Usuarios SET estado = 'Inactivo' WHERE id_usuario = @id_usuario";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("La cuenta de usuario ha sido marcada como Inactiva.", "Registro Inactivado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al inactivar el usuario: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarUsuarios(txtBuscar.Text);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarUsuarios();
        }

        #endregion

        #region Eventos de Selección de Tabla

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

                txtIdUsuario.Text = fila.Cells["Código"].Value.ToString();
                txtNombreUsuario.Text = fila.Cells["Nombre de Usuario"].Value.ToString();
                txtContrasena.Clear(); // No se muestra el hash de la clave por seguridad

                if (fila.Cells["IdRol"].Value != DBNull.Value)
                {
                    cboRol.SelectedValue = Convert.ToInt32(fila.Cells["IdRol"].Value);
                }

                cboEstado.SelectedItem = fila.Cells["Estado"].Value.ToString();

                btnGuardar.Enabled = false;
                btnModificar.Enabled = true;
                btnInactivar.Enabled = true;
            }
        }

        #endregion
    }
}
