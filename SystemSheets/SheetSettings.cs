﻿using ClosedXML.Excel;

namespace Gena.SystemSheets
{
    internal class SheetSettings
    {
        public string? Name { get; set; }
        public string? Rule { get; set; }

        //метод генерации списка состояний из таблицы States
        public static List<SheetSettings> GenerateSheetSettingsList(IXLWorkbook workbook)
        {
            //создаём список состояний из листа States
            var worksheetSettings = workbook.Worksheets.FirstOrDefault(w => w.Name == "Settings");
            var SettingsList = worksheetSettings?.RowsUsed().Skip(1).Select(row => new
            {
                Name = row.Cell(1).Value,
                Rule = row.Cell(2).Value
            });
            List<SheetSettings> SettingsSheetList = new List<SheetSettings>();
            if (SettingsList != null)
            {
                foreach (var item in SettingsList)
                {
                    SettingsSheetList.Add(new SheetSettings()
                    {
                        Name = item?.Name.ToString()?.Trim(),
                        Rule = item?.Rule.ToString()?.Trim()
                    });
                }
            }
            return SettingsSheetList;
        }
    }
}
