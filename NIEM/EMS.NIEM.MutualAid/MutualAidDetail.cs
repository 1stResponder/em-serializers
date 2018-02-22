using System;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using EMS.NIEM.NIEMCommon;
using System.Xml.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace EMS.NIEM.MutualAid
{

    /// <summary>
    /// Represents a mutual aid request or response 
    /// </summary>
    [XmlRootAttribute("MutualAidDetail", Namespace = Constants.MaidNamespace)]
    public class MutualAidDetail: EventDetails
    {

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the MutualAidDetail class
    /// </summary>
    public MutualAidDetail()
    {
    }

    /// <summary>
    /// Initializes a new instance of the MutualAidDetail class
    /// </summary>
    /// <param name="req">Mutual Aid Request</param>
    public MutualAidDetail(AidRequested req) : this()
    {
      Message = req;
    }

    /// <summary>
    /// Initializes a new instance of the MutualAidDetail class 
    /// </summary>
    /// <param name="res">Mutual Aid Response</param>
    public MutualAidDetail(AidResponding res) : this()
    {
      Message = res;
    }

    #endregion
    #region Public Fields

    /// <summary>
    /// Gets or sets the mutual aid request or response
    /// Required Element
    /// </summary>
    /// <exception cref="ArgumentException">If the message is not a MutualAidMessage Type</exception>
    [XmlElement("AidRequested", typeof(AidRequested), Namespace = Constants.MaidNamespace)]
    [XmlElement("AidResponding", typeof(AidResponding), Namespace = Constants.MaidNamespace)]
    public dynamic Message
    {
      get
      {
        return message;
      }
      set
      {
        if (value is MutualAidMessage)
        {
          message = value;
        }
        else
        {
          throw new ArgumentException("value", "Message must be of MutualAidMessage Type");
        }

      }
    }

    #endregion
    #region Private Fields

    /// <summary>
    /// Holds the mutual aid request or response
    /// Required Element
    /// </summary>
    [XmlIgnore]
    private dynamic message;

    #endregion

    #region Serial helper

    /// <summary>
    /// If Message is null then this should throw an error 
    /// </summary>
    /// <returns>true or false</returns>
    /// <exception cref="ArgumentNullException">If the Message is null</exception>
    public bool MessageSpecified
    {
      get
      {
        if (Message == null) throw new ArgumentNullException("Message must be specified");

        return true;
      }
    }
    #endregion

  }
}
