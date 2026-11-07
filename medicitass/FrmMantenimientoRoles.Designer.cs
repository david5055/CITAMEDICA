
namespace medicitass
{
    partial class FrmMantenimientoRoles
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblTotal;

        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtBuscar;

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.Button btnCerrar;

        private System.Windows.Forms.DataGridView dgvRoles;

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
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();

            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombreRol = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();

            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();

            this.dgvRoles = new System.Windows.Forms.DataGridView();

            this.pnlEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)
                (this.dgvRoles)).BeginInit();
            this.SuspendLayout();

            // ENCABEZADO
            this.pnlEncabezado.BackColor =
                System.Drawing.Color.FromArgb(18, 61, 90);
            this.pnlEncabezado.Dock =
                System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location =
                new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size =
                new System.Drawing.Size(1000, 100);

            // TITULO
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font(
                "Segoe UI", 21F,
                System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor =
                System.Drawing.Color.White;
            this.lblTitulo.Location =
                new System.Drawing.Point(28, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Mantenimiento de Roles";

            // SUBTITULO
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor =
                System.Drawing.Color.White;
            this.lblSubtitulo.Location =
                new System.Drawing.Point(32, 65);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Text =
                "Administración de perfiles y permisos de usuario";

            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);

            // LABEL CODIGO
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location =
                new System.Drawing.Point(40, 130);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Text = "Código del rol";

            // TEXTBOX CODIGO
            this.txtCodigo.Location =
                new System.Drawing.Point(40, 155);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size =
                new System.Drawing.Size(180, 28);
            this.txtCodigo.Text = "Automático";
            this.txtCodigo.BackColor =
                System.Drawing.Color.FromArgb(240, 244, 248);

            // LABEL NOMBRE
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location =
                new System.Drawing.Point(260, 130);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Text = "Nombre del rol";

            // TEXTBOX NOMBRE
            this.txtNombreRol.Location =
                new System.Drawing.Point(260, 155);
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size =
                new System.Drawing.Size(400, 28);
            this.txtNombreRol.MaxLength = 30;
            this.txtNombreRol.TabIndex = 0;

            // LABEL DESCRIPCION
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location =
                new System.Drawing.Point(40, 200);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Text = "Descripción del rol";

            // TEXTBOX DESCRIPCION
            this.txtDescripcion.Location =
                new System.Drawing.Point(40, 225);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size =
                new System.Drawing.Size(620, 65);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.MaxLength = 255;
            this.txtDescripcion.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.TabIndex = 1;

            // BOTON AGREGAR
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Location =
                new System.Drawing.Point(40, 315);
            this.btnAgregar.Size =
                new System.Drawing.Size(130, 42);
            this.btnAgregar.BackColor =
                System.Drawing.Color.SeaGreen;
            this.btnAgregar.ForeColor =
                System.Drawing.Color.White;
            this.btnAgregar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Click +=
                new System.EventHandler(this.btnAgregar_Click);

            // BOTON MODIFICAR
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Location =
                new System.Drawing.Point(185, 315);
            this.btnModificar.Size =
                new System.Drawing.Size(130, 42);
            this.btnModificar.BackColor =
                System.Drawing.Color.SteelBlue;
            this.btnModificar.ForeColor =
                System.Drawing.Color.White;
            this.btnModificar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Enabled = false;
            this.btnModificar.Click +=
                new System.EventHandler(this.btnModificar_Click);

            // BOTON ELIMINAR
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location =
                new System.Drawing.Point(330, 315);
            this.btnEliminar.Size =
                new System.Drawing.Size(130, 42);
            this.btnEliminar.BackColor =
                System.Drawing.Color.Firebrick;
            this.btnEliminar.ForeColor =
                System.Drawing.Color.White;
            this.btnEliminar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Click +=
                new System.EventHandler(this.btnEliminar_Click);

            // BOTON LIMPIAR
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Location =
                new System.Drawing.Point(475, 315);
            this.btnLimpiar.Size =
                new System.Drawing.Size(130, 42);
            this.btnLimpiar.BackColor =
                System.Drawing.Color.DimGray;
            this.btnLimpiar.ForeColor =
                System.Drawing.Color.White;
            this.btnLimpiar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Click +=
                new System.EventHandler(this.btnLimpiar_Click);

            // LABEL BUSCAR
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location =
                new System.Drawing.Point(40, 390);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Text = "Buscar rol por nombre";

            // TEXTBOX BUSCAR
            this.txtBuscar.Location =
                new System.Drawing.Point(40, 415);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size =
                new System.Drawing.Size(355, 28);
            this.txtBuscar.TabIndex = 6;

            // BOTON BUSCAR
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Location =
                new System.Drawing.Point(410, 408);
            this.btnBuscar.Size =
                new System.Drawing.Size(125, 38);
            this.btnBuscar.BackColor =
                System.Drawing.Color.SteelBlue;
            this.btnBuscar.ForeColor =
                System.Drawing.Color.White;
            this.btnBuscar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Click +=
                new System.EventHandler(this.btnBuscar_Click);

            // BOTON MOSTRAR TODOS
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Text = "Mostrar todos";
            this.btnMostrarTodos.Location =
                new System.Drawing.Point(550, 408);
            this.btnMostrarTodos.Size =
                new System.Drawing.Size(145, 38);
            this.btnMostrarTodos.BackColor =
                System.Drawing.Color.Teal;
            this.btnMostrarTodos.ForeColor =
                System.Drawing.Color.White;
            this.btnMostrarTodos.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarTodos.FlatAppearance.BorderSize = 0;
            this.btnMostrarTodos.UseVisualStyleBackColor = false;
            this.btnMostrarTodos.TabIndex = 8;
            this.btnMostrarTodos.Click +=
                new System.EventHandler(this.btnMostrarTodos_Click);

            // TABLA ROLES
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.Location =
                new System.Drawing.Point(40, 470);
            this.dgvRoles.Size =
                new System.Drawing.Size(920, 235);
            this.dgvRoles.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToDeleteRows = false;
            this.dgvRoles.ReadOnly = true;
            this.dgvRoles.MultiSelect = false;

            this.dgvRoles.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvRoles.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvRoles.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvRoles.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.dgvRoles.RowHeadersVisible = false;
            this.dgvRoles.EnableHeadersVisualStyles = false;

            this.dgvRoles.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(18, 105, 160);

            this.dgvRoles.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;

            this.dgvRoles.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            this.dgvRoles.ColumnHeadersHeight = 38;
            this.dgvRoles.RowTemplate.Height = 30;

            this.dgvRoles.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvRoles_CellClick);

            // TOTAL
            this.lblTotal.AutoSize = true;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Text = "Total de roles: 0";
            this.lblTotal.Location =
                new System.Drawing.Point(40, 720);
            this.lblTotal.Font = new System.Drawing.Font(
                "Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);
            this.lblTotal.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;

            // BOTON CERRAR
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Location =
                new System.Drawing.Point(830, 715);
            this.btnCerrar.Size =
                new System.Drawing.Size(130, 38);
            this.btnCerrar.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.BackColor =
                System.Drawing.Color.DimGray;
            this.btnCerrar.ForeColor =
                System.Drawing.Color.White;
            this.btnCerrar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click +=
                new System.EventHandler(this.btnCerrar_Click);

            // CONFIGURACION DEL FORMULARIO
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1000, 775);
            this.MinimumSize =
                new System.Drawing.Size(900, 700);

            this.BackColor =
                System.Drawing.Color.FromArgb(247, 249, 252);

            this.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.Name = "FrmMantenimientoRoles";
            this.Text = "MediCitas - Mantenimiento de Roles";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Controls.Add(this.pnlEncabezado);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombreRol);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);

            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);

            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnMostrarTodos);

            this.Controls.Add(this.dgvRoles);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnCerrar);

            this.Load +=
                new System.EventHandler(
                    this.FrmMantenimientoRoles_Load);

            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvRoles)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
