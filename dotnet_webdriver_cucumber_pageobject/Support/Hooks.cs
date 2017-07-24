using System;
using System.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace ToproomsAutomation.Support
{
    [Binding]
    public class Hooks
    {
        public static RemoteWebDriver Driver = null;

        [BeforeScenario]
        public void InitialiseDriver()
        {
            Driver = Driver ?? StartDriver(ConfigurationManager.AppSettings["Browser"]);
            ScenarioContext.Current.Set(Driver, "currentDriver");
            ScenarioContext.Current.Set(Driver, "defaultDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                ScenarioContext.Current.Get<RemoteWebDriver>("currentDriver").Quit();
                Driver = null;
            }
            ScenarioContext.Current.Clear();

        }

        [AfterTestRun]
        public static void StopSeleniumAfterAllTests()
        {
            Driver?.Quit();
        }

        public static RemoteWebDriver StartDriver(string driverType)
        {
            RemoteWebDriver driver;

            switch (driverType)
            {
                case "ie":
                    driver = new InternetExplorerDriver();
                    Console.WriteLine("Started on IE");
                    break;
                case "chrome":
                    driver = new ChromeDriver();
                    Console.WriteLine("Started on Chrome");
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    Console.WriteLine("Started on Firefox");
                    break;
                default:
                    throw new ConfigurationErrorsException("Browser app config was not set properly");
            }

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("about:blank");
            return driver;
        }


    }
}
