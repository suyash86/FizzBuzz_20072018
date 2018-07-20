using System.ComponentModel.DataAnnotations;
using PagedList;

namespace FizzBuzz.Models
{
    /// <summary>
    /// Fizz Buzz Model
    /// </summary>
    public class FizzBuzzModel
    {
        /// <summary>
        /// Gets or sets Input Number
        /// </summary>
        [Required(ErrorMessage = "Number is Required")]
        [Range(1, 1000, ErrorMessage = "Please Enter Number between 1 and 1000")]
        [Display(Name = "Enter Number")]
        public int EnterNumber { get; set; }

        /// <summary>
        /// Gets or sets list of Values
        /// </summary>
        public IPagedList<string> FizzBuzzValues { get; set; }
    }
}