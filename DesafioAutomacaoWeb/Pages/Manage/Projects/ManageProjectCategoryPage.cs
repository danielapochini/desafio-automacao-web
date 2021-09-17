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
    public class ManageProjectCategoryPage : PageBase
    {
        #region WebElements
        [FindsBy(How = How.Id, Using = "proj-category-name")]
        private IWebElement ProjectCategoryTextBox;

        [FindsBy(How = How.Id, Using = "proj-category-assigned-to")]
        private IWebElement ProjectCategoryAssigneeSelect;

        [FindsBy(How = How.XPath, Using = "//input[@value='Update Category']")]
        private IWebElement UpdateCategoryButton;

        [FindsBy(How = How.XPath, Using = "//input[@value='Delete Category']")]
        private IWebElement DeleteCategoryButton;
        #endregion

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
        #endregion
    }
}
