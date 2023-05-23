using Company.Project.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            HomeController obj = new HomeController(null);
            ViewResult ans = obj.Index() as ViewResult;
            Assert.AreEqual("Index", ans);

        }
    }
}
