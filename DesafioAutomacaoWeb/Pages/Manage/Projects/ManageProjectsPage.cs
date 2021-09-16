using DesafioAutomacaoWeb.Bases;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Pages.Manage.Projects
{
    public class ManageProjectsPage : PageBase
    {
        #region WebElements 

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Create New Project')]")]
        private IWebElement CreateProjectButton;

        #endregion

        public ManageProjectCreatePage ClickCreateNewProjectButton()
        {
            CreateProjectButton.Click();
            return new ManageProjectCreatePage();
        }
    }
}
