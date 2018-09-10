using Core;
using DarkUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PandaObfuscator
{
    public partial class addForm : Form
    {
        PandaContext pandaContext;
        mainForm main;
        public addForm(PandaContext pandaContext, mainForm mainForm)
        {
            this.main = mainForm;
            this.pandaContext = pandaContext;
            InitializeComponent();
        }

        private void addForm_Load(object sender, EventArgs e)
        {
            foreach (PandaProtection p in pandaContext.register.getRegistredModules())
            {
                try
                {
                    if (main.darkListView1.Items.Single(itm => itm.Tag == p.Id) != null) continue;
                }
                catch { }
                
                if (pandaContext.getIGModules().Contains(p)) continue;
                DarkListItem darkListItem = new DarkUI.Controls.DarkListItem(p.Name);
                darkListItem.Tag = p.Id;
                darkListView1.Items.Add(darkListItem);
            }
        }

        private void darkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                DarkListItem darkListItem = darkListView1.Items[darkListView1.SelectedIndices[0]];
                main.darkListView1.Items.Add(darkListItem);
                this.Close();
            }
            catch { }
        }

        private void darkButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
