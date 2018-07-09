
using System;

namespace VoloteaUIAutomation.Utilities.Enums
{
    public enum ApplicationElement
    {
        FlightSummary,
        SearchFlight,
        HomePage,
        CalendarPage,
        PassengerContactPage,
        ExtrasComboPage,
        ExtrasSeatMapPage,
        PaymentPage,
        ItineraryPage
    }

    public static class ApplicationElementToPageOrder
    {
        public static int GetApplicationPageOrderInBooking(ApplicationElement page)
        {
            switch(page)
            {
                case ApplicationElement.HomePage: return 1;
                case ApplicationElement.CalendarPage: return 2;
                case ApplicationElement.PassengerContactPage: return 3;
                case ApplicationElement.ExtrasComboPage: return 4;
                case ApplicationElement.ExtrasSeatMapPage: return 5;
                case ApplicationElement.PaymentPage: return 6;
                case ApplicationElement.ItineraryPage: return 7;
                default: throw new Exception("ApplicationElementToPageOrder. Cannot take order from given ApplicationElement: "
                                            + page.ToString());
            }

            return -1;
        }
    }
}
