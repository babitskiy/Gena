using ClosedXML.Excel;
using Gena.Templates.DS;
using System.Text.RegularExpressions;

namespace Gena.Modules.MainSheets.DS
{
    internal class RulesForUserInRole
    {
        //метод генерации Case для UserInRole для DocumentState
        public static Case GenerateRulesForUserInRoles(IXLWorksheet worksheet, string columnLetter, List<InternalNames> INs, string userInRolePointer)
        {
            //создаём экземпляр Case
            var rulesForUserInRoles = new Case()
            {
                UserInRoles = userInRolePointer,
                SetField = new List<CaseSetField>(),
                SetAction = new List<CaseSetAction>(),
                SetTab = new List<CaseSetTab>(),
                SetForm = new CaseSetForm()
                {
                    ReadOnly = false
                }
            };

            //for each internalName generate rules in current state
            foreach (var currentInternalName in INs)
            {
                string? valueInCurrentInternalNameCell = Convert.ToString(currentInternalName.InternalName).Trim();

                if (valueInCurrentInternalNameCell != "" && valueInCurrentInternalNameCell != null && valueInCurrentInternalNameCell != "Поля" && valueInCurrentInternalNameCell != "Кнопки" && valueInCurrentInternalNameCell != "Вкладки" && valueInCurrentInternalNameCell != "internalNames")
                {
                    int valueInCell = Convert.ToInt32(worksheet.Cell(currentInternalName.RowNumber, columnLetter).Value);

                    //Табы начинаются с ключевого слова Ribbon
                    if (Regex.Match(valueInCurrentInternalNameCell, @"^Ribbon").Success)
                    {
                        rulesForUserInRoles.SetTab.Add(new CaseSetTab(currentInternalName.InternalName, valueInCell));
                    }
                    //Кнопки начинаются с ключевого слова DsDocument
                    else if (Regex.Match(valueInCurrentInternalNameCell, @"^DsDocument").Success)
                    {
                        rulesForUserInRoles.SetAction.Add(new CaseSetAction(currentInternalName.InternalName, valueInCell));
                    }
                    //Поля - всё остальное
                    else
                    {
                        rulesForUserInRoles.SetField.Add(new CaseSetField(currentInternalName.InternalName, valueInCell));
                    }

                    //Console.WriteLine(@"Check value in cell {0}{1}", columnLetter, currentInternalName.Address.RowNumber);
                }
            }
            return rulesForUserInRoles;
        }
    }
}
