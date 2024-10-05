using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task_Sauce.Pages
{
    public class Initialize
    {
        IWebDriver driver;
        public Initialize(IWebDriver Driver)
        {
            driver = Driver;
        }

        IWebElement userName => driver.FindElement(By.Id("user-name"));
        IWebElement passWord => driver.FindElement(By.Id("password"));
        IWebElement login => driver.FindElement(By.Id("login-button"));

        public void NavigateToSite(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        public void SetTextToUserName(string username) => userName.SendKeys(username);
        public void SetTextToPassword(string password) => passWord.SendKeys(password);
        public void ClickLoginButton() => login.Click();
    }
}
