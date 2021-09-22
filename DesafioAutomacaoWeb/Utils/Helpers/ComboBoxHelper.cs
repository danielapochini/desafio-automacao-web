using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DesafioAutomacaoWeb.Utils.Helpers
{
    public static class ComboBoxHelper
    {
        private static SelectElement select;

        public static void SelectElement(IWebElement element, string visibletext)
        {
            select = new SelectElement(element);
            select.SelectByText(visibletext);
        }

        public static void SelectElement(IWebElement element, int index)
        {
            select = new SelectElement(element);
            select.SelectByIndex(index);
        }
    }
}