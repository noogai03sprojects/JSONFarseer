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
                lblFilePath.Text = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OneVOneMeIRLIWillWreckUFaggot gingerWindow = new OneVOneMeIRLIWillWreckUFaggot();
            gingerWindow.Left = this.Left + this.Width;
            //gingerWindow.Location = new Point(this.Location.X + this.Width * 3, this.Location.Y);
            gingerWindow.Show();
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LevelManager.HasSaved)
            {
                LevelManager.SaveLevel(LevelManager.CurrentPath);
            }
            else
            {
                DialogResult result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LevelManager.SaveLevel(saveFileDialog1.FileName);
                    lblFilePath.Text = System.IO.Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);
                }
            }
            //LevelManager.SaveLevel("blobbymcfartington");
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LevelManager.CreateNewLevel();
        }

        private void btnNewRectangle_Click(object sender, EventArgs e)
        {
            LevelManager.CreateRectangle();
        }

        private void editorControl1_MouseDown(object sender, MouseEventArgs e)
        {
            LevelManager.MouseDown(new Microsoft.Xna.Framework.Vector2(e.X, e.Y));
        }

        private void btnTileset_Click(object sender, EventArgs e)
        {
            TilesetSelector selector = new TilesetSelector();
            selector.Show();
        }

        private void editorControl1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void editorControl1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {

        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            //Args
        }        
    }
}
