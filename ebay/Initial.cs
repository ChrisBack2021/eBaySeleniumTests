using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Ebay
{
    [TestClass]
    public class Initial
    {
        public IWebDriver driver;
        string url = "https://www.ebay.com.au/";


        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Thread.Sleep(2000);
            driver.Quit();
        }

    }
}
