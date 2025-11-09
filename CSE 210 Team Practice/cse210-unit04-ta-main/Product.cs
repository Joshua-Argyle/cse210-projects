public class Product
{
    private int _id;             // e.g., 101
    private string _name;        // e.g., "Laptop"
    private decimal _price;      // e.g., 999.99m
    private int _stockQuantity;  // e.g., 50
    private string _description; // e.g., "High-performance laptop"

    public Product(int id, string name, decimal price, int stockQuantity, string description)
    {
        _id = id;
        _name = name;
        _price = price;
        _stockQuantity = stockQuantity;
        _description = description;
    }

    public virtual string GetInfo()
    {
        return $"Product ID: {_id}\n" +
               $"Name: {_name}\n" +
               $"Price: {_price:C}\n" +
               $"Stock Quantity: {_stockQuantity}\n" +
               $"Description: {_description}\n";
    }



}