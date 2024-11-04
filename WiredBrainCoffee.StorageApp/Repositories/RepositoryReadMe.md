- When creating child repository classes that inherit from parent `GenericRepository` class, must make `_items` field `protected` rather than `private` so that the inheriting child classes have access to it.
  - `protected`: access is limited to the containing class or types derived from the containing class.
  - `private`: access  is limited to the containing type.
  - `private protected`: access is limited to the containing class or types derived from the containing class within the current assembly.

Using `IEntity` as generic type constraint. This then allows for better type-safety and provides compiler help for available properties and methods on the generic type (in this case, specifically for `GetById` method).
Because both value types (non-nullable) and reference types (nullable) can implement interfaces, simply having `IEntity` as the type constraint only provides so much value compared to the previous value of `EntityBase`. In order to fully reach parity of the previous constraint value, we need to add the `class` constraint. This tells the compiler that `T` must also be a reference type, and therefore is nullable (but not really, since we have the nullable reference type feature turned on). By updating the `class` constraint to `class?` and `IEntity` to `IEntity?`, we're then explicitly allowing `T` to be nullable. As an alternative to the `class` constraint, there is also the `struct` type constraint, which tells the compiler that `T` must be a value type.
Reference: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters

The `new()` constraint allows you to create instances of the generic type using its parameterless constructor. Note that if an inheriting type of the type constraint(s) only have constructors with parameters, then the type will no longer have a parameterless constructor and therefore this will break.  

Creating `ListRepository<T>` and `SqlRepository<T>` classes to inherit from `IRepository<T>`. This way, `Program.cs` can use the `IRepository` interface in its arguments list to adhere to the Dependency Inversion Principle, which states that components should depend on abstractions rather than implementations. This also aligns with Ardalis's blog post [Interfaces Describe What - Implementations Describe How](https://ardalis.com/interfaces-describe-what-implementations-describe-how/).

Generic type parameters of interfaces are invariant by default, meaning the interface requires the exact type specified. This means that a more- or less-derived type argument can't be used. You can make the generic type parameter covariant (allowing a less-derived type parameter) by using the `out` keyword like so: `IInterface<out T>`. This will allow all properties and methods which return `T` to be covariant. However, this will break any properties or methods which use `T` as an argument, because they _must_ be invariant or contravariant, meaning they CAN'T use a less derived type than the one specified. In order to get around this, you can create a separate interface specifically for retrieving values that can use the covariant generic type parameter.

Example: `IEnumerable<T>` uses a covariant type parameter: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1#definition

Covariance: allowing less or equally specific type to be used than actual implementation.
Contravariance: requiring more or equally specific type to be used than actual implementation.

The opposite of covariance is contravariance. This means that a type parameter can be more specific than the type specified. You can make the generic type parameter contravariant (allowing a more-derived type parameter) by using the `in` keyword like so: `IInterface<in T>`. This will allow all properties and methods which use `T` to be contravariant. 

Methods that read from the repository can accept a less specific type (covariance). Methods that write to the repository require the specific type (contravariance).

In order to combine the concepts of covariant return types with contravariant method arguments, you need to create a parent interface for each concept which are then inherited by a child interface to join the two.