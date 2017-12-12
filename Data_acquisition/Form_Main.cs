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
using ZcLibrary;
using NPOI;
using Data_acquisition.DAL;
using MySql.Data.MySqlClient;
using System.Linq;
using Newtonsoft.Json;
using Data_acquisition.Comm;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
namespace Data_acquisition
{
    /// <summary>
    ///  iFracview system written by Kevin.zhang 2017/11/11
    /// </summary>
    public partial class Form_Main : Telerik.WinControls.UI.RadForm
    {

        #region 变量声明
        public static Kepware kep1;//混砂车
        public static Kepware kep2;//压裂泵

        public static DataTable dt;//计划表
        public static DateTime time; //当前时间
        public static DateTime time_stage;//阶段时间
        public static int num_stage = 1;//阶段号
        public static int num_totalstage;//总的阶段数，导入计划时赋值
        public static int wellinfoID;
        public static string wellname;//油田名
        public static string wellnum;//井队号
        public static string stage_big;//第几大段
        public static bool iscnndatabase; //是否有新建施工和追加施工
        public static bool stage_auto; //阶段切换模式
        public static string tbname;//当前使用的数据库表单名
        bool run;//是否记录数据
        public static double count;//数据条目
        public static Dictionary<string, Datamodel> Paralist; //实时数据缓存
        public static Dictionary<string, Datamodel> Loglist; //记录数据缓存
        double[] test = new double[200]; //测试数据
        public static Array value_blender;//混砂车plc读到的原始值
        public static Array value_frac;//压力泵读到的原始值
        bool readfinish;
        #endregion

        #region 方法
        /// <summary>
        /// 构造函数
        /// </summary>
        public Form_Main()
        {
            InitializeComponent();
            time = Convert.ToDateTime("00:00:00");
            time_stage = Convert.ToDateTime("00:00:00");
            this.Size = new Size(1920, 1080);
            this.Location = new Point(0, 0);


        }
        /// <summary>
        /// 子线程，实现数据的归档与曲线的刷新
        /// </summary>
        private void intialdata()
        {

            Random rd = new Random();
            while (true)
            {
                try
                {
                    Thread.Sleep(500);
                    //模拟数据
                    //for (int i = 0; i < 200; i++)
                    //{

                    //    test[i] = i + rd.Next(0, 10);
                    //    if (count > 600) { test[i] = count / 10 + rd.Next(0, 10); }
                    //}
                    //读取混砂车的数据
                    value_blender = kep1.kep_read();
                    //读取压力泵的数据
                    value_frac = kep2.kep_read();

                    //更新进度条
                    int percent1 = Convert.ToInt16(value_blender.GetValue(589));
                    int percent2 = Convert.ToInt16(value_blender.GetValue(631));
                    percent_refresh(percent1, percent2);

                    //阶段号更新
                    num_totalstage = Convert.ToInt16(value_blender.GetValue(588));//总的阶段号
                    this.wellinfo_refresh();
                    ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).wellinfo_refresh();
                    ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).wellinfo_refresh();


                    //切换阶段时
                    int temp = Convert.ToInt16(value_blender.GetValue(585));
                    if (num_stage != temp)
                    {
                        num_stage = temp;
                        //阶段量清零
                        //for (int i = 54; i <= 67; i++)
                        //{
                        //    test[i] = 0;
                        //}
                        //if (!iscnndatabase) return;
                        // num_stage++;
                        //阶段时间清零
                        time_stage = Convert.ToDateTime("00:00:00");
                        //计划表选取更新
                        if (dataGridView1.Rows.Count >= num_stage)
                        {
                            dataGridView1.ClearSelection();
                            dataGridView1.Rows[num_stage - 1].Selected = true;
                        }
                        //阶段号更新
                        this.wellinfo_refresh();
                        ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).wellinfo_refresh();
                        ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).wellinfo_refresh();
                    }


                    Paralist.Add(DateTime.Now.ToString(), new Datamodel((int)count, test));

                    //读取混砂车数据,阶段统计量上位机
                    Blender_read();
                    //读取压裂泵数据,阶段统计量上位机
                    Frac_read();
                    //格式化为指定的小数位数
                    trans_2point(test,2);
                    //实时数据缓存只有一百条，用于参数的刷新
                    if (Paralist.Count > 10) Paralist.Remove(Paralist.ElementAt(0).Key);

                    //模拟用
                    // Paralist.Add(count.ToString(), test);


                    //1123新增，曲线界面不同时操控，可以单独配置
                    if (run)
                    {

                        Loglist.Add(DateTime.Now.ToString(), new Datamodel((int)count, test));
                        //测试用，后续要保存该数据对图像进行修改
                        if (Loglist.Count > 3600) Paralist.Remove(Paralist.ElementAt(0).Key);


                        //若添加成功，将最新值插入到数据库  
                        string json = JsonConvert.SerializeObject(Loglist.Last());
                        DbManager db = new DbManager();
                        db.ConnStr = "Data Source=localhost;" +
                        "Initial Catalog=ifracviewdata;User Id=root;Password=hhdq;";
                        string sql = "insert into " + tbname + " values ( 0, " + num_stage.ToString() + "," + "'" + json + "'" + ")";
                        int result = db.ExecuteNonquery(sql);

                        this.timer_trend((double)count, true);//主界面曲线刷新
                        ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).timer_trend(count, true);//界面1曲线刷新
                        ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).timer_trend(count, true);////界面2曲线刷新
                        count++;
                    }

                }
                catch (Exception ex)
                {
                    //           MessageBox.Show(ex.Message) ;
                }
            }
        }
        /// <summary>
        /// 控制输出小数位数
        /// </summary>
        /// <param name="item">array数组</param>
        /// <param name="points">小数位数</param>
        /// <returns>返回的Array</returns>
        private double[] trans_2point(double []item, int points)
        {
            for (int i = 0; i <item.Length; i++)
            {
                Math.Round(item[i],2);
            }
            return item;
        }




        /// <summary>
        /// 更新进度条和阶段号
        /// </summary>
        /// <param name="num">从plc读到的进度值</param>
        private void percent_refresh(int num, int num2)
        {
            if (num >= 100) num = 100;
            if (num2 > 100) num2 = 100;
            if (radProgressBar1.InvokeRequired)
            {
                radProgressBar1.Invoke(new Action(() => { radProgressBar1.Value1 = num; radProgressBar1.Text = num + "%"; }));
            }
            else { radProgressBar1.Value1 = num; radProgressBar1.Text = num + "%"; }

            if (((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).radProgressBar1.InvokeRequired)
            {
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).radProgressBar1.Invoke(new Action(() => { ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).radProgressBar1.Value1 = num; ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).radProgressBar1.Text = num + "%"; }));
            }
            else { ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).radProgressBar1.Value1 = num; ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).radProgressBar1.Text = num + "%"; }

            if (((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).radProgressBar1.InvokeRequired)
            {
                ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).radProgressBar1.Invoke(new Action(() => { ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).radProgressBar1.Value1 = num; ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).radProgressBar1.Text = num + "%"; }));
            }
            else { ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).radProgressBar1.Value1 = num; ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).radProgressBar1.Text = num + "%"; }

            if (radProgressBar2.InvokeRequired)
            {
                radProgressBar2.Invoke(new Action(() => { radProgressBar2.Value1 = num2; radProgressBar2.Text = num2 + "%"; }));
            }
            else { radProgressBar2.Value1 = num2; radProgressBar2.Text = num2 + "%"; }

            if (((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).radProgressBar2.InvokeRequired)
            {
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).radProgressBar2.Invoke(new Action(() => { ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).radProgressBar2.Value1 = num2; ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).radProgressBar2.Text = num2 + "%"; }));
            }
            else { ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).radProgressBar2.Value1 = num2; ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).radProgressBar2.Text = num2 + "%"; }

            if (((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).radProgressBar2.InvokeRequired)
            {
                ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).radProgressBar2.Invoke(new Action(() => { ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).radProgressBar2.Value1 = num2; ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).radProgressBar2.Text = num2 + "%"; }));
            }
            else { ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).radProgressBar2.Value1 = num2; ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).radProgressBar2.Text = num2 + "%"; }


        }


        /// <summary>
        /// 初始化plc相关变量
        /// </summary>
        private void Kep_initial()
        {
            //先注册混砂车
            kep1 = new Kepware();
            string path = Application.StartupPath + "\\Config\\Blender.txt";
            if (!kep1.kep_initial(path, "B"))
            {
                MessageBox.Show("混砂车PLC变量注册失败，请检查kepware相关设置，随后重启软件！");
                Application.Exit();
            }
            //注册压裂泵
            kep2 = new Kepware();
            path = Application.StartupPath + "\\Config\\Frac.txt";
            if (!kep2.kep_initial(path, "F"))
            {
                MessageBox.Show("压裂泵PLC变量注册失败，请检查kepware相关设置，随后重启软件！");
                // Application.Exit();
            }

        }

        /// <summary>
        /// 曲线刷新
        /// </summary>
        /// <param name="num_line">曲线编号</param>
        public void trend_refresh(string num_line)
        {
            string num = num_line.Substring(num_line.Length - 1);
            //对应编号的曲线重绘，包括上下限和编号
            switch (num)
            {
                case "1":
                    zedGraphControl1.GraphPane.CurveList[4].Label.Text = paraLine1.Tagname;
                    zedGraphControl1.GraphPane.CurveList[4].Color = paraLine1.Color;
                    zedGraphControl1.GraphPane.YAxisList[2].MajorTic.Color = paraLine1.Color;
                    zedGraphControl1.GraphPane.YAxisList[2].MinorTic.Color = paraLine1.Color;
                    zedGraphControl1.GraphPane.YAxisList[2].Color = paraLine1.Color;
                    zedGraphControl1.GraphPane.YAxisList[2].Scale.FontSpec.FontColor = paraLine1.Color;
                    zedGraphControl1.GraphPane.YAxisList[2].Title.Text = paraLine1.Tagname + "(" + paraLine1.Unit + ")";
                    zedGraphControl1.GraphPane.YAxisList[2].Scale.Min = int.Parse(paraLine1.Min);
                    zedGraphControl1.GraphPane.YAxisList[2].Scale.Max = int.Parse(paraLine1.Max);
                    break;
                case "2":
                    zedGraphControl1.GraphPane.CurveList[2].Label.Text = paraLine2.Tagname;
                    zedGraphControl1.GraphPane.CurveList[2].Color = paraLine2.Color;
                    zedGraphControl1.GraphPane.YAxisList[1].MajorTic.Color = paraLine2.Color;
                    zedGraphControl1.GraphPane.YAxisList[1].MinorTic.Color = paraLine2.Color;
                    zedGraphControl1.GraphPane.YAxisList[1].Color = paraLine2.Color;
                    zedGraphControl1.GraphPane.YAxisList[1].Scale.FontSpec.FontColor = paraLine2.Color;
                    zedGraphControl1.GraphPane.YAxisList[1].Title.Text = paraLine2.Tagname + "(" + paraLine2.Unit + ")";
                    zedGraphControl1.GraphPane.YAxisList[1].Scale.Min = int.Parse(paraLine2.Min);
                    zedGraphControl1.GraphPane.YAxisList[1].Scale.Max = int.Parse(paraLine2.Max);
                    break;
                case "3":
                    zedGraphControl1.GraphPane.CurveList[0].Label.Text = paraLine3.Tagname;
                    zedGraphControl1.GraphPane.CurveList[0].Color = paraLine3.Color;
                    zedGraphControl1.GraphPane.YAxisList[0].MajorTic.Color = paraLine3.Color;
                    zedGraphControl1.GraphPane.YAxisList[0].MinorTic.Color = paraLine3.Color;
                    zedGraphControl1.GraphPane.YAxisList[0].Color = paraLine3.Color;
                    zedGraphControl1.GraphPane.YAxisList[0].Scale.FontSpec.FontColor = paraLine3.Color;
                    zedGraphControl1.GraphPane.YAxisList[0].Title.Text = paraLine3.Tagname + "(" + paraLine3.Unit + ")";
                    zedGraphControl1.GraphPane.YAxisList[0].Scale.Min = int.Parse(paraLine3.Min);
                    zedGraphControl1.GraphPane.YAxisList[0].Scale.Max = int.Parse(paraLine3.Max);
                    break;
                case "4":
                    zedGraphControl1.GraphPane.CurveList[1].Label.Text = paraLine4.Tagname;
                    zedGraphControl1.GraphPane.CurveList[1].Color = paraLine4.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[0].MajorTic.Color = paraLine4.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[0].MinorTic.Color = paraLine4.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[0].Color = paraLine4.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[0].Scale.FontSpec.FontColor = paraLine4.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[0].Title.Text = paraLine4.Tagname + "(" + paraLine4.Unit + ")";
                    zedGraphControl1.GraphPane.Y2AxisList[0].Scale.Min = int.Parse(paraLine4.Min);
                    zedGraphControl1.GraphPane.Y2AxisList[0].Scale.Max = int.Parse(paraLine4.Max);
                    break;
                case "5":
                    zedGraphControl1.GraphPane.CurveList[3].Label.Text = paraLine5.Tagname;
                    zedGraphControl1.GraphPane.CurveList[3].Color = paraLine5.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[1].MajorTic.Color = paraLine5.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[1].MinorTic.Color = paraLine5.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[1].Color = paraLine5.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[1].Scale.FontSpec.FontColor = paraLine5.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[1].Title.Text = paraLine5.Tagname + "(" + paraLine5.Unit + ")";
                    zedGraphControl1.GraphPane.Y2AxisList[1].Scale.Min = int.Parse(paraLine5.Min);
                    zedGraphControl1.GraphPane.Y2AxisList[1].Scale.Max = int.Parse(paraLine5.Max);
                    break;
                case "6":
                    zedGraphControl1.GraphPane.CurveList[5].Label.Text = paraLine6.Tagname;
                    zedGraphControl1.GraphPane.CurveList[5].Color = paraLine6.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[2].MajorTic.Color = paraLine6.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[2].MinorTic.Color = paraLine6.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[2].Color = paraLine6.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[2].Scale.FontSpec.FontColor = paraLine6.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[2].Title.Text = paraLine6.Tagname + "(" + paraLine6.Unit + ")";
                    zedGraphControl1.GraphPane.Y2AxisList[2].Scale.Min = int.Parse(paraLine6.Min);
                    zedGraphControl1.GraphPane.Y2AxisList[2].Scale.Max = int.Parse(paraLine6.Max);
                    break;
            }

            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }


        /// <summary>
        /// 曲线刷新
        /// </summary>
        /// <param name="isshow">曲线是否显示</param>
        /// <param name="num_line">曲线编号</param>
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


        /// <summary>
        /// 读取xml偏好配置文件
        /// </summary>
        private void xml_load()
        {
            try
            {
                string path = Application.StartupPath + "\\Config\\preference.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode root = doc.DocumentElement;
                //先读取paraLine控件的信息
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
                                ctr.Color = Comm.ReadColor.getcolor(node.SelectSingleNode("@color").InnerText);
                                ctr.refresh();

                            }

                        }
                    }
                }

                //再读取parashow控件的信息
                nodeList = root.SelectNodes("Form[Name='Form_Main']//Controlsshow//Control");

                foreach (Control ctr in this.Controls)
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
                                ctr2.Color = Comm.ReadColor.getcolor(node.SelectSingleNode("@color").InnerText);
                                ctr2.refresh();
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


        #region 初始化zed控件
        /// <summary>
        /// 初始化图表控件
        /// </summary>
        private void chart_initial()
        {
            //修改，开放主界面的放大、缩小以及滑轮功能
            // zedGraphControl1.IsShowContextMenu = false;
            // zedGraphControl1.IsEnableHPan = false; zedGraphControl1.IsEnableVPan = false;
            // zedGraphControl1.IsEnableHZoom = false; zedGraphControl1.IsEnableZoom = false;
            GraphPane myPane = zedGraphControl1.GraphPane;
            //曲线面板属性
            //myPane.Fill = new Fill(Color.FromArgb(28, 29, 31));
            myPane.Fill = new Fill(Color.Black);
            myPane.Chart.Fill = new Fill(Color.Black);
            myPane.Chart.Border.Color = Color.Gray;
            myPane.IsFontsScaled = false;
            myPane.Border.Color = Color.White;
            myPane.Legend.IsVisible = false;
            myPane.Title.Text = " ";
            //x轴
            myPane.XAxis.Title.Text = "时间(分钟)";
            myPane.XAxis.MajorGrid.Color = Color.White;
            myPane.XAxis.Scale.FontSpec.FontColor = Color.White;
            myPane.XAxis.Scale.FontSpec.Size = 15;
            myPane.XAxis.Title.FontSpec.Size = 15;
            myPane.XAxis.Title.FontSpec.FontColor = Color.White;
            myPane.XAxis.Scale.Min = 0; //X轴最小值0
            myPane.XAxis.Scale.Max = 30; //X轴最大30
            myPane.XAxis.MajorTic.IsInside = false;
            myPane.XAxis.MinorTic.IsInside = false;
            myPane.XAxis.MajorTic.IsOpposite = false;
            myPane.XAxis.MinorTic.IsOpposite = false;
            myPane.XAxis.MajorTic.Color = Color.White;
            myPane.XAxis.MinorTic.Color = Color.White;
            myPane.XAxis.Scale.MajorStep = 5;//X轴大步长为5，也就是显示文字的大间隔
            //y轴
            myPane.YAxis.MajorTic.IsInside = false;
            myPane.YAxis.MajorGrid.Color = Color.White;
            myPane.YAxis.MinorTic.IsInside = false;
            myPane.Y2Axis.MajorTic.IsInside = false;
            myPane.Y2Axis.MajorGrid.Color = Color.White;
            myPane.Y2Axis.MinorTic.IsInside = false;


            // 添加6条曲线
            PointPairList List1 = new PointPairList();
            PointPairList List2 = new PointPairList();
            PointPairList List3 = new PointPairList();
            PointPairList List4 = new PointPairList();
            PointPairList List5 = new PointPairList();
            PointPairList List6 = new PointPairList();

            // 第1条线的标号为3
            LineItem myCurve = myPane.AddCurve(paraLine3.Tagname,
               List1, Color.Blue, SymbolType.None);
            myCurve.Line.Width = 1;
            // Fill the symbols with white
            // myCurve.Symbol.Fill = new Fill(Color.White);

            //第2条线的标号为4
            myCurve = myPane.AddCurve(paraLine4.Tagname,
               List2, Color.Lime, SymbolType.None);
            myCurve.Line.Width = 1;
            // Fill the symbols with white
            // myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the Y2 axis
            myCurve.IsY2Axis = true;

            // 第3条线的标号为2
            myCurve = myPane.AddCurve(paraLine2.Tagname,
               List3, Color.Yellow, SymbolType.None);
            myCurve.Line.Width = 1;
            // Fill the symbols with white
            //   myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the second Y axis
            myCurve.YAxisIndex = 1;

            // 第4条线的标号为5
            myCurve = myPane.AddCurve(paraLine5.Tagname,
               List4, Color.SeaGreen, SymbolType.None);
            myCurve.Line.Width = 1;
            // Fill the symbols with white
            //myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the Y2 axis
            myCurve.IsY2Axis = true;
            // Associate this curve with the second Y2 axis
            myCurve.YAxisIndex = 1;

            // 第5条线的标号为1
            myCurve = myPane.AddCurve(paraLine1.Tagname,
               List5, Color.Red, SymbolType.None);
            myCurve.Line.Width = 1;
            // Fill the symbols with white
            //  myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the second Y axis
            myCurve.YAxisIndex = 2;

            // 第6条线的标号为6
            myCurve = myPane.AddCurve(paraLine6.Tagname,
               List6, Color.SkyBlue, SymbolType.None);
            myCurve.Line.Width = 1;
            // Fill the symbols with white
            //  myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the Y2 axis
            myCurve.IsY2Axis = true;
            // Associate this curve with the second Y2 axis
            myCurve.YAxisIndex = 2;


            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;

            // 6条y轴的颜色，文字大小等相关属性
            myPane.YAxis.Scale.FontSpec.FontColor = Color.Blue;
            myPane.YAxis.Scale.FontSpec.Size = 15;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Blue;
            myPane.YAxis.Title.FontSpec.Size = 15;
            myPane.YAxis.Color = Color.Blue;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MajorTic.Color = Color.Blue;
            myPane.YAxis.MinorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.Color = Color.Blue;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            myPane.YAxis.Scale.Max = int.Parse(paraLine3.Max);
            myPane.YAxis.Scale.Min = int.Parse(paraLine3.Min);


            // Enable the Y2 axis Lime
            myPane.Y2Axis.IsVisible = true;
            // Make the Y2 axis scale black
            myPane.Y2Axis.Scale.FontSpec.FontColor = Color.Lime;
            myPane.Y2Axis.Scale.FontSpec.Size = 15;
            myPane.Y2Axis.Title.FontSpec.FontColor = Color.Lime;
            myPane.Y2Axis.Title.FontSpec.Size = 15;
            myPane.Y2Axis.Color = Color.Lime;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            myPane.Y2Axis.MajorTic.IsOpposite = false;
            myPane.Y2Axis.MajorTic.Color = Color.Lime;
            myPane.Y2Axis.MinorTic.IsOpposite = false;
            myPane.Y2Axis.MinorTic.Color = Color.Lime;
            // Display the Y2 axis grid lines
            myPane.Y2Axis.MajorGrid.IsVisible = true;
            // Align the Y2 axis labels so they are flush to the axis
            myPane.Y2Axis.Scale.Align = AlignP.Inside;
            myPane.Y2Axis.Scale.Max = int.Parse(paraLine4.Max);
            myPane.Y2Axis.Scale.Min = int.Parse(paraLine4.Min);

            // Create a second Y Axis, Yellow
            YAxis yAxis3 = new YAxis(paraLine2.Tagname + "(" + paraLine2.Unit + ")");
            myPane.YAxisList.Add(yAxis3);
            yAxis3.Scale.FontSpec.FontColor = Color.Yellow;
            yAxis3.Scale.FontSpec.Size = 15;
            yAxis3.Title.FontSpec.FontColor = Color.Yellow;
            yAxis3.Title.FontSpec.Size = 15;
            yAxis3.Color = Color.Yellow;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis3.MajorTic.IsInside = false;
            yAxis3.MinorTic.IsInside = false;
            yAxis3.MajorTic.IsOpposite = false;
            yAxis3.MajorTic.Color = Color.Yellow;
            yAxis3.MinorTic.IsOpposite = false;
            yAxis3.MinorTic.Color = Color.Yellow;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis3.Scale.Align = AlignP.Inside;
            yAxis3.Scale.Max = int.Parse(paraLine2.Max);
            yAxis3.Scale.Min = int.Parse(paraLine2.Min);


            // Create a third Y Axis, red
            YAxis yAxis5 = new YAxis(paraLine1.Tagname + "(" + paraLine1.Unit + ")");
            myPane.YAxisList.Add(yAxis5);
            yAxis5.Scale.FontSpec.FontColor = Color.Red;
            yAxis5.Scale.FontSpec.Size = 15;
            yAxis5.Title.FontSpec.FontColor = Color.Red;
            yAxis5.Title.FontSpec.Size = 15;
            yAxis5.Color = Color.Red;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis5.MajorTic.IsInside = false;
            yAxis5.MinorTic.IsInside = false;
            yAxis5.MajorTic.IsOpposite = false;
            yAxis5.MajorTic.Color = Color.Red;
            yAxis5.MinorTic.IsOpposite = false;
            yAxis5.MinorTic.Color = Color.Red;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis5.Scale.Align = AlignP.Inside;
            yAxis5.Scale.Max = int.Parse(paraLine1.Max);
            yAxis5.Scale.Min = int.Parse(paraLine1.Min);


            // Create a second Y2 Axis, green
            Y2Axis yAxis4 = new Y2Axis(paraLine5.Tagname + "(" + paraLine5.Unit + ")");
            yAxis4.IsVisible = true;
            myPane.Y2AxisList.Add(yAxis4);
            yAxis4.Scale.FontSpec.FontColor = Color.SeaGreen;
            yAxis4.Scale.FontSpec.Size = 15;
            yAxis4.Title.FontSpec.FontColor = Color.SeaGreen;
            yAxis4.Title.FontSpec.Size = 15;
            yAxis4.Color = Color.SeaGreen;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis4.MajorTic.IsInside = false;
            yAxis4.MinorTic.IsInside = false;
            yAxis4.MajorTic.IsOpposite = false;
            yAxis4.MajorTic.Color = Color.SeaGreen;
            yAxis4.MinorTic.IsOpposite = false;
            yAxis4.MinorTic.Color = Color.SeaGreen;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis4.Scale.Align = AlignP.Inside;
            yAxis4.Scale.Max = int.Parse(paraLine5.Max);
            yAxis4.Scale.Min = int.Parse(paraLine5.Min);

            // Create a third Y2 Axis, Skyblue
            Y2Axis yAxis6 = new Y2Axis(paraLine6.Tagname + "(" + paraLine6.Unit + ")");
            yAxis6.IsVisible = true;
            myPane.Y2AxisList.Add(yAxis6);
            yAxis6.Scale.FontSpec.FontColor = Color.SkyBlue;
            yAxis6.Scale.FontSpec.Size = 15;
            yAxis6.Title.FontSpec.FontColor = Color.SkyBlue;
            yAxis6.Title.FontSpec.Size = 15;
            yAxis6.Color = Color.SkyBlue;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis6.MajorTic.IsInside = false;
            yAxis6.MinorTic.IsInside = false;
            yAxis6.MajorTic.IsOpposite = false;
            yAxis6.MajorTic.Color = Color.SkyBlue;
            yAxis6.MinorTic.IsOpposite = false;
            yAxis6.MinorTic.Color = Color.SkyBlue;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis6.Scale.Align = AlignP.Inside;
            yAxis6.Scale.Max = int.Parse(paraLine6.Max);
            yAxis6.Scale.Min = int.Parse(paraLine6.Min);
            // Fill the axis background with a gradient
            //  myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);

            //新增，y轴不显示名称及零线
            foreach (YAxis y in myPane.YAxisList)
            {
                y.MajorGrid.IsZeroLine = false;
                y.Title.IsVisible = false;
            }
            foreach (Y2Axis y in myPane.Y2AxisList)
            {
                y.MajorGrid.IsZeroLine = false;
                y.Title.IsVisible = false;
            }
            //新增，读取配置文件的曲线颜色信息，更新曲线
            trend_refresh("1"); trend_refresh("2"); trend_refresh("3");
            trend_refresh("4"); trend_refresh("5"); trend_refresh("6");
            zedGraphControl1.AxisChange();



        }
        #endregion
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

        /// <summary>
        /// 更新井号信息
        /// </summary>
        public void wellinfo_refresh()
        {

            lbl_stage.Text = wellname + wellnum + "第" + stage_big + "段  " + "阶段:" + num_stage;
            if (lbl_stage2.InvokeRequired) { lbl_stage2.Invoke(new Action(() => { lbl_stage2.Text = "阶段: " + num_stage + "/" + num_totalstage; })); }
            else { lbl_stage2.Text = "阶段: " + num_stage + "/" + num_totalstage; }

            if (lbl_time.InvokeRequired) { lbl_time.Invoke(new Action(() => lbl_time.Text = string.Format("{0:T}", time))); }
            else { lbl_time.Text = string.Format("{0:T}", time); }
            lbl_stagetime.Text = string.Format("{0:T}", time_stage);
        }
        /// <summary>
        /// 曲线更新
        /// </summary>
        /// <param name="count">x轴坐标</param>
        /// <param name="refresh">是否刷新</param>
        private void timer_trend(double count, bool refresh)
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
            double factor = 60;
            int num1 = int.Parse(paraLine3.Tag.ToString());
            int num2 = int.Parse(paraLine4.Tag.ToString());
            int num3 = int.Parse(paraLine2.Tag.ToString());
            int num4 = int.Parse(paraLine5.Tag.ToString());
            int num5 = int.Parse(paraLine1.Tag.ToString());
            int num6 = int.Parse(paraLine6.Tag.ToString());

            //  factor = 1;//测试用
            //添加数据
            //list1.Add(count / factor, Form_Main.Paralist.Values.Last()[num1]);
            //list2.Add(count / factor, Form_Main.Paralist.Values.Last()[num2]);
            //list3.Add(count / factor, Form_Main.Paralist.Values.Last()[num3]);
            //list4.Add(count / factor, Form_Main.Paralist.Values.Last()[num4]);
            //list5.Add(count / factor, Form_Main.Paralist.Values.Last()[num5]);
            //list6.Add(count / factor, Form_Main.Paralist.Values.Last()[num6]);

            list1.Add(count / factor, Form_Main.Loglist.Values.ElementAt((int)count).DATA[num1]);
            list2.Add(count / factor, Form_Main.Loglist.Values.ElementAt((int)count).DATA[num2]);
            list3.Add(count / factor, Form_Main.Loglist.Values.ElementAt((int)count).DATA[num3]);
            list4.Add(count / factor, Form_Main.Loglist.Values.ElementAt((int)count).DATA[num4]);
            list5.Add(count / factor, Form_Main.Loglist.Values.ElementAt((int)count).DATA[num5]);
            list6.Add(count / factor, Form_Main.Loglist.Values.ElementAt((int)count).DATA[num6]);


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

            if (refresh)
            {
                //第三步:调用ZedGraphControl.AxisChange()方法更新X和Y轴的范围
                zedGraphControl1.AxisChange();

                //第四步:调用Form.Invalidate()方法更新图表
                zedGraphControl1.Invalidate();
            }
        }

        /// <summary>
        /// 读取混砂车原始数据到缓存数据中
        /// </summary>
        private void Blender_read()
        {

            //读取混砂车数据,阶段统计量上位机计算
            for (int i = 31; i <= 49; i++)
            {
                test[i] = Convert.ToDouble(value_blender.GetValue(i - 30));
            }
            
            test[50] = test[47] + test[48] + test[49]; //液添当前总流量
            test[51] = Convert.ToDouble(value_blender.GetValue(20));//干添1
            test[52] = Convert.ToDouble(value_blender.GetValue(21));//干添2
            test[53] = test[51] + test[52]; //干添当前总流量
            ////  井口排出阶段总量,来自beff尚未采集
            //test[55] = test[38] / 60 + test[55];            //吸入阶段总量
            //test[56] = test[39] / 60 + test[56];          //排出阶段总量
            //test[57] = (test[43] / 60 / 1000 + test[57]); //绞龙1阶段总量
            //test[58] = (test[44] / 60 / 1000 + test[58]); //绞龙2阶段总量
            //test[59] = (test[45] / 60 / 1000 + test[59]); //绞龙3阶段总量
            //test[60] = (test[46] / 60 / 1000 + test[60]);//输砂阶段总量
            //test[61] = (test[47] / 60 / 1000 + test[61]);//液添1阶段总量
            //test[62] = (test[48] / 60 / 1000 + test[62]);//液添2阶段总量
            //test[63] = (test[49] / 60 / 1000 + test[63]);//液添3阶段总量
            //test[64] = test[61] + test[62] + test[63];//液添阶段总量
            //test[65] = (test[51] / 60 + test[65]); //干添1阶段总量
            //test[66] = (test[52] / 60 + test[66]);//干添2阶段总量
            //test[67] = test[65] + test[66];//干添阶段总量
            for (int i = 55; i <= 63; i++)
            {
                test[i] = Convert.ToDouble(value_blender.GetValue(i - 30));
            }
            test[64] = test[61] + test[62] + test[63];//液添阶段总量
            test[65] = Convert.ToDouble(value_blender.GetValue(35));//干添1阶段总量
            test[66] = Convert.ToDouble(value_blender.GetValue(36));//干添2阶段总量
            test[67] = test[65] + test[66];//干添阶段总量
            ////井口排出总量,来自beff尚未采集
            for (int i = 69; i <= 77; i++)
            {
                test[i] = Convert.ToDouble(value_blender.GetValue(i - 30));
            }
            test[78] = test[75] + test[76] + test[77];
            test[79] = Convert.ToDouble(value_blender.GetValue(49)); //干添1总量
            test[80] = Convert.ToDouble(value_blender.GetValue(50));//干添2总量
            test[81] = test[79] + test[80];

        }

        /// <summary>
        /// 读取压力泵原始数据到缓存数据中
        /// </summary>
        /// <param name="index"></param>
        private void Frac_read()
        {    //外层循环8台泵
            for (int i = 1; i <= 8; i++)
            {
                //内层循环4个变量
                for (int j = 1; j <= 4; j++)
                {
                    if (j % 4 == 0)
                    {   //每台泵的第四个参数要错位
                        test[100 + (i - 1) * 5 + j + 1] = Convert.ToDouble(value_frac.GetValue((i - 1) * 4 + j));
                        //阶段统计量
                        test[100 + (i - 1) * 5 + j] = test[100 + (i - 1) * 5 + j - 1] / 60 + test[100 + (i - 1) * 5 + j];

                    }
                    else { test[100 + (i - 1) * 5 + j] = Convert.ToDouble(value_frac.GetValue((i - 1) * 4 + j)); }
                }

            }

        }
        #endregion

        #region 控件事件

        private void Form_Main_Load(object sender, EventArgs e)
        {

            Paralist = new Dictionary<string, Datamodel>();
            Loglist = new Dictionary<string, Datamodel>();

            xml_load();//读取偏好设置文件
            chart_initial();//初始化图表控件
            Kep_initial();//注册通讯变量

            //设置dgv的列头字体大小
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10);

            //测试用，在子线程中生成随机数填充paralist
            Thread th = new Thread(intialdata);
            th.IsBackground = true;
            th.Start();
            //启动自定义控件刷新定时器
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Parashow)
                {
                    Parashow ctr2 = ctrl as Parashow;
                    ctr2.timer1.Enabled = true;
                }
            }
            //启动混砂车状态信号定时器
            timer_color.Enabled = true;
            //主界面加载完成后，依次打开其他页面

            Frm_Realtrend frm1 = new Frm_Realtrend();
            frm1.Location = new Point(1920, 0);
            frm1.Show();

            Frm_Realtrend2 frm2 = new Frm_Realtrend2();
            frm2.Location = new Point(3840, 0);
            frm2.Show();

            Frm_Paradigital2 frm3 = new Frm_Paradigital2();
            frm3.Location = new Point(3840, 0);
            frm3.Show();

            Frm_Paraanalog2 frm4 = new Frm_Paraanalog2();
            frm4.Location = new Point(1920, 0);
            frm4.Show();

        }
        /// <summary>
        /// 追加模式下将数据填充到Paralist和Loglist
        /// </summary>
        /// <param name="list"></param>
        public void list_add(Dictionary<string, Datamodel> list)
        {

            //重新描绘曲线
            bool isrefresh = false; ;
            for (int i = 0; i < count; i++)
            {
                Loglist.Add(list.Keys.ElementAt(i), list.Values.ElementAt(i));
                if (i == count - 1) isrefresh = true;
                timer_trend((double)i, isrefresh);
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).timer_trend(i, isrefresh);
                ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).timer_trend(i, isrefresh);
                if (((Frm_add)Application.OpenForms["Frm_add"]).progressBar1.InvokeRequired)
                {
                    ((Frm_add)Application.OpenForms["Frm_add"]).progressBar1.Invoke(new Action(() => ((Frm_add)Application.OpenForms["Frm_add"]).progressBar1.Value = i));
                }
            }

            count++;

        }

        /// <summary>
        /// 开始记录，曲线开始刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_start_Click(object sender, EventArgs e)
        {
            //阶段号更新
            ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).lbl_stage.Text = Form_Main.num_stage.ToString();
            ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).lbl_stage.Text = Form_Main.num_stage.ToString();
            //发送阶段号到PLC
            //kep1.KepItems.Item(320).Write(Form_Main.num_stage);
            //计划表选取更新
            //if (dataGridView1.Rows.Count >= num_stage)
            //{
            //    dataGridView1.ClearSelection();
            //    dataGridView1.Rows[num_stage - 1].Selected = true;
            //    ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).dataGridView1.ClearSelection();
            //    ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).dataGridView1.Rows[num_stage - 1].Selected = true;
            //}
            if (!iscnndatabase) { MessageBox.Show("请新建一个施工文件或者追加施工，以便开始记录数据！"); return; }
            if (run) { timer_log.Enabled = false; run = false; btn_start.Text = "继续"; tssl_log.BackColor = Color.Red; }
            else if (!run) { timer_log.Enabled = true; run = true; btn_start.Text = "暂停"; tssl_log.BackColor = Color.Lime; }
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

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            pnl_setting.Visible = false;
        }

        private void 退出ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 视图1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Frm_Realtrend"].Location = new Point(0, 0);
            Application.OpenForms["Frm_Realtrend"].BringToFront();

        }

        private void 视图2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Frm_Realtrend2"].Location = new Point(0, 0);
            Application.OpenForms["Frm_Realtrend2"].BringToFront();
        }

        private void 视图3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Frm_Paradigital2"].Location = new Point(0, 0);
            Application.OpenForms["Frm_Paradigital2"].BringToFront();
        }

        private void 视图4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Frm_Paraanalog2"].Location = new Point(0, 0);
            Application.OpenForms["Frm_Paraanalog2"].BringToFront();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 2) { MessageBox.Show("请现导入计划表！"); return; }
            Frm_send frm = new Frm_send(dataGridView1);
            frm.ShowDialog();

        }

        private void btn_import_Click(object sender, EventArgs e)
        {


            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Excel(*.xlsx)|*.xlsx|Excel(*.xls)|*.xls";
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFile.Multiselect = false;
            if (openFile.ShowDialog() == DialogResult.Cancel) return;
            var filePath = openFile.FileName;
            string fileType = System.IO.Path.GetExtension(filePath);
            if (string.IsNullOrEmpty(fileType)) return;


            try
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    dt = excelHelper.ExcelToDataTable("MySheet", true);
                    //DataColumn cln1 = new DataColumn();
                    //DataColumn cln2 = new DataColumn();
                    //DataColumn cln3 = new DataColumn();
                    //dt.Columns.Add(cln1); dt.Columns.Add(cln2); dt.Columns.Add(cln3);
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = dt;
                    num_totalstage = dt.Rows.Count;
                    // ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).grid_refresh(dt);
                    //dataGridView1.Columns[10].HeaderText = "";
                    //dataGridView1.Columns[11].HeaderText = "";
                    //dataGridView1.Columns[12].HeaderText = "";
                    //dataGridView1.Columns[3].FillWeight = 150;
                    dataGridView1.DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font.FontFamily, 10);
                    dataGridView1.RowsDefaultCellStyle.Font = new Font(dataGridView1.RowsDefaultCellStyle.Font.FontFamily, 10);
                    foreach (DataGridViewColumn item in dataGridView1.Columns)
                    {
                        item.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    //绑定数据源到曲线
                    //Series s = chart1.Series[0];
                    //  s.Points.DataBind(dt.AsEnumerable(), "净液量(m3)", "砂浓度起始(kg/m3)", "");

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Paradigital2 frm = new Frm_Paradigital2();
            frm.Location = new Point(1921, 0);
            frm.Show();
        }

        private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Paraanalog2 frm = new Frm_Paraanalog2();
            frm.Location = new Point(0, 0);
            frm.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "图片保存默认类型(*.png)|*.png";
            s.ShowDialog();
            string name = s.FileName;
            if (s.FileName.ToString().Trim() != "")
            {
                GraphPane myPane = zedGraphControl1.GraphPane;
                myPane.Fill = new Fill(Color.White);
                // myPane.Chart.Fill = new Fill(Color.FromArgb(49, 49, 49));
                myPane.Chart.Fill = new Fill(Color.White);
                zedGraphControl1.GetImage().Save(name);
            }
        }

        /// <summary>
        /// 下一阶段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_next_Click(object sender, EventArgs e)
        {
            //阶段量清零
            for (int i = 54; i <= 67; i++)
            {
                test[i] = 0;
            }
            if (!iscnndatabase) return;
            num_stage++;
            time_stage = Convert.ToDateTime("00:00:00");
            //计划表选取更新
            if (dataGridView1.Rows.Count >= num_stage)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[num_stage - 1].Selected = true;

                ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).dataGridView1.ClearSelection();
                ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).dataGridView1.Rows[num_stage - 1].Selected = true;
            }
            //阶段号更新
            this.wellinfo_refresh();
            ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).lbl_stage.Text = Form_Main.num_stage + "/" + Form_Main.num_totalstage;
            ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).lbl_stage.Text = Form_Main.num_stage + "/" + Form_Main.num_totalstage;
            //发送下一阶段命令到PLC
            kep1.KepItems.Item(586).Write(true);

        }

        private void 新建施工ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (iscnndatabase) { MessageBox.Show("当前正在施工，请先关闭该施工！"); return; }
            Frm_craet frm = new Frm_craet();
            frm.ShowDialog();
        }

        private void 追加施工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (run) { MessageBox.Show("当前正在施工，请先关闭该施工！"); return; }
            Frm_add frm = new Frm_add();
            frm.ShowDialog();
        }

        private void 结束施工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!iscnndatabase) { MessageBox.Show("请先开始一个施工或者追加一个施工!"); return; }
            DialogResult result = MessageBox.Show("确定要结束当前施工吗!", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                run = false;
                //主界面显示参数恢复到默认值
                timer_log.Enabled = false;
                btn_start.Text = "开始";
                lbl_time.Text = "00:00:00";
                lbl_stagetime.Text = "00:00:00";
                time = Convert.ToDateTime("00:00:00");//运行时间
                time_stage = Convert.ToDateTime("00:00:00");//阶段时间
                num_stage = 1;//阶段号
                wellname = "##";//油田名
                wellnum = "##";//井队号
                stage_big = "##";//第几大段
                this.wellinfo_refresh();
                //混砂车计划信息清空
                Pub_func.grid_clear(this.dataGridView1);
                Pub_func.grid_clear(((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).dataGridView1);
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).wellinfo_refresh();
                ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).wellinfo_refresh();

                Form_Main.count = 0;
                foreach (LineItem line in ((Form_Main)Application.OpenForms["Form_Main"]).zedGraphControl1.GraphPane.CurveList)
                {
                    line.Clear();
                }
                foreach (LineItem line in ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).zedGraphControl1.GraphPane.CurveList)
                {
                    line.Clear();
                }
                foreach (LineItem line in ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).zedGraphControl1.GraphPane.CurveList)
                {
                    line.Clear();
                }
                Form_Main.Paralist.Clear(); Form_Main.Loglist.Clear();
                Form_Main.iscnndatabase = false;
                //刷新各个页面的曲线
                zedGraphControl1.GraphPane.XAxis.Scale.Min = 0; zedGraphControl1.GraphPane.XAxis.Scale.Max = 30;
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).zedGraphControl1.GraphPane.XAxis.Scale.Min = 0;
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).zedGraphControl1.GraphPane.XAxis.Scale.Max = 30;
                ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).zedGraphControl1.GraphPane.XAxis.Scale.Min = 0;
                ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).zedGraphControl1.GraphPane.XAxis.Scale.Max = 50;
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).zedGraphControl1.AxisChange();
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).zedGraphControl1.Invalidate();
                ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).zedGraphControl1.AxisChange();
                ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).zedGraphControl1.Invalidate();
            }
            else if (result == DialogResult.Cancel) { return; }
        }

        /// <summary>
        /// 阶段量清零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_zero_Click(object sender, EventArgs e)
        {
            Form_Main.kep1.KepItems.Item(623).Write(true);
            //上位机的统计量清零
            test[50] = 0;  //液添流量
            test[53] = 0;  //干添流量
            test[64] = 0;//液添阶段流量
            test[67] = 0;//干添阶段流量
            test[78] = 0;// 液添总量
            test[81] = 0;//干添总量 
            //压力泵阶段统计量清零
            for (int i = 0; i <= 7; i++)
            {
                test[104 + 5 * i] = 0;

            }

        }



        private void btn_blenderstop_Click(object sender, EventArgs e)
        {

            kep1.KepItems.Item(590).Write(false);

        }

        private void btn_blenderhold_Click(object sender, EventArgs e)
        {

            bool hold = Convert.ToBoolean(value_blender.GetValue(591));
            if (hold) { kep1.KepItems.Item(591).Write(false); }
            else { kep1.KepItems.Item(591).Write(true); }

        }

        private void btn_blendernext_Click(object sender, EventArgs e)
        {
            if (num_stage == num_totalstage) { return; }
            kep1.KepItems.Item(586).Write(true);
        }

        private void btn_jobstart_Click(object sender, EventArgs e)
        {

            kep1.KepItems.Item(590).Write(true);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = sender as RadioButton;
            //算的对应数组里的角标,index起始，index+1结束
            int index = rd.TabIndex * 2 + 1;
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            x.Add(0);
            y.Add(Convert.ToDouble(Form_Main.dt.Rows[0][index]));
            //x.Add( Convert.ToDouble(Form_Main.dt.Rows[0][2]));
            // y.Add(Convert.ToDouble(Form_Main.dt.Rows[0][3]));
            for (int i = 0; i <= Form_Main.dt.Rows.Count - 2; i++)
            {
                x.Add(Convert.ToDouble(Form_Main.dt.Rows[i][2]));
                y.Add(Convert.ToDouble(Form_Main.dt.Rows[i][index + 1]));
                x.Add(Convert.ToDouble(Form_Main.dt.Rows[i][2]));
                y.Add(Convert.ToDouble(Form_Main.dt.Rows[i + 1][index]));

            }
            x.Add(Convert.ToDouble(Form_Main.dt.Rows[Form_Main.dt.Rows.Count - 1][2]));
            y.Add(Convert.ToDouble(Form_Main.dt.Rows[Form_Main.dt.Rows.Count - 1][index + 1]));
            chart1.Series[0].Points.DataBindXY(x, y);
            switch (rd.TabIndex)
            {
                case 1: chart1.ChartAreas[0].AxisY.Title = "砂浓度(kg/m3)"; break;
                case 2: chart1.ChartAreas[0].AxisY.Title = "液添1(L/m3)"; break;
                case 3: chart1.ChartAreas[0].AxisY.Title = "液添2(L/m3)"; break;
                case 4: chart1.ChartAreas[0].AxisY.Title = "液添3(L/m3)"; break;
                case 5: chart1.ChartAreas[0].AxisY.Title = "砂浓度(kg/m3)"; break;
                case 6: chart1.ChartAreas[0].AxisY.Title = "砂浓度(kg/m3)"; break;

            }
        }

        private void btn_override_Click(object sender, EventArgs e)
        {
            Frm_override frm = new Frm_override();
            frm.ShowDialog();
        }

        private void btn_table_Click(object sender, EventArgs e)
        {
            btn_table.Image = imageList1.Images[0];
            btn_chart.Image = imageList1.Images[1];
            dataGridView1.Visible = true;
            panel_curve.Visible = false;
        }

        private void btn_chart_Click(object sender, EventArgs e)
        {
            btn_table.Image = imageList1.Images[1];
            btn_chart.Image = imageList1.Images[0];
            dataGridView1.Visible = false;
            panel_curve.Visible = true;
        }



        private void btn_export_Click(object sender, EventArgs e)
        {
            SaveFileDialog sflg = new SaveFileDialog();
            sflg.Filter = "Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";
            if (sflg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            //this.gridView1.ExportToXls(sflg.FileName);
            //NPOI.xs book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.IWorkbook book = null;
            if (sflg.FilterIndex == 1)
            {
                book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            }
            else
            {
                book = new NPOI.XSSF.UserModel.XSSFWorkbook();
            }

            NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("test_001");

            // 添加表头
            NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
            int index = 0;
            foreach (DataGridViewColumn item in this.dataGridView1.Columns)
            {
                if (item.Visible)
                {
                    NPOI.SS.UserModel.ICell cell = row.CreateCell(index);
                    cell.SetCellType(NPOI.SS.UserModel.CellType.STRING);
                    cell.SetCellValue(item.HeaderText);
                    index++;
                }
            }

            // 添加数据

            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                index = 0;
                row = sheet.CreateRow(i + 1);
                foreach (DataGridViewColumn item in this.dataGridView1.Columns)
                {
                    if (item.Visible)
                    {
                        NPOI.SS.UserModel.ICell cell = row.CreateCell(index);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.STRING);
                        cell.SetCellValue(dataGridView1.Rows[i].Cells[item.Index].Value.ToString());
                        index++;
                    }
                }
            }
            // 写入 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            book = null;

            using (FileStream fs = new FileStream(sflg.FileName, FileMode.Create, FileAccess.Write))
            {
                byte[] data = ms.ToArray();
                fs.Write(data, 0, data.Length);
                fs.Flush();
            }

            ms.Close();
            ms.Dispose();
        }

        private void timer_color_Tick(object sender, EventArgs e)
        {
            // 1208新增，修改混砂车控制按钮的状态显示
            try
            {
                if (readfinish)
                {

                    if ((bool)value_blender.GetValue(590)) { indicator_start.BackColor = Color.Lime; indicator_stop.BackColor = Color.FromArgb(49, 49, 49); }
                    else { indicator_start.BackColor = Color.FromArgb(49, 49, 49); indicator_stop.BackColor = Color.Red; }

                    if ((bool)value_blender.GetValue(591)) { indicator_hold.BackColor = Color.DodgerBlue; }
                    else { indicator_hold.BackColor = Color.FromArgb(49, 49, 49); }

                }
            }
            catch (Exception)
            {

                //   throw;
            }

        }
        #endregion

        private void btn_report_Click(object sender, EventArgs e)
        {
            SaveFileDialog sflg = new SaveFileDialog();
            sflg.Filter = "Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";
            if (sflg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            //从数据库获得当前井队信息
            DbManager db = new DbManager();
            db.ConnStr = "Data Source=localhost;" +
                            "Initial Catalog=ifracview;User Id=root;Password=hhdq;";
            string sql = "select *  from wellinfo where id=@wellinfoid";
            MySqlParameter par = new MySqlParameter("@wellinfoid", Form_Main.wellinfoID);
            DataTable tb = db.ExcuteDataTable(sql, par);
            DataRow tbinfo = tb.Rows[0];

            //建立空白工作簿
            IWorkbook workbook = new HSSFWorkbook();
            //在工作簿中：建立空白工作表
            ISheet sheet = workbook.CreateSheet();
            //在工作表中：建立行，参数为行号，从0计
            IRow row = sheet.CreateRow(0);
            //在行中：建立单元格，参数为列号，从0计
            ICell cell = row.CreateCell(0);
            //设置单元格内容
            cell.SetCellValue(wellname + wellnum + "井第" + stage_big + "段");
            ICellStyle style = workbook.CreateCellStyle();
            //设置单元格的样式：水平对齐居中
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            //新建一个字体样式对象
            IFont font = workbook.CreateFont();
            //设置字体加粗样式
            font.Boldweight = short.MaxValue;
            font.FontHeight = 22 * 20;
            //使用SetFont方法将字体样式添加到单元格样式中 
            style.SetFont(font);
            //将新的样式赋给单元格
            cell.CellStyle = style;

            //设置单元格的高度
            row.Height = 27 * 20;
            //设置单元格的宽度
            // sheet.SetColumnWidth(0, 15 * 256);
            //设置一个合并单元格区域，使用上下左右定义CellRangeAddress区域
            //CellRangeAddress四个参数为：起始行，结束行，起始列，结束列
            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 10));

            IRow row1 = sheet.CreateRow(1); ICell cell1 = row1.CreateCell(0);
            cell1.SetCellValue("油田名称：  " + tbinfo[1]);
            IRow row2 = sheet.CreateRow(2); ICell cell2 = row2.CreateCell(0);
            cell2.SetCellValue("井号：  " + tbinfo[2]);
            IRow row3 = sheet.CreateRow(3); ICell cell3 = row3.CreateCell(0);
            cell3.SetCellValue("施工日期：  " + tbinfo[4]);
            IRow row4 = sheet.CreateRow(4); ICell cell4 = row4.CreateCell(0);
            cell4.SetCellValue("客户名称：  " + tbinfo[5]);
            IRow row5 = sheet.CreateRow(5); ICell cell5 = row5.CreateCell(0);
            cell5.SetCellValue("客户代表：  " + tbinfo[6]);
            IRow row6 = sheet.CreateRow(6); ICell cell6 = row6.CreateCell(0);
            cell6.SetCellValue("施工单位：  " + tbinfo[7]);
            IRow row7 = sheet.CreateRow(7); ICell cell7 = row7.CreateCell(0);
            cell7.SetCellValue("施工代表：  " + tbinfo[8]);
            IRow row8 = sheet.CreateRow(8); ICell cell8 = row8.CreateCell(0);
            cell8.SetCellValue("施工指挥：  " + tbinfo[9]);
            IRow row9 = sheet.CreateRow(9); ICell cell9 = row9.CreateCell(0);
            cell9.SetCellValue("备注：  " + tbinfo[10]);
            //列标题
            IRow row10 = sheet.CreateRow(10); row10.Height = 27 * 20;
            ICell clname1 = row10.CreateCell(0); clname1.SetCellValue("阶段名");
            ICell clname2 = row10.CreateCell(1); clname2.SetCellValue("时间");
            ICell clname3 = row10.CreateCell(2); clname3.SetCellValue("油压(MPa)");
            ICell clname4 = row10.CreateCell(3); clname4.SetCellValue("套压(MPa)");
            ICell clname5 = row10.CreateCell(4); clname5.SetCellValue("排出排量(m3/min)");
            ICell clname6 = row10.CreateCell(5); clname6.SetCellValue("砂浓度(kg/m3)");
            ICell clname7 = row10.CreateCell(6); clname7.SetCellValue("总液量(m3)");
            ICell clname8 = row10.CreateCell(7); clname8.SetCellValue("总砂量(m3)");
            ICell clname9 = row10.CreateCell(8); clname9.SetCellValue("阶段液量(m3)");
            ICell clname10 = row10.CreateCell(9); clname10.SetCellValue("阶段砂量(m3)");
            //设置列宽
            for (int i = 0; i < 10; i++) sheet.SetColumnWidth(i, 20 * 256);

            //添加具体内容
            DbManager db2 = new DbManager();
            db.ConnStr = "Data Source=localhost;" +
                            "Initial Catalog=ifracviewdata;User Id=root;Password=hhdq;";
            string sql2 = "select *  from " + Form_Main.tbname;
            DataTable value = db.ExcuteDataTable(sql2);
            for (int i = 0; i < value.Rows.Count; i++)
            {
                string json = value.Rows[i]["value"].ToString();
                KeyValuePair<string, Datamodel> _data = JsonConvert.DeserializeObject<KeyValuePair<string, Datamodel>>(json);
                IRow rowtemp = sheet.CreateRow(12 + i);
                ICell celltemp0 = rowtemp.CreateCell(0); celltemp0.SetCellValue(value.Rows[i][1].ToString());
                ICell celltemp1 = rowtemp.CreateCell(1); celltemp1.SetCellValue(_data.Key);
                ICell celltemp2 = rowtemp.CreateCell(2); celltemp2.SetCellValue(_data.Value.DATA.GetValue(31).ToString());
                ICell celltemp3 = rowtemp.CreateCell(3); celltemp3.SetCellValue(_data.Value.DATA.GetValue(32).ToString());
                ICell celltemp4 = rowtemp.CreateCell(4); celltemp4.SetCellValue(_data.Value.DATA.GetValue(39).ToString());
                ICell celltemp5 = rowtemp.CreateCell(5); celltemp5.SetCellValue(_data.Value.DATA.GetValue(35).ToString());
                ICell celltemp6 = rowtemp.CreateCell(6); celltemp6.SetCellValue(_data.Value.DATA.GetValue(78).ToString());
                ICell celltemp7 = rowtemp.CreateCell(7); celltemp7.SetCellValue(_data.Value.DATA.GetValue(74).ToString());
                ICell celltemp8 = rowtemp.CreateCell(8); celltemp8.SetCellValue(_data.Value.DATA.GetValue(64).ToString());
                ICell celltemp9 = rowtemp.CreateCell(9); celltemp9.SetCellValue(_data.Value.DATA.GetValue(60).ToString());

            }



            using (FileStream fs = new FileStream(sflg.FileName, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            Frm_print frm=new Frm_print ();
            frm.Show();
        }



    }

}

