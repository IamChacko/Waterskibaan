using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class EenBeen : IMoves
    {
        Random r = new Random();
        public int Move()
        {
            r.Next(2);
            if (r.Equals(1))
            {
                return 50;
            }
            return 0; ;
        }
        public override string ToString()
        {
            return $"Een been";
        }
    }

    public class EenHand : IMoves
    {
        Random r = new Random();
        public int Move()
        {
            r.Next(2);
            if (r.Equals(1))
            {
                return 75;
            }
            return 0; ;
        }
        public override string ToString()
        {
            return $"Een hand";
        }
    }

    public class Jump : IMoves
    {
        Random r = new Random();
        public int Move()
        {
            r.Next(2);
            if (r.Equals(1))
            {
                return 150;
            }
            return 0; ;
        }
        public override string ToString()
        {
            return $"Jump";
        }
    }
    public class Bewegen : IMoves
    {
        Random r = new Random();
        public int Move()
        {
            r.Next(2);
            if (r.Equals(1))
            {
                return 100;
            }
            return 0; ;
        }
        public override string ToString()
        {
            return $"Draai";
        }
    }
}


   