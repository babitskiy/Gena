using ClosedXML.Excel;
using Gena.Modules.MainSheets.DS;
using Gena.Modules.MainSheets.DSO;
using Gena.Serializers;
using Gena.SystemSheets;
using Gena.Templates.DS;
using Gena.Templates.DSO;

namespace Gena
{
    internal class LifeCycleGenerator
    {
        public static bool GenerateLifeCycle(string excelFilePath, string pathToFolderWithLCFiles, string systemType)
        {
            //открываем эксель-файл
            using (IXLWorkbook workbook = new XLWorkbook(excelFilePath))
            {
                //создаём список состояний из таблицы States
                var statesSheetList = SheetStates.GenerateSheetStatesList(workbook);

                //генерируем список всех групп из таблицы UserInFields
                var userInFieldsSheetList = SheetUserInFields.GenerateUserInFieldSheetList(workbook);

                //генерируем список всех настроек из таблицы Settings
                var settingsSheetList = SheetSettings.GenerateSheetSettingsList(workbook);
                var systemWorksheets = settingsSheetList.FirstOrDefault(e => e?.Name?.Trim() == "SystemWorksheets")?.Rule?.Split(';', StringSplitOptions.TrimEntries);

                if(systemType == "DSO")
                {
                    //генерируем список всех групп из таблицы Groups
                    var GroupsSheetList = SheetGroups.GenerateGroupSheetList(workbook);

                    foreach (var worksheet in workbook.Worksheets)
                    {
                        //отбрасываем системные листы экселя
                        if (!(systemWorksheets != null && systemWorksheets.Any(e => e == worksheet.Name)) && worksheet.Name != "States" && worksheet.Name != "Groups" && worksheet.Name != "Fields" && worksheet.Name != "UserInFields" && worksheet.Name != "Settings")
                        {
                            var lc = SheetWithRulesDSO.GenerateLifeCycleForSheetWithRulesDSO<List<DocumentStateDSO>>(worksheet, statesSheetList, userInFieldsSheetList, GroupsSheetList);
                            DSOSerializer.StartDSOSerializer(pathToFolderWithLCFiles + "\\" + worksheet.Name, lc);
                        }
                    }
                }
                else if(systemType == "DS")
                {
                    //генерируем список всех Ролей из таблицы UserInRoles
                    var UserInRolesSheetList = SheetUserInRoles.GenerateUserInRolesSheetList(workbook);

                    foreach (var worksheet in workbook.Worksheets)
                    {
                        //отбрасываем системные листы экселя
                        if (!(systemWorksheets != null && systemWorksheets.Any(e => e == worksheet.Name)) && worksheet.Name != "States" && worksheet.Name != "UserInRoles" && worksheet.Name != "Fields" && worksheet.Name != "UserInFields" && worksheet.Name != "Settings")
                        {
                            var lc = SheetWithRulesDS.GenerateLifeCycleForSheetWithRulesDS<StatesConfiguration>(worksheet, statesSheetList, userInFieldsSheetList, UserInRolesSheetList);
                            DSSerializer.StartDSSerializer(pathToFolderWithLCFiles + "\\" + worksheet.Name, lc);
                        }
                    }
                }
            }
            return true;
        }
    }
}
