using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoHospital.Modulos.ModuloMedicosPacientes
{
    public partial class frmMedicoRegistrar : Form
    {
        public frmMedicoRegistrar()
        {
            InitializeComponent();
            toolTips();
            // Agregar elementos al ComboBox de sexo
            sexCombo.Items.Add("Masculino");
            sexCombo.Items.Add("Femenino");

            // Agregar elementos al ComboBox de especialidades
            espeCombo.Items.Add("Médico General");
            espeCombo.Items.Add("Pediatra");
            espeCombo.Items.Add("Cardiólogo");
            espeCombo.Items.Add("Neumólogo");
            espeCombo.Items.Add("Dermatólogo");
            espeCombo.Items.Add("Gastroenterólogo");
            espeCombo.Items.Add("Neurólogo");
            espeCombo.Items.Add("Ginecólogo");
            espeCombo.Items.Add("Cirujano");
            espeCombo.Items.Add("Oncólogo");
            espeCombo.Items.Add("Oftalmólogo");

            // Agregar elementos al ComboBox de tipo
            tipoCombo.Items.Add("Empleado");
            tipoCombo.Items.Add("Externo");
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

        private void frmMedicoRegistrar_Load(object sender, EventArgs e)
        {
                
        }
    }
}
