using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById
{
    public class GetSaleByIdCommand : IRequest<GetSaleByIdResult>
    {
        /// <summary>
        /// The unique identifier of the user to retrieve
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of GetUserCommand
        /// </summary>
        /// <param name="id">The ID of the user to retrieve</param>
        public GetSaleByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
