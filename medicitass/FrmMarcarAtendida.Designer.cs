namespace medicitass
{
    partial class FrmMarcarAtendida
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
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.cboDoctorFiltro = new System.Windows.Forms.ComboBox();
            this.lblDoctorFiltro = new System.Windows.Forms.Label();
            this.dtpFechaHoy = new System.Windows.Forms.DateTimePicker();
            this.lblFechaHoy = new System.Windows.Forms.Label();
            this.dgvCitasHoy = new System.Windows.Forms.DataGridView();
            this.pnlAtencion = new System.Windows.Forms.Panel();
            this.lblTituloPanel = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnMarcarAtendida = new System.Windows.Forms.Button();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.cboUsuario = new System.Windows.Forms.ComboBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.lblIdCita = new System.Windows.Forms.Label();
            this.txtIdCita = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitasHoy)).BeginInit();
            this.pnlAtencion.SuspendLayout();
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
            this.lblTitulo.Size = new System.Drawing.Size(496, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registro de Atención Médica (Marcar Atendida)";
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltro.BackColor = System.Drawing.Color.White;
            this.pnlFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFiltro.Controls.Add(this.btnRefrescar);
            this.pnlFiltro.Controls.Add(this.cboDoctorFiltro);
            this.pnlFiltro.Controls.Add(this.lblDoctorFiltro);
            this.pnlFiltro.Controls.Add(this.dtpFechaHoy);
            this.pnlFiltro.Controls.Add(this.lblFechaHoy);
            this.pnlFiltro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.pnlFiltro.Location = new System.Drawing.Point(18, 75);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(1004, 55);
            this.pnlFiltro.TabIndex = 1;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefrescar.FlatAppearance.BorderSize = 0;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(885, 13);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(100, 27);
            this.btnRefrescar.TabIndex = 4;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // cboDoctorFiltro
            // 
            this.cboDoctorFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoctorFiltro.FormattingEnabled = true;
            this.cboDoctorFiltro.Location = new System.Drawing.Point(400, 14);
            this.cboDoctorFiltro.Name = "cboDoctorFiltro";
            this.cboDoctorFiltro.Size = new System.Drawing.Size(465, 25);
            this.cboDoctorFiltro.TabIndex = 3;
            this.cboDoctorFiltro.SelectedIndexChanged += new System.EventHandler(this.cboDoctorFiltro_SelectedIndexChanged);
            // 
            // lblDoctorFiltro
            // 
            this.lblDoctorFiltro.AutoSize = true;
            this.lblDoctorFiltro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDoctorFiltro.Location = new System.Drawing.Point(310, 18);
            this.lblDoctorFiltro.Name = "lblDoctorFiltro";
            this.lblDoctorFiltro.Size = new System.Drawing.Size(84, 15);
            this.lblDoctorFiltro.TabIndex = 2;
            this.lblDoctorFiltro.Text = "Filtrar Doctor:";
            // 
            // dtpFechaHoy
            // 
            this.dtpFechaHoy.Enabled = false;
            this.dtpFechaHoy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHoy.Location = new System.Drawing.Point(155, 14);
            this.dtpFechaHoy.Name = "dtpFechaHoy";
            this.dtpFechaHoy.Size = new System.Drawing.Size(130, 24);
            this.dtpFechaHoy.TabIndex = 1;
            // 
            // lblFechaHoy
            // 
            this.lblFechaHoy.AutoSize = true;
            this.lblFechaHoy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaHoy.Location = new System.Drawing.Point(12, 18);
            this.lblFechaHoy.Name = "lblFechaHoy";
            this.lblFechaHoy.Size = new System.Drawing.Size(137, 15);
            this.lblFechaHoy.TabIndex = 0;
            this.lblFechaHoy.Text = "Jornada del Día (Hoy):";
            // 
            // dgvCitasHoy
            // 
            this.dgvCitasHoy.AllowUserToAddRows = false;
            this.dgvCitasHoy.AllowUserToDeleteRows = false;
            this.dgvCitasHoy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCitasHoy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCitasHoy.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCitasHoy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCitasHoy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitasHoy.EnableHeadersVisualStyles = false;
            this.dgvCitasHoy.Location = new System.Drawing.Point(18, 140);
            this.dgvCitasHoy.MultiSelect = false;
            this.dgvCitasHoy.Name = "dgvCitasHoy";
            this.dgvCitasHoy.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCitasHoy.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCitasHoy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCitasHoy.Size = new System.Drawing.Size(560, 480);
            this.dgvCitasHoy.TabIndex = 2;
            this.dgvCitasHoy.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCitasHoy_CellClick);
            // 
            // pnlAtencion
            // 
            this.pnlAtencion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAtencion.BackColor = System.Drawing.Color.White;
            this.pnlAtencion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAtencion.Controls.Add(this.lblTituloPanel);
            this.pnlAtencion.Controls.Add(this.btnLimpiar);
            this.pnlAtencion.Controls.Add(this.btnMarcarAtendida);
            this.pnlAtencion.Controls.Add(this.lblObservaciones);
            this.pnlAtencion.Controls.Add(this.txtObservaciones);
            this.pnlAtencion.Controls.Add(this.lblUsuario);
            this.pnlAtencion.Controls.Add(this.cboUsuario);
            this.pnlAtencion.Controls.Add(this.lblDoctor);
            this.pnlAtencion.Controls.Add(this.txtDoctor);
            this.pnlAtencion.Controls.Add(this.lblPaciente);
            this.pnlAtencion.Controls.Add(this.txtPaciente);
            this.pnlAtencion.Controls.Add(this.lblIdCita);
            this.pnlAtencion.Controls.Add(this.txtIdCita);
            this.pnlAtencion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlAtencion.Location = new System.Drawing.Point(590, 140);
            this.pnlAtencion.Name = "pnlAtencion";
            this.pnlAtencion.Size = new System.Drawing.Size(432, 480);
            this.pnlAtencion.TabIndex = 3;
            // 
            // lblTituloPanel
            // 
            this.lblTituloPanel.AutoSize = true;
            this.lblTituloPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTituloPanel.Location = new System.Drawing.Point(14, 10);
            this.lblTituloPanel.Name = "lblTituloPanel";
            this.lblTituloPanel.Size = new System.Drawing.Size(269, 20);
            this.lblTituloPanel.TabIndex = 0;
            this.lblTituloPanel.Text = "Detalle y Observaciones de la Consulta";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(282, 420);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(130, 40);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Cancelar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnMarcarAtendida
            // 
            this.btnMarcarAtendida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnMarcarAtendida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarcarAtendida.FlatAppearance.BorderSize = 0;
            this.btnMarcarAtendida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcarAtendida.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMarcarAtendida.ForeColor = System.Drawing.Color.White;
            this.btnMarcarAtendida.Location = new System.Drawing.Point(18, 420);
            this.btnMarcarAtendida.Name = "btnMarcarAtendida";
            this.btnMarcarAtendida.Size = new System.Drawing.Size(255, 40);
            this.btnMarcarAtendida.TabIndex = 11;
            this.btnMarcarAtendida.Text = "✓ Guardar y Marcar Atendida";
            this.btnMarcarAtendida.UseVisualStyleBackColor = false;
            this.btnMarcarAtendida.Click += new System.EventHandler(this.btnMarcarAtendida_Click);
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblObservaciones.Location = new System.Drawing.Point(15, 215);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(237, 17);
            this.lblObservaciones.TabIndex = 9;
            this.lblObservaciones.Text = "Observaciones Clínicas / Diagnóstico:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(18, 237);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(394, 165);
            this.txtObservaciones.TabIndex = 10;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.Location = new System.Drawing.Point(15, 155);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(155, 17);
            this.lblUsuario.TabIndex = 7;
            this.lblUsuario.Text = "Usuario que Registra:";
            // 
            // cboUsuario
            // 
            this.cboUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuario.FormattingEnabled = true;
            this.cboUsuario.Location = new System.Drawing.Point(18, 177);
            this.cboUsuario.Name = "cboUsuario";
            this.cboUsuario.Size = new System.Drawing.Size(394, 25);
            this.cboUsuario.TabIndex = 8;
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDoctor.Location = new System.Drawing.Point(15, 95);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(127, 17);
            this.lblDoctor.TabIndex = 5;
            this.lblDoctor.Text = "Médico Asignado:";
            // 
            // txtDoctor
            // 
            this.txtDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.txtDoctor.Location = new System.Drawing.Point(18, 117);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.ReadOnly = true;
            this.txtDoctor.Size = new System.Drawing.Size(394, 25);
            this.txtDoctor.TabIndex = 6;
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPaciente.Location = new System.Drawing.Point(125, 40);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(64, 17);
            this.lblPaciente.TabIndex = 3;
            this.lblPaciente.Text = "Paciente:";
            // 
            // txtPaciente
            // 
            this.txtPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.txtPaciente.Location = new System.Drawing.Point(128, 62);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.ReadOnly = true;
            this.txtPaciente.Size = new System.Drawing.Size(284, 25);
            this.txtPaciente.TabIndex = 4;
            // 
            // lblIdCita
            // 
            this.lblIdCita.AutoSize = true;
            this.lblIdCita.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblIdCita.Location = new System.Drawing.Point(15, 40);
            this.lblIdCita.Name = "lblIdCita";
            this.lblIdCita.Size = new System.Drawing.Size(84, 17);
            this.lblIdCita.TabIndex = 1;
            this.lblIdCita.Text = "Código Cita:";
            // 
            // txtIdCita
            // 
            this.txtIdCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.txtIdCita.Location = new System.Drawing.Point(18, 62);
            this.txtIdCita.Name = "txtIdCita";
            this.txtIdCita.ReadOnly = true;
            this.txtIdCita.Size = new System.Drawing.Size(95, 25);
            this.txtIdCita.TabIndex = 2;
            // 
            // FrmMarcarAtendida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1040, 640);
            this.Controls.Add(this.pnlAtencion);
            this.Controls.Add(this.dgvCitasHoy);
            this.Controls.Add(this.pnlFiltro);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmMarcarAtendida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediCitas - Marcar Cita Atendida";
            this.Load += new System.EventHandler(this.FrmMarcarAtendida_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitasHoy)).EndInit();
            this.pnlAtencion.ResumeLayout(false);
            this.pnlAtencion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.Label lblFechaHoy;
        private System.Windows.Forms.DateTimePicker dtpFechaHoy;
        private System.Windows.Forms.Label lblDoctorFiltro;
        private System.Windows.Forms.ComboBox cboDoctorFiltro;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.DataGridView dgvCitasHoy;
        private System.Windows.Forms.Panel pnlAtencion;
        private System.Windows.Forms.Label lblTituloPanel;
        private System.Windows.Forms.Label lblIdCita;
        private System.Windows.Forms.TextBox txtIdCita;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ComboBox cboUsuario;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnMarcarAtendida;
        private System.Windows.Forms.Button btnLimpiar;
    }
}