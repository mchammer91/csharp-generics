﻿- When creating child repository classes that inherit from parent `GenericRepository` class, must make `_items` field `protected` rather than `private` so that the inheriting child classes have access to it.
  - `protected`: access is limited to the containing class or types derived from the containing class.
  - `private`: access  is limited to the containing type.
  - `private protected`: access is limited to the containing class or types derived from the containing class within the current assembly.