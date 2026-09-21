## Answers

### 1. Why is a single 20-parameter constructor for this class a problem in practice?

The 20 properties in the constructor cause the **verbose object creation problem**, making the constructor difficult to read and understand. For example, if I ask you what the `true` value I passed to the constructor represents, you wouldn't know.

Also, I might accidentally swap the order of two parameters with the same type. The constructor won't complain because the values have the correct types, but it won't detect that the parameters are in the wrong order.

Another problem is that if I add a new read-only property, I have to update the constructor call at every place where an object of this class is created.

### 2. Is this purely a "constructor is too long" problem, or is there a deeper design issue?

The `Invoice` class violates the **Single Responsibility Principle** because it handles multiple unrelated responsibilities, such as customer information, billing and shipping addresses, order information, and payment information.

Each of these areas can change independently. For example, a change in the payment system, address requirements, or order/pricing logic would require modifying the same `Invoice` class.

Therefore, the class has multiple reasons to change, which indicates an SRP violation.
