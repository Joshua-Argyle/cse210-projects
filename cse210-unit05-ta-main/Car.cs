public class Car : Vehicle
{
    public Car(string name) : base(name) { }

    public override void Drive()
    {
        Console.WriteLine($"{_name} drives smoothly on the road!");
    }
}