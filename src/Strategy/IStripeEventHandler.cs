using Strategy.Models;

namespace Strategy
{
    public interface IStripeEventHandler
    {
        Task HandleAsync(StripeEventWebhookRequest request, CancellationToken ct = default);
    }
}