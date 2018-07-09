using System;

namespace VoloteaUIAutomation.Utilities.Enums
{
    struct UrlPrefix
    {
        public static readonly String Prod = "https://www";
        public static readonly String CI = "http://ci.";
        public static readonly String Pre1 = "http://pre1.";
        public static readonly String Pre2 = "http://pre2.";
        public static readonly String Pre3 = "http://pre3.";
        public static readonly String Pre4 = "http://pre4.";
        public static readonly String Pre5 = "http://pre5.";
        public static readonly String Pre6 = "http://pre6.";
    }

    public enum ApplicationEnvironment
    {
        Prod,
        CI,
        Pre1,
        Pre2,
        Pre3,
        Pre4,
        Pre5,
        Pre6
    }

    public static class AppEnv2URLConverter
    {
        public static string ToString(ApplicationEnvironment type)
        {
            string urlPrefix = "";
            string urlDomain = "volotea.com/";

            switch (type)
            {
                case ApplicationEnvironment.Prod: urlPrefix = UrlPrefix.Prod; break;
                case ApplicationEnvironment.CI: urlPrefix = UrlPrefix.CI; break;
                case ApplicationEnvironment.Pre1: urlPrefix = UrlPrefix.Pre1; break;
                case ApplicationEnvironment.Pre2: urlPrefix = UrlPrefix.Pre2; break;
                case ApplicationEnvironment.Pre3: urlPrefix = UrlPrefix.Pre3; break;
                case ApplicationEnvironment.Pre4: urlPrefix = UrlPrefix.Pre4; break;
                case ApplicationEnvironment.Pre5: urlPrefix = UrlPrefix.Pre5; break;
                case ApplicationEnvironment.Pre6: urlPrefix = UrlPrefix.Pre6; break;
                default:
                    throw new Exception("AppEnv2URLConverter. Cannot convert given ApplicationEnvironment: "
                                        + type.ToString() + " to string");
            }

            return urlPrefix + urlDomain;
        }
    }

    public static class AppURL2EnvConverter
    {
        public static ApplicationEnvironment toEnv(String url)
        {
            if (url.Contains(UrlPrefix.Prod))
                return ApplicationEnvironment.Prod;
            if (url.Contains(UrlPrefix.CI))
                return ApplicationEnvironment.CI;
            if (url.Contains(UrlPrefix.Pre1))
                return ApplicationEnvironment.Pre1;
            if (url.Contains(UrlPrefix.Pre2))
                return ApplicationEnvironment.Pre2;
            if (url.Contains(UrlPrefix.Pre3))
                return ApplicationEnvironment.Pre3;
            if (url.Contains(UrlPrefix.Pre4))
                return ApplicationEnvironment.Pre4;
            if (url.Contains(UrlPrefix.Pre5))
                return ApplicationEnvironment.Pre5;
            if (url.Contains(UrlPrefix.Pre6))
                return ApplicationEnvironment.Pre6;

            throw new Exception("AppURL2EnvConverter. Cannot convert given url: "
                                + url + " to environment");
        }
    }
}
