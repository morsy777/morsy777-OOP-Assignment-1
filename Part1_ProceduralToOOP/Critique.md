# OOP Design

This section explains how I converted the procedural code into an object-oriented design.

The main goal is to give each class a clear responsibility and keep the object's state protected.

### Customer

The `Customer` class represents a customer and keeps all customer-related data and operations in one place.

- I use a **private constructor** so customers cannot be created directly from outside the class.
- A customer can only be created through `AddCustomer()`, where I can validate the data before creating the object.
- The properties are **read-only** because customer data should not be changed from outside the class.
- The class also keeps a **static collection** of all customers. Since this collection belongs to the class itself, it is shared by all `Customer` objects.
- I use static methods for operations that work with all customers, such as finding or adding a customer.
- Private helper methods are used for logic that is only needed inside the class.

### Order

The `Order` class represents an order and manages its relationship with the customer and its order lines.

- The `Id` property is **read-only** because once an order is created, its ID should not change.
- I use a **private constructor** to protect the object's internal state and control how orders are created.
- An order can only be created through `CreateOrder()`.
- The class keeps a **static collection** of all orders, which belongs to the `Order` class itself.
- An `Order` also has its own `OrderLines` collection because these lines belong to that specific order.
- The `Order` class is responsible for creating `OrderLine` objects because an order line does not make sense without an order.
- Private helper methods are used for internal logic that should not be accessed from outside the class.

### Product

The `Product` class represents a product and is also responsible for managing its stock.

- Products can only be created through `AddProduct()`.
- The constructor is **private** to prevent direct object creation from outside the class.
- The product properties are **read-only** because I do not want outside code to change the product's state directly.
- `Stock` is different because it needs to decrease when a product is added to an `OrderLine`.
- However, I still do not want the `Stock` property to be freely editable from outside the class.
- For this reason, I use `TryDecreaseStock()` to control how the stock changes.

```csharp
// TryDecreaseStock()
// Called from Order to decrease stock for a specific product.
// I use this method instead of making the Stock property editable outside this class.
```

This way, the `Product` class stays responsible for protecting its own stock state.

### Seeder

The `Seeder` class is responsible for adding the initial data when the application starts.

Instead of creating objects directly, the seeder uses the same methods that the application normally uses, such as:

- `Customer.AddCustomer()`
- `Product.AddProduct()`
- `Order.CreateOrder()`
- `Order.AddLineToOrder()`

This is useful because the seeded data follows the same validation and creation rules as data entered by the user.

The main `Seed()` method simply calls the smaller methods:

```text
Seed()
  ├── SeedCustomers()
  ├── SeedProducts()
  └── SeedOrders()
```

### InputHandler

The `InputHandler` class handles everything related to reading input from the user.

For example, when the user wants to create a customer, it reads the ID, name, email, city, and VIP status.

It also checks the **input format**, such as making sure the ID is a valid number.

After that, it passes the data to `Customer.AddCustomer()`.

The important idea here is that `InputHandler` does not contain the customer business rules. It only handles the interaction with the user.

This keeps the responsibilities clear:



Example:

### Customer Creation Flow

For example, when a user creates a customer:

```text
User
  ↓
Menu
  ↓
InputHandler
  ↓
Read Customer Data
  ↓
Validate Input Format
  ↓
Customer.AddCustomer()
  ↓
Check Business Rules
  ↓
new Customer(...)
  ↓
Add to Customers collection
```

The important part is that the `Customer` object is **not created by the ****`Menu`**** or ****`InputHandler`**.

The `Customer` class itself controls its creation. This gives the class control over its own state and makes the code easier to maintain.
