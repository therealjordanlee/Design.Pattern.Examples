using RulesEngine.Models;

namespace RulesEngine.Rules
{
    public class PremiumSubscriptionDiscountRule : ICustomerDiscountRule
    {
        public bool IsMatch(Customer customer)
        {
            return customer.SubscriptionType == SubscriptionType.Premium;
        }

        public Discount CalculateDiscount()
        {
            return new Discount
            {
                Type = DiscountType.PremiumSubscriptionDiscount,
                Amount = 15,
            };
        }
    }
}