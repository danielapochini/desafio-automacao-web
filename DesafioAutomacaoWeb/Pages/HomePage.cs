using DesafioAutomacaoWeb.Bases;
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
    public class HomePage : PageBase
    {
        #region WebElements 

        [FindsBy(How = How.XPath, Using = "//span[@class='user-info']")]
        private IWebElement UserInfo;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'My View')]")]
        private IWebElement MyViewButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'View Issues')]")]
        private IWebElement ViewIssuesButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href, 'manage_user_create_page')]")]
        private IWebElement InviteUsersButton;
         
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Report Issue')]")]
        private IWebElement ReportIssuesButton;
        
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Manage')]")]
        private IWebElement ManageButton;

        #endregion

        #region Actions 
        public string ReturnUser()
        {
            var text = GenericHelper.GetElementText(UserInfo);
            return text;
        }

        public bool CheckManageButton()
        {
            var value = GenericHelper.IsElementPresent(ManageButton);
            return value;
        }
        #endregion

        #region Navigation
        public ReportIssuePage NavigateToReportIssues()
        {
            ReportIssuesButton.Click();
            return new ReportIssuePage();
        }

        public ViewIssuesPage NavigateToViewIssues()
        {
            ViewIssuesButton.Click();
            return new ViewIssuesPage();
        }

        public ManagePage NavigateToManage()
        {
            ManageButton.Click();
            return new ManagePage();
        }

        public ManageUserCreatePage NavigateToInviteUsers()
        {
            InviteUsersButton.Click();
            return new ManageUserCreatePage();
        }
        #endregion
    }
}
