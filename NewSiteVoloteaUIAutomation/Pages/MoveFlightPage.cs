using OpenQA.Selenium.Support.PageObjects;
using VoloteaUIAutomation.Pages.Locators;
using VoloteaUIAutomation.Utilities;
using VoloteaUIAutomation.Utilities.Helpers;

namespace VoloteaUIAutomation.Pages.Executors
{
    class MoveFlightPage : AbstractPage
    {
        public MoveFlightLocators locators;
        public RefundLinkGenerator refundLinkGenerator = new RefundLinkGenerator();

        public MoveFlightPage(SeleniumExecutor executor)
            : base(executor)
        {
            InitElements();
        }

        public void InitElements()
        {
            locators = new MoveFlightLocators();
            PageFactory.InitElements(SeleniumExecutor.GetDriver(), locators);
        }

        


    }
}
