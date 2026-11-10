
namespace medicitass
{
    partial class FrmInicioRecepcionista
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblFecha;

        private System.Windows.Forms.TableLayoutPanel tablaTarjetas;
        private System.Windows.Forms.Panel pnlCitasHoy;
        private System.Windows.Forms.Panel pnlProgramadas;
        private System.Windows.Forms.Panel pnlPacientes;

        private System.Windows.Forms.Label lblTextoCitasHoy;
        private System.Windows.Forms.Label lblTextoProgramadas;
        private System.Windows.Forms.Label lblTextoPacientes;
        private System.Windows.Forms.Label lblCitasHoy;
        private System.Windows.Forms.Label lblProgramadas;
        private System.Windows.Forms.Label lblPacientes;

        private System.Windows.Forms.TableLayoutPanel tablaAgenda;
        private System.Windows.Forms.Label lblTituloAgenda;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.DataGridView dgvAgenda;

        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();

            this.tablaTarjetas =
                new System.Windows.Forms.TableLayoutPanel();

            this.pnlCitasHoy = new System.Windows.Forms.Panel();
            this.pnlProgramadas = new System.Windows.Forms.Panel();
            this.pnlPacientes = new System.Windows.Forms.Panel();

            this.lblTextoCitasHoy = new System.Windows.Forms.Label();
            this.lblTextoProgramadas = new System.Windows.Forms.Label();
            this.lblTextoPacientes = new System.Windows.Forms.Label();

            this.lblCitasHoy = new System.Windows.Forms.Label();
            this.lblProgramadas = new System.Windows.Forms.Label();
            this.lblPacientes = new System.Windows.Forms.Label();

            this.tablaAgenda =
                new System.Windows.Forms.TableLayoutPanel();

            this.lblTituloAgenda = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.dgvAgenda = new System.Windows.Forms.DataGridView();

            this.colHora =
                new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaciente =
                new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoctor =
                new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEspecialidad =
                new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlCabecera.SuspendLayout();
            this.tablaTarjetas.SuspendLayout();
            this.pnlCitasHoy.SuspendLayout();
            this.pnlProgramadas.SuspendLayout();
            this.pnlPacientes.SuspendLayout();
            this.tablaAgenda.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvAgenda)).BeginInit();

            this.SuspendLayout();

            // ======================================
            // ENCABEZADO
            // ======================================
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Dock =
                System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Height = 105;
            this.pnlCabecera.BackColor =
                System.Drawing.Color.FromArgb(19, 62, 92);

            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "PANEL DE RECEPCIÓN";
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location =
                new System.Drawing.Point(24, 10);
            this.lblTitulo.Font = new System.Drawing.Font(
                "Segoe UI", 21F,
                System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor =
                System.Drawing.Color.White;

            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Text = "Bienvenido a Recepción";
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Location =
                new System.Drawing.Point(28, 68);
            this.lblBienvenida.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.lblBienvenida.ForeColor =
                System.Drawing.Color.White;

            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location =
                new System.Drawing.Point(700, 68);
            this.lblFecha.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.lblFecha.ForeColor =
                System.Drawing.Color.White;

            this.pnlCabecera.Controls.Add(this.lblTitulo);
            this.pnlCabecera.Controls.Add(this.lblBienvenida);
            this.pnlCabecera.Controls.Add(this.lblFecha);

            // ======================================
            // CONTENEDOR DE TARJETAS
            // ======================================
            this.tablaTarjetas.Name = "tablaTarjetas";
            this.tablaTarjetas.Dock =
                System.Windows.Forms.DockStyle.Top;
            this.tablaTarjetas.Height = 170;
            this.tablaTarjetas.Padding =
                new System.Windows.Forms.Padding(12, 15, 12, 10);
            this.tablaTarjetas.BackColor =
                System.Drawing.Color.FromArgb(247, 249, 252);
            this.tablaTarjetas.ColumnCount = 3;
            this.tablaTarjetas.RowCount = 1;

            this.tablaTarjetas.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tablaTarjetas.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tablaTarjetas.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tablaTarjetas.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Percent, 100F));

            // ======================================
            // TARJETA CITAS DE HOY
            // ======================================
            this.pnlCitasHoy.Name = "pnlCitasHoy";
            this.pnlCitasHoy.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.pnlCitasHoy.Margin =
                new System.Windows.Forms.Padding(8);
            this.pnlCitasHoy.BackColor =
                System.Drawing.Color.FromArgb(225, 241, 251);
            this.pnlCitasHoy.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblTextoCitasHoy.Name = "lblTextoCitasHoy";
            this.lblTextoCitasHoy.Text = "CITAS DE HOY";
            this.lblTextoCitasHoy.AutoSize = true;
            this.lblTextoCitasHoy.Location =
                new System.Drawing.Point(15, 14);
            this.lblTextoCitasHoy.Font = new System.Drawing.Font(
                "Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);
            this.lblTextoCitasHoy.ForeColor =
                System.Drawing.Color.FromArgb(25, 90, 150);

            this.lblCitasHoy.Name = "lblCitasHoy";
            this.lblCitasHoy.Text = "—";
            this.lblCitasHoy.AutoSize = true;
            this.lblCitasHoy.Location =
                new System.Drawing.Point(15, 43);
            this.lblCitasHoy.Font = new System.Drawing.Font(
                "Segoe UI", 30F,
                System.Drawing.FontStyle.Bold);

            this.pnlCitasHoy.Controls.Add(this.lblTextoCitasHoy);
            this.pnlCitasHoy.Controls.Add(this.lblCitasHoy);

            // ======================================
            // TARJETA CITAS PROGRAMADAS
            // ======================================
            this.pnlProgramadas.Name = "pnlProgramadas";
            this.pnlProgramadas.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.pnlProgramadas.Margin =
                new System.Windows.Forms.Padding(8);
            this.pnlProgramadas.BackColor =
                System.Drawing.Color.FromArgb(255, 245, 222);
            this.pnlProgramadas.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblTextoProgramadas.Name =
                "lblTextoProgramadas";
            this.lblTextoProgramadas.Text =
                "CITAS PROGRAMADAS";
            this.lblTextoProgramadas.AutoSize = true;
            this.lblTextoProgramadas.Location =
                new System.Drawing.Point(15, 14);
            this.lblTextoProgramadas.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);
            this.lblTextoProgramadas.ForeColor =
                System.Drawing.Color.DarkGoldenrod;

            this.lblProgramadas.Name = "lblProgramadas";
            this.lblProgramadas.Text = "—";
            this.lblProgramadas.AutoSize = true;
            this.lblProgramadas.Location =
                new System.Drawing.Point(15, 43);
            this.lblProgramadas.Font = new System.Drawing.Font(
                "Segoe UI", 30F,
                System.Drawing.FontStyle.Bold);

            this.pnlProgramadas.Controls.Add(
                this.lblTextoProgramadas);
            this.pnlProgramadas.Controls.Add(
                this.lblProgramadas);

            // ======================================
            // TARJETA PACIENTES ACTIVOS
            // ======================================
            this.pnlPacientes.Name = "pnlPacientes";
            this.pnlPacientes.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.pnlPacientes.Margin =
                new System.Windows.Forms.Padding(8);
            this.pnlPacientes.BackColor =
                System.Drawing.Color.FromArgb(225, 244, 233);
            this.pnlPacientes.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblTextoPacientes.Name =
                "lblTextoPacientes";
            this.lblTextoPacientes.Text =
                "PACIENTES ACTIVOS";
            this.lblTextoPacientes.AutoSize = true;
            this.lblTextoPacientes.Location =
                new System.Drawing.Point(15, 14);
            this.lblTextoPacientes.Font = new System.Drawing.Font(
                "Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);
            this.lblTextoPacientes.ForeColor =
                System.Drawing.Color.DarkGreen;

            this.lblPacientes.Name = "lblPacientes";
            this.lblPacientes.Text = "—";
            this.lblPacientes.AutoSize = true;
            this.lblPacientes.Location =
                new System.Drawing.Point(15, 43);
            this.lblPacientes.Font = new System.Drawing.Font(
                "Segoe UI", 30F,
                System.Drawing.FontStyle.Bold);

            this.pnlPacientes.Controls.Add(this.lblTextoPacientes);
            this.pnlPacientes.Controls.Add(this.lblPacientes);

            this.tablaTarjetas.Controls.Add(
                this.pnlCitasHoy, 0, 0);
            this.tablaTarjetas.Controls.Add(
                this.pnlProgramadas, 1, 0);
            this.tablaTarjetas.Controls.Add(
                this.pnlPacientes, 2, 0);

            // ======================================
            // AGENDA
            // ======================================
            this.tablaAgenda.Name = "tablaAgenda";
            this.tablaAgenda.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.tablaAgenda.BackColor =
                System.Drawing.Color.FromArgb(248, 250, 252);
            this.tablaAgenda.Padding =
                new System.Windows.Forms.Padding(20, 10, 20, 12);
            this.tablaAgenda.ColumnCount = 1;
            this.tablaAgenda.RowCount = 3;

            this.tablaAgenda.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Percent, 100F));

            this.tablaAgenda.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 46F));

            this.tablaAgenda.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Percent, 100F));

            this.tablaAgenda.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 36F));

            this.lblTituloAgenda.Name = "lblTituloAgenda";
            this.lblTituloAgenda.Text =
                "AGENDA GENERAL DEL DÍA";
            this.lblTituloAgenda.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.lblTituloAgenda.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTituloAgenda.Font = new System.Drawing.Font(
                "Segoe UI", 15F,
                System.Drawing.FontStyle.Bold);
            this.lblTituloAgenda.ForeColor =
                System.Drawing.Color.FromArgb(19, 62, 92);

            // ======================================
            // TABLA DE DATOS
            // ======================================
            this.dgvAgenda.Name = "dgvAgenda";
            this.dgvAgenda.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.dgvAgenda.BackgroundColor =
                System.Drawing.Color.White;
            this.dgvAgenda.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvAgenda.AllowUserToAddRows = false;
            this.dgvAgenda.AllowUserToDeleteRows = false;
            this.dgvAgenda.AllowUserToResizeRows = false;
            this.dgvAgenda.ReadOnly = true;
            this.dgvAgenda.MultiSelect = false;
            this.dgvAgenda.RowHeadersVisible = false;
            this.dgvAgenda.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAgenda.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAgenda.EnableHeadersVisualStyles = false;

            this.dgvAgenda.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(25, 102, 155);

            this.dgvAgenda.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;

            this.dgvAgenda.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            this.dgvAgenda.ColumnHeadersHeight = 38;
            this.dgvAgenda.RowTemplate.Height = 30;

            this.dgvAgenda.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(240, 247, 252);

            this.colHora.Name = "colHora";
            this.colHora.HeaderText = "Hora";
            this.colHora.FillWeight = 65;

            this.colPaciente.Name = "colPaciente";
            this.colPaciente.HeaderText = "Paciente";
            this.colPaciente.FillWeight = 135;

            this.colDoctor.Name = "colDoctor";
            this.colDoctor.HeaderText = "Doctor";
            this.colDoctor.FillWeight = 135;

            this.colEspecialidad.Name = "colEspecialidad";
            this.colEspecialidad.HeaderText = "Especialidad";
            this.colEspecialidad.FillWeight = 120;

            this.colEstado.Name = "colEstado";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.FillWeight = 85;

            this.dgvAgenda.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[]
                {
                    this.colHora,
                    this.colPaciente,
                    this.colDoctor,
                    this.colEspecialidad,
                    this.colEstado
                });

            // ======================================
            // MENSAJE INFERIOR
            // ======================================
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "Cargando información...";
            this.lblEstado.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.lblEstado.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEstado.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.lblEstado.ForeColor =
                System.Drawing.Color.DimGray;

            this.tablaAgenda.Controls.Add(
                this.lblTituloAgenda, 0, 0);
            this.tablaAgenda.Controls.Add(
                this.dgvAgenda, 0, 1);
            this.tablaAgenda.Controls.Add(
                this.lblEstado, 0, 2);

            // ======================================
            // CONFIGURACIÓN FINAL
            // ======================================
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1000, 680);
            this.MinimumSize =
                new System.Drawing.Size(760, 500);

            this.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.BackColor =
                System.Drawing.Color.FromArgb(248, 250, 252);

            this.Name = "FrmInicioRecepcionista";
            this.Text = "MediCitas - Panel de Recepción";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Controls.Add(this.tablaAgenda);
            this.Controls.Add(this.tablaTarjetas);
            this.Controls.Add(this.pnlCabecera);

            this.Load += new System.EventHandler(
                this.FrmInicioRecepcionista_Load);

            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();

            this.pnlCitasHoy.ResumeLayout(false);
            this.pnlCitasHoy.PerformLayout();

            this.pnlProgramadas.ResumeLayout(false);
            this.pnlProgramadas.PerformLayout();

            this.pnlPacientes.ResumeLayout(false);
            this.pnlPacientes.PerformLayout();

            this.tablaTarjetas.ResumeLayout(false);
            this.tablaAgenda.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvAgenda)).EndInit();

            this.ResumeLayout(false);
        }
    }
}
