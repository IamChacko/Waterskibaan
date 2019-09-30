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

        public Sporter(List<IMoves> moves)
        {
            Moves = MoveCollection.GetWillekeurigeMoves();
            AantalRondenNogTeGaan = r.Next(1,3);
           
            KnownColor[] Kleurnamen = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = Kleurnamen[r.Next(Kleurnamen.Length)];
            KledingKleur = Color.FromKnownColor(randomColorName);
        }

        
    }
}

