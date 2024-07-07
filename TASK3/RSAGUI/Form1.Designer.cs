namespace RSAGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabDecrypt = new System.Windows.Forms.TabPage();
            this.btnDeCipher = new System.Windows.Forms.Button();
            this.btnDeSecret = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cbDeScreen = new System.Windows.Forms.CheckBox();
            this.cboFormatD = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRecover = new System.Windows.Forms.TextBox();
            this.txtCipherD = new System.Windows.Forms.TextBox();
            this.txtSecretD = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.tabEncrypt = new System.Windows.Forms.TabPage();
            this.btnEnPlain = new System.Windows.Forms.Button();
            this.btnEnPubkey = new System.Windows.Forms.Button();
            this.cbScreen = new System.Windows.Forms.CheckBox();
            this.rtbScreen = new System.Windows.Forms.RichTextBox();
            this.cboFormatE = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCipher = new System.Windows.Forms.TextBox();
            this.txtPlain = new System.Windows.Forms.TextBox();
            this.txtPublicE = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tabGenKey = new System.Windows.Forms.TabPage();
            this.cboKeySize = new System.Windows.Forms.ComboBox();
            this.cboFormat = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrivate = new System.Windows.Forms.TextBox();
            this.txtPublic = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Result = new System.Windows.Forms.TabControl();
            this.tabDecrypt.SuspendLayout();
            this.tabEncrypt.SuspendLayout();
            this.tabGenKey.SuspendLayout();
            this.Result.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDecrypt
            // 
            this.tabDecrypt.Controls.Add(this.btnDeCipher);
            this.tabDecrypt.Controls.Add(this.btnDeSecret);
            this.tabDecrypt.Controls.Add(this.richTextBox1);
            this.tabDecrypt.Controls.Add(this.cbDeScreen);
            this.tabDecrypt.Controls.Add(this.cboFormatD);
            this.tabDecrypt.Controls.Add(this.label11);
            this.tabDecrypt.Controls.Add(this.label12);
            this.tabDecrypt.Controls.Add(this.txtRecover);
            this.tabDecrypt.Controls.Add(this.txtCipherD);
            this.tabDecrypt.Controls.Add(this.txtSecretD);
            this.tabDecrypt.Controls.Add(this.label13);
            this.tabDecrypt.Controls.Add(this.label14);
            this.tabDecrypt.Controls.Add(this.btnDecrypt);
            this.tabDecrypt.Controls.Add(this.label15);
            this.tabDecrypt.Location = new System.Drawing.Point(4, 38);
            this.tabDecrypt.Name = "tabDecrypt";
            this.tabDecrypt.Padding = new System.Windows.Forms.Padding(3);
            this.tabDecrypt.Size = new System.Drawing.Size(1089, 435);
            this.tabDecrypt.TabIndex = 2;
            this.tabDecrypt.Text = "Decrypt";
            this.tabDecrypt.UseVisualStyleBackColor = true;
            // 
            // btnDeCipher
            // 
            this.btnDeCipher.Location = new System.Drawing.Point(576, 206);
            this.btnDeCipher.Name = "btnDeCipher";
            this.btnDeCipher.Size = new System.Drawing.Size(135, 34);
            this.btnDeCipher.TabIndex = 52;
            this.btnDeCipher.Text = "Cipher";
            this.btnDeCipher.UseVisualStyleBackColor = true;
            this.btnDeCipher.Click += new System.EventHandler(this.btnDeCipher_Click);
            // 
            // btnDeSecret
            // 
            this.btnDeSecret.Location = new System.Drawing.Point(576, 142);
            this.btnDeSecret.Name = "btnDeSecret";
            this.btnDeSecret.Size = new System.Drawing.Size(135, 34);
            this.btnDeSecret.TabIndex = 51;
            this.btnDeSecret.Text = "Secret";
            this.btnDeSecret.UseVisualStyleBackColor = true;
            this.btnDeSecret.Click += new System.EventHandler(this.btnDeSecret_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(728, 118);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(344, 215);
            this.richTextBox1.TabIndex = 50;
            this.richTextBox1.Text = "";
            // 
            // cbDeScreen
            // 
            this.cbDeScreen.AutoSize = true;
            this.cbDeScreen.Location = new System.Drawing.Point(728, 71);
            this.cbDeScreen.Name = "cbDeScreen";
            this.cbDeScreen.Size = new System.Drawing.Size(336, 33);
            this.cbDeScreen.TabIndex = 49;
            this.cbDeScreen.Text = "Input cipher text from screen";
            this.cbDeScreen.UseVisualStyleBackColor = true;
            this.cbDeScreen.CheckedChanged += new System.EventHandler(this.cbDeScreen_CheckedChanged);
            // 
            // cboFormatD
            // 
            this.cboFormatD.FormattingEnabled = true;
            this.cboFormatD.Items.AddRange(new object[] {
            "DER",
            "PEM"});
            this.cboFormatD.Location = new System.Drawing.Point(277, 69);
            this.cboFormatD.Name = "cboFormatD";
            this.cboFormatD.Size = new System.Drawing.Size(276, 37);
            this.cboFormatD.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(252, 29);
            this.label11.TabIndex = 29;
            this.label11.Text = "Secret key file\'s name:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 204);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(211, 29);
            this.label12.TabIndex = 28;
            this.label12.Text = "Cipher file\'s name:";
            // 
            // txtRecover
            // 
            this.txtRecover.Location = new System.Drawing.Point(277, 268);
            this.txtRecover.Name = "txtRecover";
            this.txtRecover.Size = new System.Drawing.Size(276, 34);
            this.txtRecover.TabIndex = 27;
            // 
            // txtCipherD
            // 
            this.txtCipherD.Location = new System.Drawing.Point(277, 201);
            this.txtCipherD.Name = "txtCipherD";
            this.txtCipherD.Size = new System.Drawing.Size(276, 34);
            this.txtCipherD.TabIndex = 26;
            // 
            // txtSecretD
            // 
            this.txtSecretD.Location = new System.Drawing.Point(277, 139);
            this.txtSecretD.Name = "txtSecretD";
            this.txtSecretD.Size = new System.Drawing.Size(276, 34);
            this.txtSecretD.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 271);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(229, 29);
            this.label13.TabIndex = 25;
            this.label13.Text = "Recover file\'s name:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(255, 29);
            this.label14.TabIndex = 24;
            this.label14.Text = "Format (DER/Base64):";
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(359, 328);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(117, 61);
            this.btnDecrypt.TabIndex = 23;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(208, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(449, 29);
            this.label15.TabIndex = 22;
            this.label15.Text = "Nhập input vào để decrypt ra file ban đầu";
            // 
            // tabEncrypt
            // 
            this.tabEncrypt.Controls.Add(this.btnEnPlain);
            this.tabEncrypt.Controls.Add(this.btnEnPubkey);
            this.tabEncrypt.Controls.Add(this.cbScreen);
            this.tabEncrypt.Controls.Add(this.rtbScreen);
            this.tabEncrypt.Controls.Add(this.cboFormatE);
            this.tabEncrypt.Controls.Add(this.label6);
            this.tabEncrypt.Controls.Add(this.label7);
            this.tabEncrypt.Controls.Add(this.txtCipher);
            this.tabEncrypt.Controls.Add(this.txtPlain);
            this.tabEncrypt.Controls.Add(this.txtPublicE);
            this.tabEncrypt.Controls.Add(this.label8);
            this.tabEncrypt.Controls.Add(this.label9);
            this.tabEncrypt.Controls.Add(this.btnEncrypt);
            this.tabEncrypt.Controls.Add(this.label10);
            this.tabEncrypt.Location = new System.Drawing.Point(4, 38);
            this.tabEncrypt.Name = "tabEncrypt";
            this.tabEncrypt.Padding = new System.Windows.Forms.Padding(3);
            this.tabEncrypt.Size = new System.Drawing.Size(1089, 435);
            this.tabEncrypt.TabIndex = 1;
            this.tabEncrypt.Text = "Encrypt";
            this.tabEncrypt.UseVisualStyleBackColor = true;
            this.tabEncrypt.Click += new System.EventHandler(this.tabEncrypt_Click);
            // 
            // btnEnPlain
            // 
            this.btnEnPlain.Location = new System.Drawing.Point(586, 206);
            this.btnEnPlain.Name = "btnEnPlain";
            this.btnEnPlain.Size = new System.Drawing.Size(135, 34);
            this.btnEnPlain.TabIndex = 39;
            this.btnEnPlain.Text = "Plain";
            this.btnEnPlain.UseVisualStyleBackColor = true;
            this.btnEnPlain.Click += new System.EventHandler(this.btnEnPlain_Click);
            // 
            // btnEnPubkey
            // 
            this.btnEnPubkey.Location = new System.Drawing.Point(586, 142);
            this.btnEnPubkey.Name = "btnEnPubkey";
            this.btnEnPubkey.Size = new System.Drawing.Size(135, 34);
            this.btnEnPubkey.TabIndex = 38;
            this.btnEnPubkey.Text = "PubKey";
            this.btnEnPubkey.UseVisualStyleBackColor = true;
            this.btnEnPubkey.Click += new System.EventHandler(this.btnEnPubkey_Click);
            // 
            // cbScreen
            // 
            this.cbScreen.AutoSize = true;
            this.cbScreen.Location = new System.Drawing.Point(743, 59);
            this.cbScreen.Name = "cbScreen";
            this.cbScreen.Size = new System.Drawing.Size(321, 33);
            this.cbScreen.TabIndex = 37;
            this.cbScreen.Text = "Input plain text from screen";
            this.cbScreen.UseVisualStyleBackColor = true;
            this.cbScreen.CheckedChanged += new System.EventHandler(this.cbScreen_CheckedChanged);
            // 
            // rtbScreen
            // 
            this.rtbScreen.Location = new System.Drawing.Point(743, 107);
            this.rtbScreen.Name = "rtbScreen";
            this.rtbScreen.Size = new System.Drawing.Size(321, 196);
            this.rtbScreen.TabIndex = 36;
            this.rtbScreen.Text = "";
            // 
            // cboFormatE
            // 
            this.cboFormatE.FormattingEnabled = true;
            this.cboFormatE.Items.AddRange(new object[] {
            "DER",
            "PEM"});
            this.cboFormatE.Location = new System.Drawing.Point(292, 70);
            this.cboFormatE.Name = "cboFormatE";
            this.cboFormatE.Size = new System.Drawing.Size(276, 37);
            this.cboFormatE.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(249, 29);
            this.label6.TabIndex = 19;
            this.label6.Text = "Public key file\'s name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(247, 29);
            this.label7.TabIndex = 18;
            this.label7.Text = "Encrypted file\'s name:";
            // 
            // txtCipher
            // 
            this.txtCipher.Location = new System.Drawing.Point(292, 269);
            this.txtCipher.Name = "txtCipher";
            this.txtCipher.Size = new System.Drawing.Size(276, 34);
            this.txtCipher.TabIndex = 17;
            // 
            // txtPlain
            // 
            this.txtPlain.Location = new System.Drawing.Point(292, 208);
            this.txtPlain.Name = "txtPlain";
            this.txtPlain.Size = new System.Drawing.Size(276, 34);
            this.txtPlain.TabIndex = 16;
            // 
            // txtPublicE
            // 
            this.txtPublicE.Location = new System.Drawing.Point(292, 142);
            this.txtPublicE.Name = "txtPublicE";
            this.txtPublicE.Size = new System.Drawing.Size(276, 34);
            this.txtPublicE.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(193, 29);
            this.label8.TabIndex = 15;
            this.label8.Text = "Plain file\'s name:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 29);
            this.label9.TabIndex = 14;
            this.label9.Text = "Format";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(349, 335);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(109, 59);
            this.btnEncrypt.TabIndex = 13;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(209, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(402, 29);
            this.label10.TabIndex = 12;
            this.label10.Text = "Nhập input vào để encrypt ra file mới";
            // 
            // tabGenKey
            // 
            this.tabGenKey.Controls.Add(this.cboKeySize);
            this.tabGenKey.Controls.Add(this.cboFormat);
            this.tabGenKey.Controls.Add(this.label4);
            this.tabGenKey.Controls.Add(this.label5);
            this.tabGenKey.Controls.Add(this.txtPrivate);
            this.tabGenKey.Controls.Add(this.txtPublic);
            this.tabGenKey.Controls.Add(this.label3);
            this.tabGenKey.Controls.Add(this.label2);
            this.tabGenKey.Controls.Add(this.btnGen);
            this.tabGenKey.Controls.Add(this.label1);
            this.tabGenKey.Location = new System.Drawing.Point(4, 38);
            this.tabGenKey.Name = "tabGenKey";
            this.tabGenKey.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenKey.Size = new System.Drawing.Size(1089, 435);
            this.tabGenKey.TabIndex = 0;
            this.tabGenKey.Text = "GenKey";
            this.tabGenKey.UseVisualStyleBackColor = true;
            // 
            // cboKeySize
            // 
            this.cboKeySize.FormattingEnabled = true;
            this.cboKeySize.Items.AddRange(new object[] {
            "3072",
            "4096",
            "7680"});
            this.cboKeySize.Location = new System.Drawing.Point(333, 73);
            this.cboKeySize.Name = "cboKeySize";
            this.cboKeySize.Size = new System.Drawing.Size(276, 37);
            this.cboKeySize.TabIndex = 11;
            // 
            // cboFormat
            // 
            this.cboFormat.FormattingEnabled = true;
            this.cboFormat.Items.AddRange(new object[] {
            "DER",
            "PEM"});
            this.cboFormat.Location = new System.Drawing.Point(333, 139);
            this.cboFormat.Name = "cboFormat";
            this.cboFormat.Size = new System.Drawing.Size(276, 37);
            this.cboFormat.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = "Public key file\'s name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(252, 29);
            this.label5.TabIndex = 8;
            this.label5.Text = "Secret key file\'s name:";
            // 
            // txtPrivate
            // 
            this.txtPrivate.Location = new System.Drawing.Point(333, 208);
            this.txtPrivate.Name = "txtPrivate";
            this.txtPrivate.Size = new System.Drawing.Size(276, 34);
            this.txtPrivate.TabIndex = 7;
            // 
            // txtPublic
            // 
            this.txtPublic.Location = new System.Drawing.Point(333, 267);
            this.txtPublic.Name = "txtPublic";
            this.txtPublic.Size = new System.Drawing.Size(276, 34);
            this.txtPublic.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Key Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Format:";
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(707, 139);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(142, 61);
            this.btnGen.TabIndex = 3;
            this.btnGen.Text = "Generate";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhập input vào để generate ra key";
            // 
            // Result
            // 
            this.Result.Controls.Add(this.tabGenKey);
            this.Result.Controls.Add(this.tabEncrypt);
            this.Result.Controls.Add(this.tabDecrypt);
            this.Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result.Location = new System.Drawing.Point(70, 25);
            this.Result.Name = "Result";
            this.Result.SelectedIndex = 0;
            this.Result.Size = new System.Drawing.Size(1097, 477);
            this.Result.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 539);
            this.Controls.Add(this.Result);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabDecrypt.ResumeLayout(false);
            this.tabDecrypt.PerformLayout();
            this.tabEncrypt.ResumeLayout(false);
            this.tabEncrypt.PerformLayout();
            this.tabGenKey.ResumeLayout(false);
            this.tabGenKey.PerformLayout();
            this.Result.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabDecrypt;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox cbDeScreen;
        private System.Windows.Forms.ComboBox cboFormatD;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRecover;
        private System.Windows.Forms.TextBox txtCipherD;
        private System.Windows.Forms.TextBox txtSecretD;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabEncrypt;
        private System.Windows.Forms.CheckBox cbScreen;
        private System.Windows.Forms.RichTextBox rtbScreen;
        private System.Windows.Forms.ComboBox cboFormatE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCipher;
        private System.Windows.Forms.TextBox txtPlain;
        private System.Windows.Forms.TextBox txtPublicE;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabGenKey;
        private System.Windows.Forms.ComboBox cboKeySize;
        private System.Windows.Forms.ComboBox cboFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrivate;
        private System.Windows.Forms.TextBox txtPublic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl Result;
        private System.Windows.Forms.Button btnEnPlain;
        private System.Windows.Forms.Button btnEnPubkey;
        private System.Windows.Forms.Button btnDeCipher;
        private System.Windows.Forms.Button btnDeSecret;
    }
}

