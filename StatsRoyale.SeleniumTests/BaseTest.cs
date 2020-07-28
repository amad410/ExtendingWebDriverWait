using NUnit.Framework;
using OpenQA.Selenium;
using StatsRoyale.SeleniumFramework.BrowserFactory;
using StatsRoyale.SeleniumFramework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsRoyale.SeleniumTests
{
    [TestFixture]
    public class BaseTest
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            //Created a chrome driver and launches chrome
            //driver = new ChromeDriver();
            Driver.Init();
            Pages.Init();
            //This will expand the chrome window
            //driver.Manage().Window.Maximize();
            //Navigate to the website
            //driver.Navigate().GoToUrl("https://statsroyale.com/");
            //Driver.Current.Url = "https://statsroyale.com/";
           
            Driver.GoTo("https://statsroyale.com/");
            driver = Driver.Current;
            //PageLoad load timeout
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            //script load timeout
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(20);

        }

        [TearDown]
        public void Teardown()
        {
            //Close all chrome tabs
            // driver.Quit();
            Driver.Current.Quit();
        }

    }
}
