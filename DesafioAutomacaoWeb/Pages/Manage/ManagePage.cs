using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Pages.Manage.Projects;
using DesafioAutomacaoWeb.Pages.Manage.Tags;
using DesafioAutomacaoWeb.Pages.Manage.Users;
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
    public class ManagePage : PageBase
    {
        #region WebElements 

        [FindsBy(How = How.LinkText, Using = "Manage Users")]
        private IWebElement ManageUsersTab;

        [FindsBy(How = How.LinkText, Using = "Manage Projects")]
        private IWebElement ManageProjectsTab;

        [FindsBy(How = How.LinkText, Using = "Manage Tags")]
        private IWebElement ManageTagsTab;

        [FindsBy(How = How.LinkText, Using = "Manage Custom Fields")]
        private IWebElement ManageCustomFieldsTab;
         
        [FindsBy(How = How.LinkText, Using = "Manage Global Profiles")]
        private IWebElement ManageGlobalProfilesTab;

        [FindsBy(How = How.LinkText, Using = "Manage Plugins")]
        private IWebElement ManagePluginsTab;

        [FindsBy(How = How.LinkText, Using = "Manage Configuration")]
        private IWebElement ManageConfigurationTab;
        #endregion

        #region Actions
        public bool CheckManageUsersTabDisplayed()
        {
            return GenericHelper.IsElementPresent(ManageUsersTab); 
        }

        public bool CheckManageProjectsTabDisplayed()
        {
            var value = GenericHelper.IsElementPresent(ManageProjectsTab);
            return value;
        }

        public bool CheckManageTagsTabDisplayed()
        {
            var value = GenericHelper.IsElementPresent(ManageTagsTab);
            return value;
        }

        public bool CheckManageCustomFieldsTabDisplayed()
        {
            var value = GenericHelper.IsElementPresent(ManageCustomFieldsTab);
            return value;
        }
        public bool CheckManageGlobalProfilesTabDisplayed()
        {
            var value = GenericHelper.IsElementPresent(ManageGlobalProfilesTab);
            return value;
        }
        public bool CheckManagePluginsTabDisplayed()
        {
            var value = GenericHelper.IsElementPresent(ManagePluginsTab);
            return value;
        }

        public bool CheckManageConfigurationTabDisplayed()
        {
            var value = GenericHelper.IsElementPresent(ManageConfigurationTab);
            return value;
        }

        #endregion

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
        #endregion
    }
}
