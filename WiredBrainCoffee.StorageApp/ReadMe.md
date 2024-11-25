Ideas to continue learning: 
- Use `record` type for entities rather than classes
  - Use `StronglyTypedId` library or use custom implementation for `Id` properties on entities
    - Also on `IEntity`'s `Id` property
- Low priority: what's the difference between initializing the `EmployeeAdded` method inside the delegate constructor and simply passing `EmployeeAdded` as the `SqlRepository` constructor argument? Doesn't seem to be any difference when running either way... Answer: no difference - the compiler is smart enough to match the `EmployeeAdded` method definition to the `ItemAdded` delegate's definition and accept it in place.

Notes:
- Updated `Employee` and `Organization` to inherit from new `IEntity` class to be used by `GenericRepository`.

Further reading: 
- Why use constraints: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
- Struct inheritance: https://stackoverflow.com/a/15408711
- Variance in delegates: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/covariance-contravariance/using-variance-in-delegates
  - Action delegate: https://learn.microsoft.com/en-us/dotnet/api/system.action-1 note the contravariant input type parameter.
  - Func delegate: https://learn.microsoft.com/en-us/dotnet/api/system.func-2 note the covariant return type parameter and the contravariant input type parameter. 