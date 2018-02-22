using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon.Geo4NIEM
{
    /// <summary>
    /// Abstract base class to inherit when the derived class needs a "uom" attribute and a non-wrapped
    /// double.
    /// </summary>
    public abstract partial class UOM_SerializedNumber
    {
    /// <summary>
    /// Initializes the  UOM_SerializedNumber class
    /// </summary>
    public UOM_SerializedNumber()
        {
            this.Value = 0;
        }

    /// <summary>
    /// Initializes the  UOM_SerializedNumber class
    /// </summary>
    public UOM_SerializedNumber(double value) : this()
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the value for the uom attribute
        /// </summary>
        [XmlAttribute("uom", Form = XmlSchemaForm.None)]
        public string UnitOfMeasure
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the underlying double value associated with objects of this type.
        /// </summary>
        [XmlIgnore]
        public double Value
        { get; set; }

        /// <summary>
        /// Provides serialization/deserialization translation for the underlying double value.
        /// </summary>
        [XmlText]
        public string ValueSerialized
        {
            get
            {
                return this.Value.ToString();
            }
            set
            {
                try
                {
                    this.Value = Convert.ToDouble(value);
                }
                catch (Exception ex)
                {
                    this.Value = 0;
                }
            }
        }
    }
}
