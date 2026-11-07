namespace medicitass
{
    partial class FrmReprogramarCita
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvCitasVigentes = new System.Windows.Forms.DataGridView();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.cboUsuario = new System.Windows.Forms.ComboBox();
            this.btnBuscarHorarios = new System.Windows.Forms.Button();
            this.lblNuevaHora = new System.Windows.Forms.Label();
            this.cboNuevaHora = new System.Windows.Forms.ComboBox();
            this.lblNuevaFecha = new System.Windows.Forms.Label();
            this.dtpNuevaFecha = new System.Windows.Forms.DateTimePicker();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.lblHorarioActual = new System.Windows.Forms.Label();
            this.txtHorarioActual = new System.Windows.Forms.TextBox();
            this.lblIdCita = new System.Windows.Forms.Label();
            this.txtIdCita = new System.Windows.Forms.TextBox();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnReprogramar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitasVigentes)).BeginInit();
            this.pnlFormulario.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1040, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(18, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(434, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Reprogramación de Citas Programadas";
            // 
            // dgvCitasVigentes
            // 
            this.dgvCitasVigentes.AllowUserToAddRows = false;
            this.dgvCitasVigentes.AllowUserToDeleteRows = false;
            this.dgvCitasVigentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCitasVigentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCitasVigentes.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCitasVigentes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCitasVigentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitasVigentes.EnableHeadersVisualStyles = false;
            this.dgvCitasVigentes.Location = new System.Drawing.Point(18, 75);
            this.dgvCitasVigentes.MultiSelect = false;
            this.dgvCitasVigentes.Name = "dgvCitasVigentes";
            this.dgvCitasVigentes.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCitasVigentes.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCitasVigentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCitasVigentes.Size = new System.Drawing.Size(560, 545);
            this.dgvCitasVigentes.TabIndex = 1;
            this.dgvCitasVigentes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCitasVigentes_CellClick);
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormulario.Controls.Add(this.lblUsuario);
            this.pnlFormulario.Controls.Add(this.cboUsuario);
            this.pnlFormulario.Controls.Add(this.btnBuscarHorarios);
            this.pnlFormulario.Controls.Add(this.lblNuevaHora);
            this.pnlFormulario.Controls.Add(this.cboNuevaHora);
            this.pnlFormulario.Controls.Add(this.lblNuevaFecha);
            this.pnlFormulario.Controls.Add(this.dtpNuevaFecha);
            this.pnlFormulario.Controls.Add(this.lblDoctor);
            this.pnlFormulario.Controls.Add(this.txtDoctor);
            this.pnlFormulario.Controls.Add(this.lblPaciente);
            this.pnlFormulario.Controls.Add(this.txtPaciente);
            this.pnlFormulario.Controls.Add(this.lblHorarioActual);
            this.pnlFormulario.Controls.Add(this.txtHorarioActual);
            this.pnlFormulario.Controls.Add(this.lblIdCita);
            this.pnlFormulario.Controls.Add(this.txtIdCita);
            this.pnlFormulario.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFormulario.Location = new System.Drawing.Point(590, 75);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Size = new System.Drawing.Size(432, 480);
            this.pnlFormulario.TabIndex = 2;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.Location = new System.Drawing.Point(20, 395);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(155, 17);
            this.lblUsuario.TabIndex = 13;
            this.lblUsuario.Text = "Usuario que Registra:";
            // 
            // cboUsuario
            // 
            this.cboUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuario.FormattingEnabled = true;
            this.cboUsuario.Location = new System.Drawing.Point(23, 417);
            this.cboUsuario.Name = "cboUsuario";
            this.cboUsuario.Size = new System.Drawing.Size(385, 25);
            this.cboUsuario.TabIndex = 14;
            // 
            // btnBuscarHorarios
            // 
            this.btnBuscarHorarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnBuscarHorarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarHorarios.FlatAppearance.BorderSize = 0;
            this.btnBuscarHorarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarHorarios.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnBuscarHorarios.ForeColor = System.Drawing.Color.White;
            this.btnBuscarHorarios.Location = new System.Drawing.Point(23, 345);
            this.btnBuscarHorarios.Name = "btnBuscarHorarios";
            this.btnBuscarHorarios.Size = new System.Drawing.Size(180, 28);
            this.btnBuscarHorarios.TabIndex = 10;
            this.btnBuscarHorarios.Text = "Buscar Horarios Libres";
            this.btnBuscarHorarios.UseVisualStyleBackColor = false;
            this.btnBuscarHorarios.Click += new System.EventHandler(this.btnBuscarHorarios_Click);
            // 
            // lblNuevaHora
            // 
            this.lblNuevaHora.AutoSize = true;
            this.lblNuevaHora.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNuevaHora.Location = new System.Drawing.Point(220, 320);
            this.lblNuevaHora.Name = "lblNuevaHora";
            this.lblNuevaHora.Size = new System.Drawing.Size(130, 17);
            this.lblNuevaHora.TabIndex = 11;
            this.lblNuevaHora.Text = "Nuevo Bloque Hora:";
            // 
            // cboNuevaHora
            // 
            this.cboNuevaHora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNuevaHora.FormattingEnabled = true;
            this.cboNuevaHora.Location = new System.Drawing.Point(223, 345);
            this.cboNuevaHora.Name = "cboNuevaHora";
            this.cboNuevaHora.Size = new System.Drawing.Size(185, 25);
            this.cboNuevaHora.TabIndex = 12;
            // 
            // lblNuevaFecha
            // 
            this.lblNuevaFecha.AutoSize = true;
            this.lblNuevaFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNuevaFecha.Location = new System.Drawing.Point(20, 255);
            this.lblNuevaFecha.Name = "lblNuevaFecha";
            this.lblNuevaFecha.Size = new System.Drawing.Size(130, 17);
            this.lblNuevaFecha.TabIndex = 8;
            this.lblNuevaFecha.Text = "Nueva Fecha Cita:";
            // 
            // dtpNuevaFecha
            // 
            this.dtpNuevaFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNuevaFecha.Location = new System.Drawing.Point(23, 277);
            this.dtpNuevaFecha.Name = "dtpNuevaFecha";
            this.dtpNuevaFecha.Size = new System.Drawing.Size(385, 25);
            this.dtpNuevaFecha.TabIndex = 9;
            this.dtpNuevaFecha.ValueChanged += new System.EventHandler(this.dtpNuevaFecha_ValueChanged);
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDoctor.Location = new System.Drawing.Point(20, 190);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(127, 17);
            this.lblDoctor.TabIndex = 6;
            this.lblDoctor.Text = "Médico Asignado:";
            // 
            // txtDoctor
            // 
            this.txtDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.txtDoctor.Location = new System.Drawing.Point(23, 212);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.ReadOnly = true;
            this.txtDoctor.Size = new System.Drawing.Size(385, 25);
            this.txtDoctor.TabIndex = 7;
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPaciente.Location = new System.Drawing.Point(20, 125);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(64, 17);
            this.lblPaciente.TabIndex = 4;
            this.lblPaciente.Text = "Paciente:";
            // 
            // txtPaciente
            // 
            this.txtPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.txtPaciente.Location = new System.Drawing.Point(23, 147);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.ReadOnly = true;
            this.txtPaciente.Size = new System.Drawing.Size(385, 25);
            this.txtPaciente.TabIndex = 5;
            // 
            // lblHorarioActual
            // 
            this.lblHorarioActual.AutoSize = true;
            this.lblHorarioActual.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHorarioActual.Location = new System.Drawing.Point(145, 60);
            this.lblHorarioActual.Name = "lblHorarioActual";
            this.lblHorarioActual.Size = new System.Drawing.Size(155, 17);
            this.lblHorarioActual.TabIndex = 2;
            this.lblHorarioActual.Text = "Fecha / Horario Actual:";
            // 
            // txtHorarioActual
            // 
            this.txtHorarioActual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.txtHorarioActual.Location = new System.Drawing.Point(148, 82);
            this.txtHorarioActual.Name = "txtHorarioActual";
            this.txtHorarioActual.ReadOnly = true;
            this.txtHorarioActual.Size = new System.Drawing.Size(260, 25);
            this.txtHorarioActual.TabIndex = 3;
            // 
            // lblIdCita
            // 
            this.lblIdCita.AutoSize = true;
            this.lblIdCita.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblIdCita.Location = new System.Drawing.Point(20, 60);
            this.lblIdCita.Name = "lblIdCita";
            this.lblIdCita.Size = new System.Drawing.Size(84, 17);
            this.lblIdCita.TabIndex = 0;
            this.lblIdCita.Text = "Código Cita:";
            // 
            // txtIdCita
            // 
            this.txtIdCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.txtIdCita.Location = new System.Drawing.Point(23, 82);
            this.txtIdCita.Name = "txtIdCita";
            this.txtIdCita.ReadOnly = true;
            this.txtIdCita.Size = new System.Drawing.Size(105, 25);
            this.txtIdCita.TabIndex = 1;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBotones.BackColor = System.Drawing.Color.White;
            this.pnlBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBotones.Controls.Add(this.btnLimpiar);
            this.pnlBotones.Controls.Add(this.btnReprogramar);
            this.pnlBotones.Location = new System.Drawing.Point(590, 565);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(432, 60);
            this.pnlBotones.TabIndex = 3;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(265, 12);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(145, 34);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Cancelar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnReprogramar
            // 
            this.btnReprogramar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnReprogramar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReprogramar.FlatAppearance.BorderSize = 0;
            this.btnReprogramar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReprogramar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReprogramar.ForeColor = System.Drawing.Color.Black;
            this.btnReprogramar.Location = new System.Drawing.Point(20, 12);
            this.btnReprogramar.Name = "btnReprogramar";
            this.btnReprogramar.Size = new System.Drawing.Size(230, 34);
            this.btnReprogramar.TabIndex = 0;
            this.btnReprogramar.Text = "↻ Confirmar Reprogramación";
            this.btnReprogramar.UseVisualStyleBackColor = false;
            this.btnReprogramar.Click += new System.EventHandler(this.btnReprogramar_Click);
            // 
            // FrmReprogramarCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1040, 640);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.dgvCitasVigentes);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmReprogramarCita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediCitas - Reprogramar Cita Médica";
            this.Load += new System.EventHandler(this.FrmReprogramarCita_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitasVigentes)).EndInit();
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvCitasVigentes;
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblIdCita;
        private System.Windows.Forms.TextBox txtIdCita;
        private System.Windows.Forms.Label lblHorarioActual;
        private System.Windows.Forms.TextBox txtHorarioActual;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.Label lblNuevaFecha;
        private System.Windows.Forms.DateTimePicker dtpNuevaFecha;
        private System.Windows.Forms.Label lblNuevaHora;
        private System.Windows.Forms.ComboBox cboNuevaHora;
        private System.Windows.Forms.Button btnBuscarHorarios;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ComboBox cboUsuario;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnReprogramar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}