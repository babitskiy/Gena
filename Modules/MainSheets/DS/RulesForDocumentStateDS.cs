using ClosedXML.Excel;
using Gena.Exceptions;
using Gena.SystemSheets;
using Gena.Templates.DS;

namespace Gena.Modules.MainSheets.DS
{
    internal class RulesForDocumentStateDS
    {
        //метод обновления существующего StateSettings
        public static T CreateRulesForDocumentStateDS<T>(IXLWorksheet worksheet, string columnLetter, string tempStateName, int currentStateID, List<InternalNames> INs, T lcForCurrentState, List<SheetUserInFields> userInFieldSheetList, List<SheetUserInRoles> userInRoleSheetList, int userInRolesRowNumber, int userInFieldRowNumber) where T : DocumentState, new()
        {
            if (lcForCurrentState == null)
            {
                lcForCurrentState = new T()
                {
                    ID = currentStateID,
                    Name = tempStateName,
                    Switch = new Switch()
                    {
                        Default = new Default()
                        {
                            SetField = new List<DefaultSetField>(),
                            SetAction = new List<DefaultSetAction>(),
                            SetTab = new List<DefaultSetTab>(),
                            SetForm = new DefaultSetForm()
                            {
                                ReadOnly = false
                            }
                        }
                    }
                };
            }

            //Получаем значения в ячейках на пересечении текущего состояния и строк userInRoles/userInField
            var userInRoleCellValue = (string)worksheet.Cell(userInRolesRowNumber, columnLetter).Value;
            var userInFieldCellValue = (string)worksheet.Cell(userInFieldRowNumber, columnLetter).Value;

            //если ячейка UserInGroup заполнена то вызываем генерацию правил для неё
            if (userInRoleCellValue.Trim() != "" && userInRoleCellValue.Trim() != "По умолчанию" && userInRoleCellValue.Trim() != "Default") //проверяем есть ли в этой колонке правила для userInRoles
            {
                //проверяем указано ли в ячейке UserInGroup несколько групп, и если это так, то создаём жц для каждой
                if (userInRoleCellValue.Contains(';'))
                {
                    var groupsInCell = userInRoleCellValue.Split(';');
                    foreach (var groupInCell in groupsInCell)
                    {
                        if (lcForCurrentState.Switch.Case == null)
                        {
                            lcForCurrentState.Switch.Case = new List<Case>();
                        }
                        var userInRoleInternalName = userInRoleSheetList.FirstOrDefault(e => e.RoleName.ToUpper() == groupInCell.Trim().ToUpper())?.RoleInternalName;
                        if (userInRoleInternalName is null) 
                            throw new UniversalException($"Роль \"{groupInCell.Trim()}\" не найдена в списке UserInRole (лист - \"{worksheet.Name.Trim()}\"; ячейка - \"{columnLetter}3\")");
                        lcForCurrentState.Switch.Case.Add(RulesForUserInRole.GenerateRulesForUserInRoles(worksheet, columnLetter, INs, userInRoleInternalName.Trim()));
                    }
                }
                else
                {
                    if (lcForCurrentState.Switch.Case == null)
                    {
                        lcForCurrentState.Switch.Case = new List<Case>();
                    }
                    var userInRoleInternalName = userInRoleSheetList.FirstOrDefault(e => e.RoleName.ToUpper() == userInRoleCellValue.Trim().ToUpper())?.RoleInternalName;
                    if (userInRoleInternalName is null) 
                        throw new UniversalException($"Роль \"{userInRoleCellValue.Trim()}\" не найдена в списке UserInRole (лист - \"{worksheet.Name.Trim()}\"; ячейка - \"{columnLetter}3\")");
                    lcForCurrentState.Switch.Case.Add(RulesForUserInRole.GenerateRulesForUserInRoles(worksheet, columnLetter, INs, userInRoleInternalName));
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
                        if (lcForCurrentState.Switch.Case == null)
                        {
                            lcForCurrentState.Switch.Case = new List<Case>();
                        }
                        var userInFieldInternalName = userInFieldSheetList.FirstOrDefault(e => e.FieldName.ToUpper() == fieldInCell.Trim().ToUpper())?.InternalName;
                        if (userInFieldInternalName is null) 
                            throw new UniversalException($"Поле {fieldInCell.Trim()} не найдено в списке UserInFields (лист - \"{worksheet.Name.Trim()}\"; ячейка - \"{columnLetter}4\")");
                        lcForCurrentState.Switch.Case.Add(RulesForUserInFieldDS.GenerateRulesForUserInFieldDS(worksheet, columnLetter, INs, userInFieldInternalName));
                    }
                }
                else
                {
                    if (lcForCurrentState.Switch.Case == null)
                        lcForCurrentState.Switch.Case = new List<Case>();
                    
                    var userInFieldInternalName = userInFieldSheetList.FirstOrDefault(e => e.FieldName.ToUpper() == userInFieldCellValue.Trim().ToUpper())?.InternalName;
                    
                    if (userInFieldInternalName is null) 
                        throw new UniversalException($"Поле {userInFieldCellValue.Trim()} не найдено в списке UserInFields (лист - \"{worksheet.Name.Trim()}\"; ячейка - \"{columnLetter}4\")");
                    
                    lcForCurrentState.Switch.Case.Add(RulesForUserInFieldDS.GenerateRulesForUserInFieldDS(worksheet, columnLetter, INs, userInFieldInternalName));
                }
            }

            //если в одной из ячеек указано ключевое слово Default/По умолчанию, то вызываем генерацию правил для дефолта
            if (userInRoleCellValue == "По умолчанию" || userInFieldCellValue == "По умолчанию" || userInRoleCellValue == "Default" || userInFieldCellValue == "Default")
            {
                lcForCurrentState.Switch.Default = RulesForDefaultDS.GenerateRulesForDefaultDS(worksheet, columnLetter, INs);
            }

            return lcForCurrentState;
        }
    }
}
