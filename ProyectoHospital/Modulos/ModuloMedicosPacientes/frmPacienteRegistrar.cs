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
    public partial class frmPacienteRegistrar : Form
    {
        private string connectionString = "Server=3.128.144.165; database=DB20212030388;User ID=carlos.osegueda; password=CO20212030669";

        public frmPacienteRegistrar()
        {
            InitializeComponent();
            CargarDatosEnGrid();
            toolTips();
            // Agregar elementos al ComboBox de sexo
            sexCombo.Items.Add("Masculino");
            sexCombo.Items.Add("Femenino");
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

        private void frmPacienteRegistrar_Load(object sender, EventArgs e)
        {

        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sphRegPacInsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PacienteID", int.Parse(pacID.Text));
                cmd.Parameters.AddWithValue("@Nombre", name.Text);
                cmd.Parameters.AddWithValue("@Sexo", sexCombo.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Identidad", identidad.Text);
                cmd.Parameters.AddWithValue("@Direccion", direc.Text);
                cmd.Parameters.AddWithValue("@Telefono", telef.Text);
                cmd.Parameters.AddWithValue("@FechaNacimiento",fecha.Value);


                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Paciente guardado correctamente.");
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
                    SqlCommand cmd = new SqlCommand("sphRegPacUpdate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PacienteID", int.Parse(pacID.Text));
                    cmd.Parameters.AddWithValue("@Nombre", name.Text);
                    cmd.Parameters.AddWithValue("@Sexo", sexCombo.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Identidad", identidad.Text);
                    cmd.Parameters.AddWithValue("@Direccion", direc.Text);
                    cmd.Parameters.AddWithValue("@Telefono", telef.Text);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", fecha.Value);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Paciente actualizado correctamente.");
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

        private void clsButton_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sphRegPacDelete", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PacienteID", int.Parse(pacID.Text));

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Paciente eliminado correctamente.");
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

        private void dgRegPac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgRegPac.Rows[e.RowIndex];
                pacID.Text = row.Cells["PacienteID"].Value.ToString();
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
                fecha.Value = Convert.ToDateTime(row.Cells["FechaNacimiento"].Value);


            }
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
                    dgRegPac.DataSource = table;
                    dgRegPac.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }
        }

        private void LimpiarControles()
        {
            pacID.Clear();
            name.Clear();
            identidad.Clear();
            sexCombo.SelectedIndex = -1;
            direc.Clear();
            telef.Clear();
            fecha.Value = DateTime.Now;
        }
    }
}
