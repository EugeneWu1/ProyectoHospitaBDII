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
    public partial class frmConsultorioConsulta : Form
    {
        ConexionBD cnx=new ConexionBD();
        SqlConnection conexion;

        SqlDataAdapter adpConsultorioInfo;

        DataTable tabConsultorioInfo;

        public frmConsultorioConsulta()
        {
            InitializeComponent();
            toolTips();
            conexion = cnx.ObtenerConexion();
        }
        private void CargarConsultoriosMedicos() 
        {
            try
            {
                adpConsultorioInfo = new SqlDataAdapter("Select * from hospital.vw_ConsultoriosMedicos", conexion);
                tabConsultorioInfo = new DataTable();
                adpConsultorioInfo.Fill(tabConsultorioInfo);
                dgvInfoConsultorio.DataSource = tabConsultorioInfo;

                dgvInfoConsultorio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvInfoConsultorio.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvInfoConsultorio.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                dgvInfoConsultorio.ReadOnly = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al cargar las habitaciones: " + ex.Message);
            }

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

        private void frmConsultorioConsulta_Load(object sender, EventArgs e)
        {
            CargarConsultoriosMedicos();
        }
    }
}
