using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

/// <summary>
/// Event triggered when a sale is modified.
/// </summary>
public class SaleModifiedEvent : INotification
{ 
    /// <summary>
  /// Gets the modified sale details.
  /// </summary>
    public Sale Sale { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SaleModifiedEvent"/> class.
    /// </summary>
    /// <param name="sale">The modified sale entity.</param>
    public SaleModifiedEvent(Sale sale)
    {
        Sale = sale;
    }
}