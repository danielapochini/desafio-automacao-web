using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Pages.Manage.Users;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;

namespace DesafioAutomacaoWeb.Pages
{
    public class HomePage : PageBase
    {
        #region WebElements

        private IWebElement UserInfo => ObjectRepository.Driver.FindElement(By.XPath("//span[@class='user-info']"));
        private IWebElement MyViewButton => ObjectRepository.Driver.FindElement(By.XPath("//span[contains(text(),'My View')]"));
        private IWebElement ViewIssuesButton => ObjectRepository.Driver.FindElement(By.XPath("//span[contains(text(),'View Issues')]"));
        private IWebElement InviteUsersButton => ObjectRepository.Driver.FindElement(By.XPath("//a[contains(@href, 'manage_user_create_page')]"));
        private IWebElement ReportIssuesButton => ObjectRepository.Driver.FindElement(By.XPath("//span[contains(text(),'Report Issue')]"));
        private IWebElement ManageButton => ObjectRepository.Driver.FindElement(By.XPath("//span[contains(text(),'Manage')]"));

        #endregion WebElements

        #region Actions

        public string ReturnUser()
        {
            string text = GenericHelper.GetElementText(UserInfo);
            return text;
        }

        public bool CheckManageButton()
        {
            bool value = GenericHelper.IsElementPresent(ManageButton);
            return value;
        }

        #endregion Actions

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

        #endregion Navigation
    }
}