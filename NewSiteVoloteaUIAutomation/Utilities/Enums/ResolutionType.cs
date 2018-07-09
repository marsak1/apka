using System;
using System.Drawing;

namespace VoloteaUIAutomation.Utilities.Enums
{
    public enum ResolutionType
    {
        web,
        tablet,
        mobile
    }

    public static class ResolutionTypeHelper
    {
        public static void SetResolution4Browser(ResolutionType type)
        {
            if (SeleniumExecutor.GetDriver() == null)
                throw new Exception("Driver is null in function ResolutionTypeHelper.SetResolution4Browser");

            switch (type)
            {
                case ResolutionType.web: SeleniumExecutor.GetDriver().Manage().Window.Maximize(); break;
                case ResolutionType.tablet: SeleniumExecutor.GetDriver().Manage().Window.Size = new Size(974, 1200); break;
                case ResolutionType.mobile: SeleniumExecutor.GetDriver().Manage().Window.Size = new Size(400, 700); break;
                default:
                    throw new Exception("ResolutionTypeHelper. Cannot find ResolutionType: " + type.ToString());
            }
        }
    }
}
