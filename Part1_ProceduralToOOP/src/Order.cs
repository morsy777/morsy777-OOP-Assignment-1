namespace Part1_ProceduralToOOP;

// I use private set because we will toggle IsPaid 
public class Order
{
    private const int MaxOrders = 100;
    
    public int Id { get; }
    public DateTimeOffset Date { get; private set; }
    public bool IsPaid { get; private set; }
    
    public Customer Customer { get; private set; }
    public List<OrderLine> OrderLines { get; } = new();
    private static readonly List<Order> Orders = new();

    private Order(int id, Customer customer, DateTimeOffset date)
    {
        Id = id;
        Customer = customer;
        Date = date;
        IsPaid = false;
    }

    public static void CreateOrder(int orderId, int customerId, DateTimeOffset date)
    {
        if (Orders.Count >= MaxOrders)
        {
            Console.WriteLine("ERROR: order list is full.");
            return;
        }

        if (FindOrderIndexById(orderId) != -1)
        {
            Console.WriteLine($"ERROR: order id {orderId} already exists.");
            return;
        }
        
        // Not GPT, I was learned this pattern from Eng. Mohamed ElHellaly
        if (Customer.FindCustomerById(customerId) is not { } customer)
        {
            Console.WriteLine($"ERROR: customer  {customerId} not found.");
            return;
        }
        
        //TODO: validate date here
        
        var order = new Order(orderId, customer, date);
        customer.Orders.Add(order); 
        Orders.Add(order);

        Console.WriteLine($"Order created successfully.");
    }
    
    public static void AddLineToOrder(int orderId, int productId, int quantity)
    {
        if (quantity <= 0)
        {
            Console.WriteLine("ERROR: quantity must be positive.");
            return;
        }
        
        if (FindOrderById(orderId) is not { } order)
        {
            Console.WriteLine($"ERROR: order {orderId} not found.");
            return;
        }
        
        if (order.IsPaid)
        {
            Console.WriteLine("ERROR: order is paid, so we can't change it.");
            return;
        }
        
        if (order.OrderLines.Count >= OrderLine.MAX_LINES_PER_ORDER)
        {
            Console.WriteLine($"ERROR: order limit {OrderLine.MAX_LINES_PER_ORDER}.");
            return;
        }

        if (Product.FindProductById(productId) is not { } product)
        {
            Console.WriteLine($"ERROR: product  {productId} not found.");
            return;
        }

        if (!product.TryDecreaseStock(quantity))
        {
            Console.WriteLine($"ERROR: not enough stock for product # {productId}.");
            return;
        }
        
        //product.Stock -= quantity;
        
        var line = new OrderLine(order, product, quantity);
        order.OrderLines.Add(line);

        Console.WriteLine("Order line added.");
    }
    
    public static void PrintOrder(int orderId)
    {
        if (FindOrderById(orderId) is not { } order)
        {
            Console.WriteLine($"ERROR: order {orderId} not found.");
            return;
        }

        Console.WriteLine($"=== ORDER #{order.Id} ===");
        Console.WriteLine($"Date: {order.Date}");
        Console.WriteLine($"Customer: {order.Customer.Name} (#{order.Customer.Id})");
        Console.WriteLine($"Paid: {(order.IsPaid ? "yes" : "no")}");
        Console.WriteLine("Lines:");

        Console.WriteLine($"{"Product",-20} {"Price",10} {"Quantity",10} {"Total",10}");

        foreach (var line in order.OrderLines)
        {
            double total = line.Product.Price * line.Quantity;

            Console.WriteLine(
                $"{line.Product.Name,-20} " +
                $"{line.Product.Price,10:F2} " +
                $"{line.Quantity,10} " +
                $"{total,10:F2}");
        }
    }
    
    
    public static int FindOrderIndexById(int orderId)
        => Orders.FindIndex(order => order.Id == orderId);
    
    public static Order? FindOrderById(int orderId)
        => Orders.Find(order => order.Id == orderId);
}