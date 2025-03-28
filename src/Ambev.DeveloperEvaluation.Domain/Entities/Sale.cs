using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public Sale(long customerId, int companyBranchId, bool isCancelled)
        {
            Date = DateTime.Now;
            CustomerId = customerId;
            CompanyBranchId = companyBranchId;
            IsCancelled = isCancelled;
        }


        /// <summary>
        ///  Receive sale number .
        /// Determines Sales identification.
        /// </summary>
        public long SaleNumber { get; set; }
        /// <summary>
        /// Receive date Sale.
        /// Date executing sale.
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Receive costumer from the sale.
        /// keep costumer sale.
        /// </summary>
        public long CustomerId { get; set; }
        /// <summary>
        /// Receive branch company 
        /// Save branch company for sale
        /// </summary>
        public int CompanyBranchId { get; set; }

        /// <summary>
        /// Staus sale
        /// saved status sale
        /// </summary>
        public bool IsCancelled { get; set; }

        /// Performs validation of the sale entity using the SaleValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">Sale number format (must follow 'XXXX' pattern)</list>
        /// <list type="bullet">Customer ID validity (non-empty Guid)</list>
        /// <list type="bullet">Company branch ID validity (non-empty Guid)</list>
        /// <list type="bullet">Sale date (cannot be in the future)</list>
        /// <list type="bullet">Items collection (must contain at least one valid item)</list>
        /// <list type="bullet">Each item's:
        ///     <list type="bullet">Product ID validity</list>
        ///     <list type="bullet">Description length (max 200 chars)</list>
        ///     <list type="bullet">Quantity (1-20 items)</list>
        ///     <list type="bullet">Unit price (positive value)</list>
        ///     <list type="bullet">Discount rules (0-50% with quantity restrictions)</list>
        /// </list>
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

        public void Cancel() => IsCancelled = true;
    }
}
