using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using System;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    public static class SaleItemTestData
    {
        private static readonly Faker<SaleItem> SaleItemFaker = new Faker<SaleItem>()
            .CustomInstantiator(f => new SaleItem(
                productId: 1,
                productDescription: f.Commerce.ProductName(),
                quantity: f.Random.Int(1, 20),
                unitPrice: f.Random.Decimal(10, 1000),
                isCancelled: false
            ));

        public static SaleItem GenerateValidSaleItem(int? fixedQuantity = null, decimal? fixedPrice = null)
        {
            var item = SaleItemFaker.Generate();

            if (fixedQuantity.HasValue || fixedPrice.HasValue)
            {
                item = new SaleItem(
                    productId: item.ProductId,
                    productDescription: item.ProductDescription,
                    quantity: fixedQuantity ?? item.Quantity,
                    unitPrice: fixedPrice ?? item.UnitPrice,
                isCancelled: false
                );
            }

            item.ApplyDiscount();
            return item;
        }

        public static SaleItem GenerateInvalidSaleItem()
        {
            return new SaleItem(
                productId: 0,
                productDescription: "",
                quantity: 0,
                unitPrice: -10,
                isCancelled: false
            );
        }

        public static SaleItem GenerateSaleItemWithHighDiscount()
        {
            return new SaleItem(
                productId: 1,
                productDescription: "Bulk Discount Test",
                quantity: 15, 
                unitPrice: 100,
                isCancelled: false
            );
        }
    }
}
