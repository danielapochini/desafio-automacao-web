using DesafioAutomacaoWeb.Bases;
using DesafioAutomacaoWeb.Utils.Helpers;
using OpenQA.Selenium;

namespace DesafioAutomacaoWeb.Pages.Issues
{
    public class ReportIssuePage : PageBase
    {
        #region WebElements

        private IWebElement SelectCategory => GenericHelper.GetElement(By.Id("category_id"));
        private IWebElement SelectReproducibility => GenericHelper.GetElement(By.Id("reproducibility"));
        private IWebElement SelectSeverity => GenericHelper.GetElement(By.Id("severity"));
        private IWebElement SelectPriority => GenericHelper.GetElement(By.Id("priority"));
        private IWebElement SelectProfile => GenericHelper.GetElement(By.Id("profile_id"));
        private IWebElement SummaryTextBox => GenericHelper.GetElement(By.Id("summary"));
        private IWebElement DescriptionTextBox => GenericHelper.GetElement(By.Id("description"));
        private IWebElement StepsTextBox => GenericHelper.GetElement(By.Id("steps_to_reproduce"));
        private IWebElement AdditionalInfoTextBox => GenericHelper.GetElement(By.Id("additional_info"));
        private IWebElement TagTextBox => GenericHelper.GetElement(By.Id("tag_string"));
        private IWebElement DropFileUpload => GenericHelper.GetElement(By.XPath("//input[@type='file']"));
        private IWebElement SubmitButton => GenericHelper.GetElement(By.XPath("//input[@value='Submit Issue']"));


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
            UploadLocalFile(pathToFile);
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
            GenericHelper.ClearElement(SummaryTextBox);
        }

        public string ReturnRequiredMessage()
        {
            return GetValidationMessage(SummaryTextBox);
        }

        public void UploadLocalFile(string pathToFile)
        {
            FileUploadHelper.LocalDetector();
            DropFileUpload.SendKeys(pathToFile);
        }
    }
}