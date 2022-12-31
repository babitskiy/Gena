using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gena
{
    internal class DocumentStateDSO
    {
        public int docState { get; set; }
        public string stateName { get; set; }
        public List<StateSetting> stateSettings { get; set; }
    }
}
