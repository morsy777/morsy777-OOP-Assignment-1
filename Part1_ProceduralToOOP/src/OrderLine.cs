namespace Part1_ProceduralToOOP;

public class OrderLine
{
    public const int  MAX_LINES_PER_ORDER = 20;
    
    /*public int OrdrerId { get; set; }
    public int ProductId { get; set; }*/

    public Product Product { get; set; } 
    public Order Order { get; set; } 
    public int Quantity { get; set; }

    public OrderLine(Order order, Product product, int quantity)
    {
        Order = order;
        Product = product;
        Quantity = quantity;
    }
}

