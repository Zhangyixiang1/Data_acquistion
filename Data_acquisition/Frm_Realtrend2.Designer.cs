namespace Data_acquisition
{
    partial class Frm_Realtrend2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Stage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LA1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LA2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LA3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LA4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DA1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cleanvol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SandType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paraLine1 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine6 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine5 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine4 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine3 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine2 = new Data_acquisition.Ctrl.ParaLine();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_wellinfo = new System.Windows.Forms.Label();
            this.lbl_wellnum = new System.Windows.Forms.Label();
            this.lbl_stagebig = new System.Windows.Forms.Label();
            this.lbl_stage = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 15F);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(0, 568);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1920, 500);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "计划";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 15F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stage,
            this.Sand,
            this.LA1,
            this.LA2,
            this.LA3,
            this.LA4,
            this.DA1,
            this.Cleanvol,
            this.SandType});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 15F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(20, 29);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 15F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1888, 455);
            this.dataGridView1.TabIndex = 18;
            // 
            // Stage
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.Stage.DefaultCellStyle = dataGridViewCellStyle2;
            this.Stage.HeaderText = "Stage";
            this.Stage.Name = "Stage";
            // 
            // Sand
            // 
            this.Sand.HeaderText = "Sand(PPA)";
            this.Sand.Name = "Sand";
            // 
            // LA1
            // 
            this.LA1.HeaderText = "LA1(gals/1000)";
            this.LA1.Name = "LA1";
            // 
            // LA2
            // 
            this.LA2.HeaderText = "LA2(gals/1000)";
            this.LA2.Name = "LA2";
            // 
            // LA3
            // 
            this.LA3.HeaderText = "LA3(gals/1000)";
            this.LA3.Name = "LA3";
            // 
            // LA4
            // 
            this.LA4.HeaderText = "LA4(gals/1000)";
            this.LA4.Name = "LA4";
            // 
            // DA1
            // 
            this.DA1.HeaderText = "DA1(lbs/1000)";
            this.DA1.Name = "DA1";
            // 
            // Cleanvol
            // 
            this.Cleanvol.HeaderText = "Clean Vol.(bbls)";
            this.Cleanvol.Name = "Cleanvol";
            // 
            // SandType
            // 
            this.SandType.HeaderText = "SandType";
            this.SandType.Name = "SandType";
            // 
            // paraLine1
            // 
            this.paraLine1.BackColor = System.Drawing.Color.Transparent;
            this.paraLine1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine1.Color = System.Drawing.Color.Red;
            this.paraLine1.Line_Enabled = true;
            this.paraLine1.Location = new System.Drawing.Point(970, 12);
            this.paraLine1.Max = null;
            this.paraLine1.Min = null;
            this.paraLine1.Name = "paraLine1";
            this.paraLine1.Size = new System.Drawing.Size(153, 52);
            this.paraLine1.TabIndex = 32;
            this.paraLine1.Tagname = null;
            this.paraLine1.Unit = null;
            // 
            // paraLine6
            // 
            this.paraLine6.BackColor = System.Drawing.Color.Transparent;
            this.paraLine6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine6.Color = System.Drawing.Color.SkyBlue;
            this.paraLine6.Line_Enabled = true;
            this.paraLine6.Location = new System.Drawing.Point(1765, 12);
            this.paraLine6.Max = "1000";
            this.paraLine6.Min = "0";
            this.paraLine6.Name = "paraLine6";
            this.paraLine6.Size = new System.Drawing.Size(153, 52);
            this.paraLine6.TabIndex = 27;
            this.paraLine6.Tagname = null;
            this.paraLine6.Unit = "Mpa";
            // 
            // paraLine5
            // 
            this.paraLine5.BackColor = System.Drawing.Color.Transparent;
            this.paraLine5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine5.Color = System.Drawing.Color.SeaGreen;
            this.paraLine5.Line_Enabled = true;
            this.paraLine5.Location = new System.Drawing.Point(1606, 12);
            this.paraLine5.Max = "1000";
            this.paraLine5.Min = "0";
            this.paraLine5.Name = "paraLine5";
            this.paraLine5.Size = new System.Drawing.Size(153, 52);
            this.paraLine5.TabIndex = 28;
            this.paraLine5.Tagname = null;
            this.paraLine5.Unit = "Mpa";
            // 
            // paraLine4
            // 
            this.paraLine4.BackColor = System.Drawing.Color.Transparent;
            this.paraLine4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine4.Color = System.Drawing.Color.Lime;
            this.paraLine4.Line_Enabled = false;
            this.paraLine4.Location = new System.Drawing.Point(1447, 12);
            this.paraLine4.Max = "1000";
            this.paraLine4.Min = "0";
            this.paraLine4.Name = "paraLine4";
            this.paraLine4.Size = new System.Drawing.Size(153, 52);
            this.paraLine4.TabIndex = 29;
            this.paraLine4.Tagname = null;
            this.paraLine4.Unit = "Mpa";
            // 
            // paraLine3
            // 
            this.paraLine3.BackColor = System.Drawing.Color.Transparent;
            this.paraLine3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine3.Color = System.Drawing.Color.Blue;
            this.paraLine3.Line_Enabled = true;
            this.paraLine3.Location = new System.Drawing.Point(1288, 12);
            this.paraLine3.Max = "1000";
            this.paraLine3.Min = "0";
            this.paraLine3.Name = "paraLine3";
            this.paraLine3.Size = new System.Drawing.Size(153, 52);
            this.paraLine3.TabIndex = 30;
            this.paraLine3.Tagname = null;
            this.paraLine3.Unit = "Mpa";
            // 
            // paraLine2
            // 
            this.paraLine2.BackColor = System.Drawing.Color.Transparent;
            this.paraLine2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine2.Color = System.Drawing.Color.Yellow;
            this.paraLine2.Line_Enabled = true;
            this.paraLine2.Location = new System.Drawing.Point(1129, 12);
            this.paraLine2.Max = "1000";
            this.paraLine2.Min = "0";
            this.paraLine2.Name = "paraLine2";
            this.paraLine2.Size = new System.Drawing.Size(153, 52);
            this.paraLine2.TabIndex = 31;
            this.paraLine2.Tagname = null;
            this.paraLine2.Unit = "Mpa";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 71);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1920, 492);
            this.zedGraphControl1.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(274, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "阶段:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(73, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "段:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(274, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "井号:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(52, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "油田:";
            // 
            // lbl_wellinfo
            // 
            this.lbl_wellinfo.AutoSize = true;
            this.lbl_wellinfo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_wellinfo.ForeColor = System.Drawing.Color.White;
            this.lbl_wellinfo.Location = new System.Drawing.Point(120, 12);
            this.lbl_wellinfo.Name = "lbl_wellinfo";
            this.lbl_wellinfo.Size = new System.Drawing.Size(51, 20);
            this.lbl_wellinfo.TabIndex = 40;
            this.lbl_wellinfo.Text = "南川";
            // 
            // lbl_wellnum
            // 
            this.lbl_wellnum.AutoSize = true;
            this.lbl_wellnum.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_wellnum.ForeColor = System.Drawing.Color.White;
            this.lbl_wellnum.Location = new System.Drawing.Point(353, 12);
            this.lbl_wellnum.Name = "lbl_wellnum";
            this.lbl_wellnum.Size = new System.Drawing.Size(42, 20);
            this.lbl_wellnum.TabIndex = 40;
            this.lbl_wellnum.Text = "194";
            // 
            // lbl_stagebig
            // 
            this.lbl_stagebig.AutoSize = true;
            this.lbl_stagebig.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_stagebig.ForeColor = System.Drawing.Color.White;
            this.lbl_stagebig.Location = new System.Drawing.Point(120, 44);
            this.lbl_stagebig.Name = "lbl_stagebig";
            this.lbl_stagebig.Size = new System.Drawing.Size(20, 20);
            this.lbl_stagebig.TabIndex = 40;
            this.lbl_stagebig.Text = "1";
            // 
            // lbl_stage
            // 
            this.lbl_stage.AutoSize = true;
            this.lbl_stage.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_stage.ForeColor = System.Drawing.Color.White;
            this.lbl_stage.Location = new System.Drawing.Point(353, 44);
            this.lbl_stage.Name = "lbl_stage";
            this.lbl_stage.Size = new System.Drawing.Size(20, 20);
            this.lbl_stage.TabIndex = 40;
            this.lbl_stage.Text = "1";
            // 
            // Frm_Realtrend2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_stage);
            this.Controls.Add(this.lbl_wellnum);
            this.Controls.Add(this.lbl_stagebig);
            this.Controls.Add(this.lbl_wellinfo);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.paraLine1);
            this.Controls.Add(this.paraLine6);
            this.Controls.Add(this.paraLine5);
            this.Controls.Add(this.paraLine4);
            this.Controls.Add(this.paraLine3);
            this.Controls.Add(this.paraLine2);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Realtrend2";
            this.Text = "Frm_Histrend";
            this.Load += new System.EventHandler(this.Frm_Realtrend2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Realtrend2_KeyDown);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sand;
        private System.Windows.Forms.DataGridViewTextBoxColumn LA1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LA2;
        private System.Windows.Forms.DataGridViewTextBoxColumn LA3;
        private System.Windows.Forms.DataGridViewTextBoxColumn LA4;
        private System.Windows.Forms.DataGridViewTextBoxColumn DA1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cleanvol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SandType;
        private Ctrl.ParaLine paraLine1;
        private Ctrl.ParaLine paraLine6;
        private Ctrl.ParaLine paraLine5;
        private Ctrl.ParaLine paraLine4;
        private Ctrl.ParaLine paraLine3;
        private Ctrl.ParaLine paraLine2;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_wellinfo;
        private System.Windows.Forms.Label lbl_wellnum;
        private System.Windows.Forms.Label lbl_stagebig;
        private System.Windows.Forms.Label lbl_stage;

    }
}