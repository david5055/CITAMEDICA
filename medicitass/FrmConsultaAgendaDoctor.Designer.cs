namespace medicitass
{
    partial class FrmConsultaAgendaDoctor
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
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnHoy = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cboDoctor = new System.Windows.Forms.ComboBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.pnlInfoDoctor = new System.Windows.Forms.Panel();
            this.lblContactoInfo = new System.Windows.Forms.Label();
            this.lblJuntaInfo = new System.Windows.Forms.Label();
            this.lblEspecialidadInfo = new System.Windows.Forms.Label();
            this.lblFichaDoctor = new System.Windows.Forms.Label();
            this.dgvAgendaDoctor = new System.Windows.Forms.DataGridView();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.lblTotalCanceladas = new System.Windows.Forms.Label();
            this.lblTotalAtendidas = new System.Windows.Forms.Label();
            this.lblTotalProgramadas = new System.Windows.Forms.Label();
            this.lblTotalCitas = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.pnlInfoDoctor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgendaDoctor)).BeginInit();
            this.pnlResumen.SuspendLayout();
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
            this.lblTitulo.Size = new System.Drawing.Size(431, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Jornada Diaria de Consultas por Doctor";
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFiltros.Controls.Add(this.btnRefrescar);
            this.pnlFiltros.Controls.Add(this.btnHoy);
            this.pnlFiltros.Controls.Add(this.btnFiltrar);
            this.pnlFiltros.Controls.Add(this.cboEstado);
            this.pnlFiltros.Controls.Add(this.lblEstado);
            this.pnlFiltros.Controls.Add(this.dtpFecha);
            this.pnlFiltros.Controls.Add(this.lblFecha);
            this.pnlFiltros.Controls.Add(this.cboDoctor);
            this.pnlFiltros.Controls.Add(this.lblDoctor);
            this.pnlFiltros.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.pnlFiltros.Location = new System.Drawing.Point(18, 75);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1004, 70);
            this.pnlFiltros.TabIndex = 1;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefrescar.FlatAppearance.BorderSize = 0;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(905, 30);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(80, 27);
            this.btnRefrescar.TabIndex = 8;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnHoy
            // 
            this.btnHoy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnHoy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHoy.FlatAppearance.BorderSize = 0;
            this.btnHoy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHoy.ForeColor = System.Drawing.Color.White;
            this.btnHoy.Location = new System.Drawing.Point(825, 30);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(74, 27);
            this.btnHoy.TabIndex = 7;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.UseVisualStyleBackColor = false;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(740, 30);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(79, 27);
            this.btnFiltrar.TabIndex = 6;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "Todos",
            "Programada",
            "Atendida",
            "Cancelada"});
            this.cboEstado.Location = new System.Drawing.Point(565, 31);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(160, 25);
            this.cboEstado.TabIndex = 5;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(562, 10);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(95, 15);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "Estado de Cita:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(395, 31);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(150, 24);
            this.dtpFecha.TabIndex = 3;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFecha.Location = new System.Drawing.Point(392, 10);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(117, 15);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha de Consulta:";
            // 
            // cboDoctor
            // 
            this.cboDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoctor.FormattingEnabled = true;
            this.cboDoctor.Location = new System.Drawing.Point(15, 31);
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Size = new System.Drawing.Size(360, 25);
            this.cboDoctor.TabIndex = 1;
            this.cboDoctor.SelectedIndexChanged += new System.EventHandler(this.cboDoctor_SelectedIndexChanged);
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDoctor.Location = new System.Drawing.Point(12, 10);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(176, 15);
            this.lblDoctor.TabIndex = 0;
            this.lblDoctor.Text = "Seleccionar Profesional Médico:";
            // 
            // pnlInfoDoctor
            // 
            this.pnlInfoDoctor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInfoDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(250)))));
            this.pnlInfoDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfoDoctor.Controls.Add(this.lblContactoInfo);
            this.pnlInfoDoctor.Controls.Add(this.lblJuntaInfo);
            this.pnlInfoDoctor.Controls.Add(this.lblEspecialidadInfo);
            this.pnlInfoDoctor.Controls.Add(this.lblFichaDoctor);
            this.pnlInfoDoctor.Location = new System.Drawing.Point(18, 155);
            this.pnlInfoDoctor.Name = "pnlInfoDoctor";
            this.pnlInfoDoctor.Size = new System.Drawing.Size(1004, 50);
            this.pnlInfoDoctor.TabIndex = 2;
            // 
            // lblContactoInfo
            // 
            this.lblContactoInfo.AutoSize = true;
            this.lblContactoInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactoInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblContactoInfo.Location = new System.Drawing.Point(680, 17);
            this.lblContactoInfo.Name = "lblContactoInfo";
            this.lblContactoInfo.Size = new System.Drawing.Size(69, 15);
            this.lblContactoInfo.TabIndex = 3;
            this.lblContactoInfo.Text = "Contacto: -";
            // 
            // lblJuntaInfo
            // 
            this.lblJuntaInfo.AutoSize = true;
            this.lblJuntaInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJuntaInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblJuntaInfo.Location = new System.Drawing.Point(440, 17);
            this.lblJuntaInfo.Name = "lblJuntaInfo";
            this.lblJuntaInfo.Size = new System.Drawing.Size(117, 15);
            this.lblJuntaInfo.TabIndex = 2;
            this.lblJuntaInfo.Text = "N° Junta Vigilancia: -";
            // 
            // lblEspecialidadInfo
            // 
            this.lblEspecialidadInfo.AutoSize = true;
            this.lblEspecialidadInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspecialidadInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(170)))));
            this.lblEspecialidadInfo.Location = new System.Drawing.Point(200, 17);
            this.lblEspecialidadInfo.Name = "lblEspecialidadInfo";
            this.lblEspecialidadInfo.Size = new System.Drawing.Size(90, 15);
            this.lblEspecialidadInfo.TabIndex = 1;
            this.lblEspecialidadInfo.Text = "Especialidad: -";
            // 
            // lblFichaDoctor
            // 
            this.lblFichaDoctor.AutoSize = true;
            this.lblFichaDoctor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFichaDoctor.ForeColor = System.Drawing.Color.Black;
            this.lblFichaDoctor.Location = new System.Drawing.Point(12, 16);
            this.lblFichaDoctor.Name = "lblFichaDoctor";
            this.lblFichaDoctor.Size = new System.Drawing.Size(147, 17);
            this.lblFichaDoctor.TabIndex = 0;
            this.lblFichaDoctor.Text = "Ficha del Profesional:";
            // 
            // dgvAgendaDoctor
            // 
            this.dgvAgendaDoctor.AllowUserToAddRows = false;
            this.dgvAgendaDoctor.AllowUserToDeleteRows = false;
            this.dgvAgendaDoctor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAgendaDoctor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAgendaDoctor.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAgendaDoctor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAgendaDoctor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgendaDoctor.EnableHeadersVisualStyles = false;
            this.dgvAgendaDoctor.Location = new System.Drawing.Point(18, 215);
            this.dgvAgendaDoctor.MultiSelect = false;
            this.dgvAgendaDoctor.Name = "dgvAgendaDoctor";
            this.dgvAgendaDoctor.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvAgendaDoctor.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAgendaDoctor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAgendaDoctor.Size = new System.Drawing.Size(1004, 360);
            this.dgvAgendaDoctor.TabIndex = 3;
            // 
            // pnlResumen
            // 
            this.pnlResumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlResumen.BackColor = System.Drawing.Color.White;
            this.pnlResumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResumen.Controls.Add(this.lblTotalCanceladas);
            this.pnlResumen.Controls.Add(this.lblTotalAtendidas);
            this.pnlResumen.Controls.Add(this.lblTotalProgramadas);
            this.pnlResumen.Controls.Add(this.lblTotalCitas);
            this.pnlResumen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.pnlResumen.Location = new System.Drawing.Point(18, 585);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(1004, 45);
            this.pnlResumen.TabIndex = 4;
            // 
            // lblTotalCanceladas
            // 
            this.lblTotalCanceladas.AutoSize = true;
            this.lblTotalCanceladas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblTotalCanceladas.Location = new System.Drawing.Point(620, 13);
            this.lblTotalCanceladas.Name = "lblTotalCanceladas";
            this.lblTotalCanceladas.Size = new System.Drawing.Size(147, 17);
            this.lblTotalCanceladas.TabIndex = 3;
            this.lblTotalCanceladas.Text = "Citas Canceladas: 0";
            // 
            // lblTotalAtendidas
            // 
            this.lblTotalAtendidas.AutoSize = true;
            this.lblTotalAtendidas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblTotalAtendidas.Location = new System.Drawing.Point(420, 13);
            this.lblTotalAtendidas.Name = "lblTotalAtendidas";
            this.lblTotalAtendidas.Size = new System.Drawing.Size(135, 17);
            this.lblTotalAtendidas.TabIndex = 2;
            this.lblTotalAtendidas.Text = "Citas Atendidas: 0";
            // 
            // lblTotalProgramadas
            // 
            this.lblTotalProgramadas.AutoSize = true;
            this.lblTotalProgramadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTotalProgramadas.Location = new System.Drawing.Point(210, 13);
            this.lblTotalProgramadas.Name = "lblTotalProgramadas";
            this.lblTotalProgramadas.Size = new System.Drawing.Size(157, 17);
            this.lblTotalProgramadas.TabIndex = 1;
            this.lblTotalProgramadas.Text = "Citas Programadas: 0";
            // 
            // lblTotalCitas
            // 
            this.lblTotalCitas.AutoSize = true;
            this.lblTotalCitas.Location = new System.Drawing.Point(15, 13);
            this.lblTotalCitas.Name = "lblTotalCitas";
            this.lblTotalCitas.Size = new System.Drawing.Size(161, 17);
            this.lblTotalCitas.TabIndex = 0;
            this.lblTotalCitas.Text = "Total Citas del Día: 0";
            // 
            // FrmConsultaAgendaDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1040, 645);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.dgvAgendaDoctor);
            this.Controls.Add(this.pnlInfoDoctor);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmConsultaAgendaDoctor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediCitas - Agenda Diaria por Doctor";
            this.Load += new System.EventHandler(this.FrmConsultaAgendaDoctor_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlInfoDoctor.ResumeLayout(false);
            this.pnlInfoDoctor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgendaDoctor)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.ComboBox cboDoctor;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Panel pnlInfoDoctor;
        private System.Windows.Forms.Label lblFichaDoctor;
        private System.Windows.Forms.Label lblEspecialidadInfo;
        private System.Windows.Forms.Label lblJuntaInfo;
        private System.Windows.Forms.Label lblContactoInfo;
        private System.Windows.Forms.DataGridView dgvAgendaDoctor;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblTotalCitas;
        private System.Windows.Forms.Label lblTotalProgramadas;
        private System.Windows.Forms.Label lblTotalAtendidas;
        private System.Windows.Forms.Label lblTotalCanceladas;
    }
}