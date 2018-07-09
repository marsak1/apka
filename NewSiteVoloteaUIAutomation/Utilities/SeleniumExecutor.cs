using VoloteaUIAutomation.Utilities.Configurations;
using VoloteaUIAutomation.Utilities.Enums;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Remote;
using VoloteaUIAutomation.Utilities.Helpers;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Collections;
using System.IO;
using NewSiteVoloteaUIAutomation.Utilities.Objects;

namespace VoloteaUIAutomation.Utilities
{
    public class SeleniumExecutor
    {
        public const int Timeout = 30; //seconds

        public static SeleniumExecutor executor;
        private static RemoteWebDriver driver;
        private static WebDriverWait waitDriver;

        private static String parentWindowHandle;
        private static IEnumerator<String> windowIterator;

        public static String pageDefaultUrl;

        //No connection managing and control 
        public static readonly Boolean exitWhenNoConnection = true;
        public static readonly String exitNoConnectionStr = "Due to no connection, the rest of tests will not be running";
        public static Boolean ignoreCurrentTest = false;
        public static readonly String ignoreByNoConnection = "Test ignored due to no connection";

        private static Thread mainThread;
        private static System.Timers.Timer timerServerConnection;

        public SeleniumExecutor()
        {
        }

        public static void BaseSetUp()
        {
            if (exitWhenNoConnection && ignoreCurrentTest)
            {
                Console.WriteLine(exitNoConnectionStr);
                Environment.Exit(1);
            }

            SeleniumExecutor.ignoreCurrentTest = false;
            executor = null;
            driver = null;
            pageDefaultUrl = TestConfiguration.PageMainUrl;

            if (timerServerConnection == null)
            {
                timerServerConnection = new System.Timers.Timer();
                timerServerConnection.Interval = 5000;
                timerServerConnection.Elapsed += OnTimedEvent;
                timerServerConnection.AutoReset = true;
            }

            mainThread = Thread.CurrentThread;
            timerServerConnection.Enabled = true;

            driver = CreateDriver();
            SetDriverResolution();
            parentWindowHandle = driver.CurrentWindowHandle;
            Console.WriteLine("Main page url: " + pageDefaultUrl);
        }

        public void ScreenshotReport()
        {
            if (TestContext.CurrentContext.Result.FailCount > 0)
            {
                //SeleniumReporter.TakeScreenshot(driver, TestContext.CurrentContext.Test.FullName.Remove(0,26)); // removing project name part 
            }
            else
            {
                SeleniumReporter.DeleteScreenshotIfExist(SeleniumReporter.GetScreenshotFullPath(TestContext.CurrentContext.Test.FullName.Remove(0, 26)));
            }
        }

        public void BaseTearDown()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
            }
        }

        private static void Init()
        {
            if (executor == null)
                executor = new SeleniumExecutor();
        }

        public static SeleniumExecutor GetExecutor()
        {
            Init();
            return executor;
        }

        public static RemoteWebDriver GetDriver()
        {
            return driver;
        }

        public static WebDriverWait GetWaitDriver()
        {
            return waitDriver;
        }

        public static String GetParentWindowHandle()
        {
            return parentWindowHandle;
        }

        public static IEnumerator<String> GetWindowIterator()
        {
            return windowIterator;
        }

        private static void SetDriverResolution()
        {
            ResolutionType resolutionType = TestConfiguration.ResolutionParameter;
            ResolutionTypeHelper.SetResolution4Browser(resolutionType);
            Console.WriteLine("Resolution type: " + resolutionType);
        }

        public static void SetWindowIterator()
        {
            windowIterator = driver.WindowHandles.GetEnumerator();
        }

        public static void CreateNewFolder(string folderPath)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(folderPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }
        }

        public static RemoteWebDriver CreateDriver()
        {
            string folderPath = "";
            string date = DateTime.Today.ToShortDateString().Replace('-', '_');
            string time = DateTime.Now.ToString("HH:mm:ss".Replace(':', '.'));

            if (AppVersion.Platform.Equals("ios"))
            {
                folderPath = "C:\\XamarinApp\\iOS\\" + date + "\\" + time + "\\"; ;
            } 
            else if (AppVersion.Platform.Equals("android"))
            {
                folderPath = "C:\\XamarinApp\\Android\\" + date+ "\\" + time + "\\" ;
            }

            AppVersion.FolderPath = folderPath;

            CreateNewFolder(folderPath);

            var chromeOptions = new ChromeOptions();
            var downloadDirectory = folderPath;

            chromeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

            BrowserType browserType = TestConfiguration.BrowserParameter;
            Console.WriteLine("Browser type: " + browserType);

            if (driver == null)
            {
                switch (browserType)
                {
                    case BrowserType.chrome:
                        driver = new ChromeDriver(chromeOptions);
                        break;

                    case BrowserType.firefox:
                        //important note: for Selenium 2.53 highest working FF version is 46
                        System.Environment.SetEnvironmentVariable("webdriver.firefox.driver", @"C:\Program Files\Mozilla Firefox\firefox.exe");
                        driver = new FirefoxDriver();
                        break;

                    case BrowserType.ie:
                        driver = new InternetExplorerDriver();
                        break;
                }

                waitDriver = new WebDriverWait(driver, TimeSpan.FromSeconds(Timeout));
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Timeout));
            }

            return driver;
        }

        public static String GetTitle()
        {
            return driver.Title;
        }

        public static String GetUrl()
        {
            return driver.Url;
        }

        public void DeleteCookies()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

        public void OpenPage(String url)
        {
            driver.Navigate().GoToUrl(url);
            SeleniumWait.WaitForUrl(url);
        }

        public static void SetDefaultWaitTimeout()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Timeout));
        }

        public static void ChangeWaitTimeout(int seconds)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
        }

        public static void IgnoreTestOnProduction(string testName)
        {
            if (TestConfiguration.PageMainUrl.Contains(AppEnv2URLConverter.ToString(ApplicationEnvironment.Prod)) &&
                TestConfiguration.IgnoredTestsOnProduction.Contains(testName))
            {
                string msg_ign = "Ignored test " + testName + " on production environment";
                Console.WriteLine(msg_ign);
                Assert.Ignore(msg_ign);
            }
        }

        public static void SkipTestIfCategoryNotAllowedForEnv(string testName, ArrayList testCategories)
        {
            if (testCategories == null)
                return;

            String[] confCategoryDataArray = TestConfiguration.SkipCategoryForEnv.Split(';');
            String currentEnv = AppURL2EnvConverter.toEnv(TestConfiguration.PageMainUrl).ToString();

            bool skipTest;
            string msg_ign = "Ignored test " + testName + " due to configuration for environment " + currentEnv;

            foreach (String testCategory in testCategories)
            {
                foreach (String confCategory in confCategoryDataArray)
                {
                    String confCatName = confCategory.Split(':')[0];
                    String confEnvList = confCategory.Split(':')[1];

                    if (confCatName.Equals(testCategory))
                    {
                        if (confEnvList.Contains("All-"))
                        {
                            confEnvList = confEnvList.Substring(4);
                            skipTest = true;

                            foreach (String confEnv in confEnvList.Split(','))
                            {
                                if (confEnv.Equals(currentEnv))
                                {
                                    skipTest = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            skipTest = false;

                            foreach (String confEnv in confEnvList.Split(','))
                            {
                                if (confEnv.Equals(currentEnv))
                                {
                                    skipTest = true;
                                    break;
                                }
                            }
                        }

                        if (skipTest)
                        {
                            Console.WriteLine(msg_ign);
                            Assert.Ignore(msg_ign);
                        }

                        break;
                    }
                }
            }
        }

        //Controlling connection availability
        private static bool isMainThreadSuspended = false;
        private static bool isTimedEventRunning = false;
        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (isTimedEventRunning == true)
            {
                return;
            }

            isTimedEventRunning = true;

            timerServerConnection.Enabled = false;
            HttpWebResponse response = null;
            HttpWebRequest request;
            for (int i = 1, end = 20; i <= end; ++i)
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(pageDefaultUrl);
                    request.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    request.Timeout = 15000;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response == null || response.StatusCode != HttpStatusCode.OK)
                    {
                        Console.WriteLine("Cannot connect to web site at {0}", DateTime.Now.ToString());
                    }
                    else
                    {
                        response.Close();
                        if (mainThread.ThreadState.ToString().Contains(ThreadState.Suspended.ToString()) ||
                            mainThread.ThreadState.ToString().Contains(ThreadState.SuspendRequested.ToString()))
                        {
                            Console.WriteLine("Connected at {0}", DateTime.Now.ToString());
                            mainThread.Resume();
                            isMainThreadSuspended = false;
                        }
                        else if (isMainThreadSuspended)
                            Console.WriteLine("Special situation in OnTimedEvent: {0}", mainThread.ThreadState.ToString());

                        timerServerConnection.Enabled = true;
                        isTimedEventRunning = false;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Cannot connect to web site at {0}", DateTime.Now.ToString());
                }

                if (mainThread.ThreadState == ThreadState.Running || mainThread.ThreadState == ThreadState.Background)
                {
                    mainThread.Suspend();
                    isMainThreadSuspended = true;
                }

                Thread.Sleep(30000);
                if (response != null)
                    response.Close();

                if (i == end)
                {
                    ignoreCurrentTest = true;
                }
            }

            isTimedEventRunning = false;
        }
    }
}
