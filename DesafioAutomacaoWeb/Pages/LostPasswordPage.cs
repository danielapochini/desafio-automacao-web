using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;

namespace DesafioAutomacaoWeb.Pages
{
    public class LostPasswordPage : PageBase
    {
        #region WebElements

        private IWebElement LoginTextBox => ObjectRepository.Driver.FindElement(By.Id("username"));
        private IWebElement EmailTextBox => ObjectRepository.Driver.FindElement(By.Id("email-field"));
        private IWebElement SubmitButton => ObjectRepository.Driver.FindElement(By.XPath("//input[@value= 'Submit']"));

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