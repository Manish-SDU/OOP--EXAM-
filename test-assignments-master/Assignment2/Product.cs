namespace Assignment2;

public class Product
{
    private string itemName;
    private int quantity;
    private bool shipped;

    public Product(string itemName, int quantity, bool shipped)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.shipped = shipped;
    }

    public string ItemName => itemName;
    public int Quantity => quantity;
    public bool Shipped => shipped;

    public override string ToString()
    {
        return $"itemName={ItemName}, quantity={Quantity},shipped={Shipped}";
    }

    static void Main(string[] args)
    {
        var list = new List<Product>
        {
            new Product("Computer mouse", 1, false),
            new Product("Bike", 0, true),
            new Product("Table", 0, true)
        };

        Console.WriteLine("{" + string.Join("\n, ", list) + "}");

        Helpers.WriteToFile(list);
        Console.WriteLine("\nFrom File:");
        Helpers.ReadFromFile("Products.txt");
        Console.WriteLine("\nOnly shipped:");
        Helpers.CheckHasBeenShipped("Products.txt");
    }
}