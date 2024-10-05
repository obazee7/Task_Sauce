using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using Task_Sauce.Pages;

namespace Task_Sauce.StepDefinitions
{
    [Binding]
    public class SaucedemoStepDefinitions
    {
        IWebDriver driver;
        Initialize initialize;
        Product inventory;
        string url = "https://www.saucedemo.com/";

        public SaucedemoStepDefinitions(IObjectContainer _container)
        {
                driver = _container.Resolve<IWebDriver>();
                initialize = _container.Resolve<Initialize>();
                inventory = _container.Resolve<Product>();
        }

        [Given(@"user is on saucedemo site")]
        public void GivenUserIsOnSaucedemoSite()
        {
            initialize.NavigateToSite(url);
        }

        [Given(@"user login with the following creds")]
        public void GivenUserLoginWithTheFollowingCreds(Table table)
        {
            //Example1
            initialize.SetTextToUserName(table.Rows[0]["userName"]);
            initialize.SetTextToPassword(table.Rows[0]["password"]);

            initialize.ClickLoginButton();
        }

        [When(@"user select the highest price item and add to cart")]
        public void WhenUserSelectTheHighestPriceItemAndAddToCart()
        {
            inventory.AddHighestProductToCart();
        }

        [Then(@"item cart count is (.*)")]
        public void ThenItemCartCountIs(int expectedCount)
        {
            var actualCount = int.Parse(inventory.GetCartCount());
            Assert.That(actualCount.Equals(expectedCount), Is.EqualTo(true));
        }
    }
}
