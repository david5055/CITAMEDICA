
using System;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmMenuPrincipal : Form
    {
        private readonly string usuarioActual;
        private readonly string rolActual;
        private readonly Form formularioLogin;
        private bool cerrandoSesion;

        // Para visualizar desde el diseñador
        public FrmMenuPrincipal()
            : this("", "Sin sesión", null)
        {
        }

        // Constructor utilizado por FrmLogin
        public FrmMenuPrincipal(
            string usuario,
            string rol,
            Form login = null)
        {
            InitializeComponent();

            usuarioActual = usuario ?? "";
            rolActual = (rol ?? "").Trim();
            formularioLogin = login;

            ConfigurarSesion();
        }

        private bool EsAdministrador
        {
            get
            {
                return string.Equals(
                    rolActual, "Administrador",
                    StringComparison.OrdinalIgnoreCase);
            }
        }

        private bool EsRecepcionista
        {
            get
            {
                return string.Equals(
                    rolActual, "Recepcionista",
                    StringComparison.OrdinalIgnoreCase);
            }
        }

        private bool EsDoctor
        {
            get
            {
                return string.Equals(
                    rolActual, "Doctor",
                    StringComparison.OrdinalIgnoreCase);
            }
        }

        // ==========================================
        // CONFIGURAR MENÚ POR ROL
        // ==========================================
        private void ConfigurarSesion()
        {
            lblBienvenida.Text =
                "Bienvenido, " + usuarioActual;

            lblRol.Text = "Rol: " + rolActual;

            lblEstado.Text =
                "MediCitas | Usuario: " +
                usuarioActual + " | " + rolActual;

            bool admin = EsAdministrador;
            bool recepcion = EsRecepcionista;
            bool doctor = EsDoctor;

            // MANTENIMIENTOS
            mnuMantenimientos.Visible = admin || recepcion;

            mnuPacientes.Visible = admin || recepcion;
            mnuDoctores.Visible = admin;
            mnuEspecialidades.Visible = admin;
            mnuRoles.Visible = admin;
            mnuUsuarios.Visible = admin;

            // CONSULTAS GENERALES
            // El doctor no podrá consultar agendas
            // de otros médicos desde estas opciones.
            mnuConsultas.Visible = admin || recepcion;

            mnuAgendaFecha.Visible = admin || recepcion;
            mnuAgendaDoctor.Visible = admin || recepcion;

            // Se reserva el historial clínico hasta
            // aplicar filtros y permisos por paciente.
            mnuHistorial.Visible = admin;

            mnuDisponibilidad.Visible = admin || recepcion;
            mnuBusqueda.Visible = admin || recepcion;
            mnuCanceladas.Visible = admin || recepcion;

            // GESTIÓN DE CITAS
            mnuCitas.Visible = admin || recepcion;

            mnuAgendar.Visible = admin || recepcion;
            mnuReprogramar.Visible = admin || recepcion;
            mnuCancelar.Visible = admin || recepcion;

            // Hasta integrar la atención por id_doctor
            // no se habilita el formulario clínico.
            mnuAtendida.Visible = false;

            // BOTONES DE ACCESO RÁPIDO
            btnInicio.Visible = admin || recepcion || doctor;
            btnPacientes.Visible = admin || recepcion;
            btnDoctores.Visible = admin;
            btnAgendar.Visible = admin || recepcion;
            btnConsultas.Visible = admin || recepcion;

            // Solo se habilitan para los roles correctos.
            mnuSesion.Visible = true;
        }

        // ==========================================
        // INICIO AUTOMÁTICO
        // ==========================================
        private void FrmMenuPrincipal_Shown(
            object sender,
            EventArgs e)
        {
            MostrarInicio();
        }

        // ==========================================
        // ABRIR VENTANA MDI
        // ==========================================
        private void AbrirVentana(Form nueva)
        {
            foreach (Form abierta in this.MdiChildren)
            {
                if (abierta.GetType() == nueva.GetType())
                {
                    abierta.Activate();
                    abierta.BringToFront();
                    nueva.Dispose();
                    return;
                }
            }

            nueva.MdiParent = this;
            nueva.WindowState = FormWindowState.Maximized;
            nueva.Show();
            nueva.BringToFront();
        }

        // ==========================================
        // MOSTRAR DASHBOARD SEGÚN ROL
        // ==========================================
        private void MostrarInicio()
        {
            Form[] abiertas = this.MdiChildren;

            foreach (Form ventana in abiertas)
            {
                ventana.Close();
            }

            if (EsAdministrador)
            {
                AbrirVentana(
                    new FrmInicioAdministrador());
            }
            else if (EsDoctor)
            {
                AbrirVentana(
                    new FrmInicioDoctor(usuarioActual));
            }
            else if (EsRecepcionista)
            {
                AbrirVentana(
                    new FrmInicioRecepcionista(usuarioActual));
            }
        }

        // ==========================================
        // VALIDAR PERMISOS
        // ==========================================
        private bool TienePermiso(string formulario)
        {
            if (EsAdministrador)
            {
                // El formulario clínico del Doctor
                // se habilitará cuando se valide
                // el médico asignado.
                return formulario != "FrmMarcarAtendida";
            }

            if (EsRecepcionista)
            {
                switch (formulario)
                {
                    case "FrmMantenimientoPacientes":
                    case "FrmAgendarCita":
                    case "FrmReprogramarCita":
                    case "FrmCancelarCita":
                    case "FrmConsultaAgendaFecha":
                    case "FrmConsultaAgendaDoctor":
                    case "FrmConsultaDisponibilidad":
                    case "FrmBusquedaGeneral":
                    case "FrmConsultaCitasCanceladas":
                        return true;
                }
            }

            // Doctor:
            // Por ahora únicamente el Dashboard.
            // Sus botones clínicos están deshabilitados
            // hasta conectar id_doctor.
            return false;
        }

        // ==========================================
        // BUSCAR FORMULARIO EN EL PROYECTO
        // ==========================================
        private Form CrearFormulario(string nombre)
        {
            // En tu proyecto Especialidad está
            // escrito en singular.
            if (nombre ==
                "FrmMantenimientoEspecialidades")
            {
                nombre = "FrmMantenimientoEspecialidad";
            }

            Type tipo = typeof(FrmMenuPrincipal)
                .Assembly.GetType(
                    "medicitass." + nombre);

            if (tipo == null ||
                !typeof(Form).IsAssignableFrom(tipo))
            {
                return null;
            }

            // Los formularios de mantenimiento deben
            // contar con un constructor sin parámetros.
            return Activator.CreateInstance(tipo) as Form;
        }

        // ==========================================
        // ABRIR MÓDULOS CON PERMISOS
        // ==========================================
        private void AbrirModulo(string nombre)
        {
            if (!TienePermiso(nombre))
            {
                MessageBox.Show(
                    "No tienes permiso para abrir " +
                    "este módulo.",
                    "Acceso restringido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Form ventana = CrearFormulario(nombre);

                if (ventana == null)
                {
                    MessageBox.Show(
                        "No se encontró el formulario: " +
                        nombre +
                        "\nComprueba el nombre de su clase.",
                        "MediCitas",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                AbrirVentana(ventana);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al abrir el módulo:\n" +
                    ex.GetBaseException().Message,
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // ACCESOS DEL MENÚ
        // ==========================================
        private void btnInicio_Click(
            object sender,
            EventArgs e)
        {
            MostrarInicio();
        }

        private void mnuInicio_Click(
            object sender,
            EventArgs e)
        {
            MostrarInicio();
        }

        private void btnPacientes_Click(
            object sender,
            EventArgs e)
        {
            AbrirModulo(
                "FrmMantenimientoPacientes");
        }

        private void btnDoctores_Click(
            object sender,
            EventArgs e)
        {
            AbrirModulo(
                "FrmMantenimientoDoctores");
        }

        private void btnAgendar_Click(
            object sender,
            EventArgs e)
        {
            AbrirModulo(
                "FrmAgendarCita");
        }

        private void btnConsultas_Click(
            object sender,
            EventArgs e)
        {
            AbrirModulo(
                "FrmConsultaAgendaDoctor");
        }

        private void ModuloMenu_Click(
            object sender,
            EventArgs e)
        {
            ToolStripMenuItem item =
                sender as ToolStripMenuItem;

            if (item == null || item.Tag == null)
                return;

            AbrirModulo(item.Tag.ToString());
        }

        // ==========================================
        // CERRAR SESIÓN
        // ==========================================
        private void btnCerrarSesion_Click(
            object sender,
            EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Deseas cerrar sesión?",
                "MediCitas",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                cerrandoSesion = true;
                this.Close();
            }
        }

        private void FrmMenuPrincipal_FormClosed(
            object sender,
            FormClosedEventArgs e)
        {
            if (formularioLogin != null &&
                !formularioLogin.IsDisposed)
            {
                formularioLogin.Show();
            }
        }
    }
}
