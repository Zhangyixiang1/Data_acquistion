using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
namespace Data_acquisition
{
    public partial class Frm_Realtrend2 : Form
    {
        private ZedGraphControl zedGraphControl1;
        public Frm_Realtrend2(GraphPane panel)
        {
            InitializeComponent();
            zedGraphControl1 = new ZedGraphControl();
            zedGraphControl1.Size = new System.Drawing.Size(1920, 540);
            zedGraphControl1.Location = new Point(0, 0);
            //初始化相关属性
            zedGraphControl1.IsShowContextMenu = false;
            zedGraphControl1.IsEnableHPan = false; zedGraphControl1.IsEnableVPan = false;
            zedGraphControl1.IsEnableHZoom = false; zedGraphControl1.IsEnableZoom = false;
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Fill = new Fill(Color.FromArgb(28, 29, 31));
            myPane.Chart.Fill = new Fill(Color.Black);
            //   myPane.Border.IsVisible = false;
            myPane.Border.Color = Color.White;
            myPane.IsFontsScaled = false;
            //legend 相关属性
            myPane.Legend.Fill = new Fill(Color.FromArgb(28, 29, 31));
            myPane.Legend.Border.IsVisible = false;
            myPane.Legend.Position = LegendPos.TopCenter;
            myPane.Legend.FontSpec.FontColor = Color.White;
            myPane.Legend.FontSpec.Size = 15;
            // Set the titles and axis labels
            myPane.Title.Text = "";
            myPane.YAxisList.Clear();
            for (int i = 0; i < panel.YAxisList.Count; i++) { myPane.YAxisList.Add(panel.YAxisList[i]); }
            myPane.Y2AxisList.Clear();
            for (int i = 0; i < panel.Y2AxisList.Count; i++) { myPane.Y2AxisList.Add(panel.Y2AxisList[i]); }
            //x轴

            myPane.XAxis.Title.Text = "时间(分钟)";
            myPane.XAxis.MajorGrid.Color = Color.White;
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MinorGrid.Color = Color.White;
            // myPane.XAxis.MinorGrid.IsVisible = true;
            myPane.XAxis.Scale.FontSpec.FontColor = Color.White;
            myPane.XAxis.Title.FontSpec.Size = 15;
            myPane.XAxis.Scale.FontSpec.Size = 15;
            myPane.XAxis.Title.FontSpec.FontColor = Color.White;
            myPane.XAxis.Scale.Min = panel.XAxis.Scale.Min; //X轴最小值0
            myPane.XAxis.Scale.Max = panel.XAxis.Scale.Max; //X轴最大30
            myPane.XAxis.MajorTic.IsInside = false;
            myPane.XAxis.MinorTic.IsInside = false;
            myPane.XAxis.MajorTic.IsOpposite = false;
            myPane.XAxis.MinorTic.IsOpposite = false;
            myPane.XAxis.MajorTic.Color = Color.White;
            myPane.XAxis.MinorTic.Color = Color.White;
            myPane.XAxis.Scale.MajorStep = 5;//X轴大步长为5，也就是显示文字的大间隔
            //曲线
            myPane.CurveList = panel.CurveList;
        }

        private void Frm_Realtrend2_Load(object sender, EventArgs e)
        {
            this.Controls.Add(zedGraphControl1);
            zedGraphControl1.Location = new Point(0, 0);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }

        private void Frm_Realtrend2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Location = new Point(1921, 0); this.BringToFront();
        }
        public void grid_refresh()
        {
            DbManager db = new DbManager();
            db.ConnStr = "Data Source=localhost;" +
                    "Initial Catalog=ifracview;User Id=root;Password=hhdq;";
            string sql = "select Stage,Sand,LA1,LA2,LA3,LA4,DA1,Cleanvol from schedule";
            DataTable tb = db.ExcuteDataTable(sql);
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = tb;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            double factor = xScale.Max * 60;
            factor = 1; //测试用
            if (zedGraphControl1.GraphPane.CurveList[0].Points.Count / factor > xScale.Max)
            {
                xScale.Max = xScale.Max + 30;
                xScale.MajorStep = xScale.Max / 6;//X轴大步长为5，也就是显示文字的大间隔
            }
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }
    }
}
