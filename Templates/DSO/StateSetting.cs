using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gena.Templates.DSO
{
    internal class StateSetting
    {
        public List<UserInField> userInField { get; set; }
        public List<UserInGroup> userInGroup { get; set; }
        public List<FieldSettingsByState> fieldSettingsByState { get; set; }
    }
}
