using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="UpdateSaleHandler"/> class.
/// </summary>
public class UpdateSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly UpdateSaleHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateSaleHandlerTests"/> class.
    /// Sets up the test dependencies and creates fake data generators.
    /// </summary>
    public UpdateSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _mapper = Substitute.For<IMapper>();
        var saleItemRepository = Substitute.For<ISaleItemRepository>();
        _handler = new UpdateSaleHandler(_saleRepository, saleItemRepository, _mapper);
    }  

    /// <summary>
    /// Tests that an invalid sale update request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid sale data When updating sale Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new UpdateSaleCommand(); // Empty command will fail validation

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    

    /// <summary>
    /// Tests that a null sale items list throws an ArgumentNullException.
    /// </summary>
    [Fact(DisplayName = "Given null sale items list When setting totals Then throws ArgumentNullException")]
    public void SetTotals_NullSaleItems_ThrowsArgumentNullException()
    {
        // Given
        var sale = new Sale();

        // When
        Action act = () => sale.SetTotals(null);

        // Then
        act.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'source')");
    }
}
