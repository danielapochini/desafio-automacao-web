using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;

namespace DesafioAutomacaoWeb.Pages.Manage.Projects
{
    public class ManageProjectsPage : PageBase
    {
        #region WebElements

        private IWebElement CreateProjectButton => ObjectRepository.Driver.FindElement(By.XPath("//button[contains(text(),'Create New Project')]"));
        private IWebElement CreateCategoryButton => ObjectRepository.Driver.FindElement(By.XPath("//input[@value='Add Category']"));
        private IWebElement EditCategoryButton => ObjectRepository.Driver.FindElement(By.XPath("//button[contains(text(),'Edit')]"));
        private IWebElement CategoryTextBox => ObjectRepository.Driver.FindElement(By.XPath("//*[@id='categories']/div/div[2]/form/div/input[3]"));

        #endregion WebElements

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
            IWebElement element = GenericHelper.CheckElementFromTable(categoryName);

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

        #endregion Actions
    }
}