namespace Part3_BuilderPattern;

public class Invoice
{
    // Customer Information
    public int InvoiceId { get; set; } // required
    public string CustomerName { get; set; } // required
    public string CustomerEmail { get; set; } // required
    public string CustomerPhone { get; set; } // required

    // Billing Address
    public string BillingStreet { get; set; }
    public string BillingCity { get; set; }
    public string BillingState { get; set; }
    public string BillingZipCode { get; set; }
    public string BillingCountry { get; set; }

    // Shipping Address
    public string ShippingStreet { get; set; }
    public string ShippingCity { get; set; }
    public string ShippingState { get; set; }
    public string ShippingZipCode { get; set; }
    public string ShippingCountry { get; set; }

    // Order / Payment Information
    public DateTime OrderDate { get; set; }
    public string PaymentMethod { get; set; }
    public string Currency { get; set; }
    public decimal SubTotal { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount { get; set; } // may be required

    public Invoice(
        int invoiceId,
        string customerName,
        string customerEmail,
        string customerPhone,
        string billingStreet,
        string billingCity,
        string billingState,
        string billingZipCode,
        string billingCountry,
        string shippingStreet,
        string shippingCity,
        string shippingState,
        string shippingZipCode,
        string shippingCountry,
        DateTime orderDate,
        string paymentMethod,
        string currency,
        decimal subTotal,
        decimal discountAmount,
        decimal taxAmount,
        decimal totalAmount)
    {
        InvoiceId = invoiceId;
        CustomerName = customerName;
        CustomerEmail = customerEmail;
        CustomerPhone = customerPhone;

        BillingStreet = billingStreet;
        BillingCity = billingCity;
        BillingState = billingState;
        BillingZipCode = billingZipCode;
        BillingCountry = billingCountry;

        ShippingStreet = shippingStreet;
        ShippingCity = shippingCity;
        ShippingState = shippingState;
        ShippingZipCode = shippingZipCode;
        ShippingCountry = shippingCountry;

        OrderDate = orderDate;
        PaymentMethod = paymentMethod;
        Currency = currency;
        SubTotal = subTotal;
        DiscountAmount = discountAmount;
        TaxAmount = taxAmount;
        TotalAmount = totalAmount;
    }
    
    // I override ToString, Just for testing
    public override string ToString()
    {
        return $"""
                Invoice ID: {InvoiceId}
                Customer: {CustomerName}
                Email: {CustomerEmail}
                Phone: {CustomerPhone}

                Billing Address:
                {BillingStreet}, {BillingCity}, {BillingState}, {BillingZipCode}, {BillingCountry}

                Shipping Address:
                {ShippingStreet}, {ShippingCity}, {ShippingState}, {ShippingZipCode}, {ShippingCountry}

                Order Date: {OrderDate:yyyy-MM-dd}
                Payment Method: {PaymentMethod}
                Currency: {Currency}
                SubTotal: {SubTotal}
                Discount: {DiscountAmount}
                Tax: {TaxAmount}
                Total: {TotalAmount}
                """;
    }
}