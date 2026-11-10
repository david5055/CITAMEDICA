
namespace medicitass
{
    partial class FrmInicioDoctor
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblFecha;

        private System.Windows.Forms.TableLayoutPanel tablaTarjetas;

        private System.Windows.Forms.Panel pnlCardHoy;
        private System.Windows.Forms.Panel pnlCardPendientes;
        private System.Windows.Forms.Panel pnlCardAtendidas;

        private System.Windows.Forms.Label lblTextoHoy;
        private System.Windows.Forms.Label lblTextoPendientes;
        private System.Windows.Forms.Label lblTextoAtendidas;

        private System.Windows.Forms.Label lblTotalHoy;
        private System.Windows.Forms.Label lblPendientes;
        private System.Windows.Forms.Label lblAtendidas;

        private System.Windows.Forms.TableLayoutPanel tablaAgenda;
        private System.Windows.Forms.Panel pnlBarraAgenda;
        private System.Windows.Forms.Label lblTituloAgenda;
        private System.Windows.Forms.Label lblEstado;

        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnMarcarAtendida;

        private System.Windows.Forms.DataGridView dgvAgenda;

        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCita;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlEncabezado = new System.Windows.Forms.Panel();

            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();

            this.tablaTarjetas =
                new System.Windows.Forms.TableLayoutPanel();

            this.pnlCardHoy = new System.Windows.Forms.Panel();
            this.pnlCardPendientes = new System.Windows.Forms.Panel();
            this.pnlCardAtendidas = new System.Windows.Forms.Panel();

            this.lblTextoHoy = new System.Windows.Forms.Label();
            this.lblTextoPendientes = new System.Windows.Forms.Label();
            this.lblTextoAtendidas = new System.Windows.Forms.Label();

            this.lblTotalHoy = new System.Windows.Forms.Label();
            this.lblPendientes = new System.Windows.Forms.Label();
            this.lblAtendidas = new System.Windows.Forms.Label();

            this.tablaAgenda =
                new System.Windows.Forms.TableLayoutPanel();

            this.pnlBarraAgenda = new System.Windows.Forms.Panel();
            this.lblTituloAgenda = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();

            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnMarcarAtendida = new System.Windows.Forms.Button();

            this.dgvAgenda = new System.Windows.Forms.DataGridView();

            this.colIdCita =
                new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHora =
                new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaciente =
                new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo =
                new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlEncabezado.SuspendLayout();
            this.tablaTarjetas.SuspendLayout();

            this.pnlCardHoy.SuspendLayout();
            this.pnlCardPendientes.SuspendLayout();
            this.pnlCardAtendidas.SuspendLayout();

            this.tablaAgenda.SuspendLayout();
            this.pnlBarraAgenda.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvAgenda)).BeginInit();

            this.SuspendLayout();

            // ========================================
            // ENCABEZADO VERDE
            // ========================================
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Dock =
                System.Windows.Forms.DockStyle.Top;

            this.pnlEncabezado.Height = 110;

            this.pnlEncabezado.BackColor =
                System.Drawing.Color.FromArgb(18, 104, 102);

            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "PANEL DEL DOCTOR";
            this.lblTitulo.AutoSize = true;

            this.lblTitulo.Font = new System.Drawing.Font(
                "Segoe UI", 22F,
                System.Drawing.FontStyle.Bold);

            this.lblTitulo.ForeColor =
                System.Drawing.Color.White;

            this.lblTitulo.Location =
                new System.Drawing.Point(25, 12);

            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Text = "Bienvenido, Doctor";
            this.lblBienvenida.AutoSize = true;

            this.lblBienvenida.Font =
                new System.Drawing.Font("Segoe UI", 11F);

            this.lblBienvenida.ForeColor =
                System.Drawing.Color.White;

            this.lblBienvenida.Location =
                new System.Drawing.Point(30, 70);

            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.AutoSize = true;

            this.lblFecha.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.lblFecha.ForeColor =
                System.Drawing.Color.White;

            this.lblFecha.Location =
                new System.Drawing.Point(710, 72);

            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.lblBienvenida);
            this.pnlEncabezado.Controls.Add(this.lblFecha);

            // ========================================
            // CONTENEDOR DE TARJETAS
            // ========================================
            this.tablaTarjetas.Name = "tablaTarjetas";

            this.tablaTarjetas.Dock =
                System.Windows.Forms.DockStyle.Top;

            this.tablaTarjetas.Height = 165;

            this.tablaTarjetas.Padding =
                new System.Windows.Forms.Padding(12, 15, 12, 10);

            this.tablaTarjetas.BackColor =
                System.Drawing.Color.FromArgb(246, 249, 250);

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

            // ========================================
            // TARJETA CITAS DE HOY
            // ========================================
            this.pnlCardHoy.Name = "pnlCardHoy";
            this.pnlCardHoy.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.pnlCardHoy.Margin =
                new System.Windows.Forms.Padding(8);

            this.pnlCardHoy.BackColor =
                System.Drawing.Color.FromArgb(225, 241, 251);

            this.pnlCardHoy.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblTextoHoy.Name = "lblTextoHoy";
            this.lblTextoHoy.Text = "MIS CITAS DE HOY";
            this.lblTextoHoy.AutoSize = true;

            this.lblTextoHoy.Font = new System.Drawing.Font(
                "Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);

            this.lblTextoHoy.ForeColor =
                System.Drawing.Color.FromArgb(25, 90, 150);

            this.lblTextoHoy.Location =
                new System.Drawing.Point(16, 14);

            this.lblTotalHoy.Name = "lblTotalHoy";
            this.lblTotalHoy.Text = "—";
            this.lblTotalHoy.AutoSize = true;

            this.lblTotalHoy.Font = new System.Drawing.Font(
                "Segoe UI", 30F,
                System.Drawing.FontStyle.Bold);

            this.lblTotalHoy.Location =
                new System.Drawing.Point(16, 44);

            this.pnlCardHoy.Controls.Add(this.lblTextoHoy);
            this.pnlCardHoy.Controls.Add(this.lblTotalHoy);

            // ========================================
            // TARJETA PENDIENTES
            // ========================================
            this.pnlCardPendientes.Name = "pnlCardPendientes";
            this.pnlCardPendientes.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.pnlCardPendientes.Margin =
                new System.Windows.Forms.Padding(8);

            this.pnlCardPendientes.BackColor =
                System.Drawing.Color.FromArgb(255, 245, 222);

            this.pnlCardPendientes.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblTextoPendientes.Name =
                "lblTextoPendientes";

            this.lblTextoPendientes.Text =
                "CITAS PENDIENTES";

            this.lblTextoPendientes.AutoSize = true;

            this.lblTextoPendientes.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            this.lblTextoPendientes.ForeColor =
                System.Drawing.Color.DarkGoldenrod;

            this.lblTextoPendientes.Location =
                new System.Drawing.Point(16, 14);

            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Text = "—";
            this.lblPendientes.AutoSize = true;

            this.lblPendientes.Font = new System.Drawing.Font(
                "Segoe UI", 30F,
                System.Drawing.FontStyle.Bold);

            this.lblPendientes.Location =
                new System.Drawing.Point(16, 44);

            this.pnlCardPendientes.Controls.Add(
                this.lblTextoPendientes);

            this.pnlCardPendientes.Controls.Add(
                this.lblPendientes);

            // ========================================
            // TARJETA ATENDIDAS
            // ========================================
            this.pnlCardAtendidas.Name = "pnlCardAtendidas";
            this.pnlCardAtendidas.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.pnlCardAtendidas.Margin =
                new System.Windows.Forms.Padding(8);

            this.pnlCardAtendidas.BackColor =
                System.Drawing.Color.FromArgb(225, 244, 233);

            this.pnlCardAtendidas.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblTextoAtendidas.Name =
                "lblTextoAtendidas";

            this.lblTextoAtendidas.Text =
                "CITAS ATENDIDAS";

            this.lblTextoAtendidas.AutoSize = true;

            this.lblTextoAtendidas.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            this.lblTextoAtendidas.ForeColor =
                System.Drawing.Color.DarkGreen;

            this.lblTextoAtendidas.Location =
                new System.Drawing.Point(16, 14);

            this.lblAtendidas.Name = "lblAtendidas";
            this.lblAtendidas.Text = "—";
            this.lblAtendidas.AutoSize = true;

            this.lblAtendidas.Font = new System.Drawing.Font(
                "Segoe UI", 30F,
                System.Drawing.FontStyle.Bold);

            this.lblAtendidas.Location =
                new System.Drawing.Point(16, 44);

            this.pnlCardAtendidas.Controls.Add(
                this.lblTextoAtendidas);

            this.pnlCardAtendidas.Controls.Add(
                this.lblAtendidas);

            this.tablaTarjetas.Controls.Add(
                this.pnlCardHoy, 0, 0);

            this.tablaTarjetas.Controls.Add(
                this.pnlCardPendientes, 1, 0);

            this.tablaTarjetas.Controls.Add(
                this.pnlCardAtendidas, 2, 0);

            // ========================================
            // TABLA DISTRIBUIDORA DE LA AGENDA
            // ========================================
            this.tablaAgenda.Name = "tablaAgenda";

            this.tablaAgenda.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.tablaAgenda.Padding =
                new System.Windows.Forms.Padding(20, 10, 20, 12);

            this.tablaAgenda.BackColor =
                System.Drawing.Color.FromArgb(248, 250, 252);

            this.tablaAgenda.ColumnCount = 1;
            this.tablaAgenda.RowCount = 3;

            this.tablaAgenda.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Percent, 100F));

            this.tablaAgenda.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 65F));

            this.tablaAgenda.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Percent, 100F));

            this.tablaAgenda.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Absolute, 40F));

            // ========================================
            // BARRA DE AGENDA
            // ========================================
            this.pnlBarraAgenda.Name = "pnlBarraAgenda";

            this.pnlBarraAgenda.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.lblTituloAgenda.Name = "lblTituloAgenda";
            this.lblTituloAgenda.Text = "MI AGENDA MÉDICA";

            this.lblTituloAgenda.AutoSize = true;
            this.lblTituloAgenda.Location =
                new System.Drawing.Point(0, 15);

            this.lblTituloAgenda.Font = new System.Drawing.Font(
                "Segoe UI", 16F,
                System.Drawing.FontStyle.Bold);

            this.lblTituloAgenda.ForeColor =
                System.Drawing.Color.FromArgb(18, 104, 102);

            // BOTÓN ACTUALIZAR
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Text = "↻  Actualizar";

            this.btnActualizar.Size =
                new System.Drawing.Size(125, 38);

            this.btnActualizar.Location =
                new System.Drawing.Point(555, 10);

            this.btnActualizar.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right;

            this.btnActualizar.BackColor =
                System.Drawing.Color.SteelBlue;

            this.btnActualizar.ForeColor =
                System.Drawing.Color.White;

            this.btnActualizar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnActualizar.FlatAppearance.BorderSize = 0;

            this.btnActualizar.UseVisualStyleBackColor = false;

            this.btnActualizar.Click +=
                new System.EventHandler(
                    this.btnActualizar_Click);

            // BOTÓN MARCAR ATENDIDA
            this.btnMarcarAtendida.Name =
                "btnMarcarAtendida";

            this.btnMarcarAtendida.Text =
                "✓  Marcar cita atendida";

            this.btnMarcarAtendida.Size =
                new System.Drawing.Size(225, 38);

            this.btnMarcarAtendida.Location =
                new System.Drawing.Point(690, 10);

            this.btnMarcarAtendida.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right;

            this.btnMarcarAtendida.BackColor =
                System.Drawing.Color.SeaGreen;

            this.btnMarcarAtendida.ForeColor =
                System.Drawing.Color.White;

            this.btnMarcarAtendida.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnMarcarAtendida.FlatAppearance.BorderSize = 0;

            this.btnMarcarAtendida.Enabled = false;

            this.btnMarcarAtendida.UseVisualStyleBackColor = false;

            this.btnMarcarAtendida.Click +=
                new System.EventHandler(
                    this.btnMarcarAtendida_Click);

            this.pnlBarraAgenda.Controls.Add(
                this.lblTituloAgenda);

            this.pnlBarraAgenda.Controls.Add(
                this.btnActualizar);

            this.pnlBarraAgenda.Controls.Add(
                this.btnMarcarAtendida);

            // ========================================
            // TABLA DE CITAS
            // ========================================
            this.dgvAgenda.Name = "dgvAgenda";

            this.dgvAgenda.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.dgvAgenda.Margin =
                new System.Windows.Forms.Padding(3);

            this.dgvAgenda.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvAgenda.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.dgvAgenda.AllowUserToAddRows = false;
            this.dgvAgenda.AllowUserToDeleteRows = false;
            this.dgvAgenda.AllowUserToResizeRows = false;

            this.dgvAgenda.ReadOnly = true;
            this.dgvAgenda.RowHeadersVisible = false;
            this.dgvAgenda.MultiSelect = false;

            this.dgvAgenda.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvAgenda.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvAgenda.EnableHeadersVisualStyles = false;

            this.dgvAgenda.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(18, 104, 102);

            this.dgvAgenda.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;

            this.dgvAgenda.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            this.dgvAgenda.ColumnHeadersHeight = 40;
            this.dgvAgenda.RowTemplate.Height = 32;

            this.dgvAgenda.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(235, 247, 245);

            // CÓDIGO DE LA CITA (OCULTO)
            this.colIdCita.Name = "colIdCita";
            this.colIdCita.HeaderText = "ID";
            this.colIdCita.Visible = false;

            // HORA
            this.colHora.Name = "colHora";
            this.colHora.HeaderText = "Hora";
            this.colHora.FillWeight = 65;

            // PACIENTE
            this.colPaciente.Name = "colPaciente";
            this.colPaciente.HeaderText = "Paciente";
            this.colPaciente.FillWeight = 145;

            // MOTIVO
            this.colMotivo.Name = "colMotivo";
            this.colMotivo.HeaderText = "Motivo de consulta";
            this.colMotivo.FillWeight = 170;

            // ESTADO
            this.colEstado.Name = "colEstado";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.FillWeight = 90;

            this.dgvAgenda.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[]
                {
                    this.colIdCita,
                    this.colHora,
                    this.colPaciente,
                    this.colMotivo,
                    this.colEstado
                });

            this.dgvAgenda.SelectionChanged +=
                new System.EventHandler(
                    this.dgvAgenda_SelectionChanged);

            // ========================================
            // MENSAJE DE ESTADO
            // ========================================
            this.lblEstado.Name = "lblEstado";

            this.lblEstado.Text =
                "La agenda se cargará desde SQL Server.";

            this.lblEstado.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.lblEstado.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            this.lblEstado.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.lblEstado.ForeColor =
                System.Drawing.Color.DimGray;

            // AGREGAR FILAS DE LA AGENDA
            this.tablaAgenda.Controls.Add(
                this.pnlBarraAgenda, 0, 0);

            this.tablaAgenda.Controls.Add(
                this.dgvAgenda, 0, 1);

            this.tablaAgenda.Controls.Add(
                this.lblEstado, 0, 2);

            // ========================================
            // FORMULARIO PRINCIPAL
            // ========================================
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(970, 700);

            this.MinimumSize =
                new System.Drawing.Size(760, 500);

            this.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.BackColor =
                System.Drawing.Color.FromArgb(248, 250, 252);

            this.Name = "FrmInicioDoctor";

            this.Text = "MediCitas - Panel del Doctor";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            // IMPORTANTE: ORDEN PARA EL DOCK
            this.Controls.Add(this.tablaAgenda);
            this.Controls.Add(this.tablaTarjetas);
            this.Controls.Add(this.pnlEncabezado);

            // EVENTO LOAD
            this.Load += new System.EventHandler(
                this.FrmInicioDoctor_Load);

            // ========================================
            // FINALIZAR
            // ========================================
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();

            this.pnlCardHoy.ResumeLayout(false);
            this.pnlCardHoy.PerformLayout();

            this.pnlCardPendientes.ResumeLayout(false);
            this.pnlCardPendientes.PerformLayout();

            this.pnlCardAtendidas.ResumeLayout(false);
            this.pnlCardAtendidas.PerformLayout();

            this.tablaTarjetas.ResumeLayout(false);

            this.pnlBarraAgenda.ResumeLayout(false);
            this.pnlBarraAgenda.PerformLayout();

            this.tablaAgenda.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvAgenda)).EndInit();

            this.ResumeLayout(false);
        }

        #endregion
    }
}
