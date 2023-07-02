using Framework.BaseClasses;
using Framework.WebElements;
using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class AlertsPage : BaseForm
    {
        private Button alertButton = new(
            By.Id("alertButton"), nameof(alertButton));
        private Button confirmButton = new(
            By.Id("confirmButton"), nameof(confirmButton));
        private Button promptButton = new(
            By.Id("promtButton"), nameof(promptButton));
        private TextField confirmResult = new(
            By.Id("confirmResult"), nameof(confirmResult));
        private TextField promptResult = new(
            By.Id("promptResult"), nameof(promptResult));

        public AlertsPage() : base(
            By.XPath("//div[@class='main-header' and contains(text(), 'Alerts')]"),
            "Alerts Page")
        {

        }

        public void ClickAlertButton()
        {
            alertButton.Click();
        }

        public void ClickConfirmButton()
        {
            confirmButton.Click();
        }

        public void ClickPromptButton()
        {
            promptButton.Click();
        }

        public string GetConfirmResult()
        {
            return confirmResult.GetAttribute("textContent");
        }

        public string GetPromptResult()
        {
            return promptResult.GetAttribute("textContent");
        }

        public IAlert GetAlert()
        {
            try
            {
                return driver.SwitchTo().Alert();
            }
            catch (NoAlertPresentException)
            {
                Console.WriteLine("No alert");
                return null;
            }
        }

        public string ReadAlert()
        {
            return GetAlert().Text;
        }

        public void AcceptAlert()
        {
            GetAlert().Accept();
        }

        public void CancelAlert()
        {
            GetAlert().Dismiss();
        }

        public void SendTextToAlert(string text)
        {
            GetAlert().SendKeys(text);
        }
    }
}