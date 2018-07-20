using System.Collections.Generic;
using System.Linq;
using System.Text;
using FizzBuzz.Service.Interface;

namespace FizzBuzz.Service
{
    /// <summary>
    /// Fizz Buzz service class
    /// </summary>
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IEnumerable<IRule> _fizzBuzzRules;

        /// <summary>
        /// Initializes a new instance of the FizzBuzzService class
        /// </summary>
        /// <param name="fizzBuzzRules">IEnumerable of type IRule</param>
        public FizzBuzzService(IEnumerable<IRule> fizzBuzzRules)
        {
            _fizzBuzzRules = fizzBuzzRules;
        }

        /// <summary>
        /// Method to iterate w.r.t input number
        /// </summary>
        /// <param name="inputNumber"></param>
        /// <returns></returns>
        public IList<string> DisplayFizzBuzzData(int inputNumber)
        {
            IList<string> resultList = new List<string>();
            for (int number = 1; number <= inputNumber; number++)
            {
                var lstofApplicableRules = _fizzBuzzRules.Where(p => p.IsDivisible(number)).ToList();
                BuildFizzbuzzData(lstofApplicableRules, resultList, number);
            }
            return resultList;
        }

        /// <summary>
        /// Method to prepare fizz-buzz data list
        /// </summary>
        /// <param name="lstofApplicableRules"></param>
        /// <param name="resultList"></param>
        /// <param name="number"></param>
        private static void BuildFizzbuzzData(List<IRule> lstofApplicableRules, IList<string> resultList, int number)
        {
            if (lstofApplicableRules.Any())
            {
                switch (lstofApplicableRules.Count())
                {
                    case 1:
                        resultList.Add(lstofApplicableRules.FirstOrDefault()?.DisplayValue());
                        break;
                    default:
                        if (lstofApplicableRules.Count() > 1)
                        {
                            var sb = new StringBuilder();
                            foreach (var rule in lstofApplicableRules)
                            {
                                sb.Append(rule.DisplayValue() + " ");
                            }

                            resultList.Add(sb.ToString());
                        }

                        break;
                }
            }
            else
            {
                resultList.Add(number.ToString());
            }
        }
    }
}
