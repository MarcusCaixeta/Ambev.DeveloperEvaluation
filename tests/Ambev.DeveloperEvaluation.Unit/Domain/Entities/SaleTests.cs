using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    /// <summary>
    /// Contains unit tests for the Sale entity class.
    /// Tests cover validation, total calculation, and cancellation.
    /// </summary>
    public class SaleTests
    {
        [Fact(DisplayName = "Validation should pass for valid sale data")]
        public void Given_ValidSaleData_When_Validated_Then_ShouldReturnValid()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();

            // Act
            var result = sale.Validate();

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact(DisplayName = "Validation should fail for invalid sale data")]
        public void Given_InvalidSaleData_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var sale = SaleTestData.GenerateInvalidSale();

            // Act
            var result = sale.Validate();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }

        [Fact(DisplayName = "Total calculation should sum item totals correctly")]
        public void Given_SaleWithItems_When_CalculateTotal_Then_ShouldReturnCorrectTotal()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            var expectedTotal = sale.Items.Sum(item => item.CalculateTotal());

            // Act
            var total = sale.CalculateTotal();

            // Assert
            Assert.Equal(expectedTotal, total);
        }

        [Fact(DisplayName = "Sale should be marked as cancelled when Cancel is called")]
        public void Given_Sale_When_Cancel_Then_ShouldBeCancelled()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();

            // Act
            sale.Cancel();

            // Assert
            Assert.True(sale.IsCancelled);
        }
    }
}
