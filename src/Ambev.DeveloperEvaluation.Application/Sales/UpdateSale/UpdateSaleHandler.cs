using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Handler for processing UpdateSaleCommand requests
    /// </summary>
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleItemRepository _saleItemRepository;
        private readonly IMapper _mapper;
        /// <summary>
        /// Initializes a new instance of UpdateSaleHandler
        /// </summary>
        /// <param name="saleRepository">The sale repository</param>
        /// <param name="saleItemRepository">The saleitem repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public UpdateSaleHandler(ISaleRepository saleRepository, ISaleItemRepository saleItemRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _saleItemRepository = saleItemRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the UpdateSaleCommand request
        /// </summary>
        /// <param name="command">The UpdateUser command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The update sale details</returns>
        public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var saleItems = _mapper.Map<List<SaleItem>>(command.Items);

            var sale = _mapper.Map<Sale>(command);
            sale.SetTotals(saleItems);

            var updatedSale = await _saleRepository.UpdateAsync(sale, cancellationToken);

            if (sale.IsSaleCancelled)
                saleItems.ForEach(item => item.Cancel());
            else
            {
                bool allItemsCancelled = saleItems.All(item => item.IsSaleItemCancelled);
                if (allItemsCancelled)
                    sale.Cancel();
            }

            saleItems.ForEach(item => item.SaleId = updatedSale.Id);

            var updatedSaleItems = await _saleItemRepository.UpdateManyAsync(saleItems, cancellationToken);

            var result = _mapper.Map<UpdateSaleResult>(updatedSale);
            result.Items = _mapper.Map<List<UpdateSaleItemResult>>(updatedSaleItems);

            return result;
        }
    }
}
