using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------User input to Integer---------------------");
            Console.WriteLine("Input from user:");
            int ans1_int = int.Parse(Console.ReadLine());
            Console.WriteLine("a) Integer is {0}",ans1_int);
            Console.WriteLine("Input from user:");
            int ans2_int = Convert.ToInt32(Console.ReadLine()); ;
            Console.WriteLine("b)Integer is {0}", ans2_int);
            int a;
            Console.WriteLine("Input from user:");
            bool ans3_int =  int.TryParse(Console.ReadLine(),out a);
            Console.WriteLine("c)User Input ia a integer representation: {0}", ans3_int);


            Console.WriteLine("--------------User input to Float---------------------");
            Console.WriteLine("Input from user:");
            float ans1_float = Single.Parse(Console.ReadLine());
            Console.WriteLine("a) Float value is {0}", ans1_float);
            Console.WriteLine("Input from user:");
            float ans2_float = float.Parse(Console.ReadLine());
            Console.WriteLine("b) Float value is {0}", ans2_float);
            Console.WriteLine("Input from user:");
            float ans3_float = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("c) Float value is {0}", ans3_float);


            Console.WriteLine("--------------User input to Boolean---------------------");
            Console.WriteLine("Input from user:");
            bool ans1_bool = bool.Parse(Console.ReadLine());
            Console.WriteLine("a) Boolean value is {0}", ans1_bool);
            Console.WriteLine("Input from user:");
            bool ans2_bool = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("b) Boolean value is {0}", ans2_bool);
            bool b;
            Console.WriteLine("Input from user:");
            bool ans3_bool = Boolean.TryParse(Console.ReadLine(), out b);
            Console.WriteLine("c) String ia a boolean representation: {0}", ans3_bool);



        }
    }
}
