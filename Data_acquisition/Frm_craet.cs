using MySql.Data.MySqlClient;
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
    public partial class Frm_craet : Form
    {
        public Frm_craet()
        {
            InitializeComponent();

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                DbManager db = new DbManager();
                db.ConnStr = "Data Source=localhost;" +
                           "Initial Catalog=ifracview;User Id=root;Password=hhdq;";
                //验证输入框是否为空,若为空用null填充,
                string sql = "insert into wellinfo values(0,@txt_wellname,@txt_wellnum,@txt_stage,@datetime,@txt_clientname," +
                "@txt_representname,@txt_constructionname,@txt_cstrepname,@txt_leadername,@txt_comment)";
                List<MySqlParameter> Paramter = new List<MySqlParameter>();
                if (string.IsNullOrEmpty(txt_wellname.Text)) Paramter.Add(new MySqlParameter("@txt_wellname", DBNull.Value));
                else Paramter.Add(new MySqlParameter("@txt_wellname", txt_wellname.Text));
                if (string.IsNullOrEmpty(txt_wellnum.Text)) Paramter.Add(new MySqlParameter("@txt_wellnum", DBNull.Value));
                else Paramter.Add(new MySqlParameter("@txt_wellnum", txt_wellnum.Text));
                if (string.IsNullOrEmpty(txt_stage.Text)) Paramter.Add(new MySqlParameter("@txt_stage", DBNull.Value));
                else Paramter.Add(new MySqlParameter("@txt_stage", txt_stage.Text));
                Paramter.Add(new MySqlParameter("@datetime", dateTimePicker1.Value.ToString()));
                if (string.IsNullOrEmpty(txt_wellnum.Text)) Paramter.Add(new MySqlParameter("@txt_clientname", DBNull.Value));
                else Paramter.Add(new MySqlParameter("@txt_clientname", txt_clientname.Text));
                if (string.IsNullOrEmpty(txt_wellnum.Text)) Paramter.Add(new MySqlParameter("@txt_representname", DBNull.Value));
                else Paramter.Add(new MySqlParameter("@txt_representname", txt_representname.Text));
                if (string.IsNullOrEmpty(txt_wellnum.Text)) Paramter.Add(new MySqlParameter("@txt_constructionname", DBNull.Value));
                else Paramter.Add(new MySqlParameter("@txt_constructionname", txt_constructionname.Text));
                if (string.IsNullOrEmpty(txt_wellnum.Text)) Paramter.Add(new MySqlParameter("@txt_cstrepname", DBNull.Value));
                else Paramter.Add(new MySqlParameter("@txt_cstrepname", txt_cstrepname.Text));
                if (string.IsNullOrEmpty(txt_wellnum.Text)) Paramter.Add(new MySqlParameter("@txt_leadername", DBNull.Value));
                else Paramter.Add(new MySqlParameter("@txt_leadername", txt_leadername.Text));
                if (string.IsNullOrEmpty(txt_wellnum.Text)) Paramter.Add(new MySqlParameter("@txt_comment", DBNull.Value));
                else Paramter.Add(new MySqlParameter("@txt_comment", txt_comment.Text));
                db.ExecuteNonquery(sql, Paramter.ToArray());
                DialogResult result = MessageBox.Show("创建施工成功！");
                if (result == DialogResult.OK)
                {  
                    //在数据库生成一个以时间为名的表单用以存储实时数据
                    DbManager db1 = new DbManager();
                    db1.ConnStr = "Data Source=localhost;" +
                               "Initial Catalog=ifracviewdata;User Id=root;Password=hhdq;";
                    string tbname = dateTimePicker1.Value.ToString();
                    MySqlParameter par = new MySqlParameter("@title", MySqlDbType.VarChar);
                    string tb_name = "tb" + dateTimePicker1.Value.ToString("u").Replace("-", "").Replace(":", "").Replace(" ", "");
                    par.Value = tb_name;
                    db1.ExecuteProcNonQuery("creatdb", par);
                    //创建成功后，将值传给主界面并刷新显示井队信息信息
                    Form_Main.iscnndatabase = true;
                    Form_Main.tbname = tb_name;
                    Form_Main.wellname=txt_wellname.Text;
                    Form_Main.wellnum=txt_wellnum.Text;
                    Form_Main.stage_big=txt_stage.Text;
                    ((Form_Main)Application.OpenForms["Form_Main"]).wellinfo_refresh();
                    ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).wellinfo_refresh();
                    ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).wellinfo_refresh();
                    this.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }


    }
}
