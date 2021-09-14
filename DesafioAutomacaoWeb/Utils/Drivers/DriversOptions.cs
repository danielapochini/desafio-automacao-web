﻿using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium.Chrome; 
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Utils.Drivers
{
    public class DriversOptions
    {
        public static ChromeOptions GetChromeOptions()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArguments("--disable-dev-shm-usage");
            chromeOptions.AddArguments("--whitelisted-ips=''");
            chromeOptions.AddArgument("--lang=en");
            chromeOptions.AddAdditionalCapability(CapabilityType.AcceptSslCertificates, true, true);
            return chromeOptions;
        }

        public static FirefoxOptions GetFirefoxOptions()
        {
            FirefoxProfileManager manager = new FirefoxProfileManager();

            FirefoxOptions firefoxOptions = new FirefoxOptions()
            {
                Profile = manager.GetProfile("default"),
                AcceptInsecureCertificates = true,

            };
            return firefoxOptions;
        }

        public static EdgeOptions GetEdgeOptions()
        {
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.UseChromium = true;
            return edgeOptions;
        }

        public static OperaOptions GetOperaOptions()
        {
            OperaOptions operaOptions = new OperaOptions();
            operaOptions.AddAdditionalCapability(CapabilityType.BrowserName, "operablink", true);
            return operaOptions;
        }

    }
}