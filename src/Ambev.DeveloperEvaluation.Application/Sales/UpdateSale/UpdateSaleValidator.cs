using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Validator for UpdateSaleCommand that defines validation rules for sale update command.
    /// </summary>
    public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the SaleValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - CompanyBranchId: Required, cannot be empty.
        /// - CustomerId: Required, cannot be empty.
        /// - Items: not empty items sale.
        /// - Items: Each item must meet the following validation rules:
        ///   - Quantity: Must be greater than 0 and less than or equal to 20.
        ///   - UnitPrice: Must be greater than zero.
        /// </remarks>
        public UpdateSaleValidator()
        {
            RuleFor(sale => sale.CompanyBranchId)
                        .NotEmpty().WithMessage("CompanyBranchId is required.");
            RuleFor(sale => sale.CustomerId)
                        .NotEmpty().WithMessage("CustomerId is required.");

            RuleFor(sale => sale.Items)
                        .NotEmpty().WithMessage("At least one item must be provided in the sale.");

            RuleForEach(sale => sale.Items).ChildRules(items =>
            {
                items.RuleFor(item => item.Quantity)
                    .GreaterThan(0).WithMessage("Quantity must be greater than 0.")
                    .LessThanOrEqualTo(20).WithMessage("Cannot sell more than 20 identical items.");

                items.RuleFor(item => item.UnitPrice)
               .GreaterThan(0)
               .WithMessage("Unit price must be greater than zero.");
            });
        }
    }
}
