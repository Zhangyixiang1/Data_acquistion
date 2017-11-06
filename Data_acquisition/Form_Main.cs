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
            //Random rd = new Random();
            ////zgc.Controls.Clear();
            //GraphPane myPane = zedGraphControl1.GraphPane;
            ////添加新的控件前先将面板上已经存在的控件清除。
            //myPane.CurveList.Clear();
            //myPane.GraphObjList.Clear();              // Set the titles and axis labels
            //myPane.Title.Text = "";
            //myPane.XAxis.Title.Text = "";
            //myPane.YAxis.Title.Text = "";
            //DateTime dt;
            //String[] szx = new String[10];//X轴的日期数组
            //Double[] szy = new Double[10];//Y轴的数据数组
            //for (int i = 0; i < 10; i++)
            //{
            //    //list.Add(i, Convert.ToDouble(dataGridView3[2, i].Value.ToString()));
            //    dt = DateTime.Now;
            //    szx[i] = dt.ToString("mm:ss");//18:00:00显示
            //    szy[i] = rd.Next(100);
            //}
            //myPane.XAxis.Type = AxisType.Text;

            //// Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            ////添加X轴、Y轴的数据到面板上，但是由于AddCurve方法没有匹配的参数，所以第二个X轴想显示         //时间数据时，要先设置为null，然后在下面单独添加。
            //LineItem myCurve = myPane.AddCurve("", null, szy, Color.Blue, SymbolType.None);
            //myPane.XAxis.Scale.TextLabels = szx;//添加日期到X轴
            //// Fill the area under the curve with a white-red gradient at 45 degrees
            //myCurve.Line.Fill = new Fill(Color.White, Color.White, 45F);
            //// Make the symbols opaque by filling them with white
            ////  myCurve.Symbol.Fill = new Fill(Color.White);

            //// Fill the axis background with a color gradient
            ////   myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            //// Fill the pane background with a color gradient
            ////   myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
            //// Calculate the Axis Scale Ranges
            //zedGraphControl1.AxisChange();
            //zedGraphControl1.Refresh();
            zedGraphControl1.IsShowContextMenu=false;
            zedGraphControl1.IsEnableHPan=false;zedGraphControl1.IsEnableVPan=false;
            zedGraphControl1.IsEnableHZoom=false;zedGraphControl1.IsEnableZoom=false;
            GraphPane myPane = zedGraphControl1.GraphPane;
           
            // Set the titles and axis labels
            myPane.Legend.IsVisible=false;
            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "时间, 分钟";
            myPane.YAxis.Title.Text = "井口油压, Mpa";
            myPane.Y2Axis.Title.Text = "井口套压, Mpa";

            // Make up some data points based on the Sine function
            PointPairList vList = new PointPairList();
            PointPairList aList = new PointPairList();
            PointPairList dList = new PointPairList();
            PointPairList eList = new PointPairList();

            // Fabricate some data values
            for (int i = 0; i < 30; i++)
            {
                double time = (double)i;
                double acceleration = 2.0;
                double velocity = acceleration * time;
                double distance = acceleration * time * time / 2.0;
                double energy = 100.0 * velocity * velocity / 2.0;
                aList.Add(time, acceleration);
                vList.Add(time, velocity);
                eList.Add(time, energy);
                dList.Add(time, distance);
            }

            // Generate a red curve with diamond symbols, and "Velocity" in the legend
            LineItem myCurve = myPane.AddCurve("Velocity",
               vList, Color.Red, SymbolType.Diamond);
            // Fill the symbols with white
            myCurve.Symbol.Fill = new Fill(Color.White);

            // Generate a blue curve with circle symbols, and "Acceleration" in the legend
            myCurve = myPane.AddCurve("Acceleration",
               aList, Color.Blue, SymbolType.Circle);
            // Fill the symbols with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the Y2 axis
            myCurve.IsY2Axis = true;

            // Generate a green curve with square symbols, and "Distance" in the legend
            myCurve = myPane.AddCurve("Distance",
               dList, Color.Green, SymbolType.Square);
            // Fill the symbols with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the second Y axis
            myCurve.YAxisIndex = 1;

            // Generate a Black curve with triangle symbols, and "Energy" in the legend
            myCurve = myPane.AddCurve("Energy",
               eList, Color.Black, SymbolType.Triangle);
            // Fill the symbols with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the Y2 axis
            myCurve.IsY2Axis = true;
            // Associate this curve with the second Y2 axis
            myCurve.YAxisIndex = 1;

            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;

            // Make the Y axis scale red
            myPane.YAxis.Scale.FontSpec.FontColor = Color.Red;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Red;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            myPane.YAxis.Scale.Max = 100;

            // Enable the Y2 axis display
            myPane.Y2Axis.IsVisible = true;
            // Make the Y2 axis scale blue
            myPane.Y2Axis.Scale.FontSpec.FontColor = Color.Blue;
            myPane.Y2Axis.Title.FontSpec.FontColor = Color.Blue;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            myPane.Y2Axis.MajorTic.IsOpposite = false;
            myPane.Y2Axis.MinorTic.IsOpposite = false;
            // Display the Y2 axis grid lines
            myPane.Y2Axis.MajorGrid.IsVisible = true;
            // Align the Y2 axis labels so they are flush to the axis
            myPane.Y2Axis.Scale.Align = AlignP.Inside;
            myPane.Y2Axis.Scale.Min = 1.5;
            myPane.Y2Axis.Scale.Max = 3;

            // Create a second Y Axis, green
            YAxis yAxis3 = new YAxis("密度, g/cm3");
            myPane.YAxisList.Add(yAxis3);
            yAxis3.Scale.FontSpec.FontColor = Color.Green;
            yAxis3.Title.FontSpec.FontColor = Color.Green;
            yAxis3.Color = Color.Green;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis3.MajorTic.IsInside = false;
            yAxis3.MinorTic.IsInside = false;
            yAxis3.MajorTic.IsOpposite = false;
            yAxis3.MinorTic.IsOpposite = false;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis3.Scale.Align = AlignP.Inside;

            Y2Axis yAxis4 = new Y2Axis("排量,L");
            yAxis4.IsVisible = true;
            myPane.Y2AxisList.Add(yAxis4);
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis4.MajorTic.IsInside = false;
            yAxis4.MinorTic.IsInside = false;
            yAxis4.MajorTic.IsOpposite = false;
            yAxis4.MinorTic.IsOpposite = false;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis4.Scale.Align = AlignP.Inside;
            yAxis4.Scale.Min = 100;

            // Fill the axis background with a gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);

            zedGraphControl1.AxisChange();


           
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
