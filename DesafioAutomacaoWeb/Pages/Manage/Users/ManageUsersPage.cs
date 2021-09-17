using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Pages.Manage.Users
{
    public class ManageUsersPage : PageBase
    {
        #region WebElements 
          
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[1]/a[1]")]
        private IWebElement AdminLink;

        #endregion

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

    }
}
