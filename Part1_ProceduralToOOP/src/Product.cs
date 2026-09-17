namespace Part1_ProceduralToOOP;

public class Product
{
    private const int MaxProducts = 50;

    public int Id { get; }
    public string Name { get; }
    public double Price { get; }
    public int Stock { get; private set; } 
    
    private static readonly List<Product> Products = new();

    private Product(int id, string name, double price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public static void AddProduct(int id, string name, double price, int stock)
    {
        if (Products.Count >= MaxProducts)
        {
            Console.WriteLine($"ERROR: Product list is full, " +
                              $"Maximum number of products is {MaxProducts}");
            return;
        }

        if (FindProductIndexById(id) != -1)
        {
            Console.WriteLine($"ERROR: product id {id} already exists.");
            return;
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("ERROR: product name is empty.");
            return;
        }

        if (price < 0)
        {
            Console.WriteLine("ERROR: product price cannot be negative.");
            return;
        }

        if (stock < 0)
        {
            Console.WriteLine("ERROR: product stock cannot be negative.");
            return;
        }

        var product = new Product(
            id,
            name,
            price,
            stock);

        Products.Add(product);
    }

    public static void PrintProducts()
    {
        if (Products.Count == 0)
        {
            Console.WriteLine("ERROR: No products found.");
            return;
        }

        Console.WriteLine($"=== PRODUCTS {Products.Count} ===");

        foreach (var product in Products)
        {
            Console.WriteLine(
                $"#{product.Id} - {product.Name} - " +
                $"Price = {product.Price} - Stock = {product.Stock}");
        }
    }
    
    // called in Order to decrease stock for specific product
    // I use this method instead of make Stock property editable outside this class
    public bool TryDecreaseStock(int quantity)
    {
        if (quantity <= 0 || quantity > Stock)
            return false;

        Stock -= quantity;
        return true;
    }
    
    public static int FindProductIndexById(int id)
        => Products.FindIndex(x => x.Id == id);
    
    public static Product? FindProductById(int id)
        => Products.Find(x => x.Id == id);
}