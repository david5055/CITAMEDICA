
namespace medicitass
{
    partial class FrmMantenimientoUsuarios
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.GroupBox grpBusqueda;
        private System.Windows.Forms.GroupBox grpAcciones;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtIdUsuario;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnInactivar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.DataGridView dgvUsuarios;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.grpBusqueda = new System.Windows.Forms.GroupBox();
            this.grpAcciones = new System.Windows.Forms.GroupBox();

            this.lblId = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.lblNota = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();

            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();

            this.cboRol = new System.Windows.Forms.ComboBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();

            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnInactivar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();

            this.dgvUsuarios = new System.Windows.Forms.DataGridView();

            this.pnlTitulo.SuspendLayout();
            this.grpDatos.SuspendLayout();
            this.grpBusqueda.SuspendLayout();
            this.grpAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)
                (this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            // ENCABEZADO
            this.pnlTitulo.BackColor =
                System.Drawing.Color.FromArgb(18, 61, 90);
            this.pnlTitulo.Dock =
                System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size =
                new System.Drawing.Size(1100, 75);

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI", 17F,
                    System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor =
                System.Drawing.Color.White;
            this.lblTitulo.Location =
                new System.Drawing.Point(25, 17);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text =
                "Gestión de Cuentas de Usuario y Acceso";

            this.pnlTitulo.Controls.Add(this.lblTitulo);

            // GRUPO DE DATOS
            this.grpDatos.Location =
                new System.Drawing.Point(20, 95);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size =
                new System.Drawing.Size(445, 490);
            this.grpDatos.Text = "Datos de usuario";
            this.grpDatos.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            // CODIGO
            this.lblId.AutoSize = true;
            this.lblId.Location =
                new System.Drawing.Point(20, 35);
            this.lblId.Text = "Código";

            this.txtIdUsuario.Location =
                new System.Drawing.Point(20, 62);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size =
                new System.Drawing.Size(190, 30);
            this.txtIdUsuario.ReadOnly = true;
            this.txtIdUsuario.BackColor =
                System.Drawing.Color.Gainsboro;

            // NOMBRE USUARIO
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location =
                new System.Drawing.Point(20, 110);
            this.lblNombre.Text = "Nombre de usuario";

            this.txtNombreUsuario.Location =
                new System.Drawing.Point(20, 137);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size =
                new System.Drawing.Size(395, 30);
            this.txtNombreUsuario.MaxLength = 50;
            this.txtNombreUsuario.TabIndex = 0;

            // CONTRASEÑA
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location =
                new System.Drawing.Point(20, 185);
            this.lblContrasena.Text = "Contraseña";

            this.txtContrasena.Location =
                new System.Drawing.Point(20, 212);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size =
                new System.Drawing.Size(395, 30);
            this.txtContrasena.UseSystemPasswordChar = true;
            this.txtContrasena.MaxLength = 128;
            this.txtContrasena.TabIndex = 1;

            // NOTA CONTRASEÑA
            this.lblNota.AutoSize = true;
            this.lblNota.Location =
                new System.Drawing.Point(20, 250);
            this.lblNota.Name = "lblNota";
            this.lblNota.Font =
                new System.Drawing.Font(
                    "Segoe UI", 8F,
                    System.Drawing.FontStyle.Italic);
            this.lblNota.ForeColor =
                System.Drawing.Color.Gray;
            this.lblNota.Text =
                "Mínimo 8 caracteres. En blanco no se modifica.";

            // ROL
            this.lblRol.AutoSize = true;
            this.lblRol.Location =
                new System.Drawing.Point(20, 295);
            this.lblRol.Text = "Rol del sistema";

            this.cboRol.Location =
                new System.Drawing.Point(20, 322);
            this.cboRol.Name = "cboRol";
            this.cboRol.Size =
                new System.Drawing.Size(395, 30);
            this.cboRol.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRol.TabIndex = 2;

            // ESTADO
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location =
                new System.Drawing.Point(20, 370);
            this.lblEstado.Text = "Estado";

            this.cboEstado.Location =
                new System.Drawing.Point(20, 397);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size =
                new System.Drawing.Size(395, 30);
            this.cboEstado.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.TabIndex = 3;

            this.grpDatos.Controls.Add(this.lblId);
            this.grpDatos.Controls.Add(this.txtIdUsuario);
            this.grpDatos.Controls.Add(this.lblNombre);
            this.grpDatos.Controls.Add(this.txtNombreUsuario);
            this.grpDatos.Controls.Add(this.lblContrasena);
            this.grpDatos.Controls.Add(this.txtContrasena);
            this.grpDatos.Controls.Add(this.lblNota);
            this.grpDatos.Controls.Add(this.lblRol);
            this.grpDatos.Controls.Add(this.cboRol);
            this.grpDatos.Controls.Add(this.lblEstado);
            this.grpDatos.Controls.Add(this.cboEstado);

            // GRUPO BUSQUEDA
            this.grpBusqueda.Location =
                new System.Drawing.Point(480, 95);
            this.grpBusqueda.Name = "grpBusqueda";
            this.grpBusqueda.Size =
                new System.Drawing.Size(600, 90);
            this.grpBusqueda.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.grpBusqueda.Text = "Buscar usuario";

            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location =
                new System.Drawing.Point(15, 35);
            this.lblBuscar.Text = "Usuario:";

            this.txtBuscar.Location =
                new System.Drawing.Point(90, 30);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size =
                new System.Drawing.Size(225, 30);

            this.btnBuscar.Location =
                new System.Drawing.Point(325, 27);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size =
                new System.Drawing.Size(115, 35);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.BackColor =
                System.Drawing.Color.FromArgb(0, 115, 185);
            this.btnBuscar.ForeColor =
                System.Drawing.Color.White;
            this.btnBuscar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click +=
                new System.EventHandler(this.btnBuscar_Click);

            this.btnRefrescar.Location =
                new System.Drawing.Point(450, 27);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size =
                new System.Drawing.Size(130, 35);
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.BackColor =
                System.Drawing.Color.Teal;
            this.btnRefrescar.ForeColor =
                System.Drawing.Color.White;
            this.btnRefrescar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.FlatAppearance.BorderSize = 0;
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click +=
                new System.EventHandler(this.btnRefrescar_Click);

            this.grpBusqueda.Controls.Add(this.lblBuscar);
            this.grpBusqueda.Controls.Add(this.txtBuscar);
            this.grpBusqueda.Controls.Add(this.btnBuscar);
            this.grpBusqueda.Controls.Add(this.btnRefrescar);

            // TABLA USUARIOS
            this.dgvUsuarios.Location =
                new System.Drawing.Point(480, 200);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size =
                new System.Drawing.Size(600, 480);
            this.dgvUsuarios.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.BackgroundColor =
                System.Drawing.Color.White;
            this.dgvUsuarios.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.dgvUsuarios.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvUsuarios.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvUsuarios.EnableHeadersVisualStyles = false;

            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(0, 115, 185);

            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;

            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);

            this.dgvUsuarios.ColumnHeadersHeight = 40;
            this.dgvUsuarios.RowTemplate.Height = 28;

            this.dgvUsuarios.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvUsuarios_CellClick);

            // GRUPO DE ACCIONES
            this.grpAcciones.Location =
                new System.Drawing.Point(20, 595);
            this.grpAcciones.Name = "grpAcciones";
            this.grpAcciones.Size =
                new System.Drawing.Size(445, 85);
            this.grpAcciones.Anchor =
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Bottom;

            // GUARDAR
            this.btnGuardar.Location =
                new System.Drawing.Point(12, 27);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size =
                new System.Drawing.Size(100, 40);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.BackColor =
                System.Drawing.Color.FromArgb(32, 165, 77);
            this.btnGuardar.ForeColor =
                System.Drawing.Color.White;
            this.btnGuardar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click +=
                new System.EventHandler(this.btnGuardar_Click);

            // MODIFICAR
            this.btnModificar.Location =
                new System.Drawing.Point(119, 27);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size =
                new System.Drawing.Size(100, 40);
            this.btnModificar.Text = "Modificar";
            this.btnModificar.BackColor =
                System.Drawing.Color.FromArgb(255, 190, 0);
            this.btnModificar.ForeColor =
                System.Drawing.Color.Black;
            this.btnModificar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Enabled = false;
            this.btnModificar.Click +=
                new System.EventHandler(this.btnModificar_Click);

            // INACTIVAR
            this.btnInactivar.Location =
                new System.Drawing.Point(226, 27);
            this.btnInactivar.Name = "btnInactivar";
            this.btnInactivar.Size =
                new System.Drawing.Size(100, 40);
            this.btnInactivar.Text = "Inactivar";
            this.btnInactivar.BackColor =
                System.Drawing.Color.Firebrick;
            this.btnInactivar.ForeColor =
                System.Drawing.Color.White;
            this.btnInactivar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnInactivar.FlatAppearance.BorderSize = 0;
            this.btnInactivar.UseVisualStyleBackColor = false;
            this.btnInactivar.Enabled = false;
            this.btnInactivar.Click +=
                new System.EventHandler(this.btnInactivar_Click);

            // LIMPIAR
            this.btnLimpiar.Location =
                new System.Drawing.Point(333, 27);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size =
                new System.Drawing.Size(100, 40);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.BackColor =
                System.Drawing.Color.DimGray;
            this.btnLimpiar.ForeColor =
                System.Drawing.Color.White;
            this.btnLimpiar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click +=
                new System.EventHandler(this.btnLimpiar_Click);

            this.grpAcciones.Controls.Add(this.btnGuardar);
            this.grpAcciones.Controls.Add(this.btnModificar);
            this.grpAcciones.Controls.Add(this.btnInactivar);
            this.grpAcciones.Controls.Add(this.btnLimpiar);

            // CONFIGURACIÓN DEL FORMULARIO
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor =
                System.Drawing.Color.FromArgb(245, 249, 252);
            this.ClientSize =
                new System.Drawing.Size(1100, 700);
            this.MinimumSize =
                new System.Drawing.Size(1100, 700);
            this.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmMantenimientoUsuarios";
            this.Text = "MediCitas - Mantenimiento de Usuarios";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.grpBusqueda);
            this.Controls.Add(this.grpAcciones);
            this.Controls.Add(this.dgvUsuarios);

            this.Load +=
                new System.EventHandler(
                    this.FrmMantenimientoUsuarios_Load);

            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.grpBusqueda.ResumeLayout(false);
            this.grpBusqueda.PerformLayout();
            this.grpAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)
                (this.dgvUsuarios)).EndInit();

            this.ResumeLayout(false);
        }

        #endregion
    }
}
