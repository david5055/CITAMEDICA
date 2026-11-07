using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmMantenimientoPacientes : Form
    {
        private Conexion conexion = new Conexion();

        public FrmMantenimientoPacientes()
        {
            InitializeComponent();
        }

        private void FrmMantenimientoPacientes_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
            CargarPacientes();
        }

        #region Métodos de Carga y Limpieza

        private void CargarPacientes(string filtro = "")
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = @"SELECT id_paciente AS [Código], 
                                            nombres AS [Nombres], 
                                            apellidos AS [Apellidos], 
                                            dui AS [DUI / Doc], 
                                            fecha_nacimiento AS [F. Nacimiento], 
                                            sexo AS [Sexo], 
                                            telefono AS [Teléfono], 
                                            correo AS [Correo], 
                                            direccion AS [Dirección], 
                                            estado AS [Estado]
                                     FROM Pacientes";

                    if (!string.IsNullOrWhiteSpace(filtro))
                    {
                        query += @" WHERE nombres LIKE @filtro 
                                      OR apellidos LIKE @filtro 
                                      OR dui LIKE @filtro";
                    }

                    query += " ORDER BY id_paciente DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(filtro))
                        {
                            cmd.Parameters.AddWithValue("@filtro", "%" + filtro.Trim() + "%");
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvPacientes.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de pacientes: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtIdPaciente.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtDui.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
            cboSexo.SelectedIndex = 0;
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            cboEstado.SelectedIndex = 0; // "Activo"

            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnInactivar.Enabled = false;

            txtNombres.Focus();
        }

        #endregion

        #region Validaciones de Negocio

        private bool ValidarCampos()
        {
            // 1. Campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("Ingrese el nombre del paciente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombres.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Ingrese los apellidos del paciente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidos.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDui.Text))
            {
                MessageBox.Show("Ingrese el DUI / Documento del paciente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDui.Focus();
                return false;
            }

            // 2. Validación de Fecha de Nacimiento (menor o igual a la fecha actual)
            if (dtpFechaNacimiento.Value.Date > DateTime.Today)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser mayor a la fecha actual.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFechaNacimiento.Focus();
                return false;
            }

            // 3. Validación de Teléfono con Expresión Regular (Regex) - Formato 8 dígitos o con guion (ej: 7000-0000 o 70000000)
            if (!string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                string patronTelefono = @"^\d{4}-?\d{4}$";
                if (!Regex.IsMatch(txtTelefono.Text.Trim(), patronTelefono))
                {
                    MessageBox.Show("El formato del número de teléfono no es válido. Ejemplo: 7777-7777 o 77777777", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefono.Focus();
                    return false;
                }
            }

            // 4. Validación de Correo Electrónico con Expresión Regular (Regex)
            if (!string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(txtCorreo.Text.Trim(), patronCorreo))
                {
                    MessageBox.Show("El formato del correo electrónico no es válido. Ejemplo: usuario@dominio.com", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool ExisteDui(string dui, int idExcluir = 0)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Pacientes WHERE dui = @dui AND id_paciente <> @idExcluir";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@dui", dui.Trim());
                        cmd.Parameters.AddWithValue("@idExcluir", idExcluir);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar la unicidad del DUI: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Ante error, prevenimos duplicado
            }
        }

        #endregion

        #region Eventos de Botones y Operaciones CRUD

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            string dui = txtDui.Text.Trim();
            if (ExisteDui(dui))
            {
                MessageBox.Show("El DUI / Documento ingresado ya se encuentra registrado con otro paciente.", "DUI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDui.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"INSERT INTO Pacientes 
                                    (nombres, apellidos, dui, fecha_nacimiento, sexo, telefono, correo, direccion, estado) 
                                    VALUES 
                                    (@nombres, @apellidos, @dui, @fecha_nacimiento, @sexo, @telefono, @correo, @direccion, @estado)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombres", txtNombres.Text.Trim());
                        cmd.Parameters.AddWithValue("@apellidos", txtApellidos.Text.Trim());
                        cmd.Parameters.AddWithValue("@dui", dui);
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", dtpFechaNacimiento.Value.Date);
                        cmd.Parameters.AddWithValue("@sexo", cboSexo.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@telefono", string.IsNullOrWhiteSpace(txtTelefono.Text) ? (object)DBNull.Value : txtTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@correo", string.IsNullOrWhiteSpace(txtCorreo.Text) ? (object)DBNull.Value : txtCorreo.Text.Trim());
                        cmd.Parameters.AddWithValue("@direccion", string.IsNullOrWhiteSpace(txtDireccion.Text) ? (object)DBNull.Value : txtDireccion.Text.Trim());
                        cmd.Parameters.AddWithValue("@estado", cboEstado.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Paciente registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarPacientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el paciente: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdPaciente.Text))
            {
                MessageBox.Show("Seleccione un paciente de la lista para modificar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos()) return;

            int idPaciente = Convert.ToInt32(txtIdPaciente.Text);
            string dui = txtDui.Text.Trim();

            if (ExisteDui(dui, idPaciente))
            {
                MessageBox.Show("El DUI / Documento ya pertenece a otro paciente registrado.", "DUI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDui.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"UPDATE Pacientes 
                                     SET nombres = @nombres, 
                                         apellidos = @apellidos, 
                                         dui = @dui, 
                                         fecha_nacimiento = @fecha_nacimiento, 
                                         sexo = @sexo, 
                                         telefono = @telefono, 
                                         correo = @correo, 
                                         direccion = @direccion, 
                                         estado = @estado 
                                     WHERE id_paciente = @id_paciente";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_paciente", idPaciente);
                        cmd.Parameters.AddWithValue("@nombres", txtNombres.Text.Trim());
                        cmd.Parameters.AddWithValue("@apellidos", txtApellidos.Text.Trim());
                        cmd.Parameters.AddWithValue("@dui", dui);
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", dtpFechaNacimiento.Value.Date);
                        cmd.Parameters.AddWithValue("@sexo", cboSexo.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@telefono", string.IsNullOrWhiteSpace(txtTelefono.Text) ? (object)DBNull.Value : txtTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@correo", string.IsNullOrWhiteSpace(txtCorreo.Text) ? (object)DBNull.Value : txtCorreo.Text.Trim());
                        cmd.Parameters.AddWithValue("@direccion", string.IsNullOrWhiteSpace(txtDireccion.Text) ? (object)DBNull.Value : txtDireccion.Text.Trim());
                        cmd.Parameters.AddWithValue("@estado", cboEstado.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Expediente de paciente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarPacientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el expediente del paciente: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdPaciente.Text))
            {
                MessageBox.Show("Seleccione un paciente de la lista para inactivar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPaciente = Convert.ToInt32(txtIdPaciente.Text);
            string nombrePaciente = txtNombres.Text + " " + txtApellidos.Text;

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de inactivar (borrado lógico) el expediente del paciente '{nombrePaciente}'?",
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
                        string query = "UPDATE Pacientes SET estado = 'Inactivo' WHERE id_paciente = @id_paciente";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id_paciente", idPaciente);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("El expediente del paciente ha sido marcado como Inactivo.", "Registro Inactivado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarPacientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al inactivar el paciente: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarPacientes(txtBuscar.Text);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarPacientes();
        }

        #endregion

        #region Eventos de Selección de Tabla

        private void dgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvPacientes.Rows[e.RowIndex];

                txtIdPaciente.Text = fila.Cells["Código"].Value.ToString();
                txtNombres.Text = fila.Cells["Nombres"].Value.ToString();
                txtApellidos.Text = fila.Cells["Apellidos"].Value.ToString();
                txtDui.Text = fila.Cells["DUI / Doc"].Value.ToString();

                if (DateTime.TryParse(fila.Cells["F. Nacimiento"].Value.ToString(), out DateTime fecha))
                {
                    dtpFechaNacimiento.Value = fecha;
                }

                cboSexo.SelectedItem = fila.Cells["Sexo"].Value.ToString();
                txtTelefono.Text = fila.Cells["Teléfono"].Value != DBNull.Value ? fila.Cells["Teléfono"].Value.ToString() : "";
                txtCorreo.Text = fila.Cells["Correo"].Value != DBNull.Value ? fila.Cells["Correo"].Value.ToString() : "";
                txtDireccion.Text = fila.Cells["Dirección"].Value != DBNull.Value ? fila.Cells["Dirección"].Value.ToString() : "";
                cboEstado.SelectedItem = fila.Cells["Estado"].Value.ToString();

                btnGuardar.Enabled = false;
                btnModificar.Enabled = true;
                btnInactivar.Enabled = true;
            }
        }

        #endregion
    }
}