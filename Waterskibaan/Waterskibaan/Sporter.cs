using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Sporter : Zwemvest Zwe
    {
        public int AantalRondenNogTeGaan { get; set; }
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set }
        public List<IMoves> Moves { get; set; }

        public Sporter(List<IMoves> moves)
        {
            Moves = moves;
            AantalRondenNogTeGaan = 0;
        }

        public int Move()
        {
            throw new NotImplementedException();
        }
    }

    interface IMoves
    {
        int Move(); 
    }
}
