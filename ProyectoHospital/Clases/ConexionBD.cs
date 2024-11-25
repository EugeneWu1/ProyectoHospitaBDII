using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoHospital.Clases
{
    internal class ConexionBD
    {
        SqlConnection cnx;

        public ConexionBD()
        {
            try
            {
                cnx = new SqlConnection("Server = 3.128.144.165; Database = DB20212030388; User ID = eugene.wu; Password = EW20212030388;");
                cnx.Open();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conexión: " + ex.Message);
            }

        }

        // Método para obtener la conexión abierta
        public SqlConnection ObtenerConexion()
        {
            return cnx;
        }
    }
}
