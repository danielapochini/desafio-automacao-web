using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
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

        [FindsBy(How = How.XPath, Using = "//input[@value='Add Category']")]
        private IWebElement CreateCategoryButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Edit')]")]
        private IWebElement EditCategoryButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='categories']/div/div[2]/form/div/input[3]")]
        private IWebElement CategoryTextBox;
         
        #endregion

        #region Actions
        public ManageProjectCreatePage ClickCreateNewProjectButton()
        {
            CreateProjectButton.Click();
            return new ManageProjectCreatePage();
        }

        public ManageProjectCreatePage ClickProjectLink(string projectName)
        {
            GenericHelper.ClickElement(projectName);
            return new ManageProjectCreatePage();
        }

        public ManageProjectCategoryPage ClickEditCategoryLink()
        {
            EditCategoryButton.Click();
            return new ManageProjectCategoryPage();
        }


        public bool CheckCategoryTable(string categoryName)
        {
            var element = GenericHelper.CheckElementFromTable(categoryName);

            return element.Displayed;
        }

        public ManageProjectsPage ClickCreateNewCategoryButton()
        {
            CreateCategoryButton.Click();
            return new ManageProjectsPage();
        }

        public void FillCategoryBox(string text)
        {
            CategoryTextBox.SendKeys(text);
        }
        #endregion
    }
}
