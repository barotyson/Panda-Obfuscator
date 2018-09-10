namespace PandaObfuscator
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.darkSectionPanel2 = new DarkUI.Controls.DarkSectionPanel();
            this.darkLabel6 = new DarkUI.Controls.DarkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.darkButton4 = new DarkUI.Controls.DarkButton();
            this.authorLbl = new DarkUI.Controls.DarkLabel();
            this.idLbl = new DarkUI.Controls.DarkLabel();
            this.DescLbl = new DarkUI.Controls.DarkLabel();
            this.nameLbl = new DarkUI.Controls.DarkLabel();
            this.darkButton3 = new DarkUI.Controls.DarkButton();
            this.darkButton2 = new DarkUI.Controls.DarkButton();
            this.darkListView1 = new DarkUI.Controls.DarkListView();
            this.darkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.darkTextBox1 = new DarkUI.Controls.DarkTextBox();
            this.darkButton1 = new DarkUI.Controls.DarkButton();
            this.darkSectionPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.darkSectionPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // darkSectionPanel2
            // 
            this.darkSectionPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.darkSectionPanel2.Controls.Add(this.darkLabel6);
            this.darkSectionPanel2.Controls.Add(this.pictureBox1);
            this.darkSectionPanel2.Controls.Add(this.darkButton4);
            this.darkSectionPanel2.Controls.Add(this.authorLbl);
            this.darkSectionPanel2.Controls.Add(this.idLbl);
            this.darkSectionPanel2.Controls.Add(this.DescLbl);
            this.darkSectionPanel2.Controls.Add(this.nameLbl);
            this.darkSectionPanel2.Controls.Add(this.darkButton3);
            this.darkSectionPanel2.Controls.Add(this.darkButton2);
            this.darkSectionPanel2.Controls.Add(this.darkListView1);
            this.darkSectionPanel2.Enabled = false;
            this.darkSectionPanel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(204)))));
            this.darkSectionPanel2.Location = new System.Drawing.Point(0, 60);
            this.darkSectionPanel2.Name = "darkSectionPanel2";
            this.darkSectionPanel2.SectionHeader = "Settings";
            this.darkSectionPanel2.Size = new System.Drawing.Size(800, 384);
            this.darkSectionPanel2.TabIndex = 3;
            // 
            // darkLabel6
            // 
            this.darkLabel6.AutoSize = true;
            this.darkLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel6.Location = new System.Drawing.Point(430, 246);
            this.darkLabel6.Name = "darkLabel6";
            this.darkLabel6.Size = new System.Drawing.Size(293, 78);
            this.darkLabel6.TabIndex = 9;
            this.darkLabel6.Text = "Panda Obfuscator\r\n\r\nBasic .NET Obfuscator, to protect you applications or library" +
    "s\r\n\r\nTheme: DarkUI by RobinPerris\r\nPandaObfuscator: CodeOfDark";
            this.darkLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(247, 231);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // darkButton4
            // 
            this.darkButton4.Location = new System.Drawing.Point(247, 349);
            this.darkButton4.Name = "darkButton4";
            this.darkButton4.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton4.Size = new System.Drawing.Size(541, 23);
            this.darkButton4.TabIndex = 7;
            this.darkButton4.Text = "Start";
            this.darkButton4.Click += new System.EventHandler(this.darkButton4_Click);
            // 
            // authorLbl
            // 
            this.authorLbl.AutoSize = true;
            this.authorLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.authorLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.authorLbl.Location = new System.Drawing.Point(244, 139);
            this.authorLbl.Name = "authorLbl";
            this.authorLbl.Size = new System.Drawing.Size(41, 13);
            this.authorLbl.TabIndex = 6;
            this.authorLbl.Text = "Author:";
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.idLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.idLbl.Location = new System.Drawing.Point(244, 121);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(19, 13);
            this.idLbl.TabIndex = 5;
            this.idLbl.Text = "Id:";
            // 
            // DescLbl
            // 
            this.DescLbl.AutoSize = true;
            this.DescLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.DescLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DescLbl.Location = new System.Drawing.Point(244, 157);
            this.DescLbl.Name = "DescLbl";
            this.DescLbl.Size = new System.Drawing.Size(66, 13);
            this.DescLbl.TabIndex = 4;
            this.DescLbl.Text = "Description: ";
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.nameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.nameLbl.Location = new System.Drawing.Point(244, 103);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(38, 13);
            this.nameLbl.TabIndex = 3;
            this.nameLbl.Text = "Name:";
            // 
            // darkButton3
            // 
            this.darkButton3.Location = new System.Drawing.Point(247, 64);
            this.darkButton3.Name = "darkButton3";
            this.darkButton3.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton3.Size = new System.Drawing.Size(27, 23);
            this.darkButton3.TabIndex = 2;
            this.darkButton3.Text = "-";
            this.darkButton3.Click += new System.EventHandler(this.darkButton3_Click);
            // 
            // darkButton2
            // 
            this.darkButton2.Location = new System.Drawing.Point(247, 35);
            this.darkButton2.Name = "darkButton2";
            this.darkButton2.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton2.Size = new System.Drawing.Size(27, 23);
            this.darkButton2.TabIndex = 1;
            this.darkButton2.Text = "+";
            this.darkButton2.Click += new System.EventHandler(this.darkButton2_Click);
            // 
            // darkListView1
            // 
            this.darkListView1.Location = new System.Drawing.Point(11, 35);
            this.darkListView1.Name = "darkListView1";
            this.darkListView1.Size = new System.Drawing.Size(230, 338);
            this.darkListView1.TabIndex = 0;
            this.darkListView1.Text = "darkListView1";
            this.darkListView1.Click += new System.EventHandler(this.darkListView1_Click);
            // 
            // darkSectionPanel1
            // 
            this.darkSectionPanel1.Controls.Add(this.darkLabel1);
            this.darkSectionPanel1.Controls.Add(this.darkTextBox1);
            this.darkSectionPanel1.Controls.Add(this.darkButton1);
            this.darkSectionPanel1.Location = new System.Drawing.Point(0, 0);
            this.darkSectionPanel1.Name = "darkSectionPanel1";
            this.darkSectionPanel1.SectionHeader = "PandaObfuscator";
            this.darkSectionPanel1.Size = new System.Drawing.Size(800, 61);
            this.darkSectionPanel1.TabIndex = 0;
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(12, 33);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(54, 13);
            this.darkLabel1.TabIndex = 2;
            this.darkLabel1.Text = "App Path:";
            // 
            // darkTextBox1
            // 
            this.darkTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.darkTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkTextBox1.Location = new System.Drawing.Point(72, 30);
            this.darkTextBox1.Name = "darkTextBox1";
            this.darkTextBox1.ReadOnly = true;
            this.darkTextBox1.Size = new System.Drawing.Size(635, 20);
            this.darkTextBox1.TabIndex = 1;
            // 
            // darkButton1
            // 
            this.darkButton1.Location = new System.Drawing.Point(713, 28);
            this.darkButton1.Name = "darkButton1";
            this.darkButton1.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton1.Size = new System.Drawing.Size(75, 23);
            this.darkButton1.TabIndex = 0;
            this.darkButton1.Text = "...";
            this.darkButton1.Click += new System.EventHandler(this.darkButton1_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 444);
            this.Controls.Add(this.darkSectionPanel2);
            this.Controls.Add(this.darkSectionPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = "PandaObfuscator";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.darkSectionPanel2.ResumeLayout(false);
            this.darkSectionPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.darkSectionPanel1.ResumeLayout(false);
            this.darkSectionPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        public DarkUI.Controls.DarkLabel darkLabel1;
        public DarkUI.Controls.DarkTextBox darkTextBox1;
        public DarkUI.Controls.DarkButton darkButton1;
        public DarkUI.Controls.DarkSectionPanel darkSectionPanel2;
        public DarkUI.Controls.DarkListView darkListView1;
        public DarkUI.Controls.DarkLabel DescLbl;
        public DarkUI.Controls.DarkLabel nameLbl;
        public DarkUI.Controls.DarkButton darkButton3;
        public DarkUI.Controls.DarkButton darkButton2;
        public DarkUI.Controls.DarkLabel authorLbl;
        public DarkUI.Controls.DarkLabel idLbl;
        public DarkUI.Controls.DarkButton darkButton4;
        public DarkUI.Controls.DarkLabel darkLabel6;
        public System.Windows.Forms.PictureBox pictureBox1;
    }
}

