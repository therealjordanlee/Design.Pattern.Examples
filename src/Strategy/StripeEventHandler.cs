using Strategy.EventHandlers;
using Strategy.Models;

namespace Strategy
{
    public class StripeEventHandler : IStripeEventHandler
    {
        private IEnumerable<IStripeEventProcessor> _eventHandlers;

        public StripeEventHandler(IEnumerable<IStripeEventProcessor> eventHandlers)
        {
            _eventHandlers = eventHandlers;
        }

        public async Task HandleAsync(StripeEventWebhookRequest request, CancellationToken ct = default)
        {
            var handler = _eventHandlers.FirstOrDefault(x => x.EventType == request.Type);

            if (handler != null)
                await handler.Handle(request);
        }
    }
}