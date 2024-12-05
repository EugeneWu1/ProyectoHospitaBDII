using ProyectoHospital.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class frmHospitalizacionAgendar : Form
    {
        ConexionBD cnx = new ConexionBD();
        SqlConnection conexion;

        SqlDataAdapter quirofano;
        SqlDataAdapter servicio;
        SqlDataAdapter cirugias;
        SqlDataAdapter medico;
        SqlDataAdapter paciente;

        DataTable tabquirofano;
        DataTable tabservicio;
        DataTable tabpaciente;
        DataTable tabmedico;
        DataTable tabcirugia;
        private DataRow filaSeleccionada;
        private DataRow pacienteseleccionado;
        public frmHospitalizacionAgendar()
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

        private void CargarHabitaciones()
        {
            try
            {
                conexion = cnx.ObtenerConexion();
                quirofano = new SqlDataAdapter("select Concat(c.nombreCategoria,'#',h.Numero) as nombre, " +
                    "h.habitacionId as HabitacionId from hospital.Habitaciones h " +
                    "join hospital.CategoriasHabitacion c on h.CategoriaID = c.CategoriaID where h.disponible != 0", conexion);
                tabquirofano = new DataTable();
                quirofano.Fill(tabquirofano);

                cbquirofano.DataSource = tabquirofano;
                cbquirofano.DisplayMember = "Nombre";
                cbquirofano.ValueMember = "HabitacionId";
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al cargar habitaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                insertButton.Enabled = false;
                updateButton.Enabled = false;
                deleteButton.Enabled = false;
                button1.Enabled = false;
            }


        }

        private void CargarServicios()
        {
            try
            {
                conexion = cnx.ObtenerConexion();
                servicio = new SqlDataAdapter("select Nombre, ServicioID from hospital.Servicios ", conexion);
                tabservicio = new DataTable();
                servicio.Fill(tabservicio);

                cbservicio.DataSource = tabservicio;
                cbservicio.DisplayMember = "Nombre";
                cbservicio.ValueMember = "ServicioID";
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al cargar servicios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                insertButton.Enabled = false;
                updateButton.Enabled = false;
                deleteButton.Enabled = false;
                button1.Enabled = false;
            }


        }
        private void frmHospitalizacionAgendar_Load(object sender, EventArgs e)
        {
            CargarHabitaciones();
            CargarMedicos();
            CargarDatos();
            CargarServicios();
            button1.Enabled = false;
        }


        private void CargarDatos()
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

        private void LimpiarCampos()
        {
            txtpaciente.Text = string.Empty;
            cbmedico.SelectedIndex = -1;
            cbquirofano.SelectedIndex = -1;
            cbservicio.SelectedIndex = -1;
            filaSeleccionada = null;
            pacienteseleccionado = null;
            PatientId.Text = string.Empty;
            description.Text = string.Empty;
            Date.Value = DateTime.Now;
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada == null)
            {
                MessageBox.Show($"Debe seleccionar una fila", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult confirmacion = MessageBox.Show("¿Desea eliminar este registro?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("hospital.DeleteHospitalizacion", cnx.ObtenerConexion());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@HospitalizacionID", int.Parse(filaSeleccionada["HospitalizacionID"].ToString()));

                    SqlCommand command = new SqlCommand("hospital.liberarhabitacion", cnx.ObtenerConexion());
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", filaSeleccionada["HospitalizacionID"].ToString());
                    try
                    {
                        cmd.ExecuteNonQuery();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Registro eliminado correctamente.");
                        CargarDatos();
                        LimpiarCampos();
                        CargarHabitaciones();
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

        private SqlCommand comando(string procedureName, SqlConnection conexion)
        {
            SqlCommand cmd = new SqlCommand(procedureName, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            // Add required parameters (ensure consistency with the database schema)
            cmd.Parameters.Add("@HospitalizacionID", SqlDbType.Int).SourceColumn = "HospitalizacionID";
            cmd.Parameters.Add("@ServicioID", SqlDbType.Int).SourceColumn = "ServicioID";
            cmd.Parameters.Add("@PacienteID", SqlDbType.Int).SourceColumn = "PacienteID";
            cmd.Parameters.Add("@MedicoID", SqlDbType.Int).SourceColumn = "MedicoID";
            cmd.Parameters.Add("@FechaIngreso", SqlDbType.DateTime).SourceColumn = "FechaIngreso";
            cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 500).SourceColumn = "Descripcion";
            cmd.Parameters.Add("@HabitacionID", SqlDbType.Int).SourceColumn = "HabitacionID";
            return cmd;
        }


        private void updateButton_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada != null)
            {
                try
                {
                    filaSeleccionada["HabitacionID"] = cbquirofano.SelectedValue;
                    filaSeleccionada["PacienteID"] = PatientId.Text;
                    filaSeleccionada["Descripcion"] = description.Text;
                    filaSeleccionada["MedicoID"] = cbmedico.SelectedValue;
                    filaSeleccionada["ServicioID"] = cbservicio.SelectedValue; // Fixed wrong reference
                    filaSeleccionada["FechaIngreso"] = Convert.ToDateTime(Date.Value, CultureInfo.InvariantCulture);

                    cirugias.UpdateCommand = comando("hospital.UpdateHospitalizacion", conexion);
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


        private void button1_Click(object sender, EventArgs e)
        {
            if (dghospitalizaciones.SelectedRows.Count > 0)
            {
                int filaIndex = dghospitalizaciones.CurrentRow.Index;

                if (filaIndex >= 0 && filaIndex < tabcirugia.Rows.Count)
                {
                    DialogResult confirmacion = MessageBox.Show("¿Desea liberar esta habitacion?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        try
                        {

                            SqlCommand command = new SqlCommand("hospital.LiberarHabitaciones", cnx.ObtenerConexion());
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@ID", cbquirofano.SelectedValue);
                            command.Parameters.AddWithValue("@Fecha", DateTime.Now);
                            command.Parameters.AddWithValue("@PacienteID", PatientId.Text);

                            CargarDatos();
                            LimpiarCampos();
                            CargarHabitaciones();
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
                MessageBox.Show("Seleccione un registro antes de intentar liberar su habitacion.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            dgPacients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgPacients.ReadOnly = true;
            dgPacients.Visible = true;
        }

        private void clsButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            if (PatientId.Text == string.Empty)
            {
                MessageBox.Show("Debe seleccionar un paciente para agendar hospitalizacoin.");
                return;
            }
            try
            {

                DataRow nuevaFila = tabcirugia.NewRow();
                nuevaFila["HabitacionID"] = cbquirofano.SelectedValue;
                nuevaFila["PacienteID"] = PatientId.Text;
                nuevaFila["Descripcion"] = description.Text;
                nuevaFila["MedicoID"] = cbmedico.SelectedValue;
                nuevaFila["ServicioID"] = cbmedico.SelectedValue;
                nuevaFila["FechaIngreso"] = Convert.ToDateTime(Date.Value, CultureInfo.InvariantCulture);

                tabcirugia.Rows.Add(nuevaFila);
                cirugias.InsertCommand = comando("hospital.InsertHospitalizacion", conexion);
                cirugias.Update(tabcirugia);

                CargarDatos();
                LimpiarCampos();
                CargarHabitaciones();
                MessageBox.Show("La habitación ha sido guardada correctamente.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar habitación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CargarDatos();
                LimpiarCampos();
            }
        }

        private void dghospitalizaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    filaSeleccionada = ((DataRowView)dghospitalizaciones.Rows[e.RowIndex].DataBoundItem).Row;


                    cbmedico.SelectedValue = filaSeleccionada["MedicoID"].ToString();
                    cbquirofano.SelectedValue = filaSeleccionada["HabitacionID"].ToString();
                    cbservicio.SelectedValue = filaSeleccionada["ServicioID"].ToString();
                    description.Text = filaSeleccionada["Descripcion"].ToString();
                    txtpaciente.Text = filaSeleccionada["PacienteNombre"].ToString();
                    PatientId.Text = filaSeleccionada["PacienteID"].ToString();
                    Date.Value = Convert.ToDateTime(filaSeleccionada["FechaIngreso"], CultureInfo.InvariantCulture);
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

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
