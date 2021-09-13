using DesafioAutomacaoWeb.Utils.Settings;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome; 
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace DesafioAutomacaoWeb.Utils.Drivers
{
    public class LocalDriver
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
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            new DriverManager().SetUpDriver(new FirefoxConfig()); 
            IWebDriver driver = new FirefoxDriver(DriversOptions.GetFirefoxOptions());
            return driver;
        }

        public static IWebDriver GetOperaDriver()
        {
            new DriverManager().SetUpDriver(new OperaConfig()); 
            IWebDriver driver = new OperaDriver(DriversOptions.GetOperaOptions());
            return driver;
        }

        public static IWebDriver CreateWebDriverInstance()
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
                    ObjectRepository.Driver = GetFirefoxDriver();
                    break;

                case BrowserType.Opera:
                    ObjectRepository.Driver = GetOperaDriver();
                    break;
            }
            DriverManagement.DriversConfigurations();

            return ObjectRepository.Driver;
        }

    }
}
