using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Logger
    {
        public Kabel kabel;
        public int Rodeshirts = 0;
        List<Sporter> Lijst = new List<Sporter>();
        public void VoegBezoekerToe(Sporter sp)
        {
            Lijst.Add(sp);
            if (ColorsAreClose(sp.KledingKleur, Color.Red))
            {
                Rodeshirts++;
            }
        }

        public int AantalBezoekers()
        {
            return Lijst.Count;
        }

        public Sporter Highscore()
        {
            var highscore = Lijst.OrderByDescending(x => x.BehaaldePunten).FirstOrDefault();
            return highscore;
        }   

        public int TotaleRondes()
        {
            int tot = 0;
            var totrondes = (from item in Lijst where item.AantalRondenGedaan > 0 select item.AantalRondenGedaan);
            foreach (int ronde in totrondes)
            {
                tot += ronde;
            }
            return tot;


        }

        private bool ColorsAreClose(Color a, Color z, int threshold = 90)
        {
            int r = (int)a.R - z.R,
                g = (int)a.G - z.G,
                b = (int)a.B - z.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }
        public int bepaalLichtheid(Color kleur)
        {
            int lichtheid = kleur.R * kleur.R + kleur.G * kleur.G + kleur.B * kleur.B;
            return lichtheid;
        }
        public List<Sporter> getLichsteSporters()
        {
            var lichste = Lijst.OrderByDescending(x => bepaalLichtheid(x.KledingKleur)).Take(10);
            List<Sporter> lijst = lichste.ToList();
            return lijst;
        }

        public List<IMoves> Uniekemoves()
        {
            var uniek = (from item in Lijst where item.HuidigeMove != null select item.HuidigeMove).Distinct().ToList() ;
            return uniek;
        }
        
    }
}
