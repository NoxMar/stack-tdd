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
}