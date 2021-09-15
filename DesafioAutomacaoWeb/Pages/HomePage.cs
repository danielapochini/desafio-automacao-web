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
         
        #endregion

        #region Actions 
        public string ReturnUser()
        {
            var text = GenericHelper.GetElementText(UserInfo);
            return text;
        }
        #endregion

        #region Navigation
        public ReportIssuePage NavigateToReportIssues()
        {
            ReportIssuesButton.Click();
            return new ReportIssuePage();
        }

        public ManageUserCreatePage NavigateToInviteUsers()
        {
            GenericHelper.GetElement(InviteUsersButton).Click();
            return new ManageUserCreatePage();
        }

        #endregion
    }
}
