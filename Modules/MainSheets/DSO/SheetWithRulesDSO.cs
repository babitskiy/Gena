using ClosedXML.Excel;
using Gena.Exceptions;
using Gena.SystemSheets;
using Gena.Templates.DSO;

namespace Gena.Modules.MainSheets.DSO
{
    internal class SheetWithRulesDSO
    {
        public static T GenerateLifeCycleForSheetWithRulesDSO<T>(IXLWorksheet worksheet, List<SheetStates> StatesSheetList, List<SheetUserInFields> UserInFieldsSheetList, List<SheetGroups> GroupsSheetList) where T : List<DocumentStateDSO>, new()
        {
            //генерируем список всех intrnalName'ов в таблице с описанием жц
            var INs = InternalNames.GenerateInternalNamesSheetList(worksheet);

            //собираем все колонки с правилами для состояний, т.е. начиная с третей
            var columnsWithRules = ColumnsWithRules.GenerateColumnsWithRulesList(worksheet);

            //создаём экземпляр жц
            var lc = new T();

            //Проверяем что в текущей таблице существует строка userInGroup
            var userInGroupRowNumber = worksheet.FirstColumnUsed().Cells().Where(e => e.Value.ToString().Trim().ToUpper() == "userInGroup".ToUpper())?.FirstOrDefault()?.Address.RowNumber ?? 0;
            if (userInGroupRowNumber == 0) throw new UniversalException($"В таблице \"{worksheet.Name}\" отсутствует строка userInGroup");

            //Проверяем что в текущей таблице существует строка userInField
            var userInFieldRowNumber = worksheet.FirstColumnUsed().Cells().Where(e => e.Value.ToString().Trim().ToUpper() == "userInField".ToUpper())?.FirstOrDefault()?.Address.RowNumber ?? 0;
            if (userInFieldRowNumber == 0) throw new UniversalException($"В таблице \"{worksheet.Name}\" отсутствует строка userInField");

            //Проверяем что в текущей таблице существует строка priorityDSO
            var priorityRowNumber = worksheet.FirstColumnUsed().Cells().Where(e => e.Value.ToString().Trim().ToUpper() == "priorityDSO".ToUpper())?.FirstOrDefault()?.Address.RowNumber ?? 0;
            if (priorityRowNumber == 0) throw new UniversalException($"В таблице \"{worksheet.Name}\" отсутствует строка priorityDSO");

            //for each state generate rules
            foreach (var columnWithRules in columnsWithRules)
            {
                //находим айди этого состояния в списке состояний
                int currentStateID = Convert.ToInt32(StatesSheetList.Where(e => e.StateName == columnWithRules.StateName).First().StateId);

                //объявляем переменную DocumentState
                var lcForCurrentState = new DocumentStateDSO();

                //проверяем есть ли уже объект DocumentState с таким состоянием
                if (lc.Any(e => e.DocState == currentStateID))
                {
                    //добавляем новые правила в существующий DocumentState
                    lcForCurrentState = lc.SingleOrDefault(e => e.DocState == currentStateID);
                    lcForCurrentState = RulesForDocumentStateDSO.CreateRulesForDocumentStateDSO<DocumentStateDSO>(worksheet, columnWithRules.Address.ColumnLetter, columnWithRules.StateName, currentStateID, INs, lcForCurrentState, UserInFieldsSheetList, GroupsSheetList, userInGroupRowNumber, userInFieldRowNumber, priorityRowNumber);
                }
                else
                {
                    //создаём DocumentState и добавляем его в общий жц
                    lcForCurrentState = RulesForDocumentStateDSO.CreateRulesForDocumentStateDSO<DocumentStateDSO>(worksheet, columnWithRules.Address.ColumnLetter, columnWithRules.StateName, currentStateID, INs, null, UserInFieldsSheetList, GroupsSheetList, userInGroupRowNumber, userInFieldRowNumber, priorityRowNumber);
                    lc.Add(lcForCurrentState);
                }
            }
            return lc;
        }
    }
}
