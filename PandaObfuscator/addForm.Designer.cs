namespace PandaObfuscator
{
    partial class addForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addForm));
            this.darkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            this.darkButton2 = new DarkUI.Controls.DarkButton();
            this.darkButton1 = new DarkUI.Controls.DarkButton();
            this.darkListView1 = new DarkUI.Controls.DarkListView();
            this.darkSectionPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // darkSectionPanel1
            // 
            this.darkSectionPanel1.Controls.Add(this.darkButton2);
            this.darkSectionPanel1.Controls.Add(this.darkButton1);
            this.darkSectionPanel1.Controls.Add(this.darkListView1);
            this.darkSectionPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkSectionPanel1.Location = new System.Drawing.Point(0, 0);
            this.darkSectionPanel1.Name = "darkSectionPanel1";
            this.darkSectionPanel1.SectionHeader = null;
            this.darkSectionPanel1.Size = new System.Drawing.Size(388, 345);
            this.darkSectionPanel1.TabIndex = 0;
            // 
            // darkButton2
            // 
            this.darkButton2.Location = new System.Drawing.Point(301, 310);
            this.darkButton2.Name = "darkButton2";
            this.darkButton2.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton2.Size = new System.Drawing.Size(75, 23);
            this.darkButton2.TabIndex = 2;
            this.darkButton2.Text = "Ok";
            this.darkButton2.Click += new System.EventHandler(this.darkButton2_Click);
            // 
            // darkButton1
            // 
            this.darkButton1.Location = new System.Drawing.Point(12, 310);
            this.darkButton1.Name = "darkButton1";
            this.darkButton1.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton1.Size = new System.Drawing.Size(75, 23);
            this.darkButton1.TabIndex = 1;
            this.darkButton1.Text = "Cancel";
            this.darkButton1.Click += new System.EventHandler(this.darkButton1_Click);
            // 
            // darkListView1
            // 
            this.darkListView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkListView1.Location = new System.Drawing.Point(1, 25);
            this.darkListView1.Name = "darkListView1";
            this.darkListView1.Size = new System.Drawing.Size(386, 279);
            this.darkListView1.TabIndex = 0;
            this.darkListView1.Text = "darkListView1";
            // 
            // addForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 345);
            this.Controls.Add(this.darkSectionPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "addForm";
            this.Text = "PandaSettings";
            this.Load += new System.EventHandler(this.addForm_Load);
            this.darkSectionPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        private DarkUI.Controls.DarkButton darkButton2;
        private DarkUI.Controls.DarkButton darkButton1;
        private DarkUI.Controls.DarkListView darkListView1;
    }
}