using DesafioAutomacaoWeb.Utils.Database.Enum;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Utils.Helpers
{
    public class JavaScriptExecutorHelper
    {
        public static object ExecuteScript(string script)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver);
            return executor.ExecuteScript(script);
        }

        public static void TypeTextBoxJavascript(IWebElement element, string text)
        {
            string jsElement = element.GetProperty("id");
            ExecuteScript($"document.getElementById('{jsElement}').value='{text}';"); 
        }

        public static void SelectValueJavascript(IWebElement element, UserAccessLevel value)
        {
            string jsElement = element.GetProperty("id");
            ExecuteScript($"document.getElementById('{jsElement}').value='{(int)value}';");
        }

        public static void SubmitInputJavascript(IWebElement element)
        {
            string jsElement = element.GetProperty("className"); 
            ExecuteScript($"document.getElementsByClassName('{jsElement}')[0].click()");
        }
    }
}
