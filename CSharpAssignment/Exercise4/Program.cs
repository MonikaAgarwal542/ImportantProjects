using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    enum EquipmentType
    {
        Mobile,
        Immobile
    }
    abstract class Equipment
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DistanceMovedTillDate { get; set; }
        public int MaintenanceCost { get; set; }
        public EquipmentType Equip { get; set; }                    //EquipmentType is a enum

        public virtual void MoveBy(int distanceToMove)
        {
            DistanceMovedTillDate += distanceToMove;
        }
        public abstract void ShowDetails();                          //This method has to be defined in child class

    }
    class MobileType : Equipment
    {
        public int NumberOfWheels { get; set; }

        public override void MoveBy(int distanceToMove)
        {
            base.MoveBy(distanceToMove);
            MaintenanceCost += NumberOfWheels * DistanceMovedTillDate;
        }
        public override void ShowDetails()                                  //Overriden method
        {
            Console.WriteLine();
            Console.WriteLine("Details Of the selected Equipment are : ");
            Console.WriteLine("  1.Type Of Equipment: {0}", EquipmentType.Mobile);
            Console.WriteLine("  2.Total Distance moved till date : {0} Km", DistanceMovedTillDate);
            Console.WriteLine("  3.Maintenance Cost: Rs.{0}", MaintenanceCost);
        }

    }

    class ImmobileType : Equipment
    {
        public int Weight { get; set; }

        public override void MoveBy(int distanceToMove)
        {
            base.MoveBy(distanceToMove);
            MaintenanceCost += Weight * DistanceMovedTillDate;
        }
        public override void ShowDetails()                                   //Overriden method
        {
            Console.WriteLine();
            Console.WriteLine("Details Of the selected Equipment are : ");
            Console.WriteLine("  1.Type Of Equipment: {0}", EquipmentType.Immobile);
            Console.WriteLine("  2.Total Distance moved till date : {0} Km", DistanceMovedTillDate);
            Console.WriteLine("  3.Maintenance Cost: Rs.{0}", MaintenanceCost);

        }

    }


    class Program
    {
       
       
        static void Main(string[] args)
        {
            int temp = 1;
            int input = -1;
            while (temp == 1)
            {
                Console.WriteLine("-----------------------------------------********************************************----------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Choose the Equipment : \n 1: Mobile \n 2: Immobile \n 3: Exit");
               
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("NOTE : Enter only integers");
                    
                }
                else
                {
                    switch (input)
                    {
                        case 1:
                            MobileType Jeep = new MobileType();
                            Console.Write("Enter the number of wheels : ");
                            int noofwheels = -1;
                            int distance = -1;
                            int movedistance = -1;
                            if (!int.TryParse(Console.ReadLine(), out noofwheels) || noofwheels < 0)
                            {
                                Console.WriteLine("NOTE : Enter valid number");
                                break;
                            }
                            Console.Write("Enter the distance moved till date(in km) : ");
                            if (!int.TryParse(Console.ReadLine(), out distance) || distance < 0)
                            {
                                Console.WriteLine("NOTE : Enter valid number");
                                break;
                            }
                            Console.Write("Enter the distance to move(in km) : ");
                            if (!int.TryParse(Console.ReadLine(), out movedistance) || movedistance < 0)
                            {
                                Console.WriteLine("NOTE : Enter valid number");
                                break;
                            }
                            Jeep.NumberOfWheels = noofwheels;
                            Jeep.DistanceMovedTillDate = distance;
                            Jeep.MoveBy(movedistance);
                            Jeep.ShowDetails();
                            break;
                        case 2:
                            ImmobileType ladder = new ImmobileType();
                            int weight = -1;
                            int distancemoved = -1;
                            int movedist = -1;
                            Console.Write("Enter the weight of the immobile equipment : ");
                            if (!int.TryParse(Console.ReadLine(), out weight) || weight < 0)
                            {
                                Console.WriteLine("NOTE : Enter valid weight");
                                break;
                            }
                            Console.Write("Enter the distance moved till date(in Km.) : ");
                            if (!int.TryParse(Console.ReadLine(), out distancemoved) || distancemoved < 0)
                            {
                                Console.WriteLine("NOTE : Enter valid distance");
                                break;
                            }
                            Console.Write("Enter the distance to move(in km) : ");
                            if (!int.TryParse(Console.ReadLine(), out movedist) || movedist < 0)
                            {
                                Console.WriteLine("NOTE : Enter valid number");
                                break;
                            }
                            ladder.Weight = weight;
                            ladder.DistanceMovedTillDate = distancemoved;
                            ladder.MoveBy(movedist);
                            ladder.ShowDetails();
                            break;
                        case 3:
                            temp = 0;
                            break;
                        default:
                            Console.WriteLine("Choose the correct option");
                            break;
                    }

                }
               
            }
        }
    }
}
