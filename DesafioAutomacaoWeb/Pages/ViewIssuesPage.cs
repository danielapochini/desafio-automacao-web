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
    public class ViewIssuesPage : PageBase
    {
        #region WebElements
        [FindsBy(How = How.LinkText, Using = "0000005")]
        private IWebElement BugLink;

        [FindsBy(How = How.XPath, Using = "//select[@name='handler_id']")]
        private IWebElement HandlerSelect;

        [FindsBy(How = How.XPath, Using = "//select[@name='action']")]
        private IWebElement ActionSelect;

        [FindsBy(How = How.Id, Using = "bug_arr_all")]
        private IWebElement AllIssuesCheckBox;

        [FindsBy(How = How.XPath, Using = "//input[@value='Assign To:']")]
        private IWebElement AssignButton;

        [FindsBy(How = How.XPath, Using = "//input[@value='OK']")]
        private IWebElement OkButton;

        [FindsBy(How = How.XPath, Using = "//input[@value='Update Severity']")]
        private IWebElement UpdateButton; 

        [FindsBy(How = How.XPath, Using = "//td[@class='bug-assigned-to']")]
        private IWebElement AssignedToText;

        [FindsBy(How = How.XPath, Using = "//td[@class='column-severity']")]
        private IWebElement SeverityText;

        #endregion

        #region Actions 

        public void AssignBug()
        {
            BugLink.Click();
            ComboBoxHelper.SelectElement(HandlerSelect, "test.developer");
            AssignButton.Click();
        }

        public void UpdateBug()
        {
            CheckBoxHelper.CheckCheckBoxJavascript(true, AllIssuesCheckBox);
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
        #endregion

        #region Navigation

        #endregion
    }
}
