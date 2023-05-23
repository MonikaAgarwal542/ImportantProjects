using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise17
{
    class InvalidNumberException : Exception
    {
        public InvalidNumberException(string msg):base(msg)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            int nTimesPlayed = 0;


            while (nTimesPlayed < 5)
            {
                try {
                    Console.WriteLine("\n--------------------------------Game Start!!-------------------------------");
                   Console.WriteLine("Enter any number from 1-5");
                    string str = Console.ReadLine();
                    if (!Validation(str, 1, 5, 0))
                    {
                       
                    }
                    else
                    {
                        int number = int.Parse(str);
                        nTimesPlayed++;
                        if (number == 1) { getAnswer("Enter even number :", number); }
                        else if (number == 2) { getAnswer("Enter odd number :", number); }
                        else if (number == 3) { getAnswer("Enter a prime number :", number); }
                        else if (number == 4) { getAnswer("Enter a negative number :", number); }
                        else if (number == 5) { getAnswer("Enter zero :", number); }

                    }
                }
                catch (InvalidNumberException e)
                {
                    Console.WriteLine(e.Message);
                }
             }

            Console.WriteLine("You have played this game for 5 times.");

        }
        static void getAnswer(string str,int selectedNumber)
        {
            Console.WriteLine(str);
            int min = int.MinValue;
            int max = int.MaxValue;
            string inputstring = Console.ReadLine();
           
                if (Validation(inputstring, min, max, selectedNumber))
                {
                    Console.WriteLine("It is a correct answer.");
                }
           
            
        }
        static bool Validation(string inputstr, int min, int max, int selectednumber)
        {
           
           
                int number = -1;
            if (!int.TryParse(inputstr, out number)) throw new InvalidNumberException("Error : Cannot convert string to number.Enter the digits only.");

            else
            {
                int num = int.Parse(inputstr);
                if (num < min || num > max) throw new InvalidNumberException("Error : Number entered is Out Of Range.");


                else
                {
                    if (selectednumber == 1)
                    {
                        if (num % 2 == 0) return true;
                        else throw new InvalidNumberException("It is not even number");
                    }
                    if (selectednumber == 2)
                    {
                        if (num % 2 == 1) return true;
                        else throw new InvalidNumberException("It is not odd number");
                    }
                    if (selectednumber == 3)
                    {
                        if (isPrime(num)) return true;
                        else throw new InvalidNumberException("It is not a prime number");
                    }
                    if (selectednumber == 4)
                    {
                        if (num < 0) return true;
                        else throw new InvalidNumberException("It is not a negative number");
                    }
                    if (selectednumber == 5)
                    {
                        if (num == 0) return true;
                        else throw new InvalidNumberException("It is not a zero number");
                    }

                }
            }
            return true;
        }
        static bool isPrime(long num)
        {
            if (num == 1) return false;
            if (num == 2) return true;
           
            for(int i = 2; i < Math.Sqrt(num); i++)
                if (num % i == 0) return false;
             return true;
            
        }
    }
}

          
       
