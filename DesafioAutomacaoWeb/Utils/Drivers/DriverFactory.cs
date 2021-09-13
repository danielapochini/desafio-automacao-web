using DesafioAutomacaoWeb.Utils.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DesafioAutomacaoWeb.Utils.Drivers
{
    [Binding]
    public class DriverFactory
    { 
        [BeforeScenario]
        public static void CreateInstance()
        {
            ObjectRepository.Config = new AppSettingsReader();

            string execution = ObjectRepository.Config.GetRemoteDriverExecution();

            if (ObjectRepository.Driver == null)
            {
                switch (execution)
                {
                    case ("true"):
                        ObjectRepository.Driver = RemoteDriver.CreateRemoteInstance(); 
                        break;

                    case ("false"):
                        ObjectRepository.Driver = LocalDriver.CreateWebDriverInstance();
                        break;
                }
            }
        }

        [AfterScenario]
        public static void TearDown()
        {
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            }
        }
    }
}
