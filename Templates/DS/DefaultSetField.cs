using System.Xml.Serialization;

namespace Gena.Templates.DS
{
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class DefaultSetField
    {
        [XmlAttribute()]
        public string Name { get; set; }

        [XmlAttribute()]
        public bool ReadOnly { get; set; }

        [XmlAttribute()]
        public bool Hidden { get; set; }

        [XmlAttribute()]
        public bool Required { get; set; }

        //конструктор класса
        public DefaultSetField(string internalName, int parameter)
        {
            Name = internalName;
            switch (parameter)
            {
                case 0:
                    Hidden = true;
                    break;
                case 1:
                    ReadOnly = true;
                    break;
                case 3:
                    Required = true;
                    break;
                default:
                    break;
            }
        }
        public DefaultSetField() { }
    }
}
