namespace Part1_ProceduralToOOP;

public static class Seeder
{
    public static void Seed()
    {
        Console.WriteLine("seeding...");
        SeedCustomers();
        SeedProducts();
        SeedOrders();
    }

    private static void SeedCustomers()
    {
        Customer.AddCustomer(
            1,
            "Mohamed Morsi",
            "Morsi@gmail.com",
            "Mansoura",
            true);

        Customer.AddCustomer(
            2,
            "Ahmed Adel",
            "Adel@gmail.com",
            "Alexandria",
            false);

        Customer.AddCustomer(
            3,
            "Sara Nabil",
            "sara@gmail.com",
            "Giza",
            false);
    }

    private static void SeedProducts()
    {
        Product.AddProduct(10, "Laptop", 25000.00, 5);
        Product.AddProduct(20, "Mouse", 500.00, 10);
        Product.AddProduct(30, "Keyboard", 1000.00, 3);
        Product.AddProduct(40, "USB Cable", 50.00, 100);
    }

    private static void SeedOrders()
    {
        // Customer #1 - VIP
        Order.CreateOrder(1001, 1, DateTimeOffset.Now);

        Order.AddLineToOrder(1001, 10, 2);
        Order.AddLineToOrder(1001, 20, 1);

        // Customer #2
        Order.CreateOrder(1002, 2, DateTimeOffset.Now);

        Order.AddLineToOrder(1002, 20, 2);
        Order.AddLineToOrder(1002, 30, 1);

        // Customer #3
        Order.CreateOrder(1003, 3, DateTimeOffset.Now);

        Order.AddLineToOrder(1003, 30, 1);
        Order.AddLineToOrder(1003, 40, 5);
    }
}