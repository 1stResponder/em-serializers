// ———————————————————————–
// <copyright file="EDXLDEViewerForm.designer.cs" company="EDXLSharp">
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// ———————————————————————–
namespace EDXLSharp.EDXLTestApplication
{
  partial class EDXLDEViewerForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EDXLDEViewerForm));
      this.mButtonJump = new System.Windows.Forms.Button();
      this.mLabelOf = new System.Windows.Forms.Label();
      this.mLabelMessageCount = new System.Windows.Forms.Label();
      this.mTextboxMessageIndex = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.mLabelDistibutionID = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.mLabelSenderID = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.mLabelDateTimeSent = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.mLabelDistributionStatus = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.mLabelDistributionType = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.mLabelCombinedConfidentiality = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.mLabelLanguage = new System.Windows.Forms.Label();
      this.mTextBoxXML = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.mLabelDistributionRefCount = new System.Windows.Forms.Label();
      this.mLabelKeywordCount = new System.Windows.Forms.Label();
      this.mLabelRecipientRoleCount = new System.Windows.Forms.Label();
      this.mLabelSenderRoleCount = new System.Windows.Forms.Label();
      this.mComboBoxDistributionReference = new System.Windows.Forms.ComboBox();
      this.mComboBoxKeyword = new System.Windows.Forms.ComboBox();
      this.mComboRecipientRole = new System.Windows.Forms.ComboBox();
      this.mComboBoxSenderRole = new System.Windows.Forms.ComboBox();
      this.label15 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.mLabelContentObjectCount = new System.Windows.Forms.Label();
      this.mLabelTargetAreaCount = new System.Windows.Forms.Label();
      this.mLabelExplicitAddressCount = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.mComboBoxContentObject = new System.Windows.Forms.ComboBox();
      this.mComboBoxTargetArea = new System.Windows.Forms.ComboBox();
      this.mComboBoxExplicitAddress = new System.Windows.Forms.ComboBox();
      this.mButtonPrevious = new System.Windows.Forms.Button();
      this.mButtonNext = new System.Windows.Forms.Button();
      this.mLabelTime = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.mLabelProtocol = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // mButtonJump
      // 
      this.mButtonJump.Location = new System.Drawing.Point(261, 2);
      this.mButtonJump.Name = "mButtonJump";
      this.mButtonJump.Size = new System.Drawing.Size(75, 23);
      this.mButtonJump.TabIndex = 1;
      this.mButtonJump.Text = "Jump To";
      this.mButtonJump.UseVisualStyleBackColor = true;
      this.mButtonJump.Click += new System.EventHandler(this.MButtonJump_Click);
      // 
      // mLabelOf
      // 
      this.mLabelOf.AutoSize = true;
      this.mLabelOf.Location = new System.Drawing.Point(392, 7);
      this.mLabelOf.Name = "mLabelOf";
      this.mLabelOf.Size = new System.Drawing.Size(16, 13);
      this.mLabelOf.TabIndex = 2;
      this.mLabelOf.Text = "of";
      // 
      // mLabelMessageCount
      // 
      this.mLabelMessageCount.AutoSize = true;
      this.mLabelMessageCount.Location = new System.Drawing.Point(406, 7);
      this.mLabelMessageCount.Name = "mLabelMessageCount";
      this.mLabelMessageCount.Size = new System.Drawing.Size(55, 13);
      this.mLabelMessageCount.TabIndex = 3;
      this.mLabelMessageCount.Text = "MaxCount";
      // 
      // mTextboxMessageIndex
      // 
      this.mTextboxMessageIndex.Location = new System.Drawing.Point(342, 4);
      this.mTextboxMessageIndex.Name = "mTextboxMessageIndex";
      this.mTextboxMessageIndex.Size = new System.Drawing.Size(51, 20);
      this.mTextboxMessageIndex.TabIndex = 4;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(76, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "Distribution ID:";
      // 
      // mLabelDistibutionID
      // 
      this.mLabelDistibutionID.AutoSize = true;
      this.mLabelDistibutionID.Location = new System.Drawing.Point(151, 16);
      this.mLabelDistibutionID.Name = "mLabelDistibutionID";
      this.mLabelDistibutionID.Size = new System.Drawing.Size(35, 13);
      this.mLabelDistibutionID.TabIndex = 6;
      this.mLabelDistibutionID.Text = "label2";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 29);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(58, 13);
      this.label3.TabIndex = 7;
      this.label3.Text = "Sender ID:";
      // 
      // mLabelSenderID
      // 
      this.mLabelSenderID.AutoSize = true;
      this.mLabelSenderID.Location = new System.Drawing.Point(151, 29);
      this.mLabelSenderID.Name = "mLabelSenderID";
      this.mLabelSenderID.Size = new System.Drawing.Size(35, 13);
      this.mLabelSenderID.TabIndex = 8;
      this.mLabelSenderID.Text = "label4";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 42);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(86, 13);
      this.label5.TabIndex = 9;
      this.label5.Text = "Date/Time Sent:";
      // 
      // mLabelDateTimeSent
      // 
      this.mLabelDateTimeSent.AutoSize = true;
      this.mLabelDateTimeSent.Location = new System.Drawing.Point(151, 42);
      this.mLabelDateTimeSent.Name = "mLabelDateTimeSent";
      this.mLabelDateTimeSent.Size = new System.Drawing.Size(35, 13);
      this.mLabelDateTimeSent.TabIndex = 10;
      this.mLabelDateTimeSent.Text = "label6";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(6, 55);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(92, 13);
      this.label7.TabIndex = 11;
      this.label7.Text = "Distribution Status";
      // 
      // mLabelDistributionStatus
      // 
      this.mLabelDistributionStatus.AutoSize = true;
      this.mLabelDistributionStatus.Location = new System.Drawing.Point(151, 55);
      this.mLabelDistributionStatus.Name = "mLabelDistributionStatus";
      this.mLabelDistributionStatus.Size = new System.Drawing.Size(35, 13);
      this.mLabelDistributionStatus.TabIndex = 12;
      this.mLabelDistributionStatus.Text = "label8";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(6, 68);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(86, 13);
      this.label9.TabIndex = 13;
      this.label9.Text = "Distribution Type";
      // 
      // mLabelDistributionType
      // 
      this.mLabelDistributionType.AutoSize = true;
      this.mLabelDistributionType.Location = new System.Drawing.Point(151, 68);
      this.mLabelDistributionType.Name = "mLabelDistributionType";
      this.mLabelDistributionType.Size = new System.Drawing.Size(41, 13);
      this.mLabelDistributionType.TabIndex = 14;
      this.mLabelDistributionType.Text = "label10";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(6, 81);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(125, 13);
      this.label11.TabIndex = 15;
      this.label11.Text = "Combined  Confidentiality";
      // 
      // mLabelCombinedConfidentiality
      // 
      this.mLabelCombinedConfidentiality.AutoSize = true;
      this.mLabelCombinedConfidentiality.Location = new System.Drawing.Point(151, 81);
      this.mLabelCombinedConfidentiality.Name = "mLabelCombinedConfidentiality";
      this.mLabelCombinedConfidentiality.Size = new System.Drawing.Size(41, 13);
      this.mLabelCombinedConfidentiality.TabIndex = 16;
      this.mLabelCombinedConfidentiality.Text = "label12";
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(6, 94);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(55, 13);
      this.label13.TabIndex = 17;
      this.label13.Text = "Language";
      // 
      // mLabelLanguage
      // 
      this.mLabelLanguage.AutoSize = true;
      this.mLabelLanguage.Location = new System.Drawing.Point(151, 94);
      this.mLabelLanguage.Name = "mLabelLanguage";
      this.mLabelLanguage.Size = new System.Drawing.Size(41, 13);
      this.mLabelLanguage.TabIndex = 18;
      this.mLabelLanguage.Text = "label14";
      // 
      // mTextBoxXML
      // 
      this.mTextBoxXML.Location = new System.Drawing.Point(4, 316);
      this.mTextBoxXML.Multiline = true;
      this.mTextBoxXML.Name = "mTextBoxXML";
      this.mTextBoxXML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.mTextBoxXML.Size = new System.Drawing.Size(700, 217);
      this.mTextBoxXML.TabIndex = 19;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.mLabelDistibutionID);
      this.groupBox1.Controls.Add(this.mLabelLanguage);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label13);
      this.groupBox1.Controls.Add(this.mLabelSenderID);
      this.groupBox1.Controls.Add(this.mLabelCombinedConfidentiality);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.label11);
      this.groupBox1.Controls.Add(this.mLabelDateTimeSent);
      this.groupBox1.Controls.Add(this.mLabelDistributionType);
      this.groupBox1.Controls.Add(this.label7);
      this.groupBox1.Controls.Add(this.label9);
      this.groupBox1.Controls.Add(this.mLabelDistributionStatus);
      this.groupBox1.Location = new System.Drawing.Point(4, 31);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(347, 114);
      this.groupBox1.TabIndex = 20;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "groupBox1";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.mLabelDistributionRefCount);
      this.groupBox2.Controls.Add(this.mLabelKeywordCount);
      this.groupBox2.Controls.Add(this.mLabelRecipientRoleCount);
      this.groupBox2.Controls.Add(this.mLabelSenderRoleCount);
      this.groupBox2.Controls.Add(this.mComboBoxDistributionReference);
      this.groupBox2.Controls.Add(this.mComboBoxKeyword);
      this.groupBox2.Controls.Add(this.mComboRecipientRole);
      this.groupBox2.Controls.Add(this.mComboBoxSenderRole);
      this.groupBox2.Controls.Add(this.label15);
      this.groupBox2.Controls.Add(this.label14);
      this.groupBox2.Controls.Add(this.label12);
      this.groupBox2.Controls.Add(this.label10);
      this.groupBox2.Location = new System.Drawing.Point(4, 151);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(347, 131);
      this.groupBox2.TabIndex = 21;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Routing Fields";
      // 
      // mLabelDistributionRefCount
      // 
      this.mLabelDistributionRefCount.AutoSize = true;
      this.mLabelDistributionRefCount.Location = new System.Drawing.Point(297, 105);
      this.mLabelDistributionRefCount.Name = "mLabelDistributionRefCount";
      this.mLabelDistributionRefCount.Size = new System.Drawing.Size(41, 13);
      this.mLabelDistributionRefCount.TabIndex = 11;
      this.mLabelDistributionRefCount.Text = "label18";
      // 
      // mLabelKeywordCount
      // 
      this.mLabelKeywordCount.AutoSize = true;
      this.mLabelKeywordCount.Location = new System.Drawing.Point(297, 77);
      this.mLabelKeywordCount.Name = "mLabelKeywordCount";
      this.mLabelKeywordCount.Size = new System.Drawing.Size(41, 13);
      this.mLabelKeywordCount.TabIndex = 10;
      this.mLabelKeywordCount.Text = "label17";
      // 
      // mLabelRecipientRoleCount
      // 
      this.mLabelRecipientRoleCount.AutoSize = true;
      this.mLabelRecipientRoleCount.Location = new System.Drawing.Point(297, 49);
      this.mLabelRecipientRoleCount.Name = "mLabelRecipientRoleCount";
      this.mLabelRecipientRoleCount.Size = new System.Drawing.Size(41, 13);
      this.mLabelRecipientRoleCount.TabIndex = 9;
      this.mLabelRecipientRoleCount.Text = "label16";
      // 
      // mLabelSenderRoleCount
      // 
      this.mLabelSenderRoleCount.AutoSize = true;
      this.mLabelSenderRoleCount.Location = new System.Drawing.Point(297, 21);
      this.mLabelSenderRoleCount.Name = "mLabelSenderRoleCount";
      this.mLabelSenderRoleCount.Size = new System.Drawing.Size(35, 13);
      this.mLabelSenderRoleCount.TabIndex = 8;
      this.mLabelSenderRoleCount.Text = "label8";
      // 
      // mComboBoxDistributionReference
      // 
      this.mComboBoxDistributionReference.FormattingEnabled = true;
      this.mComboBoxDistributionReference.Location = new System.Drawing.Point(95, 102);
      this.mComboBoxDistributionReference.Name = "mComboBoxDistributionReference";
      this.mComboBoxDistributionReference.Size = new System.Drawing.Size(195, 21);
      this.mComboBoxDistributionReference.TabIndex = 7;
      // 
      // mComboBoxKeyword
      // 
      this.mComboBoxKeyword.FormattingEnabled = true;
      this.mComboBoxKeyword.Location = new System.Drawing.Point(95, 74);
      this.mComboBoxKeyword.Name = "mComboBoxKeyword";
      this.mComboBoxKeyword.Size = new System.Drawing.Size(195, 21);
      this.mComboBoxKeyword.TabIndex = 6;
      // 
      // mComboRecipientRole
      // 
      this.mComboRecipientRole.FormattingEnabled = true;
      this.mComboRecipientRole.Location = new System.Drawing.Point(95, 46);
      this.mComboRecipientRole.Name = "mComboRecipientRole";
      this.mComboRecipientRole.Size = new System.Drawing.Size(195, 21);
      this.mComboRecipientRole.TabIndex = 5;
      // 
      // mComboBoxSenderRole
      // 
      this.mComboBoxSenderRole.FormattingEnabled = true;
      this.mComboBoxSenderRole.Location = new System.Drawing.Point(95, 18);
      this.mComboBoxSenderRole.Name = "mComboBoxSenderRole";
      this.mComboBoxSenderRole.Size = new System.Drawing.Size(195, 21);
      this.mComboBoxSenderRole.TabIndex = 4;
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(6, 105);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(82, 13);
      this.label15.TabIndex = 3;
      this.label15.Text = "Distribution Ref.";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(6, 77);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(48, 13);
      this.label14.TabIndex = 2;
      this.label14.Text = "Keyword";
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(6, 49);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(77, 13);
      this.label12.TabIndex = 1;
      this.label12.Text = "Recipient Role";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(6, 21);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(66, 13);
      this.label10.TabIndex = 0;
      this.label10.Text = "Sender Role";
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.mLabelContentObjectCount);
      this.groupBox3.Controls.Add(this.mLabelTargetAreaCount);
      this.groupBox3.Controls.Add(this.mLabelExplicitAddressCount);
      this.groupBox3.Controls.Add(this.label6);
      this.groupBox3.Controls.Add(this.label4);
      this.groupBox3.Controls.Add(this.label2);
      this.groupBox3.Controls.Add(this.mComboBoxContentObject);
      this.groupBox3.Controls.Add(this.mComboBoxTargetArea);
      this.groupBox3.Controls.Add(this.mComboBoxExplicitAddress);
      this.groupBox3.Location = new System.Drawing.Point(357, 32);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(347, 113);
      this.groupBox3.TabIndex = 22;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "groupBox3";
      // 
      // mLabelContentObjectCount
      // 
      this.mLabelContentObjectCount.AutoSize = true;
      this.mLabelContentObjectCount.Location = new System.Drawing.Point(296, 80);
      this.mLabelContentObjectCount.Name = "mLabelContentObjectCount";
      this.mLabelContentObjectCount.Size = new System.Drawing.Size(41, 13);
      this.mLabelContentObjectCount.TabIndex = 8;
      this.mLabelContentObjectCount.Text = "label21";
      // 
      // mLabelTargetAreaCount
      // 
      this.mLabelTargetAreaCount.AutoSize = true;
      this.mLabelTargetAreaCount.Location = new System.Drawing.Point(296, 49);
      this.mLabelTargetAreaCount.Name = "mLabelTargetAreaCount";
      this.mLabelTargetAreaCount.Size = new System.Drawing.Size(41, 13);
      this.mLabelTargetAreaCount.TabIndex = 7;
      this.mLabelTargetAreaCount.Text = "label20";
      // 
      // mLabelExplicitAddressCount
      // 
      this.mLabelExplicitAddressCount.AutoSize = true;
      this.mLabelExplicitAddressCount.Location = new System.Drawing.Point(296, 20);
      this.mLabelExplicitAddressCount.Name = "mLabelExplicitAddressCount";
      this.mLabelExplicitAddressCount.Size = new System.Drawing.Size(41, 13);
      this.mLabelExplicitAddressCount.TabIndex = 6;
      this.mLabelExplicitAddressCount.Text = "label19";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(7, 80);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(78, 13);
      this.label6.TabIndex = 5;
      this.label6.Text = "Content Object";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(7, 49);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(63, 13);
      this.label4.TabIndex = 4;
      this.label4.Text = "Target Area";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(7, 20);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(81, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Explicit Address";
      // 
      // mComboBoxContentObject
      // 
      this.mComboBoxContentObject.FormattingEnabled = true;
      this.mComboBoxContentObject.Location = new System.Drawing.Point(94, 77);
      this.mComboBoxContentObject.Name = "mComboBoxContentObject";
      this.mComboBoxContentObject.Size = new System.Drawing.Size(196, 21);
      this.mComboBoxContentObject.TabIndex = 2;
      // 
      // mComboBoxTargetArea
      // 
      this.mComboBoxTargetArea.FormattingEnabled = true;
      this.mComboBoxTargetArea.Location = new System.Drawing.Point(94, 49);
      this.mComboBoxTargetArea.Name = "mComboBoxTargetArea";
      this.mComboBoxTargetArea.Size = new System.Drawing.Size(196, 21);
      this.mComboBoxTargetArea.TabIndex = 1;
      // 
      // mComboBoxExplicitAddress
      // 
      this.mComboBoxExplicitAddress.FormattingEnabled = true;
      this.mComboBoxExplicitAddress.Location = new System.Drawing.Point(94, 20);
      this.mComboBoxExplicitAddress.Name = "mComboBoxExplicitAddress";
      this.mComboBoxExplicitAddress.Size = new System.Drawing.Size(196, 21);
      this.mComboBoxExplicitAddress.TabIndex = 0;
      // 
      // mButtonPrevious
      // 
      this.mButtonPrevious.Location = new System.Drawing.Point(548, 2);
      this.mButtonPrevious.Name = "mButtonPrevious";
      this.mButtonPrevious.Size = new System.Drawing.Size(75, 23);
      this.mButtonPrevious.TabIndex = 25;
      this.mButtonPrevious.Text = "Previous";
      this.mButtonPrevious.UseVisualStyleBackColor = true;
      this.mButtonPrevious.Click += new System.EventHandler(this.MButtonPrevious_Click);
      // 
      // mButtonNext
      // 
      this.mButtonNext.Location = new System.Drawing.Point(629, 2);
      this.mButtonNext.Name = "mButtonNext";
      this.mButtonNext.Size = new System.Drawing.Size(75, 23);
      this.mButtonNext.TabIndex = 26;
      this.mButtonNext.Text = "Next";
      this.mButtonNext.UseVisualStyleBackColor = true;
      this.mButtonNext.Click += new System.EventHandler(this.MButtonNext_Click);
      // 
      // mLabelTime
      // 
      this.mLabelTime.AutoSize = true;
      this.mLabelTime.Location = new System.Drawing.Point(14, 7);
      this.mLabelTime.Name = "mLabelTime";
      this.mLabelTime.Size = new System.Drawing.Size(74, 13);
      this.mLabelTime.TabIndex = 27;
      this.mLabelTime.Text = "Time Updated";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(4, 297);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(142, 13);
      this.label8.TabIndex = 28;
      this.label8.Text = "Complete XML Message";
      // 
      // mLabelProtocol
      // 
      this.mLabelProtocol.AutoSize = true;
      this.mLabelProtocol.Location = new System.Drawing.Point(563, 297);
      this.mLabelProtocol.Name = "mLabelProtocol";
      this.mLabelProtocol.Size = new System.Drawing.Size(41, 13);
      this.mLabelProtocol.TabIndex = 29;
      this.mLabelProtocol.Text = "label16";
      // 
      // EDXLDEViewerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(712, 545);
      this.Controls.Add(this.mLabelProtocol);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.mLabelTime);
      this.Controls.Add(this.mButtonNext);
      this.Controls.Add(this.mButtonPrevious);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.mTextBoxXML);
      this.Controls.Add(this.mTextboxMessageIndex);
      this.Controls.Add(this.mLabelMessageCount);
      this.Controls.Add(this.mLabelOf);
      this.Controls.Add(this.mButtonJump);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "EDXLDEViewerForm";
      this.Text = "DE Viewer";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button mButtonJump;
    private System.Windows.Forms.Label mLabelOf;
    private System.Windows.Forms.Label mLabelMessageCount;
    private System.Windows.Forms.TextBox mTextboxMessageIndex;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label mLabelDistibutionID;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label mLabelSenderID;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label mLabelDateTimeSent;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label mLabelDistributionStatus;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label mLabelDistributionType;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label mLabelCombinedConfidentiality;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label mLabelLanguage;
    private System.Windows.Forms.TextBox mTextBoxXML;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox mComboBoxContentObject;
    private System.Windows.Forms.ComboBox mComboBoxTargetArea;
    private System.Windows.Forms.ComboBox mComboBoxExplicitAddress;
    private System.Windows.Forms.ComboBox mComboBoxDistributionReference;
    private System.Windows.Forms.ComboBox mComboBoxKeyword;
    private System.Windows.Forms.ComboBox mComboRecipientRole;
    private System.Windows.Forms.ComboBox mComboBoxSenderRole;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Button mButtonPrevious;
    private System.Windows.Forms.Button mButtonNext;
    private System.Windows.Forms.Label mLabelTime;
    private System.Windows.Forms.Label mLabelDistributionRefCount;
    private System.Windows.Forms.Label mLabelKeywordCount;
    private System.Windows.Forms.Label mLabelRecipientRoleCount;
    private System.Windows.Forms.Label mLabelSenderRoleCount;
    private System.Windows.Forms.Label mLabelContentObjectCount;
    private System.Windows.Forms.Label mLabelTargetAreaCount;
    private System.Windows.Forms.Label mLabelExplicitAddressCount;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label mLabelProtocol;
  }
}