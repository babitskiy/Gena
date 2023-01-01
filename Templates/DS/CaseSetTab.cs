namespace Gena.Templates.DS
{
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class CaseSetTab
    {
        [System.Xml.Serialization.XmlAttribute()]
        public string ID { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public bool Hidden { get; set; }

        public CaseSetTab(string internalName, int parameter)
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
        public CaseSetTab() { }
    }
}
