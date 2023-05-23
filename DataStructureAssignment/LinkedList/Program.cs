using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListDS
{    
    class LinkedList
    {

        Node head, last;                      //head of list
        public class Node
        {
            public int data;
            public Node Next;
            public Node(int data)                          //Constructor
            {
                this.data = data;
                Next = null;
            }
        }
        public void Insert(int data)
        {

            Node new_node = new Node(data);
            if (head == null)
            {
                head = new_node;
                last = new_node;

            }
            else
            {
                last.Next = new_node;
                last = last.Next;

            }

        }

        public void InsertAtPosition(int position,int data)
        {
            
            Node new_node = new Node(data);
            if (position == 1)
            {
                new_node.Next = head;
                head = new_node;

            }
            else if (position > Size())
            {
                while (last.Next != null)
                {
                    last = last.Next;

                }
                last.Next = new_node;
                last = last.Next;

            }
            else
            {
                Node n = head;
                for(int i = 1; i < position-1; i++)
                {
                    n = n.Next;

                }
                new_node.Next = n.Next;
                n.Next = new_node;

            }
            

        }
        public void Print()
        {
            Node temp = head;
            if (Size() == 0) {
                Console.WriteLine("Linked List is Empty.");
                return;
            } 
            Console.Write($"Linked List is : {head.data} ");
            while (temp.Next != null)
            {
                Console.Write($"-> {temp.Next.data} ");
                temp = temp.Next;
            }
            Console.WriteLine();
        }
        public int Size()
        {
            Node temp = head;
            int length = 1;
            if (head == null) length = 0;
            else
            {
                while (temp.Next != null)
                {
                    length++;
                    temp = temp.Next;
                }
            }
            return length;
         

        }
        public void Deletefrombegin()
        {
            Console.Write("Old ");
            Print();
            head = head.Next;
            Console.WriteLine("Node deleted successfully!!!");
            Console.Write("New ");
            Print();


        }
        public void Deletefromend()
        {
            Node temp = head;
            Node secondlastnode = head;
            if (Size() == 1)
            {
                Console.Write("Old ");
                Print();
                head = null;
                Console.WriteLine("Node deleted successfully!!!");
                Console.Write("New ");
                Print();
                return;
            }
            Console.Write("Old ");
            Print();
            while (temp.Next != null)
            {
                secondlastnode = temp;
                temp = temp.Next;

            }
            secondlastnode.Next = null;
            Console.WriteLine("Node deleted successfully!!!");
            Console.Write("New ");
            Print();
        }
       public void Delete(int position)
       {
            Node temp = head;
            int p = -1;
            if (head == null)
            {
                Console.WriteLine("Linked List is empty");
                return;
            }
            else
            {
                if (position == 1) Deletefrombegin();
                else if (position == 2) Deletefromend();
                else
                {
                    Console.Write("Old ");
                    Print();
                    Console.Write("Enter the position of the node which is to be deleted : ");
                    if (!int.TryParse(Console.ReadLine(), out p) || p < 0 || p > Size())
                    {
                        Console.WriteLine("Enter the correct position");
                        return;
                    }
                    else
                    {
                        if (p == 1) Deletefrombegin();
                        else if (p == Size()) Deletefromend();
                        else
                        {
                            for(int i = 1; i < p-1; i++)
                            {
                                temp = temp.Next;
                            }
                            temp.Next = temp.Next.Next;
                            temp.Next.Next = null;
                        }
                        Console.Write("New ");
                        Print();
                    }
                }   
            }
       }
        public void Center()
        {
            Node temp = head;
            if (head == null)
            {
                Console.WriteLine("Linked List is empty.");
                return;
            }
            Print();
           
                for (int i = 1; i <= Size() / 2; i++) temp = temp.Next;            //In case of even size,It will print ((n/2)+1)th element.
                Console.WriteLine($"Center of the linked list is : {temp.data}");
        }
        public void Sort() {
           
            Node current = head;
            Node index;
            int temp;
            if (head == null)
            {
                Console.WriteLine("Linked List is empty.");
                return;
            }
            else
            {
                Console.Write("Old ");
                Print();
                while (current != null)
                {
                    
                    index = current.Next;
                    while (index != null)
                    {
                       
                        if (current.data > index.data)
                        {
                            temp = current.data;
                            current.data = index.data;
                            index.data = temp;
                        }

                        index = index.Next;
                    }
                    current = current.Next;
                }
            }
            Console.Write("New ");
            Print();
        
        
        }
        public void Reverse() {
            Node prevnode = null;
            Node currnode = head;
            Node nextnode = head;
            if (head == null)
            {
                Console.WriteLine("Linked List is empty.");
                return;
            }
            else
            {
                Console.Write("Old ");
                Print();
                while (nextnode != null)
                {
                    nextnode = nextnode.Next;
                    currnode.Next = prevnode;
                    prevnode = currnode;
                    currnode = nextnode;
                }
                head = prevnode;
                Console.Write("New ");
                Print();

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList ll = new LinkedList();
            int flag = 1;
            int data = -1;
            while (flag == 1)
            {
                Console.WriteLine("-------------------------------------***********************************---------------------------------------------");
                Console.WriteLine(" 1. Insert \n 2. Insert a node at a given position \n 3. Delete  \n 4. Center of Linked List \n 5. Sort the Linked List \n 6. Reverse the linked list \n 7. Size of Linked List \n 8. Iterate the Linked List \n 9. Print Linked List \n 10. Exit");
                Console.Write("Enter your choice : ");
                int choice = -1;
                
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 10)
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
                                ll.Insert(data);
                                Console.WriteLine("Data added successfully!!!");
                                break;

                            }
                        case 2:
                            int position = -1;
                            Console.Write("Enter the posiiton where node has to be inserted : ");
                            if (!int.TryParse(Console.ReadLine(), out position) || position<=0 || position>ll.Size()+1)
                            {
                                Console.WriteLine("NOTE : Enter the valid position");
                                break;
                            }
                           
                            Console.Write("Enter the data to be inserted : ");
                            if (!int.TryParse(Console.ReadLine(), out data))
                            {
                                Console.WriteLine("NOTE : Enter the valid data");
                                break;
                            }
                            ll.InsertAtPosition(position,data);
                            Console.WriteLine("Data added successfully!!!");
                            break;
                        case 3:
                            int ch = -1;
                            Console.WriteLine("1. Delete from beginning 2. Delete from end 3. Delete at position");
                            Console.Write("Enter your choice : ");
                            if (!int.TryParse(Console.ReadLine(), out ch) || ch<0 || ch>3)
                            {
                                Console.WriteLine("NOTE : Enter the valid choice");
                                break;
                            }
                            ll.Delete(ch);
                            break;
                        case 4:
                            ll.Center();
                            break;
                        case 5:
                            ll.Sort();
                            break;
                        case 6:
                            ll.Reverse();
                            break;
                        case 7:
                            Console.WriteLine($"Size of linked list is {ll.Size()}");
                            break;
                        case 8:
                            ll.Print();
                            break;
                        case 9:
                            ll.Print();
                            break;
                        default :
                            flag = -1;
                            break;

                    }

                }

            }
            
          

        }
    }
}
