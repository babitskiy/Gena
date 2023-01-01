using System.Xml.Serialization;

namespace Gena.Templates.DS
{
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class Case
    {
        [XmlElement("SetField")]
        public List<CaseSetField> SetField { get; set; }


        [XmlElement("SetAction")]
        public List<CaseSetAction> SetAction { get; set; }


        [XmlElement("SetTab")]
        public List<CaseSetTab> SetTab { get; set; }

        public CaseSetForm SetForm { get; set; }

        [XmlAttribute()]
        public string UserInRoles { get; set; }


        [XmlAttribute()]
        public string UserInFields { get; set; }
    }
}
