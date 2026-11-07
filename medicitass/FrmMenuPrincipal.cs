
using System;
using System.Drawing;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmMenuPrincipal : Form
    {
        private string usuarioActual;
        private string rolActual;
        private Form formularioLogin;

        // Constructor para diseño y vista previa.
        // No concede permisos de acceso.
        public FrmMenuPrincipal()
        {
            InitializeComponent();

            usuarioActual = "";
            rolActual = "Sin sesión";
            formularioLogin = null;

            ConfigurarSesion();
        }

        // Constructor para usuarios autenticados
        public FrmMenuPrincipal(
            string usuario,
            string rol,
            Form login = null)
        {
            InitializeComponent();

            usuarioActual = usuario;
            rolActual = rol;
            formularioLogin = login;

            ConfigurarSesion();
        }

        private void ConfigurarSesion()
        {
            lblBienvenida.Text = "Bienvenido, " +
                (string.IsNullOrEmpty(usuarioActual)
                    ? "Usuario" : usuarioActual);

            lblRol.Text = "Rol: " + rolActual;

            lblEstado.Text = "MediCitas | Usuario: " +
                usuarioActual + " | " + rolActual;

            bool admin = string.Equals(
                rolActual, "Administrador",
                StringComparison.OrdinalIgnoreCase);

            bool recepcion = string.Equals(
                rolActual, "Recepcionista",
                StringComparison.OrdinalIgnoreCase);

            bool doctor = string.Equals(
                rolActual, "Doctor",
                StringComparison.OrdinalIgnoreCase) ||
                string.Equals(
                rolActual, "Médico",
                StringComparison.OrdinalIgnoreCase);

            // MANTENIMIENTOS
            mnuPacientes.Visible = admin || recepcion;
            mnuDoctores.Visible = admin;
            mnuEspecialidades.Visible = admin;
            mnuUsuarios.Visible = admin;

            // CONSULTAS
            mnuAgendaFecha.Visible =
                admin || recepcion || doctor;

            mnuAgendaDoctor.Visible =
                admin || recepcion || doctor;

            mnuHistorial.Visible =
                admin || recepcion || doctor;

            mnuDisponibilidad.Visible =
                admin || recepcion;

            mnuBusqueda.Visible =
                admin || recepcion || doctor;

            mnuCanceladas.Visible =
                admin || recepcion;

            // CITAS
            mnuAgendar.Visible = admin || recepcion;
            mnuReprogramar.Visible = admin || recepcion;
            mnuCancelar.Visible = admin || recepcion;
            mnuAtendida.Visible =
                admin || recepcion || doctor;

            // ACCESOS RÁPIDOS
            btnPacientes.Visible = admin || recepcion;
            btnDoctores.Visible = admin;
            btnAgendar.Visible = admin || recepcion;
            btnConsultas.Visible =
                admin || recepcion || doctor;

            // MENÚS SUPERIORES
            mnuMantenimientos.Visible = admin || recepcion;
            mnuConsultas.Visible =
                admin || recepcion || doctor;
            mnuCitas.Visible =
                admin || recepcion || doctor;
        }

        // ABRIR FORMULARIO EN CONTENEDOR MDI
        private void AbrirVentana(Form ventana)
        {
            foreach (Form abierta in this.MdiChildren)
            {
                if (abierta.Name == ventana.Name)
                {
                    abierta.Activate();
                    ventana.Dispose();
                    return;
                }
            }

            ventana.MdiParent = this;
            ventana.WindowState = FormWindowState.Maximized;
            ventana.Show();
        }

        // ABRIR MÓDULO
        // Por ahora muestra una ventana temporal.
        private void AbrirModulo(
            string nombreFormulario,
            string titulo)
        {
            if (rolActual == "Sin sesión")
            {
                MessageBox.Show(
                    "Debe iniciar sesión.",
                    "Acceso restringido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Form ventana = new Form();

            ventana.Name = nombreFormulario;
            ventana.Text = titulo;
            ventana.BackColor = Color.White;

            Label lblMensaje = new Label();

            lblMensaje.Text =
                titulo +
                "\n\nAquí se mostrará el formulario real.";

            lblMensaje.Font = new Font(
                "Segoe UI", 15, FontStyle.Bold);

            lblMensaje.AutoSize = true;
            lblMensaje.Location = new Point(40, 40);

            ventana.Controls.Add(lblMensaje);

            AbrirVentana(ventana);
        }

        // MOSTRAR INICIO
        private void MostrarInicio()
        {
            foreach (Form ventana in MdiChildren)
            {
                ventana.Close();
            }
        }

        private void btnInicio_Click(
            object sender, EventArgs e)
        {
            MostrarInicio();
        }

        // BOTÓN PACIENTES
        private void btnPacientes_Click(
            object sender, EventArgs e)
        {
            AbrirModulo(
                "FrmMantenimientoPacientes",
                "Mantenimiento de Pacientes");
        }

        // BOTÓN DOCTORES
        private void btnDoctores_Click(
            object sender, EventArgs e)
        {
            AbrirModulo(
                "FrmMantenimientoDoctores",
                "Mantenimiento de Doctores");
        }

        // BOTÓN AGENDAR
        private void btnAgendar_Click(
            object sender, EventArgs e)
        {
            AbrirModulo(
                "FrmAgendarCita",
                "Agendar Cita Médica");
        }

        // BOTÓN CONSULTAS
        private void btnConsultas_Click(
            object sender, EventArgs e)
        {
            AbrirModulo(
                "FrmConsultaAgendaDoctor",
                "Agenda por Doctor");
        }

        // OPCIONES DEL MENÚ SUPERIOR
        private void ModuloMenu_Click(
            object sender, EventArgs e)
        {
            ToolStripMenuItem item =
                sender as ToolStripMenuItem;

            if (item == null || item.Tag == null)
                return;

            AbrirModulo(
                item.Tag.ToString(),
                item.Text);
        }

        // INICIO DESDE MENÚ
        private void mnuInicio_Click(
            object sender, EventArgs e)
        {
            MostrarInicio();
        }

        // CERRAR SESIÓN
        private void btnCerrarSesion_Click(
            object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Desea cerrar la sesión?",
                "MediCitas",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // REGRESAR AL LOGIN
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
