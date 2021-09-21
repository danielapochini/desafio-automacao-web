using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Pages.Manage.Projects;
using DesafioAutomacaoWeb.Pages.Manage.Tags;
using DesafioAutomacaoWeb.Pages.Manage.Users;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;

namespace DesafioAutomacaoWeb.Pages
{
    public class ManagePage : PageBase
    {
        #region WebElements

        private IWebElement ManageUsersTab => ObjectRepository.Driver.FindElement(By.LinkText("Manage Users"));
        private IWebElement ManageProjectsTab => ObjectRepository.Driver.FindElement(By.LinkText("Manage Projects"));
        private IWebElement ManageTagsTab => ObjectRepository.Driver.FindElement(By.LinkText("Manage Tags"));
        private IWebElement ManageCustomFieldsTab => ObjectRepository.Driver.FindElement(By.LinkText("Manage Custom Fields"));
        private IWebElement ManageGlobalProfilesTab => ObjectRepository.Driver.FindElement(By.LinkText("Manage Global Profiles"));
        private IWebElement ManagePluginsTab => ObjectRepository.Driver.FindElement(By.LinkText("Manage Plugins"));
        private IWebElement ManageConfigurationTab => ObjectRepository.Driver.FindElement(By.LinkText("Manage Configuration"));

        #endregion WebElements

        #region Actions

        public bool CheckManageUsersTabDisplayed()
        {
            return GenericHelper.IsElementPresent(ManageUsersTab);
        }

        public bool CheckManageProjectsTabDisplayed()
        {
            bool value = GenericHelper.IsElementPresent(ManageProjectsTab);
            return value;
        }

        public bool CheckManageTagsTabDisplayed()
        {
            bool value = GenericHelper.IsElementPresent(ManageTagsTab);
            return value;
        }

        public bool CheckManageCustomFieldsTabDisplayed()
        {
            bool value = GenericHelper.IsElementPresent(ManageCustomFieldsTab);
            return value;
        }

        public bool CheckManageGlobalProfilesTabDisplayed()
        {
            bool value = GenericHelper.IsElementPresent(ManageGlobalProfilesTab);
            return value;
        }

        public bool CheckManagePluginsTabDisplayed()
        {
            bool value = GenericHelper.IsElementPresent(ManagePluginsTab);
            return value;
        }

        public bool CheckManageConfigurationTabDisplayed()
        {
            bool value = GenericHelper.IsElementPresent(ManageConfigurationTab);
            return value;
        }

        #endregion Actions

        #region Navigation

        public ManageUsersPage NavigateToManageUsersTab()
        {
            ManageUsersTab.Click();
            return new ManageUsersPage();
        }

        public ManageProjectCreatePage NavigateToManageProjectsTab()
        {
            ManageProjectsTab.Click();
            return new ManageProjectCreatePage();
        }

        public ManageTagsPage NavigateToManageTagsTab()
        {
            ManageTagsTab.Click();
            return new ManageTagsPage();
        }

        #endregion Navigation
    }
}