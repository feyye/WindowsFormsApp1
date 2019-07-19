using System.Windows.Forms;

namespace WindowsFormsApp1
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
            this.mainSerialOpenBtn = new System.Windows.Forms.Button();
            this.mainSerialComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MainRTXCheckBox = new System.Windows.Forms.CheckBox();
            this.MainDTRCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mainRateComboBox = new System.Windows.Forms.ComboBox();
            this.mainTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mainRSSIThreshold = new System.Windows.Forms.TextBox();
            this.testBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.mainSendTextBox = new System.Windows.Forms.TextBox();
            this.mainSend = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.followSerialOpenBtn = new System.Windows.Forms.Button();
            this.followTextBox = new System.Windows.Forms.TextBox();
            this.followSerialComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.followSendTextBox = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.followRateComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.followDTRCheckBox = new System.Windows.Forms.CheckBox();
            this.followRTXCheckBox = new System.Windows.Forms.CheckBox();
            this.followRSSIThreshold = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSerialOpenBtn
            // 
            this.mainSerialOpenBtn.Location = new System.Drawing.Point(233, 484);
            this.mainSerialOpenBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainSerialOpenBtn.Name = "mainSerialOpenBtn";
            this.mainSerialOpenBtn.Size = new System.Drawing.Size(88, 26);
            this.mainSerialOpenBtn.TabIndex = 0;
            this.mainSerialOpenBtn.Text = "open";
            this.mainSerialOpenBtn.UseVisualStyleBackColor = true;
            this.mainSerialOpenBtn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // mainSerialComboBox
            // 
            this.mainSerialComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mainSerialComboBox.FormattingEnabled = true;
            this.mainSerialComboBox.Location = new System.Drawing.Point(65, 482);
            this.mainSerialComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainSerialComboBox.Name = "mainSerialComboBox";
            this.mainSerialComboBox.Size = new System.Drawing.Size(140, 25);
            this.mainSerialComboBox.TabIndex = 1;
            this.mainSerialComboBox.SelectedIndexChanged +=
                new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 484);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "com：";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // MainRTXCheckBox
            // 
            this.MainRTXCheckBox.AutoSize = true;
            this.MainRTXCheckBox.Location = new System.Drawing.Point(4, 517);
            this.MainRTXCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MainRTXCheckBox.Name = "MainRTXCheckBox";
            this.MainRTXCheckBox.Size = new System.Drawing.Size(49, 21);
            this.MainRTXCheckBox.TabIndex = 3;
            this.MainRTXCheckBox.Text = "RTS";
            this.MainRTXCheckBox.UseVisualStyleBackColor = true;
            this.MainRTXCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // MainDTRCheckBox
            // 
            this.MainDTRCheckBox.AutoSize = true;
            this.MainDTRCheckBox.Location = new System.Drawing.Point(65, 518);
            this.MainDTRCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MainDTRCheckBox.Name = "MainDTRCheckBox";
            this.MainDTRCheckBox.Size = new System.Drawing.Size(51, 21);
            this.MainDTRCheckBox.TabIndex = 4;
            this.MainDTRCheckBox.Text = "DTR";
            this.MainDTRCheckBox.UseVisualStyleBackColor = true;
            this.MainDTRCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 518);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "baudRate：";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // mainRateComboBox
            // 
            this.mainRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mainRateComboBox.FormattingEnabled = true;
            this.mainRateComboBox.Location = new System.Drawing.Point(201, 516);
            this.mainRateComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainRateComboBox.Name = "mainRateComboBox";
            this.mainRateComboBox.Size = new System.Drawing.Size(119, 25);
            this.mainRateComboBox.TabIndex = 6;
            this.mainRateComboBox.SelectedIndexChanged +=
                new System.EventHandler(this.rateComboBox_SelectedIndexChanged);
            // 
            // mainTextBox
            // 
            this.mainTextBox.Location = new System.Drawing.Point(-1, 1);
            this.mainTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainTextBox.Multiline = true;
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mainTextBox.Size = new System.Drawing.Size(321, 473);
            this.mainTextBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(159, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 16;
            this.label5.Text = "main";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(639, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 17;
            this.label6.Text = "follow";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 550);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 18;
            this.label7.Text = "RSSI Threshold:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // mainRSSIThreshold
            // 
            this.mainRSSIThreshold.Location = new System.Drawing.Point(105, 545);
            this.mainRSSIThreshold.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mainRSSIThreshold.Name = "mainRSSIThreshold";
            this.mainRSSIThreshold.Size = new System.Drawing.Size(100, 23);
            this.mainRSSIThreshold.TabIndex = 19;
            // 
            // testBtn
            // 
            this.testBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F);
            this.testBtn.Location = new System.Drawing.Point(749, 707);
            this.testBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(100, 50);
            this.testBtn.TabIndex = 22;
            this.testBtn.Text = "test";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testStartBtn);
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F);
            this.saveBtn.Location = new System.Drawing.Point(525, 707);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(100, 50);
            this.saveBtn.TabIndex = 23;
            this.saveBtn.Text = "save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // mainSendTextBox
            // 
            this.mainSendTextBox.Location = new System.Drawing.Point(0, 577);
            this.mainSendTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mainSendTextBox.Multiline = true;
            this.mainSendTextBox.Name = "mainSendTextBox";
            this.mainSendTextBox.Size = new System.Drawing.Size(321, 56);
            this.mainSendTextBox.TabIndex = 24;
            this.mainSendTextBox.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // mainSend
            // 
            this.mainSend.Location = new System.Drawing.Point(246, 545);
            this.mainSend.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mainSend.Name = "mainSend";
            this.mainSend.Size = new System.Drawing.Size(75, 26);
            this.mainSend.TabIndex = 25;
            this.mainSend.Text = "send";
            this.mainSend.UseVisualStyleBackColor = true;
            this.mainSend.Click += new System.EventHandler(this.mainSend_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.resultLabel.Location = new System.Drawing.Point(27, 734);
            this.resultLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(321, 23);
            this.resultLabel.TabIndex = 27;
            this.resultLabel.Text = "test 105  success 100";
            this.resultLabel.Click += new System.EventHandler(this.label9_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mainTextBox);
            this.panel1.Controls.Add(this.mainSerialOpenBtn);
            this.panel1.Controls.Add(this.mainSerialComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.mainSendTextBox);
            this.panel1.Controls.Add(this.mainSend);
            this.panel1.Controls.Add(this.mainRateComboBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.MainDTRCheckBox);
            this.panel1.Controls.Add(this.MainRTXCheckBox);
            this.panel1.Controls.Add(this.mainRSSIThreshold);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(27, 34);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 650);
            this.panel1.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.followSerialOpenBtn);
            this.panel2.Controls.Add(this.followTextBox);
            this.panel2.Controls.Add(this.followSerialComboBox);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.followSendTextBox);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.followRateComboBox);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.followDTRCheckBox);
            this.panel2.Controls.Add(this.followRTXCheckBox);
            this.panel2.Controls.Add(this.followRSSIThreshold);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Location = new System.Drawing.Point(525, 34);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(324, 650);
            this.panel2.TabIndex = 31;
            // 
            // followSerialOpenBtn
            // 
            this.followSerialOpenBtn.Location = new System.Drawing.Point(233, 479);
            this.followSerialOpenBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.followSerialOpenBtn.Name = "followSerialOpenBtn";
            this.followSerialOpenBtn.Size = new System.Drawing.Size(88, 26);
            this.followSerialOpenBtn.TabIndex = 32;
            this.followSerialOpenBtn.Text = "open";
            this.followSerialOpenBtn.UseVisualStyleBackColor = true;
            this.followSerialOpenBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // followTextBox
            // 
            this.followTextBox.Location = new System.Drawing.Point(4, 1);
            this.followTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.followTextBox.Multiline = true;
            this.followTextBox.Name = "followTextBox";
            this.followTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.followTextBox.Size = new System.Drawing.Size(321, 473);
            this.followTextBox.TabIndex = 7;
            // 
            // followSerialComboBox
            // 
            this.followSerialComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.followSerialComboBox.FormattingEnabled = true;
            this.followSerialComboBox.Location = new System.Drawing.Point(65, 482);
            this.followSerialComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.followSerialComboBox.Name = "followSerialComboBox";
            this.followSerialComboBox.Size = new System.Drawing.Size(140, 25);
            this.followSerialComboBox.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(0, 484);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "com：";
            // 
            // followSendTextBox
            // 
            this.followSendTextBox.Location = new System.Drawing.Point(0, 577);
            this.followSendTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.followSendTextBox.Multiline = true;
            this.followSendTextBox.Name = "followSendTextBox";
            this.followSendTextBox.Size = new System.Drawing.Size(321, 56);
            this.followSendTextBox.TabIndex = 24;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(246, 545);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 26);
            this.button7.TabIndex = 25;
            this.button7.Text = "send";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // followRateComboBox
            // 
            this.followRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.followRateComboBox.FormattingEnabled = true;
            this.followRateComboBox.Location = new System.Drawing.Point(201, 516);
            this.followRateComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.followRateComboBox.Name = "followRateComboBox";
            this.followRateComboBox.Size = new System.Drawing.Size(119, 25);
            this.followRateComboBox.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(117, 518);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 17);
            this.label11.TabIndex = 5;
            this.label11.Text = "baudRate：";
            // 
            // followDTRCheckBox
            // 
            this.followDTRCheckBox.AutoSize = true;
            this.followDTRCheckBox.Location = new System.Drawing.Point(65, 518);
            this.followDTRCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.followDTRCheckBox.Name = "followDTRCheckBox";
            this.followDTRCheckBox.Size = new System.Drawing.Size(51, 21);
            this.followDTRCheckBox.TabIndex = 4;
            this.followDTRCheckBox.Text = "DTR";
            this.followDTRCheckBox.UseVisualStyleBackColor = true;
            // 
            // followRTXCheckBox
            // 
            this.followRTXCheckBox.AutoSize = true;
            this.followRTXCheckBox.Location = new System.Drawing.Point(4, 517);
            this.followRTXCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.followRTXCheckBox.Name = "followRTXCheckBox";
            this.followRTXCheckBox.Size = new System.Drawing.Size(49, 21);
            this.followRTXCheckBox.TabIndex = 3;
            this.followRTXCheckBox.Text = "RTS";
            this.followRTXCheckBox.UseVisualStyleBackColor = true;
            this.followRTXCheckBox.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // followRSSIThreshold
            // 
            this.followRSSIThreshold.Location = new System.Drawing.Point(105, 545);
            this.followRSSIThreshold.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.followRSSIThreshold.Name = "followRSSIThreshold";
            this.followRSSIThreshold.Size = new System.Drawing.Size(100, 23);
            this.followRSSIThreshold.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(0, 550);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 23);
            this.label12.TabIndex = 18;
            this.label12.Text = "RSSI Threshold:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 761);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button mainSerialOpenBtn;
        private System.Windows.Forms.ComboBox mainSerialComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox MainRTXCheckBox;
        private System.Windows.Forms.CheckBox MainDTRCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox mainRSSIThreshold;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox mainSendTextBox;
        private System.Windows.Forms.Button mainSend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox mainRateComboBox;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox followTextBox;
        private System.Windows.Forms.ComboBox followSerialComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox followSendTextBox;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox followRateComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox followDTRCheckBox;
        private System.Windows.Forms.CheckBox followRTXCheckBox;
        private System.Windows.Forms.TextBox followRSSIThreshold;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button followSerialOpenBtn;
        private System.Windows.Forms.TextBox mainTextBox;
    }
}