
using System;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmMenuPrincipal : Form
    {
        private readonly string usuarioActual;
        private readonly string rolActual;
        private readonly Form formularioLogin;

        public FrmMenuPrincipal()
            : this("", "Sin sesión", null)
        {
        }

        public FrmMenuPrincipal(
            string usuario,
            string rol,
            Form login = null)
        {
            InitializeComponent();

            usuarioActual = (usuario ?? "").Trim();
            rolActual = (rol ?? "").Trim();
            formularioLogin = login;

            ConfigurarSesion();
        }

        // =====================================
        // ROLES DEL SISTEMA
        // =====================================
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

        // =====================================
        // CONFIGURAR PERMISOS
        // =====================================
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
            mnuMantenimientos.Visible =
                admin || recepcion;

            mnuPacientes.Visible =
                admin || recepcion;

            mnuDoctores.Visible = admin;
            mnuEspecialidades.Visible = admin;
            mnuRoles.Visible = admin;
            mnuUsuarios.Visible = admin;

            // CONSULTAS
            mnuConsultas.Visible =
                admin || recepcion;

            mnuAgendaFecha.Visible =
                admin || recepcion;

            mnuAgendaDoctor.Visible =
                admin || recepcion;

            mnuHistorial.Visible = admin;

            mnuDisponibilidad.Visible =
                admin || recepcion;

            mnuBusqueda.Visible =
                admin || recepcion;

            mnuCanceladas.Visible =
                admin || recepcion;

            // CITAS
            mnuCitas.Visible =
                admin || recepcion;

            mnuAgendar.Visible =
                admin || recepcion;

            mnuReprogramar.Visible =
                admin || recepcion;

            mnuCancelar.Visible =
                admin || recepcion;

            // La atención médica se realiza
            // desde el panel del doctor.
            mnuAtendida.Visible = false;

            // ACCESOS RÁPIDOS
            btnInicio.Visible =
                admin || recepcion || doctor;

            btnPacientes.Visible =
                admin || recepcion;

            btnDoctores.Visible = admin;

            btnAgendar.Visible =
                admin || recepcion;

            btnConsultas.Visible =
                admin || recepcion;

            btnCerrarSesion.Visible = true;
            mnuSesion.Visible = true;
        }

        // =====================================
        // ABRIR INICIO AUTOMÁTICAMENTE
        // =====================================
        private void FrmMenuPrincipal_Shown(
            object sender, EventArgs e)
        {
            MostrarInicio();
        }

        private void MostrarInicio()
        {
            // Cerrar ventanas secundarias.
            Form[] ventanas = this.MdiChildren;

            foreach (Form ventana in ventanas)
            {
                ventana.Close();
            }

            if (EsAdministrador)
            {
                AbrirVentana(
                    new FrmInicioAdministrador());
            }
            else if (EsRecepcionista)
            {
                AbrirVentana(
                    new FrmInicioRecepcionista(
                        usuarioActual));
            }
            else if (EsDoctor)
            {
                AbrirVentana(
                    new FrmInicioDoctor(
                        usuarioActual));
            }
            else
            {
                MessageBox.Show(
                    "No se reconoció el rol de la cuenta.",
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // =====================================
        // ABRIR FORMULARIOS DENTRO DEL MDI
        // =====================================
        private void AbrirVentana(Form nueva)
        {
            if (nueva == null)
                return;

            foreach (Form abierta in this.MdiChildren)
            {
                if (abierta.GetType() ==
                    nueva.GetType())
                {
                    abierta.WindowState =
                        FormWindowState.Maximized;

                    abierta.Activate();
                    abierta.BringToFront();

                    nueva.Dispose();
                    return;
                }
            }

            nueva.MdiParent = this;

            nueva.FormBorderStyle =
                FormBorderStyle.None;

            nueva.WindowState =
                FormWindowState.Maximized;

            nueva.Show();
            nueva.BringToFront();
        }

        // =====================================
        // COMPROBAR PERMISOS DE CADA MÓDULO
        // =====================================
        private bool TienePermiso(string nombre)
        {
            if (EsAdministrador)
            {
                return nombre !=
                    "FrmMarcarAtendida";
            }

            if (EsRecepcionista)
            {
                switch (nombre)
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

            // El doctor accede a su propia
            // agenda mediante FrmInicioDoctor.
            return false;
        }

        // =====================================
        // CREAR FORMULARIO
        // CORRECCIÓN DE AGENDAR CITA
        // =====================================
        private Form CrearFormulario(string nombre)
        {
            // IMPORTANTE:
            // El formulario de Agendar cita
            // necesita el usuario autenticado.
            if (nombre == "FrmAgendarCita")
            {
                return new FrmAgendarCita(
                    usuarioActual);
            }

            // En el proyecto la clase de
            // Especialidad está en singular.
            if (nombre ==
                "FrmMantenimientoEspecialidades")
            {
                nombre =
                    "FrmMantenimientoEspecialidad";
            }

            Type tipo = typeof(FrmMenuPrincipal)
                .Assembly.GetType(
                    "medicitass." + nombre);

            if (tipo == null ||
                !typeof(Form).IsAssignableFrom(tipo))
            {
                return null;
            }

            return Activator.CreateInstance(tipo)
                as Form;
        }

        // =====================================
        // ABRIR MÓDULOS
        // =====================================
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
                Form ventana =
                    CrearFormulario(nombre);

                if (ventana == null)
                {
                    MessageBox.Show(
                        "No se encontró el formulario:\n" +
                        nombre,
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
                    "No se pudo abrir el módulo:\n\n" +
                    ex.GetBaseException().Message,
                    "MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================
        // BOTONES LATERALES
        // =====================================
        private void btnInicio_Click(
            object sender, EventArgs e)
        {
            MostrarInicio();
        }

        private void btnPacientes_Click(
            object sender, EventArgs e)
        {
            AbrirModulo(
                "FrmMantenimientoPacientes");
        }

        private void btnDoctores_Click(
            object sender, EventArgs e)
        {
            AbrirModulo(
                "FrmMantenimientoDoctores");
        }

        private void btnAgendar_Click(
            object sender, EventArgs e)
        {
            AbrirModulo("FrmAgendarCita");
        }

        private void btnConsultas_Click(
            object sender, EventArgs e)
        {
            AbrirModulo(
                "FrmConsultaAgendaDoctor");
        }

        // =====================================
        // MENÚ SUPERIOR
        // =====================================
        private void mnuInicio_Click(
            object sender, EventArgs e)
        {
            MostrarInicio();
        }

        private void ModuloMenu_Click(
            object sender, EventArgs e)
        {
            ToolStripMenuItem opcion =
                sender as ToolStripMenuItem;

            if (opcion == null ||
                opcion.Tag == null)
                return;

            AbrirModulo(
                opcion.Tag.ToString());
        }

        // =====================================
        // CERRAR SESIÓN
        // =====================================
        private void btnCerrarSesion_Click(
            object sender, EventArgs e)
        {
            DialogResult respuesta =
                MessageBox.Show(
                    "¿Deseas cerrar sesión?",
                    "MediCitas",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (respuesta ==
                DialogResult.Yes)
            {
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

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
