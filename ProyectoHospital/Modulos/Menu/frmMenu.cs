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
using System.Drawing;

namespace ProyectoHospital.Modulos.Menu
{
    public partial class frmMenu : Form
    {
        SqlConnection myconexion;
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            rjDropDownMenu1.IsMainMenu = true;
            rjDropDownMenu2.IsMainMenu = true;
            rjDropDownMenu3.IsMainMenu = true;
            rjDropDownMenu4.IsMainMenu = true;
            rjDropDownMenu5.IsMainMenu = true;
            rjDropDownMenu1.MenuItemTextColor = Color.Navy;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Desea salir del sistemma?","Confirmación",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if(this.WindowState==FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnHamburguesa_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 230)
            {
                MenuVertical.Width = 66;
                btnEspaciosClinicos.Enabled = false;
                btnFarmacia.Enabled = false;
                btnMedicosPacientes.Enabled = false;
                btnPagos.Enabled = false;
                btnServicios.Enabled = false;
                btnConfig.Enabled = false;
            }
            else
            {
                MenuVertical.Width = 230;
                btnEspaciosClinicos.Enabled = true;
                btnFarmacia.Enabled = true;
                btnMedicosPacientes.Enabled = true;
                btnPagos.Enabled = true;
                btnServicios.Enabled = true;
                btnConfig.Enabled = true;
            }
        }

        private void btnEspaciosClinicos_Click(object sender, EventArgs e)
        {
            rjDropDownMenu1.IsMainMenu = true;
        }

        private void btnMedicosPacientes_Click(object sender, EventArgs e)
        {
            rjDropDownMenu2.IsMainMenu = true;
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            rjDropDownMenu3.IsMainMenu = true;
        }

        private void btnFarmacia_Click(object sender, EventArgs e)
        {
            rjDropDownMenu4.IsMainMenu = true;
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            rjDropDownMenu5.IsMainMenu = true;
        }

        
    }
}
