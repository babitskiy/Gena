using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gena
{
    internal class RulesForDocumentState
    {
        //метод обновления существующего StateSettings
        public static T CreateRulesForDocumentState<T>( IXLWorksheet worksheet, string columnLetter, string tempStateName, int currentStateID, List<InternalNames> INs, T lcForCurrentState, List<SheetUserInFields> userInFieldSheets, List<SheetGroups> GroupsSheetList) where T : DocumentState, new()
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
                        lcForCurrentState.stateSettings[0].userInGroup.Add(new UserInGroup
                        {
                            groupId = GroupsSheetList.Where(e => e.GroupName == groupInCell.Trim()).First().GroupId,
                            groupName = groupInCell.Trim(),
                            priority = priorityValue,
                            fieldSettings = RulesForUserInGroup.GenerateRulesForUserInGroup(worksheet, columnLetter, INs, groupInCell.Trim())
                        });
                    }
                }
                else
                {
                    lcForCurrentState.stateSettings[0].userInGroup.Add(new UserInGroup
                    {
                        groupId = GroupsSheetList.Where(e => e.GroupName == userInGroupCellValue).First().GroupId,
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
                        lcForCurrentState.stateSettings[0].userInField.Add(new UserInField
                        {
                            field = fieldInCell.Trim(),
                            fieldName = userInFieldSheets.Where(e => e.FieldName == fieldInCell.Trim()).First().InternalName,
                            priority = priorityValue,
                            fieldSettings = RulesForUserInField.GenerateRulesForUserInField(worksheet, columnLetter, INs, fieldInCell.Trim())
                        });
                    }
                }
                else
                {
                    lcForCurrentState.stateSettings[0].userInField.Add(new UserInField
                    {
                        field = userInFieldCellValue,
                        fieldName = userInFieldSheets.Where(e => e.FieldName == userInFieldCellValue).First().InternalName,
                        priority = priorityValue,
                        fieldSettings = RulesForUserInField.GenerateRulesForUserInField(worksheet, columnLetter, INs, userInFieldCellValue)
                    });
                }
            }

            //если в одной из ячеек указано ключевое слово Default/По умолчанию, то вызываем генерацию правил для дефолта
            if (userInGroupCellValue == "По умолчанию" || userInFieldCellValue == "По умолчанию" || userInGroupCellValue == "Default" || userInFieldCellValue == "Default")
            {
                lcForCurrentState.stateSettings[0].fieldSettingsByState = RulesForDefault.GenerateRulesForDefault(worksheet, columnLetter, INs);
            }

            return lcForCurrentState;
        }
    }
}
