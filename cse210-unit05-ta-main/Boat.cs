public class Boat : Vehicle
{
    public Boat(string name) : base(name) { }

    public override void Drive()
    {
        Console.WriteLine($"{_name} sails far across the sea!");
    }
}