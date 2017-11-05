namespace Data_acquisition
{
    partial class Frm_Paraanalog
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
            this.gauge8 = new Data_acquisition.Ctrl.Gauge();
            this.gauge7 = new Data_acquisition.Ctrl.Gauge();
            this.gauge6 = new Data_acquisition.Ctrl.Gauge();
            this.gauge5 = new Data_acquisition.Ctrl.Gauge();
            this.gauge_big3 = new Data_acquisition.Ctrl.Gauge_big();
            this.gauge_big2 = new Data_acquisition.Ctrl.Gauge_big();
            this.gauge_big4 = new Data_acquisition.Ctrl.Gauge_big();
            this.gauge_big1 = new Data_acquisition.Ctrl.Gauge_big();
            this.gauge4 = new Data_acquisition.Ctrl.Gauge();
            this.gauge3 = new Data_acquisition.Ctrl.Gauge();
            this.gauge2 = new Data_acquisition.Ctrl.Gauge();
            this.gauge1 = new Data_acquisition.Ctrl.Gauge();
            this.SuspendLayout();
            // 
            // gauge8
            // 
            this.gauge8.Location = new System.Drawing.Point(1601, 810);
            this.gauge8.Name = "gauge8";
            this.gauge8.Size = new System.Drawing.Size(320, 270);
            this.gauge8.TabIndex = 3;
            // 
            // gauge7
            // 
            this.gauge7.Location = new System.Drawing.Point(1601, 540);
            this.gauge7.Name = "gauge7";
            this.gauge7.Size = new System.Drawing.Size(320, 270);
            this.gauge7.TabIndex = 3;
            // 
            // gauge6
            // 
            this.gauge6.Location = new System.Drawing.Point(1601, 270);
            this.gauge6.Name = "gauge6";
            this.gauge6.Size = new System.Drawing.Size(320, 270);
            this.gauge6.TabIndex = 3;
            // 
            // gauge5
            // 
            this.gauge5.Location = new System.Drawing.Point(1601, 0);
            this.gauge5.Name = "gauge5";
            this.gauge5.Size = new System.Drawing.Size(320, 270);
            this.gauge5.TabIndex = 3;
            // 
            // gauge_big3
            // 
            this.gauge_big3.Location = new System.Drawing.Point(962, 540);
            this.gauge_big3.Name = "gauge_big3";
            this.gauge_big3.Size = new System.Drawing.Size(640, 540);
            this.gauge_big3.TabIndex = 2;
            // 
            // gauge_big2
            // 
            this.gauge_big2.Location = new System.Drawing.Point(321, 540);
            this.gauge_big2.Name = "gauge_big2";
            this.gauge_big2.Size = new System.Drawing.Size(640, 540);
            this.gauge_big2.TabIndex = 2;
            // 
            // gauge_big4
            // 
            this.gauge_big4.Location = new System.Drawing.Point(962, 0);
            this.gauge_big4.Name = "gauge_big4";
            this.gauge_big4.Size = new System.Drawing.Size(640, 540);
            this.gauge_big4.TabIndex = 2;
            // 
            // gauge_big1
            // 
            this.gauge_big1.Location = new System.Drawing.Point(321, 0);
            this.gauge_big1.Name = "gauge_big1";
            this.gauge_big1.Size = new System.Drawing.Size(640, 540);
            this.gauge_big1.TabIndex = 2;
            // 
            // gauge4
            // 
            this.gauge4.Location = new System.Drawing.Point(0, 810);
            this.gauge4.Name = "gauge4";
            this.gauge4.Size = new System.Drawing.Size(320, 270);
            this.gauge4.TabIndex = 1;
            // 
            // gauge3
            // 
            this.gauge3.Location = new System.Drawing.Point(0, 540);
            this.gauge3.Name = "gauge3";
            this.gauge3.Size = new System.Drawing.Size(320, 270);
            this.gauge3.TabIndex = 1;
            // 
            // gauge2
            // 
            this.gauge2.Location = new System.Drawing.Point(1, 270);
            this.gauge2.Name = "gauge2";
            this.gauge2.Size = new System.Drawing.Size(320, 270);
            this.gauge2.TabIndex = 1;
            // 
            // gauge1
            // 
            this.gauge1.Location = new System.Drawing.Point(0, 0);
            this.gauge1.Name = "gauge1";
            this.gauge1.Size = new System.Drawing.Size(320, 270);
            this.gauge1.TabIndex = 1;
            // 
            // Frm_Paraanalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.gauge8);
            this.Controls.Add(this.gauge7);
            this.Controls.Add(this.gauge6);
            this.Controls.Add(this.gauge5);
            this.Controls.Add(this.gauge_big3);
            this.Controls.Add(this.gauge_big2);
            this.Controls.Add(this.gauge_big4);
            this.Controls.Add(this.gauge_big1);
            this.Controls.Add(this.gauge4);
            this.Controls.Add(this.gauge3);
            this.Controls.Add(this.gauge2);
            this.Controls.Add(this.gauge1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Paraanalog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Frm_Paraanalog";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Paraanalog_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Ctrl.Gauge gauge1;
        private Ctrl.Gauge gauge2;
        private Ctrl.Gauge gauge3;
        private Ctrl.Gauge gauge4;
        private Ctrl.Gauge_big gauge_big1;
        private Ctrl.Gauge_big gauge_big2;
        private Ctrl.Gauge_big gauge_big3;
        private Ctrl.Gauge_big gauge_big4;
        private Ctrl.Gauge gauge5;
        private Ctrl.Gauge gauge6;
        private Ctrl.Gauge gauge7;
        private Ctrl.Gauge gauge8;


    }
}