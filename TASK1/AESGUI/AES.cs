using System;
using System.CodeDom;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AESGUI
{
    public partial class AES : Form
    {
        [DllImport("AESDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "GenerateAndSaveIV_Keys")]
        public static extern void GenerateAndSaveIV_Keys( int KeySize, string KeyFormat, string KeyFileName);

        [DllImport("AESDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "Encryption")]
        public static extern void Encryption(string mode, string KeyFile, string KeyFormat, string PlaintextFile, string PlaintextFormat, string CipherFile, string CipherFormat);


        [DllImport("AESDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "Decryption")]
        public static extern void Decryption(string mode, string KeyFile, string KeyFormat, string RecoveredFile, string RecoveredFormat, string CipherFile, string CipherFormat);

        public AES()
        {
            InitializeComponent();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            string keySize = cboKeySizeGen.SelectedItem.ToString();
            int keySizeInt = int.Parse(keySize);
            keySizeInt /= 8;
            string format = cboFormatGenKey.SelectedItem.ToString();
            string keyFile = txtKeyFileGen.Text;

            try
            {
                GenerateAndSaveIV_Keys(keySizeInt, format, keyFile);
                CopyFileToDestination(keyFile);
                MessageBox.Show("Successfull generate key with length is: " + keySizeInt + "bytes, in: " + keyFile);
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
            string cipherFormat = cboCipherFormatEn.SelectedItem.ToString();

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
            string cipherFormat = cboCipherFormatDe.SelectedItem.ToString();

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

        private void label3_Click(object sender, EventArgs e)
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
                        //MessageBox.Show("File is already in the current working directory.")/*;*/
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

        private void button2_Click(object sender, EventArgs e)
        {
            txtKeyFileEncr.Text = SelectAndCopyFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPlainTextFile.Text = SelectAndCopyFile();
        }

        private void btnKeyFileEn_Click(object sender, EventArgs e)
        {
            txtKeyFileDe.Text = SelectAndCopyFile();
        }

        private void btnPlainEn_Click(object sender, EventArgs e)
        {
            txtCipher.Text = SelectAndCopyFile();
        }

        private void tabEncrypt_Click(object sender, EventArgs e)
        {

        }

        private void cbScreen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbScreen.Checked)
            {
                // Disable Button và TextBox
                button1.Enabled = false;
                txtPlainTextFile.Enabled = false;
                rtbScreen.Enabled = true;
            }
            else
            {
                // Enable Button và TextBox
                button1.Enabled = true;
                txtPlainTextFile.Enabled = true;
            }
        }

        private void AES_Load(object sender, EventArgs e)
        {
            rtbScreen.Enabled = false;
            richTextBox1.Enabled = false;
            
        }

        private void cbDeScreen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDeScreen.Checked)
            {
                // Disable Button và TextBox
                btnPlainEn.Enabled = false;
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
