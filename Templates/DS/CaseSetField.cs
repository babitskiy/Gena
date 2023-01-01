namespace Gena.Templates.DS
{
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class CaseSetField
    {
        [System.Xml.Serialization.XmlAttribute()]
        public string Name { get; set; }


        [System.Xml.Serialization.XmlAttribute()]
        public bool ReadOnly { get; set; }


        [System.Xml.Serialization.XmlAttribute()]
        public bool Hidden { get; set; }


        [System.Xml.Serialization.XmlAttribute()]
        public bool Required { get; set; }

        //конструктор класса
        public CaseSetField(string internalName, int parameter)
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
        public CaseSetField() { }
    }
}
