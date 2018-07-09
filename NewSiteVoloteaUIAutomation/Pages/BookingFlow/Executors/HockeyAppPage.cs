using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;
using VoloteaUIAutomation.Pages.Locators;
using VoloteaUIAutomation.Tools.IO;
using VoloteaUIAutomation.Utilities;
using VoloteaUIAutomation.Utilities.Configurations;
using VoloteaUIAutomation.Utilities.Enums;
using VoloteaUIAutomation.Utilities.Helpers;

namespace VoloteaUIAutomation.Pages.Executors
{
    public class HockeyAppPage : AbstractPage
    {

        public HockeyAppPageLocators locators;
        

        public HockeyAppPage(SeleniumExecutor executor)
            : base(executor) 
        {
            InitElements();
        }

        public void InitElements()
        {
            locators = new HockeyAppPageLocators();
            PageFactory.InitElements(SeleniumExecutor.GetDriver(), locators);
            
        }


        public HockeyAppPage FillUserCredentialFields(string email, string password)
        {
            locators.emailField.SendKeysWithWait(email);
            locators.passwordField.SendKeysWithWait(password);
            return this;
        }

        public HockeyAppPage ClickSignInButton()
        {
            SeleniumClick.ClickWithWait(locators.signInButton);
            return this;
        }

        public HockeyAppPage ClickOnAppVersion(string versionNumber)
        {
            Thread.Sleep(3000);
            foreach (IWebElement version in locators.versionNumber)
            {
                if (SeleniumGetText.GetTextFromElementEx(version).Equals(versionNumber))
                {
                    SeleniumClick.ClickWithWait(version);
                    break;
                }
            }
            return this;
        }

        public HockeyAppPage ClickDownloadButton()
        {
            SeleniumClick.ClickWithWait(locators.downloadButton);
            Thread.Sleep(50000);
            return this;
        }

        public HockeyAppPage SelectAndroidPlatform()
        {
            SeleniumClick.ClickWithWait(locators.platformDropDownBtn);
            SeleniumClick.ClickWithWait(locators.androidBtn);
            Thread.Sleep(2000);
            return this;
        }

        public HockeyAppPage SelectIOSPlatform()
        {
            SeleniumClick.ClickWithWait(locators.platformDropDownBtn);
            SeleniumClick.ClickWithWait(locators.iosBtn);
            Thread.Sleep(2000);
            return this;
        }

    }
}