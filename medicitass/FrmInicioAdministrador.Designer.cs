
namespace medicitass
{
    partial class FrmInicioAdministrador
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnActualizar;

        private System.Windows.Forms.Panel pnlDoctores;
        private System.Windows.Forms.Panel pnlPacientes;
        private System.Windows.Forms.Panel pnlCitasHoy;
        private System.Windows.Forms.Panel pnlPendientes;
        private System.Windows.Forms.Panel pnlAtendidas;
        private System.Windows.Forms.Panel pnlCanceladas;

        private System.Windows.Forms.Label lblTextoDoctores;
        private System.Windows.Forms.Label lblTextoPacientes;
        private System.Windows.Forms.Label lblTextoCitasHoy;
        private System.Windows.Forms.Label lblTextoPendientes;
        private System.Windows.Forms.Label lblTextoAtendidas;
        private System.Windows.Forms.Label lblTextoCanceladas;

        private System.Windows.Forms.Label lblNumeroDoctores;
        private System.Windows.Forms.Label lblNumeroPacientes;
        private System.Windows.Forms.Label lblNumeroCitasHoy;
        private System.Windows.Forms.Label lblNumeroPendientes;
        private System.Windows.Forms.Label lblNumeroAtendidas;
        private System.Windows.Forms.Label lblNumeroCanceladas;

        private System.Windows.Forms.Label lblTituloCitas;
        private System.Windows.Forms.Label lblTotalProximas;
        private System.Windows.Forms.Label lblActualizacion;
        private System.Windows.Forms.DataGridView dgvProximasCitas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();

            this.pnlDoctores = new System.Windows.Forms.Panel();
            this.pnlPacientes = new System.Windows.Forms.Panel();
            this.pnlCitasHoy = new System.Windows.Forms.Panel();
            this.pnlPendientes = new System.Windows.Forms.Panel();
            this.pnlAtendidas = new System.Windows.Forms.Panel();
            this.pnlCanceladas = new System.Windows.Forms.Panel();

            this.lblTextoDoctores = new System.Windows.Forms.Label();
            this.lblTextoPacientes = new System.Windows.Forms.Label();
            this.lblTextoCitasHoy = new System.Windows.Forms.Label();
            this.lblTextoPendientes = new System.Windows.Forms.Label();
            this.lblTextoAtendidas = new System.Windows.Forms.Label();
            this.lblTextoCanceladas = new System.Windows.Forms.Label();

            this.lblNumeroDoctores = new System.Windows.Forms.Label();
            this.lblNumeroPacientes = new System.Windows.Forms.Label();
            this.lblNumeroCitasHoy = new System.Windows.Forms.Label();
            this.lblNumeroPendientes = new System.Windows.Forms.Label();
            this.lblNumeroAtendidas = new System.Windows.Forms.Label();
            this.lblNumeroCanceladas = new System.Windows.Forms.Label();

            this.lblTituloCitas = new System.Windows.Forms.Label();
            this.lblTotalProximas = new System.Windows.Forms.Label();
            this.lblActualizacion = new System.Windows.Forms.Label();
            this.dgvProximasCitas =
                new System.Windows.Forms.DataGridView();

            this.pnlEncabezado.SuspendLayout();
            this.pnlDoctores.SuspendLayout();
            this.pnlPacientes.SuspendLayout();
            this.pnlCitasHoy.SuspendLayout();
            this.pnlPendientes.SuspendLayout();
            this.pnlAtendidas.SuspendLayout();
            this.pnlCanceladas.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvProximasCitas)).BeginInit();

            this.SuspendLayout();

            // =========================================
            // ENCABEZADO
            // =========================================
            this.pnlEncabezado.BackColor =
                System.Drawing.Color.FromArgb(18, 61, 90);
            this.pnlEncabezado.Dock =
                System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size =
                new System.Drawing.Size(1100, 100);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.btnActualizar);

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Panel de Administración";
            this.lblTitulo.Font = new System.Drawing.Font(
                "Segoe UI", 21F,
                System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location =
                new System.Drawing.Point(25, 13);

            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Text =
                "Resumen general de la clínica MediCitas";
            this.lblSubtitulo.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor =
                System.Drawing.Color.White;
            this.lblSubtitulo.Location =
                new System.Drawing.Point(29, 67);

            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Size =
                new System.Drawing.Size(135, 40);
            this.btnActualizar.Location =
                new System.Drawing.Point(930, 30);
            this.btnActualizar.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right;
            this.btnActualizar.BackColor =
                System.Drawing.Color.FromArgb(32, 149, 171);
            this.btnActualizar.ForeColor =
                System.Drawing.Color.White;
            this.btnActualizar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click +=
                new System.EventHandler(
                    this.btnActualizar_Click);

            // =========================================
            // TARJETA DOCTORES
            // =========================================
            this.pnlDoctores.Name = "pnlDoctores";
            this.pnlDoctores.Location =
                new System.Drawing.Point(25, 120);
            this.pnlDoctores.Size =
                new System.Drawing.Size(325, 115);
            this.pnlDoctores.BackColor =
                System.Drawing.Color.FromArgb(225, 240, 250);
            this.pnlDoctores.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDoctores.Controls.Add(this.lblTextoDoctores);
            this.pnlDoctores.Controls.Add(this.lblNumeroDoctores);

            this.lblTextoDoctores.AutoSize = true;
            this.lblTextoDoctores.Name = "lblTextoDoctores";
            this.lblTextoDoctores.Text = "DOCTORES ACTIVOS";
            this.lblTextoDoctores.Font = new System.Drawing.Font(
                "Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);
            this.lblTextoDoctores.ForeColor =
                System.Drawing.Color.FromArgb(24, 92, 145);
            this.lblTextoDoctores.Location =
                new System.Drawing.Point(18, 15);

            this.lblNumeroDoctores.AutoSize = true;
            this.lblNumeroDoctores.Name = "lblNumeroDoctores";
            this.lblNumeroDoctores.Text = "0";
            this.lblNumeroDoctores.Font = new System.Drawing.Font(
                "Segoe UI", 28F,
                System.Drawing.FontStyle.Bold);
            this.lblNumeroDoctores.ForeColor =
                System.Drawing.Color.FromArgb(24, 92, 145);
            this.lblNumeroDoctores.Location =
                new System.Drawing.Point(18, 42);

            // =========================================
            // TARJETA PACIENTES
            // =========================================
            this.pnlPacientes.Name = "pnlPacientes";
            this.pnlPacientes.Location =
                new System.Drawing.Point(385, 120);
            this.pnlPacientes.Size =
                new System.Drawing.Size(325, 115);
            this.pnlPacientes.BackColor =
                System.Drawing.Color.FromArgb(226, 245, 234);
            this.pnlPacientes.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPacientes.Controls.Add(this.lblTextoPacientes);
            this.pnlPacientes.Controls.Add(this.lblNumeroPacientes);

            this.lblTextoPacientes.AutoSize = true;
            this.lblTextoPacientes.Name = "lblTextoPacientes";
            this.lblTextoPacientes.Text = "PACIENTES ACTIVOS";
            this.lblTextoPacientes.Font = new System.Drawing.Font(
                "Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);
            this.lblTextoPacientes.ForeColor =
                System.Drawing.Color.DarkGreen;
            this.lblTextoPacientes.Location =
                new System.Drawing.Point(18, 15);

            this.lblNumeroPacientes.AutoSize = true;
            this.lblNumeroPacientes.Name = "lblNumeroPacientes";
            this.lblNumeroPacientes.Text = "0";
            this.lblNumeroPacientes.Font = new System.Drawing.Font(
                "Segoe UI", 28F,
                System.Drawing.FontStyle.Bold);
            this.lblNumeroPacientes.ForeColor =
                System.Drawing.Color.DarkGreen;
            this.lblNumeroPacientes.Location =
                new System.Drawing.Point(18, 42);

            // =========================================
            // TARJETA CITAS HOY
            // =========================================
            this.pnlCitasHoy.Name = "pnlCitasHoy";
            this.pnlCitasHoy.Location =
                new System.Drawing.Point(745, 120);
            this.pnlCitasHoy.Size =
                new System.Drawing.Size(325, 115);
            this.pnlCitasHoy.BackColor =
                System.Drawing.Color.FromArgb(237, 230, 250);
            this.pnlCitasHoy.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCitasHoy.Controls.Add(this.lblTextoCitasHoy);
            this.pnlCitasHoy.Controls.Add(this.lblNumeroCitasHoy);

            this.lblTextoCitasHoy.AutoSize = true;
            this.lblTextoCitasHoy.Name = "lblTextoCitasHoy";
            this.lblTextoCitasHoy.Text = "CITAS DE HOY";
            this.lblTextoCitasHoy.Font = new System.Drawing.Font(
                "Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);
            this.lblTextoCitasHoy.ForeColor =
                System.Drawing.Color.DarkSlateBlue;
            this.lblTextoCitasHoy.Location =
                new System.Drawing.Point(18, 15);

            this.lblNumeroCitasHoy.AutoSize = true;
            this.lblNumeroCitasHoy.Name = "lblNumeroCitasHoy";
            this.lblNumeroCitasHoy.Text = "0";
            this.lblNumeroCitasHoy.Font = new System.Drawing.Font(
                "Segoe UI", 28F,
                System.Drawing.FontStyle.Bold);
            this.lblNumeroCitasHoy.ForeColor =
                System.Drawing.Color.DarkSlateBlue;
            this.lblNumeroCitasHoy.Location =
                new System.Drawing.Point(18, 42);

            // =========================================
            // TARJETA PENDIENTES
            // =========================================
            this.pnlPendientes.Name = "pnlPendientes";
            this.pnlPendientes.Location =
                new System.Drawing.Point(25, 250);
            this.pnlPendientes.Size =
                new System.Drawing.Size(325, 115);
            this.pnlPendientes.BackColor =
                System.Drawing.Color.FromArgb(255, 245, 221);
            this.pnlPendientes.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPendientes.Controls.Add(this.lblTextoPendientes);
            this.pnlPendientes.Controls.Add(this.lblNumeroPendientes);

            this.lblTextoPendientes.AutoSize = true;
            this.lblTextoPendientes.Name = "lblTextoPendientes";
            this.lblTextoPendientes.Text = "CITAS PENDIENTES";
            this.lblTextoPendientes.Font = new System.Drawing.Font(
                "Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);
            this.lblTextoPendientes.ForeColor =
                System.Drawing.Color.DarkGoldenrod;
            this.lblTextoPendientes.Location =
                new System.Drawing.Point(18, 15);

            this.lblNumeroPendientes.AutoSize = true;
            this.lblNumeroPendientes.Name = "lblNumeroPendientes";
            this.lblNumeroPendientes.Text = "0";
            this.lblNumeroPendientes.Font = new System.Drawing.Font(
                "Segoe UI", 28F,
                System.Drawing.FontStyle.Bold);
            this.lblNumeroPendientes.ForeColor =
                System.Drawing.Color.DarkGoldenrod;
            this.lblNumeroPendientes.Location =
                new System.Drawing.Point(18, 42);

            // =========================================
            // TARJETA ATENDIDAS
            // =========================================
            this.pnlAtendidas.Name = "pnlAtendidas";
            this.pnlAtendidas.Location =
                new System.Drawing.Point(385, 250);
            this.pnlAtendidas.Size =
                new System.Drawing.Size(325, 115);
            this.pnlAtendidas.BackColor =
                System.Drawing.Color.FromArgb(222, 245, 243);
            this.pnlAtendidas.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAtendidas.Controls.Add(this.lblTextoAtendidas);
            this.pnlAtendidas.Controls.Add(this.lblNumeroAtendidas);

            this.lblTextoAtendidas.AutoSize = true;
            this.lblTextoAtendidas.Name = "lblTextoAtendidas";
            this.lblTextoAtendidas.Text = "CITAS ATENDIDAS";
            this.lblTextoAtendidas.Font = new System.Drawing.Font(
                "Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);
            this.lblTextoAtendidas.ForeColor =
                System.Drawing.Color.Teal;
            this.lblTextoAtendidas.Location =
                new System.Drawing.Point(18, 15);

            this.lblNumeroAtendidas.AutoSize = true;
            this.lblNumeroAtendidas.Name = "lblNumeroAtendidas";
            this.lblNumeroAtendidas.Text = "0";
            this.lblNumeroAtendidas.Font = new System.Drawing.Font(
                "Segoe UI", 28F,
                System.Drawing.FontStyle.Bold);
            this.lblNumeroAtendidas.ForeColor =
                System.Drawing.Color.Teal;
            this.lblNumeroAtendidas.Location =
                new System.Drawing.Point(18, 42);

            // =========================================
            // TARJETA CANCELADAS
            // =========================================
            this.pnlCanceladas.Name = "pnlCanceladas";
            this.pnlCanceladas.Location =
                new System.Drawing.Point(745, 250);
            this.pnlCanceladas.Size =
                new System.Drawing.Size(325, 115);
            this.pnlCanceladas.BackColor =
                System.Drawing.Color.FromArgb(252, 233, 233);
            this.pnlCanceladas.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCanceladas.Controls.Add(this.lblTextoCanceladas);
            this.pnlCanceladas.Controls.Add(this.lblNumeroCanceladas);

            this.lblTextoCanceladas.AutoSize = true;
            this.lblTextoCanceladas.Name = "lblTextoCanceladas";
            this.lblTextoCanceladas.Text = "CITAS CANCELADAS";
            this.lblTextoCanceladas.Font = new System.Drawing.Font(
                "Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);
            this.lblTextoCanceladas.ForeColor =
                System.Drawing.Color.Firebrick;
            this.lblTextoCanceladas.Location =
                new System.Drawing.Point(18, 15);

            this.lblNumeroCanceladas.AutoSize = true;
            this.lblNumeroCanceladas.Name = "lblNumeroCanceladas";
            this.lblNumeroCanceladas.Text = "0";
            this.lblNumeroCanceladas.Font = new System.Drawing.Font(
                "Segoe UI", 28F,
                System.Drawing.FontStyle.Bold);
            this.lblNumeroCanceladas.ForeColor =
                System.Drawing.Color.Firebrick;
            this.lblNumeroCanceladas.Location =
                new System.Drawing.Point(18, 42);

            // =========================================
            // ENCABEZADO TABLA
            // =========================================
            this.lblTituloCitas.AutoSize = true;
            this.lblTituloCitas.Name = "lblTituloCitas";
            this.lblTituloCitas.Text =
                "Próximas citas programadas";
            this.lblTituloCitas.Font = new System.Drawing.Font(
                "Segoe UI", 15F,
                System.Drawing.FontStyle.Bold);
            this.lblTituloCitas.ForeColor =
                System.Drawing.Color.FromArgb(18, 61, 90);
            this.lblTituloCitas.Location =
                new System.Drawing.Point(25, 385);

            // =========================================
            // TABLA
            // =========================================
            this.dgvProximasCitas.Name = "dgvProximasCitas";
            this.dgvProximasCitas.Location =
                new System.Drawing.Point(25, 430);
            this.dgvProximasCitas.Size =
                new System.Drawing.Size(1045, 230);

            this.dgvProximasCitas.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.dgvProximasCitas.AllowUserToAddRows = false;
            this.dgvProximasCitas.AllowUserToDeleteRows = false;
            this.dgvProximasCitas.ReadOnly = true;
            this.dgvProximasCitas.MultiSelect = false;
            this.dgvProximasCitas.RowHeadersVisible = false;

            this.dgvProximasCitas.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvProximasCitas.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvProximasCitas.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvProximasCitas.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.dgvProximasCitas.EnableHeadersVisualStyles = false;

            this.dgvProximasCitas.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(18, 105, 160);

            this.dgvProximasCitas.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;

            this.dgvProximasCitas.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            this.dgvProximasCitas.ColumnHeadersHeight = 38;
            this.dgvProximasCitas.RowTemplate.Height = 30;

            // =========================================
            // PIE DE PÁGINA
            // =========================================
            this.lblTotalProximas.AutoSize = true;
            this.lblTotalProximas.Name = "lblTotalProximas";
            this.lblTotalProximas.Text =
                "Próximas citas mostradas: 0";
            this.lblTotalProximas.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);
            this.lblTotalProximas.Location =
                new System.Drawing.Point(25, 678);

            this.lblActualizacion.AutoSize = true;
            this.lblActualizacion.Name = "lblActualizacion";
            this.lblActualizacion.Text =
                "Última actualización: --";
            this.lblActualizacion.ForeColor =
                System.Drawing.Color.Gray;
            this.lblActualizacion.Location =
                new System.Drawing.Point(25, 708);

            // =========================================
            // CONFIGURACIÓN DEL FORMULARIO
            // =========================================
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize =
                new System.Drawing.Size(1100, 750);
            this.MinimumSize =
                new System.Drawing.Size(1090, 720);
            this.BackColor =
                System.Drawing.Color.FromArgb(247, 249, 252);
            this.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmInicioAdministrador";
            this.Text = "MediCitas - Inicio Administrador";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Controls.Add(this.pnlEncabezado);
            this.Controls.Add(this.pnlDoctores);
            this.Controls.Add(this.pnlPacientes);
            this.Controls.Add(this.pnlCitasHoy);
            this.Controls.Add(this.pnlPendientes);
            this.Controls.Add(this.pnlAtendidas);
            this.Controls.Add(this.pnlCanceladas);
            this.Controls.Add(this.lblTituloCitas);
            this.Controls.Add(this.dgvProximasCitas);
            this.Controls.Add(this.lblTotalProximas);
            this.Controls.Add(this.lblActualizacion);

            this.Load += new System.EventHandler(
                this.FrmInicioAdministrador_Load);

            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();

            this.pnlDoctores.ResumeLayout(false);
            this.pnlDoctores.PerformLayout();
            this.pnlPacientes.ResumeLayout(false);
            this.pnlPacientes.PerformLayout();
            this.pnlCitasHoy.ResumeLayout(false);
            this.pnlCitasHoy.PerformLayout();
            this.pnlPendientes.ResumeLayout(false);
            this.pnlPendientes.PerformLayout();
            this.pnlAtendidas.ResumeLayout(false);
            this.pnlAtendidas.PerformLayout();
            this.pnlCanceladas.ResumeLayout(false);
            this.pnlCanceladas.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvProximasCitas)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
