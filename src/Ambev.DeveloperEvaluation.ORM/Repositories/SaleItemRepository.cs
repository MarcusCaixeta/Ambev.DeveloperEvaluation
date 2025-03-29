
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of ISaleItemRepository using Entity Framework Core
    /// </summary>
    public class SaleItemRepository : ISaleItemRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of SaleRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public SaleItemRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all sale items associated with a specific sale
        /// </summary>
        /// <param name="saleId">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of sale items if found, an empty list otherwise</returns>
        public async Task<List<SaleItem?>> GetBySaleByIdAsync(Guid saleId, CancellationToken cancellationToken = default)
        {
            return (await _context.SaleItems.Where(o => o.SaleId == saleId).ToListAsync(cancellationToken)).Cast<SaleItem?>().ToList();
        }

        /// <summary>
        /// Creates multiple sale items in the repository
        /// </summary>
        /// <param name="saleItems">The list of sale items to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale items</returns>
        public async Task<List<SaleItem>> CreateManyAsync(List<SaleItem> saleItems, CancellationToken cancellationToken)
        {          
            await _context.SaleItems.AddRangeAsync(saleItems, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return saleItems;
        }
    }
}
