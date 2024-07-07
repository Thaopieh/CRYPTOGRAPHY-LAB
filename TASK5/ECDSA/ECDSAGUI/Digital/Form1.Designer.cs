namespace Digital
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            checkBox1 = new CheckBox();
            richTextBox1 = new RichTextBox();
            comboBox1 = new ComboBox();
            label8 = new Label();
            button3 = new Button();
            sigName = new TextBox();
            label4 = new Label();
            button2 = new Button();
            filePDF = new TextBox();
            label3 = new Label();
            button1 = new Button();
            pri = new TextBox();
            label2 = new Label();
            tabPage2 = new TabPage();
            button7 = new Button();
            checkBox2 = new CheckBox();
            richTextBox2 = new RichTextBox();
            comboBox2 = new ComboBox();
            label9 = new Label();
            label5 = new Label();
            button4 = new Button();
            label6 = new Label();
            sigtoVe = new TextBox();
            label7 = new Label();
            button5 = new Button();
            fileVe = new TextBox();
            button6 = new Button();
            pub = new TextBox();
            tabPage3 = new TabPage();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label13 = new Label();
            button9 = new Button();
            label11 = new Label();
            label12 = new Label();
            comboBox3 = new ComboBox();
            label10 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AccessibleRole = AccessibleRole.Grip;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(506, 25);
            label1.Name = "label1";
            label1.Size = new Size(231, 31);
            label1.TabIndex = 0;
            label1.Text = "DIGITAL SIGNATURE";
            // 
            // tabControl1
            // 
            tabControl1.AccessibleRole = AccessibleRole.Grip;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(82, 81);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1158, 373);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.AccessibleRole = AccessibleRole.Grip;
            tabPage1.BackColor = Color.LavenderBlush;
            tabPage1.Controls.Add(checkBox1);
            tabPage1.Controls.Add(richTextBox1);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(sigName);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(filePDF);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(pri);
            tabPage1.Controls.Add(label2);
            tabPage1.ForeColor = SystemColors.ControlText;
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1150, 340);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Sign PDF";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(754, 24);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(152, 24);
            checkBox1.TabIndex = 12;
            checkBox1.Text = "Input the message";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(754, 99);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(344, 156);
            richTextBox1.TabIndex = 11;
            richTextBox1.Text = "";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "DER", "PEM" });
            comboBox1.Location = new Point(224, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(296, 28);
            comboBox1.TabIndex = 10;
            // 
            // label8
            // 
            label8.AccessibleRole = AccessibleRole.Grip;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(28, 22);
            label8.Name = "label8";
            label8.Size = new Size(100, 28);
            label8.TabIndex = 9;
            label8.Text = "Key mode";
            // 
            // button3
            // 
            button3.AccessibleRole = AccessibleRole.Grip;
            button3.BackColor = Color.White;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(301, 284);
            button3.Name = "button3";
            button3.Size = new Size(133, 31);
            button3.TabIndex = 8;
            button3.Text = "Sign";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // sigName
            // 
            sigName.AccessibleRole = AccessibleRole.Grip;
            sigName.Location = new Point(224, 228);
            sigName.Name = "sigName";
            sigName.Size = new Size(487, 27);
            sigName.TabIndex = 7;
            // 
            // label4
            // 
            label4.AccessibleRole = AccessibleRole.Grip;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(28, 214);
            label4.Name = "label4";
            label4.Size = new Size(106, 28);
            label4.TabIndex = 6;
            label4.Text = "Output file";
            // 
            // button2
            // 
            button2.AccessibleRole = AccessibleRole.Grip;
            button2.BackColor = Color.White;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(578, 162);
            button2.Name = "button2";
            button2.Size = new Size(133, 31);
            button2.TabIndex = 5;
            button2.Text = "Upload";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // filePDF
            // 
            filePDF.AccessibleRole = AccessibleRole.Grip;
            filePDF.Location = new Point(224, 163);
            filePDF.Name = "filePDF";
            filePDF.ReadOnly = true;
            filePDF.Size = new Size(296, 27);
            filePDF.TabIndex = 4;
            // 
            // label3
            // 
            label3.AccessibleRole = AccessibleRole.Grip;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(28, 149);
            label3.Name = "label3";
            label3.Size = new Size(121, 28);
            label3.TabIndex = 3;
            label3.Text = "Load pdf file";
            // 
            // button1
            // 
            button1.AccessibleRole = AccessibleRole.Grip;
            button1.BackColor = Color.White;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(578, 98);
            button1.Name = "button1";
            button1.Size = new Size(133, 31);
            button1.TabIndex = 2;
            button1.Text = "Upload";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pri
            // 
            pri.AccessibleRole = AccessibleRole.Grip;
            pri.Location = new Point(224, 99);
            pri.Name = "pri";
            pri.ReadOnly = true;
            pri.Size = new Size(296, 27);
            pri.TabIndex = 1;
            // 
            // label2
            // 
            label2.AccessibleRole = AccessibleRole.Grip;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 85);
            label2.Name = "label2";
            label2.Size = new Size(156, 28);
            label2.TabIndex = 0;
            label2.Text = "Load private key";
            // 
            // tabPage2
            // 
            tabPage2.AccessibleRole = AccessibleRole.Grip;
            tabPage2.BackColor = Color.LavenderBlush;
            tabPage2.Controls.Add(button7);
            tabPage2.Controls.Add(checkBox2);
            tabPage2.Controls.Add(richTextBox2);
            tabPage2.Controls.Add(comboBox2);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(button4);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(sigtoVe);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(button5);
            tabPage2.Controls.Add(fileVe);
            tabPage2.Controls.Add(button6);
            tabPage2.Controls.Add(pub);
            tabPage2.ForeColor = SystemColors.Highlight;
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1150, 340);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Verify";
            // 
            // button7
            // 
            button7.AccessibleRole = AccessibleRole.Grip;
            button7.BackColor = Color.White;
            button7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.Location = new Point(574, 216);
            button7.Name = "button7";
            button7.Size = new Size(133, 31);
            button7.TabIndex = 22;
            button7.Text = "Upload";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(745, 41);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(152, 24);
            checkBox2.TabIndex = 21;
            checkBox2.Text = "Input the message";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(745, 89);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(344, 156);
            richTextBox2.TabIndex = 20;
            richTextBox2.Text = "";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "DER", "PEM" });
            comboBox2.Location = new Point(220, 41);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(296, 28);
            comboBox2.TabIndex = 19;
            // 
            // label9
            // 
            label9.AccessibleRole = AccessibleRole.Grip;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(34, 41);
            label9.Name = "label9";
            label9.Size = new Size(100, 28);
            label9.TabIndex = 18;
            label9.Text = "Key mode";
            // 
            // label5
            // 
            label5.AccessibleRole = AccessibleRole.Grip;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(32, 212);
            label5.Name = "label5";
            label5.Size = new Size(106, 28);
            label5.TabIndex = 9;
            label5.Text = "Output file";
            // 
            // button4
            // 
            button4.AccessibleRole = AccessibleRole.Grip;
            button4.BackColor = Color.White;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(383, 286);
            button4.Name = "button4";
            button4.Size = new Size(133, 31);
            button4.TabIndex = 17;
            button4.Text = "Verify";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label6
            // 
            label6.AccessibleRole = AccessibleRole.Grip;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(32, 149);
            label6.Name = "label6";
            label6.Size = new Size(121, 28);
            label6.TabIndex = 8;
            label6.Text = "Load pdf file";
            // 
            // sigtoVe
            // 
            sigtoVe.AccessibleRole = AccessibleRole.Grip;
            sigtoVe.Location = new Point(220, 216);
            sigtoVe.Name = "sigtoVe";
            sigtoVe.ReadOnly = true;
            sigtoVe.Size = new Size(296, 27);
            sigtoVe.TabIndex = 16;
            // 
            // label7
            // 
            label7.AccessibleRole = AccessibleRole.Grip;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(32, 84);
            label7.Name = "label7";
            label7.Size = new Size(149, 28);
            label7.TabIndex = 7;
            label7.Text = "Load public key";
            // 
            // button5
            // 
            button5.AccessibleRole = AccessibleRole.Grip;
            button5.BackColor = Color.White;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(574, 151);
            button5.Name = "button5";
            button5.Size = new Size(133, 31);
            button5.TabIndex = 14;
            button5.Text = "Upload";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // fileVe
            // 
            fileVe.AccessibleRole = AccessibleRole.Grip;
            fileVe.Location = new Point(220, 152);
            fileVe.Name = "fileVe";
            fileVe.ReadOnly = true;
            fileVe.Size = new Size(296, 27);
            fileVe.TabIndex = 13;
            // 
            // button6
            // 
            button6.AccessibleRole = AccessibleRole.Grip;
            button6.BackColor = Color.White;
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.Location = new Point(574, 87);
            button6.Name = "button6";
            button6.Size = new Size(133, 31);
            button6.TabIndex = 11;
            button6.Text = "Upload";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // pub
            // 
            pub.AccessibleRole = AccessibleRole.Grip;
            pub.Location = new Point(220, 88);
            pub.Name = "pub";
            pub.ReadOnly = true;
            pub.Size = new Size(296, 27);
            pub.TabIndex = 10;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(textBox2);
            tabPage3.Controls.Add(textBox1);
            tabPage3.Controls.Add(label13);
            tabPage3.Controls.Add(button9);
            tabPage3.Controls.Add(label11);
            tabPage3.Controls.Add(label12);
            tabPage3.Controls.Add(comboBox3);
            tabPage3.Controls.Add(label10);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1150, 340);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "GenKey";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(427, 215);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(296, 27);
            textBox2.TabIndex = 22;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(427, 151);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(296, 27);
            textBox1.TabIndex = 21;
            // 
            // label13
            // 
            label13.AccessibleRole = AccessibleRole.Grip;
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(455, 24);
            label13.Name = "label13";
            label13.Size = new Size(251, 31);
            label13.TabIndex = 20;
            label13.Text = "GENERATE ECDSA KEY";
            // 
            // button9
            // 
            button9.AccessibleRole = AccessibleRole.Grip;
            button9.BackColor = Color.White;
            button9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.Location = new Point(505, 295);
            button9.Name = "button9";
            button9.Size = new Size(133, 31);
            button9.TabIndex = 19;
            button9.Text = "Generate";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // label11
            // 
            label11.AccessibleRole = AccessibleRole.Grip;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(231, 215);
            label11.Name = "label11";
            label11.Size = new Size(100, 28);
            label11.TabIndex = 15;
            label11.Text = "Public key";
            // 
            // label12
            // 
            label12.AccessibleRole = AccessibleRole.Grip;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(231, 151);
            label12.Name = "label12";
            label12.Size = new Size(107, 28);
            label12.TabIndex = 13;
            label12.Text = "Private key";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "DER", "PEM" });
            comboBox3.Location = new Point(427, 82);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(296, 28);
            comboBox3.TabIndex = 12;
            // 
            // label10
            // 
            label10.AccessibleRole = AccessibleRole.Grip;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(231, 82);
            label10.Name = "label10";
            label10.Size = new Size(100, 28);
            label10.TabIndex = 11;
            label10.Text = "Key mode";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Pink;
            ClientSize = new Size(1333, 548);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            StartPosition = FormStartPosition.Manual;
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox sigName;
        private Label label4;
        private Button button2;
        private TextBox filePDF;
        private Label label3;
        private Button button1;
        private TextBox pri;
        private Label label2;
        private Button button3;
        private Button button4;
        private TextBox sigtoVe;
        private Button button5;
        private TextBox fileVe;
        private Button button6;
        private TextBox pub;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TabPage tabPage3;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label9;
        private Label label13;
        private Button button9;
        private Label label11;
        private Label label12;
        private ComboBox comboBox3;
        private Label label10;
        private CheckBox checkBox1;
        private RichTextBox richTextBox1;
        private CheckBox checkBox2;
        private RichTextBox richTextBox2;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button7;
    }
}
