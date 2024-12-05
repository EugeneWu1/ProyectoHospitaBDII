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
    public partial class frmMedicoConsultar : Form
    {
        private string connectionString = "Server=3.128.144.165; database=DB20212030388;User ID=carlos.osegueda; password=CO20212030669";

        public frmMedicoConsultar()
        {
            InitializeComponent();
            toolTips();
            CargarDatosEnGrid();
            LlenarComboBuscar();

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

        private void dgConMed_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgConMed.Rows[e.RowIndex];
                medID.Text = row.Cells["MedicoID"].Value.ToString();
                name.Text = row.Cells["Nombre"].Value.ToString();
                identidad.Text = row.Cells["Identidad"].Value.ToString();
                string sexoBD = row.Cells["Sexo"].Value.ToString();
                if (sexoBD == "M")
                    sex.Text = "Masculino";
                else if (sexoBD == "F")
                    sex.Text = "Femenino";
                direc.Text = row.Cells["Direccion"].Value.ToString();
                telef.Text = row.Cells["Telefono"].Value.ToString();
                espe.Text = row.Cells["Especialidad"].Value.ToString();
                tipo.Text = row.Cells["Tipo"].Value.ToString();
                salario.Text = row.Cells["Salario"].Value.ToString();
                consult.Text = row.Cells["ConsultorioID"].Value.ToString();

            }
        }

        private void CargarDatosEnGrid()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM hospital.Medicos", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(table);
                    dgConMed.DataSource = table;
                    dgConMed.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }
        }

        private void indentidad_Click(object sender, EventArgs e)
        {

        }

        private void frmMedicoConsultar_Load(object sender, EventArgs e)
        {

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
                string query = $"SELECT * FROM hospital.Medicos WHERE {campo} LIKE @valor";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@valor", $"%{valor}%"); // Buscar por coincidencias parciales

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(table);
                    dgConMed.DataSource = table;
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
            filter.Items.Add("MedicoID");
            filter.Items.Add("Nombre");
            filter.Items.Add("Sexo");
            filter.Items.Add("Identidad");
            filter.Items.Add("Direccion");
            filter.Items.Add("Telefono");
            filter.Items.Add("Especialidad");
            filter.Items.Add("Tipo");
            filter.Items.Add("ConsultorioID");
            filter.Items.Add("Salario");
            filter.SelectedIndex = 0; // Seleccionar el primer campo por defecto
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