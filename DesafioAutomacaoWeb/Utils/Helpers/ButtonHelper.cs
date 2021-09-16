using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Utils.Helpers
{
    public class ButtonHelper
    {
        public static bool CheckButtonDisplayed(IWebElement webElement)
        {
            bool isDisplayed = false;
            try
            {
                isDisplayed = webElement.Displayed;
            }
            catch { }

            return isDisplayed;
        }

    }
}
