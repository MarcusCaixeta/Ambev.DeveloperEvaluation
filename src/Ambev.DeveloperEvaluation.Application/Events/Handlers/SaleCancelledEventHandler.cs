using MediatR;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Handles the SaleCancelledEvent by performing necessary actions when a sale is cancelled.
/// </summary>
public class SaleCancelledEventHandler : INotificationHandler<SaleCancelledEvent>
{
    /// <summary>
    /// Handles the SaleCancelledEvent.
    /// </summary>
    /// <param name="notification">The SaleCancelledEvent notification.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Handle(SaleCancelledEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
