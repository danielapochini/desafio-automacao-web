using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Pages.Manage.Projects
{
    public class ManageProjectCreatePage : PageBase
    {
        #region WebElements
        [FindsBy(How = How.Id, Using = "project-name")]
        private IWebElement ProjectNameTextBox;

        [FindsBy(How = How.Id, Using = "project-status")] 
        private IWebElement ProjectStatusSelect;

        [FindsBy(How = How.Id, Using = "project-view-state")]
        private IWebElement ProjectViewStatusSelect;

        [FindsBy(How = How.Id, Using = "project-description")]
        private IWebElement ProjectDescriptionTextArea;

        [FindsBy(How = How.Id, Using = "project-inherit-global")]
        private IWebElement ProjectInheritCheckBox;

        [FindsBy(How = How.XPath, Using = "//input[@value='Add Project']")]
        private IWebElement AddProjectButton;

        [FindsBy(How = How.XPath, Using = "//input[@value='Update Project']")]
        private IWebElement UpdateProjectButton;

        [FindsBy(How = How.XPath, Using = "//input[@value='Delete Project']")]
        private IWebElement DeleteProjectButton;
        #endregion

        #region Actions
        public void CreateNewProject(string name, string status, bool value, string viewstatus, string description)
        {
            ProjectNameTextBox.SendKeys(name);
            ComboBoxHelper.SelectElement(ProjectStatusSelect, status);
            ComboBoxHelper.SelectElement(ProjectViewStatusSelect, viewstatus);
            ProjectDescriptionTextArea.SendKeys(description);
            CheckProjectInheritCheckBox(value);
            ClickAddProjectButton();
        }

        public void UpdateExistingProject(string name, string status, bool value, string viewstatus, string description)
        {
            ClearAllTextBoxFields();
            ProjectNameTextBox.SendKeys(name);
            ComboBoxHelper.SelectElement(ProjectStatusSelect, status);
            ComboBoxHelper.SelectElement(ProjectViewStatusSelect, viewstatus);
            ProjectDescriptionTextArea.SendKeys(description);
            CheckProjectInheritCheckBox(value);
            ClickUpdateProjectButton();
        }

        public void ClearAllTextBoxFields()
        {
            GenericHelper.ClearTextBox(ProjectNameTextBox);
            GenericHelper.ClearTextBox(ProjectDescriptionTextArea); 
        }
        public void ClickAddProjectButton()
        {
            AddProjectButton.Click();
        }

        public void ClickDeleteProjectButton()
        {
            DeleteProjectButton.Click();
        }

        public void ClickUpdateProjectButton()
        {
            UpdateProjectButton.Click();
        }

        public void CheckRequiredField()
        {
            GenericHelper.ClearTextBox(ProjectNameTextBox);
        }

        public void CheckProjectInheritCheckBox(bool value)
        {
            CheckBoxHelper.CheckCheckBoxJavascript(value, ProjectInheritCheckBox);
        }

        public string ReturnRequiredMessage()
        {
            return ProjectNameTextBox.GetAttribute("validationMessage");
        }


        public string ReturnProjectWarningBox()
        {
            string warningMessage = ReturnWarningMessage();
            string projectName = warningMessage.Substring(warningMessage.IndexOf(":") +2);
            return projectName;
        }
        #endregion

        #region Navigation
        #endregion
    }
}
