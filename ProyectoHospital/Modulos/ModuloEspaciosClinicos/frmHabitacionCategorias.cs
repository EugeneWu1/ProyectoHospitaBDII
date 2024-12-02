using ProyectoHospital.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoHospital.Modulos.ModuloEspaciosClinicos
{
    public partial class frmHabitacionCategorias : Form
    {
        ConexionBD cnx= new ConexionBD();
        SqlConnection conexion;

        SqlDataAdapter adpCategoria;
        SqlDataAdapter adpNombreCat;

        DataTable tabCategoria;
        DataTable tabNombreCat;

        public frmHabitacionCategorias()
        {
            InitializeComponent();
            dgvCategoria.EditingControlShowing += dgvCategoria_EditingControlShowing;
            toolTips();

            conexion = cnx.ObtenerConexion();
            adpCategoria=new SqlDataAdapter();
            adpNombreCat = new SqlDataAdapter("Select * from hospital.fCategorias()",conexion);

            adpCategoria.SelectCommand = new SqlCommand("hospital.spCategoriaSelect", conexion);
            adpCategoria.SelectCommand.CommandType= CommandType.StoredProcedure;

            adpCategoria.DeleteCommand = new SqlCommand("hospital.spCategoriaDelete",conexion);
            adpCategoria.DeleteCommand.CommandType= CommandType.StoredProcedure;
            adpCategoria.DeleteCommand.Parameters.Add("@categoriaid", SqlDbType.Int, 4, "CategoriaID");

            adpCategoria.InsertCommand = comando("hospital.spCategoriaInsert",conexion);
            adpCategoria.InsertCommand.Parameters[0].Direction= ParameterDirection.InputOutput;

            adpCategoria.UpdateCommand = comando("hospital.spCategoriaUpdate",conexion);


        }
        private SqlCommand comando(String sql,SqlConnection conexion)
        {
            SqlCommand cmd = new SqlCommand(sql,conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@categoriaid", SqlDbType.Int, 4, "CategoriaID");
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "NombreCategoria");
            cmd.Parameters.Add("@precio", SqlDbType.Float, 50, "Precio");

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmHabitacionCategorias_Load(object sender, EventArgs e)
        {
            try
            {
                DataGridViewComboBoxColumn cmdNombreCat = new DataGridViewComboBoxColumn();

                tabNombreCat = new DataTable();

                adpNombreCat.Fill(tabNombreCat);

                cmdNombreCat.DataSource = tabNombreCat;
                cmdNombreCat.DisplayMember= "Nombre";
                cmdNombreCat.ValueMember= "Nombre";
                cmdNombreCat.DataPropertyName = "Nombrecategoria";
                cmdNombreCat.HeaderText = "NombreCategoria";
                cmdNombreCat.DisplayStyleForCurrentCellOnly = true;

                tabCategoria=new DataTable();
                adpCategoria.Fill(tabCategoria);
                dgvCategoria.DataSource = tabCategoria;
                dgvCategoria.Columns.Insert(1,cmdNombreCat);
                dgvCategoria.Columns["NombreCategoria"].Visible = false;

                dgvCategoria.Columns["CategoriaID"].ReadOnly = true;

                dgvCategoria.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                dgvCategoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCategoria.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvCategoria.EndEdit();
                if (tabCategoria.GetChanges() != null)
                {
                    
                    foreach (DataRow row in tabCategoria.Rows)
                    {
                        if (row.RowState != DataRowState.Deleted) 
                        {
                            if (string.IsNullOrWhiteSpace(row["NombreCategoria"].ToString()))
                            {
                                throw new Exception("El nombre de la categoría no puede estar vacío.");
                            }

                            if (row["Precio"] == DBNull.Value || Convert.ToDouble(row["Precio"]) <= 0)
                            {
                                throw new Exception("El precio debe ser mayor a 0.");
                            }
                        }
                    }
                    adpCategoria.Update(tabCategoria);
                    tabCategoria.AcceptChanges();
                    MessageBox.Show("Información guardada con éxito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No hay cambios para guardar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                tabCategoria.RejectChanges();
                dgvCategoria.DataSource = null;
                dgvCategoria.DataSource = tabCategoria;
                MessageBox.Show("Cambios descartados", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ValidarNumeros(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true; 
            }
        }

        private void dgvCategoria_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvCategoria.CurrentCell.OwningColumn.Name == "Precio")
            {
                
                e.Control.KeyPress -= new KeyPressEventHandler(ValidarNumeros);
                
                e.Control.KeyPress += new KeyPressEventHandler(ValidarNumeros);
            }
            else
            {
               
                e.Control.KeyPress -= new KeyPressEventHandler(ValidarNumeros);
            }
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategoria.SelectedRows.Count > 0)
            {
                int filaIndex = dgvCategoria.CurrentRow.Index;

                if (filaIndex >= 0 && filaIndex < tabCategoria.Rows.Count)
                {
                    int categoriaid = Convert.ToInt32(tabCategoria.Rows[filaIndex]["CategoriaID"]);
                    DialogResult confirmacion = MessageBox.Show("¿Desea eliminar la categoria?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        try
                        {
                            tabCategoria.Rows[filaIndex].Delete();
                            adpCategoria.Update(tabCategoria);
                            MessageBox.Show("Categoria eliminada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show($"Error al eliminar la categoria: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Seleccione una categoria antes de intentar eliminarlo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
