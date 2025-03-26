using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public SaleItem(long productId, string productDescription, int quantity, decimal unitPrice, bool isCancelled)
        {
            ProductId = productId;
            ProductDescription = productDescription;
            Quantity = quantity;
            UnitPrice = unitPrice;
            IsCancelled = isCancelled;
            ApplyDiscount(); 
        }      

        /// <summary>
        ///  Receive sale number .
        /// Determines Sales identification.
        /// </summary>
        public long ProductId { get; private set; }
        /// <summary>
        ///  Receive sale number .
        /// Determines Sales identification.
        /// </summary>
        public string ProductDescription { get;  set; }
        /// <summary>
        ///  Receive sale number .
        /// Determines Sales identification.
        /// </summary>
        public int Quantity { get;  set; }
        /// <summary>
        ///  Receive sale number .
        /// Determines Sales identification.
        /// </summary>
        public decimal UnitPrice { get;  set; }
        /// <summary>
        ///  Receive sale number .
        /// Determines Sales identification.
        /// </summary>
        public decimal Discount { get;  set; }

        public bool IsCancelled { get; set; }


        /// Performs validation of the sale entity using the SaleItemValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">Product ID validity (non-empty Guid)</list>
        /// <list type="bullet">Product description length (max 100 chars)</list>
        /// <list type="bullet">Quantity (must be between 1 and 20)</list>
        /// <list type="bullet">Unit price (must be a positive value)</list>
        /// <list type="bullet">Discount rules (must be between 0% and 50%)</list>
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new SaleItemValidator();
            var result = validator.Validate(this);

            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public decimal CalculateTotal() => (UnitPrice * Quantity) * (1 - Discount);

        public void ApplyDiscount()
        {
            if (Quantity > 20)
                throw new InvalidOperationException("Cannot sell more than 20 identical items.");

            Discount = Quantity switch
            {
                >= 10 => 0.20m,
                >= 4 => 0.10m,
                _ => 0m
            };
        }
        public void Cancel() => IsCancelled = true;
    }
}
