using System;

namespace VoloteaUIAutomation.Utilities.Enums
{
    public enum AvailableMonths
    {
        First,
        Second,
        Third
    }

    public class MonthsSelectorHelper
    {
        public static int GetAvailableMonth(AvailableMonths month)
        {
            switch (month)
            {
                case AvailableMonths.First: return 0;
                case AvailableMonths.Second: return 1;
                case AvailableMonths.Third: return 2;
                default:
                    throw new Exception("MonthsSelectorHelper. Cannot convert given month to int");
            }
        }
    }
}
