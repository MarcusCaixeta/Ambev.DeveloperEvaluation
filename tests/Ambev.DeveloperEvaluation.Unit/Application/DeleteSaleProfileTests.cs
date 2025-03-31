using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Xunit;
using System;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    /// <summary>
    /// Contains unit tests for the <see cref="DeleteSaleProfile"/> class.
    /// </summary>
    public class DeleteSaleProfileTests
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSaleProfileTests"/> class.
        /// Sets up the AutoMapper configuration and mapper instance.
        /// </summary>
        public DeleteSaleProfileTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<TestDeleteSaleProfile>());
            _mapper = config.CreateMapper();
        }

        /// <summary>
        /// Tests that the mapping configuration is valid.
        /// </summary>
        [Fact(DisplayName = "Given valid mapping configuration When validating Then configuration is valid")]
        public void MappingConfiguration_IsValid()
        {
            // Given
            var config = new MapperConfiguration(cfg => cfg.AddProfile<TestDeleteSaleProfile>());

            // When / Then
            config.AssertConfigurationIsValid();
        }

        /// <summary>
        /// Tests that DeleteSaleCommand maps to Sale correctly.
        /// </summary>
        [Fact(DisplayName = "Given DeleteSaleCommand When mapping to Sale Then maps correctly")]
        public void Map_DeleteSaleCommand_To_Sale()
        {
            // Given
            var command = new DeleteSaleCommand(Guid.NewGuid());

            // When
            var sale = _mapper.Map<Sale>(command);

            // Then
            Assert.NotNull(sale);
            Assert.Equal(command.Id, sale.Id);
        }        
    }

    /// <summary>
    /// Test profile for DeleteSale mappings.
    /// </summary>
    public class TestDeleteSaleProfile : Profile
    {
        public TestDeleteSaleProfile()
        {
            CreateMap<DeleteSaleCommand, Sale>()
                .ForMember(dest => dest.SaleNumber, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.TotalSale, opt => opt.Ignore())
                .ForMember(dest => dest.TotalSaleDiscount, opt => opt.Ignore())
                .ForMember(dest => dest.TotalSaleAfterDiscount, opt => opt.Ignore())
                .ForMember(dest => dest.IsSaleCancelled, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CustomerId, opt => opt.Ignore())
                .ForMember(dest => dest.CompanyBranchId, opt => opt.Ignore());
        }
    }
}

