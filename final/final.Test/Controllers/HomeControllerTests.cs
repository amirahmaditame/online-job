using Microsoft.VisualStudio.TestTools.UnitTesting;
using final.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace final.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        //[TestMethod()]
        //public void SliderTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void showcategoryTest()
        //{
        //    Assert.Fail();
        //}
    }
}