using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class WachtrijInstructie : Wachtrij, IWachtrij
    {
        public int MAX_LENGTE_RIJ = 100;
        public override string ToString()
        {
            return $"WachtrijInstructie: {base.toString()}";
        }
    }
}
