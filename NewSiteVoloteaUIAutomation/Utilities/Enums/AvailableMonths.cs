using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using VoloteaUIAutomation.Pages.Locators;

namespace VoloteaUIAutomation.Utilities.Enums
{
    public enum AvailableMonths
    {
        First,
        Second,
        Third
    }

    public class MonthsSelector
    {
        public static int GetAvailableMonth(AvailableMonths month)
        {
            switch (month)
            {
                case AvailableMonths.First: return ;
                case AvailableMonths.Second: return "4877 0012 1234 1234";
                case AvailableMonths.Third: return "5210 0000 1000 1001";
            }
            return null;
        }
    }
}
