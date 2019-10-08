using System.Collections.Generic;

namespace Waterskibaan
{
    class Kabel
    {
        private LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();

        public bool IsStartPositieLeeg()
        {
            if (_lijnen.Count != 0)
            {
                if (_lijnen.First.Value.PositieOpKabel == 0)
                {
                    return false;
                }
            }
            return true;
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
                    lijn.PositieOpKabel += 1;
                }
                else
                {
                    lijn.PositieOpKabel = 0;
                    lijn.Sp.AantalRondenNogTeGaan--;
                }
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
