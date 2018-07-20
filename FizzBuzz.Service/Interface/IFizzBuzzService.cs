using System.Collections.Generic;

namespace FizzBuzz.Service.Interface
{
    /// <summary>
    /// Interface IFizzBuzzService
    /// </summary>
    public interface IFizzBuzzService
    {
        /// <summary>
        /// To display fizz buzz data
        /// </summary>
        /// <param name="inputNumber"></param>
        /// <returns>IList of type string</returns>
        IList<string> DisplayFizzBuzzData(int inputNumber);
    }
}
