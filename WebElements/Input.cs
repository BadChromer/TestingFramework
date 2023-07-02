using Framework.BaseClasses;
using OpenQA.Selenium;

namespace Framework.WebElements
{
    public class Input : BaseElement
    {
        private By uniqueLocator { get; set; }
        private string elementName { get; set; }

        public Input(By uniqueLocator, string elementName) : base(uniqueLocator, elementName)
        {
            this.uniqueLocator = uniqueLocator;
            this.elementName = elementName;
        }

        public void SendText(string? text)
        {
            driver.FindElement(uniqueLocator).SendKeys(text);
        }
    }
}