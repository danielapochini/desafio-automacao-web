using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;

namespace DesafioAutomacaoWeb.Pages.Manage.Projects
{
    public class ManageProjectsPage : PageBase
    {
        #region WebElements

        private IWebElement CreateProjectButton => GenericHelper.GetElement(By.XPath("//button[contains(text(),'Create New Project')]"));
        private IWebElement CreateCategoryButton => GenericHelper.GetElement(By.XPath("//input[@value='Add Category']"));
        private IWebElement EditCategoryButton => GenericHelper.GetElement(By.XPath("//tbody/tr[1]/td[3]/div[1]/div[1]/form[1]/fieldset[1]/button[1]"));
        private IWebElement CategoryTextBox => GenericHelper.GetElement(By.XPath("//*[@id='categories']/div/div[2]/form/div/input[3]"));

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