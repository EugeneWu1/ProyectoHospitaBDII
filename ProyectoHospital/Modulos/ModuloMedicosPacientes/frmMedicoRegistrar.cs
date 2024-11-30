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
using System.Xml.Linq;

namespace ProyectoHospital.Modulos.ModuloMedicosPacientes
{
    public partial class frmMedicoRegistrar : Form
    {
        private string connectionString = "Server=3.128.144.165; database=DB20212030388;User ID=carlos.osegueda; password=CO20212030669";

        public frmMedicoRegistrar()
        {
            InitializeComponent();
            CargarDatosEnGrid();
            toolTips();
            // Agregar elementos al ComboBox de sexo
            sexCombo.Items.Add("Masculino");
            sexCombo.Items.Add("Femenino");

            // Agregar elementos al ComboBox de especialidades
            espeCombo.Items.Add("Médico General");
            espeCombo.Items.Add("Pediatra");
            espeCombo.Items.Add("Cardiólogo");
            espeCombo.Items.Add("Neumólogo");
            espeCombo.Items.Add("Dermatólogo");
            espeCombo.Items.Add("Gastroenterólogo");
            espeCombo.Items.Add("Neurólogo");
            espeCombo.Items.Add("Ginecólogo");
            espeCombo.Items.Add("Cirujano");
            espeCombo.Items.Add("Oncólogo");
            espeCombo.Items.Add("Oftalmólogo");

            // Agregar elementos al ComboBox de tipo
            tipoCombo.Items.Add("Empleado");
            tipoCombo.Items.Add("Externo");
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

        private void frmMedicoRegistrar_Load(object sender, EventArgs e)
        {
                
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sphRegMedInsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MedicoID", int.Parse(medID.Text));
                cmd.Parameters.AddWithValue("@Nombre", name.Text);
                cmd.Parameters.AddWithValue("@Sexo", sexCombo.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Identidad", identidad.Text);
                cmd.Parameters.AddWithValue("@Direccion", direc.Text);
                cmd.Parameters.AddWithValue("@Telefono", telef.Text);
                cmd.Parameters.AddWithValue("@Especialidad", espeCombo.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Tipo", tipoCombo.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@ConsultorioID", int.Parse(consultID.Text));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Médico guardado correctamente.");
                    CargarDatosEnGrid();
                    LimpiarControles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea editar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sphRegMedUpdate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MedicoID", int.Parse(medID.Text));
                    cmd.Parameters.AddWithValue("@Nombre", name.Text);
                    cmd.Parameters.AddWithValue("@Sexo", sexCombo.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Identidad", identidad.Text);
                    cmd.Parameters.AddWithValue("@Direccion", direc.Text);
                    cmd.Parameters.AddWithValue("@Telefono", telef.Text);
                    cmd.Parameters.AddWithValue("@Especialidad", espeCombo.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Tipo", tipoCombo.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ConsultorioID", int.Parse(consultID.Text));

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Médico actualizado correctamente.");
                        CargarDatosEnGrid();
                        LimpiarControles();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sphRegMedDelete", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MedicoID", int.Parse(medID.Text));

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Médico eliminado correctamente.");
                        CargarDatosEnGrid();
                        LimpiarControles();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
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
                    dgRegMed.DataSource = table;
                    dgRegMed.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }
        }

        private void LimpiarControles()
        {
            medID.Clear();
            name.Clear();
            identidad.Clear();
            sexCombo.SelectedIndex = -1;
            direc.Clear();
            telef.Clear();
            espeCombo.SelectedIndex = -1;
            tipoCombo.SelectedIndex = -1;
            consultID.Clear();
        }

        private void clsButton_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void dgRegMed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgRegMed.Rows[e.RowIndex];
                medID.Text = row.Cells["MedicoID"].Value.ToString();
                name.Text = row.Cells["Nombre"].Value.ToString();
                identidad.Text = row.Cells["Identidad"].Value.ToString();
                string sexoBD = row.Cells["Sexo"].Value.ToString();
                if (sexoBD == "M")
                    sexCombo.SelectedItem = "Masculino";
                else if (sexoBD == "F")
                    sexCombo.SelectedItem = "Femenino";
                else
                    sexCombo.SelectedIndex = -1;
                direc.Text = row.Cells["Direccion"].Value.ToString();
                telef.Text = row.Cells["Telefono"].Value.ToString();
                espeCombo.SelectedItem = row.Cells["Especialidad"].Value.ToString();
                tipoCombo.SelectedItem = row.Cells["Tipo"].Value.ToString();
                consultID.Text = row.Cells["ConsultorioID"].Value.ToString();
            }
        }

        private void dgRegMed_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
