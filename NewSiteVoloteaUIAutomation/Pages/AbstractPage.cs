using VoloteaUIAutomation.Utilities;

namespace VoloteaUIAutomation.Pages
{
    public abstract class AbstractPage
    {
        public SeleniumExecutor executor;

        public AbstractPage(SeleniumExecutor executor)
        {
            this.executor = executor;
            
        }
    }
}
