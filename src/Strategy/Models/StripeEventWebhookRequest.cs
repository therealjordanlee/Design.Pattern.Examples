namespace Strategy.Models
{
    public class StripeEventWebhookRequest
    {
        public string Data { get; set; }
        public string Type { get; set; }
    }
}