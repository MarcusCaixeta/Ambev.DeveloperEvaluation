using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleById
{
    /// <summary>
    /// Represents the response returned after successfully select by id sale.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of the  sale,
    /// which can be used for subsequent operations or reference.
    /// </remarks>
    public class GetSaleByIdResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale.
        /// </summary>
        /// <value>A GUID that uniquely identifies the  sale in the system.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the sale number, which serves as the sale's unique identifier.
        /// </summary>
        public long SaleNumber { get; set; }

        /// <summary>
        /// Gets or sets the date when the sale was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the customer ID associated with the sale.
        /// </summary>
        public long CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the company branch ID where the sale occurred.
        /// </summary>
        public int CompanyBranchId { get; set; }

        /// <summary>
        /// Gets the total value of the sale.
        /// </summary>
        public decimal TotalSale { get; set; }

        // <summary>
        /// Gets the total discount applied to the sale.
        /// </summary>
        public decimal TotalSaleDiscount { get; set; }

        /// <summary>
        /// Gets the total sale amount after applying the discount.
        /// </summary>
        public decimal TotalSaleAfterDiscount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the sale is cancelled.
        /// </summary>
        public bool IsSaleCancelled { get; set; }

        /// <summary>
        /// Gets or sets the collection of sale items associated with the sale.
        /// </summary>
        /// <remarks>
        /// The `Items` collection holds the individual items involved in the sale. Each item in this collection
        /// is validated based on specific rules, including checks for quantity, unit price, and discounts.
        /// </remarks>
        public List<GetSaleByIdItemResponse> Items { get; set; }
    }

    public class GetSaleByIdItemResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the  item sale.
        /// </summary>
        /// <value>A GUID that uniquely identifies the item sale in the system.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the  sale.
        /// </summary>
        /// <value>A GUID that uniquely identifies the sale in the system.</value>
        public Guid SaleId { get; set; }

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

        /// <summary>
        /// Gets the unit price after applying any discounts.
        /// </summary>
        public decimal UnitDiscountPrice { get; set; }

        /// <summary>
        /// Gets the unit price after applying the discount and considering the quantity.
        /// </summary>
        public decimal UnitAfterDiscountPrice { get; set; }

        // <summary>
        /// Gets the total amount for the sale item not considering the discount.
        /// </summary>
        public decimal TotaSalelItem { get; set; }

        /// <summary>
        /// Gets the total discount applied to the sale item.
        /// </summary>
        public decimal TotalSaleItemDiscount { get; set; }

        /// <summary>
        /// Gets the total sale item value after applying the discount.
        /// </summary>
        public decimal TotalSaleItemAfterDiscount { get; set; }
        public bool IsSaleItemCancelled { get; set; }
    }
}
