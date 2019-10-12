using System.Collections.Generic;

namespace Waterskibaan
{
    public class Kabel
    {
        public LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();

        public bool IsStartPositieLeeg()
        {
            
            return  _lijnen.First == null || _lijnen.First.Value.PositieOpKabel != 0;
        } 

        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg())
            {
                lijn.PositieOpKabel = 0;
                _lijnen.AddFirst(lijn);

            }
        }

        public void VerschuifLijnen()
        {
            foreach (Lijn lijn in _lijnen)
            {
                if (lijn.PositieOpKabel != 9)
                {
                    lijn.PositieOpKabel++;
                }
                else
                {
                    lijn.PositieOpKabel = 0;
                    lijn.Sp.AantalRondenNogTeGaan--;
                }
                lijn.Sp.DoeMove();
            }
        }

        public Lijn VerwijderLijnVanKabel()
        {
            foreach (Lijn lijn in _lijnen) 
            {
               if (lijn.PositieOpKabel == 9 && lijn.Sp.AantalRondenNogTeGaan == 1)
                {
                    _lijnen.RemoveLast();
                    return lijn;
                }
            }
            return null;
        }

        public override string ToString()
        {
           
            string sreturn = "";
            
                foreach (Lijn lijn in _lijnen)
                {
                sreturn += $"{lijn.PositieOpKabel}|";
                              
                }
            
            return sreturn;
        }

    }
}
