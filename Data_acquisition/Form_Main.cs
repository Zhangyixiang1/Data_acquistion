using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Data_acquisition
{
    public partial class Form_Main : Telerik.WinControls.UI.RadForm
    {
    DateTime time;
    bool run;
        public Form_Main()
        {
            InitializeComponent();
            time=Convert.ToDateTime("00:00:00");
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          time=  time.AddSeconds(1);
            lbl_time.Text=string.Format("{0:T}",time);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
           if(run){timer1.Enabled=false;run=false;btn_start.Text="开始";}
           else if (!run) { timer1.Enabled = true; run = true; btn_start.Text = "暂停"; }
        }
    }
}
