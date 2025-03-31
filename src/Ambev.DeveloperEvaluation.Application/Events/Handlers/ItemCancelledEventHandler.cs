using Ambev.DeveloperEvaluation.Application.Common.Interfaces;
using MediatR;

/// <summary>
/// Handles the event when a sale item is cancelled.
/// </summary>
public class SaleItemCancelledEventHandler : INotificationHandler<SaleItemCancelledEvent>
{
    private readonly IMessagingService _messagingService;

    /// <summary>
    /// Initializes a new instance of the <see cref="SaleItemCancelledEventHandler"/> class.
    /// </summary>
    /// <param name="messagingService">The messaging service to publish events.</param>
    public SaleItemCancelledEventHandler(IMessagingService messagingService)
    {
        _messagingService = messagingService;
    }

    /// <summary>
    /// Handles the sale item cancelled event by publishing it to the messaging service.
    /// </summary>
    /// <param name="notification">The sale item cancelled event notification.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Handle(SaleItemCancelledEvent notification, CancellationToken cancellationToken)
    {
        return _messagingService.Publish("sale_item_cancelled_queue", notification);
    }
}
