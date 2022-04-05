using RulesEngine.Models;
using RulesEngine.Rules;

namespace RulesEngine
{
    public class DiscountRuleEngine : IDiscountRuleEngine
    {
        public IEnumerable<ICustomerDiscountRule> _rules;

        public DiscountRuleEngine(IEnumerable<ICustomerDiscountRule> rules)
        {
            _rules = rules;
        }

        public Discount CalculateDiscount(Customer customer)
        {
            var discount = new Discount
            {
                Type = DiscountType.None,
                Amount = 0
            };

            _rules.ToList().ForEach(rule =>
            {
                if (rule.IsMatch(customer))
                {
                    var calculatedDiscount = rule.CalculateDiscount();
                    if (calculatedDiscount.Amount > discount.Amount)
                        discount = calculatedDiscount;
                }
            });

            return discount;
        }
    }
}