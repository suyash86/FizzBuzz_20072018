using System.Collections.Generic;
using FizzBuzz.Models;
using System.Web.Mvc;
using FizzBuzz.Service.Interface;
using PagedList;

namespace FizzBuzz.Controllers
{
    /// <summary>
    /// Fizz Buzz Controller
    /// </summary>
    public class FizzBuzzController : Controller
    {
        /// <summary>
        /// Fizz Buzz Service
        /// </summary>
        private readonly IFizzBuzzService _fizzBuzzService;

        /// <summary>
        /// Max number of elements displayed in page
        /// </summary>
        private int pageSize = 20;

        /// <summary>
        /// Initializes a new instance of the FizzBuzzController class
        /// </summary>
        /// <param name="fizzBuzzService">fizzBuzzService object of type IFizzBuzzService</param>
        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        /// <summary>
        /// Returns the Display View
        /// </summary>
        /// <param name="page"> page parameter of type Integer</param>
        /// <returns> Returns Display view </returns>
        [HttpGet]
        public ActionResult Display(int page = 1)
        {
            var model = new FizzBuzzModel();
            if (this.HttpContext.Session["resultList"] != null)
            {
                var loadList = this.HttpContext.Session["resultList"] as List<string>;
                model.FizzBuzzValues = loadList.ToPagedList(page, this.pageSize);
                if (loadList != null) model.EnterNumber = loadList.Count;
            }

            return this.View("Display", model);
        }

        /// <summary>
        /// Set the model object
        /// </summary>
        /// <param name="model">model object of type FizzBuzzModel </param>
        /// <param name="page"> page of type Integer </param>
        /// <returns> Returns Display View</returns>
        [HttpPost]
        public ActionResult Display(FizzBuzzModel model, int? page)
        {
            int pageNumber = page ?? 1;
            this.ViewBag.Page = pageNumber;

            if (ModelState.IsValid)
            {
                var resultList = this._fizzBuzzService.DisplayFizzBuzzData(model.EnterNumber);

                if (resultList != null)
                {
                    this.HttpContext.Session["resultList"] = resultList;
                    model.FizzBuzzValues = resultList.ToPagedList(pageNumber, this.pageSize);
                }
            }
            return this.View("Display", model);
        }
    }
}