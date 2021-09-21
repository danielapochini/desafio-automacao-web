using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Bases
{
    public class PageBase
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-danger']//p[1]")]
        private IWebElement ErrorCodeMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-danger']//p[2]")]
        private IWebElement ErrorDescriptionMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-warning center']//p[1]")]
        private IWebElement WarningMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-success center']//p[1]")]
        private IWebElement SuccessMessage;

        [FindsBy(How = How.XPath, Using = "//span[@class = 'user-info']")]
        private IWebElement UserInfo;

        public PageBase()
        {
            PageFactory.InitElements(ObjectRepository.Driver, this);
        }

        public string PageTitle()
        {
            return ObjectRepository.Driver.Title; 
        }

        public string PageUrl()
        {
            return ObjectRepository.Driver.Url;
        }

        public string ReturnUserInfo()
        {
            var text = GenericHelper.GetElementText(UserInfo);
            return text;
        }

        public string ReturnErrorCode()
        {
            var text = GenericHelper.GetElementText(ErrorCodeMessage);
            return text;
        }

        public string ReturnErrorDescription()
        {
            var text = GenericHelper.GetElementText(ErrorDescriptionMessage);
            return text;
        }
         
        public string ReturnSuccessCode()
        {
            var text = GenericHelper.GetElementText(SuccessMessage);
            return text;
        }

        public string ReturnWarningMessage()
        {
            var text = GenericHelper.GetElementText(WarningMessage);
            return text;
        }

        public string ReturnRequiredMessage(IWebElement element)
        {
            return element.GetAttribute("validationMessage");
        }
    }
}
