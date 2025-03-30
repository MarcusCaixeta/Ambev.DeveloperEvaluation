using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Xunit;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    /// <summary>
    /// Contains unit tests for the <see cref="UpdateSaleProfile"/> class.
    /// </summary>
    public class UpdateSaleProfileTests
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSaleProfileTests"/> class.
        /// Sets up the AutoMapper configuration and mapper instance.
        /// </summary>
        public UpdateSaleProfileTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<TestUpdateSaleProfile>());
            _mapper = config.CreateMapper();
        }

        /// <summary>
        /// Tests that the mapping configuration is valid.
        /// </summary>
        [Fact(DisplayName = "Given valid mapping configuration When validating Then configuration is valid")]
        public void MappingConfiguration_IsValid()
        {
            // Given
            var config = new MapperConfiguration(cfg => cfg.AddProfile<TestUpdateSaleProfile>());

            // When / Then
            config.AssertConfigurationIsValid();
        }

        /// <summary>
        /// Tests that UpdateSaleCommand maps to Sale correctly.
        /// </summary>
        [Fact(DisplayName = "Given UpdateSaleCommand When mapping to Sale Then maps correctly")]
        public void Map_UpdateSaleCommand_To_Sale()
        {
            // Given
            var command = new UpdateSaleCommand
            {
                CustomerId = 1,
                CompanyBranchId = 2,
                Items = new List<UpdateSaleItemCommand>
                {
                    new UpdateSaleItemCommand { ProductId = 1, Quantity = 2, UnitPrice = 10.0m }
                }
            };

            // When
            var sale = _mapper.Map<Sale>(command);

            // Then
            Assert.NotNull(sale);
            Assert.Equal(command.CustomerId, sale.CustomerId);
            Assert.Equal(command.CompanyBranchId, sale.CompanyBranchId);
        }

        /// <summary>
        /// Tests that Sale maps to UpdateSaleResult correctly.
        /// </summary>
        [Fact(DisplayName = "Given Sale When mapping to UpdateSaleResult Then maps correctly")]
        public void Map_Sale_To_UpdateSaleResult()
        {
            // Given
            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                SaleNumber = 12345,
                CreatedAt = DateTime.UtcNow,
                CustomerId = 1,
                CompanyBranchId = 2,
                IsSaleCancelled = false
            };

            // When
            var result = _mapper.Map<UpdateSaleResult>(sale);

            // Then
            Assert.NotNull(result);
            Assert.Equal(sale.Id, result.Id);
            Assert.Equal(sale.SaleNumber, result.SaleNumber);
            Assert.Equal(sale.CreatedAt, result.CreatedAt);
            Assert.Equal(sale.CustomerId, result.CustomerId);
            Assert.Equal(sale.CompanyBranchId, result.CompanyBranchId);
        }

        /// <summary>
        /// Tests that UpdateSaleItemCommand maps to SaleItem correctly.
        /// </summary>
        [Fact(DisplayName = "Given UpdateSaleItemCommand When mapping to SaleItem Then maps correctly")]
        public void Map_UpdateSaleItemCommand_To_SaleItem()
        {
            // Given
            var command = new UpdateSaleItemCommand
            {
                ProductId = 1,
                Quantity = 2,
                UnitPrice = 10.0m
            };

            // When
            var saleItem = _mapper.Map<SaleItem>(command);

            // Then
            Assert.NotNull(saleItem);
            Assert.Equal(command.ProductId, saleItem.ProductId);
            Assert.Equal(command.Quantity, saleItem.Quantity);
            Assert.Equal(command.UnitPrice, saleItem.UnitPrice);
        }

        /// <summary>
        /// Tests that SaleItem maps to UpdateSaleItemResult correctly.
        /// </summary>
        [Fact(DisplayName = "Given SaleItem When mapping to UpdateSaleItemResult Then maps correctly")]
        public void Map_SaleItem_To_UpdateSaleItemResult()
        {
            // Given
            var saleItem = new SaleItem
            {
                Id = Guid.NewGuid(),
                SaleId = Guid.NewGuid(),
                ProductId = 1,
                Quantity = 2,
                UnitPrice = 10.0m
            };

            // When
            var result = _mapper.Map<UpdateSaleItemResult>(saleItem);

            // Then
            Assert.NotNull(result);
            Assert.Equal(saleItem.Id, result.Id);
            Assert.Equal(saleItem.SaleId, result.SaleId);
            Assert.Equal(saleItem.ProductId, result.ProductId);
            Assert.Equal(saleItem.Quantity, result.Quantity);
            Assert.Equal(saleItem.UnitPrice, result.UnitPrice);
        }
    }

    /// <summary>
    /// Test profile for UpdateSale mappings.
    /// </summary>
    public class TestUpdateSaleProfile : Profile
    {
        public TestUpdateSaleProfile()
        {
            CreateMap<UpdateSaleCommand, Sale>()
                .ForMember(dest => dest.SaleNumber, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.TotalSale, opt => opt.Ignore())
                .ForMember(dest => dest.TotalSaleDiscount, opt => opt.Ignore())
                .ForMember(dest => dest.TotalSaleAfterDiscount, opt => opt.Ignore())
                .ForMember(dest => dest.IsSaleCancelled, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Sale, UpdateSaleResult>()
                .ForMember(dest => dest.Items, opt => opt.Ignore());

            CreateMap<UpdateSaleItemCommand, SaleItem>()
                .ForMember(dest => dest.SaleId, opt => opt.Ignore())
                .ForMember(dest => dest.IsSaleItemCancelled, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<SaleItem, UpdateSaleItemResult>()
                .ForMember(dest => dest.TotaSalelItem, opt => opt.Ignore());
        }
    }
}
