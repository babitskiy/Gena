using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gena
{
    internal class SheetStates
    {
        private int stateId;
        private string stateName;

        public int StateId { get { return stateId; } set { stateId = value; } }
        public string StateName { get { return stateName; } set { stateName = value; } }

        //метод генерации списка состояний из таблицы States
        public static List<SheetStates> GenerateSheetStatesList(IXLWorkbook workbook)
        {
            //создаём список состояний из листа States
            var worksheetStates = workbook.Worksheets.Where(w => w.Name == "States").First();
            var StatesList = worksheetStates.RowsUsed().Skip(1).Select(row => new
            {
                StateId = row.Cell(1).Value,
                StateName = row.Cell(2).Value
            });
            List<SheetStates> StatesSheetList = new List<SheetStates>();
            foreach (var item in StatesList)
            {
                StatesSheetList.Add(new SheetStates()
                {
                    StateId = Convert.ToInt32(item.StateId),
                    StateName = item.StateName.ToString()
                });
            }
            return StatesSheetList;
        }
    }
}
