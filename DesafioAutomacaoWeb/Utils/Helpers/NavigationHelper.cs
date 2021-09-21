using DesafioAutomacaoWeb.Utils.Settings;

namespace DesafioAutomacaoWeb.Utils.Helpers
{
    public static class NavigationHelper
    {
        public static void NavigateToUrl(string Url)
        {
            ObjectRepository.Driver.Navigate().GoToUrl(Url);
        }
    }
}