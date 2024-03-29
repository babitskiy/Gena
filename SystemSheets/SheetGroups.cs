﻿using ClosedXML.Excel;
using Gena.Exceptions;

namespace Gena.SystemSheets
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
            var worksheetGroups = workbook.Worksheets.FirstOrDefault(w => w.Name == "Groups");
            if (worksheetGroups is null) 
                throw new UniversalException($"Системный список Groups не найден");
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
