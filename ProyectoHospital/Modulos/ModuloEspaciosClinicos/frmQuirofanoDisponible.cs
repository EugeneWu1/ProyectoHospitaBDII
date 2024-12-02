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

namespace ProyectoHospital.Modulos.ModuloEspaciosClinicos
{
    public partial class frmQuirofanoDisponible : Form
    {   
        ConexionBD cnx= new ConexionBD();
        SqlConnection conexion;
        SqlDataAdapter apbConsulta;
        DataTable tabConsulta;


        public frmQuirofanoDisponible()
        {
            InitializeComponent();
            toolTips();
            conexion = cnx.ObtenerConexion();
        }
        private void CargarQuirodanoConsulta() 
        {
            apbConsulta=new SqlDataAdapter("SELECT * FROM hospital.vwQuirofanos",conexion);
            tabConsulta=new DataTable();
            apbConsulta.Fill(tabConsulta);

            dgvQuirofanoConsulta.DataSource=tabConsulta;

            dgvQuirofanoConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuirofanoConsulta.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvQuirofanoConsulta.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            dgvQuirofanoConsulta.ReadOnly = true;
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

        private void frmQuirofanoDisponible_Load(object sender, EventArgs e)
        {
            CargarQuirodanoConsulta();
        }
    }
}
