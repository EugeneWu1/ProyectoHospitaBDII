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
using System.Runtime.InteropServices;
using System.Net.Http.Headers;
using ProyectoHospital.Modulos.ModuloEspaciosClinicos;
using ProyectoHospital.Modulos.ModuloMedicosPacientes;
using ProyectoHospital.Modulos.Servicios;
using ProyectoHospital.Modulos.Farmacia;
using ProyectoHospital.Modulos.ModuloPagos;
using ProyectoHospital.Modulos.ModuloServicios;


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
            if (MessageBox.Show("¿Desea salir del sistema?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
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
            rjDropDownMenu2.Show(btnMedicosPacientes, btnMedicosPacientes.Width, 0);
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            rjDropDownMenu3.Show(btnServicios, btnServicios.Width, 0);
        }

        private void btnFarmacia_Click(object sender, EventArgs e)
        {
            rjDropDownMenu4.Show(btnFarmacia, btnFarmacia.Width, 0);
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            rjDropDownMenu5.Show(btnPagos, btnPagos.Width, 0);
        }

        private void barra_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaAgendar consulta = new frmConsultaAgendar();
            consulta.ShowDialog();
        }

        private void hospitalizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHospitalizacionAgendar hops = new frmHospitalizacionAgendar();
            hops.ShowDialog();
        }

        private void cirugíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFarmacia farmacia = new frmFarmacia();
            farmacia.ShowDialog();
        }

        private void facturasPacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFacturaRegistrar factura = new frmFacturaRegistrar();
            factura.ShowDialog();
        }

        private void rjDropDownMenu4_Click(object sender, EventArgs e)
        {
            
        }

        private void pagosAMédicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPagoMedicoRegistrar pago = new frmPagoMedicoRegistrar();
            pago.ShowDialog();
        }

        private void gestiónDeHabitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHabitacionRegistro Habitacion = new frmHabitacionRegistro();
            Habitacion.ShowDialog();
        }

        private void asignarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultorioRegistro cons = new frmConsultorioRegistro();
            cons.ShowDialog();
        }

        private void gestiónDeCategoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHabitacionCategorias categorias = new frmHabitacionCategorias();
            categorias.ShowDialog();
        }

        private void disponiblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHabitacionDisponibles disponibles = new frmHabitacionDisponibles();
            disponibles.ShowDialog();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultorioConsulta consultar = new frmConsultorioConsulta();
            consultar.ShowDialog();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuirofanoRegistrar quirofano = new frmQuirofanoRegistrar();
            quirofano.ShowDialog();
        }

        private void disponiblesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmQuirofanoDisponible disponibleQuiro = new frmQuirofanoDisponible();
            disponibleQuiro.ShowDialog();
        }

        private void registrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMedicoRegistrar medico = new frmMedicoRegistrar();
            medico.ShowDialog();
        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMedicoConsultar consultarMedico = new frmMedicoConsultar();
            consultarMedico.ShowDialog();
        }

        private void consultarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmPacienteRegistrar paciente = new frmPacienteRegistrar();
            paciente.ShowDialog();
        }

        private void consultarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmmPacienteConsultar pacientecons = new frmmPacienteConsultar();
            pacientecons.ShowDialog();
        }

        private void agendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaAgendar consulta = new frmConsultaAgendar();
            consulta.ShowDialog();
        }

        private void agendarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmHospitalizacionAgendar hops = new frmHospitalizacionAgendar();
            hops.ShowDialog();
        }

        private void agendarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmCirugiaAgendar cirugia = new frmCirugiaAgendar();
            cirugia.ShowDialog();
        }

        private void consultarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmConsultaBuscar ConsBuscar = new frmConsultaBuscar();  
            ConsBuscar.ShowDialog();
        }

        private void consultarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmHospitalizacionConsultar hospAgendar = new frmHospitalizacionConsultar();
            hospAgendar.ShowDialog();
        }

        private void agendarToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            frmCirugiaAgendar cirugiaAgendar = new frmCirugiaAgendar();
            cirugiaAgendar.ShowDialog();
        }

        private void consultarToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmCirugiaConsultas consultasCirugia = new frmCirugiaConsultas();
            consultasCirugia.ShowDialog();
        }

        private void crearFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFacturaRegistrar factura = new frmFacturaRegistrar();
            factura.ShowDialog();
        }

        private void crearPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPagoMedicoRegistrar pago = new frmPagoMedicoRegistrar();
            pago.ShowDialog();
        }

        private void consultarPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPagoConsultar pagocons = new frmPagoConsultar();
            pagocons.ShowDialog();
        }

        private void consultarFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFacturasConsulta frmFactConsultas = new frmFacturasConsulta();
            frmFactConsultas.ShowDialog();
        }

        private void barra_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
