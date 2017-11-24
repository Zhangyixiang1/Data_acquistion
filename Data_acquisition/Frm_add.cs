using Data_acquisition.Comm;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
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
    public partial class Frm_add : Form
    {
        public Frm_add()
        {
            InitializeComponent();
        }

        private void Frm_add_Load(object sender, EventArgs e)
        {
            DbManager db = new DbManager();
            db.ConnStr = "Data Source=localhost;" +
                            "Initial Catalog=ifracview;User Id=root;Password=hhdq;";
            string sql = "select *  from wellinfo";
            DataTable tb = db.ExcuteDataTable(sql);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                listBox1.Items.Add(tb.Rows[i]["date"].ToString() + "---" + tb.Rows[i]["wellname"] + tb.Rows[i]["wellnum"] +
                "第" + tb.Rows[i]["wellstage"] + "段");
            }

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) MessageBox.Show("请选择需要追加施工的数据包！");
            else
            {
                string ori_tbname = listBox1.SelectedItem.ToString();
                string[] temp_tbanme = ori_tbname.Split('-');
                string tbname = temp_tbanme[0];
                DateTime dt = DateTime.Parse(tbname);
                tbname = "tb" + dt.ToString("u").Replace("-", "").Replace(":", "").Replace(" ", "");
                Form_Main.tbname = tbname;
                //以该表单名从数据库请求数据,将数据源以及井队信息传给主界面的paralist和loglist
                DbManager db = new DbManager();
                db.ConnStr = "Data Source=localhost;" +
                                 "Initial Catalog=ifracviewdata;User Id=root;Password=hhdq;";
                string sql = "select * from " + tbname;
                DataTable tb = db.ExcuteDataTable(sql);
           Dictionary<string ,Datamodel> data=new Dictionary<string,Datamodel> ();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    string json = tb.Rows[i]["value"].ToString();
                    KeyValuePair<string, Datamodel> _data = JsonConvert.DeserializeObject<KeyValuePair<string, Datamodel>>(json);
                    data.Add(_data.Key,_data.Value);
                }
                ((Form_Main)Application.OpenForms["Form_Main"]).list_add(data) ;
                //井队信息

            }
        }
    }
}
