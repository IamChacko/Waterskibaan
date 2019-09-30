﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Waterskibaan
    {
        private Kabel kabel = new Kabel();
        private LijnenVoorraad Lv = new LijnenVoorraad();
        public void VerplaatsKabel()
        {
            kabel.VerschuifLijnen();
            Lv.LijnToevoegenAanRij(kabel.VerwijderLijnVanKabel());
        }

        public Waterskibaan()
        {
            for (int i = 0; i < 15; i++)
            {
                Lv.LijnToevoegenAanRij(new Lijn());
            }
        }

        public void SporterStart(Sporter sp)
        {
            if (kabel.IsStartPositieLeeg())
            {
                Lijn lijn = Lv.VerwijderEersteLijn();
                kabel.NeemLijnInGebruik(lijn);
                lijn.Sp = sp;
            }
        }

        public override string ToString()
        {
            return $"{Lv} {kabel}";
        }
    }


}
