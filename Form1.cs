using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class textEditor : Form
    {
        Encoding encoding = Encoding.Unicode;
        String fileName = "";
        public static int temp = 0;
        public textEditor()
        {
            InitializeComponent();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            DialogResult result = f2.DialogResult;
            if (result == DialogResult.Yes)
            {
                this.Enabled = true;
            }
            else
            {
                Application.Exit();
            }

            //DialogResult result = f2.DialogResult;
            //if (result == DialogResult.Yes)
            //{
            //    this.ShowDialog();
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            font.ShowDialog();
            if (richTextBox1.SelectedText != null)
            {
                richTextBox1.SelectionFont = font.Font;
            }
            else
            {
                richTextBox1.Font = font.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            if (richTextBox1.SelectedText != null)
            {
                richTextBox1.SelectionColor = colorDialog.Color;
            }
            else
            {
                richTextBox1.ForeColor = colorDialog.Color;
            }
        }

        private void textbackGgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.ShowDialog();
            if (richTextBox1.SelectedText != null)
            {
                richTextBox1.SelectionBackColor = color.Color;
                
            }
            else
            {
                richTextBox1.SelectionBackColor = color.Color;
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is an application make for an assignment of Visual Propramming Course in University of Information Technology");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                String []subname = fileName.Split('\\');
                StreamReader streamReader = new StreamReader(fileName, Encoding.UTF8);
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    richTextBox1.AppendText(line);
                }
                this.Text = subname[subname.Length - 1];
            }
            fileName = "";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == "")
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(savefile.FileName))
                    {
                        sw.WriteLine(richTextBox1.Text);
                    }
                    fileName = savefile.FileName;
                    String[] subname = fileName.Split('\\');
                    this.Text = subname[subname.Length - 1];
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.WriteLine(richTextBox1.Text);
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text!=null)
            {
                DialogResult result = MessageBox.Show("Do you want to save this file?", "Save before close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem.PerformClick();
                }
            }
            richTextBox1.Clear();
            richTextBox1.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != null)
            {
                DialogResult result = MessageBox.Show("Do you want to save this file?", "Save before close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem.PerformClick();
                }
            }
            //richTextBox1.Clear();
            //richTextBox1.Hide();
            Application.Restart();
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            richTextBox1.BackColor = colorDialog.Color;
        }
    }
}
