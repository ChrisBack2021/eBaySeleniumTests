using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebay.Pages
{
    public class Home
    {
        private IWebDriver driver;



        public Home(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public IWebElement SearchBar => driver.FindElement(By.CssSelector("#gh-ac"));
        public IWebElement Cat => driver.FindElement(By.XPath("//select[@id='gh-cat']"));

        public IWebElement EnterBtn => driver.FindElement(By.Id("gh-btn"));

        public void Enter()
        {
            EnterBtn.Click();
        }

        public void SearchCat()
        {
            SelectElement select = new SelectElement(Cat);
            select.SelectByText("Computers/Tablets & Networking");
        }

        public void EnterSearchBar(string search)
        {
            SearchBar.SendKeys(search);
        }

        public string CorrectSearch(string search)
        {

            try
            {
                if (SearchBar.GetAttribute("value") == search)
                {
                    search = SearchBar.GetAttribute("value");
                    return search;
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return search;
        }


    }
}
