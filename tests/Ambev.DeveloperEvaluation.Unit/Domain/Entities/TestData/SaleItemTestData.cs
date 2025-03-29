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
                quantity: f.Random.Int(1, 20),
                unitPrice: f.Random.Decimal(10, 1000),
                isSaleItemCancelled: false
            ));

        public static SaleItem GenerateValidSaleItem(int? fixedQuantity = null, decimal? fixedPrice = null)
        {
            var item = SaleItemFaker.Generate();

            if (fixedQuantity.HasValue || fixedPrice.HasValue)
            {
                item = new SaleItem(
                    productId: item.ProductId,
                    quantity: fixedQuantity ?? item.Quantity,
                    unitPrice: fixedPrice ?? item.UnitPrice,
                isSaleItemCancelled: false
                );
            }            
            return item;
        }

        public static SaleItem GenerateInvalidSaleItem()
        {
            return new SaleItem(
                productId: 0,
                quantity: 0,
                unitPrice: -10,
                isSaleItemCancelled: false
            );
        }

        public static SaleItem GenerateSaleItemWithHighDiscount()
        {
            return new SaleItem(
                productId: 1,
                quantity: 15, 
                unitPrice: 100,
                isSaleItemCancelled: false
            );
        }
    }
}
