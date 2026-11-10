
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
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Label lblBuscar;

        private System.Windows.Forms.TextBox txtIdUsuario;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtBuscar;

        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.ComboBox cboDoctor;
        private System.Windows.Forms.ComboBox cboEstado;

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnInactivar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnRefrescar;

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.TableLayoutPanel tablaPrincipal;
        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.Panel pnlDerecha;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();

            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.grpBusqueda = new System.Windows.Forms.GroupBox();
            this.grpAcciones = new System.Windows.Forms.GroupBox();

            this.lblId = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblClave = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblNota = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();

            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();

            this.cboRol = new System.Windows.Forms.ComboBox();
            this.cboDoctor = new System.Windows.Forms.ComboBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();

            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnInactivar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();

            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.tablaPrincipal =
                new System.Windows.Forms.TableLayoutPanel();
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.pnlDerecha = new System.Windows.Forms.Panel();

            this.pnlTitulo.SuspendLayout();
            this.grpDatos.SuspendLayout();
            this.grpBusqueda.SuspendLayout();
            this.grpAcciones.SuspendLayout();
            this.pnlIzquierda.SuspendLayout();
            this.pnlDerecha.SuspendLayout();
            this.tablaPrincipal.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvUsuarios)).BeginInit();

            this.SuspendLayout();

            // =====================================
            // ENCABEZADO
            // =====================================
            this.pnlTitulo.Dock =
                System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Height = 78;
            this.pnlTitulo.BackColor =
                System.Drawing.Color.FromArgb(19, 105, 164);

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text =
                "Gestión de Cuentas de Usuario y Acceso";
            this.lblTitulo.ForeColor =
                System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font(
                "Segoe UI", 19F,
                System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location =
                new System.Drawing.Point(25, 19);

            this.pnlTitulo.Controls.Add(this.lblTitulo);

            // =====================================
            // DISTRIBUCIÓN PRINCIPAL
            // =====================================
            this.tablaPrincipal.Name = "tablaPrincipal";
            this.tablaPrincipal.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.tablaPrincipal.Padding =
                new System.Windows.Forms.Padding(12);
            this.tablaPrincipal.ColumnCount = 2;
            this.tablaPrincipal.RowCount = 1;

            this.tablaPrincipal.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Absolute,
                    445F));

            this.tablaPrincipal.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Percent,
                    100F));

            this.tablaPrincipal.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Percent,
                    100F));

            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.pnlIzquierda.AutoScroll = true;

            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.tablaPrincipal.Controls.Add(
                this.pnlIzquierda, 0, 0);
            this.tablaPrincipal.Controls.Add(
                this.pnlDerecha, 1, 0);

            // =====================================
            // GRUPO DATOS DEL USUARIO
            // =====================================
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Text = "Datos de la cuenta";
            this.grpDatos.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            this.grpDatos.Location =
                new System.Drawing.Point(5, 5);
            this.grpDatos.Size =
                new System.Drawing.Size(425, 475);

            // CÓDIGO
            this.lblId.Name = "lblId";
            this.lblId.Text = "Código:";
            this.lblId.AutoSize = true;
            this.lblId.Location =
                new System.Drawing.Point(23, 35);

            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Location =
                new System.Drawing.Point(25, 62);
            this.txtIdUsuario.Size =
                new System.Drawing.Size(365, 28);
            this.txtIdUsuario.ReadOnly = true;
            this.txtIdUsuario.BackColor =
                System.Drawing.Color.FromArgb(237, 241, 246);

            // NOMBRE DE USUARIO
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Text = "Nombre de usuario:";
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location =
                new System.Drawing.Point(23, 105);

            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Location =
                new System.Drawing.Point(25, 132);
            this.txtNombreUsuario.Size =
                new System.Drawing.Size(365, 28);
            this.txtNombreUsuario.MaxLength = 50;
            this.txtNombreUsuario.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Regular);

            // CONTRASEÑA
            this.lblClave.Name = "lblClave";
            this.lblClave.Text = "Contraseña:";
            this.lblClave.AutoSize = true;
            this.lblClave.Location =
                new System.Drawing.Point(23, 174);

            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Location =
                new System.Drawing.Point(25, 202);
            this.txtContrasena.Size =
                new System.Drawing.Size(365, 28);
            this.txtContrasena.MaxLength = 128;
            this.txtContrasena.UseSystemPasswordChar = true;
            this.txtContrasena.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Regular);

            // ROL
            this.lblRol.Name = "lblRol";
            this.lblRol.Text = "Rol del sistema:";
            this.lblRol.AutoSize = true;
            this.lblRol.Location =
                new System.Drawing.Point(23, 244);

            this.cboRol.Name = "cboRol";
            this.cboRol.Location =
                new System.Drawing.Point(25, 271);
            this.cboRol.Size =
                new System.Drawing.Size(365, 28);
            this.cboRol.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRol.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Regular);

            this.cboRol.SelectedIndexChanged +=
                new System.EventHandler(
                    this.cboRol_SelectedIndexChanged);

            // DOCTOR ASIGNADO (NUEVO)
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Text = "Doctor asignado:";
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Location =
                new System.Drawing.Point(23, 314);
            this.lblDoctor.ForeColor =
                System.Drawing.Color.FromArgb(21, 100, 147);

            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Location =
                new System.Drawing.Point(25, 341);
            this.cboDoctor.Size =
                new System.Drawing.Size(365, 28);
            this.cboDoctor.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoctor.Enabled = false;
            this.cboDoctor.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Regular);

            // ESTADO
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "Estado:";
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location =
                new System.Drawing.Point(23, 384);

            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Location =
                new System.Drawing.Point(25, 411);
            this.cboEstado.Size =
                new System.Drawing.Size(365, 28);
            this.cboEstado.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Regular);

            this.grpDatos.Controls.Add(this.lblId);
            this.grpDatos.Controls.Add(this.txtIdUsuario);
            this.grpDatos.Controls.Add(this.lblNombre);
            this.grpDatos.Controls.Add(this.txtNombreUsuario);
            this.grpDatos.Controls.Add(this.lblClave);
            this.grpDatos.Controls.Add(this.txtContrasena);
            this.grpDatos.Controls.Add(this.lblRol);
            this.grpDatos.Controls.Add(this.cboRol);
            this.grpDatos.Controls.Add(this.lblDoctor);
            this.grpDatos.Controls.Add(this.cboDoctor);
            this.grpDatos.Controls.Add(this.lblEstado);
            this.grpDatos.Controls.Add(this.cboEstado);

            // =====================================
            // NOTA DE CONTRASEÑA
            // =====================================
            this.lblNota.Name = "lblNota";
            this.lblNota.Text =
                "Al modificar, deje la contraseña vacía " +
                "para conservar la actual.";
            this.lblNota.AutoSize = false;
            this.lblNota.Location =
                new System.Drawing.Point(12, 487);
            this.lblNota.Size =
                new System.Drawing.Size(410, 42);
            this.lblNota.ForeColor =
                System.Drawing.Color.DimGray;
            this.lblNota.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F);

            // =====================================
            // BOTONES DE ACCIÓN
            // =====================================
            this.grpAcciones.Name = "grpAcciones";
            this.grpAcciones.Text = "Acciones";
            this.grpAcciones.Location =
                new System.Drawing.Point(5, 535);
            this.grpAcciones.Size =
                new System.Drawing.Size(425, 95);

            // GUARDAR
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location =
                new System.Drawing.Point(12, 32);
            this.btnGuardar.Size =
                new System.Drawing.Size(95, 43);
            this.btnGuardar.BackColor =
                System.Drawing.Color.FromArgb(36, 166, 91);
            this.btnGuardar.ForeColor =
                System.Drawing.Color.White;
            this.btnGuardar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click +=
                new System.EventHandler(
                    this.btnGuardar_Click);

            // MODIFICAR
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Location =
                new System.Drawing.Point(114, 32);
            this.btnModificar.Size =
                new System.Drawing.Size(95, 43);
            this.btnModificar.BackColor =
                System.Drawing.Color.FromArgb(242, 181, 25);
            this.btnModificar.ForeColor =
                System.Drawing.Color.Black;
            this.btnModificar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click +=
                new System.EventHandler(
                    this.btnModificar_Click);

            // INACTIVAR
            this.btnInactivar.Name = "btnInactivar";
            this.btnInactivar.Text = "Inactivar";
            this.btnInactivar.Location =
                new System.Drawing.Point(216, 32);
            this.btnInactivar.Size =
                new System.Drawing.Size(95, 43);
            this.btnInactivar.BackColor =
                System.Drawing.Color.FromArgb(202, 50, 61);
            this.btnInactivar.ForeColor =
                System.Drawing.Color.White;
            this.btnInactivar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnInactivar.FlatAppearance.BorderSize = 0;
            this.btnInactivar.UseVisualStyleBackColor = false;
            this.btnInactivar.Click +=
                new System.EventHandler(
                    this.btnInactivar_Click);

            // LIMPIAR
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Location =
                new System.Drawing.Point(318, 32);
            this.btnLimpiar.Size =
                new System.Drawing.Size(95, 43);
            this.btnLimpiar.BackColor =
                System.Drawing.Color.SlateGray;
            this.btnLimpiar.ForeColor =
                System.Drawing.Color.White;
            this.btnLimpiar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click +=
                new System.EventHandler(
                    this.btnLimpiar_Click);

            this.grpAcciones.Controls.Add(this.btnGuardar);
            this.grpAcciones.Controls.Add(this.btnModificar);
            this.grpAcciones.Controls.Add(this.btnInactivar);
            this.grpAcciones.Controls.Add(this.btnLimpiar);

            this.pnlIzquierda.Controls.Add(this.grpDatos);
            this.pnlIzquierda.Controls.Add(this.lblNota);
            this.pnlIzquierda.Controls.Add(this.grpAcciones);

            // =====================================
            // BUSCAR USUARIOS
            // =====================================
            this.grpBusqueda.Name = "grpBusqueda";
            this.grpBusqueda.Text = "Buscar usuarios";
            this.grpBusqueda.Dock =
                System.Windows.Forms.DockStyle.Top;
            this.grpBusqueda.Height = 100;

            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Text = "Nombre:";
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location =
                new System.Drawing.Point(16, 39);

            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Location =
                new System.Drawing.Point(88, 35);
            this.txtBuscar.Size =
                new System.Drawing.Size(235, 28);

            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Location =
                new System.Drawing.Point(335, 30);
            this.btnBuscar.Size =
                new System.Drawing.Size(95, 38);
            this.btnBuscar.BackColor =
                System.Drawing.Color.FromArgb(19, 105, 164);
            this.btnBuscar.ForeColor =
                System.Drawing.Color.White;
            this.btnBuscar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click +=
                new System.EventHandler(
                    this.btnBuscar_Click);

            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.Location =
                new System.Drawing.Point(438, 30);
            this.btnRefrescar.Size =
                new System.Drawing.Size(95, 38);
            this.btnRefrescar.BackColor =
                System.Drawing.Color.FromArgb(25, 165, 182);
            this.btnRefrescar.ForeColor =
                System.Drawing.Color.White;
            this.btnRefrescar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.FlatAppearance.BorderSize = 0;
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click +=
                new System.EventHandler(
                    this.btnRefrescar_Click);

            this.grpBusqueda.Controls.Add(this.lblBuscar);
            this.grpBusqueda.Controls.Add(this.txtBuscar);
            this.grpBusqueda.Controls.Add(this.btnBuscar);
            this.grpBusqueda.Controls.Add(this.btnRefrescar);

            // =====================================
            // TABLA DE USUARIOS
            // =====================================
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.Margin =
                new System.Windows.Forms.Padding(5);
            this.dgvUsuarios.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.RowHeadersVisible = false;

            this.dgvUsuarios.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvUsuarios.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvUsuarios.EnableHeadersVisualStyles = false;

            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(19, 105, 164);

            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;

            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            this.dgvUsuarios.ColumnHeadersHeight = 42;
            this.dgvUsuarios.RowTemplate.Height = 31;

            this.dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(239, 246, 251);

            this.dgvUsuarios.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvUsuarios_CellClick);

            this.pnlDerecha.Controls.Add(this.dgvUsuarios);
            this.pnlDerecha.Controls.Add(this.grpBusqueda);

            // =====================================
            // CONFIGURACIÓN DEL FORMULARIO
            // =====================================
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1250, 760);

            this.MinimumSize =
                new System.Drawing.Size(1050, 650);

            this.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.BackColor =
                System.Drawing.Color.FromArgb(245, 248, 252);

            this.Name = "FrmMantenimientoUsuarios";
            this.Text = "MediCitas - Gestión de Usuarios";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Controls.Add(this.tablaPrincipal);
            this.Controls.Add(this.pnlTitulo);

            this.Load +=
                new System.EventHandler(
                    this.FrmMantenimientoUsuarios_Load);

            // =====================================
            // FINALIZAR
            // =====================================
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();

            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();

            this.grpBusqueda.ResumeLayout(false);
            this.grpBusqueda.PerformLayout();

            this.grpAcciones.ResumeLayout(false);

            this.pnlIzquierda.ResumeLayout(false);
            this.pnlDerecha.ResumeLayout(false);
            this.tablaPrincipal.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvUsuarios)).EndInit();

            this.ResumeLayout(false);
        }


    }
}
