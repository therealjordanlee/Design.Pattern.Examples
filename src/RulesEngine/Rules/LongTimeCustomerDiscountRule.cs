using RulesEngine.Models;

namespace RulesEngine.Rules
{
    public class LongTimeCustomerDiscountRule : ICustomerDiscountRule
    {
        public bool IsMatch(Customer customer)
        {
            return customer.StartDate <= DateTime.UtcNow.AddYears(-5);
        }

        public Discount CalculateDiscount()
        {
            return new Discount
            {
                Type = DiscountType.LongTimeDiscount,
                Amount = 50
            };
        }
    }
}