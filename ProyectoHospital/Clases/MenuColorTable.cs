using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ProyectoHospital.Clases
{
    public class MenuColorTable : ProfessionalColorTable
    {
        //Campos
        private Color backColor; //color de fondo del Menu #FFFFFFFF
        private Color leftColumnColor;// #FF8B0000
        private Color borderColor;
        private Color menuItemBorderColor;
        private Color menuItemSelectedColor;

        //Constructor
        public MenuColorTable(bool isMainMenu,Color primaryColor)
        {
            if (isMainMenu)
            {
                backColor = Color.FromArgb(37,39,60);
                leftColumnColor = Color.FromArgb(32,33,51);
                borderColor = Color.FromArgb(32, 33, 51);
                menuItemBorderColor = primaryColor;
                menuItemSelectedColor = primaryColor;
            }
            else
            {
                backColor = Color.White;
                leftColumnColor = Color.LightGray;
                borderColor = Color.LightGray;
                menuItemBorderColor = primaryColor;
                menuItemSelectedColor = primaryColor;
            }
        }

        public override Color ToolStripDropDownBackground
        {
            get
            {
                return backColor;
            }
        }

        public override Color MenuBorder
        {
            get
            {
                return borderColor;
            }
        }

        public override Color MenuItemBorder
        {
            get
            {
                return menuItemBorderColor;
            }
        }

        public override Color MenuItemSelected
        {
            get
            {
                return menuItemSelectedColor;
            }
        }

        public override Color ImageMarginGradientBegin
        {
            get
            {
                return leftColumnColor;
            }
        }

        public override Color ImageMarginGradientMiddle 
        {
            get
            {
                return leftColumnColor; 
            }
        }

        public override Color ImageMarginGradientEnd
        {
            get
            {
                return leftColumnColor;
            }
        }

    }
}
