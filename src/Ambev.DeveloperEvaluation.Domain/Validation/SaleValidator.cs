using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(sale => sale.CustomerId)
                .NotEmpty()
                .WithMessage("Customer ID cannot be empty.");

            RuleFor(sale => sale.CompanyBranchId)
                .NotEmpty()
                .WithMessage("Company branch ID cannot be empty.");

            RuleFor(sale => sale.Date)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Sale date cannot be in the future.");

            RuleFor(sale => sale.Items)
                .NotEmpty()
                .WithMessage("Sale must contain at least one item.")
                .Must(items => items != null && items.All(item => item.Quantity > 0))
                .WithMessage("All items must have a quantity greater than zero.");

            RuleForEach(sale => sale.Items)
                .SetValidator(new SaleItemValidator());
        }
    }
}
