﻿namespace Data_acquisition.Ctrl
{
    partial class Parashow2
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.radPanel1.ForeColor = System.Drawing.Color.White;
            this.radPanel1.Location = new System.Drawing.Point(0, 27);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(170, 33);
            this.radPanel1.TabIndex = 0;
            this.radPanel1.Text = "######";
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadPanelElement)(this.radPanel1.GetChildAt(0))).Text = "######";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Blue;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Blue;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Blue;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Blue;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(110, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mpa";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "油压";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Parashow2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radPanel1);
            this.Name = "Parashow2";
            this.Size = new System.Drawing.Size(170, 60);
            this.Load += new System.EventHandler(this.Parashow2_Load);
            this.Resize += new System.EventHandler(this.Parashow2_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Timer timer1;
    }
}
