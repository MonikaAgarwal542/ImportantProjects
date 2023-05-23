using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueDS
{
    public class PriorityQueue
    {
        public int value;
        public int priority;
    }
    
    class Program
    {
       
        static int flag = 1;
        static int value = -1;
        static int priority = -1;
        static int index = -1;
        static int capacity = -1;
        static PriorityQueue[] pq;
        static void Main(string[] args)
        {
           
            Console.WriteLine("Enter the capacity of the priority queue : ");
            if (!int.TryParse(Console.ReadLine(), out capacity) || capacity <= 0)
            {
                Console.WriteLine("NOTE : Enter the valid capacity.");
                return;

            }
            pq = new PriorityQueue[capacity]; ;

            while (flag == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("-------------------------------------***********************************---------------------------------------------");
                Console.WriteLine(" 1. Enqueue \n 2. Dequeue \n 3. Peek  \n 4. Contains \n 5. Size Of Queue \n 6. Center of Queue \n 7. Sort the Queue \n 8. Reverse the Queue \n 9. Iterator \n 10. Print the Queue \n 11.Exit");
                Console.Write("Enter your choice : ");
                int choice = -1;

                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 11)
                {
                    Console.WriteLine("NOTE : Enter the correct choice.");

                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            if (index+1 == capacity)
                            {
                                Console.WriteLine("Queue is full.");
                                break;
                            }
                            Console.Write("Enter the data to be inserted : ");
                            if (!int.TryParse(Console.ReadLine(), out value))
                            {
                                Console.WriteLine("NOTE : Enter the valid data");
                                break;
                            }
                            Console.Write("Enter the priority of the data inserted : ");
                            if (!int.TryParse(Console.ReadLine(), out priority))
                            {
                                Console.WriteLine("NOTE : Enter the valid data");
                                break;
                            }
                            Enqueue(value, priority);
                            break;

                        case 2:
                           
                            Dequeue();
                           
                            break;
                        case 3:
                            
                            if(Peek()!=-1)Console.WriteLine($"Peek element is : {pq[Peek()].value}");
                            break;
                        case 4:
                             if (index == -1)
                             {
                                 Console.WriteLine("Queue is empty.");
                                 break;
                             }
                             Console.Write("Enter the data to check : ");
                             if (!int.TryParse(Console.ReadLine(), out value))
                             {
                                 Console.WriteLine("NOTE : Enter the valid data");
                                 break;
                             }
                             Contains(value);
                            break;
                        case 5:
                            if(Size()!=-1)Console.WriteLine($"Size of the priority Queue is : {Size()}");
                            break;
                        case 6:
                            Center();
                            break;
                        case 7:
                            Sort();
                            break;
                        case 8:
                            Reverse();
                            break;
                        case 9:
                            Print();
                            break;
                        case 10:
                            Print();
                            break;

                        default:
                            flag = -1;
                            break;

                    }

                }

            }
        }
       

        static void Enqueue(int data,int prior)
        {
            index++;
           
           
            pq[index] = new PriorityQueue();
            pq[index].value = data;
            pq[index].priority = prior;
         
        }
        static void Dequeue()
        {
            if (index == -1)
            {
                Console.WriteLine("Queue is empty.");
                return;
            }
            Console.Write("Before Dequeue -> ");
            Print();
            int ind = Peek();

            for (int i = ind; i < index; i++)
            {
                pq[i] = pq[i + 1];
            }

            
            index--;
            Console.WriteLine();
            Console.WriteLine("After Dequeue -> ");
            Print();
        }
        static int Size()
        {
            if (index == -1)
            {
                Console.WriteLine("Queue is empty.");
                return -1;
            }
            return index + 1;
            

        }
        static int Peek()
        {
            if (index == -1)
            {
                Console.WriteLine("Queue is empty.");
                return -1;
            }
            int maxpriority = int.MinValue;
            int ind = -1;
            for(int i = 0; i <= index; i++)
            {
                if (maxpriority == pq[i].priority && ind > -1
                 && pq[ind].value < pq[i].value)
                {
                    maxpriority = pq[i].priority;
                    ind = i;
                }
                else if (maxpriority < pq[i].priority)
                {
                    maxpriority = pq[i].priority;
                    ind = i;
                }
            }
            return ind;

        }
        static void Print()
        {
            if (index==-1)
            {
                Console.WriteLine("Queue is empty.");
                return;
            }
            Console.Write("Priority Queue is : ");
            Console.Write($"({pq[0].value} , {pq[0].priority}) ");
            for (int i = 1; i <= index; i++)
            {
                Console.Write($"-- ({pq[i].value} , {pq[i].priority}) ");

            }
            Console.WriteLine();

        }
        static void Reverse()
        {
            int temp, temp2; ;
           
            if (index == -1)
            {
                Console.WriteLine("Queue is empty.");
                return;
            }
            else
            {
                Console.Write("Before Reverse -> ");
                Print();
                for (int i = 0; i < Size() / 2; i++)
                {
                    temp = pq[i].value;
                    pq[i].value = pq[Size() - i - 1].value;
                    pq[Size() - i - 1].value= temp;
                    temp2 = pq[i].priority;
                    pq[i].priority = pq[Size() - i - 1].priority;
                    pq[Size() - i - 1].priority = temp;


                }
                Console.WriteLine("");
                Console.Write("After Reverse -> ");
                Print();
            }


        }
        static void Sort() {
            if (index == -1)
            {
                Console.WriteLine("Queue is empty");
                return;
            }
            else
            {
                Console.Write("Before Sorting -> ");
                Print();
                for (int i = 0; i < Size(); i++)
                {
                    for (int j = i + 1; j < Size(); j++)
                    {
                        int tmp = 0, temp2 ;
                        if (pq[i].value > pq[j].value)
                        {
                            tmp = pq[i].value;
                            pq[i].value = pq[j].value;
                            pq[j].value = tmp;
                            temp2 = pq[i].priority;
                            pq[i].priority = pq[j].priority;
                            pq[j].priority = temp2;

                        }
                    }
                }
                Console.WriteLine();
                Console.Write("After Sorting -> ");
                Print();
            }
        }
        static void Center()
        {
            if (index == -1)
            {
                Console.WriteLine("Queue is empty");
                return;
            }
            else
            {
                Print();
                Console.WriteLine();
                Console.WriteLine($"Center element is : {pq[(index+1)/2].value}");
            }

        }
        static void Contains(int value) {
            int flag = 0;
            for (int i = 0; i <= index; i++)
            {
                if (value == pq[i].value)
                {
                    flag = 1;
                    break;
                }
            }

            if (flag == 1) Console.WriteLine($"PriorityQueue Contains {value} : true");
            else Console.WriteLine($"PriorityQueue Contains {value} : false");


        }
    }
}
