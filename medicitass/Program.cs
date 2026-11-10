using System;
using System.Windows.Forms;

namespace medicitass
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Iniciar con la sesión de Administrador para habilitar todas las opciones
            Application.Run(new FrmLogin());
        }
    }
}