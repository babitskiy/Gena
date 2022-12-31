namespace Gena
{

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class DefaultSetTab
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ID { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Hidden { get; set; }

        //конструктор класса
        public DefaultSetTab(string internalName, int parameter)
        {
            ID = internalName;
            switch (parameter)
            {
                case 0:
                    Hidden = true;
                    break;
                case 2:
                    Hidden = false;
                    break;
                default:
                    break;
            }
        }
        public DefaultSetTab() { }
    }
}
