using Strategy.Models;

namespace Strategy.EventHandlers
{
    public class InvoicePaymentFailedProcessor : IStripeEventProcessor
    {
        public string EventType => "invoice.payment_failed";

        public async Task Handle(StripeEventWebhookRequest request)
        {
            Console.WriteLine("Handling payment failed event...");
        }
    }
}