using ProyectoHospital.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoHospital.Modulos.Farmacia
{
    public partial class frmFarmacia : Form
    {
        ConexionBD cnx=new ConexionBD();
        SqlConnection conexion;
        public frmFarmacia()
        {
            InitializeComponent();
            toolTips();
            conexion = cnx.ObtenerConexion();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void toolTips()
        {
            ToolTip ttp = new ToolTip();
            ttp.SetToolTip(btnVolver, "Regresar al menu.");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void insertButton_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
