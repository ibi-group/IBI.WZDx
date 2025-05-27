using IBI.WZDx.Equality;
using Xunit;

namespace IBI.WZDx.UnitTests.Equality;

/// <summary>
/// Tests for <see cref="DoubleExtensions"/>.
/// </summary>
public class DoubleExtensionsTests
{
    /// <summary>
    /// Tests for <see cref="DoubleExtensions.NullEqualsApproximation"/>.
    /// </summary>
    public class NullEqualsApproximation
    {
        [Fact]
        public void Should_return_true_when_both_values_are_null()
        {
            // Arrange
            double? value1 = null;
            double? value2 = null;

            // Act
            bool result = value1.NullEqualsApproximation(value2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Should_return_false_when_only_first_value_is_null()
        {
            // Arrange
            double? value1 = null;
            double? value2 = 1.0;

            // Act
            bool result = value1.NullEqualsApproximation(value2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Should_return_false_when_only_second_value_is_null()
        {
            // Arrange
            double? value1 = 1.0;
            double? value2 = null;

            // Act
            bool result = value1.NullEqualsApproximation(value2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Should_return_true_when_values_are_equal()
        {
            // Arrange
            double? value1 = 1.0;
            double? value2 = 1.0;

            // Act
            bool result = value1.NullEqualsApproximation(value2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Should_return_true_when_difference_is_less_than_epsilon()
        {
            // Arrange
            double? value1 = 1.0;
            double? value2 = value1 + double.Epsilon / 2;

            // Act
            bool result = value1.NullEqualsApproximation(value2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Should_return_false_when_values_are_different()
        {
            // Arrange
            double? value1 = 1.0;
            double? value2 = 1.1;

            // Act
            bool result = value1.NullEqualsApproximation(value2);

            // Assert
            Assert.False(result);
        }
    }
}