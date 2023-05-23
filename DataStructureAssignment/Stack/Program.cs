using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDS
{
   
    class Stack
    {
        static int max =1000;
        int[] stack = new int[max];
        int top = -1;
        public Boolean isFull()
        {
            return top == max - 1;
        }
        public void Push(int data) {
            if (isFull())
                Console.WriteLine("Stack Overflow");
            else {
                stack[++top] = data;
               
            }
                
        }
        public void Pop() {
            if (top == -1) {
                Console.WriteLine("Stack is empty.");
                return ;
            }
            else
            {
                Console.Write("Before Pop -> ");
                Print();
                
                top--;
                Console.WriteLine("");
                Console.Write("After Pop -> ");
                Print();

            }
                
            
        }
        public void Peek() {
            if (top == -1)
            {
                Console.WriteLine("Stack is empty.");
                return;
            }
            else
            {
                Console.WriteLine($"Peek element is : {stack[top]}");
            }


        }

        public void Contains(int data) {
            int flag = 0;
                for (int i = 0; i <= top; i++)
                {
                    if (data == stack[i]) {
                        flag = 1;
                        break;
                    } 
                }
            
            if (flag == 1) Console.WriteLine($"Stack Contains {data} : true");
            else Console.WriteLine($"Stack Contains {data} : false");


        }
        public int Size() {
            return top + 1; ;
        
        }
        public void Center() {
            if (top == -1)
            {
                Console.WriteLine("Stack is empty");
                return ;
            }
            else
            {
                Print();
                Console.WriteLine();
                Console.WriteLine($"Center element is : {stack[Size()/2]}");
            }


        
        }
        public void Sort() {
            if (top == -1)
            {
                Console.WriteLine("Stack is empty");
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
                        if (stack[i] > stack[j])
                        {          
                            tmp = stack[i];               
                            stack[i] = stack[j];           
                            stack[j] = tmp;
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
            if (top == -1)
            {
                Console.WriteLine("Stack is empty.");
                return;
            }
            else
            {
                Console.Write("Before Reverse -> ");
                Print();
                for (int i = 0; i < Size() / 2; i++)
                {
                    temp = stack[i];
                    stack[i] = stack[Size() - i - 1];
                    stack[Size() - i - 1] = temp;

                }
                Console.Write("After Reverse -> ");
                Print();
            }
        }
        public void Print()
        {
            int temp = top;
            if (temp < 0)
            {
                Console.WriteLine("Stack Underflow");
                return;
            }
            Console.Write("Stack is : ");
            while (temp >= 0)
            {
                Console.Write($"{stack[temp--]} ");
            }

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            int flag = 1;
            int data = -1;
            while (flag == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("-------------------------------------***********************************---------------------------------------------");
                Console.WriteLine(" 1. Push \n 2. Pop \n 3. Peek  \n 4. Contains \n 5. Size Of stack \n 6. Center of Stack \n 7. Sort the Stack \n 8. Reverse the Stack \n 9. Iterator \n 10. Print the Stack \n 11.Exit");
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
                                stack.Push(data);
                                Console.WriteLine("Data pushed successfully!!!");
                                break;

                            }
                        case 2:
                            stack.Pop();
                            break;
                        case 3:
                            stack.Peek();
                            break;
                        case 4:
                            if (stack.Size() <= 0) {
                                Console.WriteLine("Stack is empty.");
                                break;
                            }
                            Console.Write("Enter the data to check : ");
                            if (!int.TryParse(Console.ReadLine(), out data))
                            {
                                Console.WriteLine("NOTE : Enter the valid data");
                                break;
                            }
                             stack.Contains(data);
                             break;
                        case 5:
                            if (stack.Size()<=0) Console.WriteLine("Stack is empty.");
                            else Console.WriteLine($"Size of the stack is {stack.Size()}");
                            break;
                        case 6:
                            stack.Center();
                            break;
                        case 7:
                            stack.Sort();
                            break;
                        case 8:
                            stack.Reverse();
                            break;
                        case 9:
                            stack.Print();
                            break;
                        case 10:
                            stack.Print();
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
