using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById
{
    public class GetSaleByIdResult
    {

        /// <summary>
        ///  Receive sale id .
        /// Determines Sales identification.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        ///  Receive sale number .
        /// Determines Sales identification.
        /// </summary>
        public long SaleNumber { get; set; }
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
        /// <summary>
        /// Receive sale items 
        /// Sabe Items for the sale
        /// </summary>
        public List<SaleItem> Items { get; set; }
        /// <summary>
        /// Staus sale
        /// saved status sale
        /// </summary>
        public bool IsCancelled { get; set; }
    }
}
