using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var worksheetSettings = workbook.Worksheets.Where(w => w.Name == "Settings").FirstOrDefault();
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
