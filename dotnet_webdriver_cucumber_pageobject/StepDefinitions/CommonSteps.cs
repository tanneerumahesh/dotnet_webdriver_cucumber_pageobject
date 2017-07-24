using System.Configuration;
using TechTalk.SpecFlow;
using ToproomsAutomation.Support;

namespace ToproomsAutomation.StepDefinitions
{
    public class CommonSteps : BaseStep
    {

        [Given(@"I am on home page")]
        public void GivenIAmOnHomePage()
        {
            NavigateToUrl(ConfigurationManager.AppSettings["url"]);
        }
    }
}
