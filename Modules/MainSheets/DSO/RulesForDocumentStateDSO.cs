using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Gena.Exceptions;
using Gena.SystemSheets;
using Gena.Templates.DSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gena.Modules.MainSheets.DSO
{
    internal class RulesForDocumentStateDSO
    {
        //метод обновления существующего StateSettings
        public static T CreateRulesForDocumentStateDSO<T>(IXLWorksheet worksheet, string columnLetter, string tempStateName, int currentStateID, List<InternalNames> INs, T lcForCurrentState, List<SheetUserInFields> userInFieldSheets, List<SheetGroups> GroupsSheetList) where T : DocumentStateDSO, new()
        {
            if (lcForCurrentState == null)
            {
                lcForCurrentState = new T()
                {
                    docState = currentStateID,
                    stateName = tempStateName,
                    stateSettings = new List<StateSetting>()
                    {
                        new StateSetting()
                        {
                            userInField = new List<UserInField>(),
                            userInGroup = new List<UserInGroup>(),
                            fieldSettingsByState = new List<FieldSettingsByState>()
                        }
                    }
                };
            }

            var userInGroupCellValue = (string)worksheet.Cell(3, columnLetter).Value;
            var userInFieldCellValue = (string)worksheet.Cell(4, columnLetter).Value;
            var checkPriorityValue = int.TryParse(worksheet.Cell(5, columnLetter).Value.ToString(), out var priorityValue);

            //если ячейка UserInGroup заполнена то вызываем генерацию правил для неё
            if (userInGroupCellValue != "" && userInGroupCellValue != "По умолчанию" && userInGroupCellValue != "Default") //проверяем есть ли в этой колонке правила для userInRoles
            {
                //проверяем указано ли в ячейке UserInGroup несколько групп, и если это так, то создаём жц для каждой
                if (userInGroupCellValue.Contains(';'))
                {
                    var groupsInCell = userInGroupCellValue.Split(';');
                    foreach (var groupInCell in groupsInCell)
                    {
                        //проверяем есть ли такая группа в списке UserInGroups, если нет - выводим ошибку
                        var gId = GroupsSheetList.Where(e => e.GroupName == groupInCell.Trim())?.FirstOrDefault()?.GroupId ?? 0;
                        if (gId == 0) throw new UniversalException($"Группа \"{groupInCell.Trim()}\" не найдена в списке UserInGroups (лист - \"{worksheet.Name.Trim()}\"; ячейка - \"{columnLetter}3\")");

                        lcForCurrentState.stateSettings[0].userInGroup.Add(new UserInGroup
                        {
                            groupId = gId,
                            groupName = groupInCell.Trim(),
                            priority = priorityValue,
                            fieldSettings = RulesForUserInGroup.GenerateRulesForUserInGroup(worksheet, columnLetter, INs, groupInCell.Trim())
                        });
                    }
                }
                else
                {
                    //проверяем есть ли такая группа в списке UserInGroups, если нет - выводим ошибку
                    var gId = GroupsSheetList.Where(e => e.GroupName == userInGroupCellValue.Trim())?.FirstOrDefault()?.GroupId ?? 0;
                    if (gId == 0) throw new UniversalException($"Группа \"{userInGroupCellValue.Trim()}\" не найдена в списке UserInGroups (лист - \"{worksheet.Name.Trim()}\"; ячейка - \"{columnLetter}3\")");

                    lcForCurrentState.stateSettings[0].userInGroup.Add(new UserInGroup
                    {
                        groupId = gId,
                        groupName = userInGroupCellValue,
                        priority = priorityValue,
                        fieldSettings = RulesForUserInGroup.GenerateRulesForUserInGroup(worksheet, columnLetter, INs, userInGroupCellValue)
                    });
                }
            }

            //если ячейка UserInField заполнена то вызываем генерацию правил для неё
            if (userInFieldCellValue != "" && userInFieldCellValue != "По умолчанию" && userInFieldCellValue != "Default") //проверяем есть ли в этой колонке правила для userInField
            {
                if (userInFieldCellValue.Contains(';'))
                {
                    var fieldsInCell = userInFieldCellValue.Split(';');
                    foreach (var fieldInCell in fieldsInCell)
                    {
                        //проверяем есть ли такое поле в списке UserInFields, если нет - выводим ошибку
                        var fName = userInFieldSheets.Where(e => e.FieldName == fieldInCell.Trim())?.FirstOrDefault()?.InternalName;
                        if (fName is null) throw new UniversalException($"Поле {fieldInCell.Trim()} не найдено в списке UserInFields (лист - \"{worksheet.Name.Trim()}\"; ячейка - \"{columnLetter}4\")");

                        lcForCurrentState.stateSettings[0].userInField.Add(new UserInField
                        {
                            field = fieldInCell.Trim(),
                            fieldName = fName,
                            priority = priorityValue,
                            fieldSettings = RulesForUserInFieldDSO.GenerateRulesForUserInFieldDSO(worksheet, columnLetter, INs, fieldInCell.Trim())
                        });
                    }
                }
                else
                {
                    //проверяем есть ли такое поле в списке UserInFields, если нет - выводим ошибку
                    var fName = userInFieldSheets.Where(e => e.FieldName == userInFieldCellValue.Trim())?.FirstOrDefault()?.InternalName;
                    if (fName is null) throw new UniversalException($"Поле \"{userInFieldCellValue.Trim()}\" не найдено в списке UserInFields (лист - \"{worksheet.Name.Trim()}\"; ячейка - \"{columnLetter}4\")");

                    lcForCurrentState.stateSettings[0].userInField.Add(new UserInField
                    {
                        field = userInFieldCellValue,
                        fieldName = fName,
                        priority = priorityValue,
                        fieldSettings = RulesForUserInFieldDSO.GenerateRulesForUserInFieldDSO(worksheet, columnLetter, INs, userInFieldCellValue)
                    });
                }
            }

            //если в одной из ячеек указано ключевое слово Default/По умолчанию, то вызываем генерацию правил для дефолта
            if (userInGroupCellValue == "По умолчанию" || userInFieldCellValue == "По умолчанию" || userInGroupCellValue == "Default" || userInFieldCellValue == "Default")
            {
                lcForCurrentState.stateSettings[0].fieldSettingsByState = RulesForDefaultDSO.GenerateRulesForDefaultDSO(worksheet, columnLetter, INs);
            }

            return lcForCurrentState;
        }
    }
}
