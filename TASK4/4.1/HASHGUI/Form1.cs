using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HASHGUI
{
    public partial class Form1 : Form
    {
        [DllImport("shas.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void hashes(string algo, string input_filename, string output_filename);


        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                richTextBox1.Enabled = true;
                txtInput.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtInput.Text = SelectAndCopyFile();
        }

        public void CopyFileToDestination(string fileName)
        {
            string sourceFilePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            if (!File.Exists(sourceFilePath))
            {
                MessageBox.Show($"File '{fileName}' does not exist in the current working directory.");
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = fileName; // Default file name in the save dialog
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string destinationFilePath = saveFileDialog.FileName;
                    string destinationDirectory = Path.GetDirectoryName(destinationFilePath);

                    if (destinationDirectory == Directory.GetCurrentDirectory())
                    {
                        //MessageBox.Show("File is already in the current working directory.");
                    }
                    else
                    {
                        File.Copy(sourceFilePath, destinationFilePath, true);
                        //MessageBox.Show("File copied to the specified location successfully.");
                    }
                }
            }
        }

        public string SelectAndCopyFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourceFilePath = openFileDialog.FileName;
                    string currentDirectory = Directory.GetCurrentDirectory();
                    string destinationFilePath = Path.Combine(currentDirectory, Path.GetFileName(sourceFilePath));

                    // Check if the file is already in the current working directory
                    if (Path.GetDirectoryName(sourceFilePath) == currentDirectory)
                    {
                        //MessageBox.Show("File is already in the current working directory.");
                        return Path.GetFileName(sourceFilePath);
                    }

                    // Copy the file to the current working directory
                    File.Copy(sourceFilePath, destinationFilePath, true);
                    //MessageBox.Show("File copied to current working directory successfully.");
                    return Path.GetFileName(destinationFilePath);
                }
            }
            return null;
        }



        private void btnHash_Click(object sender, EventArgs e)
        {
            string algo = cboAlgo.Text;
            string input = txtInput.Text;
            string output = txtOutputt.Text;

            if(checkBox1.Checked)
            {
                string inputfile = richTextBox1.Text;
                string tempFile =  Path.GetTempFileName();
                File.WriteAllText(tempFile, inputfile);
                input = tempFile;
            }    

            try
            {
                hashes(algo, input, output);
                CopyFileToDestination(output);
                MessageBox.Show("Success hashes, output in file " + output);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                // Xóa file tạm nếu có
                if (!string.IsNullOrEmpty(input) && input.StartsWith(Path.GetTempPath()))
                {
                    File.Delete(input);
                }
            }
        }
    }
}
