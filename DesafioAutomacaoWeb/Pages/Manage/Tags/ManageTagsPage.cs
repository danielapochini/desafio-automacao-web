using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;

namespace DesafioAutomacaoWeb.Pages.Manage.Tags
{
    public class ManageTagsPage : PageBase
    {
        #region WebElements

        private IWebElement TagNameTextBox => GenericHelper.GetElement(By.Id("tag-name"));
        private IWebElement TagDescriptionTextArea => GenericHelper.GetElement(By.Id("tag-description"));
        private IWebElement CreateTagButton => GenericHelper.GetElement(By.XPath("//input[@type='submit']"));

        #endregion WebElements

        #region Actions

        public void FillTagFields(string tagName, string tagDescription)
        {
            TagNameTextBox.SendKeys(tagName);
            TagDescriptionTextArea.SendKeys(tagDescription);
        }

        public void CheckRequiredField()
        {
            TagNameTextBox.Clear();
        }

        public void ClickCreateTagButton()
        {
            CreateTagButton.Click();
        }

        public bool CheckTagTable(string tagName)
        {
            IWebElement element = GenericHelper.CheckElement(tagName);

            return element.Displayed;
        }

        public string ReturnRequiredMessage()
        {
            return TagNameTextBox.GetAttribute("validationMessage");
        }

        #endregion Actions
    }
}