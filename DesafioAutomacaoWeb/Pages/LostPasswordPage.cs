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
    public class LostPasswordPage : PageBase
    {
        #region WebElements 

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement LoginTextBox;

        [FindsBy(How = How.Id, Using = "email-field")]
        private IWebElement EmailTextBox;

        [FindsBy(How = How.XPath, Using = "//input[@value= 'Submit']")]
        private IWebElement SubmitButton; 
        #endregion

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
         
        #endregion
    }
}
