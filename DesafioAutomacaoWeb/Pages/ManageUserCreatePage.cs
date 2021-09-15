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
    public class ManageUserCreatePage : PageBase
    {
        #region WebElements 
        [FindsBy(How = How.Id, Using = "user-username")]
        private IWebElement UsernameTextBox;

        [FindsBy(How = How.Id, Using = "user-realname")]
        private IWebElement RealNameTextBox;

        [FindsBy(How = How.Id, Using = "email-field")]
        private IWebElement EmailTextBox;

        [FindsBy(How = How.Id, Using = "user-access-level")]
        private IWebElement AccessLevelSelect;

        [FindsBy(How = How.Id, Using = "user-enabled")]
        private IWebElement EnabledCheckBox;

        [FindsBy(How = How.Id, Using = "user-protected")]
        private IWebElement ProtectedCheckBox;

        [FindsBy(How = How.XPath, Using = "//input[@value= 'Create User']")]
        private IWebElement SubmitButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-success center']//p[1]")]
        private IWebElement SuccessMessage;

        #endregion

        #region Actions

        public void CreateNewUser(string username, string realname, string email, string accessValue)
        {
            FillUsername(username);
            FillRealName(realname);
            FillEmail(email);
            SelectAcessLevel(accessValue);
            SubmitForm();
        }

        public void FillUsername(string username)
        {
            UsernameTextBox.SendKeys(username);
        }
        public void FillRealName(string realname)
        {
            RealNameTextBox.SendKeys(realname);
        }
         
        public void FillEmail(string email)
        {
            EmailTextBox.SendKeys(email);
        }

        public void SelectAcessLevel(string accessValue)
        {
            ComboBoxHelper.SelectElement(AccessLevelSelect, accessValue);
        }

        public void CheckEnabledCheckBox()
        {
            EnabledCheckBox.Click();
        }

        public void CheckProtectedCheckBox()
        {
            ProtectedCheckBox.Click();
        }

        public void SubmitForm()
        {
            SubmitButton.Submit();
        }

        public string ReturnSuccessCode()
        {
            var text = GenericHelper.GetElementText(SuccessMessage);
            return text;
        }
        #endregion

        #region Navigation
        #endregion
    }
}
