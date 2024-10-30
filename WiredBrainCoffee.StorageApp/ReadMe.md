Ideas to continue learning: 
- Use `record` type for entities rather than classes
  - Use `StronglyTypedId` library or use custom implementation for `Id` properties on entities

Notes:
- Updated `Employee` and `Organization` to inherit from new `IEntity` class to be used by `GenericRepository`
- Creating `ListRepository<T>` and `SqlRepository<T>` classes to inherit from `IRepository<T>`. This way, `Program.cs` can use the `IRepository` interface in its arguments list to adhere to the Dependency Inversion Principle, which states that components should depend on abstractions rather than implementations. This also aligns with Ardalis's blog post [Interfaces Describe What - Implementations Describe How](https://ardalis.com/interfaces-describe-what-implementations-describe-how/).