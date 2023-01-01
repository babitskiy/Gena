using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gena.Templates.DSO
{
    internal class UserInGroup
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public int priority { get; set; }
        public List<FieldSettingForUserInGroup> fieldSettings { get; set; }
    }
}
