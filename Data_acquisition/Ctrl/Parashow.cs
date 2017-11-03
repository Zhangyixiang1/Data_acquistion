﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Data_acquisition.Ctrl
{
    public partial class Parashow : UserControl
    {

        float X, Y;
        private int min, max;
        public Parashow()
        {
            InitializeComponent();
            X = this.Width;
            Y = this.Height;
            setTag(this);
        }
        private void setTag(Control ctrs)
        {
            foreach (Control ctr in ctrs.Controls)
            {
                ctr.Tag = ctr.Width + ":" + ctr.Height + ":" + ctr.Left + ":" + ctr.Top + ":" + ctr.Font.Size;
                if (ctr.Controls.Count > 0) setTag(ctr);   //递归算法
            }

        }
        private void setControls(float newx, float newy, Control ctrs)
        {
            foreach (Control ctr in ctrs.Controls)
            {
                if (ctr.Tag == null) continue;
                string[] mytag = ctr.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newx;
                ctr.Width = (int)a;

                a = Convert.ToSingle(mytag[1]) * newy;
                ctr.Height = (int)a;

                a = Convert.ToSingle(mytag[2]) * newx;
                ctr.Left = (int)a;

                a = Convert.ToSingle(mytag[3]) * newy;
                ctr.Top = (int)a;

                Single currentSize = Convert.ToSingle(mytag[4]) * newy;
                ctr.Font = new Font(ctr.Font.Name, currentSize, ctr.Font.Style, ctr.Font.Unit);

                if (ctr.Controls.Count > 0) setControls(newx, newy, ctr);
            }



        }

        private void Parashow_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X;
            float newy = (this.Height) / Y;
            setControls(newx, newy, this);
        }
    }
}
