using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise12
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ls = new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 ,10,34,56,14,98};
            
            IEnumerable<int> oddNumbers=ls.Where(x => x % 2 == 1);
           
            PrintOutput("1.Odd Numbers are : ", oddNumbers);
            IEnumerable<int> evenNumbers = ls.Where(x =>
            {
                return x % 2 == 0;
            });
            PrintOutput("2.Even Numbers are : ", evenNumbers);
            IEnumerable<int> primeNumbers = ls.Where(delegate (int x)
              {
                  if (x <= 1) return false;
                  if (x == 2) return true;
                  for (int i = 2; i <= Math.Sqrt(x); i++)
                  {
                      if (x % i == 0) return false;
                  }
                  return true;
              });
            PrintOutput("3.Prime Numbers are : ", primeNumbers);

            IEnumerable<int> prime = ls.Where(x =>
            {
                if (x <= 1) return false;
                if (x == 2) return true;
                for (int i = 2; i <= Math.Sqrt(x); i++)
                {
                    if (x % i == 0) return false;
                }
                return true;
            }
            );
            PrintOutput("5.Prime Numbers are : ", prime);

            Func<int, bool> greater = GreaterThanFive;
            IEnumerable<int> greaterthanfive = ls.Where(greater);
            PrintOutput("4.Numbers greater than 5 are : ", greaterthanfive);

            Func<int, bool> less = new Func<int,bool>(LessThanFive);
            IEnumerable<int> lessthanfive = ls.Where(less);
            PrintOutput("6.Numbers less than 5 are : ", lessthanfive);

            Func<int, bool> condition3k = new Func<int, bool>(x=>x%3==0);
            IEnumerable<int> list3k = ls.Where(condition3k);
            PrintOutput("7.3k list is  : ", list3k);

            Func<int, bool> condition3kplus1 = new Func<int, bool>(delegate(int x) {
                return x % 3 == 1;
                });
            IEnumerable<int> list3kplus1 = ls.Where(condition3kplus1);
            PrintOutput("8.3k+1 list is  : ", list3kplus1);


            Func<int, bool> condition3kplus2 = x => x % 3 == 2;
            IEnumerable<int> list3kplus2 = ls.Where(condition3kplus2);
            PrintOutput("9.3k+2 list is  : ", list3kplus2);

            Func<int, bool> Anything = delegate (int x) { return x != 0; };
            IEnumerable<int> anything = ls.Where(Anything);
            PrintOutput("10.Anything  : ", anything);

            Func<int, bool> Anything2 = AnythingMethod;
            IEnumerable<int> anything2 = ls.Where(Anything2);
            PrintOutput("11.Anything  : ", anything2);
            Console.WriteLine();
        }

        static void PrintOutput(string str,IEnumerable<int> list)
        {
            Console.WriteLine();
            Console.Write(str);
            foreach(int i in list) Console.Write(i+" ");
        }
        public static bool GreaterThanFive(int x)
        {
            return x > 5;
        }
        public static bool LessThanFive(int x)
        {
            return x < 5;
        }
        public static bool AnythingMethod(int x) { return x != 0; }

    }
}
