﻿using ClosedXML.Excel;
using Gena.Templates.DS;
using System.Text.RegularExpressions;

namespace Gena.Modules.MainSheets.DS
{
    internal class RulesForUserInFieldDS
    {
        //метод генерации Case для UserInField для DocumentState
        public static Case GenerateRulesForUserInFieldDS(IXLWorksheet worksheet, string columnLetter, List<InternalNames> internalNames, string userInFieldPointer)
        {
            //создаём экземпляр Case
            var rulesForUserInField = new Case()
            {
                UserInFields = userInFieldPointer,
                SetField = new List<CaseSetField>(),
                SetAction = new List<CaseSetAction>(),
                SetTab = new List<CaseSetTab>(),
                SetForm = new CaseSetForm()
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
                        rulesForUserInField.SetTab.Add(new CaseSetTab(currentInternalName.InternalName, valueInCell));
                    }
                    //Кнопки начинаются с ключевого слова DsDocument
                    else if (Regex.Match(valueInCurrentInternalNameCell, @"^DsDocument").Success)
                    {
                        rulesForUserInField.SetAction.Add(new CaseSetAction(currentInternalName.InternalName, valueInCell));
                    }
                    //Поля - всё остальное
                    else
                    {
                        rulesForUserInField.SetField.Add(new CaseSetField(currentInternalName.InternalName, valueInCell));
                    }

                    //Console.WriteLine(@"Check value in cell {0}{1}", columnLetter, currentInternalName.Address.RowNumber);

                }
            }
            return rulesForUserInField;
        }
    }
}
