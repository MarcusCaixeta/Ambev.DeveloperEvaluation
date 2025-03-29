using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for SaleItem entity operations
    /// </summary>
    public interface ISaleItemRepository
    {
        /// <summary>
        /// Retrieves all sale items associated with a specific sale
        /// </summary>
        /// <param name="saleId">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of sale items if found, an empty list otherwise</returns>
        Task<List<SaleItem?>> GetBySaleByIdAsync(Guid saleId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates multiple sale items in the repository
        /// </summary>
        /// <param name="saleItems">The list of sale items to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale items</returns>
        Task<List<SaleItem>> CreateManyAsync(List<SaleItem> saleItems, CancellationToken cancellationToken);
    }
}
