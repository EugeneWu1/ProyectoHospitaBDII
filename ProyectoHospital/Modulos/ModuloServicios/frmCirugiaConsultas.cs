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

namespace ProyectoHospital.Modulos.ModuloServicios
{
    public partial class frmCirugiaConsultas : Form
    {
        ConexionBD cnx = new ConexionBD();
        SqlConnection conexion;

        SqlDataAdapter cirugias;
        DataTable tabcirugia;
        public frmCirugiaConsultas()
        {
            InitializeComponent();
            toolTips();
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

        private void frmCirugiaConsultas_Load(object sender, EventArgs e)
        {
            try
            {
                conexion = cnx.ObtenerConexion();
                cirugias = new SqlDataAdapter();
                cirugias.SelectCommand = new SqlCommand("hospital.SpSelectCirugias", conexion);
                cirugias.SelectCommand.CommandType = CommandType.StoredProcedure;

                tabcirugia = new DataTable();
                cirugias.Fill(tabcirugia);
                dgScheduledSurgeries.DataSource = tabcirugia;
                dgScheduledSurgeries.Columns["PacienteID"].Visible = false;
                dgScheduledSurgeries.Columns["CirugiaID"].Visible = false;
                dgScheduledSurgeries.Columns["MedicoID"].Visible = false;
                dgScheduledSurgeries.Columns["QuirofanoID"].Visible = false;

                dgScheduledSurgeries.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                dgScheduledSurgeries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgScheduledSurgeries.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgScheduledSurgeries.ReadOnly = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al cargar cirugias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
