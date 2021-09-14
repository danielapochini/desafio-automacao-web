using DesafioAutomacaoWeb.Bases;
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
        #endregion

        #region Actions
        public HomePage Login(string username, string password)
        {
            LoginTextBox.SendKeys(username); 
            LoginButton.Click();
            PasswordTextBox.SendKeys(password);
            LoginButton.Click();
            return new HomePage();
        }
        #endregion

        #region Navigation

        #endregion
    }
}
