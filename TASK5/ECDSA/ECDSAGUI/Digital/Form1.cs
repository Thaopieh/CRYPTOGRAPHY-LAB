using System.Runtime.InteropServices;

namespace Digital
{
    public partial class Form1 : Form
    {
        [DllImport("ECDSA.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "genECCKeyPair")]
        public static extern bool genECCKeyPair(string privateKeyPath, string publicKeyPath, string mode);

        [DllImport("ECDSA.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "signPdf")]
        public static extern bool signPdf(string chrprivateKeyPath, string cpdfPath, string csignaturePath, string mode);

        [DllImport("ECDSA.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "verifySignature")]
        public static extern bool verifySignature(string cpublicKeyPath, string cpdfPath, string csignaturePath, string mode);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            pri.Text = SelectAndCopyFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            filePDF.Text = SelectAndCopyFile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mode = comboBox1.Text;
            string chrprivateKeyPath = pri.Text.ToString();
            string pdfPath = filePDF.Text.ToString();
            string signFile = sigName.Text.ToString();

            if (checkBox1.Checked)
            {
                string plainText = richTextBox1.Text.ToString();
                string tempFile = Path.GetTempFileName();
                File.WriteAllText(tempFile, plainText);
                pdfPath = tempFile;
            }
            try
            {
                if (signPdf(chrprivateKeyPath, pdfPath, signFile, mode))
                {
                    CopyFileToDestination(signFile);
                    MessageBox.Show("Sign successfully!");
                }
                else
                {
                    MessageBox.Show("Mode key fail, try again!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Xóa file tạm nếu có
                if (!string.IsNullOrEmpty(pdfPath) && pdfPath.StartsWith(Path.GetTempPath()))
                {
                    File.Delete(pdfPath);
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            pub.Text = SelectAndCopyFile();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fileVe.Text = SelectAndCopyFile();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string mode = comboBox2.Text;
            string cpublicKeyPath = pub.Text.ToString();
            string pdfPath = fileVe.Text.ToString();
            string signFile = sigtoVe.Text.ToString();

            if (checkBox2.Checked)
            {
                string plainText = richTextBox2.Text;
                string tempFilePath = Path.GetTempFileName();
                File.WriteAllText(tempFilePath, plainText);
                pdfPath = tempFilePath; // Sử dụng file tạm này làm plaintext
            }
            try
            {
                if (verifySignature(cpublicKeyPath, pdfPath, signFile, mode))
                {
                    MessageBox.Show("Verify successfully!");
                }
                else
                {
                    MessageBox.Show("Verify fail! Try again!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Xóa file tạm nếu có
                if (!string.IsNullOrEmpty(pdfPath) && pdfPath.StartsWith(Path.GetTempPath()))
                {
                    File.Delete(pdfPath);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string mode = comboBox3.Text;
            string privateKey = textBox1.Text;
            string publicKey = textBox2.Text;

            if (genECCKeyPair(privateKey, publicKey, mode))
            {
                SaveKeysToDestination(privateKey, publicKey);
                MessageBox.Show("Generate successfully!");
            }
            else
            {
                MessageBox.Show("Generate fail! Try again!");
            }


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

        private void button7_Click(object sender, EventArgs e)
        {
            sigtoVe.Text = SelectAndCopyFile();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Enabled = false;
            richTextBox2.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button2.Enabled = false;
                richTextBox1.Enabled = true;

            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                button5.Enabled= false;
                richTextBox2.Enabled = true;
            }
            else
            {
                button5.Enabled= true;
            }

        }
    }
}
