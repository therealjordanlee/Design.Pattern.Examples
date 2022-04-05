using Strategy.Models;

namespace Strategy.EventHandlers
{
    public interface IStripeEventProcessor
    {
        string EventType { get; }

        Task Handle(StripeEventWebhookRequest request);
    }
}