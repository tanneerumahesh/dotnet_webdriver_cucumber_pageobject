using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace ToproomsAutomation.Support
{
    public class BaseStep : ProgramUtils
    {
        protected static RemoteWebDriver Driver
        {
            get { return ScenarioContext.Current.Get<RemoteWebDriver>("currentDriver"); }
        }

        public void WaitForPageToLoad()
        {
            GenerateWebDriverWait().Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString().Equals("complete"));
        }

        public void WaitForElement(IWebElement elementLocator)
        {
            GenerateWebDriverWait().Until(d => elementLocator.Displayed);
        }

        public void WaitForElements(IList<IWebElement> elements)
        {
            GenerateWebDriverWait().Until(d => elements.Count > 0);
        }

        public void NavigateToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
            WaitForPageToLoad();
        }

        public string ValueFromTable(Table table, string columHeader, string valueWhereRowNeedsToBeReturned, string columHeaderWhereValueNeedsToBeReturned)
        {
            return table.Rows.First(ee => ee[columHeader].Equals(valueWhereRowNeedsToBeReturned))[columHeaderWhereValueNeedsToBeReturned];
        }

        private WebDriverWait GenerateWebDriverWait(int seconds = 90)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
        }

    }
}
