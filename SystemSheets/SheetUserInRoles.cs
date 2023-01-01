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
    internal class SheetUserInRoles
    {
        public string RoleInternalName { get; set; }
        public string RoleName { get; set; }

        //метод генерации списка групп из таблицы Groups
        public static List<SheetUserInRoles> GenerateUserInRolesSheetList(IXLWorkbook workbook)
        {
            //создаём список полей из листа Groups
            var worksheetUserInRoles = workbook.Worksheets.Where(w => w.Name == "UserInRoles").First();
            var GroupsList = worksheetUserInRoles.RowsUsed().Skip(1).Select(row => new
            {
                RoleInternalName = row.Cell(1).Value,
                RoleName = row.Cell(2).Value
            });
            List<SheetUserInRoles> UserInRolesSheetList = new List<SheetUserInRoles>();
            foreach (var item in GroupsList)
            {
                UserInRolesSheetList.Add(new SheetUserInRoles()
                {
                    RoleInternalName = item.RoleInternalName.ToString(),
                    RoleName = item.RoleName.ToString()
                });
            }
            return UserInRolesSheetList;
        }
    }
}