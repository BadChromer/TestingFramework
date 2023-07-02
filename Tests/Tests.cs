using Framework.BaseClasses;
using Framework.Browser;
using Framework.PageObjects;
using Framework.Utilities;

namespace Framework.Tests
{
    public class Tests : BaseTest
    {
        [Test]
        public void AlertsTests()
        {
            HomePage homePage = new();
            Assert.That(homePage.IsPageOpened(), Is.True);
            homePage.ClickAlertsButton();

            AlertsWindowsPage alertsFrameWindowsPage = new();
            Assert.That(alertsFrameWindowsPage.IsPageOpened(), Is.True);
            alertsFrameWindowsPage.ClickAlertsButton();

            AlertsPage alertsPage = new();
            Assert.That(alertsPage.IsPageOpened(), Is.True);
            alertsPage.ClickAlertButton();
            Assert.That(alertsPage.ReadAlert(), Is.EqualTo("You clicked a button"));
            alertsPage.AcceptAlert();
            Assert.That(alertsPage.GetAlert(), Is.EqualTo(null));
            alertsPage.ClickConfirmButton();
            Assert.That(alertsPage.ReadAlert(), Is.EqualTo("Do you confirm action?"));
            alertsPage.AcceptAlert();
            Assert.That(alertsPage.GetConfirmResult(), Is.EqualTo("You selected Ok"));
            alertsPage.ClickPromptButton();
            Assert.That(alertsPage.ReadAlert(), Is.EqualTo("Please enter your name"));

            string randomText = RandomGenerator.GenerateRandomString(16);
            alertsPage.SendTextToAlert(randomText);
            alertsPage.AcceptAlert();
            Assert.That(alertsPage.GetPromptResult(), Is.EqualTo($"You entered {randomText}"));
        }

        [Test]
        public void IframeTests()
        {
            HomePage homePage = new();
            Assert.That(homePage.IsPageOpened(), Is.True);
            homePage.ClickAlertsButton();

            AlertsWindowsPage alertsFrameWindowsPage = new();
            Assert.That(alertsFrameWindowsPage.IsPageOpened(), Is.True);
            alertsFrameWindowsPage.ClickNestedFramesButton();

            NestedFramesPage nestedFramesPage = new();
            nestedFramesPage.GetFrame("frame1");
            Assert.That(nestedFramesPage.GetFrameText(), Is.EqualTo("Parent frame"));
            nestedFramesPage.GetNestedFrameChild(0);
            Assert.That(nestedFramesPage.GetFrameText(), Is.EqualTo("Child Iframe"));
            nestedFramesPage.GetDefaultContent();
            alertsFrameWindowsPage.ClickFramesButton();

            FramesPage framesPage = new();
            framesPage.GetFrame("frame1");
            Assert.That(framesPage.GetFrameText(), Is.EqualTo("This is a sample page"));
            framesPage.GetDefaultContent();
            framesPage.GetFrame("frame2");
            Assert.That(framesPage.GetFrameText(), Is.EqualTo("This is a sample page"));
        }

        [Test]
        public void TablesTests()
        {
            HomePage homePage = new();
            Assert.That(homePage.IsPageOpened(), Is.True);
            homePage.ClickElementsButton();

            ElementsPage elementsPage = new();
            Assert.That(elementsPage.IsPageOpened(), Is.True);
            elementsPage.ClickWebTablesButton();

            WebTablesPage webTablesPage = new();
            Assert.That(webTablesPage.IsPageOpened(), Is.True);
            webTablesPage.ClickAddRecordButton();
            Assert.That(webTablesPage.GetFormName(), Is.EqualTo("Registration Form"));
            webTablesPage.ClickCloseButton();
            webTablesPage.SendUserDataToForm();
            webTablesPage.GetTable();
            Assert.That(webTablesPage.CheckIfTableContainsUser(), Is.True);
            webTablesPage.ClickDeleteFirstUserRecord();
            webTablesPage.ClickDeleteSecondUserRecord();
            webTablesPage.GetTable();
            Assert.That(webTablesPage.CheckIfTableContainsUser(), Is.False);
        }

        [Test]
        public void BrowserWindowsTests()
        {
            HomePage homePage = new();
            Assert.That(homePage.IsPageOpened(), Is.True);
            homePage.ClickAlertsButton();

            AlertsWindowsPage alertsFrameWindowsPage = new();
            Assert.That(alertsFrameWindowsPage.IsPageOpened(), Is.True);
            alertsFrameWindowsPage.ClickBrowserWindowsButton();

            BrowserWindowsPage browserWindowsPage = new();
            Assert.That(browserWindowsPage.IsPageOpened(), Is.True);
            browserWindowsPage.ClickNewTabButton();
            BrowserUtility.SwitchToWindow();

            NewTabPage newTabPage = new();
            Assert.That(newTabPage.IsPageOpened(), Is.True);
            Assert.That(newTabPage.GetText(), Is.EqualTo("This is a sample page"));
            BrowserUtility.CloseCurrentWindow();
            BrowserUtility.SwitchToWindow();
            Assert.That(browserWindowsPage.IsPageOpened(), Is.True);
            browserWindowsPage.ClickElementsButton();
            browserWindowsPage.ClickLinksButton();

            LinksPage linksPage = new();
            Assert.That(linksPage.IsPageOpened(), Is.True);
            linksPage.ClickHomeLinkButton();
            BrowserUtility.SwitchToWindow();
            Assert.That(homePage.IsPageOpened(), Is.True);
            BrowserUtility.SwitchToFirstWindow();
            Assert.That(linksPage.IsPageOpened(), Is.True);
        }
    }
}