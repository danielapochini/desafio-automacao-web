using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
         

        #endregion

        #region Actions
        public void CreateNewProject(string name, string status, bool value, string viewstatus, string description)
        {
            ProjectNameTextBox.SendKeys(name);
            ComboBoxHelper.SelectElement(ProjectStatusSelect, status);
            ComboBoxHelper.SelectElement(ProjectViewStatusSelect, viewstatus);
            ProjectDescriptionTextArea.SendKeys(description);
            CheckProjectInheritCheckBox(value);
            AddProjectButton.Click();
        }
        #endregion
          
        public void CheckProjectInheritCheckBox(bool value)
        {
            CheckBoxHelper.CheckCheckBoxJavascript(value, ProjectInheritCheckBox);
        }

        #region Navigation
        #endregion
    }
}
