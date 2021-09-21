using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Utils.Settings.Interface;
using OpenQA.Selenium;

namespace DesafioAutomacaoWeb.Utils.Settings
{
    public static class ObjectRepository
    { 
        public static IConfig Config { get; set; }
        public static IWebDriver Driver { get; set; }
    }
}