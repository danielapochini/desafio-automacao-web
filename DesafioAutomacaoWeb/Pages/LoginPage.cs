using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Pages
{
    public class LoginPage : PageBase
    {
        #region WebElements 
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement LoginTextBox;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement PasswordTextBox;

        [FindsBy(How = How.XPath, Using = "//input[@value= 'Login']")]
        private IWebElement LoginButton;


        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Your account may be disabled or blocked or the use')]")]
        private IWebElement LoginErrorMessage;

        [FindsBy(How = How.LinkText, Using = "Lost your password?")]
        private IWebElement LostPwdLink;

        
        #endregion

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
            var text = GenericHelper.GetElementText(LoginErrorMessage);
            return text;
        }

        #endregion

        #region Navigation

        #endregion
    }
}
