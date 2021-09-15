using DesafioAutomacaoWeb.Utils.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Utils.Drivers
{
    public class DriverManagement
    {
        public static void DriversConfigurations()
        { 
            ObjectRepository.Driver.Manage()
                .Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut());
            ObjectRepository.Driver.Manage().
                Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
            ObjectRepository.Driver.Manage().Cookies.DeleteAllCookies();
            ObjectRepository.Driver.Manage().Window.Maximize();
        }
    }
}
