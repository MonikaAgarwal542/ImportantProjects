using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = -1;
            int num2 = -1;
            int flag = 1;
            while (flag != 0)
            {
                Console.WriteLine("****************Enter two positive non equal integers*****************************");
                Console.Write("Enter the first integer : ");
                
                if (!int.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("NOTE : Enter only integers");
                    break;
                }
                Console.Write("Enter the second integer : ");
                if (!int.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("NOTE : Enter only  integers");
                    break;
                }
                if (2 <= num1 && num1 <= 1000 && num2 >= 2 && num2 <= 1000 && num1 < num2)
                {
                    Console.Write($"Prime numbers between {num1} and {num2} are : ");

                    //Code to print list of prime numbers
                    for (int i = num1; i <= num2; i++)
                    {
                        int c = 0;
                        for (int j = 2; j <= Math.Sqrt(i); j++)
                        {
                            if (i % j == 0) c++;
                        }
                        if (c == 0) Console.Write(i + " ");
                    }
                    Console.WriteLine("");
                    flag = 0;
                }
                else
                {  
                    Console.WriteLine("\nNote:Input two positive non-equal integers (between 2 and 1000) such that first number entered is smaller than second number.");
                    Console.WriteLine("");


                }
            }
            Console.WriteLine("");

        }
    }
}

