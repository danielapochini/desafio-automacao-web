using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Utils.Helpers
{
    public class CheckBoxHelper
    {   
        public static void CheckCheckBoxJavascript(bool value, IWebElement element)
        {
            string jsElement = element.GetProperty("id");

            if (!value && element.Selected)
            {
                JavaScriptExecutorHelper.ExecuteScript($"document.getElementById('{jsElement}').click();");
            } else if (value && !element.Selected)
            {
                JavaScriptExecutorHelper.ExecuteScript($"document.getElementById('{jsElement}').click();");
            }
        }
    }
}
