namespace cars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            DieselCar d = new DieselCar("131DL4444", "BMW");

            ElectricCar e = new ElectricCar("121SO3333", "Nissan");

            cars.Add(d);
            cars.Add(e);
            foreach (Car car in cars) 
            {
                car.Drive(100);
                car.CalculateRange();         
            }
        }
    }
}