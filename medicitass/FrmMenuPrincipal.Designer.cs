namespace medicitass
{
    partial class FrmMenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuInicio;
        private System.Windows.Forms.ToolStripMenuItem mnuMantenimientos;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultas;
        private System.Windows.Forms.ToolStripMenuItem mnuCitas;
        private System.Windows.Forms.ToolStripMenuItem mnuSesion;

        private System.Windows.Forms.ToolStripMenuItem mnuPacientes;
        private System.Windows.Forms.ToolStripMenuItem mnuDoctores;
        private System.Windows.Forms.ToolStripMenuItem mnuEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;

        private System.Windows.Forms.ToolStripMenuItem mnuAgendaFecha;
        private System.Windows.Forms.ToolStripMenuItem mnuAgendaDoctor;
        private System.Windows.Forms.ToolStripMenuItem mnuHistorial;
        private System.Windows.Forms.ToolStripMenuItem mnuDisponibilidad;
        private System.Windows.Forms.ToolStripMenuItem mnuBusqueda;
        private System.Windows.Forms.ToolStripMenuItem mnuCanceladas;

        private System.Windows.Forms.ToolStripMenuItem mnuAgendar;
        private System.Windows.Forms.ToolStripMenuItem mnuReprogramar;
        private System.Windows.Forms.ToolStripMenuItem mnuCancelar;
        private System.Windows.Forms.ToolStripMenuItem mnuAtendida;
        private System.Windows.Forms.ToolStripMenuItem mnuCerrarSesion;

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Panel pnlLateral;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblAccesos;

        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnDoctores;
        private System.Windows.Forms.Button btnAgendar;
        private System.Windows.Forms.Button btnConsultas;
        private System.Windows.Forms.Button btnCerrarSesion;

        private System.Windows.Forms.StatusStrip barraEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblEstado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuInicio = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMantenimientos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPacientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoctores = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();

            this.mnuAgendaFecha = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAgendaDoctor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHistorial = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDisponibilidad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBusqueda = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCanceladas = new System.Windows.Forms.ToolStripMenuItem();

            this.mnuAgendar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReprogramar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAtendida = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();

            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.pnlLateral = new System.Windows.Forms.Panel();

            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblAccesos = new System.Windows.Forms.Label();

            this.btnInicio = new System.Windows.Forms.Button();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.btnDoctores = new System.Windows.Forms.Button();
            this.btnAgendar = new System.Windows.Forms.Button();
            this.btnConsultas = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();

            this.barraEstado = new System.Windows.Forms.StatusStrip();
            this.lblEstado = new System.Windows.Forms.ToolStripStatusLabel();

            this.menuPrincipal.SuspendLayout();
            this.pnlEncabezado.SuspendLayout();
            this.pnlLateral.SuspendLayout();
            this.barraEstado.SuspendLayout();
            this.SuspendLayout();

            // MENU PRINCIPAL
            this.menuPrincipal.BackColor =
                System.Drawing.Color.FromArgb(230, 239, 245);
            this.menuPrincipal.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.menuPrincipal.Location =
                new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size =
                new System.Drawing.Size(1100, 28);

            this.menuPrincipal.Items.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.mnuInicio,
                    this.mnuMantenimientos,
                    this.mnuConsultas,
                    this.mnuCitas,
                    this.mnuSesion
                });

            // MENU INICIO
            this.mnuInicio.Name = "mnuInicio";
            this.mnuInicio.Text = "Inicio";
            this.mnuInicio.Click +=
                new System.EventHandler(this.mnuInicio_Click);

            // MENU MANTENIMIENTOS
            this.mnuMantenimientos.Name = "mnuMantenimientos";
            this.mnuMantenimientos.Text = "Mantenimientos";

            this.mnuMantenimientos.DropDownItems.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.mnuPacientes,
                    this.mnuDoctores,
                    this.mnuEspecialidades,
                    this.mnuUsuarios
                });

            // MENU CONSULTAS
            this.mnuConsultas.Name = "mnuConsultas";
            this.mnuConsultas.Text = "Consultas";

            this.mnuConsultas.DropDownItems.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.mnuAgendaFecha,
                    this.mnuAgendaDoctor,
                    this.mnuHistorial,
                    this.mnuDisponibilidad,
                    this.mnuBusqueda,
                    this.mnuCanceladas
                });

            // MENU CITAS
            this.mnuCitas.Name = "mnuCitas";
            this.mnuCitas.Text = "Citas";

            this.mnuCitas.DropDownItems.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.mnuAgendar,
                    this.mnuReprogramar,
                    this.mnuCancelar,
                    this.mnuAtendida
                });

            // MENU SESION
            this.mnuSesion.Name = "mnuSesion";
            this.mnuSesion.Text = "Sesión";
            this.mnuSesion.DropDownItems.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.mnuCerrarSesion
                });

            // MANTENIMIENTO PACIENTES
            this.mnuPacientes.Name = "mnuPacientes";
            this.mnuPacientes.Text = "Pacientes";
            this.mnuPacientes.Tag = "FrmMantenimientoPacientes";
            this.mnuPacientes.Click +=
                new System.EventHandler(this.ModuloMenu_Click);

            // MANTENIMIENTO DOCTORES
            this.mnuDoctores.Name = "mnuDoctores";
            this.mnuDoctores.Text = "Doctores";
            this.mnuDoctores.Tag = "FrmMantenimientoDoctores";
            this.mnuDoctores.Click +=
                new System.EventHandler(this.ModuloMenu_Click);

            // MANTENIMIENTO ESPECIALIDADES
            this.mnuEspecialidades.Name = "mnuEspecialidades";
            this.mnuEspecialidades.Text = "Especialidades";
            this.mnuEspecialidades.Tag =
                "FrmMantenimientoEspecialidades";
            this.mnuEspecialidades.Click +=
                new System.EventHandler(this.ModuloMenu_Click);

            // MANTENIMIENTO USUARIOS
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Text = "Usuarios";
            this.mnuUsuarios.Tag = "FrmMantenimientoUsuarios";
            this.mnuUsuarios.Click +=
                new System.EventHandler(this.ModuloMenu_Click);

            // CONSULTA AGENDA FECHA
            this.mnuAgendaFecha.Name = "mnuAgendaFecha";
            this.mnuAgendaFecha.Text = "Agenda por fecha";
            this.mnuAgendaFecha.Tag = "FrmConsultaAgendaFecha";
            this.mnuAgendaFecha.Click +=
                new System.EventHandler(this.ModuloMenu_Click);

            // CONSULTA AGENDA DOCTOR
            this.mnuAgendaDoctor.Name = "mnuAgendaDoctor";
            this.mnuAgendaDoctor.Text = "Agenda por doctor";
            this.mnuAgendaDoctor.Tag = "FrmConsultaAgendaDoctor";
            this.mnuAgendaDoctor.Click +=
                new System.EventHandler(this.ModuloMenu_Click);

            // CONSULTA HISTORIAL
            this.mnuHistorial.Name = "mnuHistorial";
            this.mnuHistorial.Text = "Historial por paciente";
            this.mnuHistorial.Tag = "FrmConsultaHistorialPaciente";
            this.mnuHistorial.Click +=
                new System.EventHandler(this.ModuloMenu_Click);

            // CONSULTA DISPONIBILIDAD
            this.mnuDisponibilidad.Name = "mnuDisponibilidad";
            this.mnuDisponibilidad.Text =
                "Disponibilidad de doctores";
            this.mnuDisponibilidad.Tag =
                "FrmConsultaDisponibilidad";
            this.mnuDisponibilidad.Click +=
                new System.EventHandler(this.ModuloMenu_Click);

            // BUSQUEDA GENERAL
            this.mnuBusqueda.Name = "mnuBusqueda";
            this.mnuBusqueda.Text = "Búsqueda general";
            this.mnuBusqueda.Tag = "FrmBusquedaGeneral";
            this.mnuBusqueda.Click +=
                new System.EventHandler(this.ModuloMenu_Click);

            // CONSULTA CITAS CANCELADAS
            this.mnuCanceladas.Name = "mnuCanceladas";
            this.mnuCanceladas.Text = "Citas canceladas";
            this.mnuCanceladas.Tag = "FrmConsultaCitasCanceladas";
            this.mnuCanceladas.Click +=
                new System.EventHandler(this.ModuloMenu_Click);

            // AGENDAR CITA
            this.mnuAgendar.Name = "mnuAgendar";
            this.mnuAgendar.Text = "Agendar cita";
            this.mnuAgendar.Tag = "FrmAgendarCita";
            this.mnuAgendar.Click +=
                new System.EventHandler(this.ModuloMenu_Click);

            // REPROGRAMAR CITA
            this.mnuReprogramar.Name = "mnuReprogramar";
            this.mnuReprogramar.Text = "Reprogramar cita";
            this.mnuReprogramar.Tag = "FrmReprogramarCita";
            this.mnuReprogramar.Click +=
                new System.EventHandler(this.ModuloMenu_Click);

            // CANCELAR CITA
            this.mnuCancelar.Name = "mnuCancelar";
            this.mnuCancelar.Text = "Cancelar cita";
            this.mnuCancelar.Tag = "FrmCancelarCita";
            this.mnuCancelar.Click +=
                new System.EventHandler(this.ModuloMenu_Click);

            // MARCAR ATENDIDA
            this.mnuAtendida.Name = "mnuAtendida";
            this.mnuAtendida.Text = "Marcar como atendida";
            this.mnuAtendida.Tag = "FrmMarcarAtendida";
            this.mnuAtendida.Click +=
                new System.EventHandler(this.ModuloMenu_Click);

            // CERRAR SESION
            this.mnuCerrarSesion.Name = "mnuCerrarSesion";
            this.mnuCerrarSesion.Text = "Cerrar sesión";
            this.mnuCerrarSesion.Click +=
                new System.EventHandler(
                    this.btnCerrarSesion_Click);

            // PANEL ENCABEZADO
            this.pnlEncabezado.BackColor =
                System.Drawing.Color.FromArgb(18, 61, 90);
            this.pnlEncabezado.Dock =
                System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location =
                new System.Drawing.Point(0, 28);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size =
                new System.Drawing.Size(1100, 105);

            // TITULO
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Text = "MediCitas";
            this.lblTitulo.ForeColor =
                System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font(
                "Segoe UI", 24F,
                System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location =
                new System.Drawing.Point(25, 12);
            this.lblTitulo.Name = "lblTitulo";

            // DESCRIPCION
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Text =
                "Sistema de Gestión de Citas Médicas";
            this.lblDescripcion.ForeColor =
                System.Drawing.Color.White;
            this.lblDescripcion.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescripcion.Location =
                new System.Drawing.Point(30, 68);
            this.lblDescripcion.Name = "lblDescripcion";

            // BIENVENIDA
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Text = "Bienvenido a MediCitas";
            this.lblBienvenida.ForeColor =
                System.Drawing.Color.White;
            this.lblBienvenida.Font = new System.Drawing.Font(
                "Segoe UI", 12F,
                System.Drawing.FontStyle.Bold);
            this.lblBienvenida.Location =
                new System.Drawing.Point(650, 25);
            this.lblBienvenida.Name = "lblBienvenida";

            // ROL
            this.lblRol.AutoSize = true;
            this.lblRol.Text = "Rol: Sin sesión";
            this.lblRol.ForeColor =
                System.Drawing.Color.White;
            this.lblRol.Location =
                new System.Drawing.Point(650, 60);
            this.lblRol.Name = "lblRol";

            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.lblDescripcion);
            this.pnlEncabezado.Controls.Add(this.lblBienvenida);
            this.pnlEncabezado.Controls.Add(this.lblRol);

            // PANEL LATERAL
            this.pnlLateral.BackColor =
                System.Drawing.Color.FromArgb(235, 243, 248);
            this.pnlLateral.Dock =
                System.Windows.Forms.DockStyle.Left;
            this.pnlLateral.Location =
                new System.Drawing.Point(0, 133);
            this.pnlLateral.Name = "pnlLateral";
            this.pnlLateral.Size =
                new System.Drawing.Size(220, 540);

            // TITULO DEL PANEL LATERAL
            this.lblAccesos.AutoSize = true;
            this.lblAccesos.Name = "lblAccesos";
            this.lblAccesos.Text = "ACCESOS RÁPIDOS";
            this.lblAccesos.Font = new System.Drawing.Font(
                "Segoe UI", 11F,
                System.Drawing.FontStyle.Bold);
            this.lblAccesos.Location =
                new System.Drawing.Point(20, 25);

            // BOTON INICIO
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Text = "Inicio";
            this.btnInicio.Location =
                new System.Drawing.Point(20, 75);
            this.btnInicio.Size =
                new System.Drawing.Size(180, 43);
            this.btnInicio.BackColor =
                System.Drawing.Color.SteelBlue;
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click +=
                new System.EventHandler(this.btnInicio_Click);

            // BOTON PACIENTES
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Text = "Pacientes";
            this.btnPacientes.Location =
                new System.Drawing.Point(20, 130);
            this.btnPacientes.Size =
                new System.Drawing.Size(180, 43);
            this.btnPacientes.BackColor =
                System.Drawing.Color.SteelBlue;
            this.btnPacientes.ForeColor =
                System.Drawing.Color.White;
            this.btnPacientes.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.FlatAppearance.BorderSize = 0;
            this.btnPacientes.UseVisualStyleBackColor = false;
            this.btnPacientes.Click +=
                new System.EventHandler(this.btnPacientes_Click);

            // BOTON DOCTORES
            this.btnDoctores.Name = "btnDoctores";
            this.btnDoctores.Text = "Doctores";
            this.btnDoctores.Location =
                new System.Drawing.Point(20, 185);
            this.btnDoctores.Size =
                new System.Drawing.Size(180, 43);
            this.btnDoctores.BackColor =
                System.Drawing.Color.SteelBlue;
            this.btnDoctores.ForeColor =
                System.Drawing.Color.White;
            this.btnDoctores.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnDoctores.FlatAppearance.BorderSize = 0;
            this.btnDoctores.UseVisualStyleBackColor = false;
            this.btnDoctores.Click +=
                new System.EventHandler(this.btnDoctores_Click);

            // BOTON AGENDAR CITA
            this.btnAgendar.Name = "btnAgendar";
            this.btnAgendar.Text = "Agendar cita";
            this.btnAgendar.Location =
                new System.Drawing.Point(20, 240);
            this.btnAgendar.Size =
                new System.Drawing.Size(180, 43);
            this.btnAgendar.BackColor =
                System.Drawing.Color.SeaGreen;
            this.btnAgendar.ForeColor =
                System.Drawing.Color.White;
            this.btnAgendar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnAgendar.FlatAppearance.BorderSize = 0;
            this.btnAgendar.UseVisualStyleBackColor = false;
            this.btnAgendar.Click +=
                new System.EventHandler(this.btnAgendar_Click);

            // BOTON CONSULTAS
            this.btnConsultas.Name = "btnConsultas";
            this.btnConsultas.Text = "Consultas";
            this.btnConsultas.Location =
                new System.Drawing.Point(20, 295);
            this.btnConsultas.Size =
                new System.Drawing.Size(180, 43);
            this.btnConsultas.BackColor =
                System.Drawing.Color.SteelBlue;
            this.btnConsultas.ForeColor =
                System.Drawing.Color.White;
            this.btnConsultas.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultas.FlatAppearance.BorderSize = 0;
            this.btnConsultas.UseVisualStyleBackColor = false;
            this.btnConsultas.Click +=
                new System.EventHandler(this.btnConsultas_Click);

            // BOTON CERRAR SESION
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.Location =
                new System.Drawing.Point(20, 375);
            this.btnCerrarSesion.Size =
                new System.Drawing.Size(180, 43);
            this.btnCerrarSesion.BackColor =
                System.Drawing.Color.Firebrick;
            this.btnCerrarSesion.ForeColor =
                System.Drawing.Color.White;
            this.btnCerrarSesion.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click +=
                new System.EventHandler(
                    this.btnCerrarSesion_Click);

            // AGREGAR CONTROLES AL PANEL
            this.pnlLateral.Controls.Add(this.lblAccesos);
            this.pnlLateral.Controls.Add(this.btnInicio);
            this.pnlLateral.Controls.Add(this.btnPacientes);
            this.pnlLateral.Controls.Add(this.btnDoctores);
            this.pnlLateral.Controls.Add(this.btnAgendar);
            this.pnlLateral.Controls.Add(this.btnConsultas);
            this.pnlLateral.Controls.Add(this.btnCerrarSesion);

            // BARRA DE ESTADO
            this.barraEstado.BackColor =
                System.Drawing.Color.FromArgb(18, 61, 90);
            this.barraEstado.Name = "barraEstado";
            this.barraEstado.Dock =
                System.Windows.Forms.DockStyle.Bottom;
            this.barraEstado.Items.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.lblEstado
                });

            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "MediCitas | Sistema activo";
            this.lblEstado.ForeColor =
                System.Drawing.Color.White;

            // CONFIGURACION GENERAL
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1100, 700);
            this.MinimumSize =
                new System.Drawing.Size(900, 600);
            this.BackColor = System.Drawing.Color.White;
            this.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.Name = "FrmMenuPrincipal";
            this.Text = "MediCitas - Menú Principal";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState =
                System.Windows.Forms.FormWindowState.Maximized;

            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuPrincipal;

            // Orden de controles
            this.Controls.Add(this.pnlLateral);
            this.Controls.Add(this.pnlEncabezado);
            this.Controls.Add(this.menuPrincipal);
            this.Controls.Add(this.barraEstado);

            // EVENTO CIERRE
            this.FormClosed +=
                new System.Windows.Forms.FormClosedEventHandler(
                    this.FrmMenuPrincipal_FormClosed);

            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlLateral.ResumeLayout(false);
            this.pnlLateral.PerformLayout();
            this.barraEstado.ResumeLayout(false);
            this.barraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
