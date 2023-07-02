using Framework.BaseClasses;
using Framework.WebElements;
using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class NewTabPage : BaseForm
    {
        private TextField newTabText = new(
            By.Id("sampleHeading"), nameof(newTabText));

        public NewTabPage() : base(
            By.XPath("//*[@id='sampleHeading' and contains(text(), 'This is a sample page')]"),
            "New Tab Page")
        {

        }

        public string GetText()
        {
            return newTabText.GetText();
        }
    }
}