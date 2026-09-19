namespace Part1_ProceduralToOOP;

public static class Menu
{
    public static void PrintMenu()
    {
        Console.WriteLine("\n---------- MENU ----------");
        Console.WriteLine("1) Print customers");
        Console.WriteLine("2) Print products");
        Console.WriteLine("3) Print all orders");
        Console.WriteLine("4) Print one order by id");
        Console.WriteLine("5) Create order");
        Console.WriteLine("6) Add line to order");
        Console.WriteLine("7) Mark order paid");
        Console.WriteLine("8) Show paid sales total");
        Console.WriteLine("0) Exit");
        Console.Write("Choice: ");
    }

    public static void RunInteractiveMenu()
    {
        int choice = -1;

        while (choice != 0)
        {
            PrintMenu();

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("ERROR: invalid choice.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Customer.PrintCustomers();
                    break;

                case 2:
                    Product.PrintProducts();
                    break;

                case 3:
                    Order.PrintOrders();
                    break;

                case 4:
                    InputHandler.PrintOrder();
                    break;

                case 5:
                    InputHandler.CreateOrder();
                    break;

                case 6:
                    InputHandler.AddLineToOrder();
                    break;

                case 7:
                    InputHandler.MarkOrderAsPaid();
                    break;

                case 8:
                    Order.TotalSalesPaidOnly();
                    break;

                case 0:
                    Console.WriteLine("Bye.");
                    break;

                default:
                    Console.WriteLine("Unknown choice.");
                    break;
            }
        }
    }
}