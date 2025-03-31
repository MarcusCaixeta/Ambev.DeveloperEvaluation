using MediatR;

/// <summary>
/// Handles the SaleCreatedEvent by performing necessary actions when a sale is created.
/// </summary>
public class SaleCreatedEventHandler : INotificationHandler<SaleCreatedEvent>
{
    /// <summary>
    /// Handles the SaleCreatedEvent.
    /// </summary>
    /// <param name="notification">The SaleCreatedEvent notification.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Handle(SaleCreatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
