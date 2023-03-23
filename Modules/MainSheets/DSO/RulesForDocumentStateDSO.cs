using ClosedXML.Excel;
using Gena.Exceptions;
using Gena.SystemSheets;
using Gena.Templates.DSO;

namespace Gena.Modules.MainSheets.DSO
{
    internal class RulesForDocumentStateDSO
    {
        //метод обновления существующего StateSettings
        public static T CreateRulesForDocumentStateDSO<T>(IXLWorksheet worksheet, string columnLetter, string tempStateName, int currentStateID, List<InternalNames> internalNames, T lcForCurrentState, List<SheetUserInFields> userInFieldSheets, List<SheetGroups> GroupsSheetList, int userInGroupRowNumber, int userInFieldRowNumber, int priorityRowNumber) where T : DocumentStateDSO, new()
        {
            if (lcForCurrentState == null)
            {
                lcForCurrentState = new T()
                {
                    DocState = currentStateID,
                    StateName = tempStateName,
                    StateSettings = new List<StateSetting>()
                    {
                        new StateSetting()
                        {
                            UserInField = new List<UserInField>(),
                            UserInGroup = new List<UserInGroup>(),
                            FieldSettingsByState = new List<FieldSettingsByState>()
                        }
                    }
                };
            }

            var userInGroupCellValue = (string)worksheet.Cell(userInGroupRowNumber, columnLetter).Value;

            var userInFieldCellValue = (string)worksheet.Cell(userInFieldRowNumber, columnLetter).Value;

            var checkPriorityValue = int.TryParse(worksheet.Cell(priorityRowNumber, columnLetter).Value.ToString(), out var priorityValue);
            if (priorityValue > 100) 
                throw new UniversalException($"Значение приоритета не может быть больше чем 100 (лист - \"{worksheet.Name.Trim()}\"; ячейка - \"{columnLetter}{priorityRowNumber}\")");
            if (priorityValue < 0) 
                throw new UniversalException($"Значение приоритета не может быть отрицательным числом (лист - \"{worksheet.Name.Trim()}\"; ячейка - \"{columnLetter}{priorityRowNumber}\")");

            //если ячейка UserInGroup заполнена то вызываем генерацию правил для неё
            if (userInGroupCellValue.Trim() != "" && userInGroupCellValue.Trim() != "По умолчанию" && userInGroupCellValue.Trim() != "Default") //проверяем есть ли в этой колонке правила для userInRoles
            {
                //проверяем указано ли в ячейке UserInGroup несколько групп, и если это так, то создаём жц для каждой
                if (userInGroupCellValue.Contains(';'))
                {
                    var groupsInCell = userInGroupCellValue.Split(';');
                    foreach (var groupInCell in groupsInCell)
                    {
                        //проверяем есть ли такая группа в списке UserInGroups, если нет - выводим ошибку
                        var gId = GroupsSheetList.FirstOrDefault(e => e.GroupName == groupInCell.Trim())?.GroupId ?? 0;
                        if (gId == 0) 
                            throw new UniversalException($"Группа \"{groupInCell.Trim()}\" не найдена в списке UserInGroups (лист - \"{worksheet.Name.Trim()}\"; ячейка - \"{columnLetter}{userInGroupRowNumber}\")");

                        lcForCurrentState.StateSettings[0].UserInGroup.Add(new UserInGroup
                        {
                            GroupId = gId,
                            GroupName = groupInCell.Trim(),
                            Priority = priorityValue,
                            FieldSettings = RulesForUserInGroup.GenerateRulesForUserInGroup(worksheet, columnLetter, internalNames, groupInCell.Trim())
                        });
                    }
                }
                else
                {
                    //проверяем есть ли такая группа в списке UserInGroups, если нет - выводим ошибку
                    var gId = GroupsSheetList.FirstOrDefault(e => e.GroupName == userInGroupCellValue.Trim())?.GroupId ?? 0;
                    if (gId == 0) 
                        throw new UniversalException($"Группа \"{userInGroupCellValue.Trim()}\" не найдена в списке UserInGroups (лист - \"{worksheet.Name.Trim()}\"; ячейка - \"{columnLetter}{userInGroupRowNumber}\")");

                    lcForCurrentState.StateSettings[0].UserInGroup.Add(new UserInGroup
                    {
                        GroupId = gId,
                        GroupName = userInGroupCellValue,
                        Priority = priorityValue,
                        FieldSettings = RulesForUserInGroup.GenerateRulesForUserInGroup(worksheet, columnLetter, internalNames, userInGroupCellValue)
                    });
                }
            }

            //если ячейка UserInField заполнена то вызываем генерацию правил для неё
            if (userInFieldCellValue.Trim() != "" && userInFieldCellValue != "По умолчанию" && userInFieldCellValue != "Default") //проверяем есть ли в этой колонке правила для userInField
            {
                if (userInFieldCellValue.Contains(';'))
                {
                    var fieldsInCell = userInFieldCellValue.Split(';');
                    foreach (var fieldInCell in fieldsInCell)
                    {
                        //проверяем есть ли такое поле в списке UserInFields, если нет - выводим ошибку
                        var fName = userInFieldSheets.FirstOrDefault(e => e.FieldName == fieldInCell.Trim())?.InternalName;
                        if (fName is null) 
                            throw new UniversalException($"Поле {fieldInCell.Trim()} не найдено в списке UserInFields (лист - \"{worksheet.Name.Trim()}\"; ячейка - \"{columnLetter}{userInFieldRowNumber}\")");

                        lcForCurrentState.StateSettings[0].UserInField.Add(new UserInField
                        {
                            Field = fieldInCell.Trim(),
                            FieldName = fName,
                            Priority = priorityValue,
                            FieldSettings = RulesForUserInFieldDSO.GenerateRulesForUserInFieldDSO(worksheet, columnLetter, internalNames, fieldInCell.Trim())
                        });
                    }
                }
                else
                {
                    //проверяем есть ли такое поле в списке UserInFields, если нет - выводим ошибку
                    var fName = userInFieldSheets.FirstOrDefault(e => e.FieldName == userInFieldCellValue.Trim())?.InternalName;
                    if (fName is null) 
                        throw new UniversalException($"Поле \"{userInFieldCellValue.Trim()}\" не найдено в списке UserInFields (лист - \"{worksheet.Name.Trim()}\"; ячейка - \"{columnLetter}{userInFieldRowNumber}\")");

                    lcForCurrentState.StateSettings[0].UserInField.Add(new UserInField
                    {
                        Field = userInFieldCellValue,
                        FieldName = fName,
                        Priority = priorityValue,
                        FieldSettings = RulesForUserInFieldDSO.GenerateRulesForUserInFieldDSO(worksheet, columnLetter, internalNames, userInFieldCellValue)
                    });
                }
            }

            //если в одной из ячеек указано ключевое слово Default/По умолчанию, то вызываем генерацию правил для дефолта
            if (userInGroupCellValue == "По умолчанию" || userInFieldCellValue == "По умолчанию" || userInGroupCellValue == "Default" || userInFieldCellValue == "Default")
            {
                lcForCurrentState.StateSettings[0].FieldSettingsByState = RulesForDefaultDSO.GenerateRulesForDefaultDSO(worksheet, columnLetter, internalNames);
            }

            return lcForCurrentState;
        }
    }
}
