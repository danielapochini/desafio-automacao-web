using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium; 

namespace DesafioAutomacaoWeb.Pages.Manage.Projects
{
    public class ManageProjectCreatePage : PageBase
    {
        #region WebElements

        private IWebElement ProjectNameTextBox => GenericHelper.GetElement(By.Id("project-name"));
        private IWebElement ProjectStatusSelect => GenericHelper.GetElement(By.Id("project-status"));
        private IWebElement ProjectViewStatusSelect => GenericHelper.GetElement(By.Id("project-view-state"));
        private IWebElement ProjectDescriptionTextArea => GenericHelper.GetElement(By.Id("project-description"));
        private IWebElement ProjectInheritCheckBox => GenericHelper.GetElement(By.Id("project-inherit-global"));
        private IWebElement AddProjectButton => GenericHelper.GetElement(By.XPath("//input[@value='Add Project']"));
        private IWebElement UpdateProjectButton => GenericHelper.GetElement(By.XPath("//input[@value='Update Project']"));
        private IWebElement DeleteProjectButton => GenericHelper.GetElement(By.XPath("//input[@value='Delete Project']"));

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
            GenericHelper.ClearElement(ProjectNameTextBox);
            GenericHelper.ClearElement(ProjectDescriptionTextArea);
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
            GenericHelper.ClearElement(ProjectNameTextBox);
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