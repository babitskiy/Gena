using System.Xml.Serialization;

namespace Gena.Templates.DS
{
    [XmlType(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class Switch
    {

        [XmlElement("Case")]
        public List<Case> Case { get; set; }

        public Default Default { get; set; }
    }
}
