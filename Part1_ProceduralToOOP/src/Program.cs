using Part1_ProceduralToOOP;

// =========================
// Test Customers
// =========================

Customer.AddCustomer(1, "Mohamed", "mohamed@gmail.com", "Mansoura", true);
Customer.AddCustomer(2, "Ahmed", "ahmed@gmail.com", "Alexandria", false);

Customer.PrintCustomers();


// =========================
// Test Products
// =========================

Product.AddProduct(10, "Laptop", 25000, 5);
Product.AddProduct(20, "Mouse", 500, 10);
Product.AddProduct(30, "Keyboard", 1000, 3);

Product.PrintProducts();


// =========================
// Test Order
// =========================

Order.CreateOrder(
    1001,
    1,
    DateTimeOffset.Now
);


// =========================
// Test Order Lines
// =========================

Order.AddLineToOrder(1001, 10, 2);
Order.AddLineToOrder(1001, 20, 1);


// =========================
// Print Order
// =========================

Order.PrintOrder(1001);


// =========================
// Print Products Again
// =========================
// To verify that stock decreased

Product.PrintProducts();