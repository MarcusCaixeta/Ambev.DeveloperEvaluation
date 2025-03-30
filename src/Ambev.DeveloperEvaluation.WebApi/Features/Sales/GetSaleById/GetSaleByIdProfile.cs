using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSaleById;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleById
{
    /// <summary>
    /// Profile for mapping between Application and API GetSaleById responses
    /// </summary>
    public class GetSaleByIdProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetSaleById feature
        /// </summary>
        public GetSaleByIdProfile()
        {
            CreateMap<Guid, GetSaleByIdCommand>()
            .ConstructUsing(id => new GetSaleByIdCommand(id));

            CreateMap<GetSaleByIdResult, GetSaleByIdResponse>();
            CreateMap<GetSaleByIdItemResult, GetSaleByIdItemResponse>();
        }
    }
}
