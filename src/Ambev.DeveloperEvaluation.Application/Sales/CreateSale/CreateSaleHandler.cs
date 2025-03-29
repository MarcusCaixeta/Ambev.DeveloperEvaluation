using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Handler for processing CreateSaleCommand requests
    /// </summary>
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleItemRepository _saleItemRepository;
        private readonly IMapper _mapper;
        /// <summary>
        /// Initializes a new instance of CreateSaleHandler
        /// </summary>
        /// <param name="saleRepository">The sale repository</param>
        /// <param name="saleItemRepository">The saleitem repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CreateSaleHandler(ISaleRepository saleRepository, ISaleItemRepository saleItemRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _saleItemRepository = saleItemRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Handles the CreateSaleCommand request
        /// </summary>
        /// <param name="command">The CreateUser command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale details</returns>
        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var saleItems = _mapper.Map<List<SaleItem>>(command.Items);

            var sale = _mapper.Map<Sale>(command);
            sale.SetTotals(saleItems);

            var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);

            saleItems.ForEach(item => item.SaleId = createdSale.Id);
            var createdSaleItems = await _saleItemRepository.CreateManyAsync(saleItems, cancellationToken);

            var result = _mapper.Map<CreateSaleResult>(createdSale);
            result.Items = _mapper.Map<List<CreateSaleItemResult>>(createdSaleItems);

            return result;

        }
    }
}
