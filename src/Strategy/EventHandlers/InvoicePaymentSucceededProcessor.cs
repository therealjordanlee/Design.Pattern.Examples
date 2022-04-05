using Strategy.Models;

namespace Strategy.EventHandlers
{
    public class InvoicePaymentSucceededProcessor : IStripeEventProcessor
    {
        public string EventType => "invoice.payment_succeeded";

        public async Task Handle(StripeEventWebhookRequest request)
        {
            Console.WriteLine("Handling payment succeeded event...");
        }
    }
}