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
    public partial class frmHabitacionDisponibles : Form
    {
        ConexionBD cnx=new ConexionBD();
        SqlConnection conexion;

        SqlDataAdapter adpHabitacionesDispo;

        DataTable tabHabitacionesDispo;

        public frmHabitacionDisponibles()
        {
            InitializeComponent();
            toolTips();
            conexion= cnx.ObtenerConexion();

        }
        private void CargarHabitaciones() 
        {
            try
            {
                adpHabitacionesDispo = new SqlDataAdapter("Select * From hospital.vwHabitacionesDetalles", conexion);
                tabHabitacionesDispo=new DataTable();
                adpHabitacionesDispo.Fill(tabHabitacionesDispo);
                dgvHabitacionesDispo.DataSource = tabHabitacionesDispo;

                dgvHabitacionesDispo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHabitacionesDispo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvHabitacionesDispo.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                dgvHabitacionesDispo.ReadOnly = true;
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

        private void frmHabitacionDisponibles_Load(object sender, EventArgs e)
        {
            CargarHabitaciones();
        }


    }
}
