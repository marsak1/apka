using VoloteaUIAutomation.Utilities.Configurations;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using NewSiteVoloteaUIAutomation.Utilities.Objects;

namespace VoloteaUIAutomation.Utilities.Helpers
{
    public static class SeleniumClick
    {
        public static void ClickWithWait(IWebElement e, string okMessage = "", string exceptionMessage = "")
        {
            if(SeleniumClick.ClickWithWaitEx(e))
            {
                if(okMessage.Length > 0) Console.WriteLine(okMessage);
            }
            else
            {
                if(exceptionMessage.Length > 0)
                    Console.WriteLine(exceptionMessage);
                Assert.Fail(exceptionMessage);
            }
        }

        public static bool ClickWithWaitEx(IWebElement e, bool checkByDisplayed = true, int secondsWait = SeleniumExecutor.Timeout)
        {
            if (checkByDisplayed)
                SeleniumWait.WaitForElementToBeDisplayedEx(e, secondsWait);
            else
                SeleniumWait.WaitForElementToBeEnabledEx(e, secondsWait);

            SeleniumExecutor.ChangeWaitTimeout(0);
            for (int i = 0; i < 2 * secondsWait; ++i)
            {
                if (SeleniumExecutor.ignoreCurrentTest)
                    Assert.Ignore(SeleniumExecutor.ignoreByNoConnection);

                try
                {
                    e.Click();
                    SeleniumExecutor.SetDefaultWaitTimeout();
                    return true;
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(500);
                }
            }

            SeleniumExecutor.SetDefaultWaitTimeout();
            return false;
        }
    }

    public static class SeleniumSendKeys
    {
        public static void SendKeysWithWait(this IWebElement e, String text)
        {
            SeleniumWait.WaitForElementToBeDisplayedEx(e);
            e.SendKeys(text);
        }
    }



    public static class SeleniumClear
    {
        public static void ClearWithWait(this IWebElement e)
        {
            SeleniumWait.WaitForElementToBeDisplayedEx(e);
            SeleniumWait.WaitForElementToBeEnabledEx(e);
            e.Clear();
        }
    }

    public static class SeleniumGetText
    {
        public static string GetTextFromElementEx(IWebElement element)
        {
            SeleniumWait.WaitForElementToBeDisplayedEx(element);
            return element.Text;
        }
    }

    public static class SeleniumFind
    {
        public static IWebElement FindElementWithWait(IWebElement element, By by, int secondsWait = SeleniumExecutor.Timeout)
        {
            SeleniumExecutor.ChangeWaitTimeout(0);
            IWebElement elementFind;
            for (int i = 0; i < 2 * secondsWait; ++i)
            {
                if (SeleniumExecutor.ignoreCurrentTest)
                    Assert.Ignore(SeleniumExecutor.ignoreByNoConnection);

                try
                {
                    elementFind = element.FindElement(by);
                    SeleniumExecutor.SetDefaultWaitTimeout();
                    return elementFind;
                }
                catch (Exception) { }

                System.Threading.Thread.Sleep(500);
            }

            SeleniumExecutor.SetDefaultWaitTimeout();
            return null;
        }

        public static IWebElement FindElementWithWaitShort(IWebElement element, By by, int secondsWait)
        {
            SeleniumExecutor.ChangeWaitTimeout(0);
            IWebElement elementFind;

            for (int i = 0; i < 1 * secondsWait; ++i)
            {
                if (SeleniumExecutor.ignoreCurrentTest)
                    Assert.Ignore(SeleniumExecutor.ignoreByNoConnection);

                try
                {
                    elementFind = element.FindElement(by);
                    SeleniumExecutor.SetDefaultWaitTimeout();
                    return elementFind;
                }
                catch (Exception) { }

                System.Threading.Thread.Sleep(500);
            }

            SeleniumExecutor.SetDefaultWaitTimeout();

            return null;
        }

        public static IWebElement FindElementWithWait(IWebElement element, int secondsWait = SeleniumExecutor.Timeout)
        {
            if (SeleniumWait.WaitForElementToBeDisplayedEx(element, secondsWait))
                return element;
            else
                return null;
        }

        public static IList<IWebElement> FindElementsWithWait(IWebElement element, By by, int secondsWait = SeleniumExecutor.Timeout)
        {
            SeleniumExecutor.ChangeWaitTimeout(0);
            IList<IWebElement> elementsReturn = new List<IWebElement>();
            for (int i = 0; i < 2 * secondsWait; ++i)
            {
                if (SeleniumExecutor.ignoreCurrentTest)
                    Assert.Ignore(SeleniumExecutor.ignoreByNoConnection);

                try
                {
                    elementsReturn = element.FindElements(by);
                    if (elementsReturn.Count > 0)
                        break;
                }
                catch (Exception) { }

                System.Threading.Thread.Sleep(500);
                elementsReturn = new List<IWebElement>();
            }

            SeleniumExecutor.SetDefaultWaitTimeout();
            return elementsReturn;
        }

        public static IWebElement FindElementWithWait(By by, int secondsWait = SeleniumExecutor.Timeout)
        {
            SeleniumExecutor.ChangeWaitTimeout(0);
            IWebElement elementFind;
            IWebDriver driver = SeleniumExecutor.GetDriver();
            for (int i = 0; i < 2 * secondsWait; ++i)
            {
                if (SeleniumExecutor.ignoreCurrentTest)
                    Assert.Ignore(SeleniumExecutor.ignoreByNoConnection);

                try
                {
                    elementFind = driver.FindElement(by);
                    SeleniumExecutor.SetDefaultWaitTimeout();
                    return elementFind;
                }
                catch (Exception) { }

                System.Threading.Thread.Sleep(500);
            }

            SeleniumExecutor.SetDefaultWaitTimeout();
            return null;
        }

        public static IList<IWebElement> FindElementsWithWait(By by, int secondsWait = SeleniumExecutor.Timeout)
        {
            SeleniumExecutor.ChangeWaitTimeout(0);
            IWebDriver driver = SeleniumExecutor.GetDriver();
            IList<IWebElement> elementsReturn = new List<IWebElement>();
            for (int i = 0; i < 2 * secondsWait; ++i)
            {
                if (SeleniumExecutor.ignoreCurrentTest)
                    Assert.Ignore(SeleniumExecutor.ignoreByNoConnection);

                try
                {
                    elementsReturn = driver.FindElements(by);
                    if (elementsReturn.Count > 0)
                        break;
                }
                catch (Exception) { }

                System.Threading.Thread.Sleep(500);
                elementsReturn = new List<IWebElement>();
            }

            SeleniumExecutor.SetDefaultWaitTimeout();
            return elementsReturn;
        }
    }

    public static class SeleniumGetSelect
    {
        public static SelectElement GetSelectElement(IWebElement element)
        {
            SeleniumWait.WaitForElementToBeEnabledEx(element);
            return new SelectElement(element);
        }
    }

    public static class SeleniumWait
    {
        public static void WaitForNoAjaxRequestsPending(this IWebDriver driver)
        {
            WebDriverWait waitDriver = SeleniumExecutor.GetWaitDriver();

            try
            {
                waitDriver.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript(@"return document.readyState").ToString().Equals("complete", StringComparison.InvariantCultureIgnoreCase));
                waitDriver.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript(@"return jQuery.active == 0"));
            }
            catch (Exception e)
            {
                return;
            }

        }

        public static void WaitForAjaxComplete(int maxSeconds)
        {
            bool is_ajax_compete = false;
            for (int i = 1; i <= maxSeconds; i++)
            {
                is_ajax_compete = (bool)((IJavaScriptExecutor)SeleniumExecutor.GetDriver()).ExecuteScript
                ("return jQuery.active == 0");
                if (is_ajax_compete)
                {
                    return;
                }
                System.Threading.Thread.Sleep(1000);
            }
            throw new Exception("Timed out after " + maxSeconds + " seconds");
        }

        public static bool WaitForUrl(string url, int secondsWait = SeleniumExecutor.Timeout)
        {
            SeleniumExecutor.ChangeWaitTimeout(0);
            bool result = false;
            for (int i = 0; i < 2 * secondsWait; ++i)
            {
                if (SeleniumExecutor.ignoreCurrentTest)
                    Assert.Ignore(SeleniumExecutor.ignoreByNoConnection);

                try
                {
                    if (SeleniumExecutor.GetUrl().Equals(url))
                    {
                        result = true;
                        break;
                    }
                }
                catch (Exception) { }

                System.Threading.Thread.Sleep(500);
            }

            SeleniumExecutor.SetDefaultWaitTimeout();
            return result;
        }

        public static bool WaitForElementToBeDisplayedEx(IWebElement e, int secondsWait = SeleniumExecutor.Timeout)
        {
            SeleniumExecutor.ChangeWaitTimeout(0);
            bool result = false;
            for (int i = 0; i < 2 * secondsWait; ++i)
            {
                if (SeleniumExecutor.ignoreCurrentTest)
                    Assert.Ignore(SeleniumExecutor.ignoreByNoConnection);

                try
                {

                    if (e.Displayed)
                    {
                        result = true;
                        break;
                    }
                }
                catch (Exception) { }

                System.Threading.Thread.Sleep(500);
            }

            SeleniumExecutor.SetDefaultWaitTimeout();
            return result;
        }

        public static bool WaitForElementToBeDisplayedExWithException(IWebElement e, string element_str, int secondsWait = SeleniumExecutor.Timeout)
        {
            if (!WaitForElementToBeDisplayedEx(e, secondsWait))
            {
                string err_str = "Cannot reach element: " + element_str;
                Console.WriteLine(err_str);
                throw new Exception(err_str);
            }
            return true;
        }

        public static bool WaitForElementsToBeDisplayedExWithException(IList<IWebElement> e, string element_str, int secondsWait = SeleniumExecutor.Timeout)
        {
            bool result = true;
            SeleniumExecutor.ChangeWaitTimeout(0);

            try
            {
                if (!WaitForElementToBeDisplayedEx(e[0], secondsWait))
                    result = false;
            }
            catch (Exception)
            {
                result = false;
            }

            if (!result)
            {
                string err_str = "Cannot reach element: " + element_str;
                Console.WriteLine(err_str);
                throw new Exception(err_str);
            }

            SeleniumExecutor.SetDefaultWaitTimeout();
            return result;
        }

        public static bool WaitForElementsToBeDisplayedEx(IList<IWebElement> e, int secondsWait = SeleniumExecutor.Timeout)
        {
            bool result = true;
            SeleniumExecutor.ChangeWaitTimeout(0);

            try
            {
                if (!WaitForElementToBeDisplayedEx(e[0], secondsWait))
                    result = false;
            }
            catch (Exception)
            {
                result = false;
            }

            SeleniumExecutor.SetDefaultWaitTimeout();
            return result;
        }

        public static bool WaitForElementToBeEnabledEx(IWebElement e, int secondsWait = SeleniumExecutor.Timeout)
        {
            SeleniumExecutor.ChangeWaitTimeout(0);
            bool result = false;
            for (int i = 0; i < 2 * secondsWait; ++i)
            {
                if (SeleniumExecutor.ignoreCurrentTest)
                    Assert.Ignore(SeleniumExecutor.ignoreByNoConnection);

                try
                {
                    if (e.Enabled)
                    {
                        SeleniumExecutor.SetDefaultWaitTimeout();
                        result = true;
                        break;
                    }
                }
                catch (Exception) { }

                System.Threading.Thread.Sleep(500);
            }

            SeleniumExecutor.SetDefaultWaitTimeout();
            return result;
        }

        public static bool WaitForElementToBeNotDisplayedEx(IWebElement e, int secondsWait = SeleniumExecutor.Timeout)
        {
            try
            {
                for (int i = 0; i < 2 * secondsWait; ++i)
                {
                    if (SeleniumExecutor.ignoreCurrentTest)
                        Assert.Ignore(SeleniumExecutor.ignoreByNoConnection);

                    if (e.Displayed == false)
                        return true;
                    System.Threading.Thread.Sleep(500);
                }
            }
            catch (Exception) { return true; }

            return false;
        }

        public static bool WaitForElementToBeStillNotDisplayed(IWebElement e, int secondsWait = 2)
        {
            bool result = true;
            SeleniumExecutor.ChangeWaitTimeout(0);

            for (int i = 0; i < 2 * secondsWait; ++i)
            {
                if (SeleniumExecutor.ignoreCurrentTest)
                    Assert.Ignore(SeleniumExecutor.ignoreByNoConnection);

                try
                {
                    if (e.Displayed == true)
                    {
                        result = false;
                        break;
                    }
                }
                catch (Exception) { }
                System.Threading.Thread.Sleep(500);
            }

            SeleniumExecutor.SetDefaultWaitTimeout();
            return result;
        }
    }

    public static class SeleniumAlertHandle
    {
        public static void AlertHandle(this IWebDriver driver, bool accept)
        {
            //This method helps to handle confirm popup window
            switch (accept)
            {
                case false:
                    driver.SwitchTo().Alert().Dismiss();
                    break;
                case true:
                    driver.SwitchTo().Alert().Accept();
                    break;
            }
        }
    }

    public static class SeleniumFrame
    {
        public static void SendKeysToFrameAny(this IWebDriver driver, String message)
        {
            driver.SendKeysToFrameNumber(message, 0);
        }

        public static void SendKeysToFrameNumber(this IWebDriver driver, String message, int frameNumber)
        {
            driver.SwitchTo().Frame(driver.FindElements(By.XPath("//iframe"))[frameNumber]);

            IWebElement textInput = driver.FindElement(By.Id("tinymce"));
            textInput.Clear();
            textInput.Click();
            textInput.SendKeys(message);

            driver.SwitchTo().Window(driver.CurrentWindowHandle);
        }

        public static List<String> GetTextListFromFrame(this IWebDriver driver)
        {
            List<String> text = new List<String>();

            IList<IWebElement> elements = driver.FindElements(By.XPath("//iframe"));

            foreach (IWebElement element in elements)
            {
                try
                {
                    if (!text.Any() || text.All(x => string.IsNullOrEmpty(x)))
                    {
                        driver.SwitchTo().Frame(element);
                        IList<IWebElement> textInputs = driver.FindElements(By.TagName("div"));

                        text = textInputs.Select(we => we.Text).ToList();

                        driver.SwitchTo().Window(driver.CurrentWindowHandle);
                    }
                }
                catch (Exception e) { driver.SwitchTo().Window(driver.CurrentWindowHandle); }
            }

            return text;
        }
    }

    public static class SeleniumSwitchWindow
    {
        public static IWebDriver SwitchToWindow(this IWebDriver driver, String windowHandle)
        {
            IWebDriver tmp = driver.SwitchTo().Window(windowHandle);
            try
            {
                Thread.Sleep(500);
            }
            catch (Exception)
            {
            }
            return tmp;
        }

        public static void SwitchToParentWindow(this IWebDriver driver)
        {
            driver.SwitchToWindow(SeleniumExecutor.GetParentWindowHandle());
        }

        public static bool SwitchToAnyNotParentWindow(this IWebDriver driver)
        {
            SeleniumExecutor.SetWindowIterator();
            IEnumerator<String> windowIterator = SeleniumExecutor.GetWindowIterator();
            String parentWindowHandle = SeleniumExecutor.GetParentWindowHandle();

            while (windowIterator.MoveNext())
            {
                String windowHandle = windowIterator.Current;

                if (!windowHandle.Equals(parentWindowHandle))
                {
                    driver.SwitchToWindow(windowHandle);
                    return true;
                }
            }

            driver.SwitchToParentWindow();
            return false;
        }

        public static bool SwitchToWindowWithUrl(this IWebDriver driver, String url)
        {
            if (SeleniumExecutor.GetUrl().Contains(url))
                return true;

            IWebDriver popup = null;
            SeleniumExecutor.SetWindowIterator();
            IEnumerator<String> windowIterator = SeleniumExecutor.GetWindowIterator();

            while (windowIterator.MoveNext())
            {
                String windowHandle = windowIterator.Current;

                popup = driver.SwitchToWindow(windowHandle);
                if (popup.Url.Contains(url))
                {
                    return true;
                }
            }

            driver.SwitchToParentWindow();
            return false;
        }

        public static bool SwitchToWindowWithTitle(this IWebDriver driver, String title)
        {
            if (SeleniumExecutor.GetTitle().Contains(title))
                return true;

            IWebDriver popup = null;
            SeleniumExecutor.SetWindowIterator();
            IEnumerator<String> windowIterator = SeleniumExecutor.GetWindowIterator();

            while (windowIterator.MoveNext())
            {
                String windowHandle = windowIterator.Current;

                popup = driver.SwitchToWindow(windowHandle);
                if (popup.Title.Contains(title))
                {
                    return true;
                }
            }

            driver.SwitchToParentWindow();
            return false;
        }
    }

    public static class SeleniumCloseWindow
    {
        public static void CloseWindow(this IWebDriver driver)
        {
            driver.Close();
            driver.Navigate().GoToUrl("");
        }

        public static void CloseAnyNotParentWindow(this IWebDriver driver)
        {
            while (driver.SwitchToAnyNotParentWindow())
            {
                SeleniumExecutor.GetDriver().Close();
                try
                {
                    Thread.Sleep(500);
                }
                catch (Exception)
                {
                }
            }
            driver.SwitchToParentWindow();
        }
    }

    public static class SeleniumIsWindow
    {
        public static bool IsWindowWithTitlePresent(this IWebDriver driver, String title)
        {
            bool isPresent = false;
            String recentWindow;
            String parentWindowHandle = SeleniumExecutor.GetParentWindowHandle();

            try
            {
                recentWindow = driver.CurrentWindowHandle;
            }
            catch (NoSuchWindowException)
            {
                recentWindow = parentWindowHandle;
            }

            driver.SwitchToWindow(recentWindow);

            if (SeleniumExecutor.GetTitle().Contains(title))
            {
                isPresent = true;
            }
            else
            {
                IWebDriver popup = null;
                SeleniumExecutor.SetWindowIterator();
                IEnumerator<String> windowIterator = SeleniumExecutor.GetWindowIterator();

                while (windowIterator.MoveNext())
                {
                    String windowHandle = windowIterator.Current;

                    popup = driver.SwitchToWindow(windowHandle);
                    if (popup.Title.Contains(title))
                    {
                        isPresent = true;
                        break;
                    }
                }
            }

            driver.SwitchToWindow(recentWindow);
            return isPresent;
        }

        public static bool IsWindowWithUrlPresent(this IWebDriver driver, String url)
        {
            bool isPresent = false;
            String recentWindow;
            String parentWindowHandle = SeleniumExecutor.GetParentWindowHandle();

            try
            {
                recentWindow = driver.CurrentWindowHandle;
            }
            catch (NoSuchWindowException)
            {
                recentWindow = parentWindowHandle;
            }

            driver.SwitchToWindow(recentWindow);

            if (SeleniumExecutor.GetUrl().Contains(url))
            {
                isPresent = true;
            }
            else
            {
                IWebDriver popup = null;
                SeleniumExecutor.SetWindowIterator();
                IEnumerator<String> windowIterator = SeleniumExecutor.GetWindowIterator();

                while (windowIterator.MoveNext())
                {
                    String windowHandle = windowIterator.Current;

                    popup = driver.SwitchToWindow(windowHandle);
                    if (popup.Url.Contains(url))
                    {
                        isPresent = true;
                        break;
                    }
                }
            }

            driver.SwitchToWindow(recentWindow);
            return isPresent;
        }
    }

    public static class SeleniumReporter
    {
        public static void TakeScreenshot(this IWebDriver driver)
        {
            Thread.Sleep(200);
            try
            {
                ITakesScreenshot tsdriver = driver as ITakesScreenshot;
                Screenshot image = tsdriver.GetScreenshot();
                string path = AppVersion.FolderPath + "version.png";
                DeleteScreenshotIfExist(path);
                image.SaveAsFile(path, ImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void TakeScreenshotWithOption(this IWebDriver driver, string flow, string language, string scenarioName, string time, string pageTitle,
                                                    int waitSec, bool makeScreen = true)
        {
            if (makeScreen)
            {
                Thread.Sleep(waitSec * 1000);
                try
                {
                    ITakesScreenshot tsdriver = driver as ITakesScreenshot;
                    Screenshot image = tsdriver.GetScreenshot();

                    string folderPath = TestConfiguration.ScreenshotDirectory + "\\" + TestConfiguration.ResolutionParameter + @" SPA Screenshots"
                                    + "\\" + TestConfiguration.BrowserParameter + "\\" + language + "\\" + scenarioName + "\\" + time + "\\";
                    CreateNewFolder(folderPath);
                    string scrPath = folderPath + pageTitle + ".png";

                    //SecondFlow
                    //string folderFlowPath = TestConfiguration.ScreenshotDirectory + "\\" + TestConfiguration.ResolutionParameter +
                    //    @" SPA ScreenshotFlow" + "\\" + flow + "\\" + scenarioName + "\\" + pageTitle + "\\" + time + "\\";
                    //CreateNewFolder(folderFlowPath);
                    //string scrFlowPath = folderFlowPath + language + ".png";

                    //DeleteScreenshotIfExist(scrPath);
                    image.SaveAsFile(scrPath, ImageFormat.Png);
                    //image.SaveAsFile(scrFlowPath, ImageFormat.Png);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public static void DeleteScreenshotIfExist(String pathWithFileName)
        {
            try
            {
                if (File.Exists(pathWithFileName))
                {
                    File.Delete(pathWithFileName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static string GetScreenshotFullPath(string name)
        {
            return Path.Combine(TestConfiguration.ScreenshotDirectory, String.Format("{0}.png", name));
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

        public static void SaveRecordLocatorToFile(string recordLocator, string date, string scenarioName)
        {

            string folderPath = TestConfiguration.ScreenshotDirectory + $"\\Record Locators\\{DateTime.Today.ToShortDateString().Replace('-', '_')}\\";
            CreateNewFolder(folderPath);

            string textPath = folderPath + scenarioName + ".txt";

            if (!File.Exists(textPath))
            {
                using (StreamWriter sw = File.CreateText(textPath))
                {
                    sw.WriteLine("Email: test@test.pl");
                    sw.WriteLine(recordLocator + " -> First flight date: " + date);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(textPath))
                {
                    sw.WriteLine(recordLocator + " -> First flight date: " + date);
                }
            }
        }
    }

    public static class SeleniumPerform
    {
        public static void PerformMouseover(this IWebElement we)
        {
            IWebDriver driver = SeleniumExecutor.GetDriver();
            Actions action = new Actions(driver);

            action.MoveToElement(we).Perform();
        }

        public static void PerformClick(this IWebElement we)
        {
            IWebDriver driver = SeleniumExecutor.GetDriver();
            Actions action = new Actions(driver);

            action.MoveToElement(we).Click().Perform();
        }
    }

    public static class SeleniumDisplayed
    {
        public static bool isDisplayed(IWebElement we)
        {
            try
            {
                return we.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
