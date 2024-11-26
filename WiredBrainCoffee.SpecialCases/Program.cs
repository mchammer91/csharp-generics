// See https://aka.ms/new-console-template for more information

_ = new Container<string>();
_ = new Container<string>();
_ = new Container<int>();

/*
 * The static InstanceCount property only tracks the total number of invocations
 * for each generic type parameter used.
 */
Console.WriteLine($"Container<string>: {Container<string>.InstanceCount}"); // 2
Console.WriteLine($"Container<int>: {Container<int>.InstanceCount}"); // 1
Console.WriteLine($"Container<bool>: {Container<bool>.InstanceCount}"); // 0

// Could also do this, but compiler wants us to simplify the expression to use the base class
// Console.WriteLine($"ContainerBase: {Container<string>.InstanceCountBase}"); // 3
Console.WriteLine($"ContainerBase: {ContainerBase.InstanceCountBase}"); // 3

class Container<T> : ContainerBase
{
    public Container() => InstanceCount++;
    public static int InstanceCount { get; private set; }
}

/*
 * In order to get the total number of invocations of the static property
 * we must use a non-generic base class.
 */
class ContainerBase
{
    public ContainerBase() => InstanceCountBase++;
    
    public static int InstanceCountBase { get; private set; }
}