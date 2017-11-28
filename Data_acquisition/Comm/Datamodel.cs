using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_acquisition.Comm
{
    /// <summary>
    /// 数据模型
    /// </summary>
    public class Datamodel
    {  //阶段号
        public int NUM { get; set; }
        //数据流
        public double[] DATA { get; set; }
        public Datamodel(int num, double[] data)
        {
            this.NUM = num; this.DATA = data;

        }
        public Datamodel() { }
    }
}
