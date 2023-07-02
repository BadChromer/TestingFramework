using Framework.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Utilities
{
    public class Waits
    {
        public static readonly WebDriverWait wait = new(
            BrowserFactory.InitBrowser(), TimeSpan.FromSeconds(5));

        public static void WaitUntilDisplayed(IWebDriver driver, By uniqueLocator)
        {
            wait.Until(element => driver.FindElement(uniqueLocator).Displayed == true);
        }

        public static void WaitUntilClickable(IWebDriver driver, By uniqueLocator)
        {
            wait.Until(element => driver.FindElement(uniqueLocator).Enabled == true);
        }
    }
}