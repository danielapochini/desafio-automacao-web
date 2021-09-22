using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;

namespace DesafioAutomacaoWeb.Pages.Login
{
    public class LostPasswordPage : PageBase
    {
        #region WebElements

        private IWebElement LoginTextBox => GenericHelper.GetElement(By.Id("username"));
        private IWebElement EmailTextBox => GenericHelper.GetElement(By.Id("email-field"));
        private IWebElement SubmitButton => GenericHelper.GetElement(By.XPath("//input[@value= 'Submit']"));

        #endregion WebElements

        #region Actions

        public void FillEmail(string email)
        {
            EmailTextBox.SendKeys(email);
            SubmitButton.Click();
        }

        public void ClearUsername()
        {
            LoginTextBox.Clear();
        }

        #endregion Actions
    }
}