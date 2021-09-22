using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;

namespace DesafioAutomacaoWeb.Utils.Drivers
{
    public static class DriversOptions
    {
        public static ChromeOptions GetChromeOptions()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");
            chromeOptions.AddArgument("no-sandbox");
            chromeOptions.AddArgument("proxy-server='direct://'");
            chromeOptions.AddArgument("proxy-bypass-list=*");
            chromeOptions.AddArgument("lang=en");
            chromeOptions.AddAdditionalCapability(CapabilityType.AcceptSslCertificates, true, true);
            return chromeOptions;
        }

        public static FirefoxOptions GetFirefoxOptions()
        {
            FirefoxProfileManager manager = new FirefoxProfileManager();

            FirefoxOptions firefoxOptions = new FirefoxOptions
            {
                Profile = manager.GetProfile("default"),
                AcceptInsecureCertificates = true
            };
            firefoxOptions.SetPreference("intl.accept_languages", "en-US");
            return firefoxOptions;
        }

        public static EdgeOptions GetEdgeOptions()
        {
            EdgeOptions edgeOptions = new EdgeOptions
            {
                UseChromium = true
            };
            edgeOptions.AddArgument("start-maximized");
            edgeOptions.AddArgument("lang=en");
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