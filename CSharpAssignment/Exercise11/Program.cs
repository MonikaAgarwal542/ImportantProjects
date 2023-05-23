using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11
{
    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program();

            int temp = 1;

            while (temp == 1)
            {
                Console.WriteLine();
                
                Console.WriteLine("Press 1.To test an Odd Number \n      2.To test an Even Number \n      3.To test a Prime Number \n      4.To test divisibility \n      5.Exit");
                int num = int.Parse(Console.ReadLine());
                int i, j;
                if (num == 1)
                {
                    Console.WriteLine("Enter the number");
                    i = int.Parse(Console.ReadLine());
                    if (i.isOdd()) { Console.WriteLine($"{i} is an odd number"); }
                    else Console.WriteLine($"{i} is not an odd number");
                }
                else if (num == 2)
                {
                    Console.WriteLine("Enter the number");
                    i = int.Parse(Console.ReadLine());
                    if (i.isEven()) { Console.WriteLine($"{i} is an even number"); }
                    else Console.WriteLine($"{i} is not an even number");
                }
                else if (num == 3)
                {
                    Console.WriteLine("Enter the number");
                    i = int.Parse(Console.ReadLine());
                    if (i.isPrime()) { Console.WriteLine($"{i} is a prime number"); }
                    else Console.WriteLine($"{i} is not a prime number");

                }
                else if (num == 4)
                {
                    Console.WriteLine("Enter the two numbers");
                    i = int.Parse(Console.ReadLine());
                    j = int.Parse(Console.ReadLine());
                    if (i.isDivisibleBy(j)) { Console.WriteLine($"{i} is divisible by {j}"); }
                    else Console.WriteLine($"{i} is not divisible by {j}");
                }
                else
                {
                    temp = 0;
                }
            }


        }
    }
}


    
    
   

