
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
        private System.Windows.Forms.ToolStripMenuItem mnuRoles;
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
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuInicio = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMantenimientos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPacientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoctores = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAgendaFecha = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAgendaDoctor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHistorial = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDisponibilidad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBusqueda = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCanceladas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCitas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAgendar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReprogramar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAtendida = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.pnlLateral = new System.Windows.Forms.Panel();
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
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.menuPrincipal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(62)))), ((int)(((byte)(92)))));
            this.menuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInicio,
            this.mnuMantenimientos,
            this.mnuConsultas,
            this.mnuCitas,
            this.mnuSesion});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.menuPrincipal.Size = new System.Drawing.Size(1200, 37);
            this.menuPrincipal.TabIndex = 3;
            // 
            // mnuInicio
            // 
            this.mnuInicio.Name = "mnuInicio";
            this.mnuInicio.Size = new System.Drawing.Size(90, 27);
            this.mnuInicio.Text = "⌂  Inicio";
            this.mnuInicio.Click += new System.EventHandler(this.mnuInicio_Click);
            // 
            // mnuMantenimientos
            // 
            this.mnuMantenimientos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPacientes,
            this.mnuDoctores,
            this.mnuEspecialidades,
            this.mnuRoles,
            this.mnuUsuarios});
            this.mnuMantenimientos.Name = "mnuMantenimientos";
            this.mnuMantenimientos.Size = new System.Drawing.Size(181, 27);
            this.mnuMantenimientos.Text = "⚙  Mantenimientos";
            // 
            // mnuPacientes
            // 
            this.mnuPacientes.Name = "mnuPacientes";
            this.mnuPacientes.Size = new System.Drawing.Size(227, 28);
            this.mnuPacientes.Tag = "FrmMantenimientoPacientes";
            this.mnuPacientes.Text = "♙  Pacientes";
            this.mnuPacientes.Click += new System.EventHandler(this.ModuloMenu_Click);
            // 
            // mnuDoctores
            // 
            this.mnuDoctores.Name = "mnuDoctores";
            this.mnuDoctores.Size = new System.Drawing.Size(227, 28);
            this.mnuDoctores.Tag = "FrmMantenimientoDoctores";
            this.mnuDoctores.Text = "✚  Doctores";
            this.mnuDoctores.Click += new System.EventHandler(this.ModuloMenu_Click);
            // 
            // mnuEspecialidades
            // 
            this.mnuEspecialidades.Name = "mnuEspecialidades";
            this.mnuEspecialidades.Size = new System.Drawing.Size(227, 28);
            this.mnuEspecialidades.Tag = "FrmMantenimientoEspecialidades";
            this.mnuEspecialidades.Text = "✧  Especialidades";
            this.mnuEspecialidades.Click += new System.EventHandler(this.ModuloMenu_Click);
            // 
            // mnuRoles
            // 
            this.mnuRoles.Name = "mnuRoles";
            this.mnuRoles.Size = new System.Drawing.Size(227, 28);
            this.mnuRoles.Tag = "FrmMantenimientoRoles";
            this.mnuRoles.Text = "◇  Roles";
            this.mnuRoles.Click += new System.EventHandler(this.ModuloMenu_Click);
            // 
            // mnuUsuarios
            // 
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Size = new System.Drawing.Size(227, 28);
            this.mnuUsuarios.Tag = "FrmMantenimientoUsuarios";
            this.mnuUsuarios.Text = "♙  Usuarios";
            this.mnuUsuarios.Click += new System.EventHandler(this.ModuloMenu_Click);
            // 
            // mnuConsultas
            // 
            this.mnuConsultas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAgendaFecha,
            this.mnuAgendaDoctor,
            this.mnuHistorial,
            this.mnuDisponibilidad,
            this.mnuBusqueda,
            this.mnuCanceladas});
            this.mnuConsultas.Name = "mnuConsultas";
            this.mnuConsultas.Size = new System.Drawing.Size(121, 27);
            this.mnuConsultas.Text = "⌕  Consultas";
            // 
            // mnuAgendaFecha
            // 
            this.mnuAgendaFecha.Name = "mnuAgendaFecha";
            this.mnuAgendaFecha.Size = new System.Drawing.Size(282, 28);
            this.mnuAgendaFecha.Tag = "FrmConsultaAgendaFecha";
            this.mnuAgendaFecha.Text = "▦  Agenda por fecha";
            this.mnuAgendaFecha.Click += new System.EventHandler(this.ModuloMenu_Click);
            // 
            // mnuAgendaDoctor
            // 
            this.mnuAgendaDoctor.Name = "mnuAgendaDoctor";
            this.mnuAgendaDoctor.Size = new System.Drawing.Size(282, 28);
            this.mnuAgendaDoctor.Tag = "FrmConsultaAgendaDoctor";
            this.mnuAgendaDoctor.Text = "✚  Agenda por doctor";
            this.mnuAgendaDoctor.Click += new System.EventHandler(this.ModuloMenu_Click);
            // 
            // mnuHistorial
            // 
            this.mnuHistorial.Name = "mnuHistorial";
            this.mnuHistorial.Size = new System.Drawing.Size(282, 28);
            this.mnuHistorial.Tag = "FrmConsultaHistorialPaciente";
            this.mnuHistorial.Text = "▤  Historial de pacientes";
            this.mnuHistorial.Click += new System.EventHandler(this.ModuloMenu_Click);
            // 
            // mnuDisponibilidad
            // 
            this.mnuDisponibilidad.Name = "mnuDisponibilidad";
            this.mnuDisponibilidad.Size = new System.Drawing.Size(282, 28);
            this.mnuDisponibilidad.Tag = "FrmConsultaDisponibilidad";
            this.mnuDisponibilidad.Text = "◷  Disponibilidad";
            this.mnuDisponibilidad.Click += new System.EventHandler(this.ModuloMenu_Click);
            // 
            // mnuBusqueda
            // 
            
            // 
            // mnuCanceladas
            // 
            this.mnuCanceladas.Name = "mnuCanceladas";
            this.mnuCanceladas.Size = new System.Drawing.Size(282, 28);
            this.mnuCanceladas.Tag = "FrmConsultaCitasCanceladas";
            this.mnuCanceladas.Text = "×  Citas canceladas";
            this.mnuCanceladas.Click += new System.EventHandler(this.ModuloMenu_Click);
            // 
            // mnuCitas
            // 
            this.mnuCitas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAgendar,
            this.mnuReprogramar,
            this.mnuCancelar,
            this.mnuAtendida});
            this.mnuCitas.Name = "mnuCitas";
            this.mnuCitas.Size = new System.Drawing.Size(86, 27);
            this.mnuCitas.Text = "▦  Citas";
            // 
            // mnuAgendar
            // 
            this.mnuAgendar.Name = "mnuAgendar";
            this.mnuAgendar.Size = new System.Drawing.Size(250, 28);
            this.mnuAgendar.Tag = "FrmAgendarCita";
            this.mnuAgendar.Text = "＋  Agendar cita";
            this.mnuAgendar.Click += new System.EventHandler(this.ModuloMenu_Click);
            // 
            // mnuReprogramar
            // 
            this.mnuReprogramar.Name = "mnuReprogramar";
            this.mnuReprogramar.Size = new System.Drawing.Size(250, 28);
            this.mnuReprogramar.Tag = "FrmReprogramarCita";
            this.mnuReprogramar.Text = "↻  Reprogramar cita";
            this.mnuReprogramar.Click += new System.EventHandler(this.ModuloMenu_Click);
            // 
            // mnuCancelar
            // 
            this.mnuCancelar.Name = "mnuCancelar";
            this.mnuCancelar.Size = new System.Drawing.Size(250, 28);
            this.mnuCancelar.Tag = "FrmCancelarCita";
            this.mnuCancelar.Text = "×  Cancelar cita";
            this.mnuCancelar.Click += new System.EventHandler(this.ModuloMenu_Click);
            // 
            // mnuAtendida
            // 
            this.mnuAtendida.Name = "mnuAtendida";
            this.mnuAtendida.Size = new System.Drawing.Size(250, 28);
            this.mnuAtendida.Tag = "FrmMarcarAtendida";
            this.mnuAtendida.Text = "✓  Marcar atendida";
            this.mnuAtendida.Click += new System.EventHandler(this.ModuloMenu_Click);
            // 
            // mnuSesion
            // 
            this.mnuSesion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCerrarSesion});
            this.mnuSesion.Name = "mnuSesion";
            this.mnuSesion.Size = new System.Drawing.Size(100, 27);
            this.mnuSesion.Text = "♙  Sesión";
            // 
            // mnuCerrarSesion
            // 
            this.mnuCerrarSesion.Name = "mnuCerrarSesion";
            this.mnuCerrarSesion.Size = new System.Drawing.Size(218, 28);
            this.mnuCerrarSesion.Text = "⇥  Cerrar sesión";
            this.mnuCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(62)))), ((int)(((byte)(92)))));
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.lblDescripcion);
            this.pnlEncabezado.Controls.Add(this.lblBienvenida);
            this.pnlEncabezado.Controls.Add(this.lblRol);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 37);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1200, 110);
            this.pnlEncabezado.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(25, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(269, 54);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "✚  MediCitas";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion.Location = new System.Drawing.Point(35, 76);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(289, 23);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Sistema de Gestión de Citas Médicas";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.ForeColor = System.Drawing.Color.White;
            this.lblBienvenida.Location = new System.Drawing.Point(1620, 23);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(219, 25);
            this.lblBienvenida.TabIndex = 2;
            this.lblBienvenida.Text = "Bienvenido a MediCitas";
            // 
            // lblRol
            // 
            this.lblRol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRol.ForeColor = System.Drawing.Color.White;
            this.lblRol.Location = new System.Drawing.Point(1620, 66);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(38, 23);
            this.lblRol.TabIndex = 3;
            this.lblRol.Text = "Rol:";
            // 
            // pnlLateral
            // 
            this.pnlLateral.AutoScroll = true;
            this.pnlLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.pnlLateral.Controls.Add(this.lblAccesos);
            this.pnlLateral.Controls.Add(this.btnInicio);
            this.pnlLateral.Controls.Add(this.btnPacientes);
            this.pnlLateral.Controls.Add(this.btnDoctores);
            this.pnlLateral.Controls.Add(this.btnAgendar);
            this.pnlLateral.Controls.Add(this.btnConsultas);
            this.pnlLateral.Controls.Add(this.btnCerrarSesion);
            this.pnlLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLateral.Location = new System.Drawing.Point(0, 147);
            this.pnlLateral.Name = "pnlLateral";
            this.pnlLateral.Size = new System.Drawing.Size(205, 577);
            this.pnlLateral.TabIndex = 1;
            // 
            // lblAccesos
            // 
            this.lblAccesos.AutoSize = true;
            this.lblAccesos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAccesos.Location = new System.Drawing.Point(15, 21);
            this.lblAccesos.Name = "lblAccesos";
            this.lblAccesos.Size = new System.Drawing.Size(164, 23);
            this.lblAccesos.TabIndex = 0;
            this.lblAccesos.Text = "ACCESOS RÁPIDOS";
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.SteelBlue;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.Location = new System.Drawing.Point(15, 70);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(175, 45);
            this.btnInicio.TabIndex = 1;
            this.btnInicio.Text = "⌂   Inicio";
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnPacientes
            // 
            this.btnPacientes.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPacientes.FlatAppearance.BorderSize = 0;
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.ForeColor = System.Drawing.Color.White;
            this.btnPacientes.Location = new System.Drawing.Point(15, 126);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(175, 45);
            this.btnPacientes.TabIndex = 2;
            this.btnPacientes.Text = "♙   Pacientes";
            this.btnPacientes.UseVisualStyleBackColor = false;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // btnDoctores
            // 
            this.btnDoctores.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDoctores.FlatAppearance.BorderSize = 0;
            this.btnDoctores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoctores.ForeColor = System.Drawing.Color.White;
            this.btnDoctores.Location = new System.Drawing.Point(15, 182);
            this.btnDoctores.Name = "btnDoctores";
            this.btnDoctores.Size = new System.Drawing.Size(175, 45);
            this.btnDoctores.TabIndex = 3;
            this.btnDoctores.Text = "✚   Doctores";
            this.btnDoctores.UseVisualStyleBackColor = false;
            this.btnDoctores.Click += new System.EventHandler(this.btnDoctores_Click);
            // 
            // btnAgendar
            // 
            this.btnAgendar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAgendar.FlatAppearance.BorderSize = 0;
            this.btnAgendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgendar.ForeColor = System.Drawing.Color.White;
            this.btnAgendar.Location = new System.Drawing.Point(15, 238);
            this.btnAgendar.Name = "btnAgendar";
            this.btnAgendar.Size = new System.Drawing.Size(175, 45);
            this.btnAgendar.TabIndex = 4;
            this.btnAgendar.Text = "＋   Agendar cita";
            this.btnAgendar.UseVisualStyleBackColor = false;
            this.btnAgendar.Click += new System.EventHandler(this.btnAgendar_Click);
            // 
            // btnConsultas
            // 
            this.btnConsultas.BackColor = System.Drawing.Color.SteelBlue;
            this.btnConsultas.FlatAppearance.BorderSize = 0;
            this.btnConsultas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultas.ForeColor = System.Drawing.Color.White;
            this.btnConsultas.Location = new System.Drawing.Point(15, 294);
            this.btnConsultas.Name = "btnConsultas";
            this.btnConsultas.Size = new System.Drawing.Size(175, 45);
            this.btnConsultas.TabIndex = 5;
            this.btnConsultas.Text = "⌕   Consultas";
            this.btnConsultas.UseVisualStyleBackColor = false;
            this.btnConsultas.Click += new System.EventHandler(this.btnConsultas_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Firebrick;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(15, 375);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(175, 45);
            this.btnCerrarSesion.TabIndex = 6;
            this.btnCerrarSesion.Text = "⇥   Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // barraEstado
            // 
            this.barraEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(62)))), ((int)(((byte)(92)))));
            this.barraEstado.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.barraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEstado});
            this.barraEstado.Location = new System.Drawing.Point(0, 724);
            this.barraEstado.Name = "barraEstado";
            this.barraEstado.Size = new System.Drawing.Size(1200, 26);
            this.barraEstado.SizingGrip = false;
            this.barraEstado.TabIndex = 4;
            // 
            // lblEstado
            // 
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(183, 20);
            this.lblEstado.Text = "MediCitas | Sistema activo";
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlLateral);
            this.Controls.Add(this.pnlEncabezado);
            this.Controls.Add(this.menuPrincipal);
            this.Controls.Add(this.barraEstado);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuPrincipal;
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediCitas - Menú Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMenuPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.Shown += new System.EventHandler(this.FrmMenuPrincipal_Shown);
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
    }
}
