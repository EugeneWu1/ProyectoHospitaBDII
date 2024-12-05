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
//Kedwin Hissell Guillen García #20202000370
//Módulo de farmacia
namespace ProyectoHospital.Modulos.Farmacia
{
    public partial class frmFarmacia : Form
    {
        ConexionBD cnx=new ConexionBD();
        SqlConnection conexion;
        SqlDataAdapter adpInventario;
        DataTable tabInventario;

        public frmFarmacia()
        {
            InitializeComponent();
            toolTips();
            conexion = cnx.ObtenerConexion();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void insertButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre para buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                
                SqlCommand cmd = new SqlCommand("hospital.spBuscarProductoPorNombre", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());

                
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable resultado = new DataTable();
                adapter.Fill(resultado);

                
                if (resultado.Rows.Count > 0)
                {
                    dgvInventarioFarmacia.DataSource = resultado;
                }
                else
                {
                    MessageBox.Show("No se encontró ningún producto con ese nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvInventarioFarmacia.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al buscar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void MostrarDatosProducto()
        {
            SqlConnection conexion = cnx.ObtenerConexion();
            try
            {
                adpInventario = new SqlDataAdapter("hospital.spInventarioSelect", conexion);
                adpInventario.SelectCommand.CommandType = CommandType.StoredProcedure;

                tabInventario = new DataTable();
                adpInventario.Fill(tabInventario);
                dgvInventarioFarmacia.DataSource = tabInventario;
                dgvInventarioFarmacia.Columns["Tipo"].HeaderText = "Tipo de Producto";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar inventario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmFarmacia_Load(object sender, EventArgs e)
        {
            MostrarDatosProducto();
        }

        private void LimpiarCampos()
        {
            
            txtProductoID.Clear();
            txtNombre.Clear();
            txtExistencia.Clear();
            txtCosto.Clear();
            txtPrecio.Clear();
            cbTipo.SelectedIndex = -1;
            dtpFechaVencimiento.Value = DateTime.Now;
            dgvInventarioFarmacia.ClearSelection();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("hospital.spInventarioInsert", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductoID", txtProductoID.Text.Trim());
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@Tipo", cbTipo.SelectedItem?.ToString());
                cmd.Parameters.AddWithValue("@Existencia", int.Parse(txtExistencia.Text.Trim()));
                cmd.Parameters.AddWithValue("@Costo", string.IsNullOrWhiteSpace(txtCosto.Text)? (object)DBNull.Value: decimal.Parse(txtCosto.Text.Trim()));
                cmd.Parameters.AddWithValue("@Precio", decimal.Parse(txtPrecio.Text.Trim()));
                cmd.Parameters.AddWithValue("@fechavencimiento", dtpFechaVencimiento.Value);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable resultado = new DataTable();
                adapter.Fill(resultado);

                MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarDatosProducto();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dgvInventarioFarmacia.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una fila para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                
                DataGridViewRow filaSeleccionada = dgvInventarioFarmacia.SelectedRows[0];
                int productoID = Convert.ToInt32(filaSeleccionada.Cells["ProductoID"].Value);

                SqlCommand cmd = new SqlCommand("hospital.spInventarioUpdate", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductoID", productoID);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@Tipo", cbTipo.SelectedItem?.ToString());
                cmd.Parameters.AddWithValue("@Existencia", int.Parse(txtExistencia.Text.Trim()));
                cmd.Parameters.AddWithValue("@Costo", string.IsNullOrWhiteSpace(txtCosto.Text) ? (object)DBNull.Value : decimal.Parse(txtCosto.Text.Trim()));
                cmd.Parameters.AddWithValue("@Precio", decimal.Parse(txtPrecio.Text.Trim()));
                cmd.Parameters.AddWithValue("@fechavencimiento", dtpFechaVencimiento.Value);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable resultado = new DataTable();
                adapter.Fill(resultado);

                MessageBox.Show("Producto editado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarDatosProducto();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dgvInventarioFarmacia.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Está seguro de que desea eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                
                DataGridViewRow filaSeleccionada = dgvInventarioFarmacia.SelectedRows[0];
                int productoID = Convert.ToInt32(filaSeleccionada.Cells["ProductoID"].Value);

                SqlCommand cmd = new SqlCommand("hospital.spInventarioDelete", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductoID", productoID);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable resultado = new DataTable();
                adapter.Fill(resultado);

                MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarDatosProducto();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}