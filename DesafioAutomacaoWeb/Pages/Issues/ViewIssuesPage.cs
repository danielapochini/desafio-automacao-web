using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace DesafioAutomacaoWeb.Pages.Issues
{
    public class ViewIssuesPage : PageBase
    {
        #region WebElements

        private IWebElement BugLink => GenericHelper.GetElement(By.LinkText("0000005"));
        private IWebElement HandlerSelect => GenericHelper.GetElement(By.XPath("//select[@name='handler_id']"));
        private IWebElement ActionSelect => GenericHelper.GetElement(By.XPath("//select[@name='action']"));
        private IWebElement AllIssuesCheckBox => GenericHelper.GetElement(By.Id("bug_arr_all"));
        private IWebElement AssignButton => GenericHelper.GetElement(By.XPath("//input[@value='Assign To:']"));
        private IWebElement OkButton => GenericHelper.GetElement(By.XPath("//input[@value='OK']"));
        private IWebElement UpdateButton => GenericHelper.GetElement(By.XPath("//input[@value='Update Severity']"));
        private IWebElement AssignedToText => GenericHelper.GetElement(By.XPath("//td[@class='bug-assigned-to']"));
        private ReadOnlyCollection<IWebElement> SeverityText => GenericHelper.GetElements(By.XPath("//td[@class='column-severity']"));

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

        public ReadOnlyCollection<IWebElement> ReturnSeverityColumnValues()
        {
            return SeverityText; 
        }

        #endregion Actions
    }
}