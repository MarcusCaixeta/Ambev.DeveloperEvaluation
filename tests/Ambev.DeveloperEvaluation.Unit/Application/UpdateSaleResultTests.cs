using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="UpdateSaleResult"/> class.
/// </summary>
public class UpdateSaleResultTests
{
    /// <summary>
    /// Tests that a valid data creates a valid result.
    /// </summary>
    [Fact(DisplayName = "Given valid data When creating result Then returns valid result")]
    public void CreateResult_ValidData_ReturnsValidResult()
    {
        // Given
        var result = new UpdateSaleResult
        {
            Id = Guid.NewGuid(),
            SaleNumber = 123456,
            CustomerId = 1,
            CompanyBranchId = 1,
            TotalSale = 100.0m,
            TotalSaleDiscount = 10.0m,
            TotalSaleAfterDiscount = 90.0m,
            IsSaleCancelled = false,
            Items = new List<UpdateSaleItemResult>
            {
                new UpdateSaleItemResult
                {
                    ProductId = 1,
                    Quantity = 5,
                    UnitPrice = 10.0m,
                    TotalSaleItemDiscount = 5.0m,
                    TotalSaleItemAfterDiscount = 45.0m
                }
            }
        };

        // Then
        result.Should().NotBeNull();
        result.Id.Should().NotBeEmpty();
        result.SaleNumber.Should().Be(123456);
        result.CustomerId.Should().Be(1);
        result.CompanyBranchId.Should().Be(1);
        result.TotalSale.Should().Be(100.0m);
        result.TotalSaleDiscount.Should().Be(10.0m);
        result.TotalSaleAfterDiscount.Should().Be(90.0m);
        result.IsSaleCancelled.Should().BeFalse();
        result.Items.Should().NotBeNullOrEmpty();
    }
}
