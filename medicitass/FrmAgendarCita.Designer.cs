
namespace medicitass
{
    partial class FrmAgendarCita
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TableLayoutPanel tablaPrincipal;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Panel pnlCitas;

        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.Label lblTituloCitas;
        private System.Windows.Forms.Label lblEstado;

        private System.Windows.Forms.ComboBox cboPaciente;
        private System.Windows.Forms.ComboBox cboEspecialidad;
        private System.Windows.Forms.ComboBox cboDoctor;
        private System.Windows.Forms.ComboBox cboHorario;

        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnBuscarHorarios;
        private System.Windows.Forms.Button btnGuardar;

        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCita;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHorario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;

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
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.pnlCitas = new System.Windows.Forms.Panel();

            this.lblPaciente = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHorario = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.lblTituloCitas = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();

            this.cboPaciente = new System.Windows.Forms.ComboBox();
            this.cboEspecialidad = new System.Windows.Forms.ComboBox();
            this.cboDoctor = new System.Windows.Forms.ComboBox();
            this.cboHorario = new System.Windows.Forms.ComboBox();

            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnBuscarHorarios = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();

            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.colIdCita =
                new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHorario =
                new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaciente =
                new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoctor =
                new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlTitulo.SuspendLayout();
            this.tablaPrincipal.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            this.pnlCitas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)
                (this.dgvCitas)).BeginInit();
            this.SuspendLayout();

            // ENCABEZADO
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Dock =
                System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Height = 80;
            this.pnlTitulo.BackColor =
                System.Drawing.Color.FromArgb(21, 121, 194);

            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Agendamiento de Nueva Cita";
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location =
                new System.Drawing.Point(25, 19);
            this.lblTitulo.Font = new System.Drawing.Font(
                "Segoe UI", 20F,
                System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor =
                System.Drawing.Color.White;
            this.pnlTitulo.Controls.Add(this.lblTitulo);

            // DISTRIBUCIÓN
            this.tablaPrincipal.Name = "tablaPrincipal";
            this.tablaPrincipal.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.tablaPrincipal.Padding =
                new System.Windows.Forms.Padding(15);
            this.tablaPrincipal.ColumnCount = 2;
            this.tablaPrincipal.RowCount = 1;

            this.tablaPrincipal.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Percent, 40F));
            this.tablaPrincipal.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Percent, 60F));
            this.tablaPrincipal.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Percent, 100F));

            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.pnlDatos.AutoScroll = true;
            this.pnlDatos.Margin =
                new System.Windows.Forms.Padding(5);
            this.pnlDatos.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.BackColor = System.Drawing.Color.White;

            // PACIENTE
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Text = "Paciente:";
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Location =
                new System.Drawing.Point(20, 22);
            this.lblPaciente.Font = new System.Drawing.Font(
                "Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);

            this.cboPaciente.Name = "cboPaciente";
            this.cboPaciente.Location =
                new System.Drawing.Point(22, 52);
            this.cboPaciente.Size =
                new System.Drawing.Size(220, 29);
            this.cboPaciente.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            // ESPECIALIDAD
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Text = "Especialidad:";
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location =
                new System.Drawing.Point(258, 22);
            this.lblEspecialidad.Font = new System.Drawing.Font(
                "Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);

            this.cboEspecialidad.Name = "cboEspecialidad";
            this.cboEspecialidad.Location =
                new System.Drawing.Point(260, 52);
            this.cboEspecialidad.Size =
                new System.Drawing.Size(215, 29);
            this.cboEspecialidad.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEspecialidad.SelectedIndexChanged +=
                new System.EventHandler(
                    this.cboEspecialidad_SelectedIndexChanged);

            // DOCTOR
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Text = "Médico / Doctor:";
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Location =
                new System.Drawing.Point(20, 108);
            this.lblDoctor.Font = new System.Drawing.Font(
                "Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);

            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Location =
                new System.Drawing.Point(22, 139);
            this.cboDoctor.Size =
                new System.Drawing.Size(453, 29);
            this.cboDoctor.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoctor.SelectedIndexChanged +=
                new System.EventHandler(
                    this.cboDoctor_SelectedIndexChanged);

            // FECHA
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Text = "Fecha de la cita:";
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location =
                new System.Drawing.Point(20, 195);
            this.lblFecha.Font = new System.Drawing.Font(
                "Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);

            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Location =
                new System.Drawing.Point(22, 226);
            this.dtpFecha.Size =
                new System.Drawing.Size(453, 29);
            this.dtpFecha.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.ValueChanged +=
                new System.EventHandler(
                    this.dtpFecha_ValueChanged);

            // BOTÓN HORARIOS
            this.btnBuscarHorarios.Name = "btnBuscarHorarios";
            this.btnBuscarHorarios.Text = "Buscar horarios libres";
            this.btnBuscarHorarios.Location =
                new System.Drawing.Point(22, 308);
            this.btnBuscarHorarios.Size =
                new System.Drawing.Size(220, 43);
            this.btnBuscarHorarios.BackColor =
                System.Drawing.Color.FromArgb(23, 168, 187);
            this.btnBuscarHorarios.ForeColor =
                System.Drawing.Color.White;
            this.btnBuscarHorarios.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarHorarios.FlatAppearance.BorderSize = 0;
            this.btnBuscarHorarios.UseVisualStyleBackColor = false;
            this.btnBuscarHorarios.Click +=
                new System.EventHandler(
                    this.btnBuscarHorarios_Click);

            // BLOQUE DE HORARIO
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Text = "Bloque de horario:";
            this.lblHorario.AutoSize = true;
            this.lblHorario.Location =
                new System.Drawing.Point(258, 282);
            this.lblHorario.Font = new System.Drawing.Font(
                "Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);

            this.cboHorario.Name = "cboHorario";
            this.cboHorario.Location =
                new System.Drawing.Point(260, 315);
            this.cboHorario.Size =
                new System.Drawing.Size(215, 29);
            this.cboHorario.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            // MOTIVO
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Text = "Motivo de la consulta:";
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location =
                new System.Drawing.Point(20, 385);
            this.lblMotivo.Font = new System.Drawing.Font(
                "Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);

            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Location =
                new System.Drawing.Point(22, 419);
            this.txtMotivo.Size =
                new System.Drawing.Size(453, 130);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotivo.MaxLength = 255;

            // GUARDAR
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Text = "Guardar cita";
            this.btnGuardar.Location =
                new System.Drawing.Point(22, 575);
            this.btnGuardar.Size =
                new System.Drawing.Size(453, 45);
            this.btnGuardar.BackColor =
                System.Drawing.Color.SeaGreen;
            this.btnGuardar.ForeColor =
                System.Drawing.Color.White;
            this.btnGuardar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Click +=
                new System.EventHandler(this.btnGuardar_Click);

            this.pnlDatos.Controls.Add(this.lblPaciente);
            this.pnlDatos.Controls.Add(this.cboPaciente);
            this.pnlDatos.Controls.Add(this.lblEspecialidad);
            this.pnlDatos.Controls.Add(this.cboEspecialidad);
            this.pnlDatos.Controls.Add(this.lblDoctor);
            this.pnlDatos.Controls.Add(this.cboDoctor);
            this.pnlDatos.Controls.Add(this.lblFecha);
            this.pnlDatos.Controls.Add(this.dtpFecha);
            this.pnlDatos.Controls.Add(this.btnBuscarHorarios);
            this.pnlDatos.Controls.Add(this.lblHorario);
            this.pnlDatos.Controls.Add(this.cboHorario);
            this.pnlDatos.Controls.Add(this.lblMotivo);
            this.pnlDatos.Controls.Add(this.txtMotivo);
            this.pnlDatos.Controls.Add(this.btnGuardar);

            // PANEL DERECHO
            this.pnlCitas.Name = "pnlCitas";
            this.pnlCitas.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.pnlCitas.Margin =
                new System.Windows.Forms.Padding(5);
            this.pnlCitas.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCitas.BackColor = System.Drawing.Color.White;

            this.lblTituloCitas.Name = "lblTituloCitas";
            this.lblTituloCitas.Text =
                "Citas Programadas de la Fecha Elegida";
            this.lblTituloCitas.Dock =
                System.Windows.Forms.DockStyle.Top;
            this.lblTituloCitas.Height = 65;
            this.lblTituloCitas.Padding =
                new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblTituloCitas.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTituloCitas.Font = new System.Drawing.Font(
                "Segoe UI", 12F,
                System.Drawing.FontStyle.Bold);
            this.lblTituloCitas.ForeColor =
                System.Drawing.Color.FromArgb(19, 105, 164);

            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text =
                "Seleccione los datos de la cita.";
            this.lblEstado.Dock =
                System.Windows.Forms.DockStyle.Bottom;
            this.lblEstado.Height = 43;
            this.lblEstado.Padding =
                new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblEstado.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEstado.ForeColor =
                System.Drawing.Color.DimGray;

            // TABLA DE CITAS
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.dgvCitas.ReadOnly = true;
            this.dgvCitas.AllowUserToAddRows = false;
            this.dgvCitas.AllowUserToDeleteRows = false;
            this.dgvCitas.MultiSelect = false;
            this.dgvCitas.RowHeadersVisible = false;
            this.dgvCitas.BackgroundColor =
                System.Drawing.Color.White;
            this.dgvCitas.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCitas.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCitas.EnableHeadersVisualStyles = false;
            this.dgvCitas.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(18, 105, 160);
            this.dgvCitas.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;
            this.dgvCitas.ColumnHeadersHeight = 40;

            this.colIdCita.Name = "colIdCita";
            this.colIdCita.HeaderText = "Cita N°";
            this.colIdCita.FillWeight = 55;

            this.colHorario.Name = "colHorario";
            this.colHorario.HeaderText = "Horario";
            this.colHorario.FillWeight = 115;

            this.colPaciente.Name = "colPaciente";
            this.colPaciente.HeaderText = "Paciente";
            this.colPaciente.FillWeight = 130;

            this.colDoctor.Name = "colDoctor";
            this.colDoctor.HeaderText = "Doctor";
            this.colDoctor.FillWeight = 130;

            this.colMotivo.Name = "colMotivo";
            this.colMotivo.HeaderText = "Motivo";
            this.colMotivo.FillWeight = 150;

            this.dgvCitas.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[]
                {
                    this.colIdCita,
                    this.colHorario,
                    this.colPaciente,
                    this.colDoctor,
                    this.colMotivo
                });

            this.pnlCitas.Controls.Add(this.dgvCitas);
            this.pnlCitas.Controls.Add(this.lblEstado);
            this.pnlCitas.Controls.Add(this.lblTituloCitas);

            this.tablaPrincipal.Controls.Add(this.pnlDatos, 0, 0);
            this.tablaPrincipal.Controls.Add(this.pnlCitas, 1, 0);

            // FORMULARIO
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize =
                new System.Drawing.Size(1300, 800);
            this.MinimumSize =
                new System.Drawing.Size(1120, 700);
            this.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.BackColor =
                System.Drawing.Color.FromArgb(245, 248, 251);
            this.Name = "FrmAgendarCita";
            this.Text = "MediCitas - Agendar Cita Médica";

            this.Controls.Add(this.tablaPrincipal);
            this.Controls.Add(this.pnlTitulo);
            this.Load += new System.EventHandler(
                this.FrmAgendarCita_Load);

            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.tablaPrincipal.ResumeLayout(false);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlCitas.ResumeLayout(false);
            this.pnlCitas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)
                (this.dgvCitas)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
