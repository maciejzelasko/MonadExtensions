using Xunit;

namespace FunctionalExtensions.Tests
{
    public class EitherTests
    {
        private class Left
        {
        }

        private class Right
        {
        }

        [Fact]
        public void Either_ShouldNotBeFailure()
        {
            // Act
            var result = new Either<Left, Right>(new Left());

            // Assert
        }
    }
}