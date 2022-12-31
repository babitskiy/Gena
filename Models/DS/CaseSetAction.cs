namespace Gena
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class CaseSetAction
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ID { get; set; }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Visible { get; set; }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Enable { get; set; }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Force { get; set; }

        //конструктор класса
        public CaseSetAction(string internalName, int parameter)
        {
            ID = internalName;
            switch (parameter)
            {
                case 0:
                    Visible = false; Enable = false; Force = true;
                    break;
                case 1:
                    Visible = true; Enable = false; Force = true;
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
