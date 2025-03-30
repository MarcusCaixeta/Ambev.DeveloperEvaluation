using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

internal class UpdateSaleHandlerTestData
{
    public static UpdateSaleCommand GenerateValidCommand()
    {
        return new UpdateSaleCommand
        {
            Id = Guid.NewGuid(),
            SaleNumber = 123456,
            CustomerId = 1,
            CompanyBranchId = 1,
            IsSaleCancelled = false,
            Items = new List<UpdateSaleItemCommand>
            {
                new UpdateSaleItemCommand
                {
                    ProductId = 1,
                    Quantity = 5,
                    UnitPrice = 10.0m
                },
                new UpdateSaleItemCommand
                {
                    ProductId = 2,
                    Quantity = 3,
                    UnitPrice = 20.0m
                }
            }
        };
    }

    public static UpdateSaleCommand GenerateInvalidCommand()
    {
        return new UpdateSaleCommand
        {
            Id = Guid.Empty, // Invalid ID
            SaleNumber = 0, // Invalid Sale Number
            CustomerId = 0, // Invalid Customer ID
            CompanyBranchId = 0, // Invalid Company Branch ID
            IsSaleCancelled = false,
            Items = new List<UpdateSaleItemCommand>
            {
                new UpdateSaleItemCommand
                {
                    ProductId = 0, // Invalid Product ID
                    Quantity = 0, // Invalid Quantity
                    UnitPrice = 0.0m // Invalid Unit Price
                }
            }
        };
    }
}
