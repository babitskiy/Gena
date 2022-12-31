using System.Xml.Serialization;

namespace Gena
{
    [XmlType(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class Switch
    {

        [System.Xml.Serialization.XmlElementAttribute("Case")]
        public List<Case> Case { get; set; }

        public Default Default { get; set; }
    }
}
