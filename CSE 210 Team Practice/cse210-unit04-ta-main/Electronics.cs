public class Electronics : Product
{
    private string _brand;          // e.g., "Dell"
    private string _model;          // e.g., "XPS 13"
    private string _warrantyPeriod; // e.g., "24 months"

    public Electronics(int id, string name, decimal price, int stockQuantity, string description,
                      string brand, string model, string warrantyPeriod)
        : base(id, name, price, stockQuantity, description)
    {
        _brand = brand;
        _model = model;
        _warrantyPeriod = warrantyPeriod;
    }

    public override string GetInfo()
    {
        return base.GetInfo() +  // Call base method to get common info
               $"Brand: {_brand}\n" +
               $"Model: {_model}\n" +
               $"Warranty Period: {_warrantyPeriod}\n";
    }
}