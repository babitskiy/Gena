using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gena
{
    internal class FieldSettingForUserInGroup
    {
        public string name { get; set; }
        public bool hidden { get; set; }
        public bool required { get; set; }
        public bool readOnly { get; set; }

        //конструктор класса
        public FieldSettingForUserInGroup(string internalName, int parameter)
        {
            name = internalName;
            switch (parameter)
            {
                case 0:
                    readOnly = false; hidden = true; required = false;
                    break;
                case 1:
                    readOnly = true; hidden = false; required = false;
                    break;
                case 2:
                    readOnly = false; hidden = false; required = false;
                    break;
                case 3:
                    readOnly = false; hidden = false; required = true;
                    break;
                default:
                    break;
            }
        }
        public FieldSettingForUserInGroup() { }
    }
}
