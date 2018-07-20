using System.Web;

namespace FizzBuzz
{
    /// <summary>
    /// StyleHelper to Display text in label and add styling
    /// </summary>
    public static class StyleHelper
    {
        /// <summary>
        /// To Display text in label and add styling to label
        /// </summary>
        /// <param name="element">element to be displayed as label text</param>
        /// <returns>Returns label with styling</returns>
        public static IHtmlString TextDisplay(string element)
        {
            element = element.Replace("fizz", "<label style=\'color:blue\'>fizz</label>");
            element = element.Replace("buzz", "<label style=\'color:Green\'>buzz</label>");
            element = element.Replace("wizz", "<label style=\'color:blue\'>wizz</label>");
            element = element.Replace("wuzz", "<label style=\'color:Green\'>wuzz</label>");

            return new HtmlString(element);
        }
    }
}