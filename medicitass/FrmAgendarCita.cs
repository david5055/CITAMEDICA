
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmAgendarCita : Form
    {
        private readonly Conexion conexion = new Conexion();
        private readonly string usuarioActual;

        private int idUsuarioActual = 0;

        // Constructor para el diseñador.
        public FrmAgendarCita() : this("")
        {
        }

        // Constructor utilizado desde FrmMenuPrincipal.
        public FrmAgendarCita(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario ?? "";
        }

        private void FrmAgendarCita_Load(
            object sender, EventArgs e)
        {
            dtpFecha.MinDate = DateTime.Today;
            dtpFecha.Value = DateTime.Today;

            cboPaciente.SelectedIndex = -1;
            cboEspecialidad.SelectedIndex = -1;
            cboDoctor.SelectedIndex = -1;
            cboHorario.SelectedIndex = -1;

            btnGuardar.Enabled = false;

            if (string.IsNullOrWhiteSpace(usuarioActual))
            {
                lblEstado.Text =
                    "Abra este formulario desde una sesión válida.";
                return;
            }

            try
            {
                using (SqlConnection cn = conexion.Conectar())
                {
                    cn.Open();

                    if (!ValidarUsuario(cn))
                    {
                        lblEstado.Text =
                            "Usuario inactivo o sin permiso para agendar.";
                        return;
                    }
                }

                CargarPacientes();
                CargarEspecialidades();

                lblEstado.Text =
                    "Seleccione paciente, especialidad, doctor y fecha.";
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // ========================================
        // VALIDAR USUARIO AUTENTICADO
        // ========================================
        private bool ValidarUsuario(SqlConnection cn)
        {
            idUsuarioActual = 0;

            string sql = @"
                SELECT
                    u.id_usuario
                FROM dbo.Usuarios u
                INNER JOIN dbo.Roles r
                    ON u.id_rol = r.id_rol
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
                        return false;

                    int id = Convert.ToInt32(
                        dr["id_usuario"]);

                    // Rechazar cuentas duplicadas.
                    if (dr.Read())
                        return false;

                    idUsuarioActual = id;
                    return true;
                }
            }
        }

        // ========================================
        // CARGAR PACIENTES
        // ========================================
        private void CargarPacientes()
        {
            string sql = @"
                SELECT
                    id_paciente,
                    nombres + ' ' + apellidos +
                    ' - DUI: ' + dui AS descripcion
                FROM dbo.Pacientes
                WHERE estado = 'Activo'
                ORDER BY nombres, apellidos";

            CargarCombo(cboPaciente, sql,
                "descripcion", "id_paciente");
        }

        // ========================================
        // CARGAR ESPECIALIDADES
        // ========================================
        private void CargarEspecialidades()
        {
            string sql = @"
                SELECT id_especialidad, nombre
                FROM dbo.Especialidades
                WHERE estado = 'Activo'
                ORDER BY nombre";

            CargarCombo(cboEspecialidad, sql,
                "nombre", "id_especialidad");
        }

        private void CargarCombo(
            ComboBox combo,
            string sql,
            string displayMember,
            string valueMember,
            int? parametro = null)
        {
            using (SqlConnection cn = conexion.Conectar())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                if (parametro.HasValue)
                {
                    cmd.Parameters.Add(
                        "@Especialidad", SqlDbType.Int
                    ).Value = parametro.Value;
                }

                using (SqlDataAdapter da =
                    new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);

                    combo.DisplayMember = displayMember;
                    combo.ValueMember = valueMember;
                    combo.DataSource = tabla;
                    combo.SelectedIndex = -1;
                }
            }
        }

        // ========================================
        // ESPECIALIDAD SELECCIONADA
        // ========================================
        private void cboEspecialidad_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            cboDoctor.DataSource = null;
            cboHorario.DataSource = null;
            btnGuardar.Enabled = false;

            if (cboEspecialidad.SelectedIndex < 0)
                return;

            if (!(cboEspecialidad.SelectedValue is int))
                return;

            try
            {
                int idEspecialidad =
                    Convert.ToInt32(
                        cboEspecialidad.SelectedValue);

                string sql = @"
                    SELECT
                        id_doctor,
                        'Dr(a). ' + nombres + ' ' + apellidos
                            AS descripcion
                    FROM dbo.Doctores
                    WHERE id_especialidad = @Especialidad
                      AND estado = 'Activo'
                    ORDER BY nombres, apellidos";

                CargarCombo(
                    cboDoctor,
                    sql,
                    "descripcion",
                    "id_doctor",
                    idEspecialidad);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // ========================================
        // CAMBIOS DE DOCTOR Y FECHA
        // ========================================
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

        // ========================================
        // OBTENER DÍA EN ESPAÑOL
        // ========================================
        private string ObtenerDia(DateTime fecha)
        {
            switch (fecha.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "Lunes";

                case DayOfWeek.Tuesday:
                    return "Martes";

                case DayOfWeek.Wednesday:
                    return "Miercoles";

                case DayOfWeek.Thursday:
                    return "Jueves";

                case DayOfWeek.Friday:
                    return "Viernes";

                case DayOfWeek.Saturday:
                    return "Sabado";

                default:
                    return "Domingo";
            }
        }

        // ========================================
        // BUSCAR HORARIOS LIBRES
        // ========================================
        private void btnBuscarHorarios_Click(
            object sender, EventArgs e)
        {
            BuscarHorariosLibres();
        }

        private void BuscarHorariosLibres()
        {
            LimpiarHorarios();

            if (idUsuarioActual <= 0)
            {
                MessageBox.Show(
                    "Debe iniciar sesión como Administrador " +
                    "o Recepcionista.",
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (cboDoctor.SelectedIndex < 0 ||
                !(cboDoctor.SelectedValue is int))
            {
                MessageBox.Show(
                    "Seleccione un doctor.",
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int idDoctor =
                Convert.ToInt32(cboDoctor.SelectedValue);

            DateTime fecha = dtpFecha.Value.Date;
            string dia = ObtenerDia(fecha);

            try
            {
                using (SqlConnection cn = conexion.Conectar())
                {
                    cn.Open();

                    string sql = @"
                        SELECT
                            hora_inicio,
                            hora_fin
                        FROM dbo.Horarios_Doctor
                        WHERE id_doctor = @Doctor
                          AND estado = 'Activo'
                          AND (
                              UPPER(
                                  REPLACE(
                                      REPLACE(
                                          REPLACE(
                                              dia_semana,
                                              'é', 'e'),
                                          'á', 'a'),
                                      ' ', '')
                              ) = UPPER(@Dia)
                          )
                        ORDER BY hora_inicio";

                    DataTable jornadas = new DataTable();

                    using (SqlCommand cmd =
                        new SqlCommand(sql, cn))
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
                            "El doctor no tiene una jornada activa " +
                            "para el día " + dia + ".",
                            "Sin horario laboral",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }

                    // Obtener citas que ya ocupan horario.
                    DataTable ocupadas = new DataTable();

                    string citasSql = @"
                        SELECT hora_inicio, hora_fin
                        FROM dbo.Citas
                        WHERE id_doctor = @Doctor
                          AND fecha = @Fecha
                          AND estado = 'Programada'";

                    using (SqlCommand cmd =
                        new SqlCommand(citasSql, cn))
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

                    DateTime ahora = DateTime.Now;
                    int encontrados = 0;

                    foreach (DataRow jornada in jornadas.Rows)
                    {
                        TimeSpan inicio =
                            (TimeSpan)jornada["hora_inicio"];

                        TimeSpan fin =
                            (TimeSpan)jornada["hora_fin"];

                        // Bloques de 30 minutos.
                        while (inicio.Add(
                            TimeSpan.FromMinutes(30)) <= fin)
                        {
                            TimeSpan finBloque =
                                inicio.Add(
                                    TimeSpan.FromMinutes(30));

                            DateTime inicioReal =
                                fecha.Add(inicio);

                            bool esFuturo =
                                inicioReal > ahora;

                            bool ocupado = false;

                            foreach (DataRow cita in ocupadas.Rows)
                            {
                                TimeSpan horaCitaInicio =
                                    (TimeSpan)cita["hora_inicio"];

                                TimeSpan horaCitaFin =
                                    (TimeSpan)cita["hora_fin"];

                                if (inicio < horaCitaFin &&
                                    finBloque > horaCitaInicio)
                                {
                                    ocupado = true;
                                    break;
                                }
                            }

                            if (esFuturo && !ocupado)
                            {
                                cboHorario.Items.Add(
                                    new BloqueHorario(
                                        inicio, finBloque));

                                encontrados++;
                            }

                            inicio = finBloque;
                        }
                    }

                    if (encontrados == 0)
                    {
                        MessageBox.Show(
                            "No hay bloques disponibles para " +
                            "la fecha seleccionada.\n\n" +
                            "Si es hoy, puede que todos los " +
                            "horarios de atención ya hayan pasado.",
                            "Sin disponibilidad",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        lblEstado.Text =
                            encontrados +
                            " bloques de horario disponibles.";

                        cboHorario.SelectedIndex = 0;
                        btnGuardar.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // ========================================
        // CLASE DE BLOQUE HORARIO
        // ========================================
        private class BloqueHorario
        {
            public TimeSpan Inicio { get; private set; }
            public TimeSpan Fin { get; private set; }

            public BloqueHorario(
                TimeSpan inicio, TimeSpan fin)
            {
                Inicio = inicio;
                Fin = fin;
            }

            public override string ToString()
            {
                string desde =
                    DateTime.Today.Add(Inicio)
                        .ToString("hh:mm tt");

                string hasta =
                    DateTime.Today.Add(Fin)
                        .ToString("hh:mm tt");

                return desde + " - " + hasta;
            }
        }

        // ========================================
        // MOSTRAR CITAS DE LA FECHA
        // ========================================
        private void CargarCitasDeFecha()
        {
            if (dgvCitas == null)
                return;

            dgvCitas.Rows.Clear();

            if (cboDoctor.SelectedIndex < 0 ||
                !(cboDoctor.SelectedValue is int))
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
                    WHERE c.fecha = @Fecha
                      AND c.id_doctor = @Doctor
                      AND c.estado = 'Programada'
                    ORDER BY c.hora_inicio";

                using (SqlConnection cn = conexion.Conectar())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add(
                        "@Fecha", SqlDbType.Date
                    ).Value = dtpFecha.Value.Date;

                    cmd.Parameters.Add(
                        "@Doctor", SqlDbType.Int
                    ).Value =
                        Convert.ToInt32(cboDoctor.SelectedValue);

                    cn.Open();

                    using (SqlDataReader dr =
                        cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            TimeSpan inicio =
                                (TimeSpan)dr["hora_inicio"];

                            TimeSpan fin =
                                (TimeSpan)dr["hora_fin"];

                            string horario =
                                DateTime.Today.Add(inicio)
                                .ToString("hh:mm tt") +
                                " - " +
                                DateTime.Today.Add(fin)
                                .ToString("hh:mm tt");

                            dgvCitas.Rows.Add(
                                dr["id_cita"],
                                horario,
                                dr["Paciente"],
                                dr["Doctor"],
                                dr["Motivo"]
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblEstado.Text =
                    "No se pudo cargar la agenda.";

                MostrarError(ex);
            }
        }

        // ========================================
        // GUARDAR CITA
        // ========================================
        private void btnGuardar_Click(
            object sender, EventArgs e)
        {
            if (idUsuarioActual <= 0 ||
                cboPaciente.SelectedIndex < 0 ||
                cboDoctor.SelectedIndex < 0 ||
                !(cboHorario.SelectedItem is BloqueHorario))
            {
                MessageBox.Show(
                    "Complete paciente, doctor y horario.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show(
                    "Ingrese el motivo de la consulta.",
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtMotivo.Focus();
                return;
            }

            int idPaciente =
                Convert.ToInt32(cboPaciente.SelectedValue);

            int idDoctor =
                Convert.ToInt32(cboDoctor.SelectedValue);

            BloqueHorario bloque =
                (BloqueHorario)cboHorario.SelectedItem;

            DateTime fecha = dtpFecha.Value.Date;

            if (fecha.Add(bloque.Inicio) <= DateTime.Now)
            {
                MessageBox.Show(
                    "No se pueden agendar citas " +
                    "en horarios que ya pasaron.",
                    "Horario inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmar = MessageBox.Show(
                "¿Desea agendar esta cita?\n\n" +
                "Fecha: " + fecha.ToString("dd/MM/yyyy") +
                "\nHorario: " + bloque.ToString(),
                "Confirmar cita",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes)
                return;

            btnGuardar.Enabled = false;

            try
            {
                int idCita = GuardarCita(
                    idPaciente,
                    idDoctor,
                    fecha,
                    bloque.Inicio,
                    bloque.Fin,
                    txtMotivo.Text.Trim());

                MessageBox.Show(
                    "Cita agendada correctamente.\n" +
                    "Número de cita: " + idCita,
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
                BuscarHorariosLibres();
            }
        }

        // ========================================
        // TRANSACCIÓN PARA GUARDAR
        // ========================================
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
                        // Revalidar el usuario.
                        string permiso = @"
                            SELECT COUNT(*)
                            FROM dbo.Usuarios u
                            INNER JOIN dbo.Roles r
                                ON u.id_rol = r.id_rol
                            WHERE u.id_usuario = @IdUsuario
                              AND u.nombre_usuario = @Usuario
                              AND u.estado = 'Activo'
                              AND r.nombre_rol IN
                                  ('Administrador','Recepcionista')";

                        using (SqlCommand cmd =
                            new SqlCommand(permiso, cn, tx))
                        {
                            cmd.Parameters.Add(
                                "@IdUsuario", SqlDbType.Int
                            ).Value = idUsuarioActual;

                            cmd.Parameters.Add(
                                "@Usuario",
                                SqlDbType.VarChar, 50
                            ).Value = usuarioActual;

                            if (Convert.ToInt32(
                                cmd.ExecuteScalar()) != 1)
                            {
                                throw new Exception(
                                    "La cuenta no tiene permiso para agendar.");
                            }
                        }

                        // Bloqueo transaccional por doctor y fecha.
                        string recurso =
                            "MediCitas_Doctor_" + doctor + "_" +
                            fecha.ToString("yyyyMMdd");

                        int resultadoBloqueo;

                        using (SqlCommand cmd = new SqlCommand(
                            @"DECLARE @Resultado INT;
                              EXEC @Resultado = sys.sp_getapplock
                                @Resource = @Recurso,
                                @LockMode = 'Exclusive',
                                @LockOwner = 'Transaction',
                                @LockTimeout = 10000;
                              SELECT @Resultado;", cn, tx))
                        {
                            cmd.Parameters.Add(
                                "@Recurso", SqlDbType.VarChar, 255
                            ).Value = recurso;

                            resultadoBloqueo = Convert.ToInt32(
                                cmd.ExecuteScalar());
                        }

                        if (resultadoBloqueo < 0)
                        {
                            throw new Exception(
                                "No fue posible reservar el horario.");
                        }

                        if (fecha.Add(inicio) <= DateTime.Now)
                        {
                            throw new Exception(
                                "El horario seleccionado ya pasó.");
                        }

                        // Verificar que el doctor trabaje en
                        // ese día y horario.
                        string verificarJornada = @"
                            SELECT COUNT(*)
                            FROM dbo.Horarios_Doctor h
                            INNER JOIN dbo.Doctores d
                                ON h.id_doctor = d.id_doctor
                            WHERE h.id_doctor = @Doctor
                              AND h.estado = 'Activo'
                              AND d.estado = 'Activo'
                              AND UPPER(
                                REPLACE(
                                    REPLACE(
                                        REPLACE(h.dia_semana,
                                            'é','e'),
                                        'á','a'),
                                    ' ','')
                              ) = UPPER(@Dia)
                              AND h.hora_inicio <= @Inicio
                              AND h.hora_fin >= @Fin";

                        using (SqlCommand cmd =
                            new SqlCommand(
                                verificarJornada, cn, tx))
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
                                    "El doctor no atiende " +
                                    "en ese día u horario.");
                            }
                        }

                        // Verificar solapamientos.
                        string verificar = @"
                            SELECT COUNT(*)
                            FROM dbo.Citas WITH (UPDLOCK, HOLDLOCK)
                            WHERE id_doctor = @Doctor
                              AND fecha = @Fecha
                              AND estado = 'Programada'
                              AND @Inicio < hora_fin
                              AND @Fin > hora_inicio";

                        using (SqlCommand cmd =
                            new SqlCommand(verificar, cn, tx))
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
                                    "Ese bloque ya fue reservado.");
                            }
                        }

                        // Insertar cita.
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

                        int nuevaCita;

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

                            nuevaCita = Convert.ToInt32(
                                cmd.ExecuteScalar());
                        }

                        // Guardar historial.
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
                                @Cita,
                                'Creada',
                                NULL,
                                NULL,
                                @Fecha,
                                @Hora,
                                @Usuario,
                                SYSDATETIME()
                            )";

                        using (SqlCommand cmd =
                            new SqlCommand(historial, cn, tx))
                        {
                            cmd.Parameters.Add(
                                "@Cita", SqlDbType.Int
                            ).Value = nuevaCita;

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

                        tx.Commit();
                        return nuevaCita;
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

        // ========================================
        // ERRORES
        // ========================================
        private void MostrarError(Exception ex)
        {
            MessageBox.Show(
                ex.GetBaseException().Message,
                "MediCitas",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
