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
        public bool _PrintStatus = false;
        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public delegate void LijnenVerplaatst();

        private static System.Timers.Timer aTimer;
        private int counter = 0;

        WachtrijInstructie wi = new WachtrijInstructie();
        WachtrijStarten ws = new WachtrijStarten();
        InstructieGroep ig = new InstructieGroep();
        
        public event NieuweBezoekerHandler NieuweBezoeker;
        public event InstructieAfgelopenHandler instructieAfgelopen;
        public event LijnenVerplaatst _LijnenVerplaatst;
        public static Waterskibaan wbaan = new Waterskibaan();

        public void Initialize()
        {
            SetTimer();
            Console.WriteLine("Start spel");
            NieuweBezoeker += Wachtrijinstructie;
            instructieAfgelopen += Instructieaa;
            _LijnenVerplaatst += WBLijnenVerplaatst;
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();
            
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
            counter++;
            if (counter % 3 == 0)
            {
                NieuweBezoeker.Invoke(new NieuweBezoekerArgs(new Sporter(MoveCollection.GetWillekeurigeMoves())));
                PrintStatus(); // Voor TestOpdracht12();
            }
            if (counter % 20 == 0)
            {
                int aantal = wi.GetAlleSporters().Count > 5 ? 5 : wi.GetAlleSporters().Count;
                List<Sporter> splijst = wi.SportersVerlatenRij(aantal);
                instructieAfgelopen.Invoke(new InstructieAfgelopenArgs(splijst));
            }
            if (counter % 4 == 0)
            {
                _LijnenVerplaatst.Invoke();
            }
            


        }
        public void Wachtrijinstructie(NieuweBezoekerArgs nba)
        {
            wi.SporterNeemPlaatsInRij(nba.sp);
        }
        public void Instructieaa(InstructieAfgelopenArgs iaa)
        {
            if (ig.GetAlleSporters().Count > 0) {
                List<Sporter> UitInstructie = ig.SportersVerlatenRij(ig.GetAlleSporters().Count);
                foreach (Sporter sp in UitInstructie)
                {
                    ws.SporterNeemPlaatsInRij(sp);
                }
            }

            foreach (Sporter sp in iaa.lijst) {
               ig.SporterNeemPlaatsInRij(sp);
                        }
            

        }

        public void WBLijnenVerplaatst()
        {
            if (wbaan.kabel.IsStartPositieLeeg())
            {
                List<Sporter> Sporterstart = ws.SportersVerlatenRij(1);
                foreach (Sporter sp in Sporterstart)
                {
                    sp.Skies = new Skies();
                    sp.Zwemvest = new Zwemvest();
                    wbaan.SporterStart(sp);
                }
            }

            wbaan.VerplaatsKabel(); 
        }
        public void PrintStatus()
        {
            if (_PrintStatus)
            {
                Console.WriteLine(wi);
                Console.WriteLine(ws);
                Console.WriteLine($"{ig}\n");
            }
        }
    }
     

    }
