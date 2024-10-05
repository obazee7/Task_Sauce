using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task_Sauce.Hooks
{
    [Binding]
    public sealed class Basehooks
    {
        private IWebDriver driver;
        private IObjectContainer container;
        public Basehooks(IObjectContainer _container)
        {
            container = _container;
        }

        [BeforeScenario()]
        public void FirstBeforeScenario()
        {
            var option = new ChromeOptions();
            option.AddArguments("--start-maximized", "--incognito");
            driver = new ChromeDriver(option);
            container.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}