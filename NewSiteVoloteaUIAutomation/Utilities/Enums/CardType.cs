using System;

namespace VoloteaUIAutomation.Utilities.Enums
{
    public enum CardType
    {
        Visa,
        VisaDebit,
        MasterCard
    }

    public static class CardTypeHelper
    {
        public static String GetWorkingOnTestCardNumber4CardType(CardType type)
        {
            switch (type)
            {
                case CardType.Visa: return "4012 0010 2100 0605";
                case CardType.VisaDebit: return "4877 0012 1234 1234";
                case CardType.MasterCard: return "5210 0000 1000 1001";
                default:
                    throw new Exception("CardTypeHelper. Cannot convert given AvailableMotnhs: " + type.ToString() + " to string");
            }
        }
    }
}
