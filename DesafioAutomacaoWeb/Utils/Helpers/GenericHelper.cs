using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace DesafioAutomacaoWeb.Utils.Helpers
{
    public static class GenericHelper
    {
        private static IWebElement element;

        public static void ClearTextBox(IWebElement element)
        {
            element.Clear();
        }

        public static void ClickElement(string userId)
        {
            element = GetElement(By.LinkText(userId));
            element.Click();
        }

        public static IWebElement CheckElement(string userId)
        {
            element = GetElement(By.LinkText(userId));
            return element;
        }

        public static IWebElement CheckElementFromTable(string elementValue)
        {
            return element = GetElement(By.XPath($"//td[contains(text(),'{elementValue}')]"));
        }

        public static IWebElement GetElement(By locator)
        {
            if (IsElementPresent(locator))
            {
                return ObjectRepository.Driver.FindElement(locator);
            }

            throw new NoSuchElementException("Element Not Found : " + locator);
        }

        public static string GetElementText(IWebElement element)
        {
            return element.Text;
        }

        public static bool IsElementPresent(By locator)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait =
                TimeSpan.FromMilliseconds(400);
            try
            { 
                return ObjectRepository.Driver.FindElements(locator).Count == 1;
            }
            catch (NoSuchElementException)
            { 
                return false;
            }
        }
         
        public static bool IsElementPresent(IWebElement element)
        { 
            try
            { 
                return element.Displayed;
            } 
            catch (NoSuchElementException)
            { 
                return false;
            }
        } 
         
    }
}