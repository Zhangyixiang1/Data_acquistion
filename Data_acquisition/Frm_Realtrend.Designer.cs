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
            this.parashow6 = new Data_acquisition.Ctrl.Parashow();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // parashow6
            // 
            this.parashow6.BackColor = System.Drawing.Color.Transparent;
            this.parashow6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parashow6.Color = System.Drawing.SystemColors.ControlText;
            this.parashow6.Location = new System.Drawing.Point(2325, 240);
            this.parashow6.Name = "parashow6";
            this.parashow6.Size = new System.Drawing.Size(307, 108);
            this.parashow6.TabIndex = 4;
            this.parashow6.Tagname = null;
            this.parashow6.Unit = null;
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Frm_Realtrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.parashow6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Realtrend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Frm_Trend";
            this.Load += new System.EventHandler(this.Frm_Realtrend_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Realtrend_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Ctrl.Parashow parashow6;
        private System.Windows.Forms.Timer timer1;
    }
}