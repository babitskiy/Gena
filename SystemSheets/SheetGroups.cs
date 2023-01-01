using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gena
{
    internal class SheetGroups
    {
        private int groupId;
        private string groupName;

        public int GroupId { get { return groupId; } set { groupId = value; } }
        public string GroupName { get { return groupName; } set { groupName = value; } }

        //метод генерации списка групп из таблицы Groups
        public static List<SheetGroups> GenerateGroupSheetList(IXLWorkbook workbook)
        {
            //создаём список полей из листа Groups
            var worksheetGroups = workbook.Worksheets.Where(w => w.Name == "Groups")?.FirstOrDefault();
            if (worksheetGroups is null) throw new UniversalException($"Системный список Groups не найден");
            var GroupsList = worksheetGroups.RowsUsed().Skip(1).Select(row => new
            {
                GroupId = row.Cell(1).Value,
                GroupName = row.Cell(2).Value
            });
            List<SheetGroups> GroupsSheetList = new List<SheetGroups>();
            foreach (var item in GroupsList)
            {
                GroupsSheetList.Add(new SheetGroups()
                {
                    GroupId = Convert.ToInt32(item.GroupId),
                    GroupName = item.GroupName.ToString()
                });
            }
            return GroupsSheetList;
        }
    }
}
