using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cars
{
    internal abstract class Car
    {
        public string Registration { get; set; }
        public string Make { get; set; }

        public Car(string reg, string make)
        { 
            this.Make = make;
            this.Registration = reg;
        }
        public abstract double Drive(double km);  
        public abstract double CalculateRange();
    }

    internal class DieselCar : Car
    {

        public DieselCar(string reg, string make) :base(reg,make)
        {

        }
        public override double Drive(double km)
        {
            Console.WriteLine("Driving a diesel");
            return 0;
        }
    

        public override double CalculateRange()
        {

            Console.WriteLine("Range for a diesel");
            return 0;
        }
    }

    internal class ElectricCar : Car
    {

        public ElectricCar(string reg, string make) : base(reg, make)
        {

        }
        public override double Drive(double km)
        {
            Console.WriteLine("Driving an electric");
            return 0;
        }


        public override double CalculateRange()
        {

            Console.WriteLine("Range for an electric ");
            return 0;
        }
    }
}
