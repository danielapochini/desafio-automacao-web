using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Pages.Manage.Tags
{
    public class ManageTagsPage : PageBase
    {
        #region WebElements  
        [FindsBy(How = How.Id, Using = "tag-name")]
        private IWebElement TagNameTextBox;

        [FindsBy(How = How.Id, Using = "tag-description")]
        private IWebElement TagDescriptionTextArea;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement CreateTagButton; 
        #endregion

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
            var element = GenericHelper.CheckElement(tagName);

            return element.Displayed;
        }


        public string ReturnRequiredMessage()
        {
            return TagNameTextBox.GetAttribute("validationMessage");
        }

        #endregion
    }
}
