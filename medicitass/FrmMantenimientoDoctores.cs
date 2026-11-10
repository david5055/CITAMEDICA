
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmMantenimientoDoctores : Form
    {
        private readonly Conexion conexion = new Conexion();
        private int idSeleccionado = 0;

        private readonly string[] diasSemana =
        {
            "Lunes", "Martes", "Miercoles",
            "Jueves", "Viernes", "Sabado", "Domingo"
        };

        public FrmMantenimientoDoctores()
        {
            InitializeComponent();
        }

        private void FrmMantenimientoDoctores_Load(
            object sender, EventArgs e)
        {
            try
            {
                ConfigurarDias();
                CargarEspecialidades();
                CargarDoctores();
                Limpiar();
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private void ConfigurarDias()
        {
            clbDias.Items.Clear();

            foreach (string dia in diasSemana)
                clbDias.Items.Add(dia);
        }

        private void CargarEspecialidades()
        {
            const string sql = @"
                SELECT id_especialidad, nombre
                FROM dbo.Especialidades
                ORDER BY nombre";

            using (SqlConnection cn = conexion.Conectar())
            using (SqlDataAdapter da =
                new SqlDataAdapter(sql, cn))
            {
                DataTable tabla = new DataTable();
                da.Fill(tabla);

                cboEspecialidad.DisplayMember = "nombre";
                cboEspecialidad.ValueMember = "id_especialidad";
                cboEspecialidad.DataSource = tabla;
                cboEspecialidad.SelectedIndex = -1;
            }
        }

        // =====================================
        // LISTADO DE DOCTORES Y JORNADAS
        // =====================================
        private void CargarDoctores(string buscar = "")
        {
            const string sql = @"
                SELECT
                    d.id_doctor AS [Código],
                    d.nombres AS [Nombres],
                    d.apellidos AS [Apellidos],
                    d.id_especialidad AS [IdEspecialidad],
                    e.nombre AS [Especialidad],
                    d.numero_junta_vigilancia AS [N° Junta],
                    d.telefono AS [Teléfono],
                    d.correo AS [Correo],
                    h.dia_semana AS [Día horario],
                    h.hora_inicio AS [Hora inicio],
                    h.hora_fin AS [Hora fin],
                    ISNULL(d.estado, '') AS [Estado]
                FROM dbo.Doctores d
                INNER JOIN dbo.Especialidades e
                    ON d.id_especialidad = e.id_especialidad
                LEFT JOIN dbo.Horarios_Doctor h
                    ON d.id_doctor = h.id_doctor
                   AND h.estado = 'Activo'
                WHERE
                    @Buscar = ''
                    OR d.nombres LIKE '%' + @Buscar + '%'
                    OR d.apellidos LIKE '%' + @Buscar + '%'
                    OR d.numero_junta_vigilancia
                        LIKE '%' + @Buscar + '%'
                ORDER BY
                    d.id_doctor DESC,
                    h.hora_inicio,
                    h.dia_semana";

            using (SqlConnection cn = conexion.Conectar())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add(
                    "@Buscar", SqlDbType.VarChar, 100
                ).Value = buscar;

                using (SqlDataAdapter da =
                    new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);
                    dgvDoctores.DataSource = tabla;
                }
            }

            if (dgvDoctores.Columns.Contains("IdEspecialidad"))
                dgvDoctores.Columns["IdEspecialidad"].Visible = false;

            dgvDoctores.ClearSelection();
        }

        private HashSet<string> DiasMarcados()
        {
            HashSet<string> seleccionados =
                new HashSet<string>(
                    StringComparer.OrdinalIgnoreCase);

            foreach (object item in clbDias.CheckedItems)
                seleccionados.Add(item.ToString());

            return seleccionados;
        }

        private string NormalizarDia(string dia)
        {
            return (dia ?? "")
                .Trim()
                .Replace("á", "a")
                .Replace("é", "e")
                .Replace("Á", "A")
                .Replace("É", "E");
        }

        private string DiaDeFecha(DateTime fecha)
        {
            return diasSemana[
                ((int)fecha.DayOfWeek + 6) % 7];
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show(
                    "Ingrese nombres y apellidos.");
                return false;
            }

            if (txtNombres.Text.Trim().Length > 100 ||
                txtApellidos.Text.Trim().Length > 100 ||
                txtJunta.Text.Trim().Length > 30 ||
                txtTelefono.Text.Trim().Length > 15 ||
                txtCorreo.Text.Trim().Length > 100)
            {
                MessageBox.Show(
                    "Uno de los campos supera " +
                    "su longitud permitida.");
                return false;
            }

            if (cboEspecialidad.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Seleccione una especialidad.");
                return false;
            }

            if (clbDias.CheckedItems.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione al menos un día de atención.");
                return false;
            }

            if (dtpHoraFin.Value.TimeOfDay <=
                dtpHoraInicio.Value.TimeOfDay)
            {
                MessageBox.Show(
                    "La hora final debe ser mayor " +
                    "que la hora inicial.");
                return false;
            }

            return true;
        }

        // =====================================
        // INSERTAR HORARIOS SELECCIONADOS
        // =====================================
        private void InsertarHorarios(
            SqlConnection cn,
            SqlTransaction tx,
            int idDoctor)
        {
            const string sql = @"
                INSERT INTO dbo.Horarios_Doctor
                (
                    id_doctor, dia_semana,
                    hora_inicio, hora_fin, estado
                )
                VALUES
                (
                    @Doctor, @Dia,
                    @Inicio, @Fin, 'Activo'
                )";

            foreach (string dia in DiasMarcados())
            {
                using (SqlCommand cmd =
                    new SqlCommand(sql, cn, tx))
                {
                    cmd.Parameters.Add(
                        "@Doctor", SqlDbType.Int
                    ).Value = idDoctor;

                    cmd.Parameters.Add(
                        "@Dia", SqlDbType.VarChar, 15
                    ).Value = dia;

                    cmd.Parameters.Add(
                        "@Inicio", SqlDbType.Time
                    ).Value = dtpHoraInicio.Value.TimeOfDay;

                    cmd.Parameters.Add(
                        "@Fin", SqlDbType.Time
                    ).Value = dtpHoraFin.Value.TimeOfDay;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // =====================================
        // REVISAR CITAS FUTURAS AL CAMBIAR JORNADA
        // =====================================
        private void ValidarCitasFuturas(
            SqlConnection cn,
            SqlTransaction tx,
            int idDoctor)
        {
            const string sql = @"
                SELECT fecha, hora_inicio, hora_fin
                FROM dbo.Citas WITH (UPDLOCK, HOLDLOCK)
                WHERE id_doctor = @Doctor
                  AND estado = 'Programada'
                  AND fecha >= CAST(GETDATE() AS DATE)";

            HashSet<string> dias = DiasMarcados();
            TimeSpan inicio = dtpHoraInicio.Value.TimeOfDay;
            TimeSpan fin = dtpHoraFin.Value.TimeOfDay;

            using (SqlCommand cmd =
                new SqlCommand(sql, cn, tx))
            {
                cmd.Parameters.Add(
                    "@Doctor", SqlDbType.Int
                ).Value = idDoctor;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DateTime fecha =
                            Convert.ToDateTime(dr["fecha"]);

                        TimeSpan citaInicio =
                            (TimeSpan)dr["hora_inicio"];

                        TimeSpan citaFin =
                            (TimeSpan)dr["hora_fin"];

                        string dia = DiaDeFecha(fecha);

                        if (!dias.Contains(dia) ||
                            citaInicio < inicio ||
                            citaFin > fin)
                        {
                            throw new InvalidOperationException(
                                "No puede modificar la jornada " +
                                "porque hay citas futuras fuera " +
                                "del nuevo horario. Revise la " +
                                "fecha " +
                                fecha.ToString("dd/MM/yyyy") +
                                " antes de guardar.");
                        }
                    }
                }
            }
        }

        // =====================================
        // GUARDAR DOCTOR
        // =====================================
        private void btnGuardar_Click(
            object sender, EventArgs e)
        {
            if (!Validar())
                return;

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
                            const string sql = @"
                                INSERT INTO dbo.Doctores
                                (
                                    nombres, apellidos,
                                    id_especialidad,
                                    numero_junta_vigilancia,
                                    telefono, correo, estado
                                )
                                VALUES
                                (
                                    @Nombres, @Apellidos,
                                    @Especialidad, @Junta,
                                    @Telefono, @Correo, 'Activo'
                                );
                                SELECT
                                    CAST(SCOPE_IDENTITY() AS INT);";

                            int idDoctor;

                            using (SqlCommand cmd =
                                new SqlCommand(sql, cn, tx))
                            {
                                AgregarParametrosDoctor(cmd);

                                idDoctor = Convert.ToInt32(
                                    cmd.ExecuteScalar());
                            }

                            InsertarHorarios(cn, tx, idDoctor);
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
                    "Doctor y días de atención guardados.",
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarDoctores();
                Limpiar();
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        // =====================================
        // MODIFICAR DOCTOR
        // =====================================
        private void btnModificar_Click(
            object sender, EventArgs e)
        {
            if (idSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Seleccione un doctor de la tabla.");
                return;
            }

            if (!Validar())
                return;

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
                            ValidarCitasFuturas(
                                cn, tx, idSeleccionado);

                            const string sql = @"
                                UPDATE dbo.Doctores
                                SET nombres = @Nombres,
                                    apellidos = @Apellidos,
                                    id_especialidad = @Especialidad,
                                    numero_junta_vigilancia = @Junta,
                                    telefono = @Telefono,
                                    correo = @Correo
                                WHERE id_doctor = @Doctor";

                            using (SqlCommand cmd =
                                new SqlCommand(sql, cn, tx))
                            {
                                AgregarParametrosDoctor(cmd);

                                cmd.Parameters.Add(
                                    "@Doctor", SqlDbType.Int
                                ).Value = idSeleccionado;

                                if (cmd.ExecuteNonQuery() != 1)
                                    throw new Exception(
                                        "No se encontró el doctor.");
                            }

                            // Reemplazamos las jornadas activas
                            // por los días seleccionados.
                            using (SqlCommand cmd =
                                new SqlCommand(
                                    @"DELETE FROM dbo.Horarios_Doctor
                                      WHERE id_doctor = @Doctor",
                                    cn, tx))
                            {
                                cmd.Parameters.Add(
                                    "@Doctor", SqlDbType.Int
                                ).Value = idSeleccionado;

                                cmd.ExecuteNonQuery();
                            }

                            InsertarHorarios(
                                cn, tx, idSeleccionado);

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
                    "Doctor y jornadas actualizados.",
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarDoctores();
                Limpiar();
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private void AgregarParametrosDoctor(SqlCommand cmd)
        {
            cmd.Parameters.Add(
                "@Nombres", SqlDbType.VarChar, 100
            ).Value = txtNombres.Text.Trim();

            cmd.Parameters.Add(
                "@Apellidos", SqlDbType.VarChar, 100
            ).Value = txtApellidos.Text.Trim();

            cmd.Parameters.Add(
                "@Especialidad", SqlDbType.Int
            ).Value = Convert.ToInt32(
                cboEspecialidad.SelectedValue);

            cmd.Parameters.Add(
                "@Junta", SqlDbType.VarChar, 30
            ).Value = TextoONulo(txtJunta.Text);

            cmd.Parameters.Add(
                "@Telefono", SqlDbType.VarChar, 15
            ).Value = TextoONulo(txtTelefono.Text);

            cmd.Parameters.Add(
                "@Correo", SqlDbType.VarChar, 100
            ).Value = TextoONulo(txtCorreo.Text);
        }

        private object TextoONulo(string texto)
        {
            string valor = (texto ?? "").Trim();
            return valor.Length == 0
                ? (object)DBNull.Value : valor;
        }

        // =====================================
        // INACTIVAR DOCTOR
        // =====================================
        private void btnInactivar_Click(
            object sender, EventArgs e)
        {
            if (idSeleccionado <= 0)
                return;

            if (MessageBox.Show(
                "¿Desea inactivar este doctor?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
                != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection cn = conexion.Conectar())
                using (SqlCommand cmd = new SqlCommand(
                    @"UPDATE dbo.Doctores
                      SET estado = 'Inactivo'
                      WHERE id_doctor = @Doctor", cn))
                {
                    cmd.Parameters.Add(
                        "@Doctor", SqlDbType.Int
                    ).Value = idSeleccionado;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Doctor inactivado.");
                CargarDoctores();
                Limpiar();
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        // =====================================
        // SELECCIONAR DOCTOR
        // =====================================
        private void dgvDoctores_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila =
                dgvDoctores.Rows[e.RowIndex];

            idSeleccionado = Convert.ToInt32(
                fila.Cells["Código"].Value);

            txtIdDoctor.Text = idSeleccionado.ToString();
            txtNombres.Text = Convert.ToString(
                fila.Cells["Nombres"].Value);
            txtApellidos.Text = Convert.ToString(
                fila.Cells["Apellidos"].Value);

            cboEspecialidad.SelectedValue =
                Convert.ToInt32(
                    fila.Cells["IdEspecialidad"].Value);

            txtJunta.Text = Convert.ToString(
                fila.Cells["N° Junta"].Value);
            txtTelefono.Text = Convert.ToString(
                fila.Cells["Teléfono"].Value);
            txtCorreo.Text = Convert.ToString(
                fila.Cells["Correo"].Value);

            for (int i = 0; i < clbDias.Items.Count; i++)
                clbDias.SetItemChecked(i, false);

            try
            {
                using (SqlConnection cn = conexion.Conectar())
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT dia_semana, hora_inicio, hora_fin
                      FROM dbo.Horarios_Doctor
                      WHERE id_doctor = @Doctor
                        AND estado = 'Activo'
                      ORDER BY hora_inicio", cn))
                {
                    cmd.Parameters.Add(
                        "@Doctor", SqlDbType.Int
                    ).Value = idSeleccionado;

                    cn.Open();

                    TimeSpan? primeraEntrada = null;
                    TimeSpan? primeraSalida = null;
                    bool distintos = false;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string dia = NormalizarDia(
                                dr["dia_semana"].ToString());

                            for (int i = 0;
                                i < clbDias.Items.Count; i++)
                            {
                                if (string.Equals(
                                    clbDias.Items[i].ToString(),
                                    dia,
                                    StringComparison.OrdinalIgnoreCase))
                                {
                                    clbDias.SetItemChecked(i, true);
                                }
                            }

                            TimeSpan ini =
                                (TimeSpan)dr["hora_inicio"];
                            TimeSpan fin =
                                (TimeSpan)dr["hora_fin"];

                            if (!primeraEntrada.HasValue)
                            {
                                primeraEntrada = ini;
                                primeraSalida = fin;
                            }
                            else if (
                                ini != primeraEntrada.Value ||
                                fin != primeraSalida.Value)
                            {
                                distintos = true;
                            }
                        }
                    }

                    if (primeraEntrada.HasValue)
                    {
                        dtpHoraInicio.Value =
                            DateTime.Today.Add(
                                primeraEntrada.Value);

                        dtpHoraFin.Value =
                            DateTime.Today.Add(
                                primeraSalida.Value);
                    }

                    if (distintos)
                    {
                        MessageBox.Show(
                            "Este doctor tiene horarios diferentes " +
                            "entre sus días. Si modifica y guarda, " +
                            "se aplicará un horario único a todos " +
                            "los días marcados.",
                            "Revisar jornada",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Error(ex);
            }

            btnGuardar.Enabled = false;
            btnModificar.Enabled = true;
            btnInactivar.Enabled = true;
        }

        // =====================================
        // BUSCAR, REFRESCAR Y LIMPIAR
        // =====================================
        private void btnBuscar_Click(
            object sender, EventArgs e)
        {
            try
            {
                CargarDoctores(txtBuscar.Text.Trim());
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private void btnRefrescar_Click(
            object sender, EventArgs e)
        {
            try
            {
                txtBuscar.Clear();
                CargarEspecialidades();
                CargarDoctores();
                Limpiar();
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private void btnLimpiar_Click(
            object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            idSeleccionado = 0;
            txtIdDoctor.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtJunta.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();

            cboEspecialidad.SelectedIndex = -1;

            for (int i = 0; i < clbDias.Items.Count; i++)
                clbDias.SetItemChecked(i, false);

            dtpHoraInicio.Value =
                DateTime.Today.AddHours(8);

            dtpHoraFin.Value =
                DateTime.Today.AddHours(12);

            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnInactivar.Enabled = false;

            dgvDoctores.ClearSelection();
        }

        private void Error(Exception ex)
        {
            MessageBox.Show(
                ex.GetBaseException().Message,
                "MediCitas - Doctores",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
