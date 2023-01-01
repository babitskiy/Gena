using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gena.Templates.DSO
{
    internal class UserInField
    {
        public string field { get; set; }
        public string fieldName { get; set; }
        public int priority { get; set; }
        public List<FieldSettingForUserInField> fieldSettings { get; set; }
    }
}
