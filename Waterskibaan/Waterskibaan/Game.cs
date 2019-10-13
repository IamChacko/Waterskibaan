using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System.Windows;

using System.Windows.Threading;

namespace Waterskibaan
{
    public class Game
    {
        public bool _PrintStatus = false;
        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public delegate void LijnenVerplaatst();

        private int counter = 0;

        public WachtrijInstructie wi = new WachtrijInstructie();
        public WachtrijStarten ws = new WachtrijStarten();
        public InstructieGroep ig = new InstructieGroep();
        
        public event NieuweBezoekerHandler NieuweBezoeker;
        public event InstructieAfgelopenHandler instructieAfgelopen;
        public event LijnenVerplaatst _LijnenVerplaatst;
        public Waterskibaan wbaan = new Waterskibaan();

        public void Initialize(DispatcherTimer timer)
        {

            NieuweBezoeker += Wachtrijinstructie;
            instructieAfgelopen += Instructieaa;
            _LijnenVerplaatst += WBLijnenVerplaatst;

            timer.Tick += OnTimedEvent;
            
            
        }
        
        private void OnTimedEvent(object source, EventArgs e)
        {
            counter++;
           
            if (counter % 30 == 0)
            {
                NieuweBezoeker.Invoke(new NieuweBezoekerArgs(new Sporter(MoveCollection.GetWillekeurigeMoves())));
                PrintStatus(); // Voor TestOpdracht12();
            }
            if (counter % 200 == 0)
            {
                int aantal = wi.GetAlleSporters().Count > 5 ? 5 : wi.GetAlleSporters().Count;
                List<Sporter> splijst = wi.SportersVerlatenRij(aantal);
                instructieAfgelopen.Invoke(new InstructieAfgelopenArgs(splijst));
            }
            if (counter % 40 == 0)
            {
                _LijnenVerplaatst.Invoke();
            }
            Console.WriteLine($"Kabel: {wbaan.kabel}");
            


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
            wbaan.VerplaatsKabel();
            if (ws.GetAlleSporters().Count == 0) { return; }
            if (wbaan.kabel.IsStartPositieLeeg())
            {
                Sporter spStart =  ws.SportersVerlatenRij(1)[0];

                spStart.Skies = new Skies();
                spStart.Zwemvest = new Zwemvest();
                wbaan.SporterStart(spStart);
                
            }

            
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
