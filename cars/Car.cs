using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace cars
{
    internal class Car
    {
        static int carCounter = 0;
        string _name;
        string _brand;
        string _colour;
        int _registrationNumber;

        protected double _kmDriven;
        protected double _co2;
public string Name {  get { return _name; } }

public Car(string name, string brand, string colour)
        {
            _name = name;
            _brand = brand;
            _colour = colour;
            _registrationNumber = carCounter++;
            _kmDriven = 0;
            _co2 = 0;
        }

        public virtual double Drive(double km)
        {
            _kmDriven += km;
            
            return _kmDriven;
        }
        public override string ToString()
        {
            return $"{_registrationNumber,-10}{_name,-10} {_brand} {_colour} {_kmDriven,-10:F2} {_co2,10:F2}";
        }
    }

    internal class DieselCar:Car
    {
        double _fuelTankCapacityL;
        double _kmPerLitre;
        double _co2EmissionsPerKm;
        double _fuelLevelL;
       
        public double FuelTankCapacityL { get { return _fuelTankCapacityL; } }

        public DieselCar(string name, string brand, string colour, double capacity, double kmPerL, double co2PerL):base(name,brand,colour)
        {
            _fuelTankCapacityL = capacity;
            _kmPerLitre = kmPerL;
            _co2EmissionsPerKm = co2PerL;
            _fuelLevelL = 0;
        }

        public override double Drive(double km)
        {
            double weCanDrive = _kmPerLitre * _fuelLevelL;
            if(weCanDrive>=km)
            {
                _kmDriven += km;
                return km;
            }
            else
            {
                _kmDriven += weCanDrive;
                return weCanDrive;
            }

        }

        /// <summary>
        /// adds fuel if capacity there.
        /// </summary>
        /// <param name="dieselL"> diesel to add </param>
        /// <returns>returns the fuel level of the tank </returns>
        public double ReFuel(double dieselL)
        {
            double spaceInTank = _fuelTankCapacityL - _fuelLevelL;

            if(dieselL<=spaceInTank)
            {
                _fuelLevelL += dieselL;
                
            }
            else
            {
                _fuelLevelL = _fuelTankCapacityL;

            }
            return _fuelLevelL;
        }

        public override string ToString()
        {
            return base.ToString() + $"{_fuelTankCapacityL}"; 
        }
    }


}
