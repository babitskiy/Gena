using System.Xml.Serialization;

namespace Gena.Templates.DS
{
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class CaseSetAction
    {
        [XmlAttribute()]
        public string ID { get; set; }


        [XmlAttribute()]
        public bool Visible { get; set; }


        [XmlAttribute()]
        public bool Enable { get; set; }


        [XmlAttribute()]
        public bool Force { get; set; }

        //конструктор класса
        public CaseSetAction(string internalName, int parameter)
        {
            ID = internalName;
            switch (parameter)
            {
                case 0:
                    Force = true;
                    break;
                case 1:
                    Visible = true; Force = true;
                    break;
                case 2:
                    Visible = true; Enable = true; Force = true;
                    break;
                default:
                    break;
            }
        }
        public CaseSetAction() { }
    }
}
