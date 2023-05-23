using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise7
{
    class Duck
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int WingsCount { get; set; }
        public Duck() { }
        public Duck(string name, int weight, int wings)
        {
            this.Name=name;
            this.Weight=weight;
            this.WingsCount =wings;
        }
    }
    class Rubber : Duck
    {
        public Rubber(string name, int weight, int wings) : base(name, weight, wings) { }

    }
    class Mallard : Duck
    {
        public Mallard(string name, int weight, int wings) : base(name, weight, wings) { }
    }
    class Redhead : Duck
    {
        public Redhead(string name, int weight, int wings) : base(name, weight, wings) { }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Duck> ducklist = new List<Duck>();
            int count = -1;
            int choice = -1;
            while (count != 1)
            {
                Console.WriteLine();
                Console.WriteLine(" 1. Add a Duck \n 2. Remove a Duck \n 3. Remove All Ducks \n 4. DuckList in increasing order of weights \n 5. DuckList in increasing order of wings \n 6. Exit");
                Console.Write("Enter your choice : ");
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6) Console.WriteLine("NOTE : Select the correct option.");
                else
                {
                    switch (choice)
                    {
                        case 1:
                            AddDuck(ducklist);
                            break;
                        case 2:
                            RemoveDuck(ducklist);
                            break;
                        case 3:
                            if(ducklist.Count>0)
                            {
                                ducklist.Clear();
                                Console.WriteLine("All the ducks have been removed.");
                            }
                            else Console.WriteLine("Duck list is already empty.");
                           
                            break;
                        case 4:
                            SortWeight(ducklist);
                            break;
                        case 5:
                            SortWings(ducklist);
                            break;
                        case 6:
                            count = 1;
                            break;
                        default:
                            Console.WriteLine("NOTE : Select the correct option.");
                            break;

                    }
                }

            }
        }
        public static void AddDuck(List<Duck> list)
        {
            string name;
            int weight;
            int wings;
            int num = -1;
            Console.WriteLine();
            Console.WriteLine(" 1. Add Rubber Duck  2. Add Mallard Duck  3. Add Redhead Duck");
            Console.Write("Enter Your choice : ");
            if (!int.TryParse(Console.ReadLine(), out num) || num < 1 || num > 3)
            {
                
                Console.WriteLine("NOTE: Select the correct option.");
            }
            else
            {
                Console.Write("Enter the name : ");
                name = Console.ReadLine();
                Console.Write("Enter the weight : ");
                weight = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the no.of wings");
                wings = int.Parse(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        list.Add(new Rubber(name, weight, wings));
                        Console.WriteLine("\nA new Duck has been added successfully.\n");
                        break;
                    case 2:
                        list.Add(new Mallard(name, weight, wings));
                        Console.WriteLine("\nA new Duck has been added successfully.\n");
                        break;
                    case 3:
                        list.Add(new Redhead(name, weight, wings));
                        Console.WriteLine("\nA new Duck has been added successfully.\n");
                        break;
                    default :
                        Console.WriteLine("NOTE: Select the correct option.");
                        break;
                }

            }

        }
       public static void RemoveDuck(List<Duck> list)
        {
            if (list.Count > 0)
            {
                DuckList(list);
                int select = -1;
                Console.Write("Select the duck to delete: ");
                if (!int.TryParse(Console.ReadLine(), out select) || select < 1 || select > list.Count)
                {
                    Console.WriteLine("Select the correct duck");
                }
                else
                {
                    list.RemoveAt(select - 1);
                    Console.WriteLine("The selected duck has been deleted");
                }


            }
            else
            {
                Console.WriteLine("Duck list is empty.Nothing to delete.");
            }


        }
        public static void DuckList(List<Duck> list)
        {
            if (list.Count > 0) {
                Console.WriteLine("{0,-15}{1,-20}{2,-15}{3,-15}{4,-10}","No.","DuckType","Name","Weight","Wings");
                for (int i = 0; i < list.Count; i++)
                {
                    string Type = "Rubber";
                    if (list[i] is Mallard) Type = "Mallard";
                    if (list[i] is Redhead) Type = "Redhead";
                    Console.WriteLine("{0,-15}{1,-20}{2,-15}{3,-15}{4,-10}", (i + 1),Type, list[i].Name, list[i].Weight,list[i].WingsCount);

                }


            }
            else
            {
                Console.WriteLine("Duck list is empty.");

            }
        }
        public static void SortWeight(List<Duck> list)
        {
            if (list.Count > 0)
            {
                var ducklist = from x in list
                               orderby x.Weight
                               select x;
                Console.WriteLine("{0,-15}{1,-20}{2,-15}{3,-15}", "No.", "Name", "Weight", "Wings");
                int i = 0;
                foreach (var duck in ducklist)
                {

                    Console.WriteLine("{0,-15}{1,-20}{2,-15}{3,-15}", (i + 1), duck.Name, duck.Weight, duck.WingsCount);
                    i++;
                }

            }
            
             else
            {
                Console.WriteLine("Duck list is empty");
            }
        }
        public static void SortWings(List<Duck> list)
        {
            if (list.Count > 0)
            {
                var ducklist = from x in list
                               orderby x.WingsCount
                               select x;
                Console.WriteLine("{0,-15}{1,-20}{2,-15}{3,-15}", "No.", "Name", "Weight", "Wings");
                int i = 0;
                foreach (var duck in ducklist)
                {

                    Console.WriteLine("{0,-15}{1,-20}{2,-15}{3,-15}", (i + 1), duck.Name, duck.Weight, duck.WingsCount);
                    i++;
                }

            }
            else
            {
                Console.WriteLine("Duck list is empty");
            }
            
        }
    }
}
