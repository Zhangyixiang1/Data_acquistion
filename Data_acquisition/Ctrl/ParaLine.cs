using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Data_acquisition.Ctrl
{
    public partial class ParaLine : UserControl
    {
        private string tagname, min, max, unit;

        public ParaLine()
        {
            InitializeComponent();


        }
        public Color Color
        {
            get { return lineShape1.BorderColor; }
            set { this.lineShape1.BorderColor = value; }
        }
        public bool Line_Enabled
        {
            get { return checkBox1.Enabled; }
            set { checkBox1.Enabled = value; }
        }
        public string Tagname
        {
            get { return tagname; }
            set { this.tagname = value; }
        }
        public string Min
        {
            get { return min; }
            set { this.min = value; }
        }
        public string Max
        {
            get { return max; }
            set { this.max = value; }
        }
        public string Unit
        {
            get { return unit; }
            set { this.unit = value; }
        }

        public void refresh()
        {


            label1.Text = tagname;
            label2.Text = min; label4.Text = max; label6.Text = unit;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ctr = sender as CheckBox;
            string Frm_name = this.ParentForm.Name;
           switch (Frm_name)
           {
               case "Form_Main": ((Form_Main)Application.OpenForms[Frm_name]).trend_refresh(ctr.Checked, this.Name); break;
               case "Frm_Realtrend": ((Frm_Realtrend)Application.OpenForms[Frm_name]).trend_refresh(ctr.Checked, this.Name); break;
               case "Frm_Realtrend2": ((Frm_Realtrend2)Application.OpenForms[Frm_name]).trend_refresh(ctr.Checked, this.Name); break;
           }


            if (Application.OpenForms["Form_Main"] != null)
            {
                ((Form_Main)Application.OpenForms["Form_Main"]).trend_refresh(ctr.Checked, this.Name);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Para_choose frm = new Para_choose(this, this.ParentForm.Name);
            frm.ShowDialog();
        }


    }

}
