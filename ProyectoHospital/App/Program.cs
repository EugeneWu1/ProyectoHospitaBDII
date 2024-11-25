using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ProyectoHospital.Modulos.Login;

namespace ProyectoHospital
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SqlConnection myConexion;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login frmLogin = new Login();
            frmLogin.ShowDialog();

            if (frmLogin.Conectado)
            {
                myConexion = frmLogin.Conexion;
                Application.Run(new Login());
            }
        }
    }
}
