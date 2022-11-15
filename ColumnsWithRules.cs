using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gena
{
    //класс для колонок с описанием правил жц
    internal class ColumnsWithRules
    {
        private string stateName;
        private IXLAddress address;

        public string StateName { get; set; }
        public IXLAddress Address { get; set; }

        //метод генерации списка ColumnsWithRules из таблицы с описанием жц
        public static List<ColumnsWithRules> GenerateColumnsWithRulesList(IXLWorksheet worksheet)
        {
            //собираем все столбцы с правилами в текущей таблице 
            var columnsWithRulesFromCurrentSheet = worksheet.FirstRowUsed().Cells().Skip(2).Select((v, i) => new
            {
                StateName = v.Value,
                Address = v.Address
            });
            string tempStateName = ""; //такая переменная нужна для проверки на null в ячейке где должно быть состояние
            List<ColumnsWithRules> columnsWithRulesList = new List<ColumnsWithRules>();
            foreach (var item in columnsWithRulesFromCurrentSheet)
            {
                //если название состояния не указано (сдвоенные ячейки) то используем предыдущее
                if (item.StateName != "")
                {
                    tempStateName = item.StateName.ToString();
                }

                //проверяем если состояний в ячейке указано несколько, то создаём для каждой объект
                if (tempStateName.Contains(';'))
                {
                    var statesInCell = tempStateName.Split(';');
                    foreach (var state in statesInCell)
                    {
                        columnsWithRulesList.Add(new ColumnsWithRules()
                        {
                            StateName = state.Trim(),
                            Address = item.Address
                        });
                    }
                }
                else
                {
                    columnsWithRulesList.Add(new ColumnsWithRules()
                    {
                        StateName = tempStateName,
                        Address = item.Address
                    });
                }
            }
            return columnsWithRulesList;
        }
    }
}
