
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(
            object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void btnIngresar_Click(
            object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtContrasena.Text;

            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("Ingrese su usuario.");
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(clave))
            {
                MessageBox.Show("Ingrese su contraseña.");
                txtContrasena.Focus();
                return;
            }

            btnIngresar.Enabled = false;

            try
            {
                using (SqlConnection cn =
                    new Conexion().Conectar())
                {
                    cn.Open();

                    // Obtener el usuario y su rol
                    // desde la base de datos.

                    string sql = @"
                        SELECT
                            u.id_usuario,
                            u.nombre_usuario,
                            u.contrasena_hash,
                            u.estado,
                            ISNULL(u.intentos_fallidos, 0),
                            u.bloqueo_hasta,
                            r.nombre_rol,
                            GETDATE()
                        FROM Usuarios u
                        INNER JOIN Roles r
                            ON u.id_rol = r.id_rol
                        WHERE u.nombre_usuario = @usuario";

                    using (SqlTransaction tx =
                        cn.BeginTransaction())
                    {
                        try
                        {
                            int idUsuario = 0;
                            int intentos = 0;

                            string nombreUsuario = "";
                            string hashGuardado = "";
                            string estado = "";
                            string rol = "";

                            DateTime? bloqueoHasta = null;
                            DateTime fechaServidor = DateTime.Now;
                            bool encontrado = false;

                            using (SqlCommand cmd =
                                new SqlCommand(sql, cn, tx))
                            {
                                cmd.Parameters.Add(
                                    "@usuario",
                                    SqlDbType.VarChar, 50
                                ).Value = usuario;

                                using (SqlDataReader dr =
                                    cmd.ExecuteReader())
                                {
                                    if (dr.Read())
                                    {
                                        encontrado = true;

                                        idUsuario = dr.GetInt32(0);
                                        nombreUsuario = dr.GetString(1);
                                        hashGuardado = dr.GetString(2);

                                        estado = dr.IsDBNull(3)
                                            ? ""
                                            : dr.GetString(3);

                                        intentos = dr.GetInt32(4);

                                        if (!dr.IsDBNull(5))
                                            bloqueoHasta =
                                                dr.GetDateTime(5);

                                        rol = dr.GetString(6);
                                        fechaServidor = dr.GetDateTime(7);
                                    }
                                }
                            }

                            if (!encontrado)
                            {
                                tx.Commit();
                                MostrarCredencialesInvalidas();
                                return;
                            }

                            // VERIFICAR ESTADO
                            if (!estado.Equals(
                                "Activo",
                                StringComparison.OrdinalIgnoreCase))
                            {
                                tx.Commit();

                                MessageBox.Show(
                                    "Esta cuenta no está activa.",
                                    "Acceso denegado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                return;
                            }

                            // VERIFICAR BLOQUEO
                            if (bloqueoHasta.HasValue &&
                                bloqueoHasta.Value > fechaServidor)
                            {
                                tx.Commit();

                                MessageBox.Show(
                                    "La cuenta está bloqueada " +
                                    "temporalmente.",
                                    "Cuenta bloqueada",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                return;
                            }

                            // VERIFICAR CONTRASEÑA
                            bool claveCorrecta =
                                SeguridadPassword.Verificar(
                                    clave, hashGuardado);

                            if (!claveCorrecta)
                            {
                                if (bloqueoHasta.HasValue &&
                                    bloqueoHasta.Value <= fechaServidor)
                                {
                                    intentos = 0;
                                }

                                intentos++;

                                DateTime? nuevoBloqueo = null;

                                if (intentos >= 3)
                                {
                                    nuevoBloqueo =
                                        fechaServidor.AddMinutes(15);
                                }

                                string actualizar = @"
                                    UPDATE Usuarios
                                    SET intentos_fallidos = @intentos,
                                        bloqueo_hasta = @bloqueo
                                    WHERE id_usuario = @id";

                                using (SqlCommand cmd =
                                    new SqlCommand(
                                        actualizar, cn, tx))
                                {
                                    cmd.Parameters.Add(
                                        "@intentos", SqlDbType.Int
                                    ).Value = intentos;

                                    cmd.Parameters.Add(
                                        "@bloqueo",
                                        SqlDbType.DateTime2
                                    ).Value =
                                        (object)nuevoBloqueo ??
                                        DBNull.Value;

                                    cmd.Parameters.Add(
                                        "@id", SqlDbType.Int
                                    ).Value = idUsuario;

                                    cmd.ExecuteNonQuery();
                                }

                                tx.Commit();

                                if (nuevoBloqueo.HasValue)
                                {
                                    MessageBox.Show(
                                        "Cuenta bloqueada por 15 minutos.",
                                        "Seguridad MediCitas",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    MostrarCredencialesInvalidas();
                                }

                                txtContrasena.Clear();
                                return;
                            }

                            // REINICIAR INTENTOS FALLIDOS
                            string reiniciar = @"
                                UPDATE Usuarios
                                SET intentos_fallidos = 0,
                                    bloqueo_hasta = NULL
                                WHERE id_usuario = @id";

                            using (SqlCommand cmd =
                                new SqlCommand(reiniciar, cn, tx))
                            {
                                cmd.Parameters.Add(
                                    "@id", SqlDbType.Int
                                ).Value = idUsuario;

                                cmd.ExecuteNonQuery();
                            }

                            tx.Commit();

                            // VERIFICAR EL ROL
                            if (!EsRolPermitido(rol))
                            {
                                MessageBox.Show(
                                    "El rol de este usuario " +
                                    "no tiene acceso configurado.",
                                    "MediCitas",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                return;
                            }

                            // ABRIR MENÚ SEGÚN SU ROL
                            AbrirMenu(nombreUsuario, rol);
                        }
                        catch
                        {
                            try
                            {
                                tx.Rollback();
                            }
                            catch
                            {
                            }

                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "No fue posible iniciar sesión. " +
                    "Revise la conexión con SQL Server.",
                    "Error MediCitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnIngresar.Enabled = true;
            }
        }

        // VALIDAR QUE EL ROL SEA RECONOCIDO
        private bool EsRolPermitido(string rol)
        {
            return
                rol.Equals("Administrador",
                    StringComparison.OrdinalIgnoreCase)
                ||
                rol.Equals("Recepcionista",
                    StringComparison.OrdinalIgnoreCase)
                ||
                rol.Equals("Doctor",
                    StringComparison.OrdinalIgnoreCase);
        }

        // ABRIR EL MENÚ CON EL ROL REAL
        private void AbrirMenu(
            string nombreUsuario, string rol)
        {
            FrmMenuPrincipal menu =
                new FrmMenuPrincipal(
                    nombreUsuario,
                    rol,
                    this);

            txtContrasena.Clear();

            menu.Show();
            this.Hide();
        }

        private void MostrarCredencialesInvalidas()
        {
            MessageBox.Show(
                "Usuario o contraseña incorrectos.",
                "Acceso denegado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void btnSalir_Click(
            object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
