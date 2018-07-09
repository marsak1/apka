using System;
using System.Configuration;
using VoloteaUIAutomation.Utilities.Enums;

namespace VoloteaUIAutomation.Utilities.Configurations
{
    class TestConfiguration
    {
        public static BrowserType BrowserParameter
        {
            get
            {
                if (System.Environment.GetEnvironmentVariable("BrowserType") == null || System.Environment.GetEnvironmentVariable("BrowserType") == "")
                    return (BrowserType)Enum.Parse(typeof(BrowserType), ConfigurationManager.AppSettings["browserParameter"]);
                else
                    return (BrowserType)Enum.Parse(typeof(BrowserType), System.Environment.GetEnvironmentVariable("BrowserType"));
            }
        }

        public static ResolutionType ResolutionParameter
        {
            get
            {
                if (System.Environment.GetEnvironmentVariable("ResolutionType") == null || System.Environment.GetEnvironmentVariable("ResolutionType") == "")
                    return (ResolutionType)Enum.Parse(typeof(ResolutionType), ConfigurationManager.AppSettings["resolutionParameter"]);
                else
                    return (ResolutionType)Enum.Parse(typeof(ResolutionType), System.Environment.GetEnvironmentVariable("ResolutionType"));
            }
        }

        public static String ScreenshotDirectory
        {
            get { return ConfigurationManager.AppSettings["screenshotDirectory"]; }
        }

        public static String PageMainUrl
        {
            get
            {
                if (System.Environment.GetEnvironmentVariable("ApplicationEnvironment") == null || System.Environment.GetEnvironmentVariable("ApplicationEnvironment") == "")
                    return ConfigurationManager.AppSettings["pageDefaultUrl"];
                else
                    return AppEnv2URLConverter.ToString((ApplicationEnvironment)Enum.Parse(typeof(ApplicationEnvironment), System.Environment.GetEnvironmentVariable("ApplicationEnvironment")));
            }
        }

        public static String UserEmail
        {
            get { return ConfigurationManager.AppSettings["userEmail"]; }
        }

        public static String MyProfilePage
        {
            get { return ConfigurationManager.AppSettings["myProfilePage"]; }
        }

        public static String MyBookingsPage
        {
            get { return ConfigurationManager.AppSettings["myBookingsPage"]; }
        }

        public static String MyCreditPage
        {
            get { return ConfigurationManager.AppSettings["myCreditPage"]; }
        }

        public static String NewsletterPage
        {
            get { return ConfigurationManager.AppSettings["newsletterPage"]; }
        }

        public static String HomePagePartialUrl
        {
            get { return ConfigurationManager.AppSettings["homePage"]; }
        }

        public static String SearchPagePartialUrl
        {
            get { return ConfigurationManager.AppSettings["searchPage"]; }
        }

        public static String ChooseFlightPagePartialUrl
        {
            get { return ConfigurationManager.AppSettings["chooseFlightPage"]; }
        }

        public static String CalendarPagePartialUrl
        {
            get { return ConfigurationManager.AppSettings["calendarPage"]; }
        }

        public static String PassengerPagePartialUrl
        {
            get { return ConfigurationManager.AppSettings["passengerContactPage"]; }
        }

        public static String ComboPagePartialUrl
        {
            get { return ConfigurationManager.AppSettings["comboPage"]; }
        }

        public static String ExtrasPagePartialUrl
        {
            get { return ConfigurationManager.AppSettings["extrasPage"]; }
        }

        public static String PaymentPagePartialUrl
        {
            get { return ConfigurationManager.AppSettings["paymentPage"]; }
        }

        public static String ItineraryPagePartialUrl
        {
            get { return ConfigurationManager.AppSettings["itineraryPage"]; }
        }

        public static String ManageMyBookingPagePartialUrl
        {
            get { return ConfigurationManager.AppSettings["manageMyBookingPage"]; }
        }

        public static String CheckinSummaryPagePartialUrl
        {
            get { return ConfigurationManager.AppSettings["checkinSummary"]; }
        }

        //---------------- DB setup -----------------        
        public static String[] DbDefaultUser
        {
            get { return ConfigurationManager.AppSettings["dbDefaultUser"].Split(','); }
        }

        public static String DbDefaultServer
        {
            get { return ConfigurationManager.AppSettings["dbDefaultServer"]; }
        }

        public static String DbDefaultDatabase
        {
            get { return ConfigurationManager.AppSettings["dbDefaultDatabase"]; }
        }

        public static String PasswordToNewAccount
        {
            get { return ConfigurationManager.AppSettings["passwordToNewAccount"]; }
        }

        public static String LoginToAccount
        {
            get { return ConfigurationManager.AppSettings["loginToAccount"]; }
        }

        public static String PasswordToAccount
        {
            get { return ConfigurationManager.AppSettings["passwordToAccount"]; }
        }

        public static String LoginToFacebookAccount
        {
            get { return ConfigurationManager.AppSettings["loginToFacebookAccount"]; }
        }

        public static String PasswordToFacebookAccount
        {
            get { return ConfigurationManager.AppSettings["passwordToFacebookAccount"]; }
        }

        public static String IgnoredTestsOnProduction
        {
            get { return ConfigurationManager.AppSettings["ignoredTestsOnProduction"]; }
        }

        public static String SkipCategoryForEnv
        {
            get { return ConfigurationManager.AppSettings["skipCategoryForEnv"]; }
        }
    }
}
