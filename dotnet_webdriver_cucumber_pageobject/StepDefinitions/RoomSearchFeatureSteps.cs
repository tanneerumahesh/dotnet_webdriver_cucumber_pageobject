using System.Configuration;
using NUnit.Framework;
using TechTalk.SpecFlow;
using ToproomsAutomation.PageObjects;
using ToproomsAutomation.Support;

namespace ToproomsAutomation.StepDefinitions
{
    [Binding]
    public class RoomSearchFeatureSteps : BaseStep
    {
        private readonly HomePage homePage = new HomePage(Driver);
        private readonly SearchResultsPage searchResultsPage = new SearchResultsPage(Driver);

        [Given(@"I am on home page")]
        public void GivenIAmOnHomePage()
        {
            NavigateToUrl(ConfigurationManager.AppSettings["url"]);
        }

        [When(@"I select checkin date as '(.*)'")]
        public void WhenISelectCheckinDateAs(string idate)
        {

            homePage.CheckinButton.Click();
            WaitForElement(homePage.CalenderPreviousButton);
            homePage.SelectDateFromDatePicker(ConvertStringToDate(idate));

        }

        [When(@"I select checkout date as '(.*)'")]
        public void WhenISelectCheckoutDateAs(string idate)
        {
            homePage.CheckOutButton.Click();
            WaitForElement(homePage.CalenderPreviousButton);
            homePage.SelectDateFromDatePicker(ConvertStringToDate(idate));
        }

        [When(@"I entered location as '(.*)'")]
        public void WhenIEnteredLocationAs(string location)
        {
            homePage.SearchBar.Clear();
            homePage.SearchBar.SendKeys(location);
            WaitForElements(homePage.LocationOptions);
            homePage.LocationOptions[0].Click();

        }

        [When(@"I entered location as '(.*)' in search box")]
        public void WhenIEnteredLocationAsInSearchBox(string location)
        {
            homePage.SearchBar.Clear();
            homePage.SearchBar.SendKeys(location);
        }


        [When(@"I click on search button")]
        public void WhenIClickOnSearchButton()
        {
            homePage.SearchButton.Click();
            WaitForPageToLoad();
        }

        [Then(@"I should see results listed in results page")]
        public void ThenIShouldSeeResultsListedInResultsPage()
        {
            Assert.True(searchResultsPage.SearchResults.Count > 0);
        }


        [Then(@"I should see search error message as '(.*)'")]
        public void ThenIShouldSeeSearchErrorMessageAs(string searcherror)
        {
            Assert.AreEqual(searcherror, homePage.SearchError.Text);
        }

    }
}
