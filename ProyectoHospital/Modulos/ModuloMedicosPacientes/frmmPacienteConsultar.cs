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

namespace ProyectoHospital.Modulos.ModuloMedicosPacientes
{
    public partial class frmmPacienteConsultar : Form
    {
        private string connectionString = "Server=3.128.144.165; database=DB20212030388;User ID=carlos.osegueda; password=CO20212030669";

        public frmmPacienteConsultar()
        {
            InitializeComponent();
            CargarDatosEnGrid();
            LlenarComboBuscar();
            toolTips();

            search.TextChanged += search_TextChanged;
            filter.SelectedIndexChanged += filter_SelectedIndexChanged;
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

        private void CargarDatosEnGrid()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM hospital.Pacientes", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(table);
                    dgConPac.DataSource = table;
                    dgConPac.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }
        }

        private void FiltrarDatos()
        {
            string campo = filter.SelectedItem?.ToString(); // Campo seleccionado en el ComboBox
            string valor = search.Text.Trim(); // Texto ingresado en el TextBox

            if (string.IsNullOrEmpty(campo))
            {
                MessageBox.Show("Por favor, seleccione un campo para buscar.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"SELECT * FROM hospital.Pacientes WHERE {campo} LIKE @valor";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@valor", $"%{valor}%"); // Buscar por coincidencias parciales

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(table);
                    dgConPac.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al realizar la búsqueda: " + ex.Message);
                }

            }
        }
        private void LlenarComboBuscar()
        {
            filter.Items.Clear();
            filter.Items.Add("PacienteID");
            filter.Items.Add("Nombre");
            filter.Items.Add("Sexo");
            filter.Items.Add("Identidad");
            filter.Items.Add("Direccion");
            filter.Items.Add("Telefono");
            filter.SelectedIndex = 0; // Seleccionar el primer campo por defecto
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void frmmPacienteConsultar_Load(object sender, EventArgs e)
        {

        }

        private void dgConPac_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgConPac.Rows[e.RowIndex];
                pacID.Text = row.Cells["PacienteID"].Value.ToString();
                name.Text = row.Cells["Nombre"].Value.ToString();
                identidad.Text = row.Cells["Identidad"].Value.ToString();
                string sexoBD = row.Cells["Sexo"].Value.ToString();
                if (sexoBD == "M")
                    sex.Text = "Masculino";
                else if (sexoBD == "F")
                    sex.Text = "Femenino";
                direc.Text = row.Cells["Direccion"].Value.ToString();
                telef.Text = row.Cells["Telefono"].Value.ToString();
                DateTime fechaNacimiento = Convert.ToDateTime(row.Cells["FechaNacimiento"].Value);
                fecha.Text = fechaNacimiento.ToString("dd-MM-yyyy");

            }
        }

        private void filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }
    }


}
