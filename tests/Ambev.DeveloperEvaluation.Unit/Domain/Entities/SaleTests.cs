using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    /// <summary>
    /// Contains unit tests for the Sale entity class.
    /// Tests cover validation, total calculation, and cancellation.
    /// </summary>
    public class SaleTests
    {
        [Fact]
        public void Sale_ShouldBeValid_WhenCreatedWithCorrectData()
        {
            // Arrange
            var sale = new Sale(1, 1, false);

            // Act
            var validationResult = sale.Validate();

            // Assert
            validationResult.IsValid.Should().BeTrue();
            validationResult.Errors.Should().BeEmpty();
        }

        [Fact]
        public void Sale_ShouldBeInvalid_WhenCreatedWithIncorrectData()
        {
            // Arrange
            var sale = new Sale(0, 0, false);

            // Act
            var validationResult = sale.Validate();

            // Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void Sale_ShouldCalculateTotalsCorrectly()
        {
            // Arrange
            var sale = new Sale(1, 1, false);
            var saleItems = new List<SaleItem>
            {
                new SaleItem(1, 5, 100, false),
                new SaleItem(2, 10, 50, false)
            };

            // Act
            sale.SetTotals(saleItems);

            // Assert
            sale.TotalSale.Should().Be(100 * 5 + 50 * 10);
            sale.TotalSaleDiscount.Should().Be((100 * 5 * 0.10m) + (50 * 10 * 0.20m));
            sale.TotalSaleAfterDiscount.Should().Be(sale.TotalSale - sale.TotalSaleDiscount);
        }

        [Fact(DisplayName = "Sale should be marked as cancelled when Cancel is called")]
        public void Given_Sale_When_Cancel_Then_ShouldBeCancelled()
        {
            // Arrange
            var sale = new Sale(1, 1, false);

            // Act
            sale.Cancel();

            // Assert
            Assert.True(sale.IsSaleCancelled);
        }
    }
}
