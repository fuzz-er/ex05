using Xunit;

public class CalculatorTests
{
    private readonly Calculator _calculator = new Calculator();

    // Тест на обычное деление
    [Theory]
    [InlineData(10, 2, 5)]      // 10 / 2 = 5
    [InlineData(1, 2, 0.5f)]    // 1 / 2 = 0.5
    [InlineData(-6, 3, -2)]     // -6 / 3 = -2
    [InlineData(0, 5, 0)]       // 0 / 5 = 0
    public void Divide_WithNormalNumbers_ReturnsCorrectResult(float a, float b, float expected)
    {
        // Act
        float result = _calculator.Divide(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    // Тест на деление на ноль (ожидаем Infinity)
    [Fact]
    public void Divide_ByZero_ReturnsInfinity()
    {
        // Arrange
        float a = 10;
        float b = 0;

        // Act
        float result = _calculator.Divide(a, b);

        // Assert
        Assert.True(float.IsInfinity(result));
    }

    // Тест на вызов деления через Calculate()
    [Fact]
    public void Calculate_DivisionOperator_ReturnsCorrectResult()
    {
        // Arrange
        float a = 10;
        float b = 2;
        char op = '/';

        // Act
        float result = _calculator.Calculate(a, b, op);

        // Assert
        Assert.Equal(5, result);
    }
}