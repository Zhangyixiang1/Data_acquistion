using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Data_acquisition.Ctrl
{
    public partial class ParaLine : UserControl
    {
        public ParaLine()
        {
            InitializeComponent();
        }
        public Color Color
        {
            get { return lineShape1.BorderColor; }
            set { this.lineShape1.BorderColor = value; }
        }
        public string tagname
        {
           // get { return label1.Text; }
            set { this.label1.Text = value; }
        }
        public string min
        {
            get { return label2.Text; }
            set { this.label1.Text = value; }
        }
        public string max
        {
            get { return label4.Text; }
            set { this.label4.Text = value; }
        }
        public string Unit
        {
            get { return label6.Text; }
            set { this.label6.Text = value; }
        }
        private void ParaLine_Click(object sender, EventArgs e)
        {
            Para_choose frm=new Para_choose (this);
            frm.ShowDialog();
        }
    }

}
