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
        public static IWebDriver GetRemoteWebDriver(ICapabilities capabilities)
        {  
            string hubUrl = ObjectRepository.Config.GetHubUrl();

            TimeSpan timeSpan = new TimeSpan(0, 3, 0);
            return new RemoteWebDriver(
                        new Uri(hubUrl),
                        capabilities,
                        timeSpan
                    );
        }
          
        public static void CreateRemoteInstance()
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
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    ObjectRepository.Driver = GetRemoteWebDriver(DriversOptions.GetFirefoxOptions().ToCapabilities());
                    break; 
            }
            DriverManagement.DriversConfigurations(); 
        }    
       
    }
}
