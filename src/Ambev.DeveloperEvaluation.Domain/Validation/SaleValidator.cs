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
        }
    }
}
