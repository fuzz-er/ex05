using Xunit;

public class CalculatorTests
{
    private readonly Calculator _calculator = new Calculator();

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
    [Theory]
    [InlineData(2, 3, 8)]        // 2^3 = 8
    [InlineData(5, 0, 1)]        // 5^0 = 1
    [InlineData(10, 1, 10)]      // 10^1 = 10
    [InlineData(3, -1, 0.33333f)] // 3^-1 ≈ 0.33333
    [InlineData(4, 0.5f, 2)]     // 4^0.5 = 2 (квадратный корень)
    [InlineData(1, 100, 1)]      // 1^100 = 1
    public void Power_WithDifferentExponents_ReturnsCorrectResult(float baseNum, float exponent, float expected)
    {
        // Act
        float result = _calculator.Power(baseNum, exponent);

        // Assert
        Assert.Equal(expected, result, 5); // Проверяем с точностью до 5 знаков
    }

    [Fact]
    public void Calculate_PowerOperator_ReturnsCorrectResult()
    {
        // Arrange
        float a = 2;
        float b = 3;
        char op = '^';

        // Act
        float result = _calculator.Calculate(a, b, op);

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Power_WithNegativeBaseAndFractionalExponent_ReturnsNaN()
    {
        // Arrange
        float a = -4;
        float b = 0.5f; // Попытка извлечь квадратный корень из отрицательного числа

        // Act
        float result = _calculator.Power(a, b);

        // Assert
        Assert.True(float.IsNaN(result));
    }
}
