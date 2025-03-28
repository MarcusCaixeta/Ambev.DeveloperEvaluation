using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleById
{
    public class GetSaleByIdProfile : Profile
    {
        public GetSaleByIdProfile() { 
            CreateMap<Guid,Application.Sales.GetSaleById.GetSaleByIdCommand>()
                .ConstructUsing(id => new Application.Sales.GetSaleById.GetSaleByIdCommand(id));
        }
    }
}
