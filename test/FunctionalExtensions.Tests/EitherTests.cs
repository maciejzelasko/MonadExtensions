using FluentAssertions;
using Xunit;

namespace FunctionalExtensions.Tests
{
    public class EitherTests
    {
        private class Left
        {
            public Left(string leftProperty)
            {
                LeftProperty = leftProperty;
            }

            public string LeftProperty { get; }
        }

        private class Right
        {
        }

        [Fact]
        public void LeftOrDefault_IsLeft_ReturnsLeft()
        {
            // Arrange
            var either = new Either<Left, Right>(new Left("Value"));

            // Act
            var left = either.LeftOrDefault();

            // Assert
            left.Should().NotBeNull();
        }

        [Fact]
        public void RightOrDefault_IsRight_ReturnsRight()
        {
            // Arrange
            var either = new Either<Left, Right>(new Right());

            // Act
            var right = either.RightOrDefault();

            // Assert
            right.Should().NotBeNull();
        }
    }
}