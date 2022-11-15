using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gena
{
    internal class SheetWithRulesDS
    {
        public static T GenerateLifeCycleForSheetWithRulesDS<T>(IXLWorksheet worksheet, List<SheetStates> StatesSheetList, List<SheetUserInFields> UserInFieldsSheetList, List<SheetUserInRoles> UserInRolesSheetList) where T : StatesConfiguration, new()
        {
            //генерируем список всех intrnalName'ов в таблице с описанием жц
            var INs = InternalNames.GenerateInternalNamesSheetList(worksheet);

            //собираем все колонки с правилами для состояний, т.е. начиная с третей
            var columnsWithRules = ColumnsWithRules.GenerateColumnsWithRulesList(worksheet);

            //создаём экземпляр жц
            var lc = new T()
            {
                DocumentStates = new List<DocumentState>()
            };

            //for each state generate rules
            foreach (var columnWithRules in columnsWithRules)
            {
                //находим айди этого состояния в списке состояний
                int currentStateID = Convert.ToInt32(StatesSheetList.Where(e => e.StateName == columnWithRules.StateName.Trim()).First().StateId);

                //Объявляем переменную DocumentState
                var lcForCurrentState = new DocumentState();

                //проверяем есть ли уже объект DocumentState с таким состоянием
                if (lc.DocumentStates.Any(e => e.ID == currentStateID))
                {
                    lcForCurrentState = lc.DocumentStates.SingleOrDefault(e => e.ID == currentStateID);
                    //lcForCurrentState = CreateRulesForExistState<DocumentState>(worksheet, columnWithRules.Address.ColumnLetter, currentStateID, INs, lcForCurrentState);
                    lcForCurrentState = RulesForDocumentStateDS.CreateRulesForDocumentStateDS<DocumentState>(worksheet, columnWithRules.Address.ColumnLetter, columnWithRules.StateName, currentStateID, INs, lcForCurrentState, UserInFieldsSheetList, UserInRolesSheetList);
                }
                else
                {
                    //lcForCurrentState = CreateRulesForNewState<DocumentState>(worksheet, columnWithRules.Address.ColumnLetter, tempStateName, currentStateID, INs);
                    lcForCurrentState = RulesForDocumentStateDS.CreateRulesForDocumentStateDS<DocumentState>(worksheet, columnWithRules.Address.ColumnLetter, columnWithRules.StateName, currentStateID, INs, null, UserInFieldsSheetList, UserInRolesSheetList);
                    lc.DocumentStates.Add(lcForCurrentState);
                }
            }
            return lc;
        }
    }
}
