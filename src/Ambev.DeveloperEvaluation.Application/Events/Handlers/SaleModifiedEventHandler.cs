using MediatR;

/// <summary>
/// Handles the SaleModifiedEvent by performing necessary actions when a sale is modified.
/// </summary>
public class SaleModifiedEventHandler : INotificationHandler<SaleModifiedEvent>
{
    /// <summary>
    /// Handles the SaleModifiedEvent.
    /// </summary>
    /// <param name="notification">The event notification containing the modified sale details.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Handle(SaleModifiedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
