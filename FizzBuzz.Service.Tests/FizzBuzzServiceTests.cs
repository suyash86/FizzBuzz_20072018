using System.Collections.Generic;
using FizzBuzz.Service.Interface;
using Moq;
using NUnit.Framework;

namespace FizzBuzz.Service.Tests
{
    [TestFixture]
    public class FizzBuzzServiceTests
    {
        private IFizzBuzzService _fizzBuzzService;
        Mock<IRule> _fizzRule;
        List<IRule> _rules;

        [SetUp]
        public void SetUp()
        {
            _fizzRule = new Mock<IRule>();
            _rules = new List<IRule> {_fizzRule.Object};
            _fizzBuzzService = new FizzBuzzService(_rules);
        }

        [TestCase(15)]
        public void ProcessRules_WhenValidInput_ShouldReturnList(int inputNumber)
        {
            _fizzRule.Setup(x => x.IsDivisible(inputNumber)).Returns(true);
            _fizzRule.Setup(x => x.DisplayValue()).Returns("fizz");
            var result = _fizzBuzzService.DisplayFizzBuzzData(inputNumber);
            Assert.AreEqual(result.Count, 15);
        }

        [TestCase(16)]
        public void ProcessRules_WhenInputNumberNotDivisibleBy3or5or15_ShouldReturnList(int inputNumber)
        {
            _fizzRule.Setup(x => x.IsDivisible(inputNumber)).Returns(null);
            _fizzRule.Setup(x => x.DisplayValue()).Returns(inputNumber.ToString());
            var result = _fizzBuzzService.DisplayFizzBuzzData(inputNumber);
            Assert.AreEqual(result.Count, 16);
        }
    }
}
