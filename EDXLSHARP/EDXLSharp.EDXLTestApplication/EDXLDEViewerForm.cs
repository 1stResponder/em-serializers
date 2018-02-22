// ———————————————————————–
// <copyright file="EDXLDEViewerForm.cs" company="EDXLSharp">
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

using EDXLSharp.EDXLDELib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EDXLSharp.EDXLTestApplication
{
  /// <summary>
  /// EDXLDEViewerForm class
  /// </summary>
  public partial class EDXLDEViewerForm : Form
  {
    /// <summary>
    /// Viewer Window title
    /// </summary>
    private string formTitle;

    /// <summary>
    /// Viewer background color
    /// </summary>
    private Color backgroundColor = Color.White;

    /// <summary>
    /// EDXL List container
    /// </summary>
    private List<NameObject<string, EDXLDE>> deobjs;

    /// <summary>
    /// Initializes a new instance of the EDXLDEViewerForm class
    /// </summary>
    public EDXLDEViewerForm()
    {
      this.InitializeComponent();
    }

    /// <summary>
    /// Populate form with the values of a EDXL message
    /// </summary>
    /// <param name="title">EDXL Viewer Title</param>
    /// <param name="delist">EDXL List to be viewed</param>
    /// <param name="bgcolor">Viewer's background title</param>
    public void MLoadViewer(string title, List<EDXLDE> delist, Color bgcolor)
    {
      List<NameObject<string, EDXLDE>> nos = new List<NameObject<string, EDXLDE>>();
      foreach (object mO in delist)
      {
        nos.Add(new NameObject<string, EDXLDE>(string.Empty, (EDXLDE)mO));
      }

      this.MLoadViewer(title, nos, bgcolor);
    }
    
    /// <summary>
    /// Populate form with the values of a EDXL message
    /// </summary>
    /// <param name="title">EDXL Viewer Title</param>
    /// <param name="delist">Send/Receive EDXL list</param>
    /// <param name="bgcolor">Viewer's background title</param>
    public void MLoadViewer(string title, List<NameObject<string, EDXLDE>> delist, Color bgcolor)
    {
      this.mLabelTime.Text = System.DateTime.Now.ToShortTimeString();
      this.formTitle = title;
      this.Text = this.formTitle; // set form title.
      this.deobjs = delist;
      if (bgcolor != null)
      {
        this.backgroundColor = bgcolor; // if no color specified, used default val
      }

      this.BackColor = bgcolor;
      if (this.deobjs != null && this.deobjs.Count > 0)
      {
        this.mTextboxMessageIndex.Text = "1";
        this.mLabelMessageCount.Text = this.deobjs.Count.ToString();
        this.mButtonPrevious.Hide();
        if (this.deobjs.Count > 1)
        {
          this.mButtonNext.Show();
        }
        else
        {
          this.mButtonNext.Hide();
        }

        this.MShowEDXLDE(this.deobjs[0]);
      }
      else
      {
        this.mTextboxMessageIndex.Text = "0";
        this.mLabelMessageCount.Text = "0";
        this.mTextBoxXML.Text = "No History Available.";
      }
    }

    /// <summary>
    /// Populate EDXLViewerForm with the specified message
    /// </summary>
    /// <param name="mNO">EDXL Message to be displayed in the form</param>
    private void MShowEDXLDE(NameObject<string, EDXLDE> mNO)
    {
      if (mNO != null) 
      {
        EDXLDE deobj = (EDXLDE)mNO.Value;
        this.mLabelDistibutionID.Text = deobj.DistributionID;
        this.mLabelSenderID.Text = deobj.SenderID;
        this.mLabelDateTimeSent.Text = deobj.DateTimeSent.ToString();
        if (deobj.DistributionStatus.HasValue)
        {
          this.mLabelDistributionStatus.Text = deobj.DistributionStatus.Value.ToString();
        }

        if (deobj.DistributionType.HasValue)
        {
          this.mLabelDistributionType.Text = deobj.DistributionType.Value.ToString();
        }

        this.mLabelLanguage.Text = deobj.Language;

        // setup Explicit Address
        if (deobj.ExplicitAddress.Count > 0)
        {
          this.mComboBoxExplicitAddress.Items.Clear();
          this.mLabelExplicitAddressCount.Text = deobj.ExplicitAddress.Count.ToString();
          foreach (object obj in deobj.ExplicitAddress)
          {
            this.mComboBoxExplicitAddress.Items.Add(((ValueScheme)obj).ExplicitAddressScheme);
          }

          this.mComboBoxExplicitAddress.SelectedIndex = 0;
        }
        else
        {
          this.mComboBoxTargetArea.Items.Clear();
          this.mLabelExplicitAddressCount.Text = "0";
        }

        // setup Target Area
        if (deobj.TargetArea.Count > 0)
        {
          this.mComboBoxTargetArea.Items.Clear();
          this.mLabelTargetAreaCount.Text = deobj.TargetArea.Count.ToString();
          foreach (object obj in deobj.TargetArea)
          {
            this.mComboBoxTargetArea.Items.Add(((TargetAreaType)obj).ToString());
          }

          this.mComboBoxTargetArea.SelectedIndex = 0;
        }
        else
        {
          this.mComboBoxTargetArea.Items.Clear();
          this.mLabelTargetAreaCount.Text = "0";
        }

        // setup Content Object
        if (deobj.ContentObjects.Count > 0)
        {
          this.mComboBoxContentObject.Items.Clear();
          this.mLabelContentObjectCount.Text = deobj.ContentObjects.Count.ToString();
          foreach (object obj in deobj.ContentObjects)
          {
            this.mComboBoxContentObject.Items.Add(((ContentObject)obj).IncidentID);
          }

          this.mComboBoxContentObject.SelectedIndex = 0;
        }
        else
        {
          this.mComboBoxContentObject.Items.Clear();
          this.mLabelContentObjectCount.Text = "0";
        }

        // Routing Options
        // Sender Role
        if (deobj.SenderRole != null && deobj.SenderRole.Count > 0)
        {
          this.mComboBoxSenderRole.Items.Clear();
          this.mLabelSenderRoleCount.Text = deobj.SenderRole.Count.ToString();
          foreach (object obj in deobj.SenderRole)
          {
            this.mComboBoxSenderRole.Items.Add(((ValueList)obj).ValueListURN);
          }

          this.mComboBoxSenderRole.SelectedIndex = 0;
        }
        else
        {
          this.mComboBoxSenderRole.Items.Clear();
          this.mLabelSenderRoleCount.Text = "0";
        }

        // Recipient Role
        if (deobj.RecipientRole != null && deobj.RecipientRole.Count > 0)
        {
          this.mComboRecipientRole.Items.Clear();
          this.mLabelRecipientRoleCount.Text = deobj.RecipientRole.Count.ToString();
          foreach (object obj in deobj.RecipientRole)
          {
            this.mComboRecipientRole.Items.Add(((ValueList)obj).ValueListURN);
          }

          this.mComboRecipientRole.SelectedIndex = 0;
        }
        else
        {
          this.mComboRecipientRole.Items.Clear();
          this.mLabelRecipientRoleCount.Text = "0";
        }

        // Keyword
        if (deobj.Keyword != null && deobj.Keyword.Count > 0)
        {
          this.mComboBoxKeyword.Items.Clear();
          this.mLabelKeywordCount.Text = deobj.Keyword.Count.ToString();
          foreach (object obj in deobj.Keyword)
          {
            this.mComboBoxKeyword.Items.Add(((ValueList)obj).ValueListURN);
          }

          this.mComboBoxKeyword.SelectedIndex = 0;
        }
        else
        {
          this.mComboBoxKeyword.Items.Clear();
          this.mLabelKeywordCount.Text = "0";
        }

        // Distribution Reference
        if (deobj.DistributionReference != null && deobj.DistributionReference.Count > 0)
        {
          this.mComboBoxDistributionReference.Items.Clear();
          this.mLabelDistributionRefCount.Text = deobj.DistributionReference.Count.ToString();
          foreach (object obj in deobj.DistributionReference)
          {
            this.mComboBoxDistributionReference.Items.Add((string)obj);
          }

          this.mComboBoxDistributionReference.SelectedIndex = 0;
        }
        else
        {
          this.mComboBoxDistributionReference.Items.Clear();
          this.mLabelDistributionRefCount.Text = "0";
        }

        // show the xml message
        string xmltemp = null;
        try
        {
          xmltemp = deobj.WriteToXML();
          this.mTextBoxXML.Text = xmltemp;
          this.mTextBoxXML.BackColor = Color.LightGray;
        }
        catch (Exception e)
        {
          string[] temp = new string[2];
          temp[0] = "Sent non-valid xml. Reported error(s) below:";
          temp[1] = e.Message;
          this.mTextBoxXML.Lines = temp;
          this.mTextBoxXML.BackColor = Color.LightPink;
        }

        string protocolMessage = mNO.Name;
        if (protocolMessage != null && protocolMessage.Length > 0)
        {
          this.mLabelProtocol.Text = "Carrier = " + protocolMessage;
          this.mLabelProtocol.Show();
        }
        else
        {
          this.mLabelProtocol.Text = string.Empty;
          this.mLabelProtocol.Hide();
        }
      } 
    }

    /// <summary>
    /// Attempt to go the next EDXL Message in the list
    /// </summary>
    /// <param name="sender">Sender object that generated the event</param>
    /// <param name="e">Arguments associated with the event</param>
    private void MButtonNext_Click(object sender, EventArgs e)
    {
      int index = Convert.ToInt32(this.mTextboxMessageIndex.Text);
      index++;
      this.mTextboxMessageIndex.Text = index.ToString();

      if (index >= this.deobjs.Count)
      {
        this.mButtonNext.Hide();
      }

      this.mButtonPrevious.Show();
      this.MShowEDXLDE(this.deobjs[index - 1]);
    }

    /// <summary>
    /// Attempt to go to the previous message in the list
    /// </summary>
    /// <param name="sender">Sender object that generated the event</param>
    /// <param name="e">Arguments associated with the event</param>
    private void MButtonPrevious_Click(object sender, EventArgs e)
    {
      int index = Convert.ToInt32(this.mTextboxMessageIndex.Text);
      index--;
      this.mTextboxMessageIndex.Text = index.ToString();
      if (index <= 1)
      {
        this.mButtonPrevious.Hide();
      }

      if (this.deobjs.Count > 1)
      {
        this.mButtonNext.Show();
      }

      this.MShowEDXLDE(this.deobjs[index - 1]);
    }

    /// <summary>
    /// Attempt to go to the specified message in the list
    /// </summary>
    /// <param name="sender">Sender object that generated the event</param>
    /// <param name="e">Arguments associated with the event</param>
    private void MButtonJump_Click(object sender, EventArgs e)
    {
      int index = -1;
      try
      {
        index = Convert.ToInt32(this.mTextboxMessageIndex.Text);
      }
      catch (Exception exception)
      {
        exception.ToString();
        return;
      }

      if (index > 0 && index <= this.deobjs.Count)
      {
        if (index > 1)
        {
          this.mButtonPrevious.Show();
        }
        else
        {
          this.mButtonPrevious.Hide();
        }

        if (index < this.deobjs.Count)
        {
          this.mButtonNext.Show();
        }
        else
        {
          this.mButtonNext.Hide();
        }
        
        this.MShowEDXLDE(this.deobjs[index - 1]);
      }
    }

    /// <summary>
    /// View the Sender Role ValueList
    /// </summary>
    /// <param name="sender">Sender object that generated the event</param>
    /// <param name="e">Arguments associated with the event</param>
    private void MButtonViewSenderRole_Click(object sender, EventArgs e)
    {
      if (this.mComboBoxSenderRole.SelectedIndex > -1)
      {
        ValueList vl = (ValueList)this.mComboBoxSenderRole.SelectedValue;
        ValueListView vlv = new ValueListView();
        vlv.VLV(vl, "Sender Role");
      }
      else
      {
      }
    }

    /// <summary>
    /// View the RecipientRole ValueList
    /// </summary>
    /// <param name="sender">Sender object that generated the event</param>
    /// <param name="e">Arguments associated with the event</param>
    private void MButtonViewRecipientRole_Click(object sender, EventArgs e)
    {
      if (this.mComboRecipientRole.SelectedIndex > -1)
      {
        ValueList vl = (ValueList)this.mComboRecipientRole.SelectedValue;
        ValueListView vlv = new ValueListView();
        vlv.VLV(vl, "Recipient Role");
      }
    }

    /// <summary>
    /// View the Keyword ValueList
    /// </summary>
    /// <param name="sender">Sender object that generated the event</param>
    /// <param name="e">Arguments associated with the event</param>
    private void MButtonViewKeyword_Click(object sender, EventArgs e)
    {
      if (this.mComboBoxKeyword.SelectedIndex > -1)
      {
        ValueList vl = (ValueList)this.mComboBoxKeyword.SelectedValue;
        ValueListView vlv = new ValueListView();
        vlv.VLV(vl, "Keyword");
      }
    }

    /// <summary>
    /// View the DistributionReference ValueList
    /// </summary>
    /// <param name="sender">Sender object that generated the event</param>
    /// <param name="e">Arguments associated with the event</param>
    private void MButtonViewDistRef_Click(object sender, EventArgs e)
    {
      if (this.mComboBoxDistributionReference.SelectedIndex > -1)
      {
        ValueList vl = (ValueList)this.mComboBoxDistributionReference.SelectedValue;
        ValueListView vlv = new ValueListView();
        vlv.VLV(vl, "Distribution Reference");
      }
    }
  }
}
