﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class NieuweBezoekerArgs
    {
        public Sporter sp { get; set; }

        public NieuweBezoekerArgs(Sporter sp)
        {
            this.sp = sp;
        }
    }
}
