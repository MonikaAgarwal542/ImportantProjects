using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue3<string> pq = new PriorityQueue3<string>();
            //For adding the elemnts to the priority queue
            pq.Enqueue(1, "Hey");
            pq.Enqueue(3, "Hello");
            pq.Enqueue(2, "Welcome");
            pq.Enqueue(4, "Hi");
            pq.Enqueue(5, "Hola");
            pq.Enqueue(6, "Bonjour");

            Console.WriteLine($"Total no. of Items present in this queue are {pq.Count()}");
            Console.WriteLine($"Top item : { pq.Peek()}");
            Console.WriteLine($"Removed item : {pq.Dequeue()}");
            Console.WriteLine($"Total no. of Items present in this queue are {pq.Count()}");
            Console.WriteLine($"Top item: -> { pq.Peek()}");
            Console.WriteLine($"Total no. of Items present in this queue are {pq.Count()}");

            Console.WriteLine($"Contains Pune : { pq.Contains("Pune")}");

        }
    }


    class PriorityQueue3<T> where T : IEquatable<T>
    {

        private IDictionary<int, IList<T>> elements;

        public PriorityQueue3()
        {
            elements = new Dictionary<int, IList<T>>();
        }
        public PriorityQueue3(IEnumerable<T> elements) : this() { }

        public int Count()
        {
            return elements.Count();

        }
        public bool Contains(T item)
        {
            bool res = false;
            foreach (KeyValuePair<int, IList<T>> pair in elements)
            {

                if (pair.Value[0].Equals(item))
                {

                    res = true;
                }
                if (res == true)
                {
                    return res;
                }
            }
            return res;


        }
        public T Dequeue()
        {
            IList<T> list = elements[elements.Keys.First()];
            int priority = elements.Keys.First();
            T highestPriority = list.First();

            list.Remove(highestPriority);
            if (list.Count == 0)
            {
                elements.Remove(priority);
            }
            return highestPriority;

        }
        public void Enqueue(int Priority, T item)
        {
            IList<T> items;
            if (!elements.ContainsKey(Priority))
                elements.Add(Priority, new List<T>());
            items = elements[Priority];
            // Console.WriteLine(items);
            items.Add(item);


        }
        public T Peek()
        {

            IList<T> priorityList3 = elements[elements.Keys.First()];
            return priorityList3[0];

        }
        private int GetHighestPriority()
        {
            int Firstkey = elements.Take(1).Select(d => d.Key).First();
            return Firstkey;
        }

    }
}
