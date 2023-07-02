using Framework.BaseClasses;
using Framework.WebElements;
using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class ElementsPage : BaseForm
    {
        private Button webTablesButton = new(
            By.XPath("//span[@class='text' and contains(text(), 'Web Tables')]"),
            nameof(webTablesButton));

        public ElementsPage() : base(
            By.XPath("//div[@class='main-header' and contains(text(), 'Elements')]"),
            "Elements Page")
        {

        }

        public void ClickWebTablesButton()
        {
            webTablesButton.Click();
        }
    }
}