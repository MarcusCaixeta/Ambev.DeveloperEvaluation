using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById
{
    /// <summary>
    /// Command for retrieving a sale by their ID
    /// </summary>
    public class GetSaleByIdCommand : IRequest<GetSaleByIdResult>
    {
        /// <summary>
        /// The unique identifier of the sale to retrieve
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of GetSaleByIdCommand
        /// </summary>
        /// <param name="id">The ID of the sale to retrieve</param>
        public GetSaleByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
