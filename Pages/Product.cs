using OpenQA.Selenium;
using System.Text.RegularExpressions;


namespace Task_Sauce.Pages
{
    public class Product
    {
        IWebDriver driver;
        public Product(IWebDriver Driver)
        {
            driver = Driver;
        }

        IList<IWebElement> productPrice => driver.FindElements(By.XPath("//div[@data-test='inventory-item-price']"));
        IWebElement productPriceButton(decimal num) => 
            driver.FindElement(By.XPath($"//div[text()='{num}']//following-sibling::button"));
        IWebElement cartCount => driver.FindElement(By.CssSelector("[data-test='shopping-cart-badge']"));


        public void AddHighestProductToCart()
        {
            List<Decimal> num = new List<decimal>(); //Adding all number to a list

            foreach (var price in productPrice)
            {
                string p = Regex.Replace(price.Text, @"[^\d.]", "");
                if (price.Text != null)
                {
                    num.Add(Convert.ToDecimal(p));
                }
            }

            if (num.Count > 0)
            {
                // Get the highest number and add to cart based on the max value
                var highestNumber = num.Max();
                productPriceButton(highestNumber).Click();
            }
        }

        public string GetCartCount() => cartCount.Text;
    }
}
