using ProyectoHospital.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProyectoHospital.Modulos.ModuloPagos
{
    public partial class frmFacturaRegistrar : Form
    {

        ConexionBD conexion = new ConexionBD();
        private List<KeyValuePair<int, string>> Servicios;
        DataTable tabla = new DataTable();

        public frmFacturaRegistrar()
        {
            InitializeComponent();
            toolTips();
            LlenarComboBoxServicios();
            InicializarTabla();
            //Deshabilitar escritura, solo seleccion
            cboxServicios.DropDownStyle = ComboBoxStyle.DropDownList;
            dgFactura.AllowUserToResizeColumns = false;
            dgFactura.AllowUserToResizeRows = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardarTbox_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya seleccionado un servicio
                if (cboxServicios.SelectedValue == null || (int)cboxServicios.SelectedValue == 0)
                {
                    MessageBox.Show("Seleccione un servicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(tboxNombrePaciente.Text) ||
                    string.IsNullOrWhiteSpace(tboxIdentidad.Text) ||
                    string.IsNullOrWhiteSpace(tboxCantidadInsumo.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener los valores del formulario
                string nombrePaciente = tboxNombrePaciente.Text;
                string identidadPaciente = tboxIdentidad.Text;
                int servicioId = (int)cboxServicios.SelectedValue;
                string servicioNombre = cboxServicios.Text;
                DateTime fecha = dtpFecha.Value;
                string insumoUsado = tboxInsumo.Text;
                int cantidad = int.Parse(tboxCantidadInsumo.Text);
                string descripcion = tboxDescripcion.Text;

                // Obtener precios del servicio y/o insumos
                float precioServicio = ObtenerPrecioServicio(servicioId);
                float precioInsumo = !string.IsNullOrWhiteSpace(insumoUsado) ? ObtenerPrecioInsumo(int.Parse(insumoUsado)) : 0;

                // Calcular subtotal
                float precioUnitario = precioServicio > 0 ? precioServicio : precioInsumo;
                float subtotal = cantidad * precioUnitario;
                tboxSubtotal.Text = subtotal.ToString("F2");

                // Calcular ISV (15% como ejemplo)
                float isv = subtotal * 0.15f;
                tboxISV.Text = isv.ToString("F2");

                // Calcular total
                float total = subtotal + isv;
                tboxTotal.Text = total.ToString("F2");

                // Agregar datos al DataGridView
                tabla.Rows.Add(nombrePaciente, identidadPaciente, servicioNombre, fecha, insumoUsado, cantidad, precioUnitario, descripcion, isv, subtotal);

                // Limpiar campos para nueva entrada
                LimpiarCampos();

                MessageBox.Show($"Factura  generada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void toolTips()
        {
            ToolTip ttp = new ToolTip();
            ttp.SetToolTip(btnVolver, "Regresar al menu.");
        }

        //COMBOBOX SERVICIOS
        private void LlenarComboBoxServicios()
        {
            try
            {
                // Crear una nueva instancia de la conexión
                ConexionBD conexion = new ConexionBD();

                // Obtener la conexión abierta desde la clase ConexionBD
                SqlConnection connection = conexion.ObtenerConexion();

                // Crear el comando para llamar al procedimiento almacenado
                SqlCommand command = new SqlCommand("spServicios", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Ejecutar el procedimiento y obtener el lector de datos
                SqlDataReader reader = command.ExecuteReader();

                // Crear la lista para los servicios
                BindingList<KeyValuePair<int, string>> servicios = new BindingList<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(0, "Seleccione un Servicio...") 
                };

                // Leer los resultados
                while (reader.Read())
                {
                    int servicioId = reader["ServicioID"] as int? ?? 0; // Validar valores nulos
                    string nombre = reader["Nombre"] as string ?? "Desconocido";
                    servicios.Add(new KeyValuePair<int, string>(servicioId, nombre));
                }

                reader.Close();

                // Asignar los datos al ComboBox
                cboxServicios.DataSource = new BindingSource(servicios, null);
                cboxServicios.DisplayMember = "Value"; // Mostrar el nombre del servicio
                cboxServicios.ValueMember = "Key";     // Guardar el ServicioID como valor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los servicios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //DATATABLE
        private void InicializarTabla()
        {
            tabla = new DataTable();
            tabla.Columns.Add("Paciente", typeof(string));
            tabla.Columns.Add("Identidad", typeof(int));
            tabla.Columns.Add("Servicio", typeof(string));
            tabla.Columns.Add("Fecha",typeof(DateTime));
            tabla.Columns.Add("Insumo", typeof(string));
            tabla.Columns.Add("Cantidad", typeof(int));
            tabla.Columns.Add("Precio Unitario", typeof(float));
            tabla.Columns.Add("Descripcion", typeof(string));
            tabla.Columns.Add("ISV", typeof(float));
            tabla.Columns.Add("Subtotal", typeof(float));

            dgFactura.DataSource = tabla; // Asignar la tabla al DataGridView
        }

        //OBTENER EL PRECIO DE LOS SERVICIOS
        private float ObtenerPrecioServicio(int servicioId)
        {
            float precio = 0;
            try
            {
                using (SqlConnection connection = conexion.ObtenerConexion())
                {
                    using (SqlCommand command = new SqlCommand("spPrecioServicio", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ServicioID", servicioId);
                        connection.Open();
                        precio = (float)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener precio del servicio: " + ex.Message);
            }
            return precio;
        }

        //OBTENER PRECIO DE LOS INSUMOS
        private float ObtenerPrecioInsumo(int productoId)
        {
            float precio = 0;
            try
            {
                using (SqlConnection connection = conexion.ObtenerConexion())
                {
                    using (SqlCommand command = new SqlCommand("spPrecioInsumos", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ProductoID", productoId);
                        connection.Open();
                        precio = (float)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener precio del insumo: " + ex.Message);
            }
            return precio;
        }

        private void LimpiarCampos()
        {
            tboxNombrePaciente.Clear();
            tboxIdentidad.Clear();
            tboxCantidadInsumo.Clear();
            tboxInsumo.Clear();
            tboxDescripcion.Clear();
            cboxServicios.SelectedIndex = 0; // Restablecer al primer elemento
            dtpFecha.Value = DateTime.Now;
        }


    }
}
