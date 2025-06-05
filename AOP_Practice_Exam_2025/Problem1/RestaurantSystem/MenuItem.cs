namespace RestaurantSystem;

using System.Globalization;

public class MenuItem
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public MenuItem(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} - {Price.ToString("C", CultureInfo.GetCultureInfo("en-US"))}";
    }
}