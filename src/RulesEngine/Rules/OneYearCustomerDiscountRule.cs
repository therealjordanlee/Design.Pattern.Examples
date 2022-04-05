using RulesEngine.Models;

namespace RulesEngine.Rules
{
    public class OneYearCustomerDiscountRule : ICustomerDiscountRule
    {
        public bool IsMatch(Customer customer)
        {
            return customer.StartDate <= DateTime.UtcNow.AddYears(-1);
        }

        public Discount CalculateDiscount()
        {
            return new Discount
            {
                Type = DiscountType.OneYearDiscount,
                Amount = 20
            };
        }
    }
}