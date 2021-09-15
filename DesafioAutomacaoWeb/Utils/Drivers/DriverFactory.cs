using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
             
            switch (execution){
                    case ("true"):
                        RemoteDriver.CreateRemoteInstance();
                    break; 
                    case ("false"):
                        LocalDriver.CreateWebDriverInstance();
                    break;
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
