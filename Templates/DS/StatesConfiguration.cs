using System.Xml.Serialization;

namespace Gena.Templates.DS
{
    [XmlType(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    [XmlRoot(Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states", IsNullable = false)]
    public class StatesConfiguration
    {
        [XmlArrayItem("DocumentState", IsNullable = false)]
        public List<DocumentState> DocumentStates { get; set; }
    }
}
