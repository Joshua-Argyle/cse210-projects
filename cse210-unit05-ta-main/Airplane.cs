public class Airplane : Vehicle
{
    public Airplane(string name) : base(name) { }
 
    public override void Drive()
    {
        Console.WriteLine($"{_name} Flies high into the sky!");
    }
}