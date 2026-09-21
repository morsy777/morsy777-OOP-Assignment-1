namespace Part3_BuilderPattern;

public class OrderBuilder
{
    public DateTime OrderDate { get; private set; }
    public string PaymentMethod { get; private set; }
    public string Currency { get; private set; }
    public decimal SubTotal { get; private set; }
    public decimal DiscountAmount { get; private set; }
    public decimal TaxAmount { get; private set; }
    public decimal TotalAmount { get; private set; }

    public OrderBuilder SetOrderInfo(
        DateTime orderDate,
        string paymentMethod,
        string currency,
        decimal subTotal,
        decimal discountAmount,
        decimal taxAmount,
        decimal totalAmount)
    {
        OrderDate = orderDate;
        PaymentMethod = paymentMethod;
        Currency = currency;
        SubTotal = subTotal;
        DiscountAmount = discountAmount;
        TaxAmount = taxAmount;
        TotalAmount = totalAmount;

        return this;
    }
}