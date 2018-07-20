using System;

namespace FizzBuzz.Service.Interface
{
    /// <summary>
    /// Interface IRule
    /// </summary>
    public interface IRule
    {
        /// <summary>
        /// Is divisible by rule
        /// </summary>
        /// <param name="number"></param>
        /// <returns>return true if divisible by defined rule</returns>
        bool IsDivisible(int number);

        /// <summary>
        /// Display Values
        /// </summary>
        /// <returns>string message</returns>
        string DisplayValue();
    }
}