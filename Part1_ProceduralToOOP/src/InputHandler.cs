namespace Part1_ProceduralToOOP;

public class InputHandler
{
    public static void AddCustomer()
    {
        Console.Write("Enter customer ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
        {
            Console.WriteLine("ERROR: invalid customer ID.");
            return;
        }

        Console.Write("Enter customer name: ");
        string name = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter customer email: ");
        string email = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter customer city: ");
        string city = Console.ReadLine() ?? string.Empty;

        Console.Write("Is VIP? (yes/no): ");
        string input = Console.ReadLine() ?? string.Empty;

        bool isVip = input.Equals("yes", StringComparison.OrdinalIgnoreCase);

        Customer.AddCustomer(id, name, email, city, isVip);
    }
    
    public static void CreateOrder()
    {
        Console.WriteLine("=== Create New Order ===");

        Console.Write("Enter order ID: ");
        if (!int.TryParse(Console.ReadLine(), out int orderId) || orderId <= 0)
        {
            Console.WriteLine("ERROR: invalid order ID.");
            return;
        }

        Console.Write("Enter customer ID: ");
        if (!int.TryParse(Console.ReadLine(), out int customerId) || customerId <= 0)
        {
            Console.WriteLine("ERROR: invalid customer ID.");
            return;
        }

        Console.Write("Enter order date (yyyy-MM-dd): ");
        if (!DateTimeOffset.TryParse(Console.ReadLine(), out DateTimeOffset date))
        {
            Console.WriteLine("ERROR: invalid date.");
            return;
        }

        if (date > DateTimeOffset.Now)
        {
            Console.WriteLine("ERROR: order date cannot be in the future.");
            return;
        }

        Order.CreateOrder(orderId, customerId, date);
    }
    
    public static void AddLineToOrder()
    {
        Console.WriteLine("=== Add Order Line ===");

        Console.Write("Enter order ID: ");
        if (!int.TryParse(Console.ReadLine(), out int orderId) || orderId <= 0)
        {
            Console.WriteLine("ERROR: invalid order ID.");
            return;
        }

        Console.Write("Enter product ID: ");
        if (!int.TryParse(Console.ReadLine(), out int productId) || productId <= 0)
        {
            Console.WriteLine("ERROR: invalid product ID.");
            return;
        }

        Console.Write("Enter quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
        {
            Console.WriteLine("ERROR: quantity must be positive.");
            return;
        }

        Order.AddLineToOrder(orderId, productId, quantity);
    }

    public static void PrintOrder()
    {
        Console.Write("Enter order ID: ");
        if (!int.TryParse(Console.ReadLine(), out int orderId) || orderId <= 0)
        {
            Console.WriteLine("ERROR: invalid order ID.");
            return;
        }
        
        Order.PrintOrder(orderId);
    }

    public static void MarkOrderAsPaid()
    {
        Console.Write("Enter order ID: ");
        if (!int.TryParse(Console.ReadLine(), out int orderId) || orderId <= 0)
        {
            Console.WriteLine("ERROR: invalid order ID.");
            return;
        }
        
        Order.MarkOrderAsPaid(orderId);
    }
}