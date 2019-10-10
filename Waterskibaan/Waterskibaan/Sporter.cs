using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Waterskibaan
{
    class Sporter
    {
        Random r = new Random();

        public int AantalRondenNogTeGaan { get; set; }
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }
        public List<IMoves> Moves { get; set; }
        public int BehaaldePunten { get; set; }
        public IMoves HuidigeMove { get; set; }

        public Sporter(List<IMoves> moves)
        {
            Moves = MoveCollection.GetWillekeurigeMoves();
            AantalRondenNogTeGaan = r.Next(0,3);
           
            KnownColor[] Kleurnamen = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = Kleurnamen[r.Next(Kleurnamen.Length)];
            KledingKleur = Color.FromKnownColor(randomColorName);
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

