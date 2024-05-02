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
        protected double _totalEmissions;

        public string Name {  get { return _name; } }

        public Car(string name, string brand, string colour)
        {
            _name = name;
            _brand = brand;
            _colour = colour;
            _registrationNumber = carCounter++;
            _kmDriven = 0;
            _totalEmissions = 0;
        }

        public virtual double Drive(double km)
        {           
            return 0;
        }
        public override string ToString()
        {
            return $"Reg: {_registrationNumber,-10}\nBrand: {_name,-10} {_brand}\nColour:{_colour}\nKm Driven:{_kmDriven,-10:F2}km\nCO2: {_totalEmissions,10:F2}g";
        }
    }

    internal class DieselCar:Car
    {
        double _fuelTankCapacityL;
        double _kmPerLitre;
        double _co2EmissionsGPerKm;
        double _fuelLevelL;    
        public double FuelTankCapacityL { get { return _fuelTankCapacityL; } }

        public DieselCar(string name, string brand, string colour, double capacity, double kmPerL, double co2GPerKm):base(name,brand,colour)
        {
            _fuelTankCapacityL = capacity;
            _kmPerLitre = kmPerL;
            _co2EmissionsGPerKm = co2GPerKm;
            _fuelLevelL = 0;
        }
/// <summary>
/// Calculates km that can be driven, based on the fuel level in the tank, 
/// if enough fuel,adds km to kmDriven, Co2 is updated and km is returned
/// If not,the km that can be driven are are added to km driven, CO2 is updated and km driven returned.
/// </summary>
/// <param name="km"></param>
/// <returns>km actually driven </returns>
        public override double Drive(double km)
        {
            double weCanDrive = _kmPerLitre * _fuelLevelL;

            if(weCanDrive>=km)
            {
                _kmDriven += km;
                _totalEmissions += km * _co2EmissionsGPerKm;
                return km;
            }
            else
            {
                _kmDriven += weCanDrive;
                _totalEmissions += weCanDrive * _co2EmissionsGPerKm;
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
            return base.ToString() + $"\nFuel Level: {_fuelLevelL}\nFuel Tank Capacity: {_fuelTankCapacityL}\nKm per litre: {_kmPerLitre}\n"; 
        }
    }


}
