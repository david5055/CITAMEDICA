
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmMantenimientoRoles : Form
    {
        private int idSeleccionado = 0;

        public FrmMantenimientoRoles()
        {
            InitializeComponent();
        }

        // CARGAR FORMULARIO
        private void FrmMantenimientoRoles_Load(
            object sender, EventArgs e)
        {
            CargarRoles();
            LimpiarCampos();
        }

        // MOSTRAR ROLES
        private void CargarRoles(string buscar = "")
        {
            try
            {
                using (SqlConnection cn =
                    new Conexion().Conectar())
                {
                    string sql = @"
                        SELECT
                            id_rol AS Codigo,
                            nombre_rol AS Nombre,
                            descripcion AS Descripcion
                        FROM Roles
                        WHERE nombre_rol LIKE @buscar
                        ORDER BY id_rol";

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(sql, cn))
                    {
                        da.SelectCommand.Parameters.Add(
                            "@buscar", SqlDbType.VarChar, 100
                        ).Value = "%" + buscar + "%";

                        DataTable tabla = new DataTable();
                        da.Fill(tabla);

                        dgvRoles.DataSource = tabla;

                        lblTotal.Text =
                            "Total de roles: " +
                            tabla.Rows.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar roles: " + ex.Message,
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // VALIDAR CAMPOS
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(
                txtNombreRol.Text))
            {
                MessageBox.Show(
                    "Ingrese el nombre del rol.");
                txtNombreRol.Focus();
                return false;
            }

            if (txtNombreRol.Text.Trim().Length > 30)
            {
                MessageBox.Show(
                    "El nombre no debe superar 30 caracteres.");
                return false;
            }

            if (txtDescripcion.Text.Trim().Length > 255)
            {
                MessageBox.Show(
                    "La descripción no debe superar 255 caracteres.");
                return false;
            }

            return true;
        }

        // COMPROBAR NOMBRE DUPLICADO
        private bool ExisteNombre(
            SqlConnection cn, string nombre, int excluirId)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM Roles
                WHERE nombre_rol = @nombre
                  AND id_rol <> @id";

            using (SqlCommand cmd =
                new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add(
                    "@nombre", SqlDbType.VarChar, 30
                ).Value = nombre;

                cmd.Parameters.Add(
                    "@id", SqlDbType.Int
                ).Value = excluirId;

                return Convert.ToInt32(
                    cmd.ExecuteScalar()) > 0;
            }
        }

        // AGREGAR ROL
        private void btnAgregar_Click(
            object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                using (SqlConnection cn =
                    new Conexion().Conectar())
                {
                    cn.Open();

                    if (ExisteNombre(
                        cn, txtNombreRol.Text.Trim(), 0))
                    {
                        MessageBox.Show(
                            "Ya existe un rol con ese nombre.");
                        return;
                    }

                    string sql = @"
                        INSERT INTO Roles
                        (nombre_rol, descripcion)
                        VALUES (@nombre, @descripcion)";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.Add(
                            "@nombre", SqlDbType.VarChar, 30
                        ).Value = txtNombreRol.Text.Trim();

                        cmd.Parameters.Add(
                            "@descripcion",
                            SqlDbType.VarChar, 255
                        ).Value = txtDescripcion.Text.Trim();

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Rol registrado correctamente.",
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarRoles();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar: " + ex.Message);
            }
        }

        // MODIFICAR ROL
        private void btnModificar_Click(
            object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show(
                    "Seleccione un rol de la tabla.");
                return;
            }

            if (!ValidarCampos())
                return;

            try
            {
                int filas;

                using (SqlConnection cn =
                    new Conexion().Conectar())
                {
                    cn.Open();

                    if (ExisteNombre(
                        cn,
                        txtNombreRol.Text.Trim(),
                        idSeleccionado))
                    {
                        MessageBox.Show(
                            "Ya existe otro rol con ese nombre.");
                        return;
                    }

                    string sql = @"
                        UPDATE Roles
                        SET nombre_rol = @nombre,
                            descripcion = @descripcion
                        WHERE id_rol = @id";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.Add(
                            "@nombre", SqlDbType.VarChar, 30
                        ).Value = txtNombreRol.Text.Trim();

                        cmd.Parameters.Add(
                            "@descripcion", SqlDbType.VarChar, 255
                        ).Value = txtDescripcion.Text.Trim();

                        cmd.Parameters.Add(
                            "@id", SqlDbType.Int
                        ).Value = idSeleccionado;

                        filas = cmd.ExecuteNonQuery();
                    }
                }

                if (filas == 0)
                {
                    MessageBox.Show(
                        "El rol ya no existe.");
                    return;
                }

                MessageBox.Show(
                    "Rol modificado correctamente.");

                CargarRoles();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al modificar: " + ex.Message);
            }
        }

        // ELIMINAR ROL
        private void btnEliminar_Click(
            object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show(
                    "Seleccione un rol para eliminar.");
                return;
            }

            DialogResult respuesta =
                MessageBox.Show(
                    "¿Está seguro de eliminar este rol?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection cn =
                    new Conexion().Conectar())
                {
                    cn.Open();

                    // Comprobar usuarios asociados
                    string verificar = @"
                        SELECT COUNT(*)
                        FROM Usuarios
                        WHERE id_rol = @id";

                    using (SqlCommand cmd =
                        new SqlCommand(verificar, cn))
                    {
                        cmd.Parameters.Add(
                            "@id", SqlDbType.Int
                        ).Value = idSeleccionado;

                        int asociados = Convert.ToInt32(
                            cmd.ExecuteScalar());

                        if (asociados > 0)
                        {
                            MessageBox.Show(
                                "No se puede eliminar este rol " +
                                "porque tiene usuarios asociados.",
                                "Operación no permitida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string sql =
                        "DELETE FROM Roles WHERE id_rol = @id";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.Add(
                            "@id", SqlDbType.Int
                        ).Value = idSeleccionado;

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Rol eliminado correctamente.");

                CargarRoles();
                LimpiarCampos();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show(
                        "No se puede eliminar el rol " +
                        "porque está relacionado con otros registros.");
                }
                else
                {
                    MessageBox.Show(
                        "Error de SQL Server: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar: " + ex.Message);
            }
        }

        // BUSCAR ROL
        private void btnBuscar_Click(
            object sender, EventArgs e)
        {
            CargarRoles(txtBuscar.Text.Trim());
        }

        // MOSTRAR TODOS
        private void btnMostrarTodos_Click(
            object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarRoles();
        }

        // LIMPIAR
        private void btnLimpiar_Click(
            object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            idSeleccionado = 0;

            txtCodigo.Text = "Automático";
            txtNombreRol.Clear();
            txtDescripcion.Clear();

            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            dgvRoles.ClearSelection();
        }

        // SELECCIONAR REGISTRO DE LA TABLA
        private void dgvRoles_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila =
                dgvRoles.Rows[e.RowIndex];

            if (fila.IsNewRow)
                return;

            idSeleccionado = Convert.ToInt32(
                fila.Cells["Codigo"].Value);

            txtCodigo.Text =
                idSeleccionado.ToString();

            txtNombreRol.Text =
                Convert.ToString(
                    fila.Cells["Nombre"].Value);

            txtDescripcion.Text =
                Convert.ToString(
                    fila.Cells["Descripcion"].Value);

            btnAgregar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        // SALIR
        private void btnCerrar_Click(
            object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
