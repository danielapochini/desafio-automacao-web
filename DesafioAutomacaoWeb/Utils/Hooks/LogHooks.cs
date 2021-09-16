using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

       //[AfterStep()]
       //public void TakeScreenShotAfterEveryStep()
       // { 
       //     var filename = $"screenshot-{DateTime.UtcNow:yyyy-MM-dd-mm-ss.FFF}.png";
       //     ObjectRepository.Driver.TakeScreenshot().SaveAsFile(filename);
       //     _outputHelper.AddAttachment(filename); 
       // }
    }
}
