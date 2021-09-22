using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace DesafioAutomacaoWeb.Utils.Helpers
{
    public static class FileUploadHelper
    {
        public static void LocalDetector()
        {
            var allowsDetection = ObjectRepository.Driver as IAllowsFileDetection;
            if (allowsDetection != null)
            {
                allowsDetection.FileDetector = new LocalFileDetector();
            }
        }
    }
}
