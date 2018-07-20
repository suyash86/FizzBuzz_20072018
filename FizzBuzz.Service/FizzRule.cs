using System;
using FizzBuzz.Service.Interface;

namespace FizzBuzz.Service
{
    /// <summary>
    /// Rule to display fizz/wizz
    /// </summary>
    public class FizzRule: IRule
    {
        private readonly bool _isTextChangeApplicable;

        /// <summary>
        /// Initializes a new instance of the FizzBuzzService class
        /// </summary>
        /// <param name="day">DayOfWeek</param>
        public FizzRule(string day)
        {
            _isTextChangeApplicable = DayOfWeek.Wednesday.ToString() == day;
            //_isTextChangeApplicable = Convert.ToString(DateTime.Today.DayOfWeek) == day;
        }

        /// <summary>
        /// To check number is divisible by 3
        /// </summary>
        /// <param name="number"></param>
        /// <returns>bool</returns>
        public bool IsDivisible(int number)
        {
            return number % 3 == 0;
        }

        /// <summary>
        /// To display fizz/wizz
        /// </summary>
        /// <returns></returns>
        public string DisplayValue()
        {
            return _isTextChangeApplicable ? "wizz" : "fizz";
        }
    }
}
