using Framework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Framework.Browser
{
    public class BrowserFactory : BrowserUtility
    {
        public static IWebDriver InitBrowser()
        {
            if (driver == null)
            {
                switch (ConfigDataManager.configData[0].BROWSER_NAME.ToUpper())
                {
                    case "FIREFOX":
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver(SetFirefoxSettings());
                        break;
                    case "EDGE":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        driver = new EdgeDriver(SetEdgeSettings());
                        break;
                    case "CHROME":
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver(SetChromeSettings());
                        break;
                    default:
                        throw new InvalidOperationException("Browser not found");
                }
            }
            return driver;
        }
    }
}