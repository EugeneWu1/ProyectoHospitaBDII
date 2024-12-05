using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ProyectoHospital.Modulos.Login
{
    public partial class Login : Form
    {
        ToolTip toolTip;
        SqlConnection conexion;
        public bool conectado;
        public SqlConnection Conexion
        {
            get { return conexion; }
        }

        public bool Conectado
        {
            get { return conectado; }
        }
        public Login()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            toolTip = new ToolTip();
            toolTip.IsBalloon = true;
            toolTip.ToolTipIcon = ToolTipIcon.Info;
            toolTip.ToolTipTitle = "Ayuda";
            toolTip.UseAnimation = true;

            toolTip.SetToolTip(btnExit, "Cerrar.");
            toolTip.SetToolTip(btnEntrar, "Click para entrar al sistema.");
            toolTip.SetToolTip(lblForgotPass, "Click si ha olvidado su contraseña.");
            toolTip.SetToolTip(txtPass, "Ingrese su contraseña previamente establecida");
            toolTip.SetToolTip(txtUser, "Ingrese su usuario previamento establecido.");
            toolTip.SetToolTip(chkPass, "Mostrar contraseña");
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int msg, int wParam, int lParam);
        [DllImport("Gdi32.DLL", EntryPoint = "CreateRoundRectRgn")]

        private extern static IntPtr CreateRoundRectRgn
            (
                int nLeftRect,
                int nTopRect,
                int nRightRect,
                int nBottomRect,
                int nWidthEllipse,
                int nHeightEllipse
            );

        private void btnEntrar_Click_1(object sender, EventArgs e)
        {
            string servidor = "3.128.144.165";
            string bd = "DB20212030388";
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();

            string connection = $"Server ={servidor};Database={bd};User Id={user};password={pass}";

            try
            {
                conectado = false;
                conexion = new SqlConnection(connection);
                conexion.Open();
                conectado = true;
                MessageBox.Show("Se ha conectado con éxito.", "Conexión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    if (ex.Errors[i].Number == 18456)
                    {
                        MessageBox.Show("El usuario o contraseña es incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No se logró conectar al sistema.");
                    }
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.FromArgb(0, 0, 0); //NEGRO
                txtUser.Font = new Font(txtUser.Font, FontStyle.Bold);
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.Black;
                txtUser.Font = new Font(txtUser.Font, FontStyle.Regular);
            }
        }
        private void txtPass_Enter(object sender, EventArgs e)
        {
            if(txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.FromArgb(0, 0, 0); //NEGRO
                txtPass.Font = new Font(txtPass.Font, FontStyle.Bold);
                txtPass.PasswordChar = '*';
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if(txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.FromArgb(0, 0, 0); //NEGRO
                txtPass.Font = new Font(txtPass.Font, FontStyle.Regular);
                txtPass.PasswordChar = '\0';
            }
        }

        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {

            }
            else
            {
                if (chkPass.Checked)
                {
                    txtPass.PasswordChar = '\0';
                }
                else
                {
                    txtPass.PasswordChar = '*';
                }
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUser.Text = "eugene.wu";
            txtPass.Text = "EW20212030388";
        }
    }
}
