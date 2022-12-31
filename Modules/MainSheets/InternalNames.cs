using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gena
{
    internal class InternalNames
    {
        private int rowNumber;
        private string internalName;

        public int RowNumber { get { return rowNumber; } set { rowNumber = value; } }
        public string InternalName { get { return internalName; } set { internalName = value; } }

        //метод генерации списка internalNames из таблицы с описанием жц
        public static List<InternalNames> GenerateInternalNamesSheetList(IXLWorksheet worksheet)
        {
            //собираем все InternalNames в текущей таблице (ячейки начиная с шестой)
            var internalNamesFromCurrentSheet = worksheet.Column(2).Cells().Skip(5).Select((v, i) => new 
            { 
                Value = v.Value, 
                Index = i + 1, 
                Address = v.Address 
            });
            List<InternalNames> INs = new List<InternalNames>();
            foreach (var item in internalNamesFromCurrentSheet)
            {
                INs.Add(new InternalNames()
                {
                    RowNumber = item.Address.RowNumber,
                    InternalName = (string)item.Value
                });
            }
            return INs;
        }
    }
}