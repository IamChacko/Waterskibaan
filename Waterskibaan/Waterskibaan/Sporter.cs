using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Waterskibaan
{
    public class Sporter
    {
        Random r = new Random();

        public int AantalRondenNogTeGaan { get; set; }
        private static int _SporterID = 0;
        public int SporterID;
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }
        public List<IMoves> Moves { get; set; }
        public int BehaaldePunten { get; set; }
        public IMoves HuidigeMove { get; set; }

        public Sporter(List<IMoves> moves)
        {
            Moves = MoveCollection.GetWillekeurigeMoves();
            AantalRondenNogTeGaan = r.Next(1,3);
            _SporterID++;
            SporterID = _SporterID;
            KledingKleur = Color.FromArgb((byte)r.Next(255), (byte)r.Next(255), (byte)r.Next(255));
        }

        public void DoeMove()
        {
            if (r.Next(4) == 1 && Moves.Count > 0)
            {
                int index = r.Next(Moves.Count);
                HuidigeMove = Moves[index];
            }
        }


        
    }
}

