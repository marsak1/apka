using OpenQA.Selenium;
using VoloteaUIAutomation.Utilities;

namespace VoloteaUIAutomation.Tools.IO
{
    public class Navigate : SeleniumExecutor
    {
        public void SendData(IWebElement c, string text)
        {
            ScrollToElement(c, GetDriver());
            c.Clear();
            c.SendKeys(text);
        }

        public void ScrollAndClick(IWebElement c)
        {
            ScrollToElement(c, GetDriver());
            c.Click();
        }

        public static IWebElement ScrollToElement(IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

            return element;
        }

        public static void Scroll(IWebElement e)
        {
            ScrollToElement(e, GetDriver());
        }

        public static void ScrollDown(IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,250)", "");
        }
    }
}
