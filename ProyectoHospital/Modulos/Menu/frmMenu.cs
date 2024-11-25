﻿using System;
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
using System.Runtime.InteropServices;
using System.Net.Http.Headers;
using ProyectoHospital.Modulos.ModuloEspaciosClinicos;
using ProyectoHospital.Modulos.ModuloMedicosPacientes;
using ProyectoHospital.Modulos.Servicios;
using ProyectoHospital.Modulos.Farmacia;
using ProyectoHospital.Modulos.ModuloPagos;


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
            rjDropDownMenu1.PrimaryColor = Color.DeepSkyBlue;

            rjDropDownMenu2.IsMainMenu = true;
            rjDropDownMenu2.PrimaryColor = Color.DeepSkyBlue;

            rjDropDownMenu3.IsMainMenu = true;
            rjDropDownMenu3.PrimaryColor = Color.DeepSkyBlue;

            rjDropDownMenu4.IsMainMenu = true;
            rjDropDownMenu4.PrimaryColor = Color.DeepSkyBlue;

            rjDropDownMenu5.IsMainMenu = true;
            rjDropDownMenu5.PrimaryColor = Color.DeepSkyBlue;

            
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int msg, int wParam, int lParam);

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
                MenuVertical.Width = 30;
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
            rjDropDownMenu1.Show(btnEspaciosClinicos, btnEspaciosClinicos.Width, 0);
        }

        private void btnMedicosPacientes_Click(object sender, EventArgs e)
        {
            rjDropDownMenu2.Show(btnMedicosPacientes,btnMedicosPacientes.Width,0);
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            rjDropDownMenu3.Show(btnServicios,btnServicios.Width,0);
        }

        private void btnFarmacia_Click(object sender, EventArgs e)
        {
            rjDropDownMenu4.Show(btnFarmacia,btnFarmacia.Width,0);
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            rjDropDownMenu5.Show(btnPagos,btnPagos.Width,0);
        }

        private void barra_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void habitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHabitacion Habitacion = new frmHabitacion();
            Habitacion.ShowDialog();
        }

        private void consultoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultorio cons = new frmConsultorio(); 
            cons.ShowDialog();
        }

        private void quirófanosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuirofano quirofano = new frmQuirofano();
            quirofano.ShowDialog();
        }

        private void médicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMedico medico = new frmMedico();
            medico.ShowDialog();
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPaciente paciente = new frmPaciente();
            paciente.ShowDialog();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsulta consulta = new frmConsulta();
            consulta.ShowDialog();
        }

        private void hospitalizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHospitalizacionCirugia hops = new frmHospitalizacionCirugia();
            hops.ShowDialog();
        }

        private void cirugíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCirugia cirugia = new frmCirugia();
            cirugia.ShowDialog();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFarmacia farmacia = new frmFarmacia();
            farmacia.ShowDialog();
        }

        private void facturasPacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFactura factura = new frmFactura();
            factura.ShowDialog();
        }

        private void rjDropDownMenu4_Click(object sender, EventArgs e)
        {
            frmPagoMedico pago = new frmPagoMedico();
            pago.ShowDialog();
        }
    }
}