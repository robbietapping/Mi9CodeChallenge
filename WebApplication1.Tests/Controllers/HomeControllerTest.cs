using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobertTapping.Mi9CC;
using RobertTapping.Mi9CC.Controllers;

namespace RobertTapping.Mi9CC.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Robert Tapping Mi9Code Challenge", result.ViewBag.Title);
        }
    }
}
