using System.Xml.Serialization;

namespace Gena.Templates.DS
{
    [XmlType(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class DocumentState
    {
        public Switch Switch { get; set; }

        [XmlAttribute]
        public int ID { get; set; }

        [XmlAttribute]
        public string Name { get; set; }
    }
}
