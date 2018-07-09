using OpenQA.Selenium;
using System;
using System.Linq;

namespace VoloteaUIAutomation.Utilities.Helpers
{
    class PriceConverter
    {
        public static double ConvertPriceToDouble(IWebElement locator)
        {
            string text = SeleniumGetText.GetTextFromElementEx(locator);
            text = text.Substring(0, text.IndexOf('€')).Trim();
            double price = Math.Round(Double.Parse(text, System.Globalization.CultureInfo.InvariantCulture), 2);
            return price;
        }
        public static double ConvertPriceToDouble(string priceString)
        {
            string text = priceString.Split(' ').FirstOrDefault(x => x.Contains('€'));
            text = text.Substring(0, text.IndexOf('€')).Trim();
            double price = Math.Round(Double.Parse(text, System.Globalization.CultureInfo.InvariantCulture), 2);
            return price;
        }
    }
}
