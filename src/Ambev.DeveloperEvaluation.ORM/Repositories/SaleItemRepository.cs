
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
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
        public async Task<List<SaleItem?>> GetBySaleByIdAsync(Guid saleId, CancellationToken cancellationToken = default)
        {
            return (await _context.SaleItems.Where(o => o.SaleId == saleId).ToListAsync(cancellationToken)).Cast<SaleItem?>().ToList();
        }
    }
}
