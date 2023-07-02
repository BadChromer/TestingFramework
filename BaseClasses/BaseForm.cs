using Framework.Browser;
using Framework.Utilities;
using OpenQA.Selenium;

namespace Framework.BaseClasses
{
    public class BaseForm
    {
        private By uniqueLocator { get; set; }
        private string pageName { get; set; }
        public IWebDriver driver;

        public BaseForm(By uniqueLocator, string pageName)
        {
            this.uniqueLocator = uniqueLocator;
            this.pageName = pageName;
            driver = BrowserFactory.InitBrowser();
        }

        public bool IsPageOpened()
        {
            try
            {
                Waits.WaitUntilDisplayed(driver, uniqueLocator);
                Logger.PageIsLoaded(pageName);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void GetDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
        }
    }
}