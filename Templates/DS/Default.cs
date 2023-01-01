namespace Gena.Templates.DS
{

    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class Default
    {
        [System.Xml.Serialization.XmlElement("SetField")]
        public List<DefaultSetField> SetField { get; set; }

        [System.Xml.Serialization.XmlElement("SetAction")]
        public List<DefaultSetAction> SetAction { get; set; }

        [System.Xml.Serialization.XmlElement("SetTab")]
        public List<DefaultSetTab> SetTab { get; set; }

        public DefaultSetForm SetForm { get; set; }
    }
}
