namespace Part1_ProceduralToOOP;

public class Customer
{
    private const int MaxCustomers  = 50;
    
    public int Id { get; }
    public string Name { get; }
    public string Email { get; }
    public string City { get; }
    public bool IsVip { get; }
    
    private static readonly List<Customer> Customers = new();
    public List<Order> Orders { get; private set; } = new();
    
    private Customer(int id, string name, string email, string city, bool isVip)
    {
        Id = id;
        Name = name;
        Email = email;
        City = city;
        IsVip = isVip;
    }
    
    public static void AddCustomer(int id, string name, string email, string city, bool isVip)
    {
        if (Customers.Count >= MaxCustomers)
        {
            Console.WriteLine($"ERROR: Customer list is full, " +
                              $"Maximum number of customers is {MaxCustomers}");
            return;
        }
        
        if (FindCustomerIndexById(id) != -1)
        {
            Console.WriteLine($"ERROR: customer id {id} already exists.");
            return;
        }

        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(city))
        {
            Console.WriteLine($"ERROR: customer name, city or email is empty.");
            return;
        }
        
        var customer = new Customer(
            id,
            name,
            email,
            city,
            isVip);
        
        // I Added it after validation
        Customers.Add(customer);
    }
    
    public static void PrintCustomers()
    {
        if(Customers.Count == 0)
        {
            Console.WriteLine($"ERROR: No customers found.");
            return;
        }

        Console.WriteLine($"=== CUSTOMERS {Customers.Count} ===");
        foreach (var customer in Customers)
        {
            
            Console.WriteLine($"#{customer.Id} - {customer.Name} - <{customer.Email}> " +
                              $"- {customer.City} - Is Vip = {(customer.IsVip ? "yes" : "no")}");
        }
    }
    
    public static Customer? FindCustomerById(int id)
     => Customers.Find(x => x.Id == id);
    
    private static int FindCustomerIndexById(int id)
        => Customers.FindIndex(x => x.Id == id);
}