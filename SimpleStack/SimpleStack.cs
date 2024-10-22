public class SimpleStack<T>
{
    private readonly T[] _items = new T[10];
    private int _currentIndex = -1;
    public int Count => _currentIndex + 1;

    // Prefix operator to increment before assigning to _currentIndex and then assigning the value to the array
    public void Push(T v) => _items[++_currentIndex] = v;

    // Postfix operator to assign the value to the array and then decrement _currentIndex
    public T Pop() => _items[_currentIndex--];
}