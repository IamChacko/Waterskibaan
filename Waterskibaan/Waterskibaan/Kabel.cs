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
            Lijn lijnswitch = null;
            foreach (Lijn lijn in _lijnen)
            {
                if (lijn.PositieOpKabel == 9)
                {
                    lijnswitch = lijn;
                }
                else
                {
                    lijn.PositieOpKabel++;
                    lijn.Sp.DoeMove();
                }
            }
            if (lijnswitch != null)
            {
                lijnswitch.PositieOpKabel = 0;
                _lijnen.Remove(lijnswitch);
                _lijnen.AddFirst(lijnswitch);
                if (lijnswitch.Sp.AantalRondenNogTeGaan == 1)
                {
                    return;
                }
                lijnswitch.Sp.AantalRondenNogTeGaan--;
            }
            
            
        }

        public Lijn VerwijderLijnVanKabel()
        {
            foreach (Lijn lijn in _lijnen) 
            {
               if (lijn.PositieOpKabel == 9 && lijn.Sp.AantalRondenNogTeGaan <= 1)
                {
                    _lijnen.RemoveLast();
                    return _lijnen.Last.Value;
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
