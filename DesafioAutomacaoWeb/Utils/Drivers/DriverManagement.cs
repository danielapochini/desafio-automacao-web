using DesafioAutomacaoWeb.Utils.Settings;
using System;

namespace DesafioAutomacaoWeb.Utils.Drivers
{
    public static class DriverManagement
    {
        public static void DriversConfigurations()
        {
            ObjectRepository.Driver.Manage()
                .Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut());
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait =
                TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
            ObjectRepository.Driver.Manage().Cookies.DeleteAllCookies();
            ObjectRepository.Driver.Manage().Window.Maximize();
        }
    }
}