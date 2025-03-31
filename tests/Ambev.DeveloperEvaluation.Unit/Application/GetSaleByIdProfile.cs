using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.GetSaleById;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Xunit;
using System;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    /// <summary>
    /// Contains unit tests for the <see cref="GetSaleByIdProfile"/> class.
    /// </summary>
    public class GetSaleByIdProfileTests
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSaleByIdProfileTests"/> class.
        /// Sets up the AutoMapper configuration and mapper instance.
        /// </summary>
        public GetSaleByIdProfileTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<TestGetSaleByIdProfile>());
            _mapper = config.CreateMapper();
        }

        /// <summary>
        /// Tests that the mapping configuration is valid.
        /// </summary>
        [Fact(DisplayName = "Given valid mapping configuration When validating Then configuration is valid")]
        public void MappingConfiguration_IsValid()
        {
            // Given
            var config = new MapperConfiguration(cfg => cfg.AddProfile<TestGetSaleByIdProfile>());

            // When / Then
            config.AssertConfigurationIsValid();
        }

        /// <summary>
        /// Tests that GetSaleByIdCommand maps to Sale correctly.
        /// </summary>
        [Fact(DisplayName = "Given GetSaleByIdCommand When mapping to Sale Then maps correctly")]
        public void Map_GetSaleByIdCommand_To_Sale()
        {
            // Given
            var command = new GetSaleByIdCommand(Guid.NewGuid());

            // When
            var sale = _mapper.Map<Sale>(command);

            // Then
            Assert.NotNull(sale);
            Assert.Equal(command.Id, sale.Id);
        }

        /// <summary>
        /// Tests that Sale maps to GetSaleByIdResult correctly.
        /// </summary>
        [Fact(DisplayName = "Given Sale When mapping to GetSaleByIdResult Then maps correctly")]
        public void Map_Sale_To_GetSaleByIdResult()
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
            var result = _mapper.Map<GetSaleByIdResult>(sale);

            // Then
            Assert.NotNull(result);
            Assert.Equal(sale.Id, result.Id);
            Assert.Equal(sale.SaleNumber, result.SaleNumber);
            Assert.Equal(sale.CreatedAt, result.CreatedAt);
            Assert.Equal(sale.CustomerId, result.CustomerId);
            Assert.Equal(sale.CompanyBranchId, result.CompanyBranchId);
        }
    }

    /// <summary>
    /// Test profile for GetSaleById mappings.
    /// </summary>
    public class TestGetSaleByIdProfile : Profile
    {
        public TestGetSaleByIdProfile()
        {
            CreateMap<GetSaleByIdCommand, Sale>()
                .ForMember(dest => dest.SaleNumber, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.TotalSale, opt => opt.Ignore())
                .ForMember(dest => dest.TotalSaleDiscount, opt => opt.Ignore())
                .ForMember(dest => dest.TotalSaleAfterDiscount, opt => opt.Ignore())
                .ForMember(dest => dest.IsSaleCancelled, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CustomerId, opt => opt.Ignore())
                .ForMember(dest => dest.CompanyBranchId, opt => opt.Ignore());

            CreateMap<Sale, GetSaleByIdResult>()
                .ForMember(dest => dest.Items, opt => opt.Ignore());
        }
    }
}

