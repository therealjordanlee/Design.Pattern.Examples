namespace RulesEngine.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
    }
}