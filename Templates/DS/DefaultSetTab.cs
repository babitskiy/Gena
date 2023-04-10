using System.Xml.Serialization;

namespace Gena.Templates.DS
{

    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class DefaultSetTab
    {
        [XmlAttribute()]
        public string ID { get; set; }

        [XmlAttribute()]
        public bool Hidden { get; set; }

        //конструктор класса
        public DefaultSetTab(string internalName, int parameter)
        {
            ID = internalName;
            Hidden = parameter == 0;
        }
        public DefaultSetTab() { }
    }
}
