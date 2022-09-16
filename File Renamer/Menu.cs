using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace File_Renamer
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://steamcommunity.com/id/Nayoh/");
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Unchecked)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog pathA = new FolderBrowserDialog();
            if (pathA.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = pathA.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog pathB = new FolderBrowserDialog();
            if (pathB.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = pathB.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(textBox1.Text) && Directory.Exists(textBox2.Text) && textBox1.Text != textBox2.Text)
                {
                    List<string> filesA = new List<string>();
                    List<string> filesB = new List<string>();
                    filesA = Directory.EnumerateFiles(textBox1.Text, "*", SearchOption.TopDirectoryOnly).Select(Path.GetFileName).ToList();
                    filesB = Directory.EnumerateFiles(textBox2.Text, "*", SearchOption.TopDirectoryOnly).Select(Path.GetFileName).ToList();
                    if (filesA.Count == filesB.Count)
                    {
                        if (Directory.Exists(textBox2.Text + "\\File Renamer：Output\\"))
                        {
                            Directory.Delete(textBox2.Text + "\\File Renamer：Output\\", true);
                            Directory.CreateDirectory(textBox2.Text + "\\File Renamer：Output\\");
                        }
                        else
                        {
                            Directory.CreateDirectory(textBox2.Text + "\\File Renamer：Output\\");
                        }

                        for (int i = 0; i < filesA.Count; i++)
                        {
                            File.Copy(textBox2.Text + "\\" + filesB[i], textBox2.Text + "\\File Renamer：Output\\" + filesA[i]);
                        }
                        MessageBox.Show("Files renamed successfully.\n" + textBox2.Text + "\\File Renamer：Output\\");
                    }
                    else
                    {
                        MessageBox.Show("The number of files in directory A must be the same as the number of files in directory B.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Directory.");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error x-x\n\n" + exception);
            }
        }
    }
}
