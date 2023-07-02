using Framework.Browser;
using Framework.Utilities;
using OpenQA.Selenium;

namespace Framework.BaseClasses
{
    public class BaseElement
    {
        private By uniquelocator { get; set; }
        private string elementName { get; set; }
        public IWebDriver driver;

        public BaseElement(By uniquelocator, string elementName)
        {
            this.uniquelocator = uniquelocator;
            this.elementName = elementName;
            driver = BrowserFactory.InitBrowser();
        }

        public IWebElement GetElement()
        {
            return driver.FindElement(uniquelocator);
        }

        public List<IWebElement> GetElements()
        {
            return driver.FindElements(uniquelocator).ToList();
        }

        public string GetText()
        {
            return GetElement().Text;
        }

        public string GetAttribute(string attributeName)
        {
            Logger.AttributeIsGiven(elementName, attributeName);
            return GetElement().GetAttribute(attributeName);
        }

        public bool IsElementDisplayed()
        {
            Logger.ElementIsDisplayed(elementName);
            return GetElement().Displayed;
        }

        public void Click()
        {
            try
            {
                Waits.WaitUntilDisplayed(driver, uniquelocator);
                Waits.WaitUntilClickable(driver, uniquelocator);
                GetElement().Click();
                Logger.ElementIsClicked(elementName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while trying to click {elementName}. Trying javascript click to avoid {ex.Message}");
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].click();", GetElement());
            }
        }

        public void WaitUntilDisplayed()
        {
            Waits.WaitUntilDisplayed(driver, uniquelocator);
        }

        public void WaitUntilClickable()
        {
            Waits.WaitUntilClickable(driver, uniquelocator);
        }
    }
}