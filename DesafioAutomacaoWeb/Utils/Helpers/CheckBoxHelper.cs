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
        private static IWebElement element;

        public static void CheckedCheckBox(IWebElement element)
        {
            element.Click();
        }
    }
}
