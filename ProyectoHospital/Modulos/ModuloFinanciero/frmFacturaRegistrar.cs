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
using System.Collections;

namespace ProyectoHospital.Modulos.ModuloPagos
{
    public partial class frmFacturaRegistrar : Form
    {

        ConexionBD conexion = new ConexionBD();
        private List<KeyValuePair<int, string>> Servicios;
        DataTable tabla = new DataTable();

        //Varibale para almacenar el total a pagar
        private float totalPagar = 0;

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
                // Validaciones
                if (cboxServicios.SelectedValue == null || (int)cboxServicios.SelectedValue == 0)
                {
                    MessageBox.Show("Seleccione un servicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tboxNombrePaciente.Text) ||
                    string.IsNullOrWhiteSpace(tboxIdentidad.Text) ||
                    string.IsNullOrWhiteSpace(tboxCantidadInsumo.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener datos del formulario
                string nombrePaciente = tboxNombrePaciente.Text;
                string identidadPaciente = tboxIdentidad.Text;
                int servicioId = (int)cboxServicios.SelectedValue;
                string servicioNombre = cboxServicios.Text;
                DateTime fecha = dtpFecha.Value;
                string insumoUsado = tboxInsumo.Text;
                int cantidad = int.Parse(tboxCantidadInsumo.Text);
                string descripcion = tboxDescripcion.Text;

                // Calcular subtotal e ISV
                float precioServicio = ObtenerPrecioServicio(servicioId);
                float precioInsumo = !string.IsNullOrWhiteSpace(insumoUsado) ? ObtenerPrecioInsumo(insumoUsado) : 0;

                float subtotal = (float)Math.Round(precioServicio + (cantidad * precioInsumo), 2);
                tboxSubtotal.Text = subtotal.ToString("F2");

                float isv = (float)Math.Round(0.15f, 2);
                tboxISV.Text = isv.ToString("F2");

                float total = (float)Math.Round(subtotal + (subtotal * isv), 2);
                tboxTotal.Text = total.ToString("F2");

                // Agregar datos al DataGridView
                tabla.Rows.Add(nombrePaciente, identidadPaciente, servicioNombre, fecha, insumoUsado, cantidad, precioInsumo, descripcion, isv, subtotal);

                // Actualizar el total acumulado usando el campo Total
                totalPagar += total;
                tboxTotalPagar.Text = totalPagar.ToString("F2");

                // Limpiar campos para nueva entrada
                LimpiarCampos();

                MessageBox.Show($"Registro agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnGuardarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones previas
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos en la factura para guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear la conexión a la base de datos
                using (SqlConnection connection = new SqlConnection("Server=3.128.144.165; Database=DB20212030388; User ID=eugene.wu; Password=EW20212030388;"))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction()) // Iniciar una transacción
                    {
                        try
                        {
                            // Iterar por cada fila en el DataGridView/DataTable
                            foreach (DataRow row in tabla.Rows)
                            {
                                // Extraer datos de la fila
                                string nombrePaciente = row["Paciente"].ToString();
                                string identidadPaciente = row["Identidad"].ToString();
                                string servicio = row["Servicio"].ToString();
                                string productoNombre = row["Insumo"].ToString();
                                int cantidad = Convert.ToInt32(row["Cantidad"]);
                                string descripcion = row["Descripcion"].ToString();
                                DateTime fechaFactura = Convert.ToDateTime(row["Fecha"]);
                                float subtotal = Convert.ToSingle(row["Subtotal"]);
                                float isv = Convert.ToSingle(row["ISV"]);
                                float total = totalPagar;

                                // Crear el comando para llamar al procedimiento almacenado
                                using (SqlCommand command = new SqlCommand("spInsertarFactura", connection, transaction))
                                {
                                    command.CommandType = CommandType.StoredProcedure;

                                    // Agregar parámetros explícitamente
                                    command.Parameters.Add(new SqlParameter("@NombrePaciente", SqlDbType.VarChar, 50) { Value = nombrePaciente });
                                    command.Parameters.Add(new SqlParameter("@IdentificacionPaciente", SqlDbType.VarChar, 20) { Value = identidadPaciente });
                                    command.Parameters.Add(new SqlParameter("@Servicio", SqlDbType.VarChar, 30) { Value = servicio });
                                    command.Parameters.Add(new SqlParameter("@ProductoNombre", SqlDbType.VarChar, 50) { Value = productoNombre });
                                    command.Parameters.Add(new SqlParameter("@Cantidad", SqlDbType.Int) { Value = cantidad });
                                    command.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 250) { Value = descripcion });
                                    command.Parameters.Add(new SqlParameter("@FechaFactura", SqlDbType.DateTime) { Value = fechaFactura });
                                    command.Parameters.Add(new SqlParameter("@Subtotal", SqlDbType.Float) { Value = subtotal });
                                    command.Parameters.Add(new SqlParameter("@ISV", SqlDbType.Float) { Value = isv });
                                    command.Parameters.Add(new SqlParameter("@Total", SqlDbType.Float) { Value = totalPagar });

                                    // Ejecutar el procedimiento almacenado
                                    command.ExecuteNonQuery();
                                }
                            }

                            // Confirmar la transacción
                            transaction.Commit();
                            MessageBox.Show("Factura guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reiniciar el formulario
                            LimpiarCampos();
                            tabla.Clear();
                            totalPagar = 0;
                            tboxTotalPagar.Text = "0.00";
                        }
                        catch
                        {
                            // Revertir la transacción en caso de error
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para obtener el ServicioID según el nombre del servicio
        private int ObtenerServicioID(string nombreServicio, SqlConnection connection)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT ServicioID FROM hospital.Servicios WHERE Nombre = @Nombre", connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombreServicio);
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener el ID del servicio.");
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
            tabla.Columns.Add("Identidad", typeof(string));
            tabla.Columns.Add("Servicio", typeof(string));
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("Insumo", typeof(string));
            tabla.Columns.Add("Cantidad", typeof(int));
            tabla.Columns.Add("Precio Unitario", typeof(float));
            tabla.Columns.Add("Descripcion", typeof(string));
            tabla.Columns.Add("ISV", typeof(float));
            tabla.Columns.Add("Subtotal", typeof(float));
            dgFactura.ReadOnly = true;
            dgFactura.DataSource = tabla; // Asignar la tabla al DataGridView
        }

        //OBTENER EL PRECIO DE LOS SERVICIOS
        private float ObtenerPrecioServicio(int servicioId)
        {
            float precio = 0;
            string cadenaConexion = "Server=3.128.144.165; Database=DB20212030388; User ID=eugene.wu; Password=EW20212030388;";
            string query = "EXEC spPrecioServicio @ServicioID";

            try
            {
                // Crear la conexión con la base de datos
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    // Crear el comando con el query y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar el parámetro del procedimiento almacenado
                        command.Parameters.AddWithValue("@ServicioID", servicioId);

                        // Abrir la conexión
                        connection.Open();

                        // Ejecutar el comando y obtener el resultado
                        object resultado = command.ExecuteScalar();

                        // Verificar si el resultado no es nulo y convertirlo a float
                        if (resultado != null && float.TryParse(resultado.ToString(), out precio))
                        {
                            return precio;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener precio del servicio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return precio;
        }

        //OBTENER PRECIO DE LOS INSUMOS
        private float ObtenerPrecioInsumo(string nombreInsumo)
        {
            float precio = 0;
            string cadenaConexion = "Server=3.128.144.165; Database=DB20212030388; User ID=eugene.wu; Password=EW20212030388;";
            string query = "EXEC spPrecioInsumos @NombreInsumo";

            try
            {
                // Crear la conexión con la base de datos
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    // Crear el comando con el query y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar el parámetro del procedimiento almacenado
                        command.Parameters.AddWithValue("@NombreInsumo", nombreInsumo);

                        // Abrir la conexión
                        connection.Open();

                        // Ejecutar el comando y obtener el resultado
                        object resultado = command.ExecuteScalar();

                        // Verificar si el resultado no es nulo y convertirlo a float
                        if (resultado != null && float.TryParse(resultado.ToString(), out precio))
                        {
                            return precio;
                        }
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
