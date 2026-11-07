
namespace medicitass
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnSalir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();

            this.pnlEncabezado.SuspendLayout();
            this.SuspendLayout();

            // PANEL AZUL
            this.pnlEncabezado.BackColor =
                System.Drawing.Color.FromArgb(18, 61, 90);
            this.pnlEncabezado.Dock =
                System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Height = 125;
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.lblDescripcion);

            // TITULO
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font(
                "Segoe UI", 22F,
                System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(175, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "MediCitas";

            // DESCRIPCION
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion.Location =
                new System.Drawing.Point(115, 75);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Text =
                "Sistema de Gestión de Citas Médicas";

            // TITULO INICIAR SESION
            this.lblInicio.AutoSize = true;
            this.lblInicio.Font = new System.Drawing.Font(
                "Segoe UI", 15F,
                System.Drawing.FontStyle.Bold);
            this.lblInicio.Location =
                new System.Drawing.Point(180, 145);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Text = "Iniciar sesión";

            // USUARIO
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location =
                new System.Drawing.Point(90, 195);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Text = "Usuario";

            this.txtUsuario.Font =
                new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsuario.Location =
                new System.Drawing.Point(90, 220);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size =
                new System.Drawing.Size(330, 30);
            this.txtUsuario.TabIndex = 0;

            // CONTRASEÑA
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location =
                new System.Drawing.Point(90, 265);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Text = "Contraseña";

            this.txtContrasena.Font =
                new System.Drawing.Font("Segoe UI", 11F);
            this.txtContrasena.Location =
                new System.Drawing.Point(90, 290);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size =
                new System.Drawing.Size(330, 30);
            this.txtContrasena.UseSystemPasswordChar = true;
            this.txtContrasena.TabIndex = 1;

            // BOTON INGRESAR
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.Location =
                new System.Drawing.Point(90, 350);
            this.btnIngresar.Size =
                new System.Drawing.Size(155, 40);
            this.btnIngresar.BackColor =
                System.Drawing.Color.SteelBlue;
            this.btnIngresar.ForeColor =
                System.Drawing.Color.White;
            this.btnIngresar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.TabIndex = 2;
            this.btnIngresar.Click +=
                new System.EventHandler(this.btnIngresar_Click);

            // BOTON SALIR
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "Salir";
            this.btnSalir.Location =
                new System.Drawing.Point(265, 350);
            this.btnSalir.Size =
                new System.Drawing.Size(155, 40);
            this.btnSalir.BackColor =
                System.Drawing.Color.DimGray;
            this.btnSalir.ForeColor =
                System.Drawing.Color.White;
            this.btnSalir.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Click +=
                new System.EventHandler(this.btnSalir_Click);

            // FORMULARIO PRINCIPAL
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize =
                new System.Drawing.Size(520, 440);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediCitas - Inicio de sesión";
            this.AcceptButton = this.btnIngresar;

            this.Controls.Add(this.pnlEncabezado);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.btnSalir);

            this.Load +=
                new System.EventHandler(this.FrmLogin_Load);

            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
