using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        /// <summary>
        /// Receive date Sale.
        /// Date executing sale.
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Receive costumer from the sale.
        /// keep costumer sale.
        /// </summary>
        public long CustomerId { get; set; }
        /// <summary>
        /// Receive branch company 
        /// Save branch company for sale
        /// </summary>
        public int CompanyBranchId { get; set; }
        public List<SaleItem> Items { get; set; }

    }
}
