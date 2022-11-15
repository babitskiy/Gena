using ClosedXML.Excel;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var StatesSheetList = SheetStates.GenerateSheetStatesList(workbook);

                //генерируем список всех групп из таблицы UserInFields
                var UserInFieldsSheetList = SheetUserInFields.GenerateUserInFieldSheetList(workbook);

                //генерируем список всех настроек из таблицы Settings
                var SettingsSheetList = SheetSettings.GenerateSheetSettingsList(workbook);
                var SystemWorksheets = SettingsSheetList.Where(e => e?.Name?.Trim() == "SystemWorksheets").FirstOrDefault()?.Rule?.Split(';', StringSplitOptions.TrimEntries);


                if(systemType == "DSO")
                {
                    //генерируем список всех групп из таблицы Groups
                    var GroupsSheetList = SheetGroups.GenerateGroupSheetList(workbook);

                    foreach (var worksheet in workbook.Worksheets)
                    {
                        if (!(SystemWorksheets != null && SystemWorksheets.Any(e => e == worksheet.Name)) && worksheet.Name != "States" && worksheet.Name != "Groups" && worksheet.Name != "Fields" && worksheet.Name != "UserInFields")
                        {
                            var lc = SheetWithRulesDSO.GenerateLifeCycleForSheetWithRulesDSO<List<DocumentStateDSO>>(worksheet, StatesSheetList, UserInFieldsSheetList, GroupsSheetList);
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
                        if (!(SystemWorksheets != null && SystemWorksheets.Any(e => e == worksheet.Name)) && worksheet.Name != "States" && worksheet.Name != "UserInRoles" && worksheet.Name != "Fields" && worksheet.Name != "UserInFields" && worksheet.Name != "Settings")
                        {
                            var lc = SheetWithRulesDS.GenerateLifeCycleForSheetWithRulesDS<StatesConfiguration>(worksheet, StatesSheetList, UserInFieldsSheetList, UserInRolesSheetList);
                            DSSerializer.StartDSSerializer(pathToFolderWithLCFiles + "\\" + worksheet.Name, lc);
                        }
                    }
                }
            }
            return true;
        }
    }
}
