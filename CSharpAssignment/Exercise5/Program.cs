using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    enum DuckType
    {
        Rubber,
        Mallard,
        Redhead
    }
    public interface IDuckGame
    {
        void ShowDetails();                                           //By default,abstract method(no implemntation,defination has to to be defined in child class)
    }

    class Duck : IDuckGame
    {
        private double weights;
        private int noOfWings;
        private DuckType ducktype;
        public Duck() { }
        public Duck(double weights, int noOfWings, DuckType ducktype)
        {
            this.weights = weights;
            this.noOfWings = noOfWings;
            this.ducktype = ducktype;
        }
        public virtual void ShowDetails()                                    //virtual keyword specifies that the method with same signature has to be overriden in the derived class.
        {
            if (ducktype == DuckType.Rubber)
            {
                Console.WriteLine("Rubber Duck : ");
            }
            if (ducktype == DuckType.Mallard)
            {
                Console.WriteLine("Mallard Duck : ");
            }
            if (ducktype == DuckType.Redhead)
            {
                Console.WriteLine("Redhead Duck : ");
            }
            Console.WriteLine("Weight : {0}", weights);
            Console.WriteLine("Number of Wings : {0}", noOfWings);
        }
    }
    class RubberDuck : Duck
    {
        public RubberDuck(double weights, int noOfWings, DuckType ducktype) : base(weights, noOfWings, ducktype) { }
       
        public override void ShowDetails()                                                         //This method overrides method of parent class Duck.
        {
            base.ShowDetails();
            Console.WriteLine("Rubber ducks don’t fly and squeak.");
        }
    }

    class MallardDuck : Duck
    {
        public MallardDuck(double weights, int noOfWings, DuckType ducktype) : base(weights, noOfWings, ducktype) { }
     
        public override void ShowDetails()                                                           //This method overrides method of parent class Duck.
        {
            base.ShowDetails();
            Console.WriteLine("Mallard ducks fly fast and quack loud.");
        }
    }

    class RedheadDuck : Duck { 
        public RedheadDuck(double weights, int noOfWings, DuckType ducktype) : base(weights, noOfWings, ducktype) { }
        public override void ShowDetails()
        {
            base.ShowDetails();                                                    //This method overrides method of parent class Duck.
            Console.WriteLine("Redhead ducks fly slow and quack mild.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Duck[] ducks = new Duck[3];
            ducks[0] = new RubberDuck(10, 2, DuckType.Rubber);
            ducks[1] = new MallardDuck(20, 4, DuckType.Mallard);
            ducks[2] = new RedheadDuck(14, 2, DuckType.Redhead);

            for(int i = 0; i < 3; i++)
            {
                ducks[i].ShowDetails();
                Console.WriteLine();
            }


        }
    }
}



