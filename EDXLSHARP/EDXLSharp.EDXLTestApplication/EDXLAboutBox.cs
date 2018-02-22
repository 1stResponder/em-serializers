// ———————————————————————–
// <copyright file="EDXLAboutBox.cs" company="EDXLSharp">
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

using System.Reflection;
using System.Windows.Forms;

namespace EDXLSharp.EDXLTestApplication
{
  /// <summary>
  /// AboutBox windows form for EDXLTestApp
  /// </summary>
  public partial class EDXLAboutBox : Form
  {
    /// <summary>
    /// Apache Open Source License
    /// </summary>
    private static string apache = "Licensed under the Apache License, Version 2.0 (the \"License\")\nYou may not use this file except in compliance with the License.\nYou may obtain a copy of the License at:\nhttp://www.apache.org/licenses/LICENSE-2.0\nUnless required by applicable law or agreed to in writing, software distributed under the License is distributed on an \"AS IS\" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.\nSee the License for the specific language governing permissions and limitations under the License.";

    /// <summary>
    /// Copyright String
    /// </summary>
    private static string copy = "\nCopyright EDXLSharp project";
    
    /// <summary>
    /// Initializes a new instance of the EDXLAboutBox class
    /// About Box for EDXLTestApp
    /// </summary>
    public EDXLAboutBox()
    {
      this.InitializeComponent();
      this.Text = string.Format("About {0}", this.AssemblyTitle);
      this.labelProductName.Text = this.AssemblyProduct;
      this.labelVersion.Text = string.Format("Version {0}", this.AssemblyVersion);
      this.labelCopyright.Text = this.AssemblyCopyright;
      this.labelCompanyName.Text = this.AssemblyCompany;
      this.textBoxDescription.Text = this.AssemblyDescription;
      this.textBoxDescription.Text = apache + copy;
    }

    #region Assembly Attribute Accessors

    /// <summary>
    /// Gets
    /// Gets the assembly title
    /// </summary>
    public string AssemblyTitle
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
        if (attributes.Length > 0)
        {
          AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
          if (titleAttribute.Title != string.Empty)
          {
            return titleAttribute.Title;
          }
        }

        return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
      }
    }

    /// <summary>
    /// Gets
    /// Get the assembly version
    /// </summary>
    public string AssemblyVersion
    {
      get
      {
        return Assembly.GetExecutingAssembly().GetName().Version.ToString();
      }
    }

    /// <summary>
    /// Gets
    /// Get the assembly description
    /// </summary>
    public string AssemblyDescription
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
        if (attributes.Length == 0)
        {
          return string.Empty;
        }

        return ((AssemblyDescriptionAttribute)attributes[0]).Description;
      }
    }

    /// <summary>
    /// Gets
    /// Get the assembly product
    /// </summary>
    public string AssemblyProduct
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
        if (attributes.Length == 0)
        {
          return string.Empty;
        }

        return ((AssemblyProductAttribute)attributes[0]).Product;
      }
    }

    /// <summary>
    /// Gets
    /// Get the assembly copyright
    /// </summary>
    public string AssemblyCopyright
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
        if (attributes.Length == 0)
        {
          return string.Empty;
        }

        return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
      }
    }

    /// <summary>
    /// Gets
    /// Get the assembly company
    /// </summary>
    public string AssemblyCompany
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
        if (attributes.Length == 0)
        {
          return string.Empty;
        }

        return ((AssemblyCompanyAttribute)attributes[0]).Company;
      }
    }
    #endregion
  }
}
