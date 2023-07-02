using Framework.BaseClasses;
using Framework.WebElements;
using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class LinksPage : BaseForm
    {
        private Button homeLinkButton = new(
            By.XPath("//a[@id='simpleLink' and contains(text(), 'Home')]"),
            nameof(homeLinkButton));

        public LinksPage() : base(
            By.XPath("//div[@class='main-header' and contains(text(), 'Links')]"),
            "Links Page")
        {

        }

        public void ClickHomeLinkButton()
        {
            homeLinkButton.Click();
        }
    }
}