using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Framework.Browser
{
    public class BrowserUtility
    {
        public static IWebDriver driver;

        public static FirefoxOptions SetFirefoxSettings()
        {
            FirefoxOptions firefoxOption = new();
            firefoxOption.AddArguments("-private");
            return firefoxOption;
        }

        public static EdgeOptions SetEdgeSettings()
        {
            EdgeOptions edgeOption = new();
            edgeOption.AddArguments("-inprivate");
            return edgeOption;
        }

        public static ChromeOptions SetChromeSettings()
        {
            ChromeOptions chromeOption = new();
            chromeOption.AddArguments("incognito");
            return chromeOption;
        }

        public static void Navigate(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void SwitchToWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public static void SwitchToFirstWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        public static void CloseCurrentWindow()
        {
            driver.Close();
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}