using FluentAssertions;
using Xunit;

namespace FunctionalExtensions.Tests
{
    public class ResultTests
    {
        [Fact]
        public void Success_ShouldNotBeFailure()
        {
            // Arrange

            // Act
            var result = Result.Success();

            // Assert
            result.IsFailure.Should().BeFalse();
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Failure_ShouldNotBeSuccess()
        {
            // Arrange

            // Act
            var result = Result.Failure();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.IsFailure.Should().BeTrue();
        }
    }
}