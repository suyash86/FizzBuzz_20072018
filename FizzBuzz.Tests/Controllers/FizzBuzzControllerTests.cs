using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FizzBuzz.Controllers;
using FizzBuzz.Models;
using FizzBuzz.Service.Interface;
using Moq;
using NUnit.Framework;

namespace FizzBuzz.Tests.Controllers
{
    [TestFixture]
    public class FizzBuzzControllerTests
    {
        private FizzBuzzController _controller;
        public Mock<IFizzBuzzService> FizzbuzzService;
        private Mock<HttpContextBase> _context;
        private List<string> _resultList;

        [SetUp]
        public void SetUp()
        {
            FizzbuzzService = new Mock<IFizzBuzzService>();
            _controller = new FizzBuzzController(FizzbuzzService.Object);

            _context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            _context.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(_context.Object, new RouteData());
            _controller.ControllerContext = new ControllerContext(requestContext, _controller);
        }

        [TearDown]
        public void TearDown()
        {
            FizzbuzzService = null;
            _controller = null;
        }

        [Test]
        public void IndexGet_WhenSessionIsNull_ShouldReturnView()
        {
            ViewResult returnView = _controller.Display() as ViewResult;
            Assert.IsNotNull(returnView);
            Assert.AreEqual(returnView.ViewName, "Display");
        }

        [Test]
        public void IndexGet_WhenSessionIsNotNull_ShouldSetModel()
        {
            _resultList = new List<String> {"TestData"};
            _context.Setup(x => x.Session["resultList"]).Returns(_resultList);

            ViewResult returnView = _controller.Display() as ViewResult;
            Assert.IsNotNull(returnView);
            var fizzBuzzModel = (FizzBuzzModel)returnView.Model;
            Assert.IsNotNull(fizzBuzzModel);
            Assert.AreEqual(fizzBuzzModel.FizzBuzzValues[0], "TestData");
        }

        [Test]
        public void IndexPost_WhenresultListIsNull_ShouldReturnViewResult()
        {
            ViewResult returnView = _controller.Display(new FizzBuzzModel { EnterNumber = 17 }, 1) as ViewResult;
            Assert.IsNotNull(returnView);
            var fizzBuzzModel = (FizzBuzzModel)returnView.Model;
            Assert.IsNotNull(fizzBuzzModel);
            Assert.IsNull(fizzBuzzModel.FizzBuzzValues);
            Assert.AreEqual(returnView.ViewName, "Display");
        }

        [Test]
        public void IndexPost_WhenresultListIsNotNull_ShouldSetModel()
        {
            _resultList = new List<String> {"TestData"};
            FizzbuzzService.Setup(p => p.DisplayFizzBuzzData(17)).Returns(_resultList);

            ViewResult returnView = _controller.Display(new FizzBuzzModel { EnterNumber = 17 }, 1) as ViewResult;
            Assert.IsNotNull(returnView);
            var fizzBuzzModel = (FizzBuzzModel)returnView.Model;
            Assert.IsNotNull(fizzBuzzModel);
            Assert.AreEqual(fizzBuzzModel.FizzBuzzValues[0], "TestData");
        }
    }
}
