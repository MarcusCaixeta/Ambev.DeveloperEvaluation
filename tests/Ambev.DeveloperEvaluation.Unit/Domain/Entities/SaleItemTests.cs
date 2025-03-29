using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleItemTests
    {
        [Fact]
        public void SaleItem_ShouldBeValid_WhenCreatedWithCorrectData()
        {
            // Arrange
            var item = SaleItemTestData.GenerateValidSaleItem();

            // Act
            var validationResult = item.Validate();

            // Assert
            validationResult.IsValid.Should().BeTrue();
            validationResult.Errors.Should().BeEmpty();
        }

        [Fact]
        public void SaleItem_ShouldBeInvalid_WhenCreatedWithIncorrectData()
        {
            // Arrange
            var item = SaleItemTestData.GenerateInvalidSaleItem();

            // Act
            var validationResult = item.Validate();

            // Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void SaleItem_ShouldApplyDiscountCorrectly()
        {
            // Arrange
            var item = SaleItemTestData.GenerateSaleItemWithHighDiscount();

            // Act
            decimal expectedDiscount = 0.20m; // Para quantidade >= 10
            decimal expectedTotal = (item.UnitPrice * item.Quantity) * (1 - expectedDiscount);

            // Assert
            item.DiscountPercentual.Should().Be(expectedDiscount);
            item.CalculateTotal().Should().Be(expectedTotal);
        }

        [Fact]
        public void SaleItem_ShouldThrowException_WhenQuantityExceedsLimit()
        {
            // Arrange & Act
            var act = () => new SaleItem(1, 21, 100, false);

            // Assert
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Cannot sell more than 20 identical items.");
        }

        [Fact(DisplayName = "Sale should be marked as cancelled when Cancel is called")]
        public void Given_Sale_When_Cancel_Then_ShouldBeCancelled()
        {
            // Arrange
            var sale = SaleItemTestData.GenerateValidSaleItem();

            // Act
            sale.Cancel();

            // Assert
            Assert.True(sale.IsSaleItemCancelled);
        }
    }
}
