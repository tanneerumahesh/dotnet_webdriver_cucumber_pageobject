using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ToproomsAutomation.PageObjects
{
    public class SearchResultsPage
    {
        public SearchResultsPage(ISearchContext driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".propertyName")]
        public IList<IWebElement> SearchResults;

    }
}
