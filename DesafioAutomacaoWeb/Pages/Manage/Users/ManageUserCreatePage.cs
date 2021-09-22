using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Database.Enum;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;

namespace DesafioAutomacaoWeb.Pages.Manage.Users
{
    public class ManageUserCreatePage : PageBase
    {
        #region WebElements

        private IWebElement UsernameTextBox => GenericHelper.GetElement(By.Id("user-username"));
        private IWebElement RealNameTextBox => GenericHelper.GetElement(By.Id("user-realname"));
        private IWebElement EmailTextBox => GenericHelper.GetElement(By.Id("email-field"));
        private IWebElement AccessLevelSelect => GenericHelper.GetElement(By.Id("user-access-level"));
        private IWebElement EnabledCheckBox => GenericHelper.GetElement(By.Id("user-enabled"));
        private IWebElement ProtectedCheckBox => GenericHelper.GetElement(By.Id("user-protected"));
        private IWebElement SubmitButton => GenericHelper.GetElement(By.XPath("//input[@value= 'Create User']"));

        #endregion WebElements

        #region Actions

        public void CreateNewUser(string username, string realname, string email, string accessValue, bool enabledCheck,
            bool protectedCheck)
        {
            UsernameTextBox.SendKeys(username);
            RealNameTextBox.SendKeys(realname);
            EmailTextBox.SendKeys(email);
            ComboBoxHelper.SelectElement(AccessLevelSelect, accessValue);
            CheckEnabledCheckBox(enabledCheck);
            CheckProtectedCheckBox(protectedCheck);
            SubmitForm();
        }

        public void FillFieldsViaJavascript(string username, string realname, string email, UserAccessLevel accessValue,
            bool enabledCheck, bool protectedCheck)
        {
            JavaScriptExecutorHelper.TypeTextBoxJavascript(UsernameTextBox, username);
            JavaScriptExecutorHelper.TypeTextBoxJavascript(RealNameTextBox, realname);
            JavaScriptExecutorHelper.TypeTextBoxJavascript(EmailTextBox, email);
            JavaScriptExecutorHelper.SelectValueJavascript(AccessLevelSelect, accessValue);
            CheckEnabledCheckBox(enabledCheck);
            CheckProtectedCheckBox(protectedCheck);
            JavaScriptExecutorHelper.SubmitInputJavascript(SubmitButton);
        }

        public void FillOnlyUsername(string username)
        {
            UsernameTextBox.SendKeys(username);
            SubmitForm();
        }

        public void CheckEnabledCheckBox(bool value)
        {
            JavaScriptExecutorHelper.CheckCheckBoxJavascript(value, EnabledCheckBox);
        }

        public void CheckProtectedCheckBox(bool value)
        {
            JavaScriptExecutorHelper.CheckCheckBoxJavascript(value, ProtectedCheckBox);
        }

        public void SubmitForm()
        {
            SubmitButton.Submit();
        }

        #endregion Actions
    }
}