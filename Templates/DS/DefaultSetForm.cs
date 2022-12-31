namespace Gena
{
    [SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class DefaultSetForm
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ReadOnly { get; set; }
    }
}
