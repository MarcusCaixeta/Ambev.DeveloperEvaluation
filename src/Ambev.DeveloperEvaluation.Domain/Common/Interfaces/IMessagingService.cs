
namespace Ambev.DeveloperEvaluation.Application.Common.Interfaces
{
    /// <summary>
    /// Interface for MessagingService
    /// </summary>
    public interface IMessagingService
    {
        /// <summary>
        /// Publishes a message to a specified queue
        /// </summary>
        /// <param name="queueName">The name of the queue</param>
        /// <param name="message">The message to be sent</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task Publish(string queueName, object message);
    }
}
