using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

/// <summary>
/// Event triggered when a sale item is cancelled.
/// </summary>
public class SaleItemCancelledEvent : INotification
{
    /// <summary>
    /// Gets the cancelled sale item.
    /// </summary>
    public SaleItem SaleItem { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SaleItemCancelledEvent"/> class.
    /// </summary>
    /// <param name="saleItem">The cancelled sale entity.</param>
    public SaleItemCancelledEvent(SaleItem saleItem)
    {
        SaleItem = saleItem;
    }
}
