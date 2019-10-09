using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class InstructieAfgelopenArgs
    {
        public List<Sporter> lijst { get; set; }
       
        public InstructieAfgelopenArgs(List<Sporter> lijst)
        {
            this.lijst = lijst;
        }
    }
}
