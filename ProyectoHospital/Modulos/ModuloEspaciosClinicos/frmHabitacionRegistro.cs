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
    public partial class frmHabitacionRegistro : Form
    {
        ConexionBD cnx=new ConexionBD();
        SqlConnection conexion;

        SqlDataAdapter adpHabitacion;
        SqlDataAdapter adpCategoria;

        DataTable tabHabitacion;
        DataTable tabCategoria;
        private DataRow filaSeleccionada;

        public frmHabitacionRegistro()
        {
            InitializeComponent();
            toolTips();
            conexion = cnx.ObtenerConexion();
            adpHabitacion = new SqlDataAdapter();
            adpHabitacion.InsertCommand = comando("hospital.spHabitacionlInsert", conexion);
            adpHabitacion.InsertCommand.Parameters[0].Direction = ParameterDirection.InputOutput;

            adpHabitacion.UpdateCommand = comando("hospital.spHabitacionlUpdate",conexion);
        }
        private void CargarCategorias()
        {
            try
            {
                conexion = cnx.ObtenerConexion();
                adpCategoria = new SqlDataAdapter("Select CategoriaID,NombreCategoria from hospital.CategoriasHabitacion", conexion);
                tabCategoria = new DataTable();
                adpCategoria.Fill(tabCategoria);

                cmbCategoria.DataSource = tabCategoria;
                cmbCategoria.DisplayMember = "NombreCategoria";
                cmbCategoria.ValueMember = "CategoriaID";
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void CargarHabitacion() 
        {
            try
            {
                conexion = cnx.ObtenerConexion();
                adpHabitacion = new SqlDataAdapter();
                adpHabitacion.SelectCommand = new SqlCommand("hospital.spHabitacionesSelect", conexion);
                adpHabitacion.SelectCommand.CommandType = CommandType.StoredProcedure;

                tabHabitacion = new DataTable();
                adpHabitacion.Fill(tabHabitacion);
                dgvHabitaciones.DataSource = tabHabitacion;

                dgvHabitaciones.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                dgvHabitaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHabitaciones.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvHabitaciones.ReadOnly = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al cargar habitaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void LimpiarCampos()
        {
            txtCodigo.Text = string.Empty;
            cmbCategoria.SelectedIndex = -1; 
            nudNumero.Value = nudNumero.Minimum; 
            chkDisponible.Checked = false; 
            filaSeleccionada = null; 
        }

        private SqlCommand comando(String sql, SqlConnection conexion)
        {
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.Add("@htoid",SqlDbType.Int,4,"HabitacionID");
            cmd.Parameters.Add("@ctgid", SqlDbType.Int, 4, "CategoriaID");
            cmd.Parameters.Add("@num", SqlDbType.Int, 4, "Numero");
            cmd.Parameters.Add("@dispo", SqlDbType.Bit, 1, "Disponible");
            return cmd;
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

        private void frmHabitacionRegistro_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarHabitacion();
            dgvHabitaciones.CellClick += dgvHabitaciones_CellClick;
            txtCodigo.ReadOnly = true;
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (nudNumero.Value < 1 || nudNumero.Value > 20)
            {
                MessageBox.Show("El número de la habitación debe estar entre 1 y 20.");
                return;
            }
            try
            {

                DataRow nuevaFila = tabHabitacion.NewRow();
                nuevaFila["CategoriaID"] = cmbCategoria.SelectedValue;
                nuevaFila["Numero"] = nudNumero.Value;
                nuevaFila["Disponible"] = chkDisponible.Checked;

                tabHabitacion.Rows.Add(nuevaFila);
                adpHabitacion.InsertCommand = comando("hospital.spHabitacionlInsert", conexion);
                adpHabitacion.Update(tabHabitacion);

                CargarHabitacion();

                MessageBox.Show("La habitación ha sido guardada correctamente.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar habitación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
      
        }

        private void cmdActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (filaSeleccionada != null) 
                {

                    filaSeleccionada["CategoriaID"] = cmbCategoria.SelectedValue;
                    filaSeleccionada["Numero"] = nudNumero.Value;
                    filaSeleccionada["Disponible"] = chkDisponible.Checked;

                    adpHabitacion.UpdateCommand = comando("hospital.spHabitacionlUpdate", conexion);
                    adpHabitacion.Update(tabHabitacion);

                    MessageBox.Show("La habitación ha sido actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                    CargarHabitacion();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una habitación para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la habitación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHabitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    filaSeleccionada = ((DataRowView)dgvHabitaciones.Rows[e.RowIndex].DataBoundItem).Row;

                    
                    txtCodigo.Text = filaSeleccionada["HabitacionID"].ToString();
                    cmbCategoria.SelectedValue = filaSeleccionada["CategoriaID"];
                    nudNumero.Value = Convert.ToDecimal(filaSeleccionada["Numero"]);
                    chkDisponible.Checked = Convert.ToBoolean(filaSeleccionada["Disponible"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar una habitación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}