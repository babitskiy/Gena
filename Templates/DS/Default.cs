namespace Gena
{

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class Default
    {
        [System.Xml.Serialization.XmlElementAttribute("SetField")]
        public List<DefaultSetField> SetField { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("SetAction")]
        public List<DefaultSetAction> SetAction { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("SetTab")]
        public List<DefaultSetTab> SetTab { get; set; }

        public DefaultSetForm SetForm { get; set; }
    }
}
