using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sife.MapXmlUBL
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TargetCurrencyBaseRateType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SourceCurrencyBaseRateType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RateType1))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(OrderableUnitFactorRateType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CalculationRateType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AmountRateType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:UnqualifiedDataTypes-2")]
    public partial class RateType : NumericType
    {
    }
}
