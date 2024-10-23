// using SimpleStack implementation
var stack = new SimpleStack<double>();

stack.Push(1.2);
stack.Push(2.3);
stack.Push(3.4);

var sum = 0d;

while (stack.Count > 0)
{
    var item = stack.Pop();
    System.Console.WriteLine($"Item: ${item}");
    sum += item;
}

System.Console.WriteLine($"Sum: ${sum}");
System.Console.ReadLine();

// using built-in dotnet generic collection implementation
var builtInStack = new Stack<double>();
