using Ambev.DeveloperEvaluation.Application.Sales.GetSaleById;
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
            CreateMap<Sale, GetSaleByIdResult>();
        }
    }
}
