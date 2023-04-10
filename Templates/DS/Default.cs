using System.Xml.Serialization;

namespace Gena.Templates.DS
{

    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class Default
    {
        [XmlElement("SetField")]
        public List<DefaultSetField> SetField { get; set; }

        [XmlElement("SetAction")]
        public List<DefaultSetAction> SetAction { get; set; }

        [XmlElement("SetTab")]
        public List<DefaultSetTab> SetTab { get; set; }

        public DefaultSetForm SetForm { get; set; }
    }
}
