using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Gena.SystemSheets;
using Gena.Templates.DSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //for each state generate rules
            foreach (var columnWithRules in columnsWithRules)
            {
                //находим айди этого состояния в списке состояний
                int currentStateID = Convert.ToInt32(StatesSheetList.Where(e => e.StateName == columnWithRules.StateName).First().StateId);

                //объявляем переменную DocumentState
                var lcForCurrentState = new DocumentStateDSO();

                //проверяем есть ли уже объект DocumentState с таким состоянием
                if (lc.Any(e => e.docState == currentStateID))
                {
                    //добавляем новые правила в существующий DocumentState
                    lcForCurrentState = lc.SingleOrDefault(e => e.docState == currentStateID);
                    lcForCurrentState = RulesForDocumentStateDSO.CreateRulesForDocumentStateDSO<DocumentStateDSO>(worksheet, columnWithRules.Address.ColumnLetter, columnWithRules.StateName, currentStateID, INs, lcForCurrentState, UserInFieldsSheetList, GroupsSheetList);
                }
                else
                {
                    //создаём DocumentState и добавляем его в общий жц
                    lcForCurrentState = RulesForDocumentStateDSO.CreateRulesForDocumentStateDSO<DocumentStateDSO>(worksheet, columnWithRules.Address.ColumnLetter, columnWithRules.StateName, currentStateID, INs, null, UserInFieldsSheetList, GroupsSheetList);
                    lc.Add(lcForCurrentState);
                }
            }
            return lc;
        }
    }
}
