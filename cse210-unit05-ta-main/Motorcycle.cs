public class Motorcycle : Vehicle
{
    public Motorcycle(string name) : base(name){ }

    public override void Drive()
    {
        Console.WriteLine($"{_name} did a sick trick!");
    }
}