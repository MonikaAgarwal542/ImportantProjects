using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] arr = { 'N', 'a', 'g', 'a', 'r', 'r', 'o' };
            object str = new string(arr);
            object str2 = new string(arr);
            Console.WriteLine(str == str2);       //print false since both have different references.In object type it checks for the references.
            Console.WriteLine(str2.Equals(str));  //print true since both have same content
            Console.WriteLine(ReferenceEquals(str,str2));    //It check for two reference types

            string s1 = "hello";
            string s2 = "Hello";
            Console.WriteLine(s1 == s2);       //print false because in string type it checks for the value
            Console.WriteLine(s1.Equals(s2));  //print false since both have different content
            Console.WriteLine(ReferenceEquals(s1, s2)); //print false

            string st1 = "hello";
            string st2 = "hello";
            Console.WriteLine(st1 == st2);       //print true because in string type it checks for the value
            Console.WriteLine(st1.Equals(st2));  //print true since both have different content
            Console.WriteLine(ReferenceEquals(st1, st2)); //print true

            object obj1 = new StringBuilder("Hello");
            object obj2 = "Hello";
            Console.WriteLine(obj1 == obj2); // false
            Console.WriteLine(obj1.Equals(obj2));// false
            




        }
    }
}
