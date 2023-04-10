using ClosedXML.Excel;
using Gena.Exceptions;

namespace Gena.SystemSheets
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
            var worksheetStates = workbook.Worksheets.FirstOrDefault(w => w.Name == "States");
            if (worksheetStates is null) 
                throw new UniversalException($"Системный список States не найден");
            var statesList = worksheetStates.RowsUsed().Skip(1).Select(row => new
            {
                StateId = row.Cell(1).Value,
                StateName = row.Cell(2).Value
            });
            List<SheetStates> statesSheetList = new List<SheetStates>();
            foreach (var item in statesList)
            {
                statesSheetList.Add(new SheetStates()
                {
                    StateId = Convert.ToInt32(item.StateId),
                    StateName = item.StateName.ToString()
                });
            }
            return statesSheetList;
        }
    }
}
