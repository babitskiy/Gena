using ClosedXML.Excel;
using Gena.Templates.DSO;

namespace Gena.Modules.MainSheets.DSO
{
    internal class RulesForDefaultDSO
    {
        //метод генерации Default для DocumentState
        public static List<FieldSettingsByState> GenerateRulesForDefaultDSO(IXLWorksheet worksheet, string columnLetter, List<InternalNames> internalNames)
        {
            //создаём экземпляр дефолта
            var rulesForDefault = new List<FieldSettingsByState>();

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


                if (valueInCurrentInternalNameCell.Trim() != "" && valueInCurrentInternalNameCell.Trim() != null && valueInCurrentInternalNameCell.Trim() != "Поля" && valueInCurrentInternalNameCell.Trim() != "Кнопки" && valueInCurrentInternalNameCell.Trim() != "Вкладки" && valueInCurrentInternalNameCell.Trim() != "internalNames")
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
