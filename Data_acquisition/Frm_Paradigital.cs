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
    public partial class Frm_Paradigital : Form
    {
        public Frm_Paradigital()
        {
            InitializeComponent();
        }

       

        private void Frm_Paradigital_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void parashow4_Load(object sender, EventArgs e)
        {

        }
    }
}
