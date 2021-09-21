using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;

namespace DesafioAutomacaoWeb.Pages
{
    public class ViewIssuesPage : PageBase
    {
        #region WebElements

        private IWebElement BugLink => ObjectRepository.Driver.FindElement(By.LinkText("0000005"));
        private IWebElement HandlerSelect => ObjectRepository.Driver.FindElement(By.XPath("//select[@name='handler_id']"));
        private IWebElement ActionSelect => ObjectRepository.Driver.FindElement(By.XPath("//select[@name='action']"));
        private IWebElement AllIssuesCheckBox => ObjectRepository.Driver.FindElement(By.Id("bug_arr_all"));
        private IWebElement AssignButton => ObjectRepository.Driver.FindElement(By.XPath("//input[@value='Assign To:']"));
        private IWebElement OkButton => ObjectRepository.Driver.FindElement(By.XPath("//input[@value='OK']"));
        private IWebElement UpdateButton => ObjectRepository.Driver.FindElement(By.XPath("//input[@value='Update Severity']"));
        private IWebElement AssignedToText => ObjectRepository.Driver.FindElement(By.XPath("//td[@class='bug-assigned-to']"));
        private IWebElement SeverityText => ObjectRepository.Driver.FindElement(By.XPath("//td[@class='column-severity']"));

        #endregion WebElements

        #region Actions

        public void AssignBug()
        {
            BugLink.Click();
            ComboBoxHelper.SelectElement(HandlerSelect, "test.developer");
            AssignButton.Click();
        }

        public void UpdateBug()
        {
            JavaScriptExecutorHelper.CheckCheckBoxJavascript(true, AllIssuesCheckBox);
            ComboBoxHelper.SelectElement(ActionSelect, "Update Severity");
            OkButton.Click();
            UpdateButton.Click();
        }

        public void ViewBug()
        {
            BugLink.Click();
        }

        public string ReturnAssigneeName()
        {
            return AssignedToText.Text.Trim();
        }

        public string ReturnSeverityValue()
        {
            return SeverityText.Text.Trim();
        }

        #endregion Actions
    }
}