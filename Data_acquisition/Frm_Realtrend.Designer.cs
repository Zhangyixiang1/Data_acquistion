namespace Data_acquisition
{
    partial class Frm_Realtrend
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.parashow1 = new Data_acquisition.Ctrl.Parashow();
            this.parashow2 = new Data_acquisition.Ctrl.Parashow();
            this.parashow3 = new Data_acquisition.Ctrl.Parashow();
            this.parashow4 = new Data_acquisition.Ctrl.Parashow();
            this.parashow5 = new Data_acquisition.Ctrl.Parashow();
            this.parashow6 = new Data_acquisition.Ctrl.Parashow();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // parashow1
            // 
            this.parashow1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.parashow1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow1.Color = System.Drawing.SystemColors.ControlText;
            this.parashow1.Location = new System.Drawing.Point(1, 1);
            this.parashow1.Name = "parashow1";
            this.parashow1.Size = new System.Drawing.Size(318, 128);
            this.parashow1.TabIndex = 1;
            // 
            // parashow2
            // 
            this.parashow2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.parashow2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow2.Color = System.Drawing.SystemColors.ControlText;
            this.parashow2.Location = new System.Drawing.Point(320, 1);
            this.parashow2.Name = "parashow2";
            this.parashow2.Size = new System.Drawing.Size(318, 128);
            this.parashow2.TabIndex = 1;
            // 
            // parashow3
            // 
            this.parashow3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.parashow3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow3.Color = System.Drawing.SystemColors.ControlText;
            this.parashow3.Location = new System.Drawing.Point(639, 1);
            this.parashow3.Name = "parashow3";
            this.parashow3.Size = new System.Drawing.Size(318, 128);
            this.parashow3.TabIndex = 1;
            // 
            // parashow4
            // 
            this.parashow4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.parashow4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow4.Color = System.Drawing.SystemColors.ControlText;
            this.parashow4.Location = new System.Drawing.Point(958, 1);
            this.parashow4.Name = "parashow4";
            this.parashow4.Size = new System.Drawing.Size(318, 128);
            this.parashow4.TabIndex = 1;
            // 
            // parashow5
            // 
            this.parashow5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.parashow5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow5.Color = System.Drawing.SystemColors.ControlText;
            this.parashow5.Location = new System.Drawing.Point(1277, 1);
            this.parashow5.Name = "parashow5";
            this.parashow5.Size = new System.Drawing.Size(318, 128);
            this.parashow5.TabIndex = 1;
            // 
            // parashow6
            // 
            this.parashow6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.parashow6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow6.Color = System.Drawing.SystemColors.ControlText;
            this.parashow6.Location = new System.Drawing.Point(1596, 1);
            this.parashow6.Name = "parashow6";
            this.parashow6.Size = new System.Drawing.Size(318, 128);
            this.parashow6.TabIndex = 1;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 135);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1920, 943);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // Frm_Realtrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.parashow6);
            this.Controls.Add(this.parashow5);
            this.Controls.Add(this.parashow4);
            this.Controls.Add(this.parashow3);
            this.Controls.Add(this.parashow2);
            this.Controls.Add(this.parashow1);
            this.Controls.Add(this.zedGraphControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Realtrend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Frm_Trend";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Realtrend_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Ctrl.Parashow parashow1;
        private Ctrl.Parashow parashow2;
        private Ctrl.Parashow parashow3;
        private Ctrl.Parashow parashow4;
        private Ctrl.Parashow parashow5;
        private Ctrl.Parashow parashow6;
        private ZedGraph.ZedGraphControl zedGraphControl1;
    }
}