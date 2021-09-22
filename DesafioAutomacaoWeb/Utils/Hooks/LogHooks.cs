using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium.Support.Extensions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace DesafioAutomacaoWeb.Utils.Hooks
{
    [Binding]
    public class LogHooks
    {
        private readonly ISpecFlowOutputHelper _outputHelper;

        public LogHooks(ISpecFlowOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [AfterScenario()]
        public void TakeScreenShotAfterEveryScenario()
        {
            var filename = $"screenshot-{DateTime.UtcNow:yyyy-MM-dd-mm-ss.FFF}.png";
            ObjectRepository.Driver.TakeScreenshot().SaveAsFile(filename);
            _outputHelper.AddAttachment(filename);
        }
    }
}