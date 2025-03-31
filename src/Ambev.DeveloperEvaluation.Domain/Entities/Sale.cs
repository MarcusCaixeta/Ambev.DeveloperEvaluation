using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sale transaction and its associated details.
    /// </summary>
    /// <remarks>
    /// This class contains the necessary properties and methods to manage and validate a sale, 
    /// including the sale number, customer details, branch information, total sale values, 
    /// and sale status (whether it is cancelled or not).
    /// </remarks>
    public class Sale : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sale"/> class with specific values.
        /// </summary>
        /// <param name="customerId">The customer ID associated with the sale.</param>
        /// <param name="companyBranchId">The company branch ID where the sale occurred.</param>
        /// <param name="isSaleCancelled">Indicates whether the sale is cancelled.</param>
        public Sale(long customerId, int companyBranchId, bool isSaleCancelled)
        {
            CreatedAt = DateTime.Now;
            CustomerId = customerId;
            CompanyBranchId = companyBranchId;
            IsSaleCancelled = isSaleCancelled;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sale"/> class with default values.
        /// </summary>
        public Sale()
        {
            CreatedAt = DateTime.UtcNow;
        }

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
        public decimal TotalSale { get; private set; }

        /// <summary>
        /// Gets the total discount applied to the sale.
        /// </summary>
        public decimal TotalSaleDiscount { get; private set; }

        /// <summary>
        /// Gets the total sale amount after applying the discount.
        /// </summary>
        public decimal TotalSaleAfterDiscount { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the sale is cancelled.
        /// </summary>
        public bool IsSaleCancelled { get;  set; }

        /// <summary>
        /// Performs validation of the sale entity using the SaleValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed.
        /// - Errors: Collection of validation errors if any rules failed.
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">Customer ID validity (non-empty value).</list>
        /// <list type="bullet">Company branch ID validity (non-empty value).</list>
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);

            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        /// <summary>
        /// Calculates and sets the total values for the sale, including total sale value, 
        /// total discount, and total after discount.
        /// </summary>
        /// <param name="saleItems">A list of sale items associated with the sale.</param>
        public void SetTotals(List<SaleItem> saleItems)
        {         
            TotalSale = saleItems.Sum(item => item.TotalSaleItem);
            TotalSaleDiscount = saleItems.Sum(item => item.TotalSaleItemDiscount);
            TotalSaleAfterDiscount = saleItems.Sum(item => item.TotalSaleItemAfterDiscount);
        }

        /// <summary>
        /// Cancels the sale by setting the sale status to cancelled.
        /// </summary>
        public void Cancel() => IsSaleCancelled = true;
    }
}
