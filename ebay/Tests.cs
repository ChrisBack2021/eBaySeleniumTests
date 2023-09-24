using ebay.Pages;
using Ebay.Pages;
using OpenQA.Selenium;

namespace Ebay
{
    [TestClass]
    public class Tests : Initial
    {
        [TestMethod]
        public void RaspberryTest()
        {
            var homePage = new Home(driver);
            homePage.EnterSearchBar("Raspberry Pi");

            var testInput = homePage.CorrectSearch("Raspberry Pi");
            Assert.AreEqual(testInput, "Raspberry Pi", "The correct search input is Raspberry Pi");

            homePage.SearchCat();
            homePage.Enter();

            var listingsPage = new SearchList(driver);
            string currentHandle = driver.CurrentWindowHandle;


            var findItem = listingsPage.FindListing();
            Assert.IsTrue(findItem, "Item to be located should include Raspberry Pi 4");

            var rPi = new RaspberryPi(driver);

            var allWindows = driver.WindowHandles;
            string piHandle = String.Empty;
            foreach (var w in allWindows)
            {
                if (w != currentHandle)
                {
                    piHandle = w;
                    driver.SwitchTo().Window(w);
                }
            }

            var titleCheck = rPi.CheckTitle();
            Assert.IsTrue(titleCheck, "Item should include Raspberry Pi");

            string price = "199";
            var priceCheck = rPi.PriceCheck(price);
            Assert.IsTrue(priceCheck, "Price found should be $199");

            rPi.SelectModel();

            string qty = "3";
            rPi.ChooseQty(qty);

            var qtyCheck = rPi.QtyPrice(price, qty);
            Assert.AreEqual(qtyCheck, 597, "qty of 3 and price of 199 adds to 597");

            rPi.CheckCover();
            driver.Close();

            driver.SwitchTo().Window(currentHandle);
            Assert.AreNotEqual(piHandle, driver.CurrentWindowHandle, "Window handle should have changed over");
        }

        [TestMethod]
        public void AirPodTest()
        {
            var homePage = new Home(driver);
            homePage.EnterSearchBar("Air Pods");

            var input = homePage.CorrectSearch("Air Pods");
            Assert.AreEqual(input, "Air Pods", "The correct search input is Air Pods");

            homePage.Enter();

            AirPodListing aPListings = new AirPodListing(driver);
            var correctAirPod = aPListings.FilterAirpods();
            Assert.IsTrue(correctAirPod, "Airpod generation 3 should be found");

            string currentWindow = driver.CurrentWindowHandle;
            var allWindowHandles = driver.WindowHandles;

            var currentUrl = driver.Url;

            foreach (var windowHandle in allWindowHandles)
            {
                if (windowHandle == currentWindow)
                    continue;
                driver.SwitchTo().Window(windowHandle);
            }

            var newUrl = driver.Url;
            Assert.AreNotEqual(currentUrl, newUrl, "Switched pages successfully");

            AirPod AirPodPage = new AirPod(driver);
            var checkTitle = AirPodPage.AirPodTitle();
            Assert.IsTrue(checkTitle, "Incorrect listing. Listing should include 3rd Generation");

            var rightPrice = AirPodPage.CheckPrice();
            Assert.AreEqual(rightPrice, 160, "Correct price indicated");

            var buyButton = AirPodPage.BuyNow();

            Assert.AreEqual(buyButton, "Buy It Now", "Buy button was not located correctly");

 
        }
    }
}
