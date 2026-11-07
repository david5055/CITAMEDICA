namespace medicitass
{
    partial class FrmConsultaHistorialPaciente
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
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.cboTipoTiempo = new System.Windows.Forms.ComboBox();
            this.lblTipoTiempo = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboPaciente = new System.Windows.Forms.ComboBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.pnlInfoPaciente = new System.Windows.Forms.Panel();
            this.lblDireccionInfo = new System.Windows.Forms.Label();
            this.lblContactoInfo = new System.Windows.Forms.Label();
            this.lblEdadInfo = new System.Windows.Forms.Label();
            this.lblDuiInfo = new System.Windows.Forms.Label();
            this.lblFichaPaciente = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.lblTotalCanceladas = new System.Windows.Forms.Label();
            this.lblTotalAtendidas = new System.Windows.Forms.Label();
            this.lblTotalProgramadas = new System.Windows.Forms.Label();
            this.lblTotalFuturas = new System.Windows.Forms.Label();
            this.lblTotalPasadas = new System.Windows.Forms.Label();
            this.lblTotalCitas = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.pnlInfoPaciente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
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
            this.lblTitulo.Size = new System.Drawing.Size(462, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Historial Completo de Citas por Paciente";
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFiltros.Controls.Add(this.btnRefrescar);
            this.pnlFiltros.Controls.Add(this.btnFiltrar);
            this.pnlFiltros.Controls.Add(this.cboTipoTiempo);
            this.pnlFiltros.Controls.Add(this.lblTipoTiempo);
            this.pnlFiltros.Controls.Add(this.cboEstado);
            this.pnlFiltros.Controls.Add(this.lblEstado);
            this.pnlFiltros.Controls.Add(this.cboPaciente);
            this.pnlFiltros.Controls.Add(this.lblPaciente);
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
            this.btnRefrescar.TabIndex = 7;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(815, 30);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(80, 27);
            this.btnFiltrar.TabIndex = 6;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // cboTipoTiempo
            // 
            this.cboTipoTiempo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoTiempo.FormattingEnabled = true;
            this.cboTipoTiempo.Items.AddRange(new object[] {
            "Todas las Citas",
            "Citas Pasadas",
            "Citas Futuras"});
            this.cboTipoTiempo.Location = new System.Drawing.Point(620, 31);
            this.cboTipoTiempo.Name = "cboTipoTiempo";
            this.cboTipoTiempo.Size = new System.Drawing.Size(175, 25);
            this.cboTipoTiempo.TabIndex = 5;
            this.cboTipoTiempo.SelectedIndexChanged += new System.EventHandler(this.cboTipoTiempo_SelectedIndexChanged);
            // 
            // lblTipoTiempo
            // 
            this.lblTipoTiempo.AutoSize = true;
            this.lblTipoTiempo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipoTiempo.Location = new System.Drawing.Point(617, 10);
            this.lblTipoTiempo.Name = "lblTipoTiempo";
            this.lblTipoTiempo.Size = new System.Drawing.Size(107, 15);
            this.lblTipoTiempo.TabIndex = 4;
            this.lblTipoTiempo.Text = "Horizonte Temporal:";
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
            this.cboEstado.Location = new System.Drawing.Point(435, 31);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(165, 25);
            this.cboEstado.TabIndex = 3;
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.cboEstado_SelectedIndexChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(432, 10);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(95, 15);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Estado de Cita:";
            // 
            // cboPaciente
            // 
            this.cboPaciente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPaciente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPaciente.FormattingEnabled = true;
            this.cboPaciente.Location = new System.Drawing.Point(15, 31);
            this.cboPaciente.Name = "cboPaciente";
            this.cboPaciente.Size = new System.Drawing.Size(400, 25);
            this.cboPaciente.TabIndex = 1;
            this.cboPaciente.SelectedIndexChanged += new System.EventHandler(this.cboPaciente_SelectedIndexChanged);
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPaciente.Location = new System.Drawing.Point(12, 10);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(189, 15);
            this.lblPaciente.TabIndex = 0;
            this.lblPaciente.Text = "Seleccionar o Buscar Paciente:";
            // 
            // pnlInfoPaciente
            // 
            this.pnlInfoPaciente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInfoPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(250)))));
            this.pnlInfoPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfoPaciente.Controls.Add(this.lblDireccionInfo);
            this.pnlInfoPaciente.Controls.Add(this.lblContactoInfo);
            this.pnlInfoPaciente.Controls.Add(this.lblEdadInfo);
            this.pnlInfoPaciente.Controls.Add(this.lblDuiInfo);
            this.pnlInfoPaciente.Controls.Add(this.lblFichaPaciente);
            this.pnlInfoPaciente.Location = new System.Drawing.Point(18, 155);
            this.pnlInfoPaciente.Name = "pnlInfoPaciente";
            this.pnlInfoPaciente.Size = new System.Drawing.Size(1004, 50);
            this.pnlInfoPaciente.TabIndex = 2;
            // 
            // lblDireccionInfo
            // 
            this.lblDireccionInfo.AutoSize = true;
            this.lblDireccionInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccionInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblDireccionInfo.Location = new System.Drawing.Point(740, 17);
            this.lblDireccionInfo.Name = "lblDireccionInfo";
            this.lblDireccionInfo.Size = new System.Drawing.Size(70, 15);
            this.lblDireccionInfo.TabIndex = 4;
            this.lblDireccionInfo.Text = "Dirección: -";
            // 
            // lblContactoInfo
            // 
            this.lblContactoInfo.AutoSize = true;
            this.lblContactoInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactoInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblContactoInfo.Location = new System.Drawing.Point(490, 17);
            this.lblContactoInfo.Name = "lblContactoInfo";
            this.lblContactoInfo.Size = new System.Drawing.Size(69, 15);
            this.lblContactoInfo.TabIndex = 3;
            this.lblContactoInfo.Text = "Contacto: -";
            // 
            // lblEdadInfo
            // 
            this.lblEdadInfo.AutoSize = true;
            this.lblEdadInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdadInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblEdadInfo.Location = new System.Drawing.Point(340, 17);
            this.lblEdadInfo.Name = "lblEdadInfo";
            this.lblEdadInfo.Size = new System.Drawing.Size(107, 15);
            this.lblEdadInfo.TabIndex = 2;
            this.lblEdadInfo.Text = "F. Nacimiento: -";
            // 
            // lblDuiInfo
            // 
            this.lblDuiInfo.AutoSize = true;
            this.lblDuiInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuiInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(170)))));
            this.lblDuiInfo.Location = new System.Drawing.Point(170, 17);
            this.lblDuiInfo.Name = "lblDuiInfo";
            this.lblDuiInfo.Size = new System.Drawing.Size(125, 15);
            this.lblDuiInfo.TabIndex = 1;
            this.lblDuiInfo.Text = "DUI / Documento: -";
            // 
            // lblFichaPaciente
            // 
            this.lblFichaPaciente.AutoSize = true;
            this.lblFichaPaciente.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFichaPaciente.ForeColor = System.Drawing.Color.Black;
            this.lblFichaPaciente.Location = new System.Drawing.Point(12, 16);
            this.lblFichaPaciente.Name = "lblFichaPaciente";
            this.lblFichaPaciente.Size = new System.Drawing.Size(130, 17);
            this.lblFichaPaciente.TabIndex = 0;
            this.lblFichaPaciente.Text = "Ficha del Paciente:";
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.EnableHeadersVisualStyles = false;
            this.dgvHistorial.Location = new System.Drawing.Point(18, 215);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvHistorial.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(1004, 360);
            this.dgvHistorial.TabIndex = 3;
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
            this.pnlResumen.Controls.Add(this.lblTotalFuturas);
            this.pnlResumen.Controls.Add(this.lblTotalPasadas);
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
            this.lblTotalCanceladas.Location = new System.Drawing.Point(830, 13);
            this.lblTotalCanceladas.Name = "lblTotalCanceladas";
            this.lblTotalCanceladas.Size = new System.Drawing.Size(91, 17);
            this.lblTotalCanceladas.TabIndex = 5;
            this.lblTotalCanceladas.Text = "Canceladas: 0";
            // 
            // lblTotalAtendidas
            // 
            this.lblTotalAtendidas.AutoSize = true;
            this.lblTotalAtendidas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblTotalAtendidas.Location = new System.Drawing.Point(700, 13);
            this.lblTotalAtendidas.Name = "lblTotalAtendidas";
            this.lblTotalAtendidas.Size = new System.Drawing.Size(83, 17);
            this.lblTotalAtendidas.TabIndex = 4;
            this.lblTotalAtendidas.Text = "Atendidas: 0";
            // 
            // lblTotalProgramadas
            // 
            this.lblTotalProgramadas.AutoSize = true;
            this.lblTotalProgramadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTotalProgramadas.Location = new System.Drawing.Point(540, 13);
            this.lblTotalProgramadas.Name = "lblTotalProgramadas";
            this.lblTotalProgramadas.Size = new System.Drawing.Size(105, 17);
            this.lblTotalProgramadas.TabIndex = 3;
            this.lblTotalProgramadas.Text = "Programadas: 0";
            // 
            // lblTotalFuturas
            // 
            this.lblTotalFuturas.AutoSize = true;
            this.lblTotalFuturas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(16)))), ((int)(((byte)(242)))));
            this.lblTotalFuturas.Location = new System.Drawing.Point(360, 13);
            this.lblTotalFuturas.Name = "lblTotalFuturas";
            this.lblTotalFuturas.Size = new System.Drawing.Size(120, 17);
            this.lblTotalFuturas.TabIndex = 2;
            this.lblTotalFuturas.Text = "Citas Futuras (≥): 0";
            // 
            // lblTotalPasadas
            // 
            this.lblTotalPasadas.AutoSize = true;
            this.lblTotalPasadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lblTotalPasadas.Location = new System.Drawing.Point(190, 13);
            this.lblTotalPasadas.Name = "lblTotalPasadas";
            this.lblTotalPasadas.Size = new System.Drawing.Size(117, 17);
            this.lblTotalPasadas.TabIndex = 1;
            this.lblTotalPasadas.Text = "Citas Pasadas (<): 0";
            // 
            // lblTotalCitas
            // 
            this.lblTotalCitas.AutoSize = true;
            this.lblTotalCitas.Location = new System.Drawing.Point(15, 13);
            this.lblTotalCitas.Name = "lblTotalCitas";
            this.lblTotalCitas.Size = new System.Drawing.Size(130, 17);
            this.lblTotalCitas.TabIndex = 0;
            this.lblTotalCitas.Text = "Total de Historial: 0";
            // 
            // FrmConsultaHistorialPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1040, 645);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.pnlInfoPaciente);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmConsultaHistorialPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediCitas - Historial Clínico de Paciente";
            this.Load += new System.EventHandler(this.FrmConsultaHistorialPaciente_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlInfoPaciente.ResumeLayout(false);
            this.pnlInfoPaciente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.ComboBox cboPaciente;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblTipoTiempo;
        private System.Windows.Forms.ComboBox cboTipoTiempo;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Panel pnlInfoPaciente;
        private System.Windows.Forms.Label lblFichaPaciente;
        private System.Windows.Forms.Label lblDuiInfo;
        private System.Windows.Forms.Label lblEdadInfo;
        private System.Windows.Forms.Label lblContactoInfo;
        private System.Windows.Forms.Label lblDireccionInfo;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblTotalCitas;
        private System.Windows.Forms.Label lblTotalPasadas;
        private System.Windows.Forms.Label lblTotalFuturas;
        private System.Windows.Forms.Label lblTotalProgramadas;
        private System.Windows.Forms.Label lblTotalAtendidas;
        private System.Windows.Forms.Label lblTotalCanceladas;
    }
}