using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Utils.Helpers
{
    public class GenericHelper
    {
        public static void ClearTextBox(IWebElement element)
        {
            element.Clear();
        }
         
        public static void FillField(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public static IWebElement GetElement(By locator)
        {
            if (IsElementPresent(locator))
                return ObjectRepository.Driver.FindElement(locator);
            else
                throw new NoSuchElementException("Element Not Found : " + locator.ToString());
        }

        public static string GetElementText(IWebElement element)
        {
            WaitForWebElementInPage(element, TimeSpan.FromSeconds(30));
            return element.Text; 
        }

        public static IWebElement GetElement(IWebElement element)
        {
            WaitForWebElementInPage(element, TimeSpan.FromSeconds(30));
            return element;
        }

        public static bool IsElementPresent(By locator)
        {
            try
            {
                return ObjectRepository.Driver.FindElements(locator).Count == 1;
            }
            catch (Exception)
            {
                return false;
            }

        }
          
        public static WebDriverWait GetWebdriverWait(TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            return wait;
        }

        public static IWebElement WaitForWebElementInPage(IWebElement webElement, TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            var wait = GetWebdriverWait(timeout);
            var flag = wait.Until(WaitForWebElementInPageFunc(webElement));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut()));
            return flag;
        }

        private static Func<IWebDriver, IWebElement> WaitForWebElementInPageFunc(IWebElement webElement)
        {
            return ((x) =>
            {
                if (webElement.Displayed)
                    return webElement;
                return null;
            });
        }
    }
}
