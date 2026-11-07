using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmMantenimientoDoctores : Form
    {
        private Conexion conexion = new Conexion();

        public FrmMantenimientoDoctores()
        {
            InitializeComponent();
        }

        private void FrmMantenimientoDoctores_Load(object sender, EventArgs e)
        {
            CargarComboEspecialidades();
            LimpiarCampos();
            CargarDoctores();
        }

        #region Carga de Combos y Listados

        private void CargarComboEspecialidades()
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = "SELECT id_especialidad, nombre FROM Especialidades WHERE estado = 'Activo' ORDER BY nombre ASC";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboEspecialidad.DataSource = dt;
                    cboEspecialidad.DisplayMember = "nombre";
                    cboEspecialidad.ValueMember = "id_especialidad";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de especialidades: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDoctores(string filtro = "")
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = @"SELECT d.id_doctor AS [Código], 
                                            d.nombres AS [Nombres], 
                                            d.apellidos AS [Apellidos], 
                                            e.nombre AS [Especialidad], 
                                            d.id_especialidad AS [IdEspecialidad],
                                            d.numero_junta_vigilancia AS [N° Junta], 
                                            d.telefono AS [Teléfono], 
                                            d.correo AS [Correo], 
                                            ISNULL(h.dia_semana, 'Lunes') AS [Día Horario],
                                            ISNULL(h.hora_inicio, '08:00:00') AS [Hora Inicio],
                                            ISNULL(h.hora_fin, '17:00:00') AS [Hora Fin],
                                            d.estado AS [Estado]
                                     FROM Doctores d
                                     INNER JOIN Especialidades e ON d.id_especialidad = e.id_especialidad
                                     LEFT JOIN Horarios_Doctor h ON d.id_doctor = h.id_doctor AND h.estado = 'Activo'";

                    if (!string.IsNullOrWhiteSpace(filtro))
                    {
                        query += @" WHERE d.nombres LIKE @filtro 
                                      OR d.apellidos LIKE @filtro 
                                      OR d.numero_junta_vigilancia LIKE @filtro";
                    }

                    query += " ORDER BY d.id_doctor DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(filtro))
                        {
                            cmd.Parameters.AddWithValue("@filtro", "%" + filtro.Trim() + "%");
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvDoctores.DataSource = dt;

                        if (dgvDoctores.Columns.Contains("IdEspecialidad"))
                        {
                            dgvDoctores.Columns["IdEspecialidad"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de doctores: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtIdDoctor.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            if (cboEspecialidad.Items.Count > 0) cboEspecialidad.SelectedIndex = -1;
            txtJuntaVigilancia.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            cboDiaSemana.SelectedIndex = 0; // "Lunes"

            dtpHoraInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            dtpHoraFin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);

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
            // 1. Selección obligatoria de Especialidad
            if (cboEspecialidad.SelectedIndex == -1 || cboEspecialidad.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar obligatoriamente una especialidad médica.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboEspecialidad.Focus();
                return false;
            }

            // 2. Campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("Ingrese el nombre del médico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombres.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Ingrese los apellidos del médico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidos.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtJuntaVigilancia.Text))
            {
                MessageBox.Show("Ingrese el N° de Junta de Vigilancia.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtJuntaVigilancia.Focus();
                return false;
            }

            // 3. Coherencia lógica en las horas de inicio y fin (Hora Inicio < Hora Fin)
            TimeSpan horaInicio = dtpHoraInicio.Value.TimeOfDay;
            TimeSpan horaFin = dtpHoraFin.Value.TimeOfDay;

            if (horaInicio >= horaFin)
            {
                MessageBox.Show("La hora de inicio del horario debe ser menor que la hora de fin.", "Validación de Horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpHoraInicio.Focus();
                return false;
            }

            // 4. Expresión regular en Teléfono
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

            // 5. Expresión regular en Correo
            if (!string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(txtCorreo.Text.Trim(), patronCorreo))
                {
                    MessageBox.Show("El formato del correo electrónico no es válido. Ejemplo: doctor@medicitas.com", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool ExisteJuntaVigilancia(string junta, int idExcluir = 0)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Doctores WHERE numero_junta_vigilancia = @jv AND id_doctor <> @idExcluir";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@jv", junta.Trim());
                        cmd.Parameters.AddWithValue("@idExcluir", idExcluir);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar la unicidad de la Junta de Vigilancia: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        #endregion

        #region Operaciones CRUD y Transacciones SQL

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            string junta = txtJuntaVigilancia.Text.Trim();
            if (ExisteJuntaVigilancia(junta))
            {
                MessageBox.Show("El N° de Junta de Vigilancia ingresado ya pertenece a otro médico.", "Junta Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtJuntaVigilancia.Focus();
                return;
            }

            using (SqlConnection conn = conexion.Conectar())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Guardar en Tabla Doctores
                    string queryDoctor = @"INSERT INTO Doctores 
                                          (nombres, apellidos, id_especialidad, numero_junta_vigilancia, telefono, correo, estado) 
                                          VALUES 
                                          (@nombres, @apellidos, @id_especialidad, @jv, @telefono, @correo, @estado);
                                          SELECT SCOPE_IDENTITY();";

                    int newDoctorId;
                    using (SqlCommand cmdDoc = new SqlCommand(queryDoctor, conn, transaction))
                    {
                        cmdDoc.Parameters.AddWithValue("@nombres", txtNombres.Text.Trim());
                        cmdDoc.Parameters.AddWithValue("@apellidos", txtApellidos.Text.Trim());
                        cmdDoc.Parameters.AddWithValue("@id_especialidad", Convert.ToInt32(cboEspecialidad.SelectedValue));
                        cmdDoc.Parameters.AddWithValue("@jv", junta);
                        cmdDoc.Parameters.AddWithValue("@telefono", string.IsNullOrWhiteSpace(txtTelefono.Text) ? (object)DBNull.Value : txtTelefono.Text.Trim());
                        cmdDoc.Parameters.AddWithValue("@correo", string.IsNullOrWhiteSpace(txtCorreo.Text) ? (object)DBNull.Value : txtCorreo.Text.Trim());
                        cmdDoc.Parameters.AddWithValue("@estado", cboEstado.SelectedItem.ToString());

                        newDoctorId = Convert.ToInt32(cmdDoc.ExecuteScalar());
                    }

                    // 2. Guardar Horario Base en Horarios_Doctor
                    string queryHorario = @"INSERT INTO Horarios_Doctor 
                                           (id_doctor, dia_semana, hora_inicio, hora_fin, estado) 
                                           VALUES 
                                           (@id_doctor, @dia_semana, @hora_inicio, @hora_fin, 'Activo')";

                    using (SqlCommand cmdHor = new SqlCommand(queryHorario, conn, transaction))
                    {
                        cmdHor.Parameters.AddWithValue("@id_doctor", newDoctorId);
                        cmdHor.Parameters.AddWithValue("@dia_semana", cboDiaSemana.SelectedItem.ToString());
                        cmdHor.Parameters.AddWithValue("@hora_inicio", dtpHoraInicio.Value.TimeOfDay);
                        cmdHor.Parameters.AddWithValue("@hora_fin", dtpHoraFin.Value.TimeOfDay);

                        cmdHor.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Médico registrado exitosamente con su horario de atención.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarDoctores();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al guardar el médico: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdDoctor.Text))
            {
                MessageBox.Show("Seleccione un doctor de la lista para modificar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos()) return;

            int idDoctor = Convert.ToInt32(txtIdDoctor.Text);
            string junta = txtJuntaVigilancia.Text.Trim();

            if (ExisteJuntaVigilancia(junta, idDoctor))
            {
                MessageBox.Show("El N° de Junta de Vigilancia ya pertenece a otro médico.", "Junta Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtJuntaVigilancia.Focus();
                return;
            }

            using (SqlConnection conn = conexion.Conectar())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Actualizar Tabla Doctores
                    string queryDoctor = @"UPDATE Doctores 
                                           SET nombres = @nombres, 
                                               apellidos = @apellidos, 
                                               id_especialidad = @id_especialidad, 
                                               numero_junta_vigilancia = @jv, 
                                               telefono = @telefono, 
                                               correo = @correo, 
                                               estado = @estado 
                                           WHERE id_doctor = @id_doctor";

                    using (SqlCommand cmdDoc = new SqlCommand(queryDoctor, conn, transaction))
                    {
                        cmdDoc.Parameters.AddWithValue("@id_doctor", idDoctor);
                        cmdDoc.Parameters.AddWithValue("@nombres", txtNombres.Text.Trim());
                        cmdDoc.Parameters.AddWithValue("@apellidos", txtApellidos.Text.Trim());
                        cmdDoc.Parameters.AddWithValue("@id_especialidad", Convert.ToInt32(cboEspecialidad.SelectedValue));
                        cmdDoc.Parameters.AddWithValue("@jv", junta);
                        cmdDoc.Parameters.AddWithValue("@telefono", string.IsNullOrWhiteSpace(txtTelefono.Text) ? (object)DBNull.Value : txtTelefono.Text.Trim());
                        cmdDoc.Parameters.AddWithValue("@correo", string.IsNullOrWhiteSpace(txtCorreo.Text) ? (object)DBNull.Value : txtCorreo.Text.Trim());
                        cmdDoc.Parameters.AddWithValue("@estado", cboEstado.SelectedItem.ToString());

                        cmdDoc.ExecuteNonQuery();
                    }

                    // 2. Actualizar o Insertar Horario Base en Horarios_Doctor
                    string queryHorario = @"IF EXISTS (SELECT 1 FROM Horarios_Doctor WHERE id_doctor = @id_doctor AND estado = 'Activo')
                                                UPDATE Horarios_Doctor 
                                                SET dia_semana = @dia_semana, hora_inicio = @hora_inicio, hora_fin = @hora_fin 
                                                WHERE id_doctor = @id_doctor AND estado = 'Activo'
                                            ELSE
                                                INSERT INTO Horarios_Doctor (id_doctor, dia_semana, hora_inicio, hora_fin, estado) 
                                                VALUES (@id_doctor, @dia_semana, @hora_inicio, @hora_fin, 'Activo')";

                    using (SqlCommand cmdHor = new SqlCommand(queryHorario, conn, transaction))
                    {
                        cmdHor.Parameters.AddWithValue("@id_doctor", idDoctor);
                        cmdHor.Parameters.AddWithValue("@dia_semana", cboDiaSemana.SelectedItem.ToString());
                        cmdHor.Parameters.AddWithValue("@hora_inicio", dtpHoraInicio.Value.TimeOfDay);
                        cmdHor.Parameters.AddWithValue("@hora_fin", dtpHoraFin.Value.TimeOfDay);

                        cmdHor.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Registro de médico y su horario de atención actualizados.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarDoctores();
                }
                catch (SqlException sqlex)
                {
                    transaction.Rollback();
                    // Captura de mensaje del TRIGGER 3 (trg_Doctores_NoInactivar)
                    MessageBox.Show(sqlex.Message, "Regla de Negocio / Trigger", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al actualizar el médico: " + ex.Message, "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdDoctor.Text))
            {
                MessageBox.Show("Seleccione un doctor de la lista para inactivar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idDoctor = Convert.ToInt32(txtIdDoctor.Text);
            string nombreDoctor = txtNombres.Text + " " + txtApellidos.Text;

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de inactivar al médico '{nombreDoctor}'?",
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
                        string query = "UPDATE Doctores SET estado = 'Inactivo' WHERE id_doctor = @id_doctor";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id_doctor", idDoctor);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("El doctor ha sido marcado como Inactivo.", "Registro Inactivado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarDoctores();
                }
                catch (SqlException sqlex)
                {
                    // Si el TRIGGER 3 (trg_Doctores_NoInactivar) se dispara por tener citas futuras programadas
                    MessageBox.Show(sqlex.Message, "Restricción de Negocio (Trigger)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al inactivar el doctor: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDoctores(txtBuscar.Text);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarDoctores();
        }

        #endregion

        #region Eventos de Selección de Tabla

        private void dgvDoctores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvDoctores.Rows[e.RowIndex];

                txtIdDoctor.Text = fila.Cells["Código"].Value.ToString();
                txtNombres.Text = fila.Cells["Nombres"].Value.ToString();
                txtApellidos.Text = fila.Cells["Apellidos"].Value.ToString();

                if (fila.Cells["IdEspecialidad"].Value != DBNull.Value)
                {
                    cboEspecialidad.SelectedValue = Convert.ToInt32(fila.Cells["IdEspecialidad"].Value);
                }

                txtJuntaVigilancia.Text = fila.Cells["N° Junta"].Value.ToString();
                txtTelefono.Text = fila.Cells["Teléfono"].Value != DBNull.Value ? fila.Cells["Teléfono"].Value.ToString() : "";
                txtCorreo.Text = fila.Cells["Correo"].Value != DBNull.Value ? fila.Cells["Correo"].Value.ToString() : "";

                if (fila.Cells["Día Horario"].Value != DBNull.Value)
                {
                    cboDiaSemana.SelectedItem = fila.Cells["Día Horario"].Value.ToString();
                }

                if (TimeSpan.TryParse(fila.Cells["Hora Inicio"].Value.ToString(), out TimeSpan hInicio))
                {
                    dtpHoraInicio.Value = DateTime.Today.Add(hInicio);
                }

                if (TimeSpan.TryParse(fila.Cells["Hora Fin"].Value.ToString(), out TimeSpan hFin))
                {
                    dtpHoraFin.Value = DateTime.Today.Add(hFin);
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
