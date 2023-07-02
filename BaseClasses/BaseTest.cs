using Framework.Browser;
using Framework.Utilities;

namespace Framework.BaseClasses
{
    public class BaseTest
    {
        [SetUp]
        public void BaseSetUp()
        {
            ConfigDataManager.ReadConfigData();
            UserDataManager.ReadUserData();
            BrowserFactory.InitBrowser();
            BrowserUtility.Navigate(ConfigDataManager.configData[0].MAIN_PAGE_URL);
        }
        [TearDown]
        public void BaseTearDown()
        {
            BrowserUtility.CloseBrowser();
        }
    }
}