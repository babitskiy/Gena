﻿using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gena
{
    internal class RulesForUserInGroup
    {
        //метод генерации правил для UserInGroup
        public static List<FieldSettingForUserInGroup> GenerateRulesForUserInGroup(IXLWorksheet worksheet, string columnLetter, List<InternalNames> INs, string userInRolePointer)
        {
            //создаём экземпляр правил для пользователя в группе
            var rulesForUserInRoles = new List<FieldSettingForUserInGroup>();

            string currentTypeOfObject = "Поля";

            //for each internalName generate rules in current state
            foreach (var currentInternalName in INs)
            {

                string? valueInCurrentInternalNameCell = Convert.ToString(currentInternalName.InternalName);

                switch (valueInCurrentInternalNameCell)
                {
                    case "Поля":
                        currentTypeOfObject = "Поля";
                        break;

                    case "Кнопки":
                        currentTypeOfObject = "Кнопки";
                        break;

                    case "Вкладки":
                        currentTypeOfObject = "Вкладки";
                        break;

                    default:
                        break;
                }


                if (valueInCurrentInternalNameCell != "" && valueInCurrentInternalNameCell != null && valueInCurrentInternalNameCell != "Поля" && valueInCurrentInternalNameCell != "Кнопки" && valueInCurrentInternalNameCell != "Вкладки")
                {
                    int valueInCell = Convert.ToInt32(worksheet.Cell(currentInternalName.RowNumber, columnLetter).Value);
                    switch (currentTypeOfObject)
                    {
                        case "Поля":
                            rulesForUserInRoles.Add(new FieldSettingForUserInGroup(currentInternalName.InternalName, valueInCell));
                            break;

                        case "Кнопки":
                            Console.WriteLine("Кнопки"); //заглушка для кнопок
                            break;

                        case "Вкладки":
                            Console.WriteLine("Вкладки"); //заглушка для вкладок
                            break;

                        default:
                            break;
                    }
                }
            }
            return rulesForUserInRoles;
        }
    }
}