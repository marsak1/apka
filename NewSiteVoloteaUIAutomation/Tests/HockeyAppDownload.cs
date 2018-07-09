
using NewSiteVoloteaUIAutomation.Utilities.Objects;
using NUnit.Framework;
using System;
using VoloteaUIAutomation.Pages.Executors;
using VoloteaUIAutomation.Utilities;
using VoloteaUIAutomation.Utilities.Configurations;
using VoloteaUIAutomation.Utilities.Helpers;

namespace VoloteaUIAutomation.Tests
{
    [TestFixture]
    public class HockeyAppDownload
    {
        public SeleniumExecutor executor;
        public HockeyAppPage volotea;


        [Test]
        public void DownloadIOSAppVersion()
        {
            AppVersion.Platform = "ios";

            SeleniumExecutor.BaseSetUp();
            executor = SeleniumExecutor.GetExecutor();
            executor.OpenPage(SeleniumExecutor.pageDefaultUrl);
            volotea = new HockeyAppPage(executor);

            volotea.FillUserCredentialFields(TestConfiguration.LoginToAccount, TestConfiguration.PasswordToAccount).
                    ClickSignInButton().
                    SelectIOSPlatform().
                    ClickOnAppVersion("PX-633");
            SeleniumReporter.TakeScreenshot(SeleniumExecutor.GetDriver());
            volotea.ClickDownloadButton();

            executor.BaseTearDown();

        }

        [Test]
        public void DownloadAndroidAppVersion()
        {
            AppVersion.Platform = "android";

            SeleniumExecutor.BaseSetUp();
            executor = SeleniumExecutor.GetExecutor();
            executor.OpenPage(SeleniumExecutor.pageDefaultUrl);
            volotea = new HockeyAppPage(executor);

            volotea.FillUserCredentialFields(TestConfiguration.LoginToAccount, TestConfiguration.PasswordToAccount).
                    ClickSignInButton().
                    SelectAndroidPlatform().
                    ClickOnAppVersion("PX-633");
            SeleniumReporter.TakeScreenshot(SeleniumExecutor.GetDriver());
            volotea.ClickDownloadButton();

            executor.BaseTearDown();
        }
    }
}
