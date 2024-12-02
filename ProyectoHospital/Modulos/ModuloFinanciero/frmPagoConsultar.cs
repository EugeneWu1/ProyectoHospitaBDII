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
    public partial class frmPagoConsultar : Form
    {
        string connectionString = "Server=3.128.144.165; Database=DB20212030388; User ID=eugene.wu; Password=EW20212030388;";
        public frmPagoConsultar()
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

        private void CargarDatos()
        {
            string query = "SELECT * FROM hospital.PagosMedicos WHERE Activo = 1";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgPagos.DataSource = dt;
            }
        }


        private void FiltrarDatos()
        {
            string filtro = cboxFiltro.SelectedItem.ToString();
            string texto = tboxTexto.Text.Trim();

            string query = "SELECT * FROM hospital.PagosMedicos WHERE Activo = 1";

            if (!string.IsNullOrEmpty(texto))
            {
                switch (filtro)
                {
                    case "Mes":
                        query += " AND Mes = @valor";
                        break;
                    case "Año":
                        query += " AND Anio = @valor";
                        break;
                    case "MedicoID":
                        query += " AND MedicoID = @valor";
                        break;
                    case "TotalPagar":
                        query += " AND TotalPagar LIKE @valor"; // Si quieres hacer una búsqueda parcial
                        break;
                    default:
                        break;
                }
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@valor", texto);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgPagos.DataSource = dt;
            }
        }

        private void tboxTexto_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }
    }
}
