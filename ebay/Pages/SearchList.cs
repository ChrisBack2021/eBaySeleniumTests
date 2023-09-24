using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ebay.Pages
{
    public class SearchList
    {
        private IWebDriver driver;

        public SearchList(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ReadOnlyCollection<IWebElement> Listings => driver.FindElements(By.CssSelector(".s-item__link"));


        public bool FindListing()
        {
            bool correctListing;
            try
            {
                foreach (var l in Listings)
                {
                    if (l.Text.Contains("Raspberry Pi 4"))
                    {
                        correctListing = true;
                        l.Click();
                        return correctListing;
                    }

                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;

        }
    }
}
