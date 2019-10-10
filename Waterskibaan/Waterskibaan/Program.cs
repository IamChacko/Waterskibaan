using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Program
    {
        static void Main(string[] args)
        {

            //TestOpdracht2();
            // TestOpdracht3();
            // TestOpdracht5();
            //TestOpdracht8();
            //TestOpdracht10();
            //TestOpdracht11();
            TestOpdracht12();
        }
        private static void TestOpdracht2()
        {
            System.Console.WriteLine("Start");
            
            Kabel k = new Kabel();
            Lijn l1 = new Lijn() { PositieOpKabel = 0 };
            Lijn l2 = new Lijn() { PositieOpKabel = 3 };
            Lijn l3 = new Lijn() { PositieOpKabel = 8 };
            Console.WriteLine(k.IsStartPositieLeeg());
            k.NeemLijnInGebruik(l1);
            Console.WriteLine(k.ToString());
            k.VerschuifLijnen();
            k.NeemLijnInGebruik(l2);
            Console.WriteLine(k.ToString());
            k.VerschuifLijnen();
            k.NeemLijnInGebruik(l3);
            Console.WriteLine(k.ToString());
            for (int i = 0; i < 8; i++)
            {
                k.VerschuifLijnen();
            }
            k.VerwijderLijnVanKabel();
            Console.WriteLine(k.ToString());
            k.VerwijderLijnVanKabel();

            Console.WriteLine(k.ToString());
        }

        private static void TestOpdracht3()
        {
            LijnenVoorraad lv = new LijnenVoorraad();
            Lijn l1 = new Lijn() { PositieOpKabel = 0 };
            Lijn l2 = new Lijn() { PositieOpKabel = 3 };
            Lijn l3 = new Lijn() { PositieOpKabel = 8 };
            
            lv.LijnToevoegenAanRij(l1);
            lv.LijnToevoegenAanRij(l2);
            lv.LijnToevoegenAanRij(l3);
            Console.WriteLine(lv);

            lv.VerwijderEersteLijn();
            Console.WriteLine(lv);
        }

        private static void TestOpdracht5()
        {

            foreach (IMoves move in MoveCollection.GetWillekeurigeMoves())
            {
                Console.WriteLine(move);
            }
        }

        private static void TestOpdracht8()
        {
            
            Sporter s = new Sporter(MoveCollection.GetWillekeurigeMoves());
            Waterskibaan waterskibaan = new Waterskibaan();

            s.Zwemvest = new Zwemvest();
            s.Skies = new Skies();

            waterskibaan.SporterStart(s);
            foreach (var punt in s.Moves)
            {
                Console.WriteLine(punt);
            }
            Console.WriteLine(s.KledingKleur);
        }

        private static void TestOpdracht10()
        {
            WachtrijInstructie wi = new WachtrijInstructie();
            wi.SporterNeemPlaatsInRij(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            wi.SporterNeemPlaatsInRij(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            Console.WriteLine(wi);
        }

        private static void TestOpdracht11()
        {
            Game game = new Game();
            game.Initialize();
        }

        private static void TestOpdracht12()
        {
            
            Game game = new Game();
            game._PrintStatus = true;
            game.Initialize();
        }
    }
}
