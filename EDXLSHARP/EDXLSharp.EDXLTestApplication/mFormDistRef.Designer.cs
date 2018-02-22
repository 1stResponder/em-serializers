namespace EDXLSharp.EDXLTestApplication
{
  partial class MFormDistRef
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MFormDistRef));
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.mButtonCancel = new System.Windows.Forms.Button();
      this.mTextBoxDistID = new System.Windows.Forms.TextBox();
      this.mTextBoxSenderID = new System.Windows.Forms.TextBox();
      this.mTextBoxDateTimeSent = new System.Windows.Forms.TextBox();
      this.mButtonCommit = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 5);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(76, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Distribution ID:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 30);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(58, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Sender ID:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 57);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(86, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "Date/Time Sent:";
      // 
      // mButtonCancel
      // 
      this.mButtonCancel.Location = new System.Drawing.Point(12, 85);
      this.mButtonCancel.Name = "mButtonCancel";
      this.mButtonCancel.Size = new System.Drawing.Size(75, 23);
      this.mButtonCancel.TabIndex = 3;
      this.mButtonCancel.Text = "Cancel";
      this.mButtonCancel.UseVisualStyleBackColor = true;
      this.mButtonCancel.Click += new System.EventHandler(this.MButtonCancel_Click);
      // 
      // mTextBoxDistID
      // 
      this.mTextBoxDistID.Location = new System.Drawing.Point(101, 5);
      this.mTextBoxDistID.Name = "mTextBoxDistID";
      this.mTextBoxDistID.Size = new System.Drawing.Size(292, 20);
      this.mTextBoxDistID.TabIndex = 4;
      // 
      // mTextBoxSenderID
      // 
      this.mTextBoxSenderID.Location = new System.Drawing.Point(101, 30);
      this.mTextBoxSenderID.Name = "mTextBoxSenderID";
      this.mTextBoxSenderID.Size = new System.Drawing.Size(292, 20);
      this.mTextBoxSenderID.TabIndex = 5;
      // 
      // mTextBoxDateTimeSent
      // 
      this.mTextBoxDateTimeSent.Location = new System.Drawing.Point(101, 57);
      this.mTextBoxDateTimeSent.Name = "mTextBoxDateTimeSent";
      this.mTextBoxDateTimeSent.Size = new System.Drawing.Size(292, 20);
      this.mTextBoxDateTimeSent.TabIndex = 6;
      // 
      // mButtonCommit
      // 
      this.mButtonCommit.Location = new System.Drawing.Point(317, 85);
      this.mButtonCommit.Name = "mButtonCommit";
      this.mButtonCommit.Size = new System.Drawing.Size(75, 23);
      this.mButtonCommit.TabIndex = 7;
      this.mButtonCommit.Text = "Commit";
      this.mButtonCommit.UseVisualStyleBackColor = true;
      this.mButtonCommit.Click += new System.EventHandler(this.MButtonCommit_Click);
      // 
      // MFormDistRef
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(414, 128);
      this.Controls.Add(this.mButtonCommit);
      this.Controls.Add(this.mTextBoxDateTimeSent);
      this.Controls.Add(this.mTextBoxSenderID);
      this.Controls.Add(this.mTextBoxDistID);
      this.Controls.Add(this.mButtonCancel);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MFormDistRef";
      this.Text = "Distribution Reference";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button mButtonCancel;
    private System.Windows.Forms.TextBox mTextBoxDistID;
    private System.Windows.Forms.TextBox mTextBoxSenderID;
    private System.Windows.Forms.TextBox mTextBoxDateTimeSent;
    private System.Windows.Forms.Button mButtonCommit;
  }
}