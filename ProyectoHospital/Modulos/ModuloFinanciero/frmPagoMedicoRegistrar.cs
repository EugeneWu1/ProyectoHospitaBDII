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
using System.Data.SqlClient;

namespace ProyectoHospital.Modulos.ModuloPagos
{
    public partial class frmPagoMedicoRegistrar : Form
    {
        string connection = "Server=3.128.144.165; Database=DB20212030388; User ID=eugene.wu; Password=EW20212030388;";
        DataTable tabPago;

        public frmPagoMedicoRegistrar()
        {
            InitializeComponent();
            toolTips();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmPagoMedicoRegistrar_Load(object sender, EventArgs e)
        {
            cargarDatos();
            // Supongamos que quieres ocultar una columna con el nombre "Cantidad"
            dgPagos.Columns["Activo"].Visible = false;

        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar entradas antes de procesarlas
                if (string.IsNullOrWhiteSpace(tboxMedico.Text) ||
                    !int.TryParse(tboxMes.Text, out int mes) ||
                    !int.TryParse(tboxAnio.Text, out int anio) ||
                    !decimal.TryParse(tboxTotal.Text, out decimal total))
                {
                    MessageBox.Show("Por favor, complete los campos correctamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("spPagoMedicoInsert", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@nombre", tboxMedico.Text);
                        cmd.Parameters.AddWithValue("@mes", mes);
                        cmd.Parameters.AddWithValue("@anio", anio);
                        cmd.Parameters.AddWithValue("@total", total);

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                LimpiartTbox();
                cargarDatos();

                MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea editar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {

                    // Validar entradas antes de procesarlas
                    if (string.IsNullOrWhiteSpace(tboxMedico.Text) ||
                        !int.TryParse(tboxMes.Text, out int mes) ||
                        !int.TryParse(tboxAnio.Text, out int anio) ||
                        !decimal.TryParse(tboxTotal.Text, out decimal total))
                    {
                        MessageBox.Show("Por favor, complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    using (SqlConnection con = new SqlConnection(connection))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("spPagosMedicosUpdate", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Agregar parámetros al procedimiento almacenado
                            cmd.Parameters.AddWithValue("@nombre", tboxMedico.Text);
                            cmd.Parameters.AddWithValue("@mes", mes);
                            cmd.Parameters.AddWithValue("@anio", anio);
                            cmd.Parameters.AddWithValue("@total", total);

                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        LimpiartTbox();
                        cargarDatos();
                        MessageBox.Show("Datos actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connection))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("spPagosMedicosDelete", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Agregar parámetros al procedimiento almacenado
                            cmd.Parameters.AddWithValue("@nombre", tboxMedico.Text);
                            cmd.Parameters.AddWithValue("@mes", int.Parse(tboxMes.Text));
                            cmd.Parameters.AddWithValue("@anio", int.Parse(tboxAnio.Text));

                            cmd.ExecuteNonQuery();
                            con.Close() ;

                            LimpiartTbox();
                        }
                    }

                    cargarDatos(); // Recargar los datos
                    MessageBox.Show("Registro eliminado correctamente (borrado lógico).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiartTbox();
        }
        private void cargarDatos()
        {

            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM hospital.PagosMedicos where Activo = 1", con))
                    {
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable tabPagos = new DataTable();

                        adp.Fill(tabPagos); // Llena el DataTable con los datos.

                        dgPagos.DataSource = tabPagos; // Asigna el DataTable al DataGridView.
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
        private void toolTips()
        {
            ToolTip ttp = new ToolTip();
            ttp.SetToolTip(btnVolver, "Regresar al menu.");
        }

        private void LimpiartTbox()
        {
            tboxMedico.Clear();
            tboxMes.Clear();
            tboxAnio.Clear();
            tboxTotal.Clear();
        }

        private void dgPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que no sea el encabezado
            {
                DataGridViewRow row = dgPagos.Rows[e.RowIndex];

                // Obtén el MedicoID de la fila seleccionada
                int medicoID = Convert.ToInt32(row.Cells["MedicoID"].Value);

                // Ejecuta una consulta para obtener el nombre del médico
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT Nombre FROM hospital.Medicos WHERE MedicoID = @medicoID", con))
                    {
                        cmd.Parameters.AddWithValue("@medicoID", medicoID);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            tboxMedico.Text = result.ToString(); // Muestra el nombre del médico en el TextBox
                        }
                        else
                        {
                            tboxMedico.Text = string.Empty; // Si no hay resultados, limpiar el TextBox
                        }
                    }
                }

                // Carga el resto de los valores en los TextBox
                tboxMes.Text = row.Cells["Mes"].Value.ToString();
                tboxAnio.Text = row.Cells["Anio"].Value.ToString();
                tboxTotal.Text = row.Cells["TotalPagar"].Value.ToString();
            }
        }

    }
}

