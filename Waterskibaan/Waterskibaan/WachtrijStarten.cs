using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class WachtrijStarten : Wachtrij, IWachtrij
    {
        
        public int MAX_LENGTE_RIJ = 20;

        public override string ToString()
        {
            return $"WachtrijStarten: {base.toString()}";
        }
    }
}
