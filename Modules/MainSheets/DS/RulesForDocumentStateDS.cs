using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gena
{
    internal class RulesForDocumentStateDS
    {
        //метод обновления существующего StateSettings
        public static T CreateRulesForDocumentStateDS<T>(IXLWorksheet worksheet, string columnLetter, string tempStateName, int currentStateID, List<InternalNames> INs, T lcForCurrentState, List<SheetUserInFields> userInFieldSheetList, List<SheetUserInRoles> userInRoleSheetList) where T : DocumentState, new()
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

            var userInRoleCellValue = (string)worksheet.Cell(3, columnLetter).Value;
            var userInFieldCellValue = (string)worksheet.Cell(4, columnLetter).Value;

            //если ячейка UserInGroup заполнена то вызываем генерацию правил для неё
            if (userInRoleCellValue != "" && userInRoleCellValue != "По умолчанию" && userInRoleCellValue != "Default") //проверяем есть ли в этой колонке правила для userInRoles
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
                        var userInRoleInternalName = userInRoleSheetList.Where(e => e.RoleName.ToUpper() == groupInCell.Trim().ToUpper()).First().RoleInternalName;
                        lcForCurrentState.Switch.Case.Add(RulesForUserInRole.GenerateRulesForUserInRoles(worksheet, columnLetter, INs, userInRoleInternalName.Trim()));
                    }
                }
                else
                {
                    if (lcForCurrentState.Switch.Case == null)
                    {
                        lcForCurrentState.Switch.Case = new List<Case>();
                    }
                    var userInRoleInternalName = userInRoleSheetList.Where(e => e.RoleName.ToUpper() == userInRoleCellValue.Trim().ToUpper()).First().RoleInternalName;
                    lcForCurrentState.Switch.Case.Add(RulesForUserInRole.GenerateRulesForUserInRoles(worksheet, columnLetter, INs, userInRoleInternalName));
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
                        if (lcForCurrentState.Switch.Case == null)
                        {
                            lcForCurrentState.Switch.Case = new List<Case>();
                        }
                        var userInFieldInternalName = userInFieldSheetList.Where(e => e.FieldName.ToUpper() == fieldInCell.Trim().ToUpper()).First().InternalName;
                        lcForCurrentState.Switch.Case.Add(RulesForUserInFieldDS.GenerateRulesForUserInFieldDS(worksheet, columnLetter, INs, userInFieldInternalName));
                    }
                }
                else
                {
                    if (lcForCurrentState.Switch.Case == null)
                    {
                        lcForCurrentState.Switch.Case = new List<Case>();
                    }
                    var userInFieldInternalName = userInFieldSheetList.Where(e => e.FieldName.ToUpper() == userInFieldCellValue.Trim().ToUpper()).First().InternalName;
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
