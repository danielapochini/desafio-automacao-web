using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Pages.Manage.Projects;
using DesafioAutomacaoWeb.Pages.Manage.Users;
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
        #endregion
    }
}
