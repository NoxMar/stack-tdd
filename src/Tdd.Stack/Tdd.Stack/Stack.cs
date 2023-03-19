namespace Tdd.Stack;

public class Stack<T>
{
    public int Size { get; private set; }
    public readonly int Capacity;
    private readonly T[] _backing;
    public Stack(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), capacity,
                "Stack capacity must be non-negative.");
        }
        Capacity = capacity;
        _backing = new T[Capacity];
    }

    public void Push(T item)
    {
        if (Size == Capacity)
        {
            throw new InvalidOperationException("Cannot push to a full stack.");
        }

        _backing[Size] = item;
        Size++;
    }

    public T Peek() 
        => _backing[Size - 1];

    public T Pop()
    {
        Size--;
        return _backing[Size];
    }
}