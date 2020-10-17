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
            public Right(string rightProperty)
            {
                RightProperty = rightProperty;
            }

            public string RightProperty { get; }
        }

        [Fact]
        public void LeftOrDefault_IsLeft_ReturnsLeft()
        {
            // Arrange
            var either = GetExampleLeft();

            // Act
            var left = either.LeftOrDefault();

            // Assert
            left.Should().NotBeNull();
        }

        [Fact]
        public void RightOrDefault_IsRight_ReturnsRight()
        {
            // Arrange
            var either = GetExampleRight();

            // Act
            var right = either.RightOrDefault();

            // Assert
            right.Should().NotBeNull();
        }

        private Either<Left, Right> GetExampleLeft() => new Left("Left value");

        private Either<Left, Right> GetExampleRight() => new Right("Right value");
    }
}