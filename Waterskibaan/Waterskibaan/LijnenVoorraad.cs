﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class LijnenVoorraad
    {
        private Queue<Lijn> _lijnen = new Queue<Lijn>();
        public void LijnToevoegenAanRij(Lijn lijn)
        {
            if (lijn != null)
            {
                _lijnen.Enqueue(lijn);
            }
        }

        public Lijn VerwijderEersteLijn()
        {
            if (GetAantalLijnen() != 0)
            {
                return _lijnen.Dequeue();
            } else
            {
                return null;
            }
        }

        public int GetAantalLijnen()
        {
                return _lijnen.Count();
            
        }

        public override string ToString()
        {
            return $"{GetAantalLijnen()} lijnen op voorraad";
        }
    }
}
