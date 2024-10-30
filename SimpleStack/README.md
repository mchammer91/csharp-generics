Follow-along source: https://app.pluralsight.com/ilx/video-courses/6416edc0-4aca-45dd-8bb3-b8c21f6ca5b1/23eebf32-f62e-4d07-ac3d-ab27d767606d/3dd25f43-f2aa-48c8-a491-cdf5d0048411

MSFT generic stack reference: https://github.com/dotnet/runtime/blob/5535e31a712343a63f5d7d796cd874e563e5ac14/src/libraries/System.Collections/src/System/Collections/Generic/Stack.cs

## Understanding the Need for Generics
### Use Object to Support Any Type
This is inefficient because of boxing and unboxing value types actually contained in the collection, and you also lose static type safety. 

### Copy and Paste for Victory
Having specific implementations of the stack class mitigates the issues associated with boxing and unboxing, but then introduces the issue of needlessly redundant code from implementations of the class on different types.