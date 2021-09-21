using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;

namespace DesafioAutomacaoWeb.Pages.Manage.Users
{
    public class ManageUserEditPage : PageBase
    {
        #region WebElements
         
        private IWebElement DeleteUserButton => ObjectRepository.Driver.FindElement(By.XPath("//input[@value= 'Delete User']"));
        private IWebElement DeleteAccountButton => ObjectRepository.Driver.FindElement(By.XPath("//input[@value= 'Delete Account']"));
        private IWebElement ResetPasswordButton => ObjectRepository.Driver.FindElement(By.XPath("//input[@value= 'Reset Password']"));
        private IWebElement UpdateUserButton => ObjectRepository.Driver.FindElement(By.XPath("//input[@value= 'Update User']"));
        private IWebElement EditUsernameTextBox => ObjectRepository.Driver.FindElement(By.Id("edit-username"));
        private  IWebElement EditRealnameTextBox => ObjectRepository.Driver.FindElement(By.Id("edit-realname"));
        private IWebElement EditEmailTextBox => ObjectRepository.Driver.FindElement(By.Id("email-field"));
        private IWebElement EditAccessLevelSelect => ObjectRepository.Driver.FindElement(By.Id("edit-access-level"));
          
        #endregion WebElements

        #region Actions
        public void EditExistingUser(string username, string realname, string email, string accessLevel)
        {
            ClearAllTextBoxFields();
            EditUsernameTextBox.SendKeys(username);
            EditRealnameTextBox.SendKeys(realname);
            EditEmailTextBox.SendKeys(email);
            SelectAccessLevel(accessLevel);
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

        public void SelectAccessLevel(string accessValue)
        {
            ComboBoxHelper.SelectElement(EditAccessLevelSelect, accessValue);
        }

        public bool CheckDeleteAccountButton()
        {
            bool value = GenericHelper.IsElementPresent(By.XPath("//input[@value= 'Delete Account']"));
            return value;
        }

        public bool CheckResetPasswordButton()
        {
            bool value = GenericHelper.IsElementPresent(By.XPath("//input[@value= 'Reset Password']"));
            return value;
        }

        public string ReturnUsernameWarningBox()
        {
            string warningMessage = ReturnWarningMessage();

            return Regex.Matches(warningMessage, "\\\"(.*?)\\\"").ToString().Trim('"');
        }
        #endregion Actions


    }
}