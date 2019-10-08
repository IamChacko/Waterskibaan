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
        private static System.Timers.Timer aTimer;
        private static int counter = 0;
        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;
        public static Waterskibaan wbaan = new Waterskibaan();
        Waterskibaan wb = new Waterskibaan();
        
        public void Initialize()
        {
            SetTimer();
            Console.WriteLine("Start spel");
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();
        }
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            
            
            if (counter % 3 == 0)
            {
                wbaan.SporterStart(new Sporter(MoveCollection.GetWillekeurigeMoves()));
                Console.WriteLine(wbaan.ToString());
                wbaan.VerplaatsKabel();


            }
            counter++;
        }
    }
}
