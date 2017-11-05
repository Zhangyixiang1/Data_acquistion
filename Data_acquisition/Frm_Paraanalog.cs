using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Data_acquisition
{
    public partial class Frm_Paraanalog : Form
    {
        public Frm_Paraanalog()
        {
            InitializeComponent();
        }

       

        private void Frm_Paraanalog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close(); 
        }
    }
}
