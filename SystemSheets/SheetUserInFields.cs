﻿using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gena
{
    internal class SheetUserInFields
    {
        private string internalName;
        private string fieldName;
        public string InternalName { get; set; }
        public string FieldName { get; set; }

        public static List<SheetUserInFields> GenerateUserInFieldSheetList(IXLWorkbook workbook)
        {
            //создаём список полей из листа userInFields
            var worksheetUserInFields = workbook.Worksheets.Where(w => w.Name == "UserInFields").First();
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