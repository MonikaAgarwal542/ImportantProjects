using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise8
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<string> pq = new PriorityQueue<string>();
            //For adding the elemnts to the priority queue
            pq.Enqueue(4, "Bhopal");
            pq.Enqueue(3,"Gurugram");
            pq.Enqueue(1, "Hyderabad");
            pq.Enqueue(2, "Bangalore");
            pq.Enqueue(5, "Pune");
            pq.Enqueue(6, "Mumbai");
          
            Console.WriteLine($"Total no. of Items present in this queue are {pq.Count()}");
            Console.WriteLine($"Top item : { pq.Peek()}");
            Console.WriteLine($"Removed item : {pq.Dequeue()}");
            Console.WriteLine($"Total no. of Items present in this queue are {pq.Count()}");
            Console.WriteLine($"Top item: -> { pq.Peek()}");
            Console.WriteLine($"Total no. of Items present in this queue are {pq.Count()}");

            Console.WriteLine($"Contains Pune : { pq.Contains("Pune")}");

            Console.WriteLine($"Highest priority : {pq.GetHighestPriority()}");
           

        }
    }
   
    class PriorityQueue<T> where T : IEquatable<T>
    {
        private IDictionary<int, IList<T>> elements;
        public PriorityQueue() {
            elements = new Dictionary<int, IList<T>>();
           
        }
        public PriorityQueue(IDictionary<int, IList<T>> elements) : this() { }
       
        public int Count() {
            return elements.Count;

        }
        public bool Contains(T item) {
            bool res = false;
            foreach (KeyValuePair<int, IList<T>> pair in elements) {
               
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
        public T Dequeue() {
           
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
        public void Enqueue(int priority,T item)
        {
            IList<T> items;
            if (!elements.ContainsKey(priority))
                elements.Add(priority, new List<T>());
            items = elements[priority];
           // Console.WriteLine(items);
            items.Add(item);


        }
        public T Peek() {

            IList<T> priorityList = elements[elements.Keys.First()];
            return priorityList[0];
        }
        public int GetHighestPriority() {
            int Firstkey = elements.Take(1).Select(d => d.Key).First();
            return Firstkey;
        }
       
        
    }




}





 
   