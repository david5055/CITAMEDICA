
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmAgendarCita : Form
    {
        private readonly Conexion conexion = new Conexion();
        private readonly string usuarioActual;
        private int idUsuarioActual = 0;

        public FrmAgendarCita() : this("")
        {
        }

        public FrmAgendarCita(string usuario)
        {
            InitializeComponent();
            usuarioActual = (usuario ?? "").Trim();
        }

        private class BloqueHorario
        {
            public TimeSpan Inicio { get; set; }
            public TimeSpan Fin { get; set; }

            public BloqueHorario(TimeSpan inicio, TimeSpan fin)
            {
                Inicio = inicio;
                Fin = fin;
            }

            public override string ToString()
            {
                return DateTime.Today.Add(Inicio)
                    .ToString("hh:mm tt") + " - " +
                    DateTime.Today.Add(Fin)
                    .ToString("hh:mm tt");
            }
        }

        private void FrmAgendarCita_Load(
            object sender, EventArgs e)
        {
            dtpFecha.MinDate = DateTime.Today;
            dtpFecha.Value = DateTime.Today;
            btnGuardar.Enabled = false;

            try
            {
                using (SqlConnection cn = conexion.Conectar())
                {
                    cn.Open();
                    idUsuarioActual = BuscarUsuarioAutorizado(cn);
                }

                if (idUsuarioActual == 0)
                {
                    lblEstado.Text =
                        "Sesión no identificada. Abra Agendar cita " +
                        "desde el Menú Principal con una cuenta válida.";

                    MessageBox.Show(
                        "No se identificó la cuenta que está " +
                        "agendando la cita.",
                        "MediCitas",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                CargarPacientes();
                CargarEspecialidades();
                LimpiarHorarios();

                lblEstado.Text =
                    "Seleccione un paciente, doctor y fecha.";
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private int BuscarUsuarioAutorizado(SqlConnection cn)
        {
            if (string.IsNullOrWhiteSpace(usuarioActual))
                return 0;

            string sql = @"
                SELECT u.id_usuario
                FROM dbo.Usuarios u
                INNER JOIN dbo.Roles r
                  ON r.id_rol = u.id_rol
                WHERE u.nombre_usuario = @Usuario
                  AND u.estado = 'Activo'
                  AND r.nombre_rol IN
                    ('Administrador', 'Recepcionista')";

            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add(
                    "@Usuario", SqlDbType.VarChar, 50
                ).Value = usuarioActual;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read())
                        return 0;

                    int id = Convert.ToInt32(dr["id_usuario"]);

                    if (dr.Read())
                        return 0;

                    return id;
                }
            }
        }

        private void CargarPacientes()
        {
            string sql = @"
                SELECT id_paciente,
                    nombres + ' ' + apellidos +
                    ' - DUI: ' + dui AS Descripcion
                FROM dbo.Pacientes
                WHERE estado = 'Activo'
                ORDER BY nombres, apellidos";

            CargarCombo(
                cboPaciente, sql,
                "Descripcion", "id_paciente");
        }

        private void CargarEspecialidades()
        {
            string sql = @"
                SELECT id_especialidad, nombre
                FROM dbo.Especialidades
                WHERE estado = 'Activo'
                ORDER BY nombre";

            CargarCombo(
                cboEspecialidad, sql,
                "nombre", "id_especialidad");
        }

        private void CargarCombo(
            ComboBox combo,
            string sql,
            string display,
            string value,
            int? especialidad = null)
        {
            using (SqlConnection cn = conexion.Conectar())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                if (especialidad.HasValue)
                {
                    cmd.Parameters.Add(
                        "@Especialidad", SqlDbType.Int
                    ).Value = especialidad.Value;
                }

                DataTable tabla = new DataTable();
                da.Fill(tabla);

                combo.DisplayMember = display;
                combo.ValueMember = value;
                combo.DataSource = tabla;
                combo.SelectedIndex = -1;
            }
        }

        private bool ObtenerIdSeleccionado(
            ComboBox combo, out int id)
        {
            id = 0;

            if (combo.SelectedIndex < 0)
                return false;

            if (combo.SelectedValue == null ||
                combo.SelectedValue is DataRowView)
                return false;

            return int.TryParse(
                combo.SelectedValue.ToString(), out id);
        }

        private void cboEspecialidad_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            cboDoctor.DataSource = null;
            LimpiarHorarios();
            dgvCitas.Rows.Clear();

            int idEspecialidad;

            if (!ObtenerIdSeleccionado(
                cboEspecialidad, out idEspecialidad))
                return;

            try
            {
                string sql = @"
                    SELECT id_doctor,
                        'Dr(a). ' + nombres + ' ' +
                        apellidos AS Descripcion
                    FROM dbo.Doctores
                    WHERE id_especialidad = @Especialidad
                      AND estado = 'Activo'
                    ORDER BY nombres, apellidos";

                CargarCombo(
                    cboDoctor, sql,
                    "Descripcion", "id_doctor",
                    idEspecialidad);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void cboDoctor_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            LimpiarHorarios();
            CargarCitasDeFecha();
        }

        private void dtpFecha_ValueChanged(
            object sender, EventArgs e)
        {
            LimpiarHorarios();
            CargarCitasDeFecha();
        }

        private void LimpiarHorarios()
        {
            cboHorario.DataSource = null;
            cboHorario.Items.Clear();
            cboHorario.SelectedIndex = -1;
            btnGuardar.Enabled = false;
        }

        private string ObtenerDia(DateTime fecha)
        {
            switch (fecha.DayOfWeek)
            {
                case DayOfWeek.Monday: return "Lunes";
                case DayOfWeek.Tuesday: return "Martes";
                case DayOfWeek.Wednesday: return "Miercoles";
                case DayOfWeek.Thursday: return "Jueves";
                case DayOfWeek.Friday: return "Viernes";
                case DayOfWeek.Saturday: return "Sabado";
                default: return "Domingo";
            }
        }

        private void btnBuscarHorarios_Click(
            object sender, EventArgs e)
        {
            BuscarHorariosLibres();
        }

        private void BuscarHorariosLibres()
        {
            LimpiarHorarios();

            int idDoctor;

            if (idUsuarioActual <= 0)
            {
                MessageBox.Show(
                    "La sesión no está identificada.",
                    "MediCitas");
                return;
            }

            if (!ObtenerIdSeleccionado(
                cboDoctor, out idDoctor))
            {
                MessageBox.Show(
                    "Seleccione primero un doctor.",
                    "MediCitas");
                return;
            }

            DateTime fecha = dtpFecha.Value.Date;
            string dia = ObtenerDia(fecha);

            try
            {
                using (SqlConnection cn = conexion.Conectar())
                {
                    cn.Open();

                    // Leer las jornadas registradas.
                    DataTable jornadas = new DataTable();

                    string sqlJornadas = @"
                        SELECT h.hora_inicio, h.hora_fin
                        FROM dbo.Horarios_Doctor h
                        INNER JOIN dbo.Doctores d
                            ON d.id_doctor = h.id_doctor
                        WHERE h.id_doctor = @Doctor
                          AND h.estado = 'Activo'
                          AND d.estado = 'Activo'
                          AND h.dia_semana COLLATE
                              Latin1_General_100_CI_AI
                              = @Dia COLLATE
                              Latin1_General_100_CI_AI
                        ORDER BY h.hora_inicio";

                    using (SqlCommand cmd =
                        new SqlCommand(sqlJornadas, cn))
                    {
                        cmd.Parameters.Add(
                            "@Doctor", SqlDbType.Int
                        ).Value = idDoctor;

                        cmd.Parameters.Add(
                            "@Dia", SqlDbType.VarChar, 15
                        ).Value = dia;

                        using (SqlDataAdapter da =
                            new SqlDataAdapter(cmd))
                        {
                            da.Fill(jornadas);
                        }
                    }

                    if (jornadas.Rows.Count == 0)
                    {
                        MessageBox.Show(
                            "El médico no tiene una jornada " +
                            "activa para " + dia + ".",
                            "Sin jornada");
                        return;
                    }

                    DataTable ocupadas = new DataTable();

                    string sqlOcupadas = @"
                        SELECT hora_inicio, hora_fin
                        FROM dbo.Citas
                        WHERE id_doctor = @Doctor
                          AND fecha = @Fecha
                          AND estado = 'Programada'";

                    using (SqlCommand cmd =
                        new SqlCommand(sqlOcupadas, cn))
                    {
                        cmd.Parameters.Add(
                            "@Doctor", SqlDbType.Int
                        ).Value = idDoctor;

                        cmd.Parameters.Add(
                            "@Fecha", SqlDbType.Date
                        ).Value = fecha;

                        using (SqlDataAdapter da =
                            new SqlDataAdapter(cmd))
                        {
                            da.Fill(ocupadas);
                        }
                    }

                    foreach (DataRow jornada in jornadas.Rows)
                    {
                        TimeSpan hora =
                            (TimeSpan)jornada["hora_inicio"];

                        TimeSpan finJornada =
                            (TimeSpan)jornada["hora_fin"];

                        while (hora.Add(
                            TimeSpan.FromMinutes(30)) <= finJornada)
                        {
                            TimeSpan fin = hora.Add(
                                TimeSpan.FromMinutes(30));

                            bool futuro =
                                fecha.Add(hora) > DateTime.Now;

                            bool ocupado = false;

                            foreach (DataRow cita in ocupadas.Rows)
                            {
                                TimeSpan iniCita =
                                    (TimeSpan)cita["hora_inicio"];

                                TimeSpan finCita =
                                    (TimeSpan)cita["hora_fin"];

                                if (hora < finCita &&
                                    fin > iniCita)
                                {
                                    ocupado = true;
                                    break;
                                }
                            }

                            if (futuro && !ocupado)
                            {
                                cboHorario.Items.Add(
                                    new BloqueHorario(hora, fin));
                            }

                            hora = fin;
                        }
                    }

                    if (cboHorario.Items.Count == 0)
                    {
                        lblEstado.Text =
                            "No hay bloques disponibles.";

                        MessageBox.Show(
                            "No hay horarios libres para " +
                            "la fecha seleccionada.",
                            "Sin disponibilidad");
                    }
                    else
                    {
                        cboHorario.SelectedIndex = 0;
                        btnGuardar.Enabled = true;

                        lblEstado.Text =
                            cboHorario.Items.Count +
                            " horarios disponibles.";
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void CargarCitasDeFecha()
        {
            if (dgvCitas == null)
                return;

            dgvCitas.Rows.Clear();

            int idDoctor;

            if (!ObtenerIdSeleccionado(
                cboDoctor, out idDoctor))
                return;

            try
            {
                string sql = @"
                    SELECT
                        c.id_cita,
                        c.hora_inicio,
                        c.hora_fin,
                        p.nombres + ' ' + p.apellidos
                            AS Paciente,
                        d.nombres + ' ' + d.apellidos
                            AS Doctor,
                        ISNULL(c.motivo_consulta, '')
                            AS Motivo
                    FROM dbo.Citas c
                    INNER JOIN dbo.Pacientes p
                        ON c.id_paciente = p.id_paciente
                    INNER JOIN dbo.Doctores d
                        ON c.id_doctor = d.id_doctor
                    WHERE c.id_doctor = @Doctor
                      AND c.fecha = @Fecha
                      AND c.estado = 'Programada'
                    ORDER BY c.hora_inicio";

                using (SqlConnection cn = conexion.Conectar())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add(
                        "@Doctor", SqlDbType.Int
                    ).Value = idDoctor;

                    cmd.Parameters.Add(
                        "@Fecha", SqlDbType.Date
                    ).Value = dtpFecha.Value.Date;

                    cn.Open();

                    using (SqlDataReader dr =
                        cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            TimeSpan ini =
                                (TimeSpan)dr["hora_inicio"];

                            TimeSpan fin =
                                (TimeSpan)dr["hora_fin"];

                            string horario =
                                DateTime.Today.Add(ini)
                                    .ToString("hh:mm tt") +
                                " - " +
                                DateTime.Today.Add(fin)
                                    .ToString("hh:mm tt");

                            dgvCitas.Rows.Add(
                                dr["id_cita"],
                                horario,
                                dr["Paciente"],
                                dr["Doctor"],
                                dr["Motivo"]);
                        }
                    }
                }

                dgvCitas.ClearSelection();
            }
            catch (Exception ex)
            {
                lblEstado.Text =
                    "No se pudieron cargar las citas: " +
                    ex.GetBaseException().Message;
            }
        }

        // =========================================
        // GUARDAR CITA
        // =========================================
        private void btnGuardar_Click(
            object sender, EventArgs e)
        {
            int paciente;
            int doctor;

            if (idUsuarioActual == 0 ||
                !ObtenerIdSeleccionado(
                    cboPaciente, out paciente) ||
                !ObtenerIdSeleccionado(
                    cboDoctor, out doctor) ||
                !(cboHorario.SelectedItem is BloqueHorario))
            {
                MessageBox.Show(
                    "Seleccione paciente, doctor y " +
                    "un horario disponible.",
                    "Datos incompletos");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show(
                    "Ingrese el motivo de consulta.",
                    "MediCitas");
                return;
            }

            BloqueHorario bloque =
                (BloqueHorario)cboHorario.SelectedItem;

            DateTime fecha = dtpFecha.Value.Date;

            if (fecha.Add(bloque.Inicio) <= DateTime.Now)
            {
                MessageBox.Show(
                    "La hora de la cita ya pasó.",
                    "MediCitas");
                return;
            }

            if (MessageBox.Show(
                "¿Desea guardar esta cita?\n" +
                fecha.ToString("dd/MM/yyyy") + "\n" +
                bloque.ToString(),
                "Confirmar cita",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
                != DialogResult.Yes)
                return;

            btnGuardar.Enabled = false;

            try
            {
                int idCita = GuardarCita(
                    paciente, doctor, fecha,
                    bloque.Inicio, bloque.Fin,
                    txtMotivo.Text.Trim());

                MessageBox.Show(
                    "Cita guardada correctamente.\n" +
                    "Código de cita: " + idCita,
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtMotivo.Clear();
                CargarCitasDeFecha();
                BuscarHorariosLibres();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
                CargarCitasDeFecha();
            }
            finally
            {
                if (cboHorario.Items.Count > 0)
                    btnGuardar.Enabled = true;
            }
        }

        private int GuardarCita(
            int paciente,
            int doctor,
            DateTime fecha,
            TimeSpan inicio,
            TimeSpan fin,
            string motivo)
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
                        // Validar la sesión otra vez.
                        string permiso = @"
                            SELECT COUNT(*)
                            FROM dbo.Usuarios u
                            INNER JOIN dbo.Roles r
                                ON r.id_rol = u.id_rol
                            WHERE u.id_usuario = @IdUsuario
                              AND u.nombre_usuario = @Nombre
                              AND u.estado = 'Activo'
                              AND r.nombre_rol IN
                                ('Administrador', 'Recepcionista')";

                        using (SqlCommand cmd =
                            new SqlCommand(permiso, cn, tx))
                        {
                            cmd.Parameters.Add(
                                "@IdUsuario", SqlDbType.Int
                            ).Value = idUsuarioActual;

                            cmd.Parameters.Add(
                                "@Nombre", SqlDbType.VarChar, 50
                            ).Value = usuarioActual;

                            if (Convert.ToInt32(
                                cmd.ExecuteScalar()) != 1)
                            {
                                throw new Exception(
                                    "La cuenta no tiene permiso " +
                                    "para agendar citas.");
                            }
                        }

                        // Bloquear temporalmente este doctor
                        // y fecha para evitar doble reserva.
                        string recurso =
                            "MediCitas_" + doctor + "_" +
                            fecha.ToString("yyyyMMdd");

                        using (SqlCommand cmd =
                            new SqlCommand(@"
                                DECLARE @resultado INT;
                                EXEC @resultado = sp_getapplock
                                    @Resource = @Recurso,
                                    @LockMode = 'Exclusive',
                                    @LockOwner = 'Transaction',
                                    @LockTimeout = 10000;
                                SELECT @resultado;",
                                cn, tx))
                        {
                            cmd.Parameters.Add(
                                "@Recurso",
                                SqlDbType.VarChar, 255
                            ).Value = recurso;

                            if (Convert.ToInt32(
                                cmd.ExecuteScalar()) < 0)
                            {
                                throw new Exception(
                                    "No se pudo reservar " +
                                    "el horario.");
                            }
                        }

                        // Validar fecha/hora y jornada.
                        if (fecha.Add(inicio) <= DateTime.Now)
                        {
                            throw new Exception(
                                "El horario ya pasó.");
                        }

                        string jornada = @"
                            SELECT COUNT(*)
                            FROM dbo.Horarios_Doctor h
                            INNER JOIN dbo.Doctores d
                                ON d.id_doctor = h.id_doctor
                            WHERE h.id_doctor = @Doctor
                              AND h.estado = 'Activo'
                              AND d.estado = 'Activo'
                              AND h.dia_semana COLLATE
                                  Latin1_General_100_CI_AI
                                  = @Dia COLLATE
                                  Latin1_General_100_CI_AI
                              AND h.hora_inicio <= @Inicio
                              AND h.hora_fin >= @Fin";

                        using (SqlCommand cmd =
                            new SqlCommand(jornada, cn, tx))
                        {
                            cmd.Parameters.Add(
                                "@Doctor", SqlDbType.Int
                            ).Value = doctor;

                            cmd.Parameters.Add(
                                "@Dia", SqlDbType.VarChar, 15
                            ).Value = ObtenerDia(fecha);

                            cmd.Parameters.Add(
                                "@Inicio", SqlDbType.Time
                            ).Value = inicio;

                            cmd.Parameters.Add(
                                "@Fin", SqlDbType.Time
                            ).Value = fin;

                            if (Convert.ToInt32(
                                cmd.ExecuteScalar()) == 0)
                            {
                                throw new Exception(
                                    "El doctor no atiende en " +
                                    "el horario seleccionado.");
                            }
                        }

                        // Verificar que el bloque siga libre.
                        string ocupacion = @"
                            SELECT COUNT(*)
                            FROM dbo.Citas WITH
                                (UPDLOCK, HOLDLOCK)
                            WHERE id_doctor = @Doctor
                              AND fecha = @Fecha
                              AND estado = 'Programada'
                              AND @Inicio < hora_fin
                              AND @Fin > hora_inicio";

                        using (SqlCommand cmd =
                            new SqlCommand(ocupacion, cn, tx))
                        {
                            cmd.Parameters.Add(
                                "@Doctor", SqlDbType.Int
                            ).Value = doctor;

                            cmd.Parameters.Add(
                                "@Fecha", SqlDbType.Date
                            ).Value = fecha;

                            cmd.Parameters.Add(
                                "@Inicio", SqlDbType.Time
                            ).Value = inicio;

                            cmd.Parameters.Add(
                                "@Fin", SqlDbType.Time
                            ).Value = fin;

                            if (Convert.ToInt32(
                                cmd.ExecuteScalar()) > 0)
                            {
                                throw new Exception(
                                    "Ese horario ya está ocupado.");
                            }
                        }

                        // Insertar la cita.
                        string insertar = @"
                            INSERT INTO dbo.Citas
                            (
                                id_paciente,
                                id_doctor,
                                fecha,
                                hora_inicio,
                                hora_fin,
                                motivo_consulta,
                                estado,
                                motivo_cancelacion,
                                id_usuario,
                                fecha_registro
                            )
                            VALUES
                            (
                                @Paciente,
                                @Doctor,
                                @Fecha,
                                @Inicio,
                                @Fin,
                                @Motivo,
                                'Programada',
                                NULL,
                                @Usuario,
                                SYSDATETIME()
                            );
                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int idCita;

                        using (SqlCommand cmd =
                            new SqlCommand(insertar, cn, tx))
                        {
                            cmd.Parameters.Add(
                                "@Paciente", SqlDbType.Int
                            ).Value = paciente;

                            cmd.Parameters.Add(
                                "@Doctor", SqlDbType.Int
                            ).Value = doctor;

                            cmd.Parameters.Add(
                                "@Fecha", SqlDbType.Date
                            ).Value = fecha;

                            cmd.Parameters.Add(
                                "@Inicio", SqlDbType.Time
                            ).Value = inicio;

                            cmd.Parameters.Add(
                                "@Fin", SqlDbType.Time
                            ).Value = fin;

                            cmd.Parameters.Add(
                                "@Motivo", SqlDbType.VarChar, 255
                            ).Value = motivo;

                            cmd.Parameters.Add(
                                "@Usuario", SqlDbType.Int
                            ).Value = idUsuarioActual;

                            idCita = Convert.ToInt32(
                                cmd.ExecuteScalar());
                        }

                        // Registro del movimiento.
                        // Si tu base ya registra creaciones
                        // con un trigger de historial, este
                        // INSERT manual debe omitirse.
                        if (!ExisteTriggerHistorialCreacion(cn, tx))
                        {
                            string historial = @"
                                INSERT INTO dbo.Historial_Citas
                                (
                                    id_cita, accion,
                                    fecha_anterior,
                                    hora_anterior,
                                    fecha_nueva,
                                    hora_nueva,
                                    id_usuario,
                                    fecha_movimiento
                                )
                                VALUES
                                (
                                    @Cita, 'Creada',
                                    NULL, NULL,
                                    @Fecha, @Hora,
                                    @Usuario, SYSDATETIME()
                                )";

                            using (SqlCommand cmd =
                                new SqlCommand(historial, cn, tx))
                            {
                                cmd.Parameters.Add(
                                    "@Cita", SqlDbType.Int
                                ).Value = idCita;

                                cmd.Parameters.Add(
                                    "@Fecha", SqlDbType.Date
                                ).Value = fecha;

                                cmd.Parameters.Add(
                                    "@Hora", SqlDbType.Time
                                ).Value = inicio;

                                cmd.Parameters.Add(
                                    "@Usuario", SqlDbType.Int
                                ).Value = idUsuarioActual;

                                cmd.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();
                        return idCita;
                    }
                    catch
                    {
                        if (tx.Connection != null)
                            tx.Rollback();
                        throw;
                    }
                }
            }
        }

        // Determina si la creación de citas tiene
        // un trigger INSERT habilitado. El nombre
        // por sí solo no indica su comportamiento.
        private bool ExisteTriggerHistorialCreacion(
            SqlConnection cn, SqlTransaction tx)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM sys.triggers t
                WHERE t.parent_id =
                      OBJECT_ID('dbo.Citas')
                  AND t.is_disabled = 0
                  AND OBJECTPROPERTY(
                      t.object_id, 'ExecIsInsertTrigger') = 1";

            using (SqlCommand cmd =
                new SqlCommand(sql, cn, tx))
            {
                return Convert.ToInt32(
                    cmd.ExecuteScalar()) > 0;
            }
        }

        private void MostrarError(Exception ex)
        {
            MessageBox.Show(
                "No se pudo completar la operación:\n\n" +
                ex.GetBaseException().Message,
                "MediCitas",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
