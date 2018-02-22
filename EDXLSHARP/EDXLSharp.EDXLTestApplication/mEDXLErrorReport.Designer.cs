namespace EDXLSharp.EDXLTestApplication
{
  partial class MEDXLErrorReport
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MEDXLErrorReport));
      this.mLabelEDXErrors = new System.Windows.Forms.Label();
      this.mLabelCloseNote = new System.Windows.Forms.Label();
      this.mTextBoxErrorReport = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // mLabelEDXErrors
      // 
      this.mLabelEDXErrors.AutoSize = true;
      this.mLabelEDXErrors.Location = new System.Drawing.Point(13, 13);
      this.mLabelEDXErrors.Name = "mLabelEDXErrors";
      this.mLabelEDXErrors.Size = new System.Drawing.Size(64, 13);
      this.mLabelEDXErrors.TabIndex = 0;
      this.mLabelEDXErrors.Text = "Error Report";
      // 
      // mLabelCloseNote
      // 
      this.mLabelCloseNote.AutoSize = true;
      this.mLabelCloseNote.Location = new System.Drawing.Point(16, 309);
      this.mLabelCloseNote.Name = "mLabelCloseNote";
      this.mLabelCloseNote.Size = new System.Drawing.Size(372, 13);
      this.mLabelCloseNote.TabIndex = 1;
      this.mLabelCloseNote.Text = "Closing this window will clear the error report and return you to the application" +
    ".";
      // 
      // mTextBoxErrorReport
      // 
      this.mTextBoxErrorReport.Location = new System.Drawing.Point(13, 30);
      this.mTextBoxErrorReport.Multiline = true;
      this.mTextBoxErrorReport.Name = "mTextBoxErrorReport";
      this.mTextBoxErrorReport.Size = new System.Drawing.Size(589, 276);
      this.mTextBoxErrorReport.TabIndex = 2;
      // 
      // MEDXLErrorReport
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(614, 334);
      this.Controls.Add(this.mTextBoxErrorReport);
      this.Controls.Add(this.mLabelCloseNote);
      this.Controls.Add(this.mLabelEDXErrors);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MEDXLErrorReport";
      this.Text = "EDXL Error Report";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label mLabelEDXErrors;
    private System.Windows.Forms.Label mLabelCloseNote;
    private System.Windows.Forms.TextBox mTextBoxErrorReport;
  }
}