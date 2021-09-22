using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium; 

namespace DesafioAutomacaoWeb.Pages.Manage.Users
{
    public class ManageUsersPage : PageBase
    {
        #region WebElements 
        private IWebElement AdminLink => GenericHelper.GetElement(By.XPath("//tbody/tr[1]/td[1]/a[1]"));
         
        #endregion WebElements

        #region Navigation
        public ManageUserEditPage ClickUserLink(string username)
        {
            GenericHelper.ClickElement(username);
            return new ManageUserEditPage();
        }

        public ManageUserEditPage ClickAdminLink()
        {
            AdminLink.Click();
            return new ManageUserEditPage();
        }
        #endregion Navigation
    }
}