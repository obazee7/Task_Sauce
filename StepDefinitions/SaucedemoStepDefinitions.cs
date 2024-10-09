using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using Task_Sauce.Pages;
using Task_Sauce.Secret;
using Task_Sauce.Support;




namespace Task_Sauce.StepDefinitions
{
    [Binding]
    public class SaucedemoStepDefinitions
    {
        IWebDriver driver;
        Initialize initialize;
        Product inventory;
        string url = "https://www.saucedemo.com/";
        readFromConfig readFromConfig;
 
        public SaucedemoStepDefinitions(IObjectContainer _container)
        {
            driver = _container.Resolve<IWebDriver>();
            initialize = _container.Resolve<Initialize>();
            inventory = _container.Resolve<Product>();
            readFromConfig = _container.Resolve<readFromConfig>();
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

            //Example 2 Class File
            //Example 3 - Json File
            //Example 4 - Database
            //Example 5 - Ressource File

          
        }

        [Given(@"user login with the following creds 2")]
        public void GivenUserLoginWithTheFollowingCreds()
        {
           
            //json example
            initialize.SetTextToUserName(readFromConfig.GetConfigData("Credentials:username"));
            initialize.SetTextToPassword(readFromConfig.GetConfigData("Credentials:password"));
            initialize.ClickLoginButton();

        }

    



        [When(@"user select the highest price item and add to cart")]
        public void WhenUserSelectTheHighestPriceItemAndAddToCart()
        {
            inventory.AddHighestProductToCart();
        }

        [When(@"user select the option '(highest|lowest|any|second)' price item and add to cart")]
        public void WhenUserSelectTheOptionPriceItemAndAddToCart(string option)
        {
            inventory.AddHighestLowestProductToCart(option);
        }

        [When(@"user select amount '(.*)' price item and add to cart")]
        public void WhenUserSelectTheOptionPriceItemAndAddToCart(decimal option)
        {
            inventory.AddAnyProductToCart(Convert.ToDecimal(option));
        }

        [Then(@"item cart count is (.*)")]
        public void ThenItemCartCountIs(int expectedCount)
        {
            var actualCount = int.Parse(inventory.GetCartCount());
            Assert.That(actualCount.Equals(expectedCount), Is.EqualTo(true));
           
       }

        [When(@"validate text label on Product page as '([^']*)'")]
        public void WhenValidateTextLabelOnProductPageAs(string expectedProductLabel)
        {
            var actual = inventory.ValidateproductLabel(expectedProductLabel);
            Assert.That(expectedProductLabel.Equals(actual), Is.EqualTo(true));
        }

        [When(@"I click on cart on product page")]
        public void WhenIClickOnCartOnProductPage()
        {
            inventory.ClickProductToCart();
        }


    }
}
