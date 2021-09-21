using DesafioAutomacaoWeb.Utils.Database.Enum;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;

namespace DesafioAutomacaoWeb.Utils.Helpers
{
    public static class JavaScriptExecutorHelper
    {
        public static object ExecuteScript(string script)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)ObjectRepository.Driver;
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

        public static void CheckCheckBoxJavascript(bool value, IWebElement element)
        {
            string jsElement = element.GetProperty("id");

            if (!value && element.Selected)
            {
                ExecuteScript($"document.getElementById('{jsElement}').click();");
            }
            else if (value && !element.Selected)
            {
                ExecuteScript($"document.getElementById('{jsElement}').click();");
            }
        } 
    }
}