using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Pages.Manage.Users
{
    public class ManageUserEditPage : PageBase
    {
        #region WebElements 

        [FindsBy(How = How.XPath, Using = "//input[@value= 'Delete User']")]
        private IWebElement DeleteUserButton;

        [FindsBy(How = How.XPath, Using = "//input[@value= 'Delete Account']")]
        private IWebElement DeleteAccountButton;

        [FindsBy(How = How.XPath, Using = "//input[@value= 'Reset Password']")]
        private IWebElement ResetPasswordButton;

        [FindsBy(How = How.XPath, Using = "//input[@value= 'Update User']")]
        private IWebElement UpdateUserButton;

        [FindsBy(How = How.Id, Using = "edit-username")]
        private IWebElement EditUsernameTextBox;

        [FindsBy(How = How.Id, Using = "edit-realname")]
        private IWebElement EditRealnameTextBox;
         
        [FindsBy(How = How.Id, Using = "email-field")]
        private IWebElement EditEmailTextBox;

        [FindsBy(How = How.Id, Using = "edit-access-level")]
        private IWebElement EditAccessLevelSelect;

        [FindsBy(How = How.Id, Using = "edit-enabled")]
        private IWebElement EditEnabledCheckBox;

        [FindsBy(How = How.Id, Using = "edit-protected")]
        private IWebElement EditProtectedCheckBox;
        #endregion

        public void EditExistingUser()
        {
            ClearAllTextBoxFields();
            EditUsernameTextBox.SendKeys("teste.username");
            EditRealnameTextBox.SendKeys("Nome Alterado");
            EditEmailTextBox.SendKeys("email@valid05.com");
            SelectAcessLevel("developer");
            UpdateUserButton.Click();
        }
        public void FillUsername(string username)
        {
            GenericHelper.ClearTextBox(EditUsernameTextBox);
            EditUsernameTextBox.SendKeys(username);
            UpdateUserButton.Click();
        }

        public void ClearAllTextBoxFields()
        {
            GenericHelper.ClearTextBox(EditUsernameTextBox);
            GenericHelper.ClearTextBox(EditRealnameTextBox);
            GenericHelper.ClearTextBox(EditEmailTextBox);
        }
        public void ClickDeleteUserButton()
        {
            DeleteUserButton.Click();
        }
        
        public void ClickDeleteAccountButton()
        {
            DeleteAccountButton.Click();
        }

        public void ClickResetPasswordButton()
        {
            ResetPasswordButton.Click();
        }
         

        public void SelectAcessLevel(string accessValue)
        {
            ComboBoxHelper.SelectElement(EditAccessLevelSelect, accessValue);
        }

        public bool CheckDeleteAccountButton()
        {
            var value = ButtonHelper.CheckButtonDisplayed(DeleteAccountButton);
            return value;
        }

        public bool CheckResetPasswordButton()
        {
            var value = ButtonHelper.CheckButtonDisplayed(ResetPasswordButton);
            return value;
        }
    }
}
