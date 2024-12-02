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
    public partial class frmConsultorioRegistro : Form
    {
        ConexionBD cnx = new ConexionBD();
        SqlConnection conexion;

        SqlDataAdapter adpConsultorios;
        SqlDataAdapter adpTipo;

        DataTable tabConsultorios;
        DataTable tabTipo;



        public frmConsultorioRegistro()
        {
            InitializeComponent();
            toolTips();
  
        }
        private DataTable ObtenerTipo() 
        {
            conexion = cnx.ObtenerConexion();
            adpTipo = new SqlDataAdapter("Select * from hospital.fTipo()",conexion);
            tabTipo= new DataTable();
            adpTipo.Fill(tabTipo);
            return tabTipo; 
        }
        private void CargarConsultorios()
        {
            try
            {
                if (dgvConsultorios.Columns.Contains("cmbTipo"))
                {
                    dgvConsultorios.Columns.Remove("cmbTipo");
                }
                DataGridViewComboBoxColumn cmbTipo = new DataGridViewComboBoxColumn();
                conexion = cnx.ObtenerConexion();
                adpConsultorios = new SqlDataAdapter();
                adpConsultorios.SelectCommand = new SqlCommand("hospital.spConsultoriosSelect", conexion);
                adpConsultorios.SelectCommand.CommandType = CommandType.StoredProcedure;

                cmbTipo.Name = "cmbTipo";
                cmbTipo.DataSource = ObtenerTipo();
                cmbTipo.DisplayMember = "Nombre";
                cmbTipo.ValueMember = "Nombre";
                cmbTipo.DataPropertyName = "Tipo";
                cmbTipo.HeaderText = "Tipo";
                cmbTipo.DisplayStyleForCurrentCellOnly = true;


                tabConsultorios = new DataTable();
                adpConsultorios.Fill(tabConsultorios);
                dgvConsultorios.DataSource = tabConsultorios;

                dgvConsultorios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvConsultorios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvConsultorios.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                dgvConsultorios.Columns.Add(cmbTipo);
                dgvConsultorios.Columns["Tipo"].Visible = false;
                dgvConsultorios.Columns["ConsultorioID"].ReadOnly = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        private SqlCommand comando(String sql, SqlConnection conexion)
        {
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "Nombre");
            cmd.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "Tipo");

            return cmd;
        }
        private void GuardarConsultorios()
        {
            try
            {
                
                conexion = cnx.ObtenerConexion();
                dgvConsultorios.EndEdit();

                if (tabConsultorios.GetChanges() != null)
                {
                    foreach (DataRow row in tabConsultorios.Rows)
                    {

                        if (row.RowState != DataRowState.Deleted)
                        {
                            if (string.IsNullOrWhiteSpace(row["Nombre"].ToString()))
                            {
                                throw new Exception("El nombre no puede estar vacío.");
                            }
                            if (row["Tipo"] == DBNull.Value || string.IsNullOrWhiteSpace(row["Tipo"].ToString()))
                            {
                                throw new Exception("Debe seleccionar un tipo de consultorio.");
                            }

                        }
                    }
                    adpConsultorios.InsertCommand = comando("hospital.spConsultoriosInsert", conexion);
                    adpConsultorios.UpdateCommand = comando("hospital.spConsultoriosUpdate", conexion);
                    adpConsultorios.UpdateCommand.Parameters.Add("@ConsultorioID", SqlDbType.Int, 4, "ConsultorioID");
                    adpConsultorios.Update(tabConsultorios);
                    CargarConsultorios();
                    MessageBox.Show("Información guardada con éxito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No hay cambios para guardar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los cambios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void toolTips()
        {
            ToolTip ttp = new ToolTip();
            ttp.SetToolTip(btnVolver,"Regresar al menu.");
        }


        private void frmConsultorioRegistro_Load(object sender, EventArgs e)
        {
            CargarConsultorios();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            GuardarConsultorios();
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                tabConsultorios.RejectChanges();
                dgvConsultorios.DataSource = null;
                dgvConsultorios.DataSource = tabConsultorios;
                MessageBox.Show("Cambios descartados", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
