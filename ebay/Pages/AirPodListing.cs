using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ebay.Pages
{
    public class AirPodListing
    {
        private IWebDriver driver;

        public AirPodListing(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public ReadOnlyCollection<IWebElement> AirPodList => driver.FindElements(By.XPath("//span[@role='heading']"));

        public IWebElement Cats => driver.FindElement(By.Id("gh-cat"));

        public bool FilterAirpods()
        {
            bool airpodText = false;
            foreach (IWebElement airpod in AirPodList)
            {
                Console.WriteLine(airpod.Text);
                if (airpod.Text.Contains("3rd Generation"))
                {
                    airpodText = true;
                    airpod.Click();
                    return airpodText;
                }
            }
            return airpodText;
        }
        public void NewCategory()
        {
            SelectElement cat = new SelectElement(Cats);
            cat.SelectByIndex(2);

        }
    }
}

