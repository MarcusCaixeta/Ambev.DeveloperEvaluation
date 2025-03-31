using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById
{
    /// <summary>
    /// Handler for processing GetSaleByIdCommand requests
    /// </summary>
    public class GetSaleByIdHandler : IRequestHandler<GetSaleByIdCommand, GetSaleByIdResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleItemRepository _saleItemRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetSaleByIdHandler
        /// </summary>
        /// <param name="saleRepository">The sale repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public GetSaleByIdHandler(
            ISaleRepository saleRepository,
            ISaleItemRepository saleItemRepository,
            IMapper mapper)
        {
            _saleRepository = saleRepository;
            _saleItemRepository = saleItemRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Handles the GetSaleByIdCommand request
        /// </summary>
        /// <param name="request">The GetSaleById command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale details if found</returns>
        public async Task<GetSaleByIdResult> Handle(GetSaleByIdCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetSaleByIdValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);
            var saleItem = await _saleItemRepository.GetBySaleByIdAsync(request.Id, cancellationToken);
            if (sale == null || saleItem == null)
                throw new KeyNotFoundException($"Sale with ID {request.Id} not found");

            var result = _mapper.Map<GetSaleByIdResult>(sale);
             result.Items = _mapper.Map<List<GetSaleByIdItemResult>>(saleItem);

            return result;
        }
    }
}
