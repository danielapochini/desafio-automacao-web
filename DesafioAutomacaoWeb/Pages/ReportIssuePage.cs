using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Pages
{
    public class ReportIssuePage : PageBase
    { 
        #region WebElements
        [FindsBy(How = How.Id, Using = "category_id")]
        private IWebElement SelectCategory;

        [FindsBy(How = How.Id, Using = "reproducibility")]
        private IWebElement SelectReproducibility;

        [FindsBy(How = How.Id, Using = "severity")]
        private IWebElement SelectSeverity;

        [FindsBy(How = How.Id, Using = "priority")]
        private IWebElement SelectPriority;

        [FindsBy(How = How.Id, Using = "profile_id")]
        private IWebElement SelectProfile;

        [FindsBy(How = How.Id, Using = "summary")]
        private IWebElement SummaryTextBox;

        [FindsBy(How = How.Id, Using = "description")]
        private IWebElement DescriptionTextBox;

        [FindsBy(How = How.Id, Using = "steps_to_reproduce")]
        private IWebElement StepsTextBox;

        [FindsBy(How = How.Id, Using = "additional_info")]
        private IWebElement AdditionalInfoTextBox;


        [FindsBy(How = How.XPath, Using = "//input[@value='Submit Issue']")]
        private IWebElement SubmitButton;
        #endregion

        #region Actions
        public void ReportNewIssue(string category, string reproducibility, string severity, string priority, string profile, string summary, string description, string steps, string additionalInfo)
        {
            ComboBoxHelper.SelectElement(SelectCategory, category);
            ComboBoxHelper.SelectElement(SelectReproducibility, reproducibility);
            ComboBoxHelper.SelectElement(SelectSeverity, severity);
            ComboBoxHelper.SelectElement(SelectPriority, priority);
            ComboBoxHelper.SelectElement(SelectProfile, profile);
            SummaryTextBox.SendKeys(summary);
            DescriptionTextBox.SendKeys(description);
            StepsTextBox.SendKeys(steps);
            AdditionalInfoTextBox.SendKeys(additionalInfo);
            SubmitButton.Click();
        }
        #endregion
    }
}
