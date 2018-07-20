using System;
using FizzBuzz.Service.Interface;

namespace FizzBuzz.Service
{
    /// <summary>
    /// Rule to display buzz/wuzz
    /// </summary>
    public class BuzzRule : IRule
    {
        private readonly bool _isTextChangeApplicable;

        /// <summary>
        /// Initializes a new instance of the BuzzRule class
        /// </summary>
        /// <param name="day">DayOfWeek</param>
        public BuzzRule(string day)
        {
            _isTextChangeApplicable = DayOfWeek.Wednesday.ToString() == day;
            //_isTextChangeApplicable = Convert.ToString(DateTime.Today.DayOfWeek) == day;
        }

        /// <summary>
        /// To check number is divisible by 5
        /// </summary>
        /// <param name="number"></param>
        /// <returns>bool</returns>
        public bool IsDivisible(int number)
        {
            return number % 5 == 0;
        }

        /// <summary>
        /// To display buzz/wuzz
        /// </summary>
        /// <returns></returns>
        public string DisplayValue()
        {
            return _isTextChangeApplicable ? "wuzz" : "buzz";
        }
    }
}
