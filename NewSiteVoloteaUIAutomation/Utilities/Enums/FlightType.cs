using System;

namespace VoloteaUIAutomation.Utilities.Enums
{
    public enum FlightType
    {
        OneWay,
        RoundTrip,
        MultiCity
    }

    public static class FlightTypeConverter
    {
        public static string ToString(FlightType type, ApplicationElement appElement = ApplicationElement.SearchFlight)
        {
            if (appElement == ApplicationElement.SearchFlight)
            {
                switch (type)
                {
                    case FlightType.OneWay: return "One-way";
                    case FlightType.RoundTrip: return "Return journey";
                    case FlightType.MultiCity: return "Multi-city";
                    default:
                        throw new Exception("FlightTypeConverter. Cannot convert given FlightType: "
                                            + type.ToString() + " to string");
                }
            }
            else if(appElement == ApplicationElement.FlightSummary)
            {
                switch (type)
                {
                    case FlightType.OneWay: return "One-way";
                    case FlightType.RoundTrip: return "Round Trip";
                    case FlightType.MultiCity: return "Multi-city";
                    default:
                        throw new Exception("FlightTypeConverter. Cannot convert given FlightType: "
                                            + type.ToString() + " to string");
                }
            }

            return null;
        }
    }
}
