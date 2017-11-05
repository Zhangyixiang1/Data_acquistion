using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using ZedGraph;
namespace Data_acquisition
{
    public partial class Form_Main : Telerik.WinControls.UI.RadForm
    {
        DateTime time;
        bool run;
        public Form_Main()
        {
            InitializeComponent();
            time = Convert.ToDateTime("00:00:00");
            this.Location = new Point(0, 0);
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            chart_initial();//初始化图表控件
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time = time.AddSeconds(1);
            lbl_time.Text = string.Format("{0:T}", time);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (run) { timer_log.Enabled = false; run = false; btn_start.Text = "开始"; }
            else if (!run) { timer_log.Enabled = true; run = true; btn_start.Text = "暂停"; }
        }

        private void timer_now_Tick(object sender, EventArgs e)
        {
            lbl_now.Text = DateTime.Now.ToString();
        }
        private void chart_initial()
        {
            Random rd = new Random();
            //zgc.Controls.Clear();
            GraphPane myPane = zedGraphControl1.GraphPane;
            //添加新的控件前先将面板上已经存在的控件清除。
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();              // Set the titles and axis labels
            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "";
            myPane.YAxis.Title.Text = "";
            DateTime dt;
            String[] szx = new String[10];//X轴的日期数组
            Double[] szy = new Double[10];//Y轴的数据数组
            for (int i = 0; i < 10; i++)
            {
                //list.Add(i, Convert.ToDouble(dataGridView3[2, i].Value.ToString()));
                dt = DateTime.Now;
                szx[i] = dt.ToString("mm:ss");//18:00:00显示
                szy[i] = rd.Next(100);
            }
            myPane.XAxis.Type = AxisType.Text;

            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            //添加X轴、Y轴的数据到面板上，但是由于AddCurve方法没有匹配的参数，所以第二个X轴想显示         //时间数据时，要先设置为null，然后在下面单独添加。
            LineItem myCurve = myPane.AddCurve("", null, szy, Color.Blue, SymbolType.None);
            myPane.XAxis.Scale.TextLabels = szx;//添加日期到X轴
            // Fill the area under the curve with a white-red gradient at 45 degrees
            myCurve.Line.Fill = new Fill(Color.White, Color.White, 45F);
            // Make the symbols opaque by filling them with white
            //  myCurve.Symbol.Fill = new Fill(Color.White);

            // Fill the axis background with a color gradient
            //   myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            // Fill the pane background with a color gradient
            //   myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
            // Calculate the Axis Scale Ranges
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
           
        }

        private void 视图1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Realtrend frm=new Frm_Realtrend ();
            frm.Location=new Point(0,0);
            frm.Show();
        }

        private void 视图2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Paradigital frm=new Frm_Paradigital ();
            frm.Location = new Point(0, 0);
            frm.Show();
        }

        private void 视图3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Paraanalog frm=new Frm_Paraanalog();
            frm.Location = new Point(0, 0);
            frm.Show();
        }
    }
}
