using ProyectoHospital.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoHospital.Modulos.Servicios
{
    public partial class frmCirugiaAgendar : Form
    {
        ConexionBD cnx = new ConexionBD();
        SqlConnection conexion;

        SqlDataAdapter quirofano;
        SqlDataAdapter cirugias;
        SqlDataAdapter medico;
        SqlDataAdapter paciente;

        DataTable tabquirofano;
        DataTable tabpaciente;
        DataTable tabmedico;
        DataTable tabcirugia;
        private DataRow filaSeleccionada;
        private DataRow pacienteseleccionado;

        public frmCirugiaAgendar()
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

        private void CargarMedicos()
        {
            try
            {
                conexion = cnx.ObtenerConexion();
                medico = new SqlDataAdapter("Select Nombre,MedicoId from hospital.Medicos", conexion);
                tabmedico = new DataTable();
                medico.Fill(tabmedico);

                cbmedico.DataSource = tabmedico;
                cbmedico.DisplayMember = "Nombre";
                cbmedico.ValueMember = "MedicoId";
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al cargar medicos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void CargarQuirofanos()
        {
            try
            {
                conexion = cnx.ObtenerConexion();
                quirofano = new SqlDataAdapter("Select concat( 'Quirofano #', QuirofanoId, '-', Precio) as Nombre, QuirofanoId from hospital.Quirofanos where disponible != 0", conexion);
                tabquirofano = new DataTable();
                quirofano.Fill(tabquirofano);

                cbquirofano.DataSource = tabquirofano;
                cbquirofano.DisplayMember = "Nombre";
                cbquirofano.ValueMember = "QuirofanoId";
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al cargar quirofanos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                insertButton.Enabled = false;
                updateButton.Enabled = false;
                deleteButton.Enabled = false;
                button1.Enabled = false;
            }


        }


        private void frmCirugiaAgendar_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarMedicos();
            CargarQuirofanos();
            button1.Enabled = false;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void CargarDatos()
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

        private void LimpiarCampos()
        {
            txtpaciente.Text = string.Empty;
            cbmedico.SelectedIndex = -1;
            cbquirofano.SelectedIndex = -1;
            filaSeleccionada = null;
            pacienteseleccionado = null;
            PatientId.Text = string.Empty;
            description.Text = string.Empty;
            Date.Value = DateTime.Now;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string searchName = txtpaciente.Text;

            SqlCommand command = new SqlCommand("hospital.SearchPacientesByName", cnx.ObtenerConexion());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@SearchName", searchName);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgPacients.DataSource = table;
            dgPacients.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgPacients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgPacients.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgPacients.ReadOnly = true;
            dgPacients.Visible = true;
        }

        private void IdentidadPaciente_Validated(object sender, EventArgs e)
        {
        }

        private SqlCommand comando(String sql, SqlConnection conexion)
        {
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@QuirofanoID", SqlDbType.Int, 4, "QuirofanoID");
            cmd.Parameters.Add("@CirugiaID", SqlDbType.Int, 4, "CirugiaID");
            cmd.Parameters.Add("@PacienteID", SqlDbType.Int, 4, "PacienteID");
            cmd.Parameters.Add("@MedicoID", SqlDbType.Int, 4, "MedicoID");
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, -1, "CirugiaDescripcion");
            cmd.Parameters.Add("@Fecha", SqlDbType.DateTime, 8, "CirugiaFecha");
            return cmd;
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            if (PatientId.Text == string.Empty)
            {
                MessageBox.Show("Debe seleccionar un paciente para agendar cirugía.");
                return;
            }
            try
            {

                DataRow nuevaFila = tabcirugia.NewRow();
                nuevaFila["QuirofanoID"] = cbquirofano.SelectedValue;
                nuevaFila["PacienteID"] = PatientId.Text;
                nuevaFila["CirugiaDescripcion"] = description.Text;
                nuevaFila["MedicoID"] = cbmedico.SelectedValue;
                nuevaFila["CirugiaFecha"] = Convert.ToDateTime(Date.Value, CultureInfo.InvariantCulture);

                tabcirugia.Rows.Add(nuevaFila);
                cirugias.InsertCommand = comando("hospital.spInsertCirugia", conexion);
                cirugias.Update(tabcirugia);

                CargarDatos();
                LimpiarCampos();
                CargarQuirofanos();
                MessageBox.Show("La habitación ha sido guardada correctamente.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar habitación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CargarDatos();
                LimpiarCampos();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada != null)
            {
                try
                {
                    filaSeleccionada["QuirofanoID"] = cbquirofano.SelectedValue;
                    filaSeleccionada["PacienteID"] = PatientId.Text;
                    filaSeleccionada["CirugiaDescripcion"] = description.Text;
                    filaSeleccionada["MedicoID"] = cbmedico.SelectedValue;// Fixed wrong reference
                    filaSeleccionada["CirugiaFecha"] = Convert.ToDateTime(Date.Value, CultureInfo.InvariantCulture);

                    cirugias.UpdateCommand = comando("hospital.spUpdateCirugia", conexion);
                    cirugias.Update(tabcirugia);

                    CargarDatos();
                    LimpiarCampos();
                    MessageBox.Show("El registro ha sido editado correctamente.");

                    insertButton.Enabled = true;
                    button1.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al editar registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CargarDatos();
                    LimpiarCampos();
                }
            }

        }

        private void clsButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }


        private void deleteButton_Click(object sender, EventArgs e)
        {

            DialogResult confirmacion = MessageBox.Show("¿Desea eliminar este registro?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("hospital.spDeleteCirugia", cnx.ObtenerConexion());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CirugiaID", int.Parse(filaSeleccionada["CirugiaID"].ToString()));

                    SqlCommand command = new SqlCommand("hospital.LiberarQuirofano", cnx.ObtenerConexion());
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", filaSeleccionada["QuirofanoID"].ToString());
                    try
                    {
                        cmd.ExecuteNonQuery();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Registro eliminado correctamente.");
                        CargarDatos();
                        LimpiarCampos();
                        CargarQuirofanos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error al eliminar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CargarDatos();
                    LimpiarCampos();
                }
            }
        }

        private void dgScheduledSurgeries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    filaSeleccionada = ((DataRowView)dgScheduledSurgeries.Rows[e.RowIndex].DataBoundItem).Row;


                    cbmedico.SelectedValue = filaSeleccionada["MedicoID"].ToString();
                    cbquirofano.SelectedValue = filaSeleccionada["QuirofanoId"].ToString();
                    PatientId.Text = filaSeleccionada["PacienteId"].ToString();
                    description.Text = filaSeleccionada["CirugiaDescripcion"].ToString();
                    txtpaciente.Text = filaSeleccionada["PacienteNombre"].ToString();
                    PatientId.Text = filaSeleccionada["PacienteID"].ToString();
                    Date.Value = Convert.ToDateTime(filaSeleccionada["CirugiaFecha"], CultureInfo.InvariantCulture);
                    insertButton.Enabled = false;
                    button1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar un registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgPacients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex <= dgPacients.Rows.Count)
                {
                    pacienteseleccionado = ((DataRowView)dgPacients.Rows[e.RowIndex].DataBoundItem).Row;
                    PatientId.Text = pacienteseleccionado["PacienteID"].ToString();
                    txtpaciente.Text = pacienteseleccionado["Nombre"].ToString();
                    dgPacients.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar un paciente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtpaciente_Validated(object sender, EventArgs e)
        {

        }

        private void txtpaciente_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgScheduledSurgeries.SelectedRows.Count > 0)
            {
                int filaIndex = dgScheduledSurgeries.CurrentRow.Index;

                if (filaIndex >= 0 && filaIndex < tabcirugia.Rows.Count)
                {
                    DialogResult confirmacion = MessageBox.Show("¿Desea liberar este quirofano?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        try
                        {

                            SqlCommand command = new SqlCommand("hospital.LiberarQuirofano", cnx.ObtenerConexion());
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@ID", cbquirofano.SelectedValue);

                            CargarDatos();
                            LimpiarCampos();
                            CargarQuirofanos();
                            MessageBox.Show("El registro ha sido editado correctamente.");
                            insertButton.Enabled = true;
                            button1.Enabled = false;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al editar registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La fila seleccionada no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Seleccione un registro antes de intentar liberar su quirofano.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
