using Newtonsoft.Json;
using EMS.NIEM.NIEMCommon;
using System;
using System.Xml.Serialization;

namespace EMS.NIEM.MutualAid
{
  /// <summary>
  /// Represents a specific resource
  /// </summary>
  [Serializable]
  public class SpecificResource : RequestResourceKind
  {
    #region Constructor

    /// <summary>
    /// Initializes a new instance of the SpecificResource class
    /// </summary>
    public SpecificResource()
    {
      SerialResourceIdentifier = new IdentificationID();
    }

    /// <summary>
    /// Initializes a new instance of the SpecificResource class
    /// </summary>
    /// <param name="id">Resource ID as string</param>
    public SpecificResource(string id)
    {
      ResourceIdentifier = (id != null) ? id : "";
    }

    #endregion
    #region Public Fields

    /// <summary>
    /// Gets or sets the serial id for this resource
    /// Required Element
    /// </summary>
    [XmlElement(ElementName = "ResourceIdentifier", Namespace = Constants.EmlcNamespace)]
    public IdentificationID SerialResourceIdentifier
    {
        get
        {
          return new IdentificationID(resourceIdentifier);
        }

        set
        {
          resourceIdentifier = value.ID;
        }
    }

    /// <summary>
    /// Gets/Sets the Resource ID as a string
    /// </summary>
    [XmlIgnore]
    public string ResourceIdentifier
    {
      get
      {
        return (resourceIdentifier != null) ? resourceIdentifier : "";
      }
      set
      {
        resourceIdentifier = value;
      }
    }

    #endregion

    #region Private Fields

    /// <summary>
    /// Holds the Resource ID as a string
    /// Required Element
    /// </summary>
    [XmlIgnore]
    private string resourceIdentifier;

    #endregion

    #region Helper Methods

    /// <summary>
    /// Sets the Resource Identifier
    /// </summary>
    /// <param name="id">The Resource Identifier as a string</param>
    public void SetResourceIdentifier(string id)
    {
      ResourceIdentifier = id;
    }

    /// <summary>
    /// Sets the Resource Identifier
    /// </summary>
    /// <param name="id">The Resource Identifier</param>
    public void SetResourceIdentifier(IdentificationID id)
    {
      SerialResourceIdentifier = id;
    }

    #endregion

  }
}
