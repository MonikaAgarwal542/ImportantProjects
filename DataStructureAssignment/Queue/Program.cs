using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueDS
{
    public class Queue
    {
       
        int[] queue;
        int front,rear,capacity;
        public Queue(int c)
        {
            capacity = c;
            front = 0;
            rear = 0;
            queue = new int[capacity];
        }
        
        public void Enqueue(int data)
        {
            if (rear==capacity)
                Console.WriteLine("Queue is full");
            else
            {
                queue[rear] = data;
                rear++;
                Console.WriteLine("Data added successfully!!!");
            }

        }
        public void Dequeue()
        {
            if (front==rear)
            {
                Console.WriteLine("Queue is empty.");
                return;
            }
            else
            {
                Console.Write("Before Pop -> ");
                Print();
                for (int i = 0; i < rear - 1; i++)
                {
                    queue[i] = queue[i + 1];
                }
                if (rear < capacity)
                    queue[rear] = 0;
                rear--;
                Console.WriteLine("");
                Console.Write("After Pop -> ");
                Print();

            }


        }
        public void Peek()
        {
            if (front == rear)
            {
                Console.WriteLine("Queue is empty.");
                return;
            }
            else
            {
                Console.WriteLine($"Peek element is : {queue[front]}");
            }


        }

        public void Contains(int data)
        {
            int flag = 0;
            for (int i = front; i <rear; i++)
            {
                if (data == queue[i])
                {
                    flag = 1;
                    break;
                }
            }

            if (flag == 1) Console.WriteLine($"Queue Contains {data} : true");
            else Console.WriteLine($"Queue Contains {data} : false");


        }
        public int Size()
        {
            return rear ;

        }
        public void Center()
        {
            if (front==rear)
            {
                Console.WriteLine("Queue is empty");
                return;
            }
            else
            {
                Print();
                Console.WriteLine();
                Console.WriteLine($"Center element is : {queue[Size() / 2]}");
            }



        }
        public void Sort()
        {
            if (front==rear)
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
                        int tmp = 0;
                        if (queue[i] > queue[j])
                        {
                            tmp = queue[i];
                            queue[i] = queue[j];
                            queue[j] = tmp;
                        }
                    }
                }
                Console.WriteLine();
                Console.Write("After Sorting -> ");
                Print();
            }

        }
        public void Reverse()
        {
            int temp;
            if (rear == -1)
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
                    temp = queue[i];
                    queue[i] = queue[Size() - i - 1];
                    queue[Size() - i - 1] = temp;

                }
                Console.WriteLine("");
                Console.Write("After Reverse -> ");
                Print();
            }
        }
        public void Print()
        {
            if (front == rear)
            {
                Console.Write("\nQueue is Empty\n");
                return;
            }
            Console.Write("Elements of the queue are : ");
            for (int i = front; i < rear; i++)
            {
                Console.Write($"{queue[i]} ");
            }

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int capacity;
            Console.WriteLine("Enter the capacity of the queue : ");
            if (!int.TryParse(Console.ReadLine(), out capacity) || capacity <=0)
            {
                Console.WriteLine("NOTE : Enter the valid capacity.");
                return;

            }


            Queue queue = new Queue(capacity);
            int flag = 1;
            int data = -1;
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
                            Console.Write("Enter the data to be inserted : ");
                            if (!int.TryParse(Console.ReadLine(), out data))
                            {
                                Console.WriteLine("NOTE : Enter the valid data");
                                break;
                            }
                            else
                            {
                                queue.Enqueue(data);
                                
                                break;

                            }
                        case 2:
                            queue.Dequeue();
                            break;
                        case 3:
                            queue.Peek();
                            break;
                        case 4:
                            if (queue.Size() <= 0)
                            {
                                Console.WriteLine("Queue is empty.");
                                break;
                            }
                            Console.Write("Enter the data to check : ");
                            if (!int.TryParse(Console.ReadLine(), out data))
                            {
                                Console.WriteLine("NOTE : Enter the valid data");
                                break;
                            }
                            queue.Contains(data);
                            break;
                        case 5:
                            if (queue.Size() <= 0) Console.WriteLine("Queue is empty.");
                            else Console.WriteLine($"Size of the Queue is {queue.Size()}");
                            break;
                        case 6:
                            queue.Center();
                            break;
                        case 7:
                            queue.Sort();
                            break;
                        case 8:
                            queue.Reverse();
                            break;
                        case 9:
                            queue.Print();
                            break;
                        case 10:
                            queue.Print();
                            break;

                        default:
                            flag = -1;
                            break;

                    }

                }

            }
        }
    }
}
