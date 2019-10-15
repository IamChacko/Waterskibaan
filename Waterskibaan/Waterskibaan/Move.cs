using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class EenBeen : IMoves
    {
        public string naam = "Een been";
        Random r = new Random();
        public int Move()
        {
            if (r.Next(2) == 1)
            {
                return 50;
            }
            return 0; ;
        }
        public string Naam()
        {
            return naam;
        }
        public override string ToString()
        {
            return $"Een been";
        }
    }

    public class EenHand : IMoves
    {
        public string naam = "Een hand";
        Random r = new Random();
        public int Move()
        {
            if (r.Next(2) == 1)
            {
                return 75;
            }
            return 0; ;
        }
        public string Naam()
        {
            return naam;
        }
        public override string ToString()
        {
            return $"Een hand";
        }
    }

    public class Jump : IMoves
    {
        public string naam = "Jump";
        Random r = new Random();
        public int Move()
        {
            if (r.Next(2) == 1)
            {
                return 150;
            }
            return 0; ;
        }
        public string Naam()
        {
            return naam;
        }
        public override string ToString()
        {
            return $"Jump";
        }
    }
    public class Bewegen : IMoves
    {
        public string naam = "Draai";
        Random r = new Random();
        public int Move()
        {
            if (r.Next(2) == 1)
            {
                return 100;
            }
            return 0; ;
        }
        public string Naam()
        {
            return naam;
        }
        public override string ToString()
        {
            return $"Draai";
        }

    }
}


   