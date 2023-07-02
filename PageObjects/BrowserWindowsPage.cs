using Framework.BaseClasses;
using Framework.WebElements;
using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class BrowserWindowsPage : BaseForm
    {
        private Button newTabButton = new(
            By.Id("tabButton"),
            nameof(newTabButton));
        private Button elementsButton = new(
            By.XPath("//div[@class='header-text' and contains(text(), 'Elements')]"),
            nameof(elementsButton));
        private Button linksButton = new(
            By.XPath("//span[@class='text' and contains(text(), 'Links')]"),
            nameof(linksButton));

        public BrowserWindowsPage() : base(
            By.XPath("//div[@class='main-header' and contains(text(), 'Browser Windows')]"),
            "Browser Windows Page")
        {

        }

        public void ClickNewTabButton()
        {
            newTabButton.Click();
        }

        public void ClickElementsButton()
        {
            elementsButton.Click();
        }

        public void ClickLinksButton()
        {
            linksButton.Click();
        }
    }
}