using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium; 

namespace DesafioAutomacaoWeb.Pages.Manage.Projects
{
    public class ManageProjectCreatePage : PageBase
    {
        #region WebElements

        private IWebElement ProjectNameTextBox => ObjectRepository.Driver.FindElement(By.Id("project-name"));
        private IWebElement ProjectStatusSelect => ObjectRepository.Driver.FindElement(By.Id("project-status"));
        private IWebElement ProjectViewStatusSelect => ObjectRepository.Driver.FindElement(By.Id("project-view-state"));
        private IWebElement ProjectDescriptionTextArea => ObjectRepository.Driver.FindElement(By.Id("project-description"));
        private IWebElement ProjectInheritCheckBox => ObjectRepository.Driver.FindElement(By.Id("project-inherit-global"));
        private IWebElement AddProjectButton => ObjectRepository.Driver.FindElement(By.XPath("//input[@value='Add Project']"));
        private IWebElement UpdateProjectButton => ObjectRepository.Driver.FindElement(By.XPath("//input[@value='Update Project']"));
        private IWebElement DeleteProjectButton => ObjectRepository.Driver.FindElement(By.XPath("//input[@value='Delete Project']"));

        #endregion WebElements

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
            JavaScriptExecutorHelper.CheckCheckBoxJavascript(value, ProjectInheritCheckBox);
        }

        public string ReturnRequiredMessage()
        {
            return GetValidationMessage(ProjectNameTextBox);
        }

        public string ReturnProjectWarningBox()
        {
            string warningMessage = ReturnWarningMessage();
            string projectName = warningMessage.Substring(warningMessage.IndexOf(":") + 2);
            return projectName;
        }

        #endregion Actions
    }
}