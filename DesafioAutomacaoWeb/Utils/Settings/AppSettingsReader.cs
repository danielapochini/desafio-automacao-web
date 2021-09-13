using DesafioAutomacaoWeb.Utils.Drivers;
using DesafioAutomacaoWeb.Utils.Settings.Interface;
using System;

namespace DesafioAutomacaoWeb.Utils.Settings
{
    public class AppSettingsReader : IConfig
    {
        private readonly AppSettings AppSettings = new AppSettings();

        public BrowserType? GetBrowser()
        {
            string browser = AppSettings.Browser;
            try
            {
                return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetPassword()
        {
            return AppSettings.Password;
        }

        public string GetUsername()
        {
            return AppSettings.Username;
        }

        public string GetBaseUrl()
        {
            return AppSettings.BaseUrl;
        }

        public string GetHubUrl()
        {
            return AppSettings.HubUrl;
        }

        public int GetPageLoadTimeOut()
        {
            string timeout = AppSettings.PageLoadTimeOut;
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }

        public int GetElementLoadTimeOut()
        {
            string timeout = AppSettings.ElementLoadTimeOut;
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }

        public string GetRemoteDriverExecution()
        {
            return AppSettings.RemoteDriverExecution;
        }
    }
}
