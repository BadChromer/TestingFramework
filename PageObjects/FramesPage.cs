using Framework.BaseClasses;
using Framework.WebElements;
using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class FramesPage : BaseForm
    {
        private TextField frameText = new(
            By.TagName("body"), nameof(frameText));

        public FramesPage() : base(
            By.XPath("//div[@class='main-header' and contains(text(), 'Frames')]"),
            "Frames")
        {

        }

        public void GetFrame(string frameName)
        {
            driver.SwitchTo().Frame(frameName);
        }

        public string GetFrameText()
        {
            return frameText.GetText();
        }
    }
}