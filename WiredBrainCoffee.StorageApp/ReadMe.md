Ideas to continue learning: 
- Use `record` type for entities rather than classes
  - Use `StronglyTypedId` library or use custom implementation for `Id` properties on entities
    - Also on `IEntity`'s `Id` property
- Low priority: what's the difference between initializing the `EmployeeAdded` method inside the delegate constructor and simply passing `EmployeeAdded` as the `SqlRepository` constructor argument?

Notes:
- Updated `Employee` and `Organization` to inherit from new `IEntity` class to be used by `GenericRepository`.

Further reading: 
- Why use constraints: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
- Struct inheritance: https://stackoverflow.com/a/15408711

