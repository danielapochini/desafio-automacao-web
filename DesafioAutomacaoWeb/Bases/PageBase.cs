using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium; 

namespace DesafioAutomacaoWeb.Bases
{
    public class PageBase
    {
        #region WebElements
        private IWebElement ErrorCodeMessage => GenericHelper.GetElement(By.XPath("//div[@class='alert alert-danger']//p[1]"));
        private IWebElement ErrorDescriptionMessage => GenericHelper.GetElement(By.XPath("//div[@class='alert alert-danger']//p[2]"));
        private IWebElement SuccessMessage => GenericHelper.GetElement(By.XPath("//div[@class='alert alert-success center']//p[1]"));
        private IWebElement WarningMessage => GenericHelper.GetElement(By.XPath("//div[@class='alert alert-warning center']//p[1]"));
        private IWebElement UserInfo => GenericHelper.GetElement(By.XPath("//span[@class = 'user-info']"));
        #endregion WebElements

        #region Actions
        public string ReturnPageTitle()
        {
            return ObjectRepository.Driver.Title;
        }

        public string ReturnPageUrl()
        {
            return ObjectRepository.Driver.Url;
        }

        public string ReturnUserInfo()
        {
            return GenericHelper.GetElementText(UserInfo);
        }

        public string ReturnErrorCode()
        {
            return GenericHelper.GetElementText(ErrorCodeMessage);
        }

        public string ReturnErrorDescription()
        {
            return GenericHelper.GetElementText(ErrorDescriptionMessage);
        }

        public string ReturnSuccessCode()
        {
            return GenericHelper.GetElementText(SuccessMessage);
        }

        public string ReturnWarningMessage()
        {
            return GenericHelper.GetElementText(WarningMessage);
        }

        public string GetValidationMessage(IWebElement element)
        {
            return element.GetAttribute("validationMessage");
        }
        #endregion Actions
    }
}