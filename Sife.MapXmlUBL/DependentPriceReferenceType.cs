using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sife.MapXmlUBL
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    [System.Xml.Serialization.XmlRootAttribute("DependentPriceReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
    public partial class DependentPriceReferenceType
    {

        private PercentType1 percentField;

        private AddressType locationAddressField;

        private LineReferenceType dependentLineReferenceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public PercentType1 Percent
        {
            get
            {
                return this.percentField;
            }
            set
            {
                this.percentField = value;
            }
        }

        /// <remarks/>
        public AddressType LocationAddress
        {
            get
            {
                return this.locationAddressField;
            }
            set
            {
                this.locationAddressField = value;
            }
        }

        /// <remarks/>
        public LineReferenceType DependentLineReference
        {
            get
            {
                return this.dependentLineReferenceField;
            }
            set
            {
                this.dependentLineReferenceField = value;
            }
        }
    }
}
