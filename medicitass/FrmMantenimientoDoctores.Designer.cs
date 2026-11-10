
namespace medicitass
{
    partial class FrmMantenimientoDoctores
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;

        private System.Windows.Forms.TableLayoutPanel tablaPrincipal;
        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.Panel pnlDerecha;

        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.GroupBox grpHorarios;

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.Label lblJunta;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Label lblBuscar;

        private System.Windows.Forms.TextBox txtIdDoctor;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtJunta;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtBuscar;

        private System.Windows.Forms.ComboBox cboEspecialidad;
        private System.Windows.Forms.CheckedListBox clbDias;

        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.DateTimePicker dtpHoraFin;

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnInactivar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnRefrescar;

        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.DataGridView dgvDoctores;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();

            this.tablaPrincipal =
                new System.Windows.Forms.TableLayoutPanel();

            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.pnlDerecha = new System.Windows.Forms.Panel();

            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.grpHorarios = new System.Windows.Forms.GroupBox();

            this.lblId = new System.Windows.Forms.Label();
            this.lblNombres = new System.Windows.Forms.Label();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.lblJunta = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblDias = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblFin = new System.Windows.Forms.Label();
            this.lblNota = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();

            this.txtIdDoctor = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtJunta = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();

            this.cboEspecialidad = new System.Windows.Forms.ComboBox();
            this.clbDias = new System.Windows.Forms.CheckedListBox();

            this.dtpHoraInicio =
                new System.Windows.Forms.DateTimePicker();

            this.dtpHoraFin =
                new System.Windows.Forms.DateTimePicker();

            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnInactivar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();

            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.dgvDoctores = new System.Windows.Forms.DataGridView();

            this.pnlTitulo.SuspendLayout();
            this.tablaPrincipal.SuspendLayout();
            this.pnlIzquierda.SuspendLayout();
            this.pnlDerecha.SuspendLayout();
            this.grpDatos.SuspendLayout();
            this.grpHorarios.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvDoctores)).BeginInit();

            this.SuspendLayout();

            // =====================================
            // ENCABEZADO
            // =====================================
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Dock =
                System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Height = 78;
            this.pnlTitulo.BackColor =
                System.Drawing.Color.FromArgb(19, 105, 164);

            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text =
                "Gestión de Personal Médico (Doctores)";
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font(
                "Segoe UI", 20F,
                System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor =
                System.Drawing.Color.White;
            this.lblTitulo.Location =
                new System.Drawing.Point(25, 17);

            this.pnlTitulo.Controls.Add(this.lblTitulo);

            // =====================================
            // DISTRIBUCIÓN PRINCIPAL
            // =====================================
            this.tablaPrincipal.Name = "tablaPrincipal";
            this.tablaPrincipal.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.tablaPrincipal.Padding =
                new System.Windows.Forms.Padding(10);
            this.tablaPrincipal.ColumnCount = 2;
            this.tablaPrincipal.RowCount = 1;

            this.tablaPrincipal.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Absolute, 440F));

            this.tablaPrincipal.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Percent, 100F));

            this.tablaPrincipal.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Percent, 100F));

            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.pnlIzquierda.AutoScroll = true;

            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.tablaPrincipal.Controls.Add(
                this.pnlIzquierda, 0, 0);

            this.tablaPrincipal.Controls.Add(
                this.pnlDerecha, 1, 0);

            // =====================================
            // DATOS DEL DOCTOR
            // =====================================
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Text = "Información del médico";
            this.grpDatos.Location =
                new System.Drawing.Point(5, 5);
            this.grpDatos.Size =
                new System.Drawing.Size(420, 365);

            // CÓDIGO
            this.lblId.Name = "lblId";
            this.lblId.Text = "Código:";
            this.lblId.AutoSize = true;
            this.lblId.Location =
                new System.Drawing.Point(16, 28);

            this.txtIdDoctor.Name = "txtIdDoctor";
            this.txtIdDoctor.Location =
                new System.Drawing.Point(18, 51);
            this.txtIdDoctor.Size =
                new System.Drawing.Size(170, 26);
            this.txtIdDoctor.ReadOnly = true;
            this.txtIdDoctor.BackColor =
                System.Drawing.Color.FromArgb(238, 242, 246);

            // NOMBRES
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Text = "Nombres:";
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location =
                new System.Drawing.Point(16, 91);

            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Location =
                new System.Drawing.Point(18, 114);
            this.txtNombres.Size =
                new System.Drawing.Size(185, 27);

            // APELLIDOS
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Text = "Apellidos:";
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Location =
                new System.Drawing.Point(215, 91);

            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Location =
                new System.Drawing.Point(217, 114);
            this.txtApellidos.Size =
                new System.Drawing.Size(185, 27);

            // ESPECIALIDAD
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Text =
                "Especialidad médica:";
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location =
                new System.Drawing.Point(16, 155);

            this.cboEspecialidad.Name = "cboEspecialidad";
            this.cboEspecialidad.Location =
                new System.Drawing.Point(18, 178);
            this.cboEspecialidad.Size =
                new System.Drawing.Size(384, 28);
            this.cboEspecialidad.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            // JUNTA
            this.lblJunta.Name = "lblJunta";
            this.lblJunta.Text = "N° Junta Vigilancia:";
            this.lblJunta.AutoSize = true;
            this.lblJunta.Location =
                new System.Drawing.Point(16, 220);

            this.txtJunta.Name = "txtJunta";
            this.txtJunta.Location =
                new System.Drawing.Point(18, 243);
            this.txtJunta.Size =
                new System.Drawing.Size(185, 27);

            // TELÉFONO
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location =
                new System.Drawing.Point(215, 220);

            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Location =
                new System.Drawing.Point(217, 243);
            this.txtTelefono.Size =
                new System.Drawing.Size(185, 27);

            // CORREO
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Text = "Correo electrónico:";
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Location =
                new System.Drawing.Point(16, 287);

            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Location =
                new System.Drawing.Point(18, 310);
            this.txtCorreo.Size =
                new System.Drawing.Size(384, 27);

            this.grpDatos.Controls.Add(this.lblId);
            this.grpDatos.Controls.Add(this.txtIdDoctor);
            this.grpDatos.Controls.Add(this.lblNombres);
            this.grpDatos.Controls.Add(this.txtNombres);
            this.grpDatos.Controls.Add(this.lblApellidos);
            this.grpDatos.Controls.Add(this.txtApellidos);
            this.grpDatos.Controls.Add(this.lblEspecialidad);
            this.grpDatos.Controls.Add(this.cboEspecialidad);
            this.grpDatos.Controls.Add(this.lblJunta);
            this.grpDatos.Controls.Add(this.txtJunta);
            this.grpDatos.Controls.Add(this.lblTelefono);
            this.grpDatos.Controls.Add(this.txtTelefono);
            this.grpDatos.Controls.Add(this.lblCorreo);
            this.grpDatos.Controls.Add(this.txtCorreo);

            // =====================================
            // JORNADAS DE ATENCIÓN
            // =====================================
            this.grpHorarios.Name = "grpHorarios";
            this.grpHorarios.Text =
                "Días y horarios de atención";
            this.grpHorarios.Location =
                new System.Drawing.Point(5, 380);
            this.grpHorarios.Size =
                new System.Drawing.Size(420, 292);

            this.lblDias.Name = "lblDias";
            this.lblDias.Text =
                "Seleccione todos los días que atiende:";
            this.lblDias.AutoSize = true;
            this.lblDias.Location =
                new System.Drawing.Point(16, 28);

            this.clbDias.Name = "clbDias";
            this.clbDias.Location =
                new System.Drawing.Point(18, 55);
            this.clbDias.Size =
                new System.Drawing.Size(384, 130);
            this.clbDias.CheckOnClick = true;
            this.clbDias.MultiColumn = true;
            this.clbDias.ColumnWidth = 165;
            this.clbDias.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            // HORA INICIO
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Text = "Hora de inicio:";
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location =
                new System.Drawing.Point(16, 199);

            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraInicio.CustomFormat = "hh:mm tt";
            this.dtpHoraInicio.ShowUpDown = true;
            this.dtpHoraInicio.Location =
                new System.Drawing.Point(18, 224);
            this.dtpHoraInicio.Size =
                new System.Drawing.Size(180, 29);

            // HORA FIN
            this.lblFin.Name = "lblFin";
            this.lblFin.Text = "Hora de finalización:";
            this.lblFin.AutoSize = true;
            this.lblFin.Location =
                new System.Drawing.Point(213, 199);

            this.dtpHoraFin.Name = "dtpHoraFin";
            this.dtpHoraFin.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraFin.CustomFormat = "hh:mm tt";
            this.dtpHoraFin.ShowUpDown = true;
            this.dtpHoraFin.Location =
                new System.Drawing.Point(215, 224);
            this.dtpHoraFin.Size =
                new System.Drawing.Size(187, 29);

            this.grpHorarios.Controls.Add(this.lblDias);
            this.grpHorarios.Controls.Add(this.clbDias);
            this.grpHorarios.Controls.Add(this.lblInicio);
            this.grpHorarios.Controls.Add(this.dtpHoraInicio);
            this.grpHorarios.Controls.Add(this.lblFin);
            this.grpHorarios.Controls.Add(this.dtpHoraFin);

            // =====================================
            // NOTA
            // =====================================
            this.lblNota.Name = "lblNota";
            this.lblNota.Text =
                "El horario seleccionado se aplicará " +
                "a todos los días marcados.";
            this.lblNota.Location =
                new System.Drawing.Point(12, 680);
            this.lblNota.Size =
                new System.Drawing.Size(403, 35);
            this.lblNota.ForeColor =
                System.Drawing.Color.DimGray;

            // =====================================
            // BOTONES
            // =====================================
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location =
                new System.Drawing.Point(10, 733);
            this.btnGuardar.Size =
                new System.Drawing.Size(98, 40);
            this.btnGuardar.BackColor =
                System.Drawing.Color.ForestGreen;
            this.btnGuardar.ForeColor =
                System.Drawing.Color.White;
            this.btnGuardar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click +=
                new System.EventHandler(this.btnGuardar_Click);

            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Location =
                new System.Drawing.Point(115, 733);
            this.btnModificar.Size =
                new System.Drawing.Size(98, 40);
            this.btnModificar.BackColor =
                System.Drawing.Color.Goldenrod;
            this.btnModificar.ForeColor =
                System.Drawing.Color.Black;
            this.btnModificar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click +=
                new System.EventHandler(this.btnModificar_Click);

            this.btnInactivar.Name = "btnInactivar";
            this.btnInactivar.Text = "Inactivar";
            this.btnInactivar.Location =
                new System.Drawing.Point(220, 733);
            this.btnInactivar.Size =
                new System.Drawing.Size(98, 40);
            this.btnInactivar.BackColor =
                System.Drawing.Color.Firebrick;
            this.btnInactivar.ForeColor =
                System.Drawing.Color.White;
            this.btnInactivar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnInactivar.UseVisualStyleBackColor = false;
            this.btnInactivar.Click +=
                new System.EventHandler(this.btnInactivar_Click);

            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Location =
                new System.Drawing.Point(325, 733);
            this.btnLimpiar.Size =
                new System.Drawing.Size(98, 40);
            this.btnLimpiar.BackColor =
                System.Drawing.Color.SlateGray;
            this.btnLimpiar.ForeColor =
                System.Drawing.Color.White;
            this.btnLimpiar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click +=
                new System.EventHandler(this.btnLimpiar_Click);

            this.pnlIzquierda.Controls.Add(this.grpDatos);
            this.pnlIzquierda.Controls.Add(this.grpHorarios);
            this.pnlIzquierda.Controls.Add(this.lblNota);
            this.pnlIzquierda.Controls.Add(this.btnGuardar);
            this.pnlIzquierda.Controls.Add(this.btnModificar);
            this.pnlIzquierda.Controls.Add(this.btnInactivar);
            this.pnlIzquierda.Controls.Add(this.btnLimpiar);

            // =====================================
            // BÚSQUEDA
            // =====================================
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Dock =
                System.Windows.Forms.DockStyle.Top;
            this.pnlBusqueda.Height = 80;
            this.pnlBusqueda.BackColor =
                System.Drawing.Color.White;

            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Text = "Buscar:";
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location =
                new System.Drawing.Point(12, 27);

            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Location =
                new System.Drawing.Point(83, 22);
            this.txtBuscar.Size =
                new System.Drawing.Size(205, 27);

            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Location =
                new System.Drawing.Point(300, 17);
            this.btnBuscar.Size =
                new System.Drawing.Size(90, 38);
            this.btnBuscar.BackColor =
                System.Drawing.Color.FromArgb(19, 105, 164);
            this.btnBuscar.ForeColor =
                System.Drawing.Color.White;
            this.btnBuscar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click +=
                new System.EventHandler(this.btnBuscar_Click);

            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.Location =
                new System.Drawing.Point(399, 17);
            this.btnRefrescar.Size =
                new System.Drawing.Size(95, 38);
            this.btnRefrescar.BackColor =
                System.Drawing.Color.FromArgb(23, 160, 180);
            this.btnRefrescar.ForeColor =
                System.Drawing.Color.White;
            this.btnRefrescar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click +=
                new System.EventHandler(this.btnRefrescar_Click);

            this.pnlBusqueda.Controls.Add(this.lblBuscar);
            this.pnlBusqueda.Controls.Add(this.txtBuscar);
            this.pnlBusqueda.Controls.Add(this.btnBuscar);
            this.pnlBusqueda.Controls.Add(this.btnRefrescar);

            // =====================================
            // TABLA DE DOCTORES
            // =====================================
            this.dgvDoctores.Name = "dgvDoctores";
            this.dgvDoctores.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.dgvDoctores.BackgroundColor =
                System.Drawing.Color.White;
            this.dgvDoctores.ReadOnly = true;
            this.dgvDoctores.AllowUserToAddRows = false;
            this.dgvDoctores.AllowUserToDeleteRows = false;
            this.dgvDoctores.MultiSelect = false;
            this.dgvDoctores.RowHeadersVisible = false;

            this.dgvDoctores.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvDoctores.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            this.dgvDoctores.EnableHeadersVisualStyles = false;
            this.dgvDoctores.ColumnHeadersHeight = 42;

            this.dgvDoctores.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(19, 105, 164);

            this.dgvDoctores.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;

            this.dgvDoctores.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(239, 246, 251);

            this.dgvDoctores.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvDoctores_CellClick);

            this.pnlDerecha.Controls.Add(this.dgvDoctores);
            this.pnlDerecha.Controls.Add(this.pnlBusqueda);

            // =====================================
            // FORMULARIO
            // =====================================
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1300, 850);

            this.MinimumSize =
                new System.Drawing.Size(1080, 650);

            this.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.BackColor =
                System.Drawing.Color.FromArgb(246, 249, 252);

            this.Name = "FrmMantenimientoDoctores";
            this.Text = "MediCitas - Mantenimiento de Doctores";

            this.Controls.Add(this.tablaPrincipal);
            this.Controls.Add(this.pnlTitulo);

            this.Load +=
                new System.EventHandler(
                    this.FrmMantenimientoDoctores_Load);

            // FINALIZAR
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.grpHorarios.ResumeLayout(false);
            this.grpHorarios.PerformLayout();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.pnlIzquierda.ResumeLayout(false);
            this.pnlDerecha.ResumeLayout(false);
            this.tablaPrincipal.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvDoctores)).EndInit();

            this.ResumeLayout(false);
        }
    }
}
