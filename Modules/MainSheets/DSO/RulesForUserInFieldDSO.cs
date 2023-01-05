using ClosedXML.Excel;
using Gena.Templates.DSO;

namespace Gena.Modules.MainSheets.DSO
{
    internal class RulesForUserInFieldDSO
    {
        //метод генерации правил для UserInGroup
        public static List<FieldSettingForUserInField> GenerateRulesForUserInFieldDSO(IXLWorksheet worksheet, string columnLetter, List<InternalNames> internalNames, string userInRolePointer)
        {
            //создаём экземпляр правил для пользователя в группе
            var rulesForUserInRoles = new List<FieldSettingForUserInField>();

            string currentTypeOfObject = "Поля";

            //for each internalName generate rules in current state
            foreach (var currentInternalName in internalNames)
            {

                string? valueInCurrentInternalNameCell = Convert.ToString(currentInternalName.InternalName);

                switch (valueInCurrentInternalNameCell)
                {
                    case "Поля":
                        currentTypeOfObject = "Поля";
                        break;

                    case "Кнопки":
                        currentTypeOfObject = "Кнопки";
                        break;

                    case "Вкладки":
                        currentTypeOfObject = "Вкладки";
                        break;

                    default:
                        break;
                }


                if (valueInCurrentInternalNameCell != "" && valueInCurrentInternalNameCell != null && valueInCurrentInternalNameCell != "Поля" && valueInCurrentInternalNameCell != "Кнопки" && valueInCurrentInternalNameCell != "Вкладки" && valueInCurrentInternalNameCell != "internalNames")
                {
                    int valueInCell = Convert.ToInt32(worksheet.Cell(currentInternalName.RowNumber, columnLetter).Value);
                    switch (currentTypeOfObject)
                    {
                        case "Поля":
                            rulesForUserInRoles.Add(new FieldSettingForUserInField(currentInternalName.InternalName, valueInCell));
                            break;

                        case "Кнопки":
                            Console.WriteLine("Кнопки"); //заглушка для кнопок
                            break;

                        case "Вкладки":
                            Console.WriteLine("Вкладки"); //заглушка для вкладок
                            break;

                        default:
                            break;
                    }
                }
            }
            return rulesForUserInRoles;
        }
    }
}
