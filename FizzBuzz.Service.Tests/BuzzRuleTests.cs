using System;
using NUnit.Framework;

namespace FizzBuzz.Service.Tests
{
    [TestFixture]
    public class BuzzRuleTests
    {
        private BuzzRule _buzzRule;

        [SetUp]
        public void SetUp()
        {
            _buzzRule = new BuzzRule("");
        }

        [Test]
        public void IsDivisible_WhenNumberMultipleOf5_ReturnsTrue()
        {
            Assert.IsTrue(_buzzRule.IsDivisible(5));
        }

        [Test]
        public void IsDivisible_WhenNumberNotMultipleOf5_ReturnsFalse()
        {
            Assert.IsFalse(_buzzRule.IsDivisible(4));
        }

        [TestCase("2018/07/12")]
        public void DisplayValue_WhenNotWednesday_Returnsbuzz(DateTime dateTime)
        {
            _buzzRule=new BuzzRule(dateTime.DayOfWeek.ToString());
            var result = _buzzRule.DisplayValue();
            Assert.AreEqual(result, "buzz");
        }

        [TestCase("2018/07/11")]
        public void DisplayValue_WhenWednesday_Returnswuzz(DateTime dateTime)
        {
            _buzzRule = new BuzzRule(dateTime.DayOfWeek.ToString());
            var result = _buzzRule.DisplayValue();
            Assert.AreEqual(result, "wuzz");
        }
    }
}
