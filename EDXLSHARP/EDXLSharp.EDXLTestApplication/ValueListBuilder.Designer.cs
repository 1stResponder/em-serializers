namespace EDXLSharp.EDXLTestApplication
{
  partial class MFormValueList
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
      this.mMenuStripValueListBuilder = new System.Windows.Forms.MenuStrip();
      this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.fromURIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mComboBoxURN = new System.Windows.Forms.ComboBox();
      this.mComboBoxValue = new System.Windows.Forms.ComboBox();
      this.mListBoxValues = new System.Windows.Forms.ListBox();
      this.mLabelURN = new System.Windows.Forms.Label();
      this.mLabelValues = new System.Windows.Forms.Label();
      this.mLabelValue = new System.Windows.Forms.Label();
      this.mButtonAddValue = new System.Windows.Forms.Button();
      this.mButtonCommitValueListBuilder = new System.Windows.Forms.Button();
      this.mButtonCancelValueListBuilder = new System.Windows.Forms.Button();
      this.mButtonRemoveValues = new System.Windows.Forms.Button();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripMessage = new System.Windows.Forms.ToolStripStatusLabel();
      this.mMenuStripValueListBuilder.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // mMenuStripValueListBuilder
      // 
      this.mMenuStripValueListBuilder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem});
      this.mMenuStripValueListBuilder.Location = new System.Drawing.Point(0, 0);
      this.mMenuStripValueListBuilder.Name = "mMenuStripValueListBuilder";
      this.mMenuStripValueListBuilder.Size = new System.Drawing.Size(292, 24);
      this.mMenuStripValueListBuilder.TabIndex = 0;
      this.mMenuStripValueListBuilder.Text = "menuStrip1";
      // 
      // loadToolStripMenuItem
      // 
      this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromURIToolStripMenuItem,
            this.fromFileToolStripMenuItem});
      this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
      this.loadToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
      this.loadToolStripMenuItem.Text = "Load COI Set";
      // 
      // fromURIToolStripMenuItem
      // 
      this.fromURIToolStripMenuItem.Name = "fromURIToolStripMenuItem";
      this.fromURIToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
      this.fromURIToolStripMenuItem.Text = "From URI";
      // 
      // fromFileToolStripMenuItem
      // 
      this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
      this.fromFileToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
      this.fromFileToolStripMenuItem.Text = "From File";
      // 
      // mComboBoxURN
      // 
      this.mComboBoxURN.FormattingEnabled = true;
      this.mComboBoxURN.Location = new System.Drawing.Point(71, 27);
      this.mComboBoxURN.Name = "mComboBoxURN";
      this.mComboBoxURN.Size = new System.Drawing.Size(209, 21);
      this.mComboBoxURN.TabIndex = 1;
      // 
      // mComboBoxValue
      // 
      this.mComboBoxValue.FormattingEnabled = true;
      this.mComboBoxValue.Location = new System.Drawing.Point(71, 155);
      this.mComboBoxValue.Name = "mComboBoxValue";
      this.mComboBoxValue.Size = new System.Drawing.Size(209, 21);
      this.mComboBoxValue.TabIndex = 2;
      // 
      // mListBoxValues
      // 
      this.mListBoxValues.FormattingEnabled = true;
      this.mListBoxValues.Location = new System.Drawing.Point(71, 54);
      this.mListBoxValues.Name = "mListBoxValues";
      this.mListBoxValues.Size = new System.Drawing.Size(209, 95);
      this.mListBoxValues.TabIndex = 2;
      this.mListBoxValues.TabStop = false;
      // 
      // mLabelURN
      // 
      this.mLabelURN.AutoSize = true;
      this.mLabelURN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.mLabelURN.Location = new System.Drawing.Point(13, 34);
      this.mLabelURN.Name = "mLabelURN";
      this.mLabelURN.Size = new System.Drawing.Size(38, 13);
      this.mLabelURN.TabIndex = 3;
      this.mLabelURN.Text = "URN:";
      // 
      // mLabelValues
      // 
      this.mLabelValues.AutoSize = true;
      this.mLabelValues.Location = new System.Drawing.Point(13, 54);
      this.mLabelValues.Name = "mLabelValues";
      this.mLabelValues.Size = new System.Drawing.Size(42, 13);
      this.mLabelValues.TabIndex = 4;
      this.mLabelValues.Text = "Values:";
      // 
      // mLabelValue
      // 
      this.mLabelValue.AutoSize = true;
      this.mLabelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.mLabelValue.Location = new System.Drawing.Point(13, 163);
      this.mLabelValue.Name = "mLabelValue";
      this.mLabelValue.Size = new System.Drawing.Size(43, 13);
      this.mLabelValue.TabIndex = 5;
      this.mLabelValue.Text = "Value:";
      // 
      // mButtonAddValue
      // 
      this.mButtonAddValue.Location = new System.Drawing.Point(204, 183);
      this.mButtonAddValue.Name = "mButtonAddValue";
      this.mButtonAddValue.Size = new System.Drawing.Size(75, 23);
      this.mButtonAddValue.TabIndex = 3;
      this.mButtonAddValue.Text = "AddValue";
      this.mButtonAddValue.UseVisualStyleBackColor = true;
      this.mButtonAddValue.Click += new System.EventHandler(this.MButtonAddValue_Click);
      // 
      // mButtonCommitValueListBuilder
      // 
      this.mButtonCommitValueListBuilder.Location = new System.Drawing.Point(152, 212);
      this.mButtonCommitValueListBuilder.Name = "mButtonCommitValueListBuilder";
      this.mButtonCommitValueListBuilder.Size = new System.Drawing.Size(75, 23);
      this.mButtonCommitValueListBuilder.TabIndex = 4;
      this.mButtonCommitValueListBuilder.Text = "Commit";
      this.mButtonCommitValueListBuilder.UseVisualStyleBackColor = true;
      this.mButtonCommitValueListBuilder.Click += new System.EventHandler(this.MButtonCommitValueListBuilder_Click);
      // 
      // mButtonCancelValueListBuilder
      // 
      this.mButtonCancelValueListBuilder.Location = new System.Drawing.Point(71, 212);
      this.mButtonCancelValueListBuilder.Name = "mButtonCancelValueListBuilder";
      this.mButtonCancelValueListBuilder.Size = new System.Drawing.Size(75, 23);
      this.mButtonCancelValueListBuilder.TabIndex = 8;
      this.mButtonCancelValueListBuilder.TabStop = false;
      this.mButtonCancelValueListBuilder.Text = "Cancel";
      this.mButtonCancelValueListBuilder.UseVisualStyleBackColor = true;
      this.mButtonCancelValueListBuilder.Click += new System.EventHandler(this.MButtonCancelValueListBuilder_Click);
      // 
      // mButtonRemoveValues
      // 
      this.mButtonRemoveValues.Location = new System.Drawing.Point(4, 70);
      this.mButtonRemoveValues.Name = "mButtonRemoveValues";
      this.mButtonRemoveValues.Size = new System.Drawing.Size(61, 35);
      this.mButtonRemoveValues.TabIndex = 9;
      this.mButtonRemoveValues.Text = "Remove Values";
      this.mButtonRemoveValues.UseVisualStyleBackColor = true;
      this.mButtonRemoveValues.Click += new System.EventHandler(this.MButtonRemoveValues_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripMessage});
      this.statusStrip1.Location = new System.Drawing.Point(0, 244);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(292, 22);
      this.statusStrip1.TabIndex = 10;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(58, 17);
      this.toolStripStatusLabel1.Text = "Last error:";
      // 
      // toolStripMessage
      // 
      this.toolStripMessage.Name = "toolStripMessage";
      this.toolStripMessage.Size = new System.Drawing.Size(0, 17);
      this.toolStripMessage.Visible = false;
      // 
      // mFormValueList
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 266);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.mButtonRemoveValues);
      this.Controls.Add(this.mButtonCancelValueListBuilder);
      this.Controls.Add(this.mButtonCommitValueListBuilder);
      this.Controls.Add(this.mButtonAddValue);
      this.Controls.Add(this.mLabelValue);
      this.Controls.Add(this.mLabelValues);
      this.Controls.Add(this.mLabelURN);
      this.Controls.Add(this.mListBoxValues);
      this.Controls.Add(this.mComboBoxValue);
      this.Controls.Add(this.mComboBoxURN);
      this.Controls.Add(this.mMenuStripValueListBuilder);
      this.MainMenuStrip = this.mMenuStripValueListBuilder;
      this.Name = "mFormValueList";
      this.Text = "Value List Builder";
      this.mMenuStripValueListBuilder.ResumeLayout(false);
      this.mMenuStripValueListBuilder.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

      this.mValueList = null;

    }

    #endregion

    private System.Windows.Forms.MenuStrip mMenuStripValueListBuilder;
    private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem fromURIToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem fromFileToolStripMenuItem;
    private System.Windows.Forms.ComboBox mComboBoxURN;
    private System.Windows.Forms.ComboBox mComboBoxValue;
    private System.Windows.Forms.ListBox mListBoxValues;
    private System.Windows.Forms.Label mLabelURN;
    private System.Windows.Forms.Label mLabelValues;
    private System.Windows.Forms.Label mLabelValue;
    private System.Windows.Forms.Button mButtonAddValue;
    private System.Windows.Forms.Button mButtonCommitValueListBuilder;
    private System.Windows.Forms.Button mButtonCancelValueListBuilder;
    private System.Windows.Forms.Button mButtonRemoveValues;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripMessage;

    public ValueList mValueList;
  }
}