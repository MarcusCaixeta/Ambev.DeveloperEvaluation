using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sale item in the system.
    /// Contains product details, quantity, pricing, and discount logic.
    /// This entity includes business rules and validation.
    /// </summary>
    public class SaleItem : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the SaleItem class with the specified values.
        /// </summary>
        /// <param name="productId">The ID of the product sold.</param>
        /// <param name="quantity">The quantity of the product sold.</param>
        /// <param name="unitPrice">The unit price of the product sold.</param>
        /// <param name="isSaleItemCancelled">Indicates if the sale item is canceled.</param>
        public SaleItem(long productId, int quantity, decimal unitPrice, bool isSaleItemCancelled)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            IsSaleItemCancelled = isSaleItemCancelled;
        }

        /// <summary>
        /// Default constructor for SaleItem.
        /// </summary>
        public SaleItem() { }

        /// <summary>
        /// Gets or sets the unique identifier for the sale to which this item belongs.
        /// </summary>
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
        public decimal UnitDiscountPrice => CalculateUnitDiscount();

        /// <summary>
        /// Gets the unit price after applying the discount and considering the quantity.
        /// </summary>
        public decimal UnitAfterDiscountPrice => CalculateUnitAfterDiscount();

        /// <summary>
        /// Gets the discount percentage based on the quantity of items purchased.
        /// </summary>
        public decimal DiscountPercentual => Quantity switch
        {
            >= 10 and <= 20 => 0.20m, 
            >= 4 => 0.10m,  
            _ => 0m         
        };

        /// <summary>
        /// Gets the total amount for the sale item not considering the discount.
        /// </summary>
        public decimal TotalSaleItem => CalculateTotal();

        /// <summary>
        /// Gets the total discount applied to the sale item.
        /// </summary>
        public decimal TotalSaleItemDiscount => CalculateDiscount();

        /// <summary>
        /// Gets the total sale item value after applying the discount.
        /// </summary>
        public decimal TotalSaleItemAfterDiscount => CalculateTotalAfterDiscount();

        /// <summary>
        /// Gets a value indicating whether the sale item has been cancelled.
        /// </summary>
        public bool IsSaleItemCancelled { get; private set; }

        /// <summary>
        /// Performs validation of the sale item using the SaleItemValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed.
        /// - Errors: Collection of validation errors if any rules failed.
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking the following rules for each sale item:</listheader>
        /// <list type="bullet">Product ID must not be empty.</list>
        /// <list type="bullet">Quantity must be greater than zero and less than or equal to 20.</list>
        /// <list type="bullet">Unit price must be greater than zero.</list>
        /// 
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new SaleItemValidator();
            var result = validator.Validate(this);

            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        /// <summary>
        /// Calculates the total value for the sale item considering no discounts.
        /// </summary>
        /// <returns>The total value of the sale item before discount.</returns>
        public decimal CalculateTotal() => (UnitPrice * Quantity);

        /// <summary>
        /// Calculates the total value for the sale item after applying the discount.
        /// </summary>
        /// <returns>The total value of the sale item after discount.</returns>
        public decimal CalculateTotalAfterDiscount() => (UnitPrice * Quantity) * (1 - DiscountPercentual);

        // <summary>
        /// Calculates the total discount applied to the sale item.
        /// </summary>
        /// <returns>The total discount for the sale item.</returns>
        public decimal CalculateDiscount() => UnitPrice * Quantity * DiscountPercentual;
        /// <summary>
        /// Calculates the unit discount applied to the sale item.
        /// </summary>
        /// <returns>The unit discount for the sale item.</returns>
        public decimal CalculateUnitDiscount() => (UnitPrice * Quantity * DiscountPercentual) / Quantity;
        /// <summary>
        /// Calculates the unit price after applying the discount considering the quantity.
        /// </summary>
        /// <returns>The unit price after discount considering the quantity.</returns>
        public decimal CalculateUnitAfterDiscount() => (UnitPrice * Quantity) * (1 - DiscountPercentual) / Quantity;

        /// <summary>
        /// Cancels the sale item by setting its cancelled status to true.
        /// </summary>
        public void Cancel() => IsSaleItemCancelled = true;
    }
}
