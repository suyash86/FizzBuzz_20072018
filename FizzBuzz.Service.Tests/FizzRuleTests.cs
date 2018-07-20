using System;
using NUnit.Framework;

namespace FizzBuzz.Service.Tests
{
    [TestFixture]
    public class FizzRuleTests
    {
        private FizzRule _fizzRule;

        [SetUp]
        public void SetUp()
        {
            _fizzRule = new FizzRule("");
        }

        [Test]
        public void IsDivisible_WhenNumberMultipleOf3_ReturnsTrue()
        {
            Assert.IsTrue(_fizzRule.IsDivisible(3));
        }

        [Test]
        public void IsDivisible_WhenNumberNotMultipleOf3_ReturnsFalse()
        {
            Assert.IsFalse(_fizzRule.IsDivisible(4));
        }

        [TestCase("2018/07/12")]
        public void DisplayValue_WhenNotWednesday_Returnsfizz(DateTime dateTime)
        {
            _fizzRule = new FizzRule(dateTime.DayOfWeek.ToString());
            var result = _fizzRule.DisplayValue();
            Assert.AreEqual(result, "fizz");
        }

        [TestCase("2018/07/11")]
        public void DisplayValue_WhenWednesday_Returnswizz(DateTime dateTime)
        {
            _fizzRule = new FizzRule(dateTime.DayOfWeek.ToString());
            var result = _fizzRule.DisplayValue();
            Assert.AreEqual(result, "wizz");
        }
    }
}
