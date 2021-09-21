using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;

namespace DesafioAutomacaoWeb.Pages
{
    public class LoginPage : PageBase
    {
        #region WebElements

        private IWebElement LoginTextBox => ObjectRepository.Driver.FindElement(By.Id("username"));
        private IWebElement PasswordTextBox => ObjectRepository.Driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => ObjectRepository.Driver.FindElement(By.XPath("//input[@value= 'Login']"));
        private IWebElement LoginErrorMessage => ObjectRepository.Driver.FindElement(By.XPath("//p[contains(text(),'Your account may be disabled or blocked or the use')]"));
        private IWebElement LostPwdLink => ObjectRepository.Driver.FindElement(By.LinkText("Lost your password?"));

        #endregion WebElements

        #region Actions

        public HomePage Login(string username, string password)
        {
            FillLogin(username);
            FillPassword(password);
            return new HomePage();
        }

        public LostPasswordPage LostPassword()
        {
            LostPwdLink.Click();
            return new LostPasswordPage();
        }

        public void FillLogin(string username)
        {
            LoginTextBox.SendKeys(username);
            LoginButton.Click();
        }

        public void FillPassword(string password)
        {
            PasswordTextBox.SendKeys(password);
            LoginButton.Click();
        }

        public string ReturnErrorMessage()
        {
            string text = GenericHelper.GetElementText(LoginErrorMessage);
            return text;
        }

        #endregion Actions
    }
}