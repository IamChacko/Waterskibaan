using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    abstract class Wachtrij
    {
        private Queue<Sporter> queue = new Queue<Sporter>();
        public List<Sporter> GetAlleSporters()
        {
            List<Sporter> spList = new List<Sporter>();
            foreach(Sporter sp in queue)
            {
                spList.Add(sp);
            }
            return spList;
        }

        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
            queue.Enqueue(sporter);
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            List<Sporter> spList = new List<Sporter>();
            for (int i = aantal; i > 0; i++)
            {
                spList.Add(queue.Dequeue());
            }
            return spList;
        }
        public String toString()
        {
            String text = $"Aantal sporters in wachtrij: {queue.Count}";
            return text;
        }
    }
}
