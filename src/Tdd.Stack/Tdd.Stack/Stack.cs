namespace Tdd.Stack;

public class Stack<T>
{
    public int Size => 0;
    public readonly int Capacity;
    public Stack(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), capacity,
                "Stack capacity must be non-negative.");
        }
        Capacity = capacity;
    }

    public void Push(T item)
    {
        throw new NotImplementedException();
    }

    public T Peek()
    {
        throw new NotImplementedException();
    }

    public T Pop()
    {
        throw new NotImplementedException();
    }
}