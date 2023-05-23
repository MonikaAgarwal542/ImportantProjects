using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise13
{
    class Program
    {
        static void Main(string[] args)
        {
           var arr = new int[]{ 3,1,45,3,40,50,10,5,200};
            Console.Write("List of the elements is : ");
            foreach (int i in arr) Console.Write(" "+i);
            Console.WriteLine("");
            Console.WriteLine();
            Console.WriteLine("1. Is All Numbers are multiple of 5 : {0}", arr.CustomAll(x => x%5==0));
            Console.WriteLine("2. Is Any Numbers are multiple of 5 : {0}", arr.CustomAny(x => x % 5 == 0));
              Console.WriteLine("3. Max element is : {0}", arr.CustomMax(x => x));
            Console.WriteLine("4. Min element is : {0}", arr.CustomMin(x => x));

            Console.WriteLine("5. Using Where Operator : {0}", string.Join(" ", arr.CustomWhere(x => x<5)));
            Console.WriteLine("6. Using Select Operator : {0}", string.Join(" ",arr.CustomSelect(x => x>40)));


        }
    }
     static class EnumerableExtensions
    {
        public static bool CustomAll<T>(this IEnumerable<T> enumerable,Func<T, bool> func) {
            foreach(var element in enumerable){
                if (!func(element)) return false;
            }

            return true;
        }
        public static bool CustomAny<T>(this IEnumerable<T> enumerable, Func<T, bool> func) {
            foreach (var element in enumerable)
            {
                if (func(element)) return true;
            }

            return false;
        }
       public static TResult CustomMax<T,TResult>(this IEnumerable<T> enumerable, Func<T, TResult> func) where TResult:IComparable<TResult> {

            return enumerable.Max(func);
        }
        public static TResult CustomMin<T,TResult>(this IEnumerable<T> enumerable, Func<T, TResult> func) where TResult : IComparable<TResult>
        {
            return enumerable.Min(func);
        }

        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> enumerable, Func<T, bool> func) {
            foreach(var elem in enumerable)
            {
                if (func(elem)) yield return elem;
            }
           
        }
        public static IEnumerable<TResult> CustomSelect<T,TResult>(this IEnumerable<T> enumerable, Func<T, TResult> func) {
            foreach (var elem in enumerable)
            {
                yield return func(elem);
            }
        }



    }
}
