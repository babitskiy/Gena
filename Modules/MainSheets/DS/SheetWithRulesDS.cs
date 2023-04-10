using ClosedXML.Excel;
using Gena.Exceptions;
using Gena.SystemSheets;
using Gena.Templates.DS;

namespace Gena.Modules.MainSheets.DS
{
    internal class SheetWithRulesDS
    {
        public static T GenerateLifeCycleForSheetWithRulesDS<T>(IXLWorksheet worksheet, List<SheetStates> StatesSheetList, List<SheetUserInFields> UserInFieldsSheetList, List<SheetUserInRoles> UserInRolesSheetList) where T : StatesConfiguration, new()
        {
            //генерируем список всех intrnalName'ов в таблице с описанием жц
            var internalNames = InternalNames.GenerateInternalNamesSheetList(worksheet);

            //собираем все колонки с правилами для состояний, т.е. начиная с третей
            var columnsWithRules = ColumnsWithRules.GenerateColumnsWithRulesList(worksheet);

            //создаём экземпляр жц
            var lc = new T()
            {
                DocumentStates = new List<DocumentState>()
            };

            //Проверяем что в текущей таблице существует строка userInGroup
            var userInRolesRowNumber = worksheet.FirstColumnUsed().Cells().FirstOrDefault(e => e.Value.ToString().Trim().ToUpper() == "userInRoles".ToUpper())?.Address.RowNumber ?? 0;
            if (userInRolesRowNumber == 0) 
                throw new UniversalException($"В таблице \"{worksheet.Name}\" отсутствует строка userInRoles");

            //Проверяем что в текущей таблице существует строка userInField
            var userInFieldRowNumber = worksheet.FirstColumnUsed().Cells().FirstOrDefault(e => e.Value.ToString().Trim().ToUpper() == "userInField".ToUpper())?.Address.RowNumber ?? 0;
            if (userInFieldRowNumber == 0) 
                throw new UniversalException($"В таблице \"{worksheet.Name}\" отсутствует строка userInField");

            //for each state generate rules
            foreach (var columnWithRules in columnsWithRules)
            {
                //находим айди этого состояния в списке состояний
                int currentStateID = Convert.ToInt32(StatesSheetList?.FirstOrDefault(e => e.StateName == columnWithRules.StateName.Trim()).StateId);

                //Объявляем переменную DocumentState
                var lcForCurrentState = new DocumentState();

                //проверяем есть ли уже объект DocumentState с таким состоянием
                if (lc.DocumentStates.Any(e => e.ID == currentStateID))
                {
                    lcForCurrentState = lc.DocumentStates.SingleOrDefault(e => e.ID == currentStateID);
                    //lcForCurrentState = CreateRulesForExistState<DocumentState>(worksheet, columnWithRules.Address.ColumnLetter, currentStateID, INs, lcForCurrentState);
                    lcForCurrentState = RulesForDocumentStateDS.CreateRulesForDocumentStateDS<DocumentState>(worksheet, columnWithRules.Address.ColumnLetter, columnWithRules.StateName, currentStateID, internalNames, lcForCurrentState, UserInFieldsSheetList, UserInRolesSheetList, userInRolesRowNumber, userInFieldRowNumber);
                }
                else
                {
                    //lcForCurrentState = CreateRulesForNewState<DocumentState>(worksheet, columnWithRules.Address.ColumnLetter, tempStateName, currentStateID, INs);
                    lcForCurrentState = RulesForDocumentStateDS.CreateRulesForDocumentStateDS<DocumentState>(worksheet, columnWithRules.Address.ColumnLetter, columnWithRules.StateName, currentStateID, internalNames, null, UserInFieldsSheetList, UserInRolesSheetList, userInRolesRowNumber, userInFieldRowNumber);
                    lc.DocumentStates.Add(lcForCurrentState);
                }
            }
            return lc;
        }
    }
}
