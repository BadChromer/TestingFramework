using Framework.BaseClasses;
using OpenQA.Selenium;

namespace Framework.WebElements
{
    public class TextField : BaseElement
    {
        private By uniqueLocator { get; set; }
        private string elementName { get; set; }

        public TextField(By uniqueLocator, string elementName) : base(uniqueLocator, elementName)
        {
            this.uniqueLocator = uniqueLocator;
            this.elementName = elementName;
        }
    }
}