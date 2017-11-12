using Data_acquisition.Ctrl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Telerik.WinControls;
using ZedGraph;
namespace Data_acquisition
{
    public partial class Form_Main : Telerik.WinControls.UI.RadForm
    {
        ToolTip toolTip1;
        DateTime time;
        DateTime time_stage;
        bool run;//是否记录数据
        double count;//测试用
        public static Dictionary<string, double[]> Paralist; //数据缓存
        public Form_Main()
        {
            InitializeComponent();

            time = Convert.ToDateTime("00:00:00");
            time_stage = Convert.ToDateTime("00:00:00");
            this.Location = new Point(0, 0);
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            toolTip1 = new ToolTip();
            Paralist = new Dictionary<string, double[]>();
            xml_load();//读取偏好设置文件
            chart_initial();//初始化图表控件

            //测试用，在子线程中生成随机数填充paralist
            Thread th = new Thread(intialdata);
            th.IsBackground = true;
            th.Start();
            //开启用户控件定时器

            foreach (Control ctrl in this.tabControl1.Controls)
            {
                if (ctrl is TabPage)
                {
                    TabPage ctrl2 = ctrl as TabPage;
                    foreach (Control ctr in ctrl2.Controls)
                    {
                        if (ctr is Parashow)
                        {
                            Parashow ctr2 = ctr as Parashow;
                            ctr2.timer1.Enabled = true;
                        }
                    }
                }
            }



        }
        /// <summary>
        /// 产生测试用随机数
        /// </summary>
        private void intialdata()
        {
            double[] test = new double[100];
            Random rd = new Random();
            while (true)
            {
                try
                {
                    Thread.Sleep(500);
                    for (int i = 0; i < 100; i++)
                    {
                        test[i] = rd.Next(0, 1000);
                    }

                    Paralist.Add(DateTime.Now.ToString(), test);

                }
                catch { }
            }
        }
        /// <summary>
        /// 记录定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            time = time.AddSeconds(1);
            time_stage = time_stage.AddSeconds(1);
            lbl_time.Text = string.Format("{0:T}", time);
            lbl_stagetime.Text = string.Format("{0:T}", time_stage);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (run) { timer_log.Enabled = false; run = false; btn_start.Text = "开始"; timer_trend.Enabled = false; }
            else if (!run) { timer_log.Enabled = true; run = true; btn_start.Text = "暂停"; timer_trend.Enabled = true; }
        }
        /// <summary>
        /// 当前时间定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_now_Tick(object sender, EventArgs e)
        {
            lbl_now.Text = DateTime.Now.ToString();
        }
        #region 初始化zed控件
        /// <summary>
        /// 初始化图表控件
        /// </summary>
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
            zedGraphControl1.IsShowContextMenu = false;
            zedGraphControl1.IsEnableHPan = false; zedGraphControl1.IsEnableVPan = false;
            zedGraphControl1.IsEnableHZoom = false; zedGraphControl1.IsEnableZoom = false;
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Fill = new Fill(Color.FromArgb(28,29,31));
            myPane.Chart.Fill = new Fill(Color.FromArgb(49, 49, 49));
            // Set the titles and axis labels
            myPane.Legend.IsVisible = false;
            myPane.Title.Text = "";
          
            myPane.XAxis.Title.Text = "时间(分钟)";
            
            myPane.XAxis.Scale.FontSpec.Size = 5;
            myPane.XAxis.Title.FontSpec.Size = 5;
            myPane.XAxis.Scale.Min = 0; //X轴最小值0
            myPane.XAxis.Scale.Max = 30; //X轴最大30

            myPane.XAxis.Scale.MajorStep = 5;//X轴大步长为5，也就是显示文字的大间隔

            myPane.YAxis.Title.Text = paraLine3.Tagname + "(" + paraLine3.Unit + ")";
            myPane.Y2Axis.Title.Text = paraLine4.Tagname + "(" + paraLine4.Unit + ")";

            // Make up some data points based on the Sine function
            PointPairList List1 = new PointPairList();
            PointPairList List2 = new PointPairList();
            PointPairList List3 = new PointPairList();
            PointPairList List4 = new PointPairList();
            PointPairList List5 = new PointPairList();
            PointPairList List6 = new PointPairList();
            // 测试用，用蓝色曲线做测试
            Random rd = new Random();
            for (int i = 0; i <= 1800; i++)
            {
                List1.Add(i / 60, i/10  + 10);
                List2.Add(i / 60, i / 10 + 10);
                List3.Add(i / 60, i / 10 + 10);
                List4.Add(i / 60, i / 10 + 10);
                List5.Add(i / 60, i / 10 + 10);
                List6.Add(i / 60, i / 10 + 10);

            }

            //}

            // Generate a blue curve with diamond symbols, and "Velocity" in the legend
            LineItem myCurve = myPane.AddCurve("Velocity",
               List1, Color.Blue, SymbolType.None);
            myCurve.Line.Width = 2;
            // Fill the symbols with white
            // myCurve.Symbol.Fill = new Fill(Color.White);

            // Generate a darkblue curve with circle symbols, and "Acceleration" in the legend
            myCurve = myPane.AddCurve("Acceleration",
               List2, Color.DarkBlue, SymbolType.None);
            myCurve.Line.Width = 2;
            // Fill the symbols with white
            // myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the Y2 axis
            myCurve.IsY2Axis = true;

            // Generate a black curve with square symbols, and "Distance" in the legend
            myCurve = myPane.AddCurve("Distance",
               List3, Color.Black, SymbolType.None);
            myCurve.Line.Width = 2;
            // Fill the symbols with white
            //   myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the second Y axis
            myCurve.YAxisIndex = 1;

            // Generate a green curve with triangle symbols, and "Energy" in the legend
            myCurve = myPane.AddCurve("Energy",
               List4, Color.SeaGreen, SymbolType.None);
            myCurve.Line.Width = 2;
            // Fill the symbols with white
            //myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the Y2 axis
            myCurve.IsY2Axis = true;
            // Associate this curve with the second Y2 axis
            myCurve.YAxisIndex = 1;

            // Generate a red curve with square symbols, and "Distance" in the legend
            myCurve = myPane.AddCurve("Distance",
               List5, Color.Red, SymbolType.None);
            myCurve.Line.Width = 2;
            // Fill the symbols with white
            //  myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the second Y axis
            myCurve.YAxisIndex = 2;

            // Generate a purple curve with triangle symbols, and "Energy" in the legend
            myCurve = myPane.AddCurve("Energy",
               List6, Color.Purple, SymbolType.None);
            myCurve.Line.Width = 2;
            // Fill the symbols with white
            //  myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the Y2 axis
            myCurve.IsY2Axis = true;
            // Associate this curve with the second Y2 axis
            myCurve.YAxisIndex = 2;


            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;

            // Make the Y axis blue
            myPane.YAxis.Scale.FontSpec.FontColor = Color.Blue;
            myPane.YAxis.Scale.FontSpec.Size = 10;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Blue;
            myPane.YAxis.Title.FontSpec.Size = 10;
            myPane.YAxis.Color = Color.Blue;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            myPane.YAxis.Scale.Max = int.Parse(paraLine3.Max);
            myPane.YAxis.Scale.Min = int.Parse(paraLine3.Min);

            // Enable the Y2 axis DarkBlue
            myPane.Y2Axis.IsVisible = true;
            // Make the Y2 axis scale black
            myPane.Y2Axis.Scale.FontSpec.FontColor = Color.DarkBlue;
            myPane.Y2Axis.Scale.FontSpec.Size = 10;
            myPane.Y2Axis.Title.FontSpec.FontColor = Color.DarkBlue;
            myPane.Y2Axis.Title.FontSpec.Size = 10;
            myPane.Y2Axis.Color = Color.DarkBlue;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            myPane.Y2Axis.MajorTic.IsOpposite = false;
            myPane.Y2Axis.MinorTic.IsOpposite = false;
            // Display the Y2 axis grid lines
            myPane.Y2Axis.MajorGrid.IsVisible = true;
            // Align the Y2 axis labels so they are flush to the axis
            myPane.Y2Axis.Scale.Align = AlignP.Inside;
            myPane.Y2Axis.Scale.Max = int.Parse(paraLine4.Max);
            myPane.Y2Axis.Scale.Min = int.Parse(paraLine4.Min);

            // Create a second Y Axis, black
            YAxis yAxis3 = new YAxis(paraLine2.Tagname + "(" + paraLine2.Unit + ")");
            myPane.YAxisList.Add(yAxis3);
            yAxis3.Scale.FontSpec.FontColor = Color.Black;
            yAxis3.Scale.FontSpec.Size = 10;
            yAxis3.Title.FontSpec.FontColor = Color.Black;
            yAxis3.Title.FontSpec.Size = 10;
            yAxis3.Color = Color.Black;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis3.MajorTic.IsInside = false;
            yAxis3.MinorTic.IsInside = false;
            yAxis3.MajorTic.IsOpposite = false;
            yAxis3.MinorTic.IsOpposite = false;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis3.Scale.Align = AlignP.Inside;
            yAxis3.Scale.Max = int.Parse(paraLine2.Max);
            yAxis3.Scale.Min = int.Parse(paraLine2.Min);


            // Create a third Y Axis, red
            YAxis yAxis5 = new YAxis(paraLine1.Tagname + "(" + paraLine1.Unit + ")");
            myPane.YAxisList.Add(yAxis5);
            yAxis5.Scale.FontSpec.FontColor = Color.Red;
            yAxis5.Scale.FontSpec.Size = 10;
            yAxis5.Title.FontSpec.FontColor = Color.Red;
            yAxis5.Title.FontSpec.Size = 10;
            yAxis5.Color = Color.Red;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis5.MajorTic.IsInside = false;
            yAxis5.MinorTic.IsInside = false;
            yAxis5.MajorTic.IsOpposite = false;
            yAxis5.MinorTic.IsOpposite = false;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis5.Scale.Align = AlignP.Inside;
            yAxis5.Scale.Max = int.Parse(paraLine1.Max);
            yAxis5.Scale.Min = int.Parse(paraLine1.Min);


            // Create a second Y2 Axis, green
            Y2Axis yAxis4 = new Y2Axis(paraLine5.Tagname + "(" + paraLine5.Unit + ")");
            yAxis4.IsVisible = true;
            myPane.Y2AxisList.Add(yAxis4);
            yAxis4.Scale.FontSpec.FontColor = Color.SeaGreen;
            yAxis4.Scale.FontSpec.Size = 10;
            yAxis4.Title.FontSpec.FontColor = Color.SeaGreen;
            yAxis4.Title.FontSpec.Size = 10;
            yAxis4.Color = Color.SeaGreen;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis4.MajorTic.IsInside = false;
            yAxis4.MinorTic.IsInside = false;
            yAxis4.MajorTic.IsOpposite = false;
            yAxis4.MinorTic.IsOpposite = false;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis4.Scale.Align = AlignP.Inside;
            yAxis4.Scale.Max = int.Parse(paraLine5.Max);
            yAxis4.Scale.Min = int.Parse(paraLine5.Min);

            // Create a third Y2 Axis, purple
            Y2Axis yAxis6 = new Y2Axis(paraLine6.Tagname + "(" + paraLine6.Unit + ")");
            yAxis6.IsVisible = true;
            myPane.Y2AxisList.Add(yAxis6);
            yAxis6.Scale.FontSpec.FontColor = Color.Purple;
            yAxis6.Scale.FontSpec.Size = 10;
            yAxis6.Title.FontSpec.FontColor = Color.Purple;
            yAxis6.Title.FontSpec.Size = 10;
            yAxis6.Color = Color.Purple;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis6.MajorTic.IsInside = false;
            yAxis6.MinorTic.IsInside = false;
            yAxis6.MajorTic.IsOpposite = false;
            yAxis6.MinorTic.IsOpposite = false;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis6.Scale.Align = AlignP.Inside;
            yAxis6.Scale.Max = int.Parse(paraLine6.Max);
            yAxis6.Scale.Min = int.Parse(paraLine6.Min);
            // Fill the axis background with a gradient
            //  myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);

            //新增，y轴不显示名称
            foreach (YAxis y in myPane.YAxisList) {
                y.Title.IsVisible = false;
            }
            foreach (Y2Axis y in myPane.Y2AxisList)
            {
                y.Title.IsVisible = false;
            }

            zedGraphControl1.AxisChange();



        }
        #endregion
        private void 视图1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Realtrend frm = new Frm_Realtrend();
            frm.Location = new Point(0, 0);
            frm.Show();
        }

        private void 视图2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Paradigital frm = new Frm_Paradigital();
            frm.Location = new Point(0, 0);
            frm.Show();
        }

        private void 视图3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Paraanalog frm = new Frm_Paraanalog();
            frm.Location = new Point(0, 0);
            frm.Show();
        }

        public void trend_refresh(string num_line)
        {
            string num = num_line.Substring(num_line.Length - 1);
            //对应编号的曲线重绘，包括上下限和编号
            switch (num)
            {
                case "1":
                    zedGraphControl1.GraphPane.YAxisList[2].Title.Text = paraLine1.Tagname + "(" + paraLine1.Unit + ")";
                    zedGraphControl1.GraphPane.YAxisList[2].Scale.Min = int.Parse(paraLine1.Min);
                    zedGraphControl1.GraphPane.YAxisList[2].Scale.Max = int.Parse(paraLine1.Max);
                    break;
                case "2":
                    zedGraphControl1.GraphPane.YAxisList[1].Title.Text = paraLine2.Tagname + "(" + paraLine2.Unit + ")";
                    zedGraphControl1.GraphPane.YAxisList[1].Scale.Min = int.Parse(paraLine2.Min);
                    zedGraphControl1.GraphPane.YAxisList[1].Scale.Max = int.Parse(paraLine2.Max);
                    break;
                case "3": zedGraphControl1.GraphPane.YAxisList[0].Title.Text = paraLine3.Tagname + "(" + paraLine3.Unit + ")";
                    zedGraphControl1.GraphPane.YAxisList[0].Scale.Min = int.Parse(paraLine3.Min);
                    zedGraphControl1.GraphPane.YAxisList[0].Scale.Max = int.Parse(paraLine3.Max);
                    break;
                case "4": zedGraphControl1.GraphPane.Y2AxisList[0].Title.Text = paraLine4.Tagname + "(" + paraLine4.Unit + ")";
                    zedGraphControl1.GraphPane.Y2AxisList[0].Scale.Min = int.Parse(paraLine4.Min);
                    zedGraphControl1.GraphPane.Y2AxisList[0].Scale.Max = int.Parse(paraLine4.Max);
                    break;
                case "5": zedGraphControl1.GraphPane.Y2AxisList[1].Title.Text = paraLine5.Tagname + "(" + paraLine5.Unit + ")";
                    zedGraphControl1.GraphPane.Y2AxisList[1].Scale.Min = int.Parse(paraLine5.Min);
                    zedGraphControl1.GraphPane.Y2AxisList[1].Scale.Max = int.Parse(paraLine5.Max);
                    break;
                case "6": zedGraphControl1.GraphPane.Y2AxisList[2].Title.Text = paraLine6.Tagname + "(" + paraLine6.Unit + ")";
                    zedGraphControl1.GraphPane.Y2AxisList[2].Scale.Min = int.Parse(paraLine6.Min);
                    zedGraphControl1.GraphPane.Y2AxisList[2].Scale.Max = int.Parse(paraLine6.Max);
                    break;
            }
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }
        public void trend_refresh(bool isshow, string num_line)
        {
            string num = num_line.Substring(num_line.Length - 1);
            //对应编号的曲线重绘，包括上下限和编号
            switch (num)
            {
                case "1":
                    zedGraphControl1.GraphPane.CurveList[4].IsVisible = isshow;
                    zedGraphControl1.GraphPane.YAxisList[2].IsVisible = isshow;
                    break;
                case "2":
                    zedGraphControl1.GraphPane.CurveList[2].IsVisible = isshow;
                    zedGraphControl1.GraphPane.YAxisList[1].IsVisible = isshow;
                    break;
                case "3":
                    zedGraphControl1.GraphPane.CurveList[0].IsVisible = isshow;
                    zedGraphControl1.GraphPane.YAxisList[0].IsVisible = isshow;
                    break;
                case "4":
                    zedGraphControl1.GraphPane.CurveList[1].IsVisible = isshow;
                    zedGraphControl1.GraphPane.Y2AxisList[0].IsVisible = isshow;
                    break;
                case "5":
                    zedGraphControl1.GraphPane.CurveList[3].IsVisible = isshow;
                    zedGraphControl1.GraphPane.Y2AxisList[1].IsVisible = isshow;
                    break;
                case "6":
                    zedGraphControl1.GraphPane.CurveList[5].IsVisible = isshow;
                    zedGraphControl1.GraphPane.Y2AxisList[2].IsVisible = isshow;
                    break;
            }
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }
        private void xml_load()
        {
            try
            {
                string path = Application.StartupPath + "\\Config\\preference.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode root = doc.DocumentElement;
                //现读取paraLine控件的信息
                XmlNodeList nodeList = root.SelectNodes("Form[Name='Form_Main']//Controlsline//Control");
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is ParaLine)
                    {
                        ParaLine ctr = ctrl as ParaLine;
                        foreach (XmlNode node in nodeList)
                        {
                            if (ctr.Name == node.SelectSingleNode("@name").InnerText)
                            {
                                ctr.Tagname = node.SelectSingleNode("@tagname").InnerText;
                                ctr.Min = node.SelectSingleNode("@min").InnerText;
                                ctr.Max = node.SelectSingleNode("@max").InnerText;
                                ctr.Unit = node.SelectSingleNode("@unit").InnerText;
                                ctr.Tag = node.SelectSingleNode("@index").InnerText;
                                ctr.refresh();

                            }

                        }
                    }
                }
                //再读取parashow控件的信息
                nodeList = root.SelectNodes("Form[Name='Form_Main']//Controlsshow//Control");
                foreach (Control ctrl in this.tabControl1.Controls)
                {
                    if (ctrl is TabPage)
                    {
                        TabPage ctrl2 = ctrl as TabPage;
                        foreach (Control ctr in ctrl2.Controls)
                        {
                            if (ctr is Parashow)
                            {
                                Parashow ctr2 = ctr as Parashow;
                                foreach (XmlNode node in nodeList)
                                {
                                    if (ctr2.Name == node.SelectSingleNode("@name").InnerText)
                                    {
                                        ctr2.Tagname = node.SelectSingleNode("@tagname").InnerText;
                                        ctr2.Unit = node.SelectSingleNode("@unit").InnerText;
                                        ctr2.Tag = node.SelectSingleNode("@index").InnerText;
                                        ctr2.refresh();
                                    }

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }




        }

        private void timer_trend_Tick(object sender, EventArgs e)
        {
            //取Graph第一个曲线，也就是第一步:在GraphPane.CurveList集合中查找CurveItem
            LineItem curve1 = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            LineItem curve2 = zedGraphControl1.GraphPane.CurveList[1] as LineItem;
            LineItem curve3 = zedGraphControl1.GraphPane.CurveList[2] as LineItem;
            LineItem curve4 = zedGraphControl1.GraphPane.CurveList[3] as LineItem;
            LineItem curve5 = zedGraphControl1.GraphPane.CurveList[4] as LineItem;
            LineItem curve6 = zedGraphControl1.GraphPane.CurveList[5] as LineItem;
            if (curve1 == null)
            {
                return;
            }

            //第二步:在CurveItem中访问PointPairList(或者其它的IPointList)，根据自己的需要增加新数据或修改已存在的数据
            IPointListEdit list1 = curve1.Points as IPointListEdit;
            IPointListEdit list2 = curve2.Points as IPointListEdit;
            IPointListEdit list3 = curve3.Points as IPointListEdit;
            IPointListEdit list4 = curve4.Points as IPointListEdit;
            IPointListEdit list5 = curve5.Points as IPointListEdit;
            IPointListEdit list6 = curve6.Points as IPointListEdit;

            if (list1 == null)
            {
                return;
            }

            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            double factor = xScale.Max * 60;
            //添加数据
            list1.Add(count / factor, (new Random()).Next(50));
            list2.Add(count / factor, (new Random()).Next(50));
            list3.Add(count / factor, (new Random()).Next(50));
            list4.Add(count / factor, (new Random()).Next(50));
            list5.Add(count / factor, (new Random()).Next(50));
            list6.Add(count / factor, (new Random()).Next(50));
            count++;

            if (count / factor > xScale.Max)
            {
                xScale.Max = xScale.Max + 30;
                xScale.MajorStep = xScale.Max / 6;//X轴大步长为5，也就是显示文字的大间隔
            }


            //Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            //if (time > xScale.Max - xScale.MajorStep)
            //{
            //xScale.Max = time + xScale.MajorStep;
            //xScale.Min = xScale.Max - 30.0;


            //第三步:调用ZedGraphControl.AxisChange()方法更新X和Y轴的范围
            zedGraphControl1.AxisChange();

            //第四步:调用Form.Invalidate()方法更新图表
            zedGraphControl1.Invalidate();
        }

        private void pnl_setting_VisibleChanged(object sender, EventArgs e)
        {
            if (pnl_setting.Visible)
            {
                cmb_line.Items.Add(paraLine1.Tagname); cmb_line.Items.Add(paraLine2.Tagname); cmb_line.Items.Add(paraLine3.Tagname);
                cmb_line.Items.Add(paraLine4.Tagname); cmb_line.Items.Add(paraLine5.Tagname); cmb_line.Items.Add(paraLine6.Tagname);
            }
            else { cmb_line.Items.Clear(); }
        }

        private void 图像编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnl_setting.Visible = true;
        }

        private void cmb_line_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chk_time_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_time.Checked) { txb_start.Enabled = false; txb_end.Enabled = false; }
            else { txb_start.Enabled = true; txb_end.Enabled = true; }
        }
        #region 图像编辑相关算法

        private void btn_ok_Click(object sender, EventArgs e)
        {
            //不编辑被选中，则隐藏面板
            if (rab_none.Checked) { pnl_setting.Visible = false; return; }

            int sel_line = 0;
            //获取选取的曲线编号
            switch (cmb_line.SelectedIndex)
            {
                case (0): { sel_line = 4; break; }
                case (1): { sel_line = 2; break; }
                case (2): { sel_line = 0; break; }
                case (3): { sel_line = 1; break; }
                case (4): { sel_line = 3; break; }
                case (5): { sel_line = 5; break; }


            }
            IPointListEdit list = zedGraphControl1.GraphPane.CurveList[sel_line].Points as IPointListEdit;
            //根据不同的算法做出相应的修改

            // 取得时间轴的最大值最小值
            int scale_max, scale_min;
            //判断是否选取了应用整个时间通道
            if (chk_time.Checked)
            {
                scale_max = list.Count - 1; scale_min = 0;
            }
            else { scale_max = int.Parse(txb_end.Text); scale_min = int.Parse(txb_start.Text); }
            //插值方法
            if (rab_interpolation.Checked)
            {

                //求出一次函数y=kx+b的斜率k,偏移量b
                double k = (list[scale_max].Y - list[scale_min].Y) / (list[scale_max].X - list[scale_min].X);
                double b = list[scale_max].Y - k * list[scale_max].X;
                //修改数据点
                for (int i = scale_min; i <= scale_max; i++)
                {
                    list[i] = new ZedGraph.PointPair((double)i / 60, k * i / 60 + b);
                }
            }
            //设置方法
            if (rab_set.Checked)
            {
                for (int i = scale_min; i <= scale_max; i++)
                {

                    list[i] = new ZedGraph.PointPair((double)i / 60, double.Parse(txb_set.Text));
                }

            }
            //递推平均方法
            if (rab_recurrence.Checked)
            {
                //取得采样长度N
                int N = int.Parse(txb_recurrence.Text);
                List<double> filter = new List<double>();
                //初始化采样队列
                for (int i = 0; i < N; i++) filter.Add(list[scale_min + i].Y);
                //滤波
                for (int i = 0; i < scale_max - scale_min - N; i++)
                {
                    filter.RemoveAt(0);
                    filter.Add(list[scale_min + N + i].Y);
                    double sum = 0;
                    foreach (double item in filter) { sum = item + sum; }
                    list[scale_min + N + i].Y = sum / N;

                }

            }

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        #endregion
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            pnl_setting.Visible = false;
        }
    }
}

