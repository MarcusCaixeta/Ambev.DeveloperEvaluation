using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

/// <summary>
/// Event triggered when a sale is cancelled.
/// </summary>
public class SaleCancelledEvent : INotification
{
    /// <summary>
    /// Gets the sale that was cancelled.
    /// </summary>
    public Sale Sale { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SaleCancelledEvent"/> class.
    /// </summary>
    /// <param name="sale">The sale that was cancelled.</param>
    public SaleCancelledEvent(Sale sale)
    {
        Sale = sale;
    }
}
