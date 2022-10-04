using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam
{
    public partial class mainForm : Form
    {
        string filePath = "";
        public mainForm()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Opening...";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "txt files (*.txt)|*.txt";

            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = fileDialog.FileName;
                using(StreamReader reader = new StreamReader(filePath))
                {
                    string text = reader.ReadToEnd();
                    mainTb.Text = text;
                }
                toolStripStatusLabel1.Text = "Ready";
                toolStripStatusLabel2.Text = "Saved";
            }
            else
                toolStripStatusLabel1.Text = "Ready";
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            OpenToolStripMenuItem_Click(sender, e);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Saving...";
            if (filePath != "")
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.Write(mainTb.Text);
                }
                toolStripStatusLabel1.Text = "Ready";
                toolStripStatusLabel2.Text = "Saved";
            }
            else
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "txt files (*.txt)|*.txt";
                if(fileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(fileDialog.FileName, false))
                    {
                        writer.Write(mainTb.Text);
                    }
                    toolStripStatusLabel1.Text = "Ready";
                    toolStripStatusLabel2.Text = "Saved";
                }
                else
                    toolStripStatusLabel1.Text = "Ready";
            }
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            SaveToolStripMenuItem_Click(sender, e);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ломакин ПР-20.102к");
        }

        private void MainTb_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Modified";
        }
    }
}
