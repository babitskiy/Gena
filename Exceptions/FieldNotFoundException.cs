using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gena
{
    internal class UniversalException : Exception
    {
        public UniversalException(string customMsg) : base(customMsg)
        {

        }
    }
}