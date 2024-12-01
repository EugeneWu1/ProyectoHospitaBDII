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

namespace ProyectoHospital.Modulos.ModuloPagos
{
    public partial class frmFacturasConsulta : Form
    {
        private string connectionString = "Server=3.128.144.165; Database=DB20212030388; User ID=eugene.wu; Password=EW20212030388;";
        public frmFacturasConsulta()
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

        private void BuscarFacturas()
        {
            // Establecer el procedimiento almacenado
            string storedProcedure = "spConsultarFactura";

            // Crear la conexión a la base de datos
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Crear el SqlCommand con el procedimiento almacenado
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros basados en el filtro seleccionado
                    if (cboxFiltro.SelectedItem.ToString() == "Nombre Paciente")
                    {
                        cmd.Parameters.AddWithValue("@NombrePaciente", tboxTexto.Text);
                        cmd.Parameters.AddWithValue("@IdentificacionPaciente", DBNull.Value); // Para evitar que se pase NULL
                        cmd.Parameters.AddWithValue("@FechaInicio", DBNull.Value); // NULL por defecto
                        cmd.Parameters.AddWithValue("@FechaFin", DBNull.Value); // NULL por defecto
                    }
                    else if (cboxFiltro.SelectedItem.ToString() == "Identidad")
                    {
                        cmd.Parameters.AddWithValue("@IdentificacionPaciente", tboxTexto.Text);
                        cmd.Parameters.AddWithValue("@NombrePaciente", DBNull.Value); // NULL por defecto
                        cmd.Parameters.AddWithValue("@FechaInicio", DBNull.Value); // NULL por defecto
                        cmd.Parameters.AddWithValue("@FechaFin", DBNull.Value); // NULL por defecto
                    }
                    else if (cboxFiltro.SelectedItem.ToString() == "Fecha Facturacion")
                    {
                        // Suponiendo que el tboxTexto contiene una fecha en formato "yyyy-MM-dd"
                        if (DateTime.TryParse(tboxTexto.Text, out DateTime fecha))
                        {
                            cmd.Parameters.AddWithValue("@FechaInicio", fecha);
                            cmd.Parameters.AddWithValue("@FechaFin", fecha);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@FechaInicio", DBNull.Value);
                            cmd.Parameters.AddWithValue("@FechaFin", DBNull.Value);
                        }
                        cmd.Parameters.AddWithValue("@NombrePaciente", DBNull.Value); // NULL por defecto
                        cmd.Parameters.AddWithValue("@IdentificacionPaciente", DBNull.Value); // NULL por defecto
                    }

                    // Conectar y ejecutar la consulta
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Mostrar los resultados en el DataGridView
                    dgFacturas.DataSource = dt;
                }
            }
        }

        private void tboxTexto_TextChanged(object sender, EventArgs e)
        {
            BuscarFacturas();
        }
    }
}
