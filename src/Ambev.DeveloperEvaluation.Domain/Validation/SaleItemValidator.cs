using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleItemValidator : AbstractValidator<SaleItem>
    {
        public SaleItemValidator()
        {
            RuleFor(item => item.ProductId)
                .NotEmpty()
                .WithMessage("Product ID cannot be empty.");

            RuleFor(item => item.ProductDescription)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Product description cannot exceed 100 characters.");

            RuleFor(item => item.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero.")
                .LessThanOrEqualTo(20)
                .WithMessage("Cannot sell more than 20 identical items.");

            RuleFor(item => item.UnitPrice)
                .GreaterThan(0)
                .WithMessage("Unit price must be greater than zero.");

            RuleFor(item => item.Discount)
                .InclusiveBetween(0, 0.5m)
                .WithMessage("Discount must be between 0% and 50%.");          
        }
    }
}