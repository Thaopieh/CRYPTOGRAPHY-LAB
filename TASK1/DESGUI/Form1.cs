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

namespace DESGUI
{

    public partial class Form1 : Form
    {
        [DllImport("DESDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "GenerateAndSaveIV_Keys")]
        public static extern void GenerateAndSaveIV_Keys(string KeyFormat, string KeyFileName);

        [DllImport("DESDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "Encryption")]
        public static extern void Encryption(string mode, string KeyFile, string KeyFormat, string PlaintextFile, string PlaintextFormat, string CipherFile, string CipherFormat);


        [DllImport("DESDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "Decryption")]
        public static extern void Decryption(string mode, string KeyFile, string KeyFormat, string RecoveredFile, string RecoveredFormat, string CipherFile, string CipherFormat);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            string format = cboFormatGenKey.SelectedItem.ToString();
            string keyFile = txtKeyFileGen.Text;
            try
            {
                GenerateAndSaveIV_Keys( format, keyFile);
                CopyFileToDestination(keyFile);

                MessageBox.Show("Successfull generate key with length is: 8 bytes, in: " + keyFile);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string Mode = cboMode.SelectedItem.ToString();
            string KeyFile = txtKeyFileEncr.Text;
            string KeynCipherFormat = cboFormatKeyEnCr.SelectedItem.ToString();
            string PlainTextFormat = cboTextFormatEncr.SelectedItem.ToString();
            string PlainTextFile = txtPlainTextFile.Text;
            string EncryptFile = txtEncryptedFile.Text;
            string cipherFormat = cboCipherFormat.SelectedItem.ToString();

            // Kiểm tra và xử lý checkbox
            if (cbScreen.Checked)
            {
                string plainTextScreen = rtbScreen.Text;
                // Tạo file tạm và lưu nội dung của rtbScreen vào đó
                string tempFilePath = Path.GetTempFileName();
                File.WriteAllText(tempFilePath, plainTextScreen);
                PlainTextFile = tempFilePath; // Sử dụng file tạm này làm plaintext
            }
            try
            {
                Encryption(Mode, KeyFile, KeynCipherFormat, PlainTextFile, PlainTextFormat, EncryptFile, cipherFormat);
                CopyFileToDestination(EncryptFile);
                MessageBox.Show("Successful encryption in file: " + EncryptFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Xóa file tạm nếu có
                if (!string.IsNullOrEmpty(PlainTextFile) && PlainTextFile.StartsWith(Path.GetTempPath()))
                {
                    File.Delete(PlainTextFile);
                }
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string Mode = cboModeDe.SelectedItem.ToString();
            string KeyFile = txtKeyFileDe.Text;
            string KeynCipherFormat = cboFormatKeynCipherDe.SelectedItem.ToString();
            string RecoverTextFormat = cboRecoverFormat.SelectedItem.ToString();
            string RecoverTextFile = txtRecovered.Text;
            string CipherFile = txtCipher.Text;
            string cipherFormat = cboFormatCipherDe.SelectedItem.ToString();
            if (cbDeScreen.Checked)
            {
                string plainTextScreen = richTextBox1.Text;
                // Tạo file tạm và lưu nội dung của rtbScreen vào đó
                string tempFilePath = Path.GetTempFileName();
                File.WriteAllText(tempFilePath, plainTextScreen);
                CipherFile = tempFilePath; // Sử dụng file tạm này làm plaintext
            }

            try
            {
                Decryption(Mode, KeyFile, KeynCipherFormat, RecoverTextFile, RecoverTextFormat, CipherFile, cipherFormat);
                CopyFileToDestination(RecoverTextFile);

                MessageBox.Show("Successful decryption in file: " + RecoverTextFile);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Xóa file tạm nếu có
                if (!string.IsNullOrEmpty(CipherFile) && CipherFile.StartsWith(Path.GetTempPath()))
                {
                    File.Delete(CipherFile);
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            rtbScreen.Enabled = false;
            richTextBox1.Enabled = false;
        }

        private void tabDecrypt_Click(object sender, EventArgs e)
        {

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

            private void btnKeyFileEn_Click(object sender, EventArgs e)
        {
            txtKeyFileEncr.Text=SelectAndCopyFile();
        }

        private void btnPlainEn_Click(object sender, EventArgs e)
        {
            txtPlainTextFile.Text = SelectAndCopyFile();
        }



        private void btnKeyFileDe_Click(object sender, EventArgs e)
        {
            txtKeyFileDe.Text = SelectAndCopyFile();
        }

        private void btnCipherFile_Click(object sender, EventArgs e)
        {
            txtCipher.Text = SelectAndCopyFile();
        }

        private void cbScreen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbScreen.Checked)
            {
                // Disable Button và TextBox
                btnPlainEn.Enabled = false;
                txtPlainTextFile.Enabled = false;
                rtbScreen.Enabled = true;
            }
            else
            {
                // Enable Button và TextBox
                btnPlainEn.Enabled = true;
                txtPlainTextFile.Enabled = true;
            }
        }



        private void cbDeScreen_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbDeScreen.Checked)
            {
                // Disable Button và TextBox
                btnCipherFile.Enabled = false;
                txtCipher.Enabled = false;
                richTextBox1.Enabled = true;


            }
            else
            {
                // Enable Button và TextBox
                btnPlainEn.Enabled = true;
                txtCipher.Enabled = true;
                
            }
        }
    }
}
