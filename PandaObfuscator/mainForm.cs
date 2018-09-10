using Core;
using Core.Protections.StringEncoding;
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
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            pandaModuleManager = new PandaModuleManager();
        }
        PandaContext pandaContext;
        PandaModuleManager pandaModuleManager;
        PandaEngine pandaEngine;
        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void darkButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                darkTextBox1.Text = op.FileName;
                try
                {
                    pandaContext = new PandaContext(op.FileName);
                    pandaModuleManager = new PandaModuleManager();
                    pandaEngine = new PandaEngine(pandaContext);
                    darkSectionPanel2.Enabled = true;
                }catch (Exception)
                {
                    darkSectionPanel2.Enabled = false;
                }

            }
            


        }

        private void darkListView1_Click(object sender, EventArgs e)
        {
            try
            {
                DarkListItem darkListItem = darkListView1.Items[darkListView1.SelectedIndices[0]];
                PandaProtection pandaProtection = pandaModuleManager.pandaProtections().Single(t => t.Id == darkListItem.Tag && t.Name == darkListItem.Text);
                nameLbl.Text = "Name: " + (pandaProtection.Name);
                idLbl.Text = "Id: " + pandaProtection.Id;
                DescLbl.Text = "Description: " + pandaProtection.Description;
                authorLbl.Text = "Author: " + pandaProtection.Author;
            }
            catch{}
        }

        private void darkButton2_Click(object sender, EventArgs e)
        {
            new addForm(pandaContext, this).Show();

        }

        private void darkButton3_Click(object sender, EventArgs e)
        {
            DarkListItem darkListItem = darkListView1.Items[darkListView1.SelectedIndices[0]];
            PandaProtection pandaProtection = pandaModuleManager.pandaProtections().Single(t => t.Id == darkListItem.Tag && t.Name == darkListItem.Text);
            darkListView1.Items.RemoveAt(darkListView1.SelectedIndices[0]);
            pandaContext.removeIGModule(pandaProtection);
        }

        private void darkButton4_Click(object sender, EventArgs e)
        {
            foreach(DarkListItem itm in darkListView1.Items)
            {
                PandaProtection pandaProtection = pandaModuleManager.pandaProtections().Single(t => t.Id == itm.Tag && t.Name == itm.Text);
                pandaContext.addIGModule(pandaProtection);

            }
            pandaEngine.runModules(pandaContext);
            if (pandaContext.Write())
                MessageBox.Show("File Obfuscated!");
            else
                MessageBox.Show("Cannot Obfuscate the file for some reasons!");
        }
        public void reNew()
        {
            darkSectionPanel2.Enabled = false;
            nameLbl.Text = "Name: ";
            idLbl.Text = "Id: ";
            DescLbl.Text = "Description: ";
            authorLbl.Text = "Author: ";
        }
    }
}
