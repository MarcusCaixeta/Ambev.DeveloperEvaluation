using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleItemRepository
    {/// <summary>
        /// Retrieves a sale item by their unique identifier sale
        /// </summary>
        /// <param name="saleId">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The user if found, null otherwise</returns>
        Task<List<SaleItem?>> GetBySaleByIdAsync(Guid saleId, CancellationToken cancellationToken = default);
    }
}
