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
    }
}
