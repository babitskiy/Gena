namespace Gena.Templates.DS
{
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class DefaultSetForm
    {
        [System.Xml.Serialization.XmlAttribute()]
        public bool ReadOnly { get; set; }
    }
}
