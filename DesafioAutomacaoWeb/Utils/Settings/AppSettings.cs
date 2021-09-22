using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DesafioAutomacaoWeb.Utils.Settings
{
    public class AppSettings
    {
        public AppSettings()
        {
            Browser = ReturnParamAppSettings("Browser");
            Username = ReturnParamAppSettings("User");
            Password = ReturnParamAppSettings("Password");
            BaseUrl = ReturnParamAppSettings("BaseUrl");
            HubUrl = ReturnParamAppSettings("HubUrl");
            PageLoadTimeOut = ReturnParamAppSettings("PageLoadTimeOut");
            ElementLoadTimeOut = ReturnParamAppSettings("ElementLoadTimeOut");
            DbConnection = ReturnParamAppSettings("DbConnection");
            RemoteDriverExecution = Boolean.Parse(ReturnParamAppSettings("RemoteDriverExecution"));
        }

        public string Browser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string BaseUrl { get; set; }
        public string HubUrl { get; set; }
        public string PageLoadTimeOut { get; set; }
        public string ElementLoadTimeOut { get; set; }
        public string DbConnection { get; set; }
        public bool RemoteDriverExecution { get; set; }

        public static string ReturnParamAppSettings(string nameParam)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            return config[nameParam];
        }
    }
}