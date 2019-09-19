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
            
            TestOpdracht2();
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
    }
}
