using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_acquisition.Comm
{
    public class Datamodel
    {
        public string NUM { get; set; } 
        public double[] DATA { get; set; } 
        public Datamodel(string num, double[] data)
        {
            this.NUM = num; this.DATA = data;

        }
        public Datamodel(){}
    }
}
