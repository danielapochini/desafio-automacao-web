using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;

namespace DesafioAutomacaoWeb.Pages.Login
{
    public class LoginPage : PageBase
    {
        #region WebElements

        private IWebElement LoginTextBox => GenericHelper.GetElement(By.Id("username"));
        private IWebElement PasswordTextBox => GenericHelper.GetElement(By.Id("password"));
        private IWebElement LoginButton => GenericHelper.GetElement(By.XPath("//input[@value= 'Login']"));
        private IWebElement LoginErrorMessage => GenericHelper.GetElement(By.XPath("//p[contains(text(),'Your account may be disabled or blocked or the use')]"));
        private IWebElement LostPwdLink => GenericHelper.GetElement(By.LinkText("Lost your password?"));

        #endregion WebElements

        #region Actions

        public HomePage DoLogin(string username, string password)
        {
            FillLoginTextBox(username);
            FillPasswordTextBox(password);
            return new HomePage();
        }
         
        public void FillLoginTextBox(string username)
        {
            LoginTextBox.SendKeys(username);
            LoginButton.Click();
        }

        public void FillPasswordTextBox(string password)
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

        #region Navigation 
        public LostPasswordPage NavigateToLostPassword()
        {
            LostPwdLink.Click();
            return new LostPasswordPage();
        }
        #endregion Navigation
    }
}