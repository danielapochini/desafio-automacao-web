using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Utils.Settings.Interface
{
    public interface IConfig
    {
        BrowserType? GetBrowser();
        string GetUsername();
        string GetPassword();
        string GetBaseUrl();
        string GetHubUrl();
        string GetRemoteDriverExecution();
        int GetPageLoadTimeOut();
        int GetElementLoadTimeOut();
    }
}
