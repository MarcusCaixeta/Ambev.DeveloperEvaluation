using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="UpdateSaleCommand"/> class.
/// </summary>
public class UpdateSaleCommandTests
{
    /// <summary>
    /// Tests that a valid command data is validated successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid command data When validating Then returns valid result")]
    public void Validate_ValidCommand_ReturnsValidResult()
    {
        // Given
        var command = UpdateSaleHandlerTestData.GenerateValidCommand();

        // When
        var validationResult = command.Validate();

        // Then
        validationResult.IsValid.Should().BeTrue();
    }

    /// <summary>
    /// Tests that an invalid command data fails validation.
    /// </summary>
    [Fact(DisplayName = "Given invalid command data When validating Then returns invalid result")]
    public void Validate_InvalidCommand_ReturnsInvalidResult()
    {
        // Given
        var command = UpdateSaleHandlerTestData.GenerateInvalidCommand();

        // When
        var validationResult = command.Validate();

        // Then
        validationResult.IsValid.Should().BeFalse();
    }
}
