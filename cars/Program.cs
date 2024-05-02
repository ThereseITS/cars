//
//Car example from class illustrating inheritance.
//
namespace cars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Octavia", "Skoda", "red");
            Console.WriteLine(car.ToString());

            car.Drive(10);

            Console.WriteLine(car.ToString());

            DieselCar d = new DieselCar("Bavarian", "BMW", "black", 70, 40,99);

            Console.WriteLine(d.ToString());
            d.ReFuel(20);

            Console.WriteLine (d.Drive(100).ToString());

            Console.WriteLine(d.ToString());
        }
    }
}
