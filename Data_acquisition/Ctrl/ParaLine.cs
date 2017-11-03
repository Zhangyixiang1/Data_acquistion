using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Data_acquisition.Ctrl
{
    public partial class ParaLine : UserControl
    {
        public ParaLine()
        {
            InitializeComponent();
        }
        public Color Color
        {
            get { return lineShape1.BorderColor; }
            set { this.lineShape1.BorderColor = value; }
        }
    }

}
