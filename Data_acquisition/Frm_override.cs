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
    public partial class Frm_override : Form
    {  int index;
        public Frm_override()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
             index=((RadioButton)sender).TabIndex;
            txb_old.Text=Form_Main.value_blender.GetValue(625+(index-1)).ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(txb_new.Text==""){MessageBox.Show("请输入override的值！");return;}
           double value = Convert.ToDouble(txb_new.Text);
            Form_Main.kep1.KepItems.Item(603 + (index - 1) * 3).Write(true);  //发送overide信号
            if (rdbtn_stage.Checked) { Form_Main.kep1.KepItems.Item(621).Write(true); }
            if (rdbtn_job.Checked) { Form_Main.kep1.KepItems.Item(622).Write(true); }
            Form_Main.kep1.KepItems.Item(604 + (index - 1) * 3).Write(value);
            this.Close();
        }

        private void Frm_override_Load(object sender, EventArgs e)
        {
            
            txb_old.Text = Form_Main.value_blender.GetValue(625 ).ToString();
        }
    }
}
