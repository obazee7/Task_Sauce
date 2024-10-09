using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
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

        IWebElement productLabel (string text) => driver.FindElement(By.XPath($"//div[text()='{text}']"));

        


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
                var highestNumber = num.ElementAt(3);
                productPriceButton(highestNumber).Click();
            }
        }

        public void AddHighestLowestProductToCart(string option)
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
                // Get the highest or any option number and add to cart based on the max value
                var choice = option.Equals("highest") 
                    ? num.Max()
                    : option.Equals("lowest")
                    ? num.Min()
                    : option.Equals("second")
                    ? num.ElementAt(1)
                    : option.Equals("third")
                    ? num.ElementAt(2)
                    : option.Equals("fourth")
                    ? num.ElementAt(3)
                    : num.LastOrDefault();
                var highestNumber = choice;
                productPriceButton(highestNumber).Click();
            }
        }


        public void AddAnyProductToCart(decimal value)
        {
            productPriceButton(value).Click();
        }


        public string ValidateproductLabel(string label) => productLabel(label).Text;

        public string GetCartCount() => cartCount.Text;

        public void ClickProductToCart() => cartCount.Click();
    }
}
