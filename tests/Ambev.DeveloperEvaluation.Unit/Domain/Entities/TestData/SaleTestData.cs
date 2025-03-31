﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using FluentAssertions.Common;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData

{
    public static class SaleTestData
    {
        private static long _lastSequentialNumberLong = DateTime.Now.Ticks % 1000000;
        private static int _lastSequentialNumberInt = (int)DateTime.Now.Ticks % 1000000;
        private static readonly object _lock = new object();


        private static readonly Faker<SaleItem> SaleItemFaker = new Faker<SaleItem>()
            .CustomInstantiator(f => new SaleItem(
                productId: GenerateSequentialNumberLong(),
                quantity: f.Random.Int(1, 20),
                unitPrice: f.Random.Decimal(10, 1000),
                isSaleItemCancelled: false
            ));

        private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
            .CustomInstantiator(f => new Sale(
                customerId: GenerateSequentialNumberLong(),
                companyBranchId: GenerateSequentialNumberInt(),
                isSaleCancelled: false
            ));

        private static long GenerateSequentialNumberLong()
        {
            lock (_lock)
            {
                return Interlocked.Increment(ref _lastSequentialNumberLong);
            }
        }

        private static int GenerateSequentialNumberInt()
        {
            lock (_lock)
            {
                return Interlocked.Increment(ref _lastSequentialNumberInt);
            }
        }

        public static Sale GenerateValidSale(int itemCount = 1, bool isCancelled = false)
        {
            var sale = SaleFaker.Generate();           
            sale.IsSaleCancelled = isCancelled;
            return sale;
        }

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

        public static Sale GenerateEmptySale() =>
            new Sale(0, 0, false);

        public static Sale GenerateCancelledSale() =>
            GenerateValidSale(isCancelled: true);

        public static Sale GenerateInvalidSale()
        {
            return new Sale(
                customerId: 0,
                companyBranchId: 0,
                isSaleCancelled: false
            );
        }

        public static SaleItem GenerateInvalidSaleItem()
        {
            return new SaleItem(
                productId: 0,
                quantity: 21, // Quantidade inválida
                unitPrice: 100,
                isSaleItemCancelled: false
            );
        }
    }
}
