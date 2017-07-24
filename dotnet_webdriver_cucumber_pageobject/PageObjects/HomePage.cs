using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ToproomsAutomation.PageObjects
{
    public class HomePage
    {
        public HomePage(ISearchContext driver)
        {
            PageFactory.InitElements(driver, this);
        }



        [FindsBy(How = How.CssSelector, Using = "#eviivo-search-button")]
        public IWebElement SearchButton;

        [FindsBy(How = How.CssSelector, Using = "#eviivo-search-start-date")]
        public IWebElement CheckinButton;

        [FindsBy(How = How.CssSelector, Using = "#eviivo-search-end-date")]
        public IWebElement CheckOutButton;

        [FindsBy(How = How.CssSelector, Using = ".ui-datepicker-prev")]
        public IWebElement CalenderPreviousButton;

        [FindsBy(How = How.CssSelector, Using = ".ui-datepicker-next")]
        public IWebElement CalenderNextButton;

        [FindsBy(How = How.CssSelector, Using = ".ui-datepicker-year")]
        public IWebElement CalenderYear;

        [FindsBy(How = How.CssSelector, Using = ".ui-datepicker-month")]
        public IWebElement CalenderMonth;

        [FindsBy(How = How.CssSelector, Using = "[data-handler='selectDay'] a")]
        public IList<IWebElement> CalenderAvailableDates;

        [FindsBy(How = How.CssSelector, Using = "#eviivo-search-destination")]
        public IWebElement SearchBar;

        [FindsBy(How = How.CssSelector, Using = ".ui-autocomplete:nth-child(2)>li")]
        public IList<IWebElement> LocationOptions;

        [FindsBy(How = How.CssSelector, Using = "#eviivo-search-destination-tooltip .column-outer")]
        public IWebElement SearchError;






        public void SelectDateFromDatePicker(DateTime dateTime)
        {
            while (DateTime.ParseExact(CalenderMonth.Text, "MMMM", CultureInfo.CurrentCulture).Month != dateTime.Month &&
               Convert.ToInt32(CalenderYear.Text) != dateTime.Year)
            {
                CalenderNextButton.Click();
            }

            CalenderAvailableDates.FirstOrDefault(dt => dt.Text == dateTime.Day.ToString())?.Click();
        }

        public void EnterSearchTerm(string searchText)
        {
            SearchBar.Clear();
            SearchBar.SendKeys(searchText);
        }
    }
}
