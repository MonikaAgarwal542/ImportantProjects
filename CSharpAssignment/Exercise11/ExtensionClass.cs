using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11
{
   static  class ExtensionClass
    {
        public static bool isOdd(this int x)
        {
            if (x % 2 == 1) return true;
            else return false;
                    
        }
        public static bool isEven(this int x)
        {
            if (x % 2 == 0) return true;
            else return false;

        }
        public static bool isPrime(this int x)
        {
            if (x == 1) return false;
            if (x == 2) return true;
            for(int i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % 2 == 0) return false;
            }
            return true;


        }
        public static bool isDivisibleBy(this int x,int y)
        {
            if (x % y == 0) return true;
            else return false;

        }
    }
}
