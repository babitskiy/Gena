using ClosedXML.Excel;
using Gena.Exceptions;

namespace Gena.SystemSheets
{
    internal class SheetUserInFields
    {
        public string InternalName { get; set; }
        public string FieldName { get; set; }

        public static List<SheetUserInFields> GenerateUserInFieldSheetList(IXLWorkbook workbook)
        {
            //создаём список полей из листа userInFields
            var worksheetUserInFields = workbook.Worksheets.FirstOrDefault(w => w.Name == "UserInFields");
            if (worksheetUserInFields is null) 
                throw new UniversalException($"Системный список UserInFields не найден");
            var UserInFieldsList = worksheetUserInFields.RowsUsed().Skip(1).Select(row => new
            {
                InternalName = row.Cell(1).Value,
                FieldName = row.Cell(2).Value
            });
            List<SheetUserInFields> UserInFieldsSheetList = new List<SheetUserInFields>();
            foreach (var item in UserInFieldsList)
            {
                UserInFieldsSheetList.Add(new SheetUserInFields()
                {
                    InternalName = item.InternalName.ToString(),
                    FieldName = item.FieldName.ToString()
                });
            }
            return UserInFieldsSheetList;
        }
    }
}
