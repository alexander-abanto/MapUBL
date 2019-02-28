using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sife.MapXmlUBL
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TierRatePercentType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TargetServicePercentType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SettlementDiscountPercentType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ReliabilityPercentType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ProgressPercentType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PercentType1))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PenaltySurchargePercentType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PaymentPercentType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ParticipationPercentType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PartecipationPercentType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MinimumPercentType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MaximumPercentType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(HumidityPercentType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AirFlowPercentType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:UnqualifiedDataTypes-2")]
    public partial class PercentType : NumericType
    {
    }
}
