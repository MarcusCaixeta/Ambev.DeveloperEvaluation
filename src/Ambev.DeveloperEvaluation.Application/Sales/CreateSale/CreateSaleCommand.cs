using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Command for creating a new sale.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for creating a sale, 
    /// including customer ID, company branch ID, and sale items. 
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="CreateSaleResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="CreateSaleValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules. The validation ensures that:
    /// - Customer ID is provided and valid.
    /// - Company branch ID is provided and valid.
    /// - Sale items are valid, including product IDs, quantity, and unit price.
    /// </remarks>
    public class CreateSaleCommand : IRequest<CreateSaleResult>
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
        public List<CreateSaleItemCommand> Items { get; set; }

        /// <summary>
        /// Validates the sale data using the <see cref="CreateSaleValidator"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed.
        /// - Errors: Collection of validation errors if any rules failed.
        /// </returns>
        /// <remarks>        
        /// Validation rules include:
        /// - CompanyBranchId: Required, cannot be empty.
        /// - CustomerId: Required, cannot be empty.
        /// - Items: Each item must meet the following validation rules:
        ///   - Quantity: Must be greater than 0 and less than or equal to 20.
        ///   - UnitPrice: Must be greater than zero.
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new CreateSaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }

    public class CreateSaleItemCommand
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
