using Framework.BaseClasses;
using OpenQA.Selenium;

namespace Framework.WebElements
{
    public class Table : BaseElement
    {
        private By uniqueLocator { get; set; }
        private string elementName { get; set; }

        public Table(By uniqueLocator, string elementName) : base(uniqueLocator, elementName)
        {
            this.uniqueLocator = uniqueLocator;
            this.elementName = elementName;
        }
    }
}