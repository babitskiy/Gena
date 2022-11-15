
using DocumentFormat.OpenXml.Wordprocessing;
using System.Xml.Linq;

public class DocumentStateDSO
{
    public int docState { get; set; }
    public string stateName { get; set; }
    public List<StateSetting> stateSettings { get; set; }
}

public class StateSetting
{
    public List<UserInField> userInField { get; set; }
    public List<UserInGroup> userInGroup { get; set; }
    public List<FieldSettingsByState> fieldSettingsByState { get; set; }
}

public class UserInField
{
    public string field { get; set; }
    public string fieldName { get; set; }
    public int priority { get; set; }
    public List<FieldSettingForUserInField> fieldSettings { get; set; }
}

public class FieldSettingForUserInField
{
    public string name { get; set; }
    public bool hidden { get; set; }
    public bool required { get; set; }
    public bool readOnly { get; set; }

    //конструктор класса
    public FieldSettingForUserInField(string internalName, int parameter)
    {
        name = internalName;
        switch (parameter)
        {
            case 0:
                readOnly = false; hidden = true; required = false;
                break;
            case 1:
                readOnly = true; hidden = false; required = false;
                break;
            case 2:
                readOnly = false; hidden = false; required = false;
                break;
            case 3:
                readOnly = false; hidden = false; required = true;
                break;
            default:
                break;
        }
    }
    public FieldSettingForUserInField() { }
}

public class UserInGroup
{
    public int groupId { get; set; }
    public string groupName { get; set; }
    public int priority { get; set; }
    public List<FieldSettingForUserInGroup> fieldSettings { get; set; }
}

public class FieldSettingForUserInGroup
{
    public string name { get; set; }
    public bool hidden { get; set; }
    public bool required { get; set; }
    public bool readOnly { get; set; }

    //конструктор класса
    public FieldSettingForUserInGroup(string internalName, int parameter)
    {
        name = internalName;
        switch (parameter)
        {
            case 0:
                readOnly = false; hidden = true; required = false;
                break;
            case 1:
                readOnly = true; hidden = false; required = false;
                break;
            case 2:
                readOnly = false; hidden = false; required = false;
                break;
            case 3:
                readOnly = false; hidden = false; required = true;
                break;
            default:
                break;
        }
    }
    public FieldSettingForUserInGroup() { }
}

public class FieldSettingsByState
{
    public string name { get; set; }
    public bool hidden { get; set; }
    public bool required { get; set; }
    public bool readOnly { get; set; }

    //конструктор класса
    public FieldSettingsByState(string internalName, int parameter)
    {
        name = internalName;
        switch (parameter)
        {
            case 0:
                readOnly = false; hidden = true; required = false;
                break;
            case 1:
                readOnly = true; hidden = false; required = false;
                break;
            case 2:
                readOnly = false; hidden = false; required = false;
                break;
            case 3:
                readOnly = false; hidden = false; required = true;
                break;
            default:
                break;
        }
    }
    public FieldSettingsByState() { }
}
