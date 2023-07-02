using Framework.BaseClasses;
using Framework.WebElements;
using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class AlertsWindowsPage : BaseForm
    {
        private Button alertWindowsButton = new(
            By.XPath("//span[@class='text' and contains(text(), 'Alerts')]"),
            nameof(alertWindowsButton));
        private Button nestedFramesButton = new(
            By.XPath("//span[@class='text' and contains(text(), 'Nested Frames')]"),
            nameof(nestedFramesButton));
        private Button framesButton = new(
            By.XPath("//span[@class='text' and contains(text(), 'Frames')]"),
            nameof(framesButton));
        private Button browserWindowsButton = new(
            By.XPath("//span[@class='text' and contains(text(), 'Browser Windows')]"),
            nameof(browserWindowsButton));

        public AlertsWindowsPage() : base(
            By.XPath("//div[@class='main-header' and contains(text(), 'Alerts, Frame & Windows')]"),
            "Alerts, Frame & Windows Page")
        {

        }

        public void ClickAlertsButton()
        {
            alertWindowsButton.Click();
        }

        public void ClickNestedFramesButton()
        {
            nestedFramesButton.Click();
        }

        public void ClickFramesButton()
        {
            framesButton.Click();
        }

        public void ClickBrowserWindowsButton()
        {
            browserWindowsButton.Click();
        }
    }
}