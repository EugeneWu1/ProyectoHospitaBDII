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
    public partial class frmQuirofanoRegistrar : Form
    {
        ConexionBD cnx=new ConexionBD();
        SqlConnection conexion;

        SqlDataAdapter adpQuierofanos;

        DataTable tabQuierofanos;

        public frmQuirofanoRegistrar()
        {
            InitializeComponent();
            toolTips();
        }
        private void CargarQuirofanos() 
        {
            try
            {
                conexion = cnx.ObtenerConexion();
                adpQuierofanos = new SqlDataAdapter();
                adpQuierofanos.SelectCommand = new SqlCommand("hospital.spQuirofanoSelect", conexion);
                adpQuierofanos.SelectCommand.CommandType = CommandType.StoredProcedure;

                tabQuierofanos = new DataTable();
                adpQuierofanos.Fill(tabQuierofanos);
                dgvQuirofano.DataSource = tabQuierofanos;

                dgvQuirofano.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvQuirofano.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvQuirofano.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private SqlCommand comando(String sql, SqlConnection conexion)
        {
            SqlCommand cmd= new SqlCommand(sql, conexion);
            cmd.CommandType=CommandType.StoredProcedure;

            cmd.Parameters.Add("@qrnid", SqlDbType.Int, 4, "QuirofanoID");
            cmd.Parameters.Add("@dispo", SqlDbType.Bit, 1, "Disponible");
            cmd.Parameters.Add("@precio", SqlDbType.Float, 10, "Precio");
            return cmd;
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


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void toolTips()
        {
            ToolTip ttp = new ToolTip();
            ttp.SetToolTip(btnVolver, "Regresar al menu.");
        }

        private void frmQuirofanoRegistrar_Load(object sender, EventArgs e)
        {
            CargarQuirofanos();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                conexion = cnx.ObtenerConexion();
                dgvQuirofano.EndEdit();

                if (tabQuierofanos.GetChanges() != null)
                {
     
                    foreach (DataRow row in tabQuierofanos.Rows)
                    {
                        if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                        {
                            int quirofanoID = Convert.ToInt32(row["QuirofanoID"]);

                            if (quirofanoID < 1 || quirofanoID > 2)
                            {
                                MessageBox.Show($"El QuirofanoID debe estar entre 1 y 2. Verifique la fila con ID: {quirofanoID}",
                                            "Validación",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                                return;
                            }
                            if (double.TryParse(row["Precio"].ToString(), out double precio))
                            {
                                if (precio < 0)
                                {
                                    MessageBox.Show($"El Precio no puede ser negativo. Verifique la fila con Precio: {precio}",
                                                    "Validación",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("El Precio debe ser un número válido.",
                                                "Error de Validación",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    adpQuierofanos.InsertCommand = comando("hospital.spQuirofanoInsert", conexion);
                    adpQuierofanos.InsertCommand.Parameters[0].Direction = ParameterDirection.InputOutput;
                    adpQuierofanos.UpdateCommand = comando("hospital.spQuirofanoUpdate", conexion);
                    adpQuierofanos.Update(tabQuierofanos);
                    CargarQuirofanos();
                    MessageBox.Show("Información guardada con éxito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los cambios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvQuirofano_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvQuirofano.CurrentCell.OwningColumn.Name == "Precio")
            {
                
                e.Control.KeyPress -= new KeyPressEventHandler(ValidarNumeros);

                
                e.Control.KeyPress += new KeyPressEventHandler(ValidarNumeros);
            }
            else
            {
                
                e.Control.KeyPress -= new KeyPressEventHandler(ValidarNumeros);
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                tabQuierofanos.RejectChanges();
                dgvQuirofano.DataSource = null;
                dgvQuirofano.DataSource = tabQuierofanos;
                MessageBox.Show("Cambios descartados", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
