namespace Part3_BuilderPattern;

public sealed class InvoiceBuilder
{
    // required
    private readonly int _invoiceId;
    private readonly string _customerName;
    private readonly string _customerEmail;
    private readonly string _customerPhone;

    // optional
    private AddressBuilder _addressBuilder;
    private OrderBuilder _orderBuilder;

    public InvoiceBuilder(
        int invoiceId,
        string customerName,
        string customerEmail,
        string customerPhone)
    {
        _invoiceId = invoiceId;
        _customerName = customerName;
        _customerEmail = customerEmail;
        _customerPhone = customerPhone;
    }

    public InvoiceBuilder SetAddress(AddressBuilder addressBuilder)
    {
        ArgumentNullException.ThrowIfNull(addressBuilder);
        
        _addressBuilder = addressBuilder;
        return this;
    }

    public InvoiceBuilder SetOrder(OrderBuilder orderBuilder)
    {
        ArgumentNullException.ThrowIfNull(orderBuilder);
        
        _orderBuilder = orderBuilder;
        return this;
    }

    public Invoice Build()
    {
        ArgumentNullException.ThrowIfNull(_addressBuilder);
        ArgumentNullException.ThrowIfNull(_orderBuilder);
        
        return new Invoice(
            _invoiceId,
            _customerName,
            _customerEmail,
            _customerPhone,
            _addressBuilder.BillingStreet,
            _addressBuilder.BillingCity,
            _addressBuilder.BillingState,
            _addressBuilder.BillingZipCode,
            _addressBuilder.BillingCountry,
            _addressBuilder.ShippingStreet,
            _addressBuilder.ShippingCity,
            _addressBuilder.ShippingState,
            _addressBuilder.ShippingZipCode,
            _addressBuilder.ShippingCountry,
            _orderBuilder.OrderDate,
            _orderBuilder.PaymentMethod,
            _orderBuilder.Currency,
            _orderBuilder.SubTotal,
            _orderBuilder.DiscountAmount,
            _orderBuilder.TaxAmount,
            _orderBuilder.TotalAmount
        );
    }
    
    
}

