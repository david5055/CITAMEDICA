using MediCitas;
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

        // Constructor para diseño y vista previa
        public FrmMenuPrincipal()
        {
            InitializeComponent();

            usuarioActual = "Admin";
            rolActual = "Administrador";
            formularioLogin = null;

            ConfigurarSesion();
        }

        // Constructor para usuarios autenticados
        public FrmMenuPrincipal(string usuario, string rol, Form login = null)
        {
            InitializeComponent();

            usuarioActual = usuario;
            rolActual = rol;
            formularioLogin = login;

            ConfigurarSesion();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }

        private void ConfigurarSesion()
        {
            lblBienvenida.Text = "Bienvenido, " + (string.IsNullOrEmpty(usuarioActual) ? "Usuario" : usuarioActual);
            lblRol.Text = "Rol: " + rolActual;
            lblEstado.Text = "MediCitas | Usuario: " + usuarioActual + " | " + rolActual;

            bool admin = string.Equals(rolActual, "Administrador", StringComparison.OrdinalIgnoreCase);
            bool recepcion = string.Equals(rolActual, "Recepcionista", StringComparison.OrdinalIgnoreCase);
            bool doctor = string.Equals(rolActual, "Doctor", StringComparison.OrdinalIgnoreCase) ||
                         string.Equals(rolActual, "Médico", StringComparison.OrdinalIgnoreCase);

            // MANTENIMIENTOS
            mnuPacientes.Visible = admin || recepcion;
            mnuDoctores.Visible = admin;
            mnuEspecialidades.Visible = admin;
            mnuUsuarios.Visible = admin;

            // CONSULTAS
            mnuAgendaFecha.Visible = admin || recepcion || doctor;
            mnuAgendaDoctor.Visible = admin || recepcion || doctor;
            mnuHistorial.Visible = admin || recepcion || doctor;
            mnuDisponibilidad.Visible = admin || recepcion;
            mnuBusqueda.Visible = admin || recepcion || doctor;
            mnuCanceladas.Visible = admin || recepcion;

            // CITAS (TRANSACCIONALES)
            mnuAgendar.Visible = admin || recepcion;
            mnuReprogramar.Visible = admin || recepcion;
            mnuCancelar.Visible = admin || recepcion;
            mnuAtendida.Visible = admin || recepcion || doctor;

            // ACCESOS RÁPIDOS LATERALES
            btnPacientes.Visible = admin || recepcion;
            btnDoctores.Visible = admin;
            btnAgendar.Visible = admin || recepcion;
            btnConsultas.Visible = admin || recepcion || doctor;

            // MENÚS SUPERIORES
            mnuMantenimientos.Visible = admin || recepcion;
            mnuConsultas.Visible = admin || recepcion || doctor;
            mnuCitas.Visible = admin || recepcion || doctor;
        }

        // METODO MEJORADO PARA ABRIR VENTANAS Y TRAERLAS AL FRENTE
        private void AbrirVentana(Form ventana)
        {
            // Si el formulario ya está abierto, lo activa y trae al frente
            foreach (Form abierta in this.MdiChildren)
            {
                if (abierta.GetType() == ventana.GetType())
                {
                    if (abierta.WindowState == FormWindowState.Minimized)
                        abierta.WindowState = FormWindowState.Normal;

                    abierta.BringToFront();
                    abierta.Activate();
                    ventana.Dispose();
                    return;
                }
            }

            // Configurar como hijo MDI y mostrar al frente
            ventana.MdiParent = this;
            ventana.StartPosition = FormStartPosition.CenterScreen;
            ventana.Show();
            ventana.BringToFront();
            ventana.Activate();
        }

        // RUTEO DE FORMULARIOS REALES
        private void AbrirModulo(string nombreFormulario, string titulo)
        {
            if (rolActual == "Sin sesión")
            {
                MessageBox.Show("Debe iniciar sesión para acceder a este módulo.", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form ventana = null;

            switch (nombreFormulario)
            {
                // --- MANTENIMIENTOS ---
                case "FrmMantenimientoPacientes":
                    ventana = new FrmMantenimientoPacientes();
                    break;

                case "FrmMantenimientoDoctores":
                    ventana = new FrmMantenimientoDoctores();
                    break;

                case "FrmMantenimientoEspecialidades":
                case "FrmMantenimientoEspecialidad":
                    ventana = new FrmMantenimientoEspecialidad(); // Nombre en singular según el proyecto
                    break;

                case "FrmMantenimientoUsuarios":
                    ventana = new FrmMantenimientoUsuarios();
                    break;

                // --- CONSULTAS ---
                case "FrmConsultaAgendaFecha":
                    ventana = new FrmConsultaAgendaFecha();
                    break;

                case "FrmConsultaAgendaDoctor":
                    ventana = new FrmConsultaAgendaDoctor();
                    break;

                case "FrmConsultaHistorialPaciente":
                    ventana = new FrmConsultaHistorialPaciente();
                    break;

                case "FrmConsultaDisponibilidad":
                    ventana = new FrmConsultaDisponibilidad();
                    break;

                case "FrmBusquedaGeneral":
                    ventana = new FrmBusquedaGeneral();
                    break;

                case "FrmConsultaCitasCanceladas":
                    ventana = new FrmConsultaCitasCanceladas();
                    break;

                // --- PROCESOS TRANSACCIONALES ---
                case "FrmAgendarCita":
                    ventana = new FrmAgendarCita();
                    break;

                case "FrmReprogramarCita":
                    ventana = new FrmReprogramarCita();
                    break;

                case "FrmCancelarCita":
                    ventana = new FrmCancelarCita();
                    break;

                case "FrmMarcarAtendida":
                    ventana = new FrmMarcarAtendida();
                    break;

                default:
                    MessageBox.Show($"El formulario '{nombreFormulario}' no está registrado.", "Módulo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }

            if (ventana != null)
            {
                AbrirVentana(ventana);
            }
        }

        private void MostrarInicio()
        {
            foreach (Form ventana in MdiChildren)
            {
                ventana.Close();
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            MostrarInicio();
        }

        // BOTONES DE ACCESO RÁPIDO
        private void btnPacientes_Click(object sender, EventArgs e)
        {
            AbrirModulo("FrmMantenimientoPacientes", "Mantenimiento de Pacientes");
        }

        private void btnDoctores_Click(object sender, EventArgs e)
        {
            AbrirModulo("FrmMantenimientoDoctores", "Mantenimiento de Doctores");
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            AbrirModulo("FrmAgendarCita", "Agendar Cita Médica");
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            AbrirModulo("FrmConsultaAgendaDoctor", "Agenda por Doctor");
        }

        // OPCIONES DEL MENÚ SUPERIOR
        private void ModuloMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null || item.Tag == null) return;

            AbrirModulo(item.Tag.ToString(), item.Text);
        }

        private void mnuInicio_Click(object sender, EventArgs e)
        {
            MostrarInicio();
        }

        // CERRAR SESIÓN
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Desea cerrar la sesión actual?",
                "MediCitas - Cerrar Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FrmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (formularioLogin != null && !formularioLogin.IsDisposed)
            {
                formularioLogin.Show();
            }
        }
    }
}
