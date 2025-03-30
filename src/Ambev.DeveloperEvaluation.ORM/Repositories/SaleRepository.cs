﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of ISaleRepository using Entity Framework Core
    /// </summary>
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of SaleRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Begins a new database transaction for sale operations
        /// </summary>
        /// <returns>An active database transaction</returns>
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        /// <summary>
        /// Retrieves a sale by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the user</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale if found, null otherwise</returns>
        public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Sales.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        /// <summary>
        /// Creates a new sale in the repository
        /// </summary>
        /// <param name="sale">The sale entity to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale</returns>
        public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            await _context.Sales.AddAsync(sale, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return sale;
        }

        /// <summary>
        /// Deletes a sale from the database
        /// </summary>
        /// <param name="id">The unique identifier of the sale to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the sale was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var sale = await GetByIdAsync(id, cancellationToken);
            if (sale == null)
                return false;

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <summary>
        /// update sale in the repository
        /// </summary>
        /// <param name="sale">The sale entity to update</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated sale</returns>
        public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            var existingSale = await GetByIdAsync(sale.Id, cancellationToken);
            if (existingSale == null)
                throw new KeyNotFoundException("Sale not found.");

            sale.CreatedAt = existingSale.CreatedAt;

            _context.Entry(existingSale).CurrentValues.SetValues(sale);

            await _context.SaveChangesAsync(cancellationToken);
            return sale;
        }
    }
}
