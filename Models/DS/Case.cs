using System.Xml.Serialization;

namespace Gena
{
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class Case
    {
        [XmlElement("SetField")]
        public List<CaseSetField> SetField { get; set; }


        [XmlElement("SetAction")]
        public List<CaseSetAction> SetAction { get; set; }


        [XmlElement("SetTab")]
        public List<CaseSetTab> SetTab { get; set; }

        public CaseSetForm SetForm { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UserInRoles { get; set; }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UserInFields { get; set; }
    }
}
