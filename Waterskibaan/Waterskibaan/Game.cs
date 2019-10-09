using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;


namespace Waterskibaan
{
    class Game
    {
        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);

        private static System.Timers.Timer aTimer;
        private static int counter = 0;

        WachtrijInstructie wi = new WachtrijInstructie();
        InstructieGroep ig = new InstructieGroep();
        
        public event NieuweBezoekerHandler NieuweBezoeker;
        public event InstructieAfgelopenHandler instructieAfgelopen;
        public static Waterskibaan wbaan = new Waterskibaan();

        public void Initialize()
        {
            SetTimer();
            Console.WriteLine("Start spel");
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();
            NieuweBezoeker += Wachtrijinstructie;
            instructieAfgelopen += Instructieaa;
        }
        private  void SetTimer()
        {
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            
            
            if (counter % 3 == 0)
            {
                NieuweBezoeker.Invoke(new NieuweBezoekerArgs(new Sporter(MoveCollection.GetWillekeurigeMoves())));
            }
            if (counter % 20 == 0)
            {
                int aantal = wi.GetAlleSporters().Count;
                instructieAfgelopen.Invoke(new InstructieAfgelopenArgs(wi.SportersVerlatenRij(aantal < 5 ? aantal : 5)));
            }
            counter++;
        }
        public void Wachtrijinstructie(NieuweBezoekerArgs nba)
        {
            wi.SporterNeemPlaatsInRij(nba.sp);
        }
        public void Instructieaa(InstructieAfgelopenArgs iaa)
        {
            foreach (Sporter sp in iaa.lijst) {
                ig.SporterNeemPlaatsInRij(sp);
                    }
        }

    }
}
