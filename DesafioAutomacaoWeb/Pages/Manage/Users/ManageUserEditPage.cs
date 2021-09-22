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
         
        private IWebElement DeleteUserButton => GenericHelper.GetElement(By.XPath("//input[@value= 'Delete User']"));
        private IWebElement DeleteAccountButton => GenericHelper.GetElement(By.XPath("//input[@value= 'Delete Account']"));
        private IWebElement ResetPasswordButton => GenericHelper.GetElement(By.XPath("//input[@value= 'Reset Password']"));
        private IWebElement UpdateUserButton => GenericHelper.GetElement(By.XPath("//input[@value= 'Update User']"));
        private IWebElement EditUsernameTextBox => GenericHelper.GetElement(By.Id("edit-username"));
        private  IWebElement EditRealnameTextBox => GenericHelper.GetElement(By.Id("edit-realname"));
        private IWebElement EditEmailTextBox => GenericHelper.GetElement(By.Id("email-field"));
        private IWebElement EditAccessLevelSelect => GenericHelper.GetElement(By.Id("edit-access-level"));
          
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
            GenericHelper.ClearElement(EditUsernameTextBox);
            EditUsernameTextBox.SendKeys(username);
            UpdateUserButton.Click();
        }

        public void ClearAllTextBoxFields()
        {
            GenericHelper.ClearElement(EditUsernameTextBox);
            GenericHelper.ClearElement(EditRealnameTextBox);
            GenericHelper.ClearElement(EditEmailTextBox);
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