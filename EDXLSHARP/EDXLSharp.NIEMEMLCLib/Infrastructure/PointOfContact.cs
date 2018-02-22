//-----------------------------------------------------------------------
// <copyright file="PointOfContact.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Infrastructure
{
  /// <summary>
  /// Represents point of contact information
  /// </summary>
  [Serializable]
  public class PointOfContact
  {
    /// <summary>
    /// Name of point of contact
    /// </summary>
    /// <returns>Name of point of contact</returns>
    public string Name
    {
      get; set;
    }

    /// <summary>
    /// Phone Number
    /// </summary>
    public TelephoneNumber Phone
    {
      get; set;
    }


    /// <summary>
    /// POC Email Address
    /// </summary>
    public string EmailAddress //TODO: validate it is in the correct format
    {
      get; set;

    }

    /// <summary>
    /// Determines whether or not to serialize EmailAddress
    /// </summary>
    /// <returns>Yes or No</returns>
    public bool ShouldSerializeEmailAddress()
    {
      return !string.IsNullOrWhiteSpace(this.EmailAddress);
    }

    /// <summary>
    /// Fax number
    /// </summary>
    public TelephoneNumber Fax
    {
      get; set;
    }

    /// <summary>
    /// Determines whether or not to serialize Fax
    /// </summary>
    /// <returns>Yes or No</returns>
    public bool ShouldSerializeFax()
    {
      return this.Fax != null;
    }

    /// <summary>
    /// Radio contact information
    /// </summary>
    public string RadioContact
    {
      get; set;
    }
    
    /// <summary>
    /// Determines whether or not to serialize RadioContact
    /// </summary>
    /// <returns>Yes or No</returns>
    public bool ShouldSerializeRadioContact()
    {
      return !string.IsNullOrWhiteSpace(this.RadioContact);
    }
  }
}
