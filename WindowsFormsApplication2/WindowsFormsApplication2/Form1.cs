using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        bool indexer = false;
        bool check = false;
        String path = "";
        public Form1()
        {
            InitializeComponent();
        }
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = note.SelectionFont;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                note.SelectionFont = fd.Font ;
            } 
        }

        private void backGroundColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                note.BackColor = cd.Color;
            } 
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ver 1.0.0 \n -Created By Shyam Kanani©");
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            note.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            note.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            note.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            note.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            note.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            note.SelectAll();
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                note.SelectionColor = cd.Color;
            } 
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            note.Clear();
            note.BackColor = Color.White;
            this.Text = "Untitled-Notepad";
            indexer = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Text Document(*.txt)|*.txt";
            if (op.ShowDialog() == DialogResult.OK)
            {
                //File.WriteAllText(op.FileName, note.Text);
                note.LoadFile(op.FileName, RichTextBoxStreamType.PlainText);
            }
            path = op.FileName;
            this.Text = op.FileName;
            indexer = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sp = new SaveFileDialog();
            if (indexer == false) 
            {
                sp.Filter = "Text Document(*.txt)|*.txt";
                if (sp.ShowDialog() == DialogResult.OK)
                {
                    //File.WriteAllText(sp.FileName, note.Text);
                    note.SaveFile(sp.FileName, RichTextBoxStreamType.PlainText);
                }
                path = sp.FileName;
                this.Text = sp.FileName;
                indexer = true;
                check = true;
            }
            else
            {
                //File.WriteAllText(sp.FileName, note.Text);
                note.SaveFile(path, RichTextBoxStreamType.PlainText);
                check = true;
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            note.SelectedText = "";
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            note.Text = Convert.ToString(DateTime.Now);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.ShowDialog();
        }

        private void saveASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sp = new SaveFileDialog();
                sp.Filter = "Text Document(*.txt)|*.txt";
                if (sp.ShowDialog() == DialogResult.OK)
                {
                    //File.WriteAllText(sp.FileName, note.Text);
                    note.SaveFile(sp.FileName, RichTextBoxStreamType.PlainText);
                }
                path = sp.FileName;
                this.Text = sp.FileName;
                indexer = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (check == false)
            {
                DialogResult result3 = MessageBox.Show("You want to save this file ?", "The Question ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result3 == DialogResult.Yes) 
                {
                    saveToolStripMenuItem.PerformClick();
                }
                else if (result3 == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else 
            {
                Application.Exit();
            }
        }

        private void note_TextChanged(object sender, EventArgs e)
        {
            check = false;
        }
    }
}
