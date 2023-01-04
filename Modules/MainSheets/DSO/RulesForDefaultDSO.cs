using ClosedXML.Excel;
using Gena.Templates.DSO;

namespace Gena.Modules.MainSheets.DSO
{
    internal class RulesForDefaultDSO
    {
        //метод генерации Default для DocumentState
        public static List<FieldSettingsByState> GenerateRulesForDefaultDSO(IXLWorksheet worksheet, string columnLetter, List<InternalNames> INs)
        {
            //создаём экземпляр дефолта
            var rulesForDefault = new List<FieldSettingsByState>();

            string currentTypeOfObject = "Поля";

            //for each internalName generate rules in current state
            foreach (var currentInternalName in INs)
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
                            rulesForDefault.Add(new FieldSettingsByState(currentInternalName.InternalName, valueInCell));
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
            return rulesForDefault;
        }
    }
}
