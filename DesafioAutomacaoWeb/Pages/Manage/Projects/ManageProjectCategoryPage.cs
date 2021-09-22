using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;

namespace DesafioAutomacaoWeb.Pages.Manage.Projects
{
    public class ManageProjectCategoryPage : PageBase
    {
        #region WebElements

        private IWebElement ProjectCategoryTextBox => GenericHelper.GetElement(By.Id("proj-category-name"));
        private IWebElement ProjectCategoryAssigneeSelect => GenericHelper.GetElement(By.Id("proj-category-assigned-to"));
        private IWebElement UpdateCategoryButton => GenericHelper.GetElement(By.XPath("//input[@value='Update Category']"));
        private IWebElement DeleteCategoryButton => GenericHelper.GetElement(By.XPath("//input[@value='Delete Category']"));

        #endregion WebElements

        #region Actions

        public void FillCategoryInputs(string name, string selectValue)
        {
            ProjectCategoryTextBox.Clear();
            ProjectCategoryTextBox.SendKeys(name);
            ComboBoxHelper.SelectElement(ProjectCategoryAssigneeSelect, selectValue);
            ClickUpdateCategoryButton();
        }

        public void CheckRequiredField()
        {
            ProjectCategoryTextBox.Clear();
            ClickUpdateCategoryButton();
        }

        public void ClickUpdateCategoryButton()
        {
            UpdateCategoryButton.Click();
        }

        public void ClickDeleteCategoryButton()
        {
            DeleteCategoryButton.Click();
        }

        #endregion Actions
    }
}