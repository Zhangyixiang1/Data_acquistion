using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Data_acquisition.Ctrl;
namespace Data_acquisition
{
    public partial class Para_choose : Form
    {
        public ParaLine ctr_line;
        public Parashow ctr_show;
        Button btn_s;
        public Para_choose(ParaLine ctr)
        {
            this.ctr_line = ctr;
            InitializeComponent();
        }
        public Para_choose(Parashow ctr)
        {
            this.ctr_show = ctr;
            InitializeComponent();
        }
        private void Para_choose_Load(object sender, EventArgs e)
        {

            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.WorkerSupportsCancellation = true;    //声明是否支持取消线程
            backgroundWorker1.RunWorkerAsync(); //开始
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int x = 6, y = 6;
            //从配置文件中读取通道标签
            string path = Application.StartupPath + "\\Config\\" + "test.xml";
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNodeList list = xml.GetElementsByTagName("item");
            for (int i = 0; i < list.Count; ++i)
            {
                XmlNode node = list.Item(i);
                string Index = node.Attributes["序号"].Value;
                string Name = node.Attributes["中文名称"].Value;
                string Unit_en = node.Attributes["英制单位"].Value;
                string Unit_me = node.Attributes["公制单位"].Value;
                string max = node.Attributes["最大值"].Value;
                string min = node.Attributes["最小值"].Value;
                Button btn = new Button();
                btn.Tag = Index + "," + Unit_en + "," + Unit_me + "," + max + "," + min;
                btn.Text = Name;
                btn.Size = new Size(120, 23);
                btn.Location = new Point(x + 131 * (i % 4), y + 29 * (i / 4));
                btn.Click += btnClick;
                this.tabPage2.Controls.Add(btn);
            }

        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.CancelAsync();

        }
        private void btnClick(object sender, EventArgs e)
        {
            if (btn_s != null) btn_s.BackColor = Color.Transparent;
            btn_s = sender as Button;
            ((Button)sender).BackColor = Color.Gray;
            string[] message = btn_s.Tag.ToString().Split(',');
            txb_max.Text = message[3]; txb_min.Text = message[4];
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string[] message = btn_s.Tag.ToString().Split(',');
            if (btn_s != null)
            {
                if (ctr_line != null)
                {
                    ctr_line.Tagname = btn_s.Text;
                    ctr_line.Tag = message[0];
                    ctr_line.Unit = message[2];
                    ctr_line.Max = txb_max.Text;
                    ctr_line.Min = txb_min.Text;
                    //保存修改到偏好配置文件
                    //保存修改到偏好设置
                    string path = Application.StartupPath + "\\Config\\preference.xml";
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    XmlNode root = doc.DocumentElement;
                    XmlNodeList nodeList = root.SelectNodes("Form[Name='Form_Main']//Controlsline//Control");


                    foreach (XmlNode node in nodeList)
                    {
                        if (ctr_line.Name == node.SelectSingleNode("@name").InnerText)
                        {
                            node.SelectSingleNode("@tagname").InnerText = ctr_line.Tagname;
                            node.SelectSingleNode("@min").InnerText = ctr_line.Min;
                            node.SelectSingleNode("@max").InnerText = ctr_line.Max;
                            node.SelectSingleNode("@unit").InnerText = ctr_line.Unit;

                        }

                    }
                    doc.Save(path);


                    ctr_line.refresh();
                    ((Form_Main)Application.OpenForms["Form_Main"]).trend_refresh(ctr_line.Name);
                }
                if (ctr_show != null)
                {
                    ctr_show.Tagname = btn_s.Text;
                    ctr_show.Tag = message[0];
                    ctr_show.Unit = message[2];
                 
                    //保存修改到偏好配置文件
                    //保存修改到偏好设置
                    string path = Application.StartupPath + "\\Config\\preference.xml";
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    XmlNode root = doc.DocumentElement;
                    XmlNodeList nodeList = root.SelectNodes("Form[Name='Form_Main']//Controlsshow//Control");


                    foreach (XmlNode node in nodeList)
                    {
                        if (ctr_show.Name == node.SelectSingleNode("@name").InnerText)
                        {
                            node.SelectSingleNode("@tagname").InnerText = ctr_show.Tagname;
                       
                            node.SelectSingleNode("@unit").InnerText = ctr_show.Unit;

                        }

                    }
                    doc.Save(path);


                    ctr_show.refresh();
                }
            }
            //保存修改的量程到配置文件
     
            string path2 = Application.StartupPath + "\\Config\\" + "test.xml";
            XmlDocument xml = new XmlDocument();
            xml.Load(path2);
            XmlNodeList list = xml.GetElementsByTagName("item");
            for (int i = 0; i < list.Count; ++i)
            {
                XmlNode node = list.Item(i);
                if (node.Attributes["序号"].Value == message[0])
                {

                    node.Attributes["最大值"].Value = txb_max.Text;
                    node.Attributes["最小值"].Value = txb_min.Text;
                }

            }
            xml.Save(path2);
            



            this.Close();
        }
    }
}
