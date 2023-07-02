using Framework.BaseClasses;
using Framework.WebElements;
using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class NestedFramesPage : BaseForm
    {
        private TextField frameText = new(
            By.TagName("body"), nameof(frameText));

        public NestedFramesPage() : base(
            By.XPath("//div[@class='main-header' and contains(text(), 'Nested Frames')]"),
            "Nested Frames Page")
        {

        }

        public void GetFrame(string frameName)
        {
            driver.SwitchTo().Frame(frameName);
        }

        public void GetNestedFrameChild(int frameNumber)
        {
            driver.SwitchTo().Frame(frameNumber);
        }

        public string GetFrameText()
        {
            return frameText.GetText();
        }
    }
}