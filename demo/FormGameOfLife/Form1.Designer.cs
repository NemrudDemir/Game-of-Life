namespace FormGameOfLife
{
    partial class Form1
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
            if (disposing && (components != null)) {
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
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdNewGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAliveRule = new System.Windows.Forms.TextBox();
            this.numFieldsize = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblGeneration = new System.Windows.Forms.Label();
            this.lblAliveCells = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trcAutoSpeed = new System.Windows.Forms.TrackBar();
            this.cmdStop = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdStart = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.lblWarning = new System.Windows.Forms.Label();
            this.imgGame = new System.Windows.Forms.PictureBox();
            this.txtDeadRule = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFieldsize)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trcAutoSpeed)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgGame)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(12, 415);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 35);
            this.label7.TabIndex = 8;
            this.label7.Text = "Cells alive:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(12, 450);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 35);
            this.label6.TabIndex = 6;
            this.label6.Text = "Generation:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(840, 23);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(412, 771);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Size = new System.Drawing.Size(396, 724);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtDeadRule);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmdNewGame);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtAliveRule);
            this.groupBox2.Controls.Add(this.numFieldsize);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Size = new System.Drawing.Size(372, 196);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Game Options";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 35);
            this.label3.TabIndex = 19;
            this.label3.Text = "Fieldsize:";
            // 
            // cmdNewGame
            // 
            this.cmdNewGame.Location = new System.Drawing.Point(18, 137);
            this.cmdNewGame.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmdNewGame.Name = "cmdNewGame";
            this.cmdNewGame.Size = new System.Drawing.Size(222, 44);
            this.cmdNewGame.TabIndex = 18;
            this.cmdNewGame.Text = "Apply and reset";
            this.cmdNewGame.UseVisualStyleBackColor = true;
            this.cmdNewGame.Click += new System.EventHandler(this.cmdNewGame_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 33);
            this.label1.TabIndex = 10;
            this.label1.Text = "Rule:";
            // 
            // txtAliveRule
            // 
            this.txtAliveRule.Location = new System.Drawing.Point(132, 37);
            this.txtAliveRule.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtAliveRule.Name = "txtAliveRule";
            this.txtAliveRule.Size = new System.Drawing.Size(43, 31);
            this.txtAliveRule.TabIndex = 9;
            this.txtAliveRule.Text = "23";
            // 
            // numFieldsize
            // 
            this.numFieldsize.Location = new System.Drawing.Point(132, 87);
            this.numFieldsize.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.numFieldsize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numFieldsize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFieldsize.Name = "numFieldsize";
            this.numFieldsize.Size = new System.Drawing.Size(108, 31);
            this.numFieldsize.TabIndex = 20;
            this.numFieldsize.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblGeneration);
            this.groupBox1.Controls.Add(this.lblAliveCells);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.trcAutoSpeed);
            this.groupBox1.Controls.Add(this.cmdStop);
            this.groupBox1.Controls.Add(this.cmdNext);
            this.groupBox1.Controls.Add(this.cmdStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 219);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(372, 490);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game";
            // 
            // lblGeneration
            // 
            this.lblGeneration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGeneration.Location = new System.Drawing.Point(154, 450);
            this.lblGeneration.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblGeneration.Name = "lblGeneration";
            this.lblGeneration.Size = new System.Drawing.Size(206, 35);
            this.lblGeneration.TabIndex = 17;
            this.lblGeneration.Text = "0";
            // 
            // lblAliveCells
            // 
            this.lblAliveCells.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAliveCells.Location = new System.Drawing.Point(154, 415);
            this.lblAliveCells.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAliveCells.Name = "lblAliveCells";
            this.lblAliveCells.Size = new System.Drawing.Size(206, 35);
            this.lblAliveCells.TabIndex = 18;
            this.lblAliveCells.Text = "0";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 35);
            this.label2.TabIndex = 16;
            this.label2.Text = "Auto-Speed:";
            // 
            // trcAutoSpeed
            // 
            this.trcAutoSpeed.AutoSize = false;
            this.trcAutoSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.trcAutoSpeed.Location = new System.Drawing.Point(132, 92);
            this.trcAutoSpeed.Margin = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.trcAutoSpeed.Name = "trcAutoSpeed";
            this.trcAutoSpeed.Size = new System.Drawing.Size(228, 44);
            this.trcAutoSpeed.TabIndex = 15;
            this.trcAutoSpeed.Value = 10;
            this.trcAutoSpeed.ValueChanged += new System.EventHandler(this.trcAutoSpeed_ValueChanged);
            // 
            // cmdStop
            // 
            this.cmdStop.Location = new System.Drawing.Point(252, 37);
            this.cmdStop.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(108, 44);
            this.cmdStop.TabIndex = 9;
            this.cmdStop.Text = "Stop";
            this.cmdStop.UseVisualStyleBackColor = true;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // cmdNext
            // 
            this.cmdNext.Location = new System.Drawing.Point(12, 37);
            this.cmdNext.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(108, 44);
            this.cmdNext.TabIndex = 8;
            this.cmdNext.Text = "Next";
            this.cmdNext.UseVisualStyleBackColor = true;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(132, 37);
            this.cmdStart.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(108, 44);
            this.cmdStart.TabIndex = 4;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.lblWarning);
            this.panel.Controls.Add(this.imgGame);
            this.panel.Location = new System.Drawing.Point(24, 23);
            this.panel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(802, 771);
            this.panel.TabIndex = 7;
            this.panel.SizeChanged += new System.EventHandler(this.panel_SizeChanged);
            // 
            // lblWarning
            // 
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWarning.AutoSize = true;
            this.lblWarning.BackColor = System.Drawing.Color.Transparent;
            this.lblWarning.ForeColor = System.Drawing.Color.Coral;
            this.lblWarning.Location = new System.Drawing.Point(6, 738);
            this.lblWarning.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(0, 25);
            this.lblWarning.TabIndex = 16;
            // 
            // imgGame
            // 
            this.imgGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgGame.Cursor = System.Windows.Forms.Cursors.Cross;
            this.imgGame.Location = new System.Drawing.Point(0, 0);
            this.imgGame.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.imgGame.Name = "imgGame";
            this.imgGame.Size = new System.Drawing.Size(798, 767);
            this.imgGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgGame.TabIndex = 2;
            this.imgGame.TabStop = false;
            this.imgGame.Paint += new System.Windows.Forms.PaintEventHandler(this.imgGame_Paint);
            this.imgGame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgGame_MouseDown);
            this.imgGame.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgGame_MouseMove);
            // 
            // txtDeadRule
            // 
            this.txtDeadRule.Location = new System.Drawing.Point(197, 37);
            this.txtDeadRule.Margin = new System.Windows.Forms.Padding(6);
            this.txtDeadRule.Name = "txtDeadRule";
            this.txtDeadRule.Size = new System.Drawing.Size(43, 31);
            this.txtDeadRule.TabIndex = 21;
            this.txtDeadRule.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 25);
            this.label4.TabIndex = 22;
            this.label4.Text = "/";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 817);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFieldsize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trcAutoSpeed)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgGame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdNewGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAliveRule;
        private System.Windows.Forms.NumericUpDown numFieldsize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trcAutoSpeed;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox imgGame;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGeneration;
        private System.Windows.Forms.Label lblAliveCells;
        private System.Windows.Forms.TextBox txtDeadRule;
        private System.Windows.Forms.Label label4;
    }
}

