namespace AESGUI
{
    partial class AES
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
            this.cboMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKeyFileEncr = new System.Windows.Forms.TextBox();
            this.tabDecrypt = new System.Windows.Forms.TabPage();
            this.cbDeScreen = new System.Windows.Forms.CheckBox();
            this.btnPlainEn = new System.Windows.Forms.Button();
            this.btnKeyFileEn = new System.Windows.Forms.Button();
            this.cboCipherFormatDe = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cboRecoverFormat = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCipher = new System.Windows.Forms.TextBox();
            this.txtRecovered = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboFormatKeynCipherDe = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboModeDe = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtKeyFileDe = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Result = new System.Windows.Forms.TabControl();
            this.tabGenKey = new System.Windows.Forms.TabPage();
            this.cboKeySizeGen = new System.Windows.Forms.ComboBox();
            this.cboFormatGenKey = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKeyFileGen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabEncrypt = new System.Windows.Forms.TabPage();
            this.cbScreen = new System.Windows.Forms.CheckBox();
            this.rtbScreen = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cboCipherFormatEn = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cboTextFormatEncr = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEncryptedFile = new System.Windows.Forms.TextBox();
            this.txtPlainTextFile = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboFormatKeyEnCr = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabDecrypt.SuspendLayout();
            this.Result.SuspendLayout();
            this.tabGenKey.SuspendLayout();
            this.tabEncrypt.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboMode
            // 
            this.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMode.FormattingEnabled = true;
            this.cboMode.Items.AddRange(new object[] {
            "CBC",
            "CFB",
            "ECB",
            "OFB",
            "CTR",
            "XTS",
            "GCM",
            "CCM"});
            this.cboMode.Location = new System.Drawing.Point(293, 67);
            this.cboMode.Name = "cboMode";
            this.cboMode.Size = new System.Drawing.Size(276, 37);
            this.cboMode.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(189, 29);
            this.label7.TabIndex = 18;
            this.label7.Text = "Plain text format:";
            // 
            // txtKeyFileEncr
            // 
            this.txtKeyFileEncr.Location = new System.Drawing.Point(293, 191);
            this.txtKeyFileEncr.Name = "txtKeyFileEncr";
            this.txtKeyFileEncr.Size = new System.Drawing.Size(276, 34);
            this.txtKeyFileEncr.TabIndex = 16;
            // 
            // tabDecrypt
            // 
            this.tabDecrypt.Controls.Add(this.richTextBox1);
            this.tabDecrypt.Controls.Add(this.cbDeScreen);
            this.tabDecrypt.Controls.Add(this.btnPlainEn);
            this.tabDecrypt.Controls.Add(this.btnKeyFileEn);
            this.tabDecrypt.Controls.Add(this.cboCipherFormatDe);
            this.tabDecrypt.Controls.Add(this.label20);
            this.tabDecrypt.Controls.Add(this.cboRecoverFormat);
            this.tabDecrypt.Controls.Add(this.label11);
            this.tabDecrypt.Controls.Add(this.txtCipher);
            this.tabDecrypt.Controls.Add(this.txtRecovered);
            this.tabDecrypt.Controls.Add(this.label12);
            this.tabDecrypt.Controls.Add(this.cboFormatKeynCipherDe);
            this.tabDecrypt.Controls.Add(this.label13);
            this.tabDecrypt.Controls.Add(this.cboModeDe);
            this.tabDecrypt.Controls.Add(this.label14);
            this.tabDecrypt.Controls.Add(this.txtKeyFileDe);
            this.tabDecrypt.Controls.Add(this.label17);
            this.tabDecrypt.Controls.Add(this.label18);
            this.tabDecrypt.Controls.Add(this.btnDecrypt);
            this.tabDecrypt.Controls.Add(this.label15);
            this.tabDecrypt.Location = new System.Drawing.Point(4, 38);
            this.tabDecrypt.Name = "tabDecrypt";
            this.tabDecrypt.Padding = new System.Windows.Forms.Padding(3);
            this.tabDecrypt.Size = new System.Drawing.Size(1146, 574);
            this.tabDecrypt.TabIndex = 2;
            this.tabDecrypt.Text = "Decrypt";
            this.tabDecrypt.UseVisualStyleBackColor = true;
            // 
            // cbDeScreen
            // 
            this.cbDeScreen.AutoSize = true;
            this.cbDeScreen.Location = new System.Drawing.Point(814, 137);
            this.cbDeScreen.Name = "cbDeScreen";
            this.cbDeScreen.Size = new System.Drawing.Size(336, 33);
            this.cbDeScreen.TabIndex = 45;
            this.cbDeScreen.Text = "Input cipher text from screen";
            this.cbDeScreen.UseVisualStyleBackColor = true;
            this.cbDeScreen.CheckedChanged += new System.EventHandler(this.cbDeScreen_CheckedChanged);
            // 
            // btnPlainEn
            // 
            this.btnPlainEn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlainEn.Location = new System.Drawing.Point(636, 431);
            this.btnPlainEn.Name = "btnPlainEn";
            this.btnPlainEn.Size = new System.Drawing.Size(171, 34);
            this.btnPlainEn.TabIndex = 43;
            this.btnPlainEn.Text = "Cipher file";
            this.btnPlainEn.UseVisualStyleBackColor = true;
            this.btnPlainEn.Click += new System.EventHandler(this.btnPlainEn_Click);
            // 
            // btnKeyFileEn
            // 
            this.btnKeyFileEn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeyFileEn.Location = new System.Drawing.Point(636, 186);
            this.btnKeyFileEn.Name = "btnKeyFileEn";
            this.btnKeyFileEn.Size = new System.Drawing.Size(171, 34);
            this.btnKeyFileEn.TabIndex = 42;
            this.btnKeyFileEn.Text = "Key file";
            this.btnKeyFileEn.UseVisualStyleBackColor = true;
            this.btnKeyFileEn.Click += new System.EventHandler(this.btnKeyFileEn_Click);
            // 
            // cboCipherFormatDe
            // 
            this.cboCipherFormatDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCipherFormatDe.FormattingEnabled = true;
            this.cboCipherFormatDe.Items.AddRange(new object[] {
            "DER",
            "PEM",
            "HEX"});
            this.cboCipherFormatDe.Location = new System.Drawing.Point(354, 379);
            this.cboCipherFormatDe.Name = "cboCipherFormatDe";
            this.cboCipherFormatDe.Size = new System.Drawing.Size(276, 37);
            this.cboCipherFormatDe.TabIndex = 41;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(36, 379);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(173, 29);
            this.label20.TabIndex = 40;
            this.label20.Text = "Format Cipher:";
            // 
            // cboRecoverFormat
            // 
            this.cboRecoverFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRecoverFormat.FormattingEnabled = true;
            this.cboRecoverFormat.Items.AddRange(new object[] {
            "Text",
            "DER",
            "PEM",
            "HEX"});
            this.cboRecoverFormat.Location = new System.Drawing.Point(354, 261);
            this.cboRecoverFormat.Name = "cboRecoverFormat";
            this.cboRecoverFormat.Size = new System.Drawing.Size(276, 37);
            this.cboRecoverFormat.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 442);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(211, 29);
            this.label11.TabIndex = 38;
            this.label11.Text = "Cipher file\'s name:";
            // 
            // txtCipher
            // 
            this.txtCipher.Location = new System.Drawing.Point(354, 431);
            this.txtCipher.Name = "txtCipher";
            this.txtCipher.Size = new System.Drawing.Size(276, 34);
            this.txtCipher.TabIndex = 37;
            // 
            // txtRecovered
            // 
            this.txtRecovered.Location = new System.Drawing.Point(354, 318);
            this.txtRecovered.Name = "txtRecovered";
            this.txtRecovered.Size = new System.Drawing.Size(276, 34);
            this.txtRecovered.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 318);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(257, 29);
            this.label12.TabIndex = 35;
            this.label12.Text = "Recovered file\'s name:";
            // 
            // cboFormatKeynCipherDe
            // 
            this.cboFormatKeynCipherDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormatKeynCipherDe.FormattingEnabled = true;
            this.cboFormatKeynCipherDe.Items.AddRange(new object[] {
            "DER",
            "PEM",
            "HEX"});
            this.cboFormatKeynCipherDe.Location = new System.Drawing.Point(354, 133);
            this.cboFormatKeynCipherDe.Name = "cboFormatKeynCipherDe";
            this.cboFormatKeynCipherDe.Size = new System.Drawing.Size(276, 37);
            this.cboFormatKeynCipherDe.TabIndex = 34;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(239, 29);
            this.label13.TabIndex = 33;
            this.label13.Text = "Format Key n Cipher:";
            // 
            // cboModeDe
            // 
            this.cboModeDe.AllowDrop = true;
            this.cboModeDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeDe.FormattingEnabled = true;
            this.cboModeDe.Items.AddRange(new object[] {
            "CBC",
            "CFB",
            "ECB",
            "OFB",
            "CTR",
            "XTS",
            "GCM",
            "CCM"});
            this.cboModeDe.Location = new System.Drawing.Point(354, 69);
            this.cboModeDe.Name = "cboModeDe";
            this.cboModeDe.Size = new System.Drawing.Size(276, 37);
            this.cboModeDe.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(29, 251);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(253, 29);
            this.label14.TabIndex = 31;
            this.label14.Text = "Recovered text format:";
            // 
            // txtKeyFileDe
            // 
            this.txtKeyFileDe.Location = new System.Drawing.Point(354, 189);
            this.txtKeyFileDe.Name = "txtKeyFileDe";
            this.txtKeyFileDe.Size = new System.Drawing.Size(276, 34);
            this.txtKeyFileDe.TabIndex = 30;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(29, 189);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(180, 29);
            this.label17.TabIndex = 29;
            this.label17.Text = "Key file\'s name:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(29, 67);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 29);
            this.label18.TabIndex = 28;
            this.label18.Text = "Mode: ";
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(430, 493);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 29);
            this.label8.TabIndex = 15;
            this.label8.Text = "Key file\'s name:";
            // 
            // Result
            // 
            this.Result.Controls.Add(this.tabGenKey);
            this.Result.Controls.Add(this.tabEncrypt);
            this.Result.Controls.Add(this.tabDecrypt);
            this.Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result.Location = new System.Drawing.Point(56, 45);
            this.Result.Name = "Result";
            this.Result.SelectedIndex = 0;
            this.Result.Size = new System.Drawing.Size(1154, 616);
            this.Result.TabIndex = 1;
            // 
            // tabGenKey
            // 
            this.tabGenKey.Controls.Add(this.cboKeySizeGen);
            this.tabGenKey.Controls.Add(this.cboFormatGenKey);
            this.tabGenKey.Controls.Add(this.label5);
            this.tabGenKey.Controls.Add(this.txtKeyFileGen);
            this.tabGenKey.Controls.Add(this.label3);
            this.tabGenKey.Controls.Add(this.label2);
            this.tabGenKey.Controls.Add(this.btnGen);
            this.tabGenKey.Controls.Add(this.label1);
            this.tabGenKey.Location = new System.Drawing.Point(4, 38);
            this.tabGenKey.Name = "tabGenKey";
            this.tabGenKey.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenKey.Size = new System.Drawing.Size(1146, 574);
            this.tabGenKey.TabIndex = 0;
            this.tabGenKey.Text = "GenKey";
            this.tabGenKey.UseVisualStyleBackColor = true;
            // 
            // cboKeySizeGen
            // 
            this.cboKeySizeGen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKeySizeGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKeySizeGen.FormattingEnabled = true;
            this.cboKeySizeGen.Items.AddRange(new object[] {
            "128",
            "192",
            "256"});
            this.cboKeySizeGen.Location = new System.Drawing.Point(384, 136);
            this.cboKeySizeGen.Name = "cboKeySizeGen";
            this.cboKeySizeGen.Size = new System.Drawing.Size(276, 37);
            this.cboKeySizeGen.TabIndex = 11;
            // 
            // cboFormatGenKey
            // 
            this.cboFormatGenKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormatGenKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFormatGenKey.FormattingEnabled = true;
            this.cboFormatGenKey.Items.AddRange(new object[] {
            "DER",
            "PEM",
            "HEX"});
            this.cboFormatGenKey.Location = new System.Drawing.Point(384, 216);
            this.cboFormatGenKey.Name = "cboFormatGenKey";
            this.cboFormatGenKey.Size = new System.Drawing.Size(276, 37);
            this.cboFormatGenKey.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 29);
            this.label5.TabIndex = 8;
            this.label5.Text = "Key file\'s name:";
            // 
            // txtKeyFileGen
            // 
            this.txtKeyFileGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyFileGen.Location = new System.Drawing.Point(384, 278);
            this.txtKeyFileGen.Name = "txtKeyFileGen";
            this.txtKeyFileGen.Size = new System.Drawing.Size(276, 34);
            this.txtKeyFileGen.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Key Size (128/ 192/ 256 ):";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Format ";
            // 
            // btnGen
            // 
            this.btnGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGen.Location = new System.Drawing.Point(761, 192);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(141, 61);
            this.btnGen.TabIndex = 3;
            this.btnGen.Text = "Generate";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhập input vào để generate ra key";
            // 
            // tabEncrypt
            // 
            this.tabEncrypt.Controls.Add(this.cbScreen);
            this.tabEncrypt.Controls.Add(this.rtbScreen);
            this.tabEncrypt.Controls.Add(this.button1);
            this.tabEncrypt.Controls.Add(this.button2);
            this.tabEncrypt.Controls.Add(this.cboCipherFormatEn);
            this.tabEncrypt.Controls.Add(this.label19);
            this.tabEncrypt.Controls.Add(this.cboTextFormatEncr);
            this.tabEncrypt.Controls.Add(this.label6);
            this.tabEncrypt.Controls.Add(this.txtEncryptedFile);
            this.tabEncrypt.Controls.Add(this.txtPlainTextFile);
            this.tabEncrypt.Controls.Add(this.label16);
            this.tabEncrypt.Controls.Add(this.cboFormatKeyEnCr);
            this.tabEncrypt.Controls.Add(this.label4);
            this.tabEncrypt.Controls.Add(this.cboMode);
            this.tabEncrypt.Controls.Add(this.label7);
            this.tabEncrypt.Controls.Add(this.txtKeyFileEncr);
            this.tabEncrypt.Controls.Add(this.label8);
            this.tabEncrypt.Controls.Add(this.label9);
            this.tabEncrypt.Controls.Add(this.btnEncrypt);
            this.tabEncrypt.Controls.Add(this.label10);
            this.tabEncrypt.Location = new System.Drawing.Point(4, 38);
            this.tabEncrypt.Name = "tabEncrypt";
            this.tabEncrypt.Padding = new System.Windows.Forms.Padding(3);
            this.tabEncrypt.Size = new System.Drawing.Size(1146, 574);
            this.tabEncrypt.TabIndex = 1;
            this.tabEncrypt.Text = "Encrypt";
            this.tabEncrypt.UseVisualStyleBackColor = true;
            this.tabEncrypt.Click += new System.EventHandler(this.tabEncrypt_Click);
            // 
            // cbScreen
            // 
            this.cbScreen.AutoSize = true;
            this.cbScreen.Location = new System.Drawing.Point(814, 95);
            this.cbScreen.Name = "cbScreen";
            this.cbScreen.Size = new System.Drawing.Size(321, 33);
            this.cbScreen.TabIndex = 33;
            this.cbScreen.Text = "Input plain text from screen";
            this.cbScreen.UseVisualStyleBackColor = true;
            this.cbScreen.CheckedChanged += new System.EventHandler(this.cbScreen_CheckedChanged);
            // 
            // rtbScreen
            // 
            this.rtbScreen.Location = new System.Drawing.Point(814, 153);
            this.rtbScreen.Name = "rtbScreen";
            this.rtbScreen.Size = new System.Drawing.Size(284, 266);
            this.rtbScreen.TabIndex = 32;
            this.rtbScreen.Text = "";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(584, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 34);
            this.button1.TabIndex = 31;
            this.button1.Text = "Plain File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(584, 191);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 34);
            this.button2.TabIndex = 30;
            this.button2.Text = "Key File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cboCipherFormatEn
            // 
            this.cboCipherFormatEn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCipherFormatEn.FormattingEnabled = true;
            this.cboCipherFormatEn.Items.AddRange(new object[] {
            "DER",
            "PEM",
            "HEX"});
            this.cboCipherFormatEn.Location = new System.Drawing.Point(293, 393);
            this.cboCipherFormatEn.Name = "cboCipherFormatEn";
            this.cboCipherFormatEn.Size = new System.Drawing.Size(276, 37);
            this.cboCipherFormatEn.TabIndex = 29;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(36, 401);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(173, 29);
            this.label19.TabIndex = 28;
            this.label19.Text = "Format Cipher:";
            // 
            // cboTextFormatEncr
            // 
            this.cboTextFormatEncr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTextFormatEncr.FormattingEnabled = true;
            this.cboTextFormatEncr.Items.AddRange(new object[] {
            "Text",
            "DER",
            "PEM",
            "HEX"});
            this.cboTextFormatEncr.Location = new System.Drawing.Point(293, 259);
            this.cboTextFormatEncr.Name = "cboTextFormatEncr";
            this.cboTextFormatEncr.Size = new System.Drawing.Size(276, 37);
            this.cboTextFormatEncr.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 463);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(247, 29);
            this.label6.TabIndex = 26;
            this.label6.Text = "Encrypted file\'s name:";
            // 
            // txtEncryptedFile
            // 
            this.txtEncryptedFile.Location = new System.Drawing.Point(293, 461);
            this.txtEncryptedFile.Name = "txtEncryptedFile";
            this.txtEncryptedFile.Size = new System.Drawing.Size(276, 34);
            this.txtEncryptedFile.TabIndex = 25;
            // 
            // txtPlainTextFile
            // 
            this.txtPlainTextFile.Location = new System.Drawing.Point(293, 326);
            this.txtPlainTextFile.Name = "txtPlainTextFile";
            this.txtPlainTextFile.Size = new System.Drawing.Size(276, 34);
            this.txtPlainTextFile.TabIndex = 24;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(36, 332);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(193, 29);
            this.label16.TabIndex = 23;
            this.label16.Text = "Plain file\'s name:";
            // 
            // cboFormatKeyEnCr
            // 
            this.cboFormatKeyEnCr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormatKeyEnCr.FormattingEnabled = true;
            this.cboFormatKeyEnCr.Items.AddRange(new object[] {
            "DER",
            "PEM",
            "HEX"});
            this.cboFormatKeyEnCr.Location = new System.Drawing.Point(293, 123);
            this.cboFormatKeyEnCr.Name = "cboFormatKeyEnCr";
            this.cboFormatKeyEnCr.Size = new System.Drawing.Size(276, 37);
            this.cboFormatKeyEnCr.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 29);
            this.label4.TabIndex = 21;
            this.label4.Text = "Format Key:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 29);
            this.label9.TabIndex = 14;
            this.label9.Text = "Mode: ";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(426, 510);
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
            this.label10.Location = new System.Drawing.Point(331, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(402, 29);
            this.label10.TabIndex = 12;
            this.label10.Text = "Nhập input vào để encrypt ra file mới";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(386, 6);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(274, 36);
            this.label21.TabIndex = 30;
            this.label21.Text = "AES ALGORITHM";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(826, 186);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(284, 266);
            this.richTextBox1.TabIndex = 46;
            this.richTextBox1.Text = "";
            // 
            // AES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 712);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.Result);
            this.Name = "AES";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AES_Load);
            this.tabDecrypt.ResumeLayout(false);
            this.tabDecrypt.PerformLayout();
            this.Result.ResumeLayout(false);
            this.tabGenKey.ResumeLayout(false);
            this.tabGenKey.PerformLayout();
            this.tabEncrypt.ResumeLayout(false);
            this.tabEncrypt.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKeyFileEncr;
        private System.Windows.Forms.TabPage tabDecrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl Result;
        private System.Windows.Forms.TabPage tabGenKey;
        private System.Windows.Forms.ComboBox cboFormatGenKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKeyFileGen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabEncrypt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboKeySizeGen;
        private System.Windows.Forms.ComboBox cboFormatKeyEnCr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTextFormatEncr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEncryptedFile;
        private System.Windows.Forms.TextBox txtPlainTextFile;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboRecoverFormat;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCipher;
        private System.Windows.Forms.TextBox txtRecovered;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboFormatKeynCipherDe;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboModeDe;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtKeyFileDe;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboCipherFormatEn;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnPlainEn;
        private System.Windows.Forms.Button btnKeyFileEn;
        private System.Windows.Forms.ComboBox cboCipherFormatDe;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox cbScreen;
        private System.Windows.Forms.RichTextBox rtbScreen;
        private System.Windows.Forms.CheckBox cbDeScreen;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

