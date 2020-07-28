using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsRoyale.SeleniumFramework.Utils
{
    public static class WaitUtils
    {

        public static Boolean isVisible(IWebDriver driver, TimeSpan maximumTimeToWait, By locator)
        {

            WebDriverWait wait = new WebDriverWait(driver, maximumTimeToWait);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));

            return wait.Until(drv => drv.FindElement(locator).Displayed);
        }
        public static Boolean isNotVisible(IWebDriver driver, TimeSpan timeout, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));

            return wait.Until(drv => !drv.FindElement(locator).Displayed);
        }
        public static Boolean isPresent(IWebDriver driver, TimeSpan timeout, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));

            return wait.Until(drv => drv.FindElements(locator).Count > 0);
        }
        public static Boolean isTextPresent(IWebDriver driver, TimeSpan timeout, By locator, string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));

            return wait.Until(drv => drv.FindElement(locator).Text.Equals(text));
        }
        public static Boolean isAttrubuteContains(IWebDriver driver, TimeSpan timeout, By locator, string attributeName, string text)
        {

            WebDriverWait wait = new WebDriverWait(driver, timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));

            return wait.Until(drv => drv.FindElement(locator).GetAttribute(attributeName).Contains(text));
        }
        public static IWebElement waitForElement(IWebDriver driver, TimeSpan timeout, By locator)
        {
            IWebElement elem = null;
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));

            if (wait.Until(drv => drv.FindElements(locator).Count > 0) == true)
            {
                elem = driver.FindElement(locator);
            }
            return elem;
        }
        public static IList<IWebElement> waitForElements(IWebDriver driver, TimeSpan timeout, By locator)
        {
            IList<IWebElement> listOfElems = null;
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));
            wait.Message = String.Format("no such element matching {0}", locator.ToString());

            if (wait.Until(drv => drv.FindElements(locator).Count > 0) == true)
            {
                listOfElems = driver.FindElements(locator);
            }


            return listOfElems;
        }
    }
}
