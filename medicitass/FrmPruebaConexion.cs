
using System;
using System.Windows.Forms;

namespace medicitass
{
    public partial class FrmPruebaConexion : Form
    {
        public FrmPruebaConexion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion conexionBD = new Conexion();

                using (var conexion = conexionBD.Conectar())
                {
                    conexion.Open();

                    MessageBox.Show(
                        "¡Conexión exitosa con MediCitas!",
                        "Conexión correcta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al conectar: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
