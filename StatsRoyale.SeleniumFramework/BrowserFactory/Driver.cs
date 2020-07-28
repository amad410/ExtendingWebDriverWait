using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsRoyale.SeleniumFramework.BrowserFactory
{
    public static class Driver
    {
        //static IWebdriver field with an annotation that specifies that it is unique for each thread
        [ThreadStatic]
        private static IWebDriver _driver;

        public static void Init()
        {
            _driver = new ChromeDriver();
             _driver.Manage().Window.Maximize();
            
            //This is the global rule for all elements
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);

           
           


        }
        public static void GoTo(string url)
        {
            try
            {
                Current.Url = url;
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new Exception("Failed to load within 3 secs. Exception is " + ex.Message);
            }
        }

        public static IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }
        public static IList<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("driver is null");


    }
}
