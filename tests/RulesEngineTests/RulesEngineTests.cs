using RulesEngine;
using RulesEngine.Models;
using RulesEngine.Rules;
using System;
using System.Collections.Generic;
using Xunit;

namespace RulesEngineTests
{
    public class RulesEngineTests
    {
        [Fact]
        public void Using_If_Statements()
        {
            var customer = new Customer
            {
                Id = "1",
                Name = "John Doe",
                StartDate = DateTime.UtcNow.AddYears(-1),
                SubscriptionType = SubscriptionType.Standard
            };

            float discount = 0;

            if (customer.SubscriptionType == SubscriptionType.Standard)
                discount = 5;

            if (customer.SubscriptionType == SubscriptionType.Premium)
                discount = 15;

            if (customer.StartDate <= DateTime.UtcNow.AddYears(-1))
                discount = 20;

            if (customer.StartDate <= DateTime.UtcNow.AddYears(-5))
                discount = 50;

            Assert.Equal(20, discount);
        }

        [Fact]
        public void Using_Rules_Engine()
        {
            var customer = new Customer
            {
                Id = "1",
                Name = "John Doe",
                StartDate = DateTime.UtcNow.AddYears(-5),
                SubscriptionType = SubscriptionType.Standard
            };

            var rules = new List<ICustomerDiscountRule>
            {
                new LongTimeCustomerDiscountRule(),
                new OneYearCustomerDiscountRule(),
                new PremiumSubscriptionDiscountRule(),
                new StandardSubscriptionDiscountRule()
            };
            var sut = new DiscountRuleEngine(rules);

            var discount = sut.CalculateDiscount(customer);

            Assert.Equal(DiscountType.LongTimeDiscount, discount.Type);
            Assert.Equal(50, discount.Amount);
        }
    }
}