using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Utils.Settings.Interface;
using OpenQA.Selenium;

namespace DesafioAutomacaoWeb.Utils.Settings
{
    public class ObjectRepository
    {
        public static IConfig Config { get; set; }
        public static IWebDriver Driver { get; set; } 

        public static HomePage HomePage;
        public static LoginPage LoginPage;
    }
}
