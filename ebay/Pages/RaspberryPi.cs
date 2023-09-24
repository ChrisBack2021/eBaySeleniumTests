using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ebay.Pages
{
    public class RaspberryPi
    {
        private IWebDriver driver;

        public RaspberryPi(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ReadOnlyCollection<IWebElement> Price => driver.FindElements(By.XPath("//span[@class='ux-textspans']"));

        public IWebElement Model => driver.FindElement(By.Id("x-msku__select-box-1000"));

        public IWebElement Qty => driver.FindElement(By.CssSelector("input#qtyTextBox"));

        public IWebElement CoverService => driver.FindElement(By.Id("vas-field-item-checkbox-193495056998"));

        public void CheckCover()
        {
            CoverService.Click();
        }

        public void ChooseQty(string q)
        {
            try
            {
                Qty.Clear();
                Qty.SendKeys(q);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SelectModel()
        {
            SelectElement modelPick = new SelectElement(Model);
            modelPick.SelectByText("4 GB");
        }

        public bool PriceCheck(string num)
        {
            foreach (var p in Price)
            {
                if (p.Text.Contains(num))
                    return true;
            }
            return false;
        }

        public int QtyPrice(string num, string qty)
        {
            int n = int.Parse(num);
            int q = int.Parse(qty);

            int newPrice = n * q;
            return newPrice;
        }

        public bool CheckTitle()
        {
            try
            {
                if (driver.Title.Contains("Raspberry Pi"))
                {
                    return true;
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
            return false;
        }

    }
}
