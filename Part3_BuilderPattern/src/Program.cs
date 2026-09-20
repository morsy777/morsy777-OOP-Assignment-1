using Part3_BuilderPattern;

var address = new AddressBuilder();

address.SetShippingAddress(
    "12 Tahrir Street",
    "Mansoura",
    "Dakahlia",
    "35511",
    "Egypt");

address.SetBillingAddress(
    "25 El-Gomhoria Street",
    "Mansoura",
    "Dakahlia",
    "35512",
    "Egypt");


var order = new OrderBuilder();

order.SetOrderInfo(
    new DateTime(2026, 9, 21),
    "Credit Card",
    "EGP",
    5000m,
    500m,
    675m,
    5175m);


var invoice = new InvoiceBuilder(
        1,
        "Morsi",
        "morsi@gmail.com",
        "01065622044")
    .SetAddress(address)
    .SetOrder(order)
    .Build();

Console.WriteLine(invoice);