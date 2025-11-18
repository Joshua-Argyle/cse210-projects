public abstract class Vehicle
{
    protected string _name;

    public Vehicle(string name)
    {
        _name = name;
    }
    
    public abstract void Drive();
}