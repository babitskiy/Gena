using ClosedXML.Excel;
using Gena.Exceptions;

namespace Gena.SystemSheets
{
    internal class SheetUserInRoles
    {
        public string RoleInternalName { get; set; }
        public string RoleName { get; set; }

        //метод генерации списка групп из таблицы Groups
        public static List<SheetUserInRoles> GenerateUserInRolesSheetList(IXLWorkbook workbook)
        {
            //создаём список полей из листа Groups
            var worksheetUserInRoles = workbook.Worksheets.FirstOrDefault(w => w.Name == "UserInRoles");
            //проверяем есть ли такой лист в экселе, если нет - возвращаем ошибку
            if (worksheetUserInRoles is null) 
                throw new UniversalException($"Системный список UserInRoles не найден");
            var groupsList = worksheetUserInRoles.RowsUsed().Skip(1).Select(row => new
            {
                RoleInternalName = row.Cell(1).Value,
                RoleName = row.Cell(2).Value
            });
            List<SheetUserInRoles> UserInRolesSheetList = new List<SheetUserInRoles>();
            foreach (var item in groupsList)
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