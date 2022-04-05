using RulesEngine.Models;

namespace RulesEngine
{
    public interface IDiscountRuleEngine
    {
        Discount CalculateDiscount(Customer customer);
    }
}