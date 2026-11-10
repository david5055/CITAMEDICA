using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmMantenimientoEspecialidad : Form
    {
        private Conexion conexion = new Conexion();

        public FrmMantenimientoEspecialidad()
        {
            InitializeComponent();
        }

        private void FrmMantenimientoEspecialidades_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
            CargarEspecialidades();
        }

        #region Métodos de Carga y Limpieza

        private void CargarEspecialidades(string filtro = "")
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = @"SELECT id_especialidad AS [Código], 
                                            nombre AS [Especialidad], 
                                            descripcion AS [Descripción], 
                                            estado AS [Estado]
                                     FROM Especialidades";

                    if (!string.IsNullOrWhiteSpace(filtro))
                    {
                        query += " WHERE nombre LIKE @filtro OR descripcion LIKE @filtro";
                    }

                    query += " ORDER BY id_especialidad DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(filtro))
                        {
                            cmd.Parameters.AddWithValue("@filtro", "%" + filtro.Trim() + "%");
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvEspecialidades.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de especialidades: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtIdEspecialidad.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            cboEstado.SelectedIndex = 0; // "Activo"

            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnInactivar.Enabled = false;

            txtNombre.Focus();
        }

        #endregion

        #region Validaciones de Negocio

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre de la especialidad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            return true;
        }

        private bool ExisteNombreEspecialidad(string nombre, int idExcluir = 0)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Especialidades WHERE nombre = @nombre AND id_especialidad <> @idExcluir";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre.Trim());
                        cmd.Parameters.AddWithValue("@idExcluir", idExcluir);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar la unicidad de la especialidad: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private bool TieneDoctoresActivos(int idEspecialidad)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Doctores WHERE id_especialidad = @id_especialidad AND estado = 'Activo'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_especialidad", idEspecialidad);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar doctores asociados: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        #endregion

        #region Operaciones CRUD

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            string nombre = txtNombre.Text.Trim();
            if (ExisteNombreEspecialidad(nombre))
            {
                MessageBox.Show("La especialidad ingresada ya se encuentra registrada en el sistema.", "Especialidad Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"INSERT INTO Especialidades (nombre, descripcion, estado) 
                                     VALUES (@nombre, @descripcion, @estado)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@descripcion", string.IsNullOrWhiteSpace(txtDescripcion.Text) ? (object)DBNull.Value : txtDescripcion.Text.Trim());
                        cmd.Parameters.AddWithValue("@estado", cboEstado.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Especialidad médica registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarEspecialidades();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la especialidad: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdEspecialidad.Text))
            {
                MessageBox.Show("Seleccione una especialidad de la lista para modificar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos()) return;

            int idEspecialidad = Convert.ToInt32(txtIdEspecialidad.Text);
            string nombre = txtNombre.Text.Trim();
            string nuevoEstado = cboEstado.SelectedItem.ToString();

            if (ExisteNombreEspecialidad(nombre, idEspecialidad))
            {
                MessageBox.Show("El nombre de la especialidad ya pertenece a otro registro.", "Nombre Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            // Validación de Negocio / Trigger: Prohibición de inactivar si hay doctores activos
            if (nuevoEstado == "Inactivo" && TieneDoctoresActivos(idEspecialidad))
            {
                MessageBox.Show("No se puede inactivar esta especialidad porque actualmente existen doctores activos vinculados a ella.", "Inactivación Denegada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cboEstado.SelectedItem = "Activo";
                return;
            }

            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"UPDATE Especialidades 
                                     SET nombre = @nombre, 
                                         descripcion = @descripcion, 
                                         estado = @estado 
                                     WHERE id_especialidad = @id_especialidad";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_especialidad", idEspecialidad);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@descripcion", string.IsNullOrWhiteSpace(txtDescripcion.Text) ? (object)DBNull.Value : txtDescripcion.Text.Trim());
                        cmd.Parameters.AddWithValue("@estado", nuevoEstado);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Especialidad actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarEspecialidades();
            }
            catch (SqlException sqlex)
            {
                // Captura por si el Trigger 2 (trg_Especialidades_NoInactivar) rechaza la operación
                MessageBox.Show(sqlex.Message, "Regla de Negocio (Trigger SQL)", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la especialidad: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdEspecialidad.Text))
            {
                MessageBox.Show("Seleccione una especialidad de la lista para inactivar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEspecialidad = Convert.ToInt32(txtIdEspecialidad.Text);
            string nombreEspecialidad = txtNombre.Text;

            // Verificación previa en C#
            if (TieneDoctoresActivos(idEspecialidad))
            {
                MessageBox.Show($"No es posible inactivar la especialidad '{nombreEspecialidad}' porque tiene doctores activos asociados.", "Inactivación Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de inactivar la especialidad '{nombreEspecialidad}'?",
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
                        string query = "UPDATE Especialidades SET estado = 'Inactivo' WHERE id_especialidad = @id_especialidad";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id_especialidad", idEspecialidad);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("La especialidad ha sido marcada como Inactiva.", "Registro Inactivado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarEspecialidades();
                }
                catch (SqlException sqlex)
                {
                    // Manejo del TRIGGER 2 (trg_Especialidades_NoInactivar) de SQL Server
                    MessageBox.Show(sqlex.Message, "Restricción de Negocio (Trigger SQL)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al inactivar la especialidad: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarEspecialidades(txtBuscar.Text);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarEspecialidades();
        }

        #endregion

        #region Eventos de Selección de Tabla

        private void dgvEspecialidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvEspecialidades.Rows[e.RowIndex];

                txtIdEspecialidad.Text = fila.Cells["Código"].Value.ToString();
                txtNombre.Text = fila.Cells["Especialidad"].Value.ToString();
                txtDescripcion.Text = fila.Cells["Descripción"].Value != DBNull.Value ? fila.Cells["Descripción"].Value.ToString() : "";
                cboEstado.SelectedItem = fila.Cells["Estado"].Value.ToString();

                btnGuardar.Enabled = false;
                btnModificar.Enabled = true;
                btnInactivar.Enabled = true;
            }
        }

        #endregion
    }
}
