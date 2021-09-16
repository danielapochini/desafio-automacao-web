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
         
        #endregion

        #region Actions

        public void CreateNewUser(string username, string realname, string email, string accessValue, bool enabledCheck, bool protectedCheck)
        {
            UsernameTextBox.SendKeys(username);
            RealNameTextBox.SendKeys(realname);
            EmailTextBox.SendKeys(email);
            ComboBoxHelper.SelectElement(AccessLevelSelect, accessValue);
            CheckEnabledCheckBox(enabledCheck);
            CheckProtectedCheckBox(protectedCheck);
            SubmitForm();
        }

        public void FillOnlyUsername(string username)
        {
            UsernameTextBox.SendKeys(username);
            SubmitForm();
        } 
           

        public void CheckEnabledCheckBox(bool value)
        {
            CheckBoxHelper.CheckCheckBoxJavascript(value, EnabledCheckBox);
        }

        public void CheckProtectedCheckBox(bool value)
        {
            CheckBoxHelper.CheckCheckBoxJavascript(value, ProtectedCheckBox);
        }

        public void SubmitForm()
        {
            SubmitButton.Submit();
        }
         
        #endregion

        #region Navigation
        #endregion
    }
}
