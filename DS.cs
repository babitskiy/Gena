using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gena
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states", IsNullable = false)]
    public class StatesConfiguration
    {
        [System.Xml.Serialization.XmlArrayItemAttribute("DocumentState", IsNullable = false)]
        public List<DocumentState> DocumentStates { get; set; }
    }


    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class DocumentState
    {
        private object preActionsField;

        private Switch switchField;

        private int idField;

        private string nameField;

        public object PreActions { get; set; }

        public Switch Switch { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int ID { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name { get; set; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class Switch
    {
        private List<Case> caseField;

        private Default defaultField;

        [System.Xml.Serialization.XmlElementAttribute("Case")]
        public List<Case> Case { get; set; }

        public Default Default { get; set; }
    }


    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class Case
    {

        private List<CaseSetField> setFieldField;

        private List<CaseSetAction> setActionField;

        private List<CaseSetTab> setTabField;

        private CaseSetForm setFormField;

        private string userInRolesField;

        private string userInFieldsField;


        [System.Xml.Serialization.XmlElementAttribute("SetField")]
        public List<CaseSetField> SetField { get; set; }


        [System.Xml.Serialization.XmlElementAttribute("SetAction")]
        public List<CaseSetAction> SetAction { get; set; }


        [System.Xml.Serialization.XmlElementAttribute("SetTab")]
        public List<CaseSetTab> SetTab { get; set; }

        public CaseSetForm SetForm { get; set; }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UserInRoles { get; set; }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UserInFields { get; set; }
    }


    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class CaseSetField
    {

        private string nameField;

        private bool readOnlyField;

        private bool hiddenField;

        private bool requiredField;


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name { get; set; }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ReadOnly { get; set; }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Hidden { get; set; }


        [System.Xml.Serialization.XmlAttributeAttribute()]
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


    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class CaseSetAction
    {

        private string idField;

        private bool visibleField;

        private bool enableField;

        private bool forceField;


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

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class CaseSetTab
    {

        private string idField;

        private bool hiddenField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ID { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
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


    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class CaseSetForm
    {

        private bool readOnlyField;


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ReadOnly { get; set; }
    }


    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class Default
    {

        private List<DefaultSetField> setFieldField;

        private List<DefaultSetAction> setActionField;

        private List<DefaultSetTab> setTabField;

        private DefaultSetForm setFormField;


        [System.Xml.Serialization.XmlElementAttribute("SetField")]
        public List<DefaultSetField> SetField { get; set; }


        [System.Xml.Serialization.XmlElementAttribute("SetAction")]
        public List<DefaultSetAction> SetAction { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("SetTab")]
        public List<DefaultSetTab> SetTab { get; set; }

        public DefaultSetForm SetForm { get; set; }
    }


    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class DefaultSetField
    {

        private string nameField;

        private bool readOnlyField;

        private bool hiddenField;

        private bool requiredField;


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


    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class DefaultSetAction
    {

        private string idField;

        private bool visibleField;

        private bool enableField;

        private bool forceField;


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ID { get; set; }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Visible { get; set; }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Enable { get; set; }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Force { get; set; }

        //конструктор класса
        public DefaultSetAction(string internalName, int parameter)
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
        public DefaultSetAction() { }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public partial class DefaultSetTab
    {

        private string idField;

        private bool hiddenField;

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

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.conteq.ru/sharepoint/v4/configuration/states")]
    public class DefaultSetForm
    {

        private bool readOnlyField;


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ReadOnly { get; set; }
    }
}
