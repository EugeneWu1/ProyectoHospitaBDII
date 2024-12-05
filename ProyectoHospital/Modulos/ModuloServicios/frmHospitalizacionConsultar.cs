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
    public partial class frmHospitalizacionConsultar : Form
    {
        ConexionBD cnx = new ConexionBD();
        SqlConnection conexion;

        SqlDataAdapter cirugias;
        DataTable tabcirugia;
        public frmHospitalizacionConsultar()
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

        private void frmHospitalizacionConsultar_Load(object sender, EventArgs e)
        {
            try
            {
                conexion = cnx.ObtenerConexion();
                cirugias = new SqlDataAdapter();
                cirugias.SelectCommand = new SqlCommand("hospital.SelectHospitalizacion", conexion);
                cirugias.SelectCommand.CommandType = CommandType.StoredProcedure;

                tabcirugia = new DataTable();
                cirugias.Fill(tabcirugia);
                dghospitalizaciones.DataSource = tabcirugia;
                dghospitalizaciones.Columns["PacienteID"].Visible = false;
                dghospitalizaciones.Columns["HabitacionID"].Visible = false;
                dghospitalizaciones.Columns["MedicoID"].Visible = false;
                dghospitalizaciones.Columns["ServicioID"].Visible = false;
                dghospitalizaciones.Columns["HospitalizacionID"].Visible = false;

                dghospitalizaciones.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                dghospitalizaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dghospitalizaciones.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dghospitalizaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dghospitalizaciones.ReadOnly = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al cargar hospitalizaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
