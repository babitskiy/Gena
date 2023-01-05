using ClosedXML.Excel;
using Gena.Templates.DS;
using System.Text.RegularExpressions;

namespace Gena.Modules.MainSheets.DS
{
    internal class RulesForDefaultDS
    {
        //метод генерации Default для DocumentState
        public static Default GenerateRulesForDefaultDS(IXLWorksheet worksheet, string columnLetter, List<InternalNames> internalNames)
        {
            var rulesForDefault = new Default()
            {
                SetField = new List<DefaultSetField>(),
                SetAction = new List<DefaultSetAction>(),
                SetTab = new List<DefaultSetTab>(),
                SetForm = new DefaultSetForm()
                {
                    ReadOnly = false
                }
            };

            //for each internalName generate rules in current state
            foreach (var currentInternalName in internalNames)
            {
                string? valueInCurrentInternalNameCell = Convert.ToString(currentInternalName.InternalName).Trim();

                if (valueInCurrentInternalNameCell != "" && valueInCurrentInternalNameCell != null && valueInCurrentInternalNameCell != "Поля" && valueInCurrentInternalNameCell != "Кнопки" && valueInCurrentInternalNameCell != "Вкладки" && valueInCurrentInternalNameCell != "internalNames")
                {
                    int valueInCell = Convert.ToInt32(worksheet.Cell(currentInternalName.RowNumber, columnLetter).Value);

                    //Табы начинаются с ключевого слова Ribbon
                    if (Regex.Match(valueInCurrentInternalNameCell, @"^Ribbon").Success)
                    {
                        rulesForDefault.SetTab.Add(new DefaultSetTab(currentInternalName.InternalName, valueInCell));
                    }
                    //Кнопки начинаются с ключевого слова DsDocument
                    else if (Regex.Match(valueInCurrentInternalNameCell, @"^DsDocument").Success)
                    {
                        rulesForDefault.SetAction.Add(new DefaultSetAction(currentInternalName.InternalName, valueInCell));
                    }
                    //Поля - всё остальное
                    else
                    {
                        rulesForDefault.SetField.Add(new DefaultSetField(currentInternalName.InternalName, valueInCell));
                    }

                    //Console.WriteLine(@"Check value in cell {0}{1}", columnLetter, currentInternalName.Address.RowNumber);
                }
            }
            return rulesForDefault;
        }
    }
}
