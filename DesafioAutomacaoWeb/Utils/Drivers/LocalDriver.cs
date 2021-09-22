using DesafioAutomacaoWeb.Utils.Settings;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;
using System.Text;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace DesafioAutomacaoWeb.Utils.Drivers
{
    public static class LocalDriver
    {
        public static IWebDriver GetChromeDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

            IWebDriver driver = new ChromeDriver(
                ChromeDriverService.CreateDefaultService(),
                DriversOptions.GetChromeOptions(),
                TimeSpan.FromMinutes(5)
            );
            return driver;
        }

        public static IWebDriver GetEdgeDriver()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            IWebDriver edgeDriver = new EdgeDriver(DriversOptions.GetEdgeOptions());
            return edgeDriver;
        }

        public static IWebDriver GetFirefoxDriver()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            service.Host = "::1";
            IWebDriver driver = new FirefoxDriver(service, DriversOptions.GetFirefoxOptions());
            return driver;
        }
         
        public static void CreateWebDriverInstance()
        {
            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    break;

                case BrowserType.Edge:
                    ObjectRepository.Driver = GetEdgeDriver();
                    break;

                case BrowserType.Firefox:
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    ObjectRepository.Driver = GetFirefoxDriver();
                    break;
            }

            DriverManagement.DriversConfigurations();
        }
    }
}