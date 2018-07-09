using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace VoloteaUIAutomation.Tools.IO
{
    class Inputs
    {
        public static void SelectElementFromDropdown(IWebElement element, string value)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByValue(value);
        }
    }
}
