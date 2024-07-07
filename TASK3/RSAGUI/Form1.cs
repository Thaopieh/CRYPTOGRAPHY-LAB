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

namespace RSAGUI
{
    public partial class Form1 : Form
    {
        [DllImport("Dll1.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "GenerationAndSaveRSAKeys")]
        public static extern void GenerationAndSaveRSAKeys(int keySize, string format, string privateKeyFile, string publicKeyFile);

        [DllImport("Dll1.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "RSAencrypt")]
        public static extern void RSAencrypt(string format, string publicKeyFile, string PlaintextFile, string CipherFile);

        [DllImport("Dll1.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "RSAdecrypt")]
        public static extern void RSAdecrypt(string format, string privateKeyFile, string CipherFile, string PlaintextFile);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int keySize = Int32.Parse(cboKeySize.Text);
            string format = cboFormat.SelectedItem.ToString();
            string privateKeyFile = txtPrivate.Text;
            string publicKeyFile = txtPublic.Text;


            GenerationAndSaveRSAKeys(keySize, format, privateKeyFile, publicKeyFile);
            SaveKeysToDestination(privateKeyFile, publicKeyFile);

            MessageBox.Show("Keys Generated Successfully!");
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string format = cboFormatE.SelectedItem.ToString();
            string publicKeyFile = txtPublicE.Text;
            string plaintextFile = txtPlain.Text;
            string cipherFile = txtCipher.Text;

            if (cbScreen.Checked)
            {
                string plainTextScreen = rtbScreen.Text;
                // Tạo file tạm và lưu nội dung của rtbScreen vào đó
                string tempFilePath = Path.GetTempFileName();
                File.WriteAllText(tempFilePath, plainTextScreen);
                plaintextFile = tempFilePath; // Sử dụng file tạm này làm plaintext
            }

            try
            {
                RSAencrypt(format, publicKeyFile, plaintextFile, cipherFile);
                CopyFileToDestination(cipherFile);
                MessageBox.Show("Encrypted Successfully in File: " + cipherFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Xóa file tạm nếu có
                if (!string.IsNullOrEmpty(plaintextFile) && plaintextFile.StartsWith(Path.GetTempPath()))
                {
                    File.Delete(plaintextFile);
                }
            }

        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string format = cboFormatD.SelectedItem.ToString();
            string privateKeyFile = txtSecretD.Text;
            string cipherFile = txtCipherD.Text;
            string plaintextFile = txtRecover.Text;

            if (cbDeScreen.Checked)
            {
                string plainTextScreen = richTextBox1.Text;
                // Tạo file tạm và lưu nội dung của rtbScreen vào đó
                string tempFilePath = Path.GetTempFileName();
                File.WriteAllText(tempFilePath, plainTextScreen);
                cipherFile = tempFilePath; // Sử dụng file tạm này làm plaintext
            }
            try
            {
                RSAdecrypt(format, privateKeyFile, cipherFile, plaintextFile);
                CopyFileToDestination(plaintextFile);
                MessageBox.Show("Decrypted Successfully in File: " + plaintextFile);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Xóa file tạm nếu có
                if (!string.IsNullOrEmpty(cipherFile) && cipherFile.StartsWith(Path.GetTempPath()))
                {
                    File.Delete(cipherFile);
                }
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs);
                string content = ofd.FileName +": "+ sr.ReadToEnd()+"\n";
                richTextBox1.Text += content;
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabEncrypt_Click(object sender, EventArgs e)
        {

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


        // Method to copy a file from the current working directory to a specified destination
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

        private void SaveKeysToDestination(string privateKeyFile, string publicKeyFile)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string destinationPath = folderBrowserDialog.SelectedPath;

                    string sourcePrivateKeyPath = Path.Combine(Directory.GetCurrentDirectory(), privateKeyFile);
                    string sourcePublicKeyPath = Path.Combine(Directory.GetCurrentDirectory(), publicKeyFile);

                    string destinationPrivateKeyPath = Path.Combine(destinationPath, privateKeyFile);
                    string destinationPublicKeyPath = Path.Combine(destinationPath, publicKeyFile);

                    if (Path.GetDirectoryName(sourcePrivateKeyPath) != destinationPath)
                    {
                        File.Copy(sourcePrivateKeyPath, destinationPrivateKeyPath, true);
                    }

                    if (Path.GetDirectoryName(sourcePublicKeyPath) != destinationPath)
                    {
                        File.Copy(sourcePublicKeyPath, destinationPublicKeyPath, true);
                    }

                    MessageBox.Show("Keys saved to: " + destinationPath);
                }
            }
        }

        private void btnEnPubkey_Click(object sender, EventArgs e)
        {
            txtPublicE.Text = SelectAndCopyFile();
        }

        private void btnEnPlain_Click(object sender, EventArgs e)
        {
            txtPlain.Text = SelectAndCopyFile();
        }

        private void btnDeSecret_Click(object sender, EventArgs e)
        {
            txtSecretD.Text = SelectAndCopyFile();
        }

        private void btnDeCipher_Click(object sender, EventArgs e)
        {
            txtCipherD.Text = SelectAndCopyFile();
        }

        private void cbDeScreen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDeScreen.Checked)
            {
                // Disable Button và TextBox
                txtCipherD.Enabled = false;
                btnDeCipher.Enabled = false;
                richTextBox1.Enabled = true;


            }
            else
            {
                // Enable Button và TextBox
                btnDeCipher.Enabled = true;
                txtCipherD.Enabled = true;
 
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Enabled = false;
            rtbScreen.Enabled = false;
        }

        private void cbScreen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbScreen.Checked)
            {
                // Disable Button và TextBox
                btnEnPlain.Enabled = false;
                txtPlain.Enabled = false;
                rtbScreen.Enabled = true;
            }
            else
            {
                // Enable Button và TextBox
                btnEnPlain.Enabled = true;
                txtPlain.Enabled = true;
            }
        }
    }
}
