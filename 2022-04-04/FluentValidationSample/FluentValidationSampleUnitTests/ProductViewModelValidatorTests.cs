using FluentValidationSample.Models;
using Xunit;

namespace FluentValidationSampleUnitTests
{
    public class ProductViewModelValidatorTests
    {
        [Fact]
        public void Validator_ShouldHaveErrors_WhenNameIsNull()
        {
            // Arrange
            var model = new ProductViewModel()
            {
                Name = null,
                Sku = "TEST",
                Quantity = 0,
                Price = 0
            };

            // Act
            var result = new ProductViewModelValidator().Validate(model);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.ErrorMessage == "Please specify a name");
        }

        [Fact]
        public void Validator_ShouldHaveErrors_WhenSkuHasNotMinimalLength()
        {
            // Arrange
            var model = new ProductViewModel()
            {
                Name = "Test",
                Sku = "TT",
                Quantity = 0,
                Price = 0
            };

            // Act
            var result = new ProductViewModelValidator().Validate(model);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors,
                e => e.ErrorMessage == "'Sku' must be between 3 and 10 characters. You entered 2 characters.");
        }

        [Fact]
        public void Validator_ShouldHaveErrors_WhenQuantityIsNegative()
        {
            // Arrange
            var model = new ProductViewModel()
            {
                Name = "Test",
                Sku = "TEST",
                Quantity = -1,
                Price = 0
            };

            // Act
            var result = new ProductViewModelValidator().Validate(model);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors,
                e => e.ErrorMessage == "'Quantity' must be greater than or equal to '0'.");
        }

        [Fact]
        public void Validator_ShouldHaveErrors_WhenQuantityIsGreaterThanZeroButPriceIsZero()
        {
            // Arrange
            var model = new ProductViewModel()
            {
                Name = "Test",
                Sku = "TEST",
                Quantity = 1,
                Price = 0
            };

            // Act
            var result = new ProductViewModelValidator().Validate(model);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors,
                e => e.ErrorMessage == "Please specify a price");
        }

        [Fact]
        public void Validator_ShouldSucceed_WhenAllRulesAreSatisfied()
        {
            // Arrange
            var model = new ProductViewModel()
            {
                Name = "Test",
                Sku = "TEST",
                Quantity = 1,
                Price = 1
            };

            // Act
            var result = new ProductViewModelValidator().Validate(model);

            // Assert
            Assert.True(result.IsValid);
        }
    }
}
