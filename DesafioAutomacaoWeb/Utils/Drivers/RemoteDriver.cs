using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;

namespace DesafioAutomacaoWeb.Utils.Drivers
{
    [Binding]
    public class RemoteDriver
    {
        private static IWebDriver GetRemoteWebDriver(ICapabilities capabilities)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            ObjectRepository.Config = new AppSettingsReader();
            string hubUrl = ObjectRepository.Config.GetHubUrl();

            TimeSpan timeSpan = new TimeSpan(0, 3, 0);
            return new RemoteWebDriver(
                        new Uri(hubUrl),
                        capabilities,
                        timeSpan
                    );
        }
         
        public static IWebDriver CreateRemoteInstance()
        {
            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetRemoteWebDriver(DriversOptions.GetChromeOptions().ToCapabilities());
                    break;

                case BrowserType.Edge:
                    ObjectRepository.Driver = GetRemoteWebDriver(DriversOptions.GetEdgeOptions().ToCapabilities());
                    break;

                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetRemoteWebDriver(DriversOptions.GetFirefoxOptions().ToCapabilities());
                    break;

                case BrowserType.Opera:
                    ObjectRepository.Driver = GetRemoteWebDriver(DriversOptions.GetOperaOptions().ToCapabilities());
                    break;
            }
            DriverManagement.DriversConfigurations();
            return ObjectRepository.Driver;
        }    
       
    }
}
