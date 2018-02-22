using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon
{

  /// <summary>
  /// Represents a Resource Definition
  /// </summary>
  [Serializable]
  public class ResourceDefinition
    {

    #region Constructor

    public ResourceDefinition()
    {
    }

    #endregion

    #region Public Fields
    /// <summary>
    /// Gets/Sets the string  
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 1, IsNullable = true)]
    public string Id
    {
      get
      {
        return id;
      }

      set
      {
        id = value;
      }

    }


    /// <summary>
    /// Gets/Sets the int  
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 2, IsNullable = true)]
    public int? Tier
    {
      get
      {
        return tier;
      }

      set
      {
        tier = value;
      }

    }


    /// <summary>
    /// Gets/Sets the string  
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 3, IsNullable = true)]
    public string Name
    {
      get
      {
        return name;
      }

      set
      {
        name = value;
      }

    }


    /// <summary>
    /// Gets/Sets the string  
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 4, IsNullable = true)]
    public string Status
    {
      get
      {
        return status;
      }

      set
      {
        status = value;
      }

    }


    /// <summary>
    /// Gets/Sets the string  
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 5, IsNullable = true)]
    public string StatusDescription
    {
      get
      {
        return statusDescription;
      }

      set
      {
        statusDescription = value;
      }

    }


    /// <summary>
    /// Gets/Sets the DateTime  
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 6, IsNullable = true)]
    public DateTime? Updated
    {
      get
      {
        return updated;
      }

      set
      {
        updated = value;
      }

    }


    /// <summary>
    /// Gets/Sets the DateTime  
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 7, IsNullable = true)]
    public DateTime? Released
    {
      get
      {
        return released;
      }

      set
      {
        released = value;
      }

    }


    /// <summary>
    /// Gets/Sets the string  
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 8, IsNullable = true)]
    public string Discipline
    {
      get
      {
        return discipline;
      }

      set
      {
        discipline = value;
      }

    }


    /// <summary>
    /// Gets/Sets the Discipline number
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 9, IsNullable = true)]
    public int? DisciplineNumber
    {
      get
      {
        return disciplineNumber;
      }

      set
      {
        disciplineNumber = value;
      }

    }


    /// <summary>
    /// Gets/Sets the string  
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 10, IsNullable = true)]
    public string PrimaryCoreCapability
    {
      get
      {
        return primaryCoreCapability;
      }

      set
      {
        primaryCoreCapability = value;
      }

    }


    /// <summary>
    /// Gets/Sets the string  
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 11, IsNullable = true)]
    public string SecondaryCoreCapability
    {
      get
      {
        return secondaryCoreCapability;
      }

      set
      {
        secondaryCoreCapability = value;
      }

    }


    /// <summary>
    /// Gets/Sets the ResourceSupportingCoreCapability List
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlArray("SupportingCoreCapabilities", Namespace = Constants.TNSNamespace, Order = 12, IsNullable =true)]
    [XmlArrayItem("ResourceSupportingCoreCapability", typeof(ResourceSupportingCoreCapability), Namespace = Constants.TNSNamespace)]
    public List<ResourceSupportingCoreCapability> SupportingCoreCapabilties
    {
      get
      {
        return supportingCoreCapabilties;
      }

      set
      {
        supportingCoreCapabilties = value;
      }

    }


    /// <summary>
    /// Gets/Sets the string  
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 13, IsNullable = true)]
    public string Description
    {
      get
      {
        return description;
      }

      set
      {
        description = value;
      }

    }


    /// <summary>
    /// Gets/Sets the string  
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 14, IsNullable = true)]
    public string Category
    {
      get
      {
        return category;
      }

      set
      {
        category = value;
      }

    }


    /// <summary>
    /// Gets/Sets the string  
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 15, IsNullable = true)]
    public string Kind
    {
      get
      {
        return kind;
      }

      set
      {
        kind = value;
      }

    }


    /// <summary>
    /// Gets/Sets the string  
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 16, IsNullable = true)]
    public string OverallFunction
    {
      get
      {
        return overallFunction;
      }

      set
      {
        overallFunction = value;
      }

    }


    /// <summary>
    /// Gets/Sets the string  
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 17, IsNullable = true)]
    public string CompositionOrdering
    {
      get
      {
        return compositionOrdering;
      }

      set
      {
        compositionOrdering = value;
      }

    }


    /// <summary>
    /// Gets/Sets the ResourceCapability List
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlArray("Capabilities", Namespace = Constants.TNSNamespace, Order = 18, IsNullable = true)]
    [XmlArrayItem("ResourceCapability", typeof(ResourceCapability), Namespace = Constants.TNSNamespace)]
    public List<ResourceCapability> Capabilities
    {
      get
      {
        return capabilities;
      }

      set
      {
        capabilities = value;
      }

    }


    /// <summary>
    /// Gets/Sets the ResourceComment List
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlArray("Comments", Namespace = Constants.TNSNamespace, Order = 19, IsNullable = true)]
    [XmlArrayItem("ResourceComment", typeof(ResourceComment), Namespace = Constants.TNSNamespace)]
    public List<ResourceComment> Comments
    {
      get
      {
        return comments;
      }

      set
      {
        comments = value;
      }

    }


    /// <summary>
    /// Gets/Sets the ResourceReference List
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlArray("References", Namespace = Constants.TNSNamespace, Order = 20, IsNullable = true)]
    [XmlArrayItem("ResourceReference", typeof(ResourceReference), Namespace = Constants.TNSNamespace)]
    public List<ResourceReference> References
    {
      get
      {
        return references;
      }

      set
      {
        references = value;
      }

    }


    /// <summary>
    /// Gets/Sets the ResourceNote List
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlArray("Notes", Namespace = Constants.TNSNamespace, Order = 21, IsNullable = true)]
    [XmlArrayItem("ResourceNote", typeof(ResourceNote), Namespace = Constants.TNSNamespace)]
    public List<ResourceNote> Notes
    {
      get
      {
        return notes;
      }

      set
      {
        notes = value;
      }

    }
    #endregion

    #region Private Fields
    /// <summary>
    /// Holds the Id 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private string id;

    /// <summary>
    /// Holds the Tier 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private int? tier;

    /// <summary>
    /// Holds the Name 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private string name;

    /// <summary>
    /// Holds the Status 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private string status;

    /// <summary>
    /// Holds the StatusDescription 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private string statusDescription;

    /// <summary>
    /// Holds the Updated 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private DateTime? updated;

    /// <summary>
    /// Holds the Released 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private DateTime? released;

    /// <summary>
    /// Holds the Discipline 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private string discipline;

    /// <summary>
    /// Holds the DisciolineNumber 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private int? disciplineNumber;

    /// <summary>
    /// Holds the PrimaryCoreCapability 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private string primaryCoreCapability;

    /// <summary>
    /// Holds the SecondaryCoreCapability 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private string secondaryCoreCapability;

    /// <summary>
    /// Holds the SupportingCoreCapabilties 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private List<ResourceSupportingCoreCapability> supportingCoreCapabilties;

    /// <summary>
    /// Holds the Description 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private string description;

    /// <summary>
    /// Holds the Category 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private string category;

    /// <summary>
    /// Holds the Kind 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private string kind;

    /// <summary>
    /// Holds the OverallFunction 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private string overallFunction;

    /// <summary>
    /// Holds the CompositionOrdering 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private string compositionOrdering;

    /// <summary>
    /// Holds the Capabilities 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private List<ResourceCapability> capabilities;

    /// <summary>
    /// Holds the Comments 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private List<ResourceComment> comments;

    /// <summary>
    /// Holds the References 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private List<ResourceReference> references;

    /// <summary>
    /// Holds the Notes 
    /// </summary>
    /// <remarks>
    /// Optional Element 
    /// </remarks>
    [XmlIgnore]
    private List<ResourceNote> notes;

    #endregion

    #region Helper Methods

    /// <summary>
    /// Adds the Supporting Capability to the list of supporting capabilties
    /// </summary>
    /// <param name="cap">The supporting Resource Capability</param>
    public void AddSupportingCapability(ResourceSupportingCoreCapability cap)
    {
      AddSupportingCapability(new List<ResourceSupportingCoreCapability> { cap });
    }

    /// <summary>
    /// Adds the list of Supporting Capability to the list of capabilties
    /// </summary>
    /// <param name="cap">List of supporting Resource Capabilities</param>
    public void AddSupportingCapability(List<ResourceSupportingCoreCapability> cap)
    {
      if (SupportingCoreCapabilties == null) SupportingCoreCapabilties = new List<ResourceSupportingCoreCapability>();

      SupportingCoreCapabilties.AddRange(cap);
    }

    /// <summary>
    /// Adds the list of Supporting Capability to the list of Supporting capabilties
    /// </summary>
    /// <param name="cap">List of Resource Capabilities as Array</param>
    public void AddSupportingCapability(ResourceSupportingCoreCapability[] cap)
    {
      AddSupportingCapability(cap.ToList());
    }

    /// <summary>
    /// Creates a supporting capability with the given value and adds it to the list of Supporting Capabilties
    /// </summary>
    /// <param name="name">(Optional) Name for Supporting capability</param>
    public void AddSupportingCapability(string name = null)
    {
      AddSupportingCapability(new ResourceSupportingCoreCapability(name));
    }

    /// <summary>
    /// Adds the list of Capabilities
    /// </summary>
    /// <param name="cap">List of Resource Capabilities</param>
    public void AddCapability(List<ResourceCapability> cap)
    {
      if (Capabilities == null) Capabilities = new List<ResourceCapability>();

      Capabilities.AddRange(cap);
    }

    /// <summary>
    /// Adds the list of Capabilities
    /// </summary>
    /// <param name="cap">Resource Capability</param>
    public void AddCapability(ResourceCapability cap)
    {
      AddCapability(new List<ResourceCapability> { cap });
    }

    /// <summary>
    /// Adds the list of Capabilities
    /// </summary>
    /// <param name="cap">List of Resource Capabilities as Array</param>
    public void AddCapability(ResourceCapability[] cap)
    {
      AddCapability(cap.ToList());
    }

	/// <summary>
	/// Creates a capability with the given value and adds it to the list of Capabilties
	/// </summary>
	/// <param name="resComponent">Component</param>
	/// <param name="resMetric">(Optional) Metric</param>
	/// <param name="resAbility">(Optional) Ability</param>
	/// <param name="resNote">(Optional) Notes</param>
	/// <param name="resOrder">(Optional) Order Number</param>
	/// <param name="resTypes">(Optional) List of Resource Types</param>
	public void AddCapability(string resComponent, string resMetric = null, string resAbility = null, string resNote = null, int? resOrder = null, List<ResourceCapabilityType> resTypes = null)
    {
	  if (resTypes != null)
	  {
		ResourceCapability c = new ResourceCapability(resComponent, resMetric, resAbility, resNote, resOrder, resTypes);
		AddCapability(c);
	  }
	  else
	  {
		ResourceCapability c = new ResourceCapability(resComponent, resMetric, resAbility, resNote, resOrder);
		AddCapability(c);
	  }
    }

	/// <summary>
	/// Add the given Resource Comment to the List of Comments
	/// </summary>
	/// <param name="com">Resource Comment</param>
	public void AddComment(ResourceComment com)
    {
      AddComment(new List<ResourceComment> { com });
    }

    /// <summary>
    /// Add the given Resource Comment to the List of Comments
    /// </summary>
    /// <param name="com">List of resource comment</param>
    public void AddComment(List<ResourceComment> com)
    {
      if (Comments == null) Comments = new List<ResourceComment>();

      Comments.AddRange(com);
    }

    /// <summary>
    /// Add the given Resource Comment to the List of Comments
    /// </summary>
    /// <param name="com">List of resource comment as array</param>
    public void AddComment(ResourceComment[] com)
    {
      AddComment(com.ToList());
    }

    /// <summary>
    /// Creates a Reasource comment with the given value and adds it to the List of Comments 
    /// </summary>
    /// <param name = "resComment" > Comment </ param >
    /// <param name="orderNum">(Optional) Order Number</param>
    public void AddComment(string resComment, int? orderNum = null)
    {
        ResourceComment c = new ResourceComment(resComment, orderNum);
        AddComment(c);
    }

    /// <summary>
    /// Adds the Resource Reference(s) to the list of References
    /// </summary>
    /// <param name="refer">The Resource Reference</param>
    public void AddReference(ResourceReference refer)
    {
      AddReference(new List<ResourceReference> { refer });
    }

    /// <summary>
    /// Adds the Resource Reference(s) to the list of References
    /// </summary>
    /// <param name="refer">The list of Resource References</param>
    public void AddReference(List<ResourceReference> refer)
    {
      if (References == null) References = new List<ResourceReference>();

      References.AddRange(refer);
    }

    /// <summary>
    /// Adds the Resource Reference(s) to the list of References
    /// </summary>
    /// <param name="refer">The list of Resource References as Array</param>
    public void AddReference(ResourceReference[] refer)
    {
      AddReference(refer.ToList());
    }

    /// <summary>
    /// Creates the Resource Reference(s) and adds them to the list of References
    /// </summary>
    /// <param name="resRef">Reference</param>
    /// <param name="orderNum">(Optional) Order Number</param>
    public void AddReference(string resRef, int? orderNum = null)
    {
      ResourceReference r = new ResourceReference(resRef, orderNum);
      AddReference(r);
    }

    /// <summary>
    /// Adds the List of Resource Notes(s) to the list of Notes
    /// </summary>
    /// <param name="note">Resource Notes List</param>
    public void AddNote(List<ResourceNote> note)
    {
      if(Notes == null) Notes = new List<ResourceNote>();

      Notes.AddRange(note);
    }

    /// <summary>
    /// Adds the List of Resource Notes(s) to the list of Notes
    /// </summary>
    /// <param name="note">Resource Notes List as Array</param>
    public void AddNote(ResourceNote[] note)
    {
      AddNote(note.ToList());
    }

    /// <summary>
    /// Adds the Resource Notes(s) to the list of Notes
    /// </summary>
    /// <param name="note">Resource Notes</param>
    public void AddNote(ResourceNote note)
    {
      AddNote(new List<ResourceNote> { note });
    }

    /// <summary>
    /// Creates the Resource Notes and adds them to the list of Notes
    /// </summary>
    /// <param name="resNote">Notes</param>
    /// <param name="orderNum">(Optional) Order Number</param>
    public void AddNote(string resNote, int? orderNum = null)
    {
      ResourceNote n = new ResourceNote(resNote, orderNum);
      AddNote(n);
    }

    #endregion
  }
}
