using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;

namespace DesafioAutomacaoWeb.Pages
{
    public class ReportIssuePage : PageBase
    {
        #region WebElements

        private IWebElement SelectCategory => ObjectRepository.Driver.FindElement(By.Id("category_id"));
        private IWebElement SelectReproducibility => ObjectRepository.Driver.FindElement(By.Id("reproducibility"));
        private IWebElement SelectSeverity => ObjectRepository.Driver.FindElement(By.Id("severity"));
        private IWebElement SelectPriority => ObjectRepository.Driver.FindElement(By.Id("priority"));
        private IWebElement SelectProfile => ObjectRepository.Driver.FindElement(By.Id("profile_id"));
        private IWebElement SummaryTextBox => ObjectRepository.Driver.FindElement(By.Id("summary"));
        private IWebElement DescriptionTextBox => ObjectRepository.Driver.FindElement(By.Id("description"));
        private IWebElement StepsTextBox => ObjectRepository.Driver.FindElement(By.Id("steps_to_reproduce"));
        private IWebElement AdditionalInfoTextBox => ObjectRepository.Driver.FindElement(By.Id("additional_info"));
        private IWebElement TagTextBox => ObjectRepository.Driver.FindElement(By.Id("tag_string"));
        private IWebElement DropFileUpload => ObjectRepository.Driver.FindElement(By.XPath("//input[@type='file']"));
         
        private IWebElement SubmitButton => ObjectRepository.Driver.FindElement(By.XPath("//input[@value='Submit Issue']"));

        #endregion WebElements

        #region Actions

        public void ReportNewIssue(string category, string reproducibility, string severity, string priority,
            string profile, string summary, string description, string steps, string tags, string additionalInfo, string pathToFile)
        {
            ComboBoxHelper.SelectElement(SelectCategory, category);
            ComboBoxHelper.SelectElement(SelectReproducibility, reproducibility);
            ComboBoxHelper.SelectElement(SelectSeverity, severity);
            ComboBoxHelper.SelectElement(SelectPriority, priority);
            ComboBoxHelper.SelectElement(SelectProfile, profile);
            SummaryTextBox.SendKeys(summary);
            DescriptionTextBox.SendKeys(description);
            StepsTextBox.SendKeys(steps);
            TagTextBox.SendKeys(tags);
            AdditionalInfoTextBox.SendKeys(additionalInfo);
            DropFileUpload.SendKeys(pathToFile);
        }

        public void ReportBasicIssue(int category, string summary, string description)
        {
            ComboBoxHelper.SelectElement(SelectCategory, category);
            SummaryTextBox.SendKeys(summary);
            DescriptionTextBox.SendKeys(description); 
        }
         

        public void SubmitIssue()
        {
            SubmitButton.Click();
        }
        #endregion Actions

        public void CheckSummaryRequiredField()
        {
            GenericHelper.ClearTextBox(SummaryTextBox);
        } 
         
        public string ReturnRequiredMessage()
        {
            return GetValidationMessage(SummaryTextBox);
        }

    }
}