using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// Validator for UpdateSaleRequest that defines validation rules for user creation.
    /// </summary>
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateSaleRequestValidator with defined validation rules.
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
        public UpdateSaleRequestValidator()
        {
            RuleFor(sale => sale.CompanyBranchId)
                                   .NotEmpty().WithMessage("CompanyBranchId is required.");
            RuleFor(sale => sale.CustomerId)
                        .NotEmpty().WithMessage("CustomerId is required.");

            RuleFor(sale => sale.Items)
                        .NotEmpty().WithMessage("At least one item must be provided in the sale.");

            RuleFor(sale => sale.Items)
            .NotEmpty().WithMessage("At least one SaleItem is required.")
            .Must((sale, items) => items.All(item => item.SaleId == sale.Id))
            .WithMessage("All SaleItems must have the same SaleId as the sale.");

            RuleForEach(sale => sale.Items).ChildRules(items =>
            {
                items.RuleFor(item => item.Quantity)
                    .GreaterThan(0).WithMessage("Quantity must be greater than 0.")
                    .LessThanOrEqualTo(20).WithMessage("Cannot sell more than 20 identical items.");

                items.RuleFor(item => item.UnitPrice)
               .GreaterThan(0)
               .WithMessage("Unit price must be greater than zero.");

                items.RuleFor(i => i.SaleId)
                .NotEmpty().WithMessage("SaleId is required for each item.");
            });
        }
    }
}
