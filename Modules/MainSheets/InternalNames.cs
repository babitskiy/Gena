using ClosedXML.Excel;
using Gena.Exceptions;

namespace Gena.Modules.MainSheets
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
            //находим букву столбца с internalNames
            var internalNamesColumnNumber = worksheet.FirstRowUsed().Cells().Where(e => e?.Value?.ToString()?.Trim().ToUpper() == "internalNames".ToUpper())?.FirstOrDefault()?.Address.ColumnLetter;
            if (internalNamesColumnNumber is null) throw new UniversalException($"В таблице \"{worksheet.Name}\" не найдена колонка internalNames");

            //собираем всё что есть в колонке InternalNames в текущей таблице
            var internalNamesFromCurrentSheet = worksheet.Column(internalNamesColumnNumber).Cells().Skip(1).Select((v, i) => new
            {
                v.Value,
                Index = i + 1,
                v.Address
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