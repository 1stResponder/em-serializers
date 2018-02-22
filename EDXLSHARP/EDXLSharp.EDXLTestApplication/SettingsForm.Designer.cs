namespace EDXLSharp.EDXLTestApplication
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components=null;

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
            this.mButtCancelmButtCancel = new System.Windows.Forms.Button();
            this.mButtApply = new System.Windows.Forms.Button();
            this.mButtSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mTextLogFile = new System.Windows.Forms.TextBox();
            this.mSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.mButtLogBrowse = new System.Windows.Forms.Button();
            this.mTextMaxLogSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mTextPeriod = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mCheckKeepTxOpen = new System.Windows.Forms.CheckBox();
            this.mTextHistoryLength = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mTextDistributionPrefix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mTextSenderDefault = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mComboDistStatusDefault = new System.Windows.Forms.ComboBox();
            this.mComboDistTypeDefault = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.mTextConfDefault = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mCheckTCPSend = new System.Windows.Forms.CheckBox();
            this.mCheckUDPSend = new System.Windows.Forms.CheckBox();
            this.mCheckTCPRecieve = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.mTextTCPRecievePort = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.mTextUDPSendHost = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.mTextUDPSendPort = new System.Windows.Forms.TextBox();
            this.mTextTCPSendPort = new System.Windows.Forms.TextBox();
            this.mTextTCPSendHost = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.mTextUDPRecievePort = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.mCheckUDPRecieve = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mButtCancelmButtCancel
            // 
            this.mButtCancelmButtCancel.Location = new System.Drawing.Point(12, 389);
            this.mButtCancelmButtCancel.Name = "mButtCancelmButtCancel";
            this.mButtCancelmButtCancel.Size = new System.Drawing.Size(75, 23);
            this.mButtCancelmButtCancel.TabIndex = 0;
            this.mButtCancelmButtCancel.Text = "Cancel";
            this.mButtCancelmButtCancel.UseVisualStyleBackColor = true;
            this.mButtCancelmButtCancel.Click += new System.EventHandler(this.MButtCancelmButtCancel_Click);
            // 
            // mButtApply
            // 
            this.mButtApply.Location = new System.Drawing.Point(386, 389);
            this.mButtApply.Name = "mButtApply";
            this.mButtApply.Size = new System.Drawing.Size(75, 23);
            this.mButtApply.TabIndex = 1;
            this.mButtApply.Text = "Apply";
            this.mButtApply.UseVisualStyleBackColor = true;
            this.mButtApply.Click += new System.EventHandler(this.MButtApply_Click);
            // 
            // mButtSave
            // 
            this.mButtSave.Location = new System.Drawing.Point(196, 389);
            this.mButtSave.Name = "mButtSave";
            this.mButtSave.Size = new System.Drawing.Size(75, 23);
            this.mButtSave.TabIndex = 2;
            this.mButtSave.Text = "Save";
            this.mButtSave.UseVisualStyleBackColor = true;
            this.mButtSave.Click += new System.EventHandler(this.MButtSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Log File:";
            // 
            // mTextLogFile
            // 
            this.mTextLogFile.Location = new System.Drawing.Point(150, 12);
            this.mTextLogFile.Name = "mTextLogFile";
            this.mTextLogFile.Size = new System.Drawing.Size(217, 20);
            this.mTextLogFile.TabIndex = 4;
            // 
            // mButtLogBrowse
            // 
            this.mButtLogBrowse.Location = new System.Drawing.Point(373, 9);
            this.mButtLogBrowse.Name = "mButtLogBrowse";
            this.mButtLogBrowse.Size = new System.Drawing.Size(75, 23);
            this.mButtLogBrowse.TabIndex = 5;
            this.mButtLogBrowse.Text = "Browse";
            this.mButtLogBrowse.UseVisualStyleBackColor = true;
            // 
            // mTextMaxLogSize
            // 
            this.mTextMaxLogSize.Location = new System.Drawing.Point(150, 38);
            this.mTextMaxLogSize.Name = "mTextMaxLogSize";
            this.mTextMaxLogSize.Size = new System.Drawing.Size(121, 20);
            this.mTextMaxLogSize.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Max Log Size (KB):";
            // 
            // mTextPeriod
            // 
            this.mTextPeriod.Location = new System.Drawing.Point(150, 64);
            this.mTextPeriod.Name = "mTextPeriod";
            this.mTextPeriod.Size = new System.Drawing.Size(121, 20);
            this.mTextPeriod.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Period (ms):";
            // 
            // mCheckKeepTxOpen
            // 
            this.mCheckKeepTxOpen.AutoSize = true;
            this.mCheckKeepTxOpen.Location = new System.Drawing.Point(12, 352);
            this.mCheckKeepTxOpen.Name = "mCheckKeepTxOpen";
            this.mCheckKeepTxOpen.Size = new System.Drawing.Size(138, 17);
            this.mCheckKeepTxOpen.TabIndex = 10;
            this.mCheckKeepTxOpen.Text = "Keep Tx Socket Open?";
            this.mCheckKeepTxOpen.UseVisualStyleBackColor = true;
            // 
            // mTextHistoryLength
            // 
            this.mTextHistoryLength.Location = new System.Drawing.Point(150, 90);
            this.mTextHistoryLength.Name = "mTextHistoryLength";
            this.mTextHistoryLength.Size = new System.Drawing.Size(121, 20);
            this.mTextHistoryLength.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "History Length:";
            // 
            // mTextDistributionPrefix
            // 
            this.mTextDistributionPrefix.Location = new System.Drawing.Point(150, 112);
            this.mTextDistributionPrefix.Name = "mTextDistributionPrefix";
            this.mTextDistributionPrefix.Size = new System.Drawing.Size(121, 20);
            this.mTextDistributionPrefix.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Distribution Prefix:";
            // 
            // mTextSenderDefault
            // 
            this.mTextSenderDefault.Location = new System.Drawing.Point(150, 138);
            this.mTextSenderDefault.Name = "mTextSenderDefault";
            this.mTextSenderDefault.Size = new System.Drawing.Size(121, 20);
            this.mTextSenderDefault.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Sender Default:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Distribution Status Default:";
            // 
            // mComboDistStatusDefault
            // 
            this.mComboDistStatusDefault.FormattingEnabled = true;
            this.mComboDistStatusDefault.Location = new System.Drawing.Point(150, 168);
            this.mComboDistStatusDefault.Name = "mComboDistStatusDefault";
            this.mComboDistStatusDefault.Size = new System.Drawing.Size(121, 21);
            this.mComboDistStatusDefault.TabIndex = 18;
            this.mComboDistStatusDefault.Text = "Please Choose...";
            // 
            // mComboDistTypeDefault
            // 
            this.mComboDistTypeDefault.FormattingEnabled = true;
            this.mComboDistTypeDefault.Location = new System.Drawing.Point(150, 195);
            this.mComboDistTypeDefault.Name = "mComboDistTypeDefault";
            this.mComboDistTypeDefault.Size = new System.Drawing.Size(121, 21);
            this.mComboDistTypeDefault.TabIndex = 20;
            this.mComboDistTypeDefault.Text = "Please Choose...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Distribution Type Default:";
            // 
            // mTextConfDefault
            // 
            this.mTextConfDefault.Location = new System.Drawing.Point(150, 222);
            this.mTextConfDefault.Name = "mTextConfDefault";
            this.mTextConfDefault.Size = new System.Drawing.Size(121, 20);
            this.mTextConfDefault.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Confidentiality Default:";
            // 
            // mCheckTCPSend
            // 
            this.mCheckTCPSend.AutoSize = true;
            this.mCheckTCPSend.Location = new System.Drawing.Point(12, 257);
            this.mCheckTCPSend.Name = "mCheckTCPSend";
            this.mCheckTCPSend.Size = new System.Drawing.Size(123, 17);
            this.mCheckTCPSend.TabIndex = 23;
            this.mCheckTCPSend.Text = "TCP Send Enabled?";
            this.mCheckTCPSend.UseVisualStyleBackColor = true;
            // 
            // mCheckUDPSend
            // 
            this.mCheckUDPSend.AutoSize = true;
            this.mCheckUDPSend.Location = new System.Drawing.Point(12, 280);
            this.mCheckUDPSend.Name = "mCheckUDPSend";
            this.mCheckUDPSend.Size = new System.Drawing.Size(125, 17);
            this.mCheckUDPSend.TabIndex = 24;
            this.mCheckUDPSend.Text = "UDP Send Enabled?";
            this.mCheckUDPSend.UseVisualStyleBackColor = true;
            // 
            // mCheckTCPRecieve
            // 
            this.mCheckTCPRecieve.AutoSize = true;
            this.mCheckTCPRecieve.Location = new System.Drawing.Point(12, 303);
            this.mCheckTCPRecieve.Name = "mCheckTCPRecieve";
            this.mCheckTCPRecieve.Size = new System.Drawing.Size(138, 17);
            this.mCheckTCPRecieve.TabIndex = 25;
            this.mCheckTCPRecieve.Text = "TCP Recieve Enabled?";
            this.mCheckTCPRecieve.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(147, 257);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Port:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(147, 281);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Port:";
            // 
            // mTextTCPRecievePort
            // 
            this.mTextTCPRecievePort.Location = new System.Drawing.Point(182, 301);
            this.mTextTCPRecievePort.Name = "mTextTCPRecievePort";
            this.mTextTCPRecievePort.Size = new System.Drawing.Size(111, 20);
            this.mTextTCPRecievePort.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(147, 304);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Port:";
            // 
            // mTextUDPSendHost
            // 
            this.mTextUDPSendHost.Location = new System.Drawing.Point(337, 278);
            this.mTextUDPSendHost.Name = "mTextUDPSendHost";
            this.mTextUDPSendHost.Size = new System.Drawing.Size(111, 20);
            this.mTextUDPSendHost.TabIndex = 33;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(302, 281);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Host:";
            // 
            // mTextUDPSendPort
            // 
            this.mTextUDPSendPort.Location = new System.Drawing.Point(182, 278);
            this.mTextUDPSendPort.Name = "mTextUDPSendPort";
            this.mTextUDPSendPort.Size = new System.Drawing.Size(111, 20);
            this.mTextUDPSendPort.TabIndex = 34;
            // 
            // mTextTCPSendPort
            // 
            this.mTextTCPSendPort.Location = new System.Drawing.Point(182, 254);
            this.mTextTCPSendPort.Name = "mTextTCPSendPort";
            this.mTextTCPSendPort.Size = new System.Drawing.Size(111, 20);
            this.mTextTCPSendPort.TabIndex = 35;
            // 
            // mTextTCPSendHost
            // 
            this.mTextTCPSendHost.Location = new System.Drawing.Point(337, 254);
            this.mTextTCPSendHost.Name = "mTextTCPSendHost";
            this.mTextTCPSendHost.Size = new System.Drawing.Size(111, 20);
            this.mTextTCPSendHost.TabIndex = 37;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(302, 257);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "Host:";
            // 
            // mTextUDPRecievePort
            // 
            this.mTextUDPRecievePort.Location = new System.Drawing.Point(182, 327);
            this.mTextUDPRecievePort.Name = "mTextUDPRecievePort";
            this.mTextUDPRecievePort.Size = new System.Drawing.Size(111, 20);
            this.mTextUDPRecievePort.TabIndex = 40;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(147, 330);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 13);
            this.label15.TabIndex = 39;
            this.label15.Text = "Port:";
            // 
            // mCheckUDPRecieve
            // 
            this.mCheckUDPRecieve.AutoSize = true;
            this.mCheckUDPRecieve.Location = new System.Drawing.Point(12, 329);
            this.mCheckUDPRecieve.Name = "mCheckUDPRecieve";
            this.mCheckUDPRecieve.Size = new System.Drawing.Size(140, 17);
            this.mCheckUDPRecieve.TabIndex = 38;
            this.mCheckUDPRecieve.Text = "UDP Recieve Enabled?";
            this.mCheckUDPRecieve.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 424);
            this.Controls.Add(this.mTextUDPRecievePort);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.mCheckUDPRecieve);
            this.Controls.Add(this.mTextTCPSendHost);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.mTextTCPSendPort);
            this.Controls.Add(this.mTextUDPSendPort);
            this.Controls.Add(this.mTextUDPSendHost);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.mTextTCPRecievePort);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.mCheckTCPRecieve);
            this.Controls.Add(this.mCheckUDPSend);
            this.Controls.Add(this.mCheckTCPSend);
            this.Controls.Add(this.mTextConfDefault);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mComboDistTypeDefault);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.mComboDistStatusDefault);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.mTextSenderDefault);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mTextDistributionPrefix);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mTextHistoryLength);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mCheckKeepTxOpen);
            this.Controls.Add(this.mTextPeriod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mTextMaxLogSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mButtLogBrowse);
            this.Controls.Add(this.mTextLogFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mButtSave);
            this.Controls.Add(this.mButtApply);
            this.Controls.Add(this.mButtCancelmButtCancel);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mButtCancelmButtCancel;
        private System.Windows.Forms.Button mButtApply;
        private System.Windows.Forms.Button mButtSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mTextLogFile;
        private System.Windows.Forms.SaveFileDialog mSaveFileDialog;
        private System.Windows.Forms.Button mButtLogBrowse;
        private System.Windows.Forms.TextBox mTextMaxLogSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mTextPeriod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox mCheckKeepTxOpen;
        private System.Windows.Forms.TextBox mTextHistoryLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mTextDistributionPrefix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox mTextSenderDefault;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox mComboDistStatusDefault;
        private System.Windows.Forms.ComboBox mComboDistTypeDefault;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox mTextConfDefault;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox mCheckTCPSend;
        private System.Windows.Forms.CheckBox mCheckUDPSend;
        private System.Windows.Forms.CheckBox mCheckTCPRecieve;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox mTextTCPRecievePort;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox mTextUDPSendHost;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox mTextUDPSendPort;
        private System.Windows.Forms.TextBox mTextTCPSendPort;
        private System.Windows.Forms.TextBox mTextTCPSendHost;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox mTextUDPRecievePort;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox mCheckUDPRecieve;
    }
}