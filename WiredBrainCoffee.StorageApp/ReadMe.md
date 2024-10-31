Ideas to continue learning: 
- Use `record` type for entities rather than classes
  - Use `StronglyTypedId` library or use custom implementation for `Id` properties on entities
    - Also on `IEntity`'s `Id` property

Notes:
- Updated `Employee` and `Organization` to inherit from new `IEntity` class to be used by `GenericRepository`.