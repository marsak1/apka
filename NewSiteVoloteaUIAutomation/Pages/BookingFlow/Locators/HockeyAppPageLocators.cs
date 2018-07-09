using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System;

namespace VoloteaUIAutomation.Pages.Locators
{
    public class HockeyAppPageLocators
    {
        [FindsBy(How = How.Id, Using = "user_email")]
        public IWebElement emailField;

        [FindsBy(How = How.Id, Using = "user_password")]
        public IWebElement passwordField;

        [FindsBy(How = How.Name, Using = "commit")]
        public IWebElement signInButton;

        [FindsBy(How = How.XPath, Using = "//span[@data-original]")]
        public IList<IWebElement> versionNumber;

        [FindsBy(How = How.XPath, Using = "//a[@class='btn btn-ha-primary button']")]
        public IWebElement downloadButton;

        [FindsBy(How = How.XPath, Using = "//ul[@class='nav nav-pills']/li[2]")]
        public IWebElement platformDropDownBtn;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Android')]")]
        public IWebElement androidBtn;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'iOS')]")]
        public IWebElement iosBtn;
    }
}
