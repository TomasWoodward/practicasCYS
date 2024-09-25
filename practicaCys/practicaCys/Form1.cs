using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practicaCys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panelListado.Visible = false;
            panelAcceso.Visible = true;
        }

        private void buttonAcceder_Click(object sender, EventArgs e)
        { 
            panelListado.Visible = true;
            panelAcceso.Visible = false;   
              
        }
    }
}
