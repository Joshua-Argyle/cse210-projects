public class Food : Product
{
    private string _expirationDate;

    private int _calories;

    public Food (int id, string name, decimal price, int stockQuantity, string description, string expirationDate, int calories) : base(id, name, price, stockQuantity, description)
    {
        _expirationDate = expirationDate;
        _calories = calories;
    }
    public override string GetInfo()
    {
        return base.GetInfo() +  // Call base method to get common info
               $"Expiration Date: {_expirationDate}\n" +
               $"Calories: {_calories}";
    }
}