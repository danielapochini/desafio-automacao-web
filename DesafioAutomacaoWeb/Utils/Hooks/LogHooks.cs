using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;
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
            string subpasta = @"Reports\"; 
            string fullPath = Path.Combine(Environment.CurrentDirectory, subpasta);
            Directory.CreateDirectory(fullPath);
            var filename = $"screenshot-{DateTime.UtcNow:yyyy-MM-dd-mm-ss.FFF}.png";
            ObjectRepository.Driver.TakeScreenshot().SaveAsFile(fullPath + filename);
            _outputHelper.AddAttachment(filename);
        } 
    }
}