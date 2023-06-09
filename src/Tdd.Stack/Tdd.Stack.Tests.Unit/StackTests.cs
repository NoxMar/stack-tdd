namespace Tdd.Stack.Tests.Unit;

public class StackTests
{
    [Fact]
    public void Size_NoOperations_Zero()
    {
        // Arrange
        Stack<int> sut = new(10);
        
        // Act
        var size = sut.Size;
        
        // Assert
        Assert.Equal(0, size);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    public void Ctor_NonpositiveCapacity_ArgumentOutOfRangeException(int capacity)
    {
        // Arrange
        
        // Act
        var e = Record.Exception(() => new Stack<int>(capacity));
        
        // Assert
        Assert.IsType<ArgumentOutOfRangeException>(e);
    }

    [Fact]
    public void Capacity_NoOperations_ValuePassedToConstructor()
    {
        // Arrange
        Stack<int> sut = new(10);
        
        // Act
        var maxSize = sut.Capacity;
        
        // Assert
        Assert.Equal(10, maxSize);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    [InlineData(9)]
    public void Push_NotFul_IncreaseSize(int initialSize)
    {
        // Arrange
        var expected = initialSize + 1;
        Stack<int> sut = new(10);
        for (var i = 0; i < initialSize; i++)
        {
            sut.Push(i);
        }
        
        // Act
        sut.Push(999);
        
        // Assert
        Assert.Equal(expected, sut.Size);
    }

    [Fact]
    public void Push_NotFulComplexOrder_IncreaseSize()
    {
        // Arrange
        var sut = MoreComplexStack();
        
        // Act
        sut.Push(999);
        
        // Assert
        Assert.Equal(3, sut.Size);
    }

    [Fact]
    public void Push_Full_InvalidOperationException()
    {
        // Arrange
        const int CAPACITY = 10;
        Stack<int> sut = new(CAPACITY);
        for (var i = 0; i < CAPACITY; i++)
        {
            sut.Push(i);
        }
        
        // Act
        var e = Record.Exception(() => sut.Push(999));
        
        // Assert
        var ex = Assert.IsType<InvalidOperationException>(e);
        Assert.Contains("full", ex.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    [InlineData(9)]
    public void Push_NotFull_ChangePeek(int initialSize)
    {
        // Arrange
        Stack<int> sut = new(10);
        for (int i = 0; i < initialSize; i++)
        {
            sut.Push(i);
        }
        
        // Act
        sut.Push(999);
        
        // Assert
        Assert.Equal(999, sut.Peek());
    }
    
    [Fact]
    public void Push_NotFulComplexOrder_ChangePeek()
    {
        // Arrange
        var sut = MoreComplexStack();
        
        // Act
        sut.Push(999);
        
        // Assert
        Assert.Equal(999, sut.Peek());
    }

    [Fact]
    public void Peek_EmptyStack_InvalidOperationException()
    {
        // Arrange
        Stack<int> sut = new(10);
        
        // Act
        var e = Record.Exception(() => sut.Peek());
        
        // Assert 
        var ex = Assert.IsType<InvalidOperationException>(e);
        Assert.Contains("empty", ex.Message);
    }

    [Fact]
    public void Pop_EmptyStack_InvalidOperationException()
    {
        // Arrange
        Stack<int> sut = new(10);
        
        // Act
        var e = Record.Exception(() => sut.Pop());
        
        // Assert
        var ex = Assert.IsType<InvalidOperationException>(e);
        Assert.Contains("empty", ex.Message);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void Pop_NonemptyStack_DecreaseSizeByOne(int initialSize)
    {
        // Arrange
        var expectedSize = initialSize - 1;
        Stack<int> sut = new(10);
        for (int i = 0; i < initialSize; i++)
        {
            sut.Push(i);
        }
        
        // Act
        _ = sut.Pop();
        
        // Assert
        Assert.Equal(expectedSize, sut.Size);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void Pop_NonEmptyStack_ReturnTop(int initialSize)
    {
        // Arrange
        Stack<int> sut = new(10);
        int expectedTop = initialSize - 1;
        for (int i = 0; i < initialSize; i++)
        {
            sut.Push(i);
        }
        
        // Act
        var top = sut.Pop();
        
        // Assert
        Assert.Equal(expectedTop, top);
    }

    [Fact]
    public void Pop_MoreComplexStack_ReturnTop()
    {
        // Arrange
        var sut = MoreComplexStack();
        
        // Act
        var top = sut.Pop();
        
        // Assert
        Assert.Equal(222, top);
    }

    /// <summary>
    /// Create stack of capacity 2 and size 3 through multiple push and pop operations.
    /// </summary>
    /// <returns>Stack of capacity 2, size 3 and elements (bottom to top): 111, 222</returns>
    private static Stack<int> MoreComplexStack()
    {
        Stack<int> res = new(3);
        
        res.Push(1);
        res.Push(2);
        res.Pop();
        res.Push(22);
        res.Push(33);
        res.Pop();
        res.Pop();
        res.Pop();
        res.Push(111);
        res.Push(222);

        return res;
    }
}