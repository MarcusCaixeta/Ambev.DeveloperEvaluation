using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Xunit;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    /// <summary>
    /// Contains unit tests for the <see cref="CreateSaleProfile"/> class.
    /// </summary>
    public class CreateSaleProfileTests
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSaleProfileTests"/> class.
        /// Sets up the AutoMapper configuration and mapper instance.
        /// </summary>
        public CreateSaleProfileTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<TestCreateSaleProfile>());
            _mapper = config.CreateMapper();
        }

        /// <summary>
        /// Tests that the mapping configuration is valid.
        /// </summary>
        [Fact(DisplayName = "Given valid mapping configuration When validating Then configuration is valid")]
        public void MappingConfiguration_IsValid()
        {
            // Given
            var config = new MapperConfiguration(cfg => cfg.AddProfile<TestCreateSaleProfile>());

            // When / Then
            config.AssertConfigurationIsValid();
        }

        /// <summary>
        /// Tests that CreateSaleCommand maps to Sale correctly.
        /// </summary>
        [Fact(DisplayName = "Given CreateSaleCommand When mapping to Sale Then maps correctly")]
        public void Map_CreateSaleCommand_To_Sale()
        {
            // Given
            var command = new CreateSaleCommand
            {
                CustomerId = 1,
                CompanyBranchId = 2,
                Items = new List<CreateSaleItemCommand>
                {
                    new CreateSaleItemCommand { ProductId = 1, Quantity = 2, UnitPrice = 10.0m }
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
        /// Tests that Sale maps to CreateSaleResult correctly.
        /// </summary>
        [Fact(DisplayName = "Given Sale When mapping to CreateSaleResult Then maps correctly")]
        public void Map_Sale_To_CreateSaleResult()
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
            var result = _mapper.Map<CreateSaleResult>(sale);

            // Then
            Assert.NotNull(result);
            Assert.Equal(sale.Id, result.Id);
            Assert.Equal(sale.SaleNumber, result.SaleNumber);
            Assert.Equal(sale.CreatedAt, result.CreatedAt);
            Assert.Equal(sale.CustomerId, result.CustomerId);
            Assert.Equal(sale.CompanyBranchId, result.CompanyBranchId);
        }

        /// <summary>
        /// Tests that CreateSaleItemCommand maps to SaleItem correctly.
        /// </summary>
        [Fact(DisplayName = "Given CreateSaleItemCommand When mapping to SaleItem Then maps correctly")]
        public void Map_CreateSaleItemCommand_To_SaleItem()
        {
            // Given
            var command = new CreateSaleItemCommand
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
        /// Tests that SaleItem maps to CreateSaleItemResult correctly.
        /// </summary>
        [Fact(DisplayName = "Given SaleItem When mapping to CreateSaleItemResult Then maps correctly")]
        public void Map_SaleItem_To_CreateSaleItemResult()
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
            var result = _mapper.Map<CreateSaleItemResult>(saleItem);

            // Then
            Assert.NotNull(result);
            Assert.Equal(saleItem.Id, result.Id);
            Assert.Equal(saleItem.SaleId, result.SaleId);
            Assert.Equal(saleItem.ProductId, result.ProductId);
            Assert.Equal(saleItem.Quantity, result.Quantity);
            Assert.Equal(saleItem.UnitPrice, result.UnitPrice);
        }

        /// <summary>
        /// Tests that CreateSaleCommand maps to Sale with all properties correctly.
        /// </summary>
        [Fact(DisplayName = "Given CreateSaleCommand with all properties When mapping to Sale Then maps correctly")]
        public void Map_CreateSaleCommand_To_Sale_AllProperties()
        {
            // Given
            var command = new CreateSaleCommand
            {
                CustomerId = 1,
                CompanyBranchId = 2,
                Items = new List<CreateSaleItemCommand>
                {
                    new CreateSaleItemCommand { ProductId = 1, Quantity = 2, UnitPrice = 10.0m }
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
        /// Tests that Sale maps to CreateSaleResult with all properties correctly.
        /// </summary>
        [Fact(DisplayName = "Given Sale with all properties When mapping to CreateSaleResult Then maps correctly")]
        public void Map_Sale_To_CreateSaleResult_AllProperties()
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
            var result = _mapper.Map<CreateSaleResult>(sale);

            // Then
            Assert.NotNull(result);
            Assert.Equal(sale.Id, result.Id);
            Assert.Equal(sale.SaleNumber, result.SaleNumber);
            Assert.Equal(sale.CreatedAt, result.CreatedAt);
            Assert.Equal(sale.CustomerId, result.CustomerId);
            Assert.Equal(sale.CompanyBranchId, result.CompanyBranchId);
        }

        /// <summary>
        /// Tests that CreateSaleItemCommand maps to SaleItem with all properties correctly.
        /// </summary>
        [Fact(DisplayName = "Given CreateSaleItemCommand with all properties When mapping to SaleItem Then maps correctly")]
        public void Map_CreateSaleItemCommand_To_SaleItem_AllProperties()
        {
            // Given
            var command = new CreateSaleItemCommand
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
        /// Tests that SaleItem maps to CreateSaleItemResult with all properties correctly.
        /// </summary>
        [Fact(DisplayName = "Given SaleItem with all properties When mapping to CreateSaleItemResult Then maps correctly")]
        public void Map_SaleItem_To_CreateSaleItemResult_AllProperties()
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
            var result = _mapper.Map<CreateSaleItemResult>(saleItem);

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
    /// Test profile for CreateSale mappings.
    /// </summary>
    public class TestCreateSaleProfile : Profile
    {
        public TestCreateSaleProfile()
        {
            CreateMap<CreateSaleCommand, Sale>()
                .ForMember(dest => dest.SaleNumber, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.TotalSale, opt => opt.Ignore())
                .ForMember(dest => dest.TotalSaleDiscount, opt => opt.Ignore())
                .ForMember(dest => dest.TotalSaleAfterDiscount, opt => opt.Ignore())
                .ForMember(dest => dest.IsSaleCancelled, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Sale, CreateSaleResult>()
                .ForMember(dest => dest.Items, opt => opt.Ignore());

            CreateMap<CreateSaleItemCommand, SaleItem>()
                .ForMember(dest => dest.SaleId, opt => opt.Ignore())
                .ForMember(dest => dest.IsSaleItemCancelled, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<SaleItem, CreateSaleItemResult>()
                .ForMember(dest => dest.TotaSalelItem, opt => opt.Ignore());
        }
    }
}
