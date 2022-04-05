using RulesEngine.Models;

namespace RulesEngine.Rules
{
    public interface ICustomerDiscountRule
    {
        public Discount CalculateDiscount();

        public bool IsMatch(Customer customer);
    }
}