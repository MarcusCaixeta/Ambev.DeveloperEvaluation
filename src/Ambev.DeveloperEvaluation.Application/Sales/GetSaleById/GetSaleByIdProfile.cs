using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById
{
    /// <summary>
    /// Profile for mapping between Sale entity and GetSaleByIdResult
    /// </summary>
    public class GetSaleByIdProfile : Profile
    {/// <summary>
     /// Initializes the mappings for GetSaleById operation
     /// </summary>
        public GetSaleByIdProfile()
        {
            CreateMap<GetSaleByIdCommand, Sale>();
            CreateMap<Sale, GetSaleByIdResult>();

            CreateMap<SaleItem, GetSaleByIdItemResult>();
        }
    }
}
