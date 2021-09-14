using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace DesafioAutomacaoWeb.Utils.Drivers
{
    [Binding]
    public class DriverFactory
    {
        private readonly ISpecFlowOutputHelper _outputHelper;

        public DriverFactory(ISpecFlowOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            DatabaseHelper.ResetMantisDatabase();
        }

        [BeforeScenario]
        public void CreateInstance()
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
            _outputHelper.WriteLine("Browser iniciado");
        }

        [AfterScenario]
        public void TearDown()
        {
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
                _outputHelper.WriteLine("Browser encerrado");
            }
        }
    }
}
