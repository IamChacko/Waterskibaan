﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class InstructieAfgelopenArgs
    {
        public List<Sporter> lijst { get; set; }
       
        public InstructieAfgelopenArgs(List<Sporter> lijst)
        {
            this.lijst = lijst;
        }

        public List<Sporter> verplaatsBeschikbareSporters()
        {
            List<Sporter> returnLijst = new List<Sporter>();
            returnLijst = lijst;
            lijst.Clear();
            return returnLijst;
        }
    }
}
