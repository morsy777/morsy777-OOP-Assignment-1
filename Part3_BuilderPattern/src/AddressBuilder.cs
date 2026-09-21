namespace Part3_BuilderPattern;

public class AddressBuilder
{
    public string BillingStreet { get; private set; }
    public string BillingCity { get; private set; }
    public string BillingState { get; private set; }
    public string BillingZipCode { get; private set; }
    public string BillingCountry { get; private set; }

    public string ShippingStreet { get; private set; }
    public string ShippingCity { get; private set; }
    public string ShippingState { get; private set; }
    public string ShippingZipCode { get; private set; }
    public string ShippingCountry { get; private set; }

    public AddressBuilder SetBillingAddress(
        string billingStreet,
        string billingCity,
        string billingState,
        string billingZipCode,
        string billingCountry)
    {
        BillingStreet = billingStreet;
        BillingCity = billingCity;
        BillingState = billingState;
        BillingZipCode = billingZipCode;
        BillingCountry = billingCountry;

        return this;
    }

    public AddressBuilder SetShippingAddress(
        string shippingStreet,
        string shippingCity,
        string shippingState,
        string shippingZipCode,
        string shippingCountry)
    {
        ShippingStreet = shippingStreet;
        ShippingCity = shippingCity;
        ShippingState = shippingState;
        ShippingZipCode = shippingZipCode;
        ShippingCountry = shippingCountry;

        return this;
    }
}