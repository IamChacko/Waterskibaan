using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class InstructieGroep : Wachtrij, IWachtrij
    {
        public int MAX_LENGTE_RIJ = 5;

        public override string ToString()
        {
            return $"Instructiegroep: {base.toString()}";
        }
    }
}
