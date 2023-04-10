using System.Xml.Serialization;

namespace Gena.Templates.DS
{
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class DefaultSetForm
    {
        [XmlAttribute()]
        public bool ReadOnly { get; set; }
    }
}
