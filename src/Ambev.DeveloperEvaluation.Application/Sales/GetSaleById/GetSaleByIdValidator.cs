using Ambev.DeveloperEvaluation.Application.Sales.GetSaleById;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById
{
    public class GetSaleByIdValidator : AbstractValidator<GetSaleByIdCommand>
    {
        /// <summary>
        /// Initializes validation rules for GetSaleByIdValidator
        /// </summary>
        public GetSaleByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("User ID is required");
        }
    }
}
