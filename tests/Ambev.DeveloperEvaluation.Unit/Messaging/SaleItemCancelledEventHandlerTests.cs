using Moq;
using Xunit;
using Ambev.DeveloperEvaluation.Application.Common.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItemCancelledEventHandlerTests
{
    [Fact]
    public async Task Handle_Should_Call_Publish_Method()
    {
        // Arrange
        var mockRabbitMQService = new Mock<IMessagingService>();

        mockRabbitMQService
            .Setup(s => s.Publish(It.IsAny<string>(), It.IsAny<SaleItemCancelledEvent>()))
            .Returns(Task.CompletedTask);

        var handler = new SaleItemCancelledEventHandler(mockRabbitMQService.Object);
        var saleItemCancelledEvent = new SaleItemCancelledEvent(new SaleItem());

        // Act
        await handler.Handle(saleItemCancelledEvent, CancellationToken.None);

        // Assert
        mockRabbitMQService.Verify(
            s => s.Publish("sale_item_cancelled_queue", It.Is<SaleItemCancelledEvent>(e => e == saleItemCancelledEvent)),
            Times.Once
        );
    }
}
