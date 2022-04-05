using RulesEngine.Models;

namespace RulesEngine.Rules
{
    public class StandardSubscriptionDiscountRule : ICustomerDiscountRule
    {
        public bool IsMatch(Customer customer)
        {
            return customer.SubscriptionType == SubscriptionType.Standard;
        }

        public Discount CalculateDiscount()
        {
            return new Discount
            {
                Type = DiscountType.StandardSubscriptionDiscount,
                Amount = 5
            };
        }
    }
}