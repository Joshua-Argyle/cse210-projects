namespace cse210_unit05_ta;

class Program
{
    static void Main(string[] args)
    {
        Vehicle car = new Car("Ford");

        // TODO: Instantiate a Boat, an Airplane, and a Motorcycle

        Vehicle boat = new Boat("The Black Pearl");

        Vehicle airplane = new Airplane("The Millenium Falcon");
        
        Vehicle motorcycle = new Motorcycle("Batcycle");

        List<Vehicle> vehicles = new List<Vehicle>();
        vehicles.Add(boat);
        vehicles.Add(motorcycle);
        vehicles.Add(airplane);
        vehicles.Add(car);

        foreach (Vehicle vehicle in vehicles)
        {
            vehicle.Drive();
        }
    }
}
