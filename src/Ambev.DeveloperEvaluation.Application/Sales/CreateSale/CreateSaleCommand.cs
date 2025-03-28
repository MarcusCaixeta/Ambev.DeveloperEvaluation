using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
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
