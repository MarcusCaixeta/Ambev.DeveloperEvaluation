using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

/// <summary>
/// Event triggered when a new sale is created.
/// </summary>
public class SaleCreatedEvent : INotification
{
    /// <summary>
    /// Gets the sale associated with the event.
    /// </summary>
    public Sale Sale { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SaleCreatedEvent"/> class.
    /// </summary>
    /// <param name="sale">The sale associated with the event.</param>
    public SaleCreatedEvent(Sale sale)
    {
        Sale = sale;
    }
}
