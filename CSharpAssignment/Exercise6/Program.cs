using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    class Equipment
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double MaintenanceCost { get; set; }
        public Equipment(string name,string description,double cost)
        {
            Name = name;
            Description = description;
            MaintenanceCost = cost;

        }
        public Equipment() { }
    }
    class Mobile : Equipment
    {
        public int DistanceMoved { get; set; }
        public Mobile(string name, string description, double cost) : base(name, description, cost) {
            this.DistanceMoved = 0;
        }

    }
    class Immobile : Equipment
    {
        public Immobile(string name, string description, double cost) : base(name, description, cost) { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Equipment> equipmentlist = new List<Equipment>();
            int num = -1;
            int choice = -1;
            while (num != 1)
            {
               
                Console.WriteLine();
                Console.WriteLine("***************************Equipment Inventory*****************************************");
                Console.WriteLine("1. Create an equipment – mobile and immobile");
                Console.WriteLine("2. Delete an equipment");
                Console.WriteLine("3. Move an equipment – mobile and immobile");
                Console.WriteLine("4. List all equipment.");
                Console.WriteLine("5. Show details of an equipment.");
                Console.WriteLine("6. List all mobile equipment");
                Console.WriteLine("7. List all Immobile equipment");
                Console.WriteLine("8. List all equipment that have not been moved till now");
                Console.WriteLine("9. Delete all equipment");
                Console.WriteLine("10. Delete all immobile equipment");
                Console.WriteLine("11. Delete all mobile equipment");
                Console.WriteLine("12. Exit");
                Console.Write("Enter your Choice : ");
                if (!int.TryParse(Console.ReadLine(), out choice)) Console.WriteLine("NOTE : Select the correct option.");
                else
                {
                    switch (choice)
                    {
                        case 1:
                            CreateEquipment(equipmentlist);
                             break;
                        case 2:
                            DeleteEquipmemt(equipmentlist);
                            break;
                        case 3:
                            MoveEquipment(equipmentlist);
                            break;
                        case 4:
                            ListAllEquipments(equipmentlist);
                            break;
                        case 5:
                            Details(equipmentlist);
                            break;
                        case 6:
                            ListMobileEquipments(equipmentlist);
                            break;
                        case 7:
                            ListImmobileEquipment(equipmentlist);
                            break;
                        case 8:
                            ListEquipmentsNotBeenMovedTillNow(equipmentlist);
                            break;
                        case 9:
                            equipmentlist.Clear();
                            Console.WriteLine("All equipments have been deleted");
                            break;
                        case 10:
                            equipmentlist.RemoveAll(x => x is Immobile);
                            Console.WriteLine("All Immobile equipments have been deleted");
                            break;
                        case 11:
                            equipmentlist.RemoveAll(x => x is Mobile);
                            Console.WriteLine("All Mobile equipments have been deleted");
                            break;
                        case 12:
                            num = 1;
                            break;
                        default:
                            Console.Write("NOTE: Select correct option: ");
                            break;
                   
                    }
                }
            }

        }
        static void CreateEquipment(List<Equipment> list) {
            string name;
            string description;
            double maintenancecost;
           
            int num;
           
                Console.WriteLine();
                Console.WriteLine(" 1. Create Mobile Equipment \n 2. Create Immobile Equipment");
                Console.Write("Enter Your choice : ");
                if (!int.TryParse(Console.ReadLine(), out num) || num < 1 || num > 2)
                {
                    Console.WriteLine("NOTE: Select the correct option.");
                }
               
                else
                {
                   
                    Console.Write("Enter the name : ");
                    name = Console.ReadLine();
                    Console.Write("Enter the description : ");
                    description = Console.ReadLine();
                    
                        Console.Write("Enter the maintenance cost : ");
                        if (!double.TryParse(Console.ReadLine(), out maintenancecost) || maintenancecost < 0)
                        {
                            Console.WriteLine("NOTE : Enter the valid maintenance cost.");

                        }
                        else
                        {
                            switch (num)
                            {
                                case 1:
                                    list.Add(new Mobile(name, description, maintenancecost));
                                    Console.WriteLine("\nA new Equipment has been added successfully.\n");

                                    break;
                                case 2:
                                    list.Add(new Immobile(name, description, maintenancecost));
                                    Console.WriteLine("\nA new Equipment has been added successfully.\n");

                                    break;
                               
                                default:
                                    Console.WriteLine("Note : Select the correct option");
                                    break;

                            }
               
                }
            }       
        }
        static void DeleteEquipmemt(List<Equipment> list) {
            if (list.Count > 0) {
                Console.WriteLine();
                Console.WriteLine("List of the equipments is : ");
                ListAllEquipments(list);
                int select = -1;
                Console.Write("Select the equipment to delete: ");
                if(!int.TryParse(Console.ReadLine(),out select) || select<1 || select > list.Count)
                {
                    Console.WriteLine("Select the correct equipment");
                }
                else
                {
                    list.RemoveAt(select - 1);
                    Console.WriteLine("The selected equipment has been deleted");
                }

            }
            else
            {
                Console.WriteLine("Equipment list is empty.");
            }
            
        }
        static void MoveEquipment(List<Equipment> list) {
            if (list.Count > 0) {
                ListAllEquipments(list);
                int select = -1;
                Console.Write("\nSelect the mobile equipment: ");
                if(!int.TryParse(Console.ReadLine(), out select) || select < 0 || select > list.Count)
                {
                    Console.WriteLine("\nSelect the correct equipment");
                }
                else
                {
                    if(list[select-1] is Mobile)
                    {
                        int dist=-1;
                        Console.Write("\nEnter the distance to move mobile equipment: ");
                        if (!int.TryParse(Console.ReadLine(), out dist) || dist < 0) Console.WriteLine("Enter the correct distance to move");
                        else
                        {
                           ( (Mobile)list[select - 1]).DistanceMoved = dist;
                        }

                    }
                    else
                    {
                        Console.WriteLine("\nSelect Mobile equipment.\n");
                    }
                    Console.WriteLine();
                }
            
            }
            else
            {
                Console.WriteLine("Equipment list is empty.");
            }
        
        }
        static void ListAllEquipments(List<Equipment> list) {
            if (list.Count > 0) {
                Console.WriteLine("{0,-15}{1,-22}{2,-15}","No.","Name","Description");
                for(int i = 0; i < list.Count; i++) {
                    Console.WriteLine("{0,-15}{1,-22}{2,-15}",(i+1),list[i].Name,list[i].Description);

                }
               
            }
            else Console.WriteLine("Equipments list is empty.");
        
        
        
        }
        static void Details(List<Equipment> list) {
            if (list.Count > 0)
            {
                Console.WriteLine("{0,-15}{1,-22}{2,-15}{3,-15}{4,-20}", "No.", "Type","Name","Cost", "Description");
                for (int i = 0; i < list.Count; i++)
                {
                    string Type = "Immobile";
                    if (list[i] is Mobile) Type = "Mobile";
                    Console.WriteLine("{0,-15}{1,-22}{2,-15}{3,-15}{4,-20}", (i + 1),Type, list[i].Name, list[i].MaintenanceCost,list[i].Description);

                }

            }
            else
            {
                Console.WriteLine("Equipment list is empty");
            }
        
        
        
        }
        static void ListMobileEquipments(List<Equipment> list) {

            if (list.Count > 0)
            {

                Console.WriteLine("{0,-15}{1,-22}{2,-15}{3,-15}{4,-20}{5,-20}", "No.", "Type", "Name", "Cost", "Description","Distance Moved");
                int i = 0;
                foreach(Equipment e in list.FindAll(x=>x is Mobile))
                {
                    Console.WriteLine("{0,-15}{1,-22}{2,-15}{3,-15}{4,-20}{5,-20}", (i + 1), "Mobile", e.Name, e.MaintenanceCost, e.Description,(((Mobile)e).DistanceMoved));
                    i++;
                }

            }
            else
            {
                Console.WriteLine("Equipment list is empty");
            }

        }
        static void ListImmobileEquipment(List<Equipment> list) {

            if (list.Count > 0)
            {

                Console.WriteLine("{0,-15}{1,-22}{2,-15}{3,-15}{4,-20}", "No.", "Type", "Name", "Cost", "Description");
                int i = 0;
                foreach (Equipment e in list.FindAll(x => x is Immobile))
                {
                    Console.WriteLine("{0,-15}{1,-22}{2,-15}{3,-15}{4,-20}", (i + 1), "Immobile", e.Name, e.MaintenanceCost, e.Description);
                    i++;
                }

            }
            else
            {
                Console.WriteLine("Equipment list is empty");
            }
        }
        static void ListEquipmentsNotBeenMovedTillNow(List<Equipment> list) {

            if (list.Count > 0) {

                Console.WriteLine("{0,-15}{1,-22}{2,-15}{3,-15}{4,-20}", "No.", "Type", "Name", "Cost", "Description");
                int i = 0;
                foreach (Equipment e in list.FindAll(x => x is Mobile && (((Mobile)x).DistanceMoved)==0))
                {
                    Console.WriteLine("{0,-15}{1,-22}{2,-15}{3,-15}{4,-20}", (i + 1), "Mobile", e.Name, e.MaintenanceCost, e.Description);
                    i++;
                }

            }
            else
            {
                Console.WriteLine("Equipments list is empty");
            }

        }
    }

}

