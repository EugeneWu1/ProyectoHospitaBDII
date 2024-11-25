using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoHospital.Modulos.ModuloPagos
{
    public partial class frmPagoMedico : Form
    {
        public frmPagoMedico()
        {
            InitializeComponent();
            toolTips();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            
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
    }
}
