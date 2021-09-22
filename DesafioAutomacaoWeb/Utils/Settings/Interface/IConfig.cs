using DesafioAutomacaoWeb.Utils.Drivers;

namespace DesafioAutomacaoWeb.Utils.Settings.Interface
{
    public interface IConfig
    {
        BrowserType? GetBrowser();

        string GetUsername();

        string GetPassword();

        string GetBaseUrl();

        string GetHubUrl();

        bool GetRemoteDriverExecution();

        int GetPageLoadTimeOut();

        int GetElementLoadTimeOut();
    }
}