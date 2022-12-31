using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gena
{
    internal class FieldNotFoundException : Exception
    {
        public FieldNotFoundException(string customMsg) : base(customMsg)
        {

        }
    }
}