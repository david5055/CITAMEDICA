namespace medicitass
{
    partial class FrmConsultaAgendaFecha
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.lblTotalCanceladas = new System.Windows.Forms.Label();
            this.lblTotalAtendidas = new System.Windows.Forms.Label();
            this.lblTotalProgramadas = new System.Windows.Forms.Label();
            this.lblTotalCitas = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
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
            this.lblTitulo.Size = new System.Drawing.Size(434, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Consulta de Agenda por Rango de Fechas";
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFiltros.Controls.Add(this.btnRefrescar);
            this.pnlFiltros.Controls.Add(this.btnHoy);
            this.pnlFiltros.Controls.Add(this.btnBuscar);
            this.pnlFiltros.Controls.Add(this.txtBuscar);
            this.pnlFiltros.Controls.Add(this.lblBuscar);
            this.pnlFiltros.Controls.Add(this.cboEstado);
            this.pnlFiltros.Controls.Add(this.lblEstado);
            this.pnlFiltros.Controls.Add(this.dtpFechaHasta);
            this.pnlFiltros.Controls.Add(this.lblFechaHasta);
            this.pnlFiltros.Controls.Add(this.dtpFechaDesde);
            this.pnlFiltros.Controls.Add(this.lblFechaDesde);
            this.pnlFiltros.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.pnlFiltros.Location = new System.Drawing.Point(18, 75);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1004, 75);
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
            this.btnRefrescar.Location = new System.Drawing.Point(905, 34);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(80, 27);
            this.btnRefrescar.TabIndex = 10;
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
            this.btnHoy.Location = new System.Drawing.Point(825, 34);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(74, 27);
            this.btnHoy.TabIndex = 9;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.UseVisualStyleBackColor = false;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(740, 34);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(79, 27);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Filtrar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(485, 35);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(240, 24);
            this.txtBuscar.TabIndex = 7;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.Location = new System.Drawing.Point(482, 13);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(149, 15);
            this.lblBuscar.TabIndex = 6;
            this.lblBuscar.Text = "Paciente / Doctor / DUI:";
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
            this.cboEstado.Location = new System.Drawing.Point(315, 34);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(150, 25);
            this.cboEstado.TabIndex = 5;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(312, 13);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(95, 15);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "Estado de Cita:";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(165, 35);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(130, 24);
            this.dtpFechaHasta.TabIndex = 3;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaHasta.Location = new System.Drawing.Point(162, 13);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(76, 15);
            this.lblFechaHasta.TabIndex = 2;
            this.lblFechaHasta.Text = "Fecha Hasta:";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(15, 35);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(130, 24);
            this.dtpFechaDesde.TabIndex = 1;
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaDesde.Location = new System.Drawing.Point(12, 13);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(79, 15);
            this.lblFechaDesde.TabIndex = 0;
            this.lblFechaDesde.Text = "Fecha Desde:";
            // 
            // dgvCitas
            // 
            this.dgvCitas.AllowUserToAddRows = false;
            this.dgvCitas.AllowUserToDeleteRows = false;
            this.dgvCitas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCitas.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCitas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitas.EnableHeadersVisualStyles = false;
            this.dgvCitas.Location = new System.Drawing.Point(18, 160);
            this.dgvCitas.MultiSelect = false;
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCitas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCitas.Size = new System.Drawing.Size(1004, 415);
            this.dgvCitas.TabIndex = 2;
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
            this.pnlResumen.TabIndex = 3;
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
            this.lblTotalCitas.Size = new System.Drawing.Size(130, 17);
            this.lblTotalCitas.TabIndex = 0;
            this.lblTotalCitas.Text = "Total de Citas: 0";
            // 
            // FrmConsultaAgendaFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1040, 645);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.dgvCitas);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmConsultaAgendaFecha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediCitas - Consulta de Agenda por Fechas";
            this.Load += new System.EventHandler(this.FrmConsultaAgendaFecha_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblTotalCitas;
        private System.Windows.Forms.Label lblTotalProgramadas;
        private System.Windows.Forms.Label lblTotalAtendidas;
        private System.Windows.Forms.Label lblTotalCanceladas;
    }
}