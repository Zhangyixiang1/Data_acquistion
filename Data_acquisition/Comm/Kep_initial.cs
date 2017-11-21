using OPCAutomation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Data_acquisition.Comm
{ //Kepware相关类，初始化以及读取

    class Kep_initial
    {      //kepware相关变量
        static public OPCServer KepServer;
        static public OPCGroups KepGroups;
        static public OPCGroup KepGroup;
        static public OPCItems KepItems;
        static public OPCItem KepItem;
        static public int[] Item_serverhandle1_To_PC = new int[65536];
        static public int item_oder_To_PC = 1;
        static public int item_oder = 1;
        static public Array kepvalue;
        static public Array keperr;
        static public object kepqua;
        static public object kepstamp;
        static public bool kepconn;
        public void kep_initial()
        {
            try
            {
                KepServer = new OPCServer();
                ////连接opc server
                KepServer.Connect("KEPware.KEPServerEx.V4", "");
                //(2)建立一个opc组集合
                KepGroups = KepServer.OPCGroups;
                //(3)建立一个opc组
                KepGroup = KepGroups.Add(null); //Group组名字可有可无
                //(4)添加opc标签
                KepGroup.IsActive = true; //设置该组为活动状态，连接PLC时，设置为非活动状态也一样
                KepGroup.IsSubscribed = true; //设置异步通知
                KepGroup.UpdateRate = 250;
                KepServer.OPCGroups.DefaultGroupDeadband = 0;
                KepItems = KepGroup.OPCItems; //建立opc标签集合
                string path = System.Environment.CurrentDirectory;
                StreamReader sr = new StreamReader(path + @"\Kepware.txt");
                string content = sr.ReadToEnd();
                string[] str = content.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (object temp0 in str)
                {
                    string temp1 = temp0.ToString();
                    string temp = temp1.Replace("\t", "");
                    KepItems.AddItem("Channel1." + temp.ToString(), item_oder);
                    Item_serverhandle1_To_PC[item_oder_To_PC] = KepItems.Item(item_oder).ServerHandle;
                    item_oder_To_PC = item_oder_To_PC + 1;
                    item_oder = item_oder + 1;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public Array kep_read()
        {
            kepvalue = new Array[KepItems.Count];
            keperr = new Array[KepItems.Count];
            Array handle2 = (Array)Item_serverhandle1_To_PC;
            KepGroup.SyncRead(1, KepItems.Count, ref handle2, out kepvalue, out keperr, out kepqua, out kepstamp);
            return kepvalue;

        }
    }
}
