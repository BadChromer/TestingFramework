using Framework.BaseClasses;
using Framework.WebElements;
using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class HomePage : BaseForm
    {
        private Button alertsFrameWindowsButton = new(
            By.XPath("//*[text()='Alerts, Frame & Windows']"),
            nameof(alertsFrameWindowsButton));
        private Button elementsButton = new(
            By.XPath("//*[text()='Elements']"),
            nameof(elementsButton));

        public HomePage() : base(By.ClassName("home-content"), "Home Page")
        {

        }

        public void ClickAlertsButton()
        {
            alertsFrameWindowsButton.Click();
        }

        public void ClickElementsButton()
        {
            elementsButton.Click();
        }
    }
}