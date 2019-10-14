using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public static class MoveCollection
    {
        public static List<IMoves> GetWillekeurigeMoves()
        {
            Random r = new Random();
            List<IMoves> moves = new List<IMoves>();
            for (int i = 0; i <= r.Next(4); i++)
            {
                int ran = r.Next(4);
               
                if (ran == 0)
                {
                    moves.Add(new Bewegen());
                }
                else if (ran == 1)
                {
                    moves.Add(new Jump());
                }
                else if (ran == 2)
                {
                    moves.Add(new EenBeen());
                }
                else if (ran == 3)
                {
                    moves.Add(new EenHand());
                }
            }
            return moves;
        }
    }
}
