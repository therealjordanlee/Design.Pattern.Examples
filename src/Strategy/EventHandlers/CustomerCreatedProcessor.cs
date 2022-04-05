using Strategy.Models;

namespace Strategy.EventHandlers
{
    public class CustomerCreatedProcessor : IStripeEventProcessor
    {
        public string EventType => "customer.created";

        public async Task Handle(StripeEventWebhookRequest request)
        {
            Console.WriteLine("Handling customer created event...");
        }
    }
}