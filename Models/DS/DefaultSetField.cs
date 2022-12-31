namespace Gena
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class DefaultSetField
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ReadOnly { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Hidden { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Required { get; set; }

        //конструктор класса
        public DefaultSetField(string internalName, int parameter)
        {
            Name = internalName;
            switch (parameter)
            {
                case 0:
                    ReadOnly = false; Hidden = true; Required = false;
                    break;
                case 1:
                    ReadOnly = true; Hidden = false; Required = false;
                    break;
                case 2:
                    ReadOnly = false; Hidden = false; Required = false;
                    break;
                case 3:
                    ReadOnly = false; Hidden = false; Required = true;
                    break;
                default:
                    break;
            }
        }
        public DefaultSetField() { }
    }
}
