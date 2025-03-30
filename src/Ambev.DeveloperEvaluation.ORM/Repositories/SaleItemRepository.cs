
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

        /// <summary>
        /// Update multiple sale items in the repository.
        /// </summary>
        /// <param name="saleItems">The list of sale items to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The updated sale items.</returns>
        public async Task<List<SaleItem>> UpdateManyAsync(List<SaleItem> saleItems, CancellationToken cancellationToken = default)
        {
            if (saleItems == null || !saleItems.Any())
                throw new ArgumentException("The list of sale items cannot be empty.");

            var itemIds = saleItems.Select(si => si.Id).ToList();

            // Busca todos os itens de venda de uma vez
            var existingItems = await _context.SaleItems
                                              .Where(si => itemIds.Contains(si.Id))
                                              .ToListAsync(cancellationToken);

            if (existingItems.Count != saleItems.Count)
                throw new KeyNotFoundException("One or more SaleItems were not found.");

            // Atualiza os valores de cada item existente
            foreach (var item in saleItems)
            {
                var existingItem = existingItems.FirstOrDefault(e => e.Id == item.Id);
                if (existingItem != null)
                {
                    _context.Entry(existingItem).CurrentValues.SetValues(item);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
            return saleItems;
        }

    }
}
