using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Pages.Issues;
using DesafioAutomacaoWeb.Pages.Manage.Users;
using DesafioAutomacaoWeb.Utils.Helpers; 
using OpenQA.Selenium;

namespace DesafioAutomacaoWeb.Pages
{
    public class HomePage : PageBase
    {
        #region WebElements

        private IWebElement UserInfo => GenericHelper.GetElement(By.XPath("//span[@class='user-info']"));
        private IWebElement MyViewButton => GenericHelper.GetElement(By.XPath("//span[contains(text(),'My View')]"));
        private IWebElement ViewIssuesButton => GenericHelper.GetElement(By.XPath("//span[contains(text(),'View Issues')]"));
        private IWebElement InviteUsersButton => GenericHelper.GetElement(By.XPath("//a[contains(@href, 'manage_user_create_page')]"));
        private IWebElement ReportIssuesButton => GenericHelper.GetElement(By.XPath("//span[contains(text(),'Report Issue')]"));
        private IWebElement ManageButton => GenericHelper.GetElement(By.XPath("//span[contains(text(),'Manage')]"));

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