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

        string GetRemoteDriverExecution();

        int GetPageLoadTimeOut();

        int GetElementLoadTimeOut();
    }
}