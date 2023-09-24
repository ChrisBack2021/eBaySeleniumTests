using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ebay.Pages
{
    public class AirPod
    {
        private IWebDriver driver;

        public AirPod(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public IWebElement Price => driver.FindElement(By.ClassName("x-buybox__price-section"));

        public ReadOnlyCollection<IWebElement> Buttons => driver.FindElements(By.ClassName("ux-call-to-action__text"));


        public bool AirPodTitle()
        {
            if (driver.Title.Contains("3rd Generation"))
                return true;
            return false;
        }

        public int CheckPrice()
        {
            int price = 0;
            try
            {
                var priceString = Price.Text.ToString();
                var arr = priceString.Split(' ');

                foreach (var item in arr)
                {
                    if (item.Contains("$160"))
                    {
                        string priceFound = item.Remove(0, 1);
                        string foundPrice = priceFound.Remove(3);
                        price = Convert.ToInt32(foundPrice);
                        return price;
                    }
                }
                return price;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return price;
            }
        }

        public string BuyNow()
        {
            string BuyItNow = "";

            try
            {
                foreach (var buttons in Buttons)
                {

                    if (buttons.Text.Contains("Buy It Now"))
                        BuyItNow = buttons.Text;
                    return BuyItNow;
                }
                return BuyItNow;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BuyItNow;
            }
        }

    }
}
