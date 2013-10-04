using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Editor
{
    public partial class MainForm : Form
    {
        string LastDirectoryFile = "lastDirectory";
        string defaultDir;
        public MainForm()
        {
            //openFileDialog1.AutoUpgradeEnabled = true;

            InitializeComponent();
        }        

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (File.Exists(LastDirectoryFile))
            {
                StreamReader reader = new StreamReader(LastDirectoryFile);

                using (reader)
                {
                    defaultDir = reader.ReadToEnd();
                }

                openFileDialog1.InitialDirectory = defaultDir;
            }
            else
            {
                //Environment.Exit(0);
                defaultDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                //System.IO.Path.GetDirectoryName
                
            }

            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                defaultDir = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
                editorControl1.LoadLevel(openFileDialog1.FileName);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter writer = new StreamWriter(LastDirectoryFile, false);
            //Stre
            using (writer)
            {
                writer.Write(defaultDir);
            }
        }
    }
}
