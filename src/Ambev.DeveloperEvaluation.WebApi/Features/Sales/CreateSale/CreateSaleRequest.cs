using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Represents a request to create a new sale in the system.
    /// </summary>
    public class CreateSaleRequest
    {
        /// <summary>
        /// Gets or sets the customer ID associated with the sale.
        /// </summary>
        public long CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the company branch ID where the sale occurred.
        /// </summary>
        public int CompanyBranchId { get; set; }

        /// <summary>
        /// Gets or sets the collection of sale items associated with the sale.
        /// </summary>
        /// <remarks>
        /// The `Items` collection holds the individual items involved in the sale. Each item in this collection
        /// is validated based on specific rules, including checks for quantity, unit price, and discounts.
        /// 
        /// </remarks>
        public List<CreateSaleItemRequest> Items { get; set; }
    }

    public class CreateSaleItemRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sold product.
        /// </summary>
        public long ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product sold.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the sold product.
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}
